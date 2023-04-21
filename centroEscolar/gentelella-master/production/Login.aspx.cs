using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using CapaLogicaNegocio;
using CapaLogicaNegocio.utils;
using Entidades;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.Net.Http.Headers;
using CapaLogicaNegocio.Exceptions;

namespace centroEscolar.gentelella_master.production
{
    public partial class Login : System.Web.UI.Page
    {
        private UserService userService = new UserService();

        public List<User> getUsersCookies { get; set; } = null;
        public User getUserCookie { get; set; }
        public string getJsonUsersCookies { get; set; }
        public string getJsonUserCookiesDataIncorrect { get; set; } = "a";
        public string getBlockedAccountMsj { get; set; } = "a";
        public bool getPassIncorrect { get; set; } = false;
        public bool getEmptyPassword { get; set; } = false;
        public bool getPassRemember { get; set; }=false;
        public bool getBlockedAccount { get; set; } = false;
        public bool getModalShow { get; set; } = false;
        public int getIndexValueListUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
            if (Session["user"]!=null)
            {
                Response.Redirect("indexUser.aspx");
            }
            else
            {
                string JQueryVer = "1.7.1"; ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition { Path = "~/Scripts/jquery-" + JQueryVer + ".min.js", DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js", CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js", CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js", CdnSupportsSecureConnection = true, LoadSuccessExpression = "window.jQuery" });
                recoverDataUsersCookies();
            }            
        }

        private void recoverDataUsersCookies()
        {            
            var usersCookies = new List<User>();
            var camposView = new List<string>();

            var cookies = Request.Cookies;
            camposView.Add("nameCookie");
            camposView.Add("nombres");
            camposView.Add("apellidoP");
            camposView.Add("apellidoM");
            camposView.Add("image");
            foreach (var item in cookies)
            {
                var cookieUser = cookies.Get(item.ToString());
                // || 
                //var valuesByKellsCookieUser=cookieUser.Values.AllKeys;
                //foreach (var v in valuesByKellsCookieUser)
                //{
                //    //value tiene el correo del usuario
                //    var value = cookieUser.Values.Get(v);
                //}
                var valueCookieUser=cookieUser.Values[0];                
                var user = userService.retriveUser(valueCookieUser, camposView);
               
                if (user != null)
                {
                    user.nameCookie = cookieUser.Name;
                    usersCookies.Add(user);
                }
            }
            getUsersCookies=usersCookies;
            getJsonUsersCookies = Converter.ToJson(usersCookies);
        }
        private bool ValidateUser(string userName, string passWord,ref string urlRederic)
        {
            
            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] La validación de entrada de correo falló.");
                //vUserName.Text = "Correo falló";
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] La validación de entrada de la contraseña falló.");
                //lblMsg.Text = "Contraseña falló";
                return false;
            }
            return userService.loginUsua(userName, passWord,ref urlRederic);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                lblBlockedAccount.Text = "";
                lblEmailNonexistent.Text = "";
                if (userService.validateIfExistEmailInstitutional(Login1.UserName))
                {
                    string urlRederic = "indexUser.aspx";
                    if (ValidateUser(Login1.UserName, Login1.Password,ref urlRederic))
                    {
                        FormsAuthenticationTicket tkt;
                        string cookiestr;
                        HttpCookie ck;
                        tkt = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now,
                        DateTime.Now.AddMinutes(30), Login1.RememberMeSet, "your custom data");
                        cookiestr = FormsAuthentication.Encrypt(tkt);
                        ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                        if (Login1.RememberMeSet)
                            ck.Expires = tkt.Expiration;
                        ck.Path = FormsAuthentication.FormsCookiePath;
                        Response.Cookies.Add(ck);

                        string strRedirect;
                        strRedirect = Request["ReturnUrl"];
                        if (strRedirect == null)
                            strRedirect = urlRederic;

                        User user = userService.retriveUser(Login1.UserName);
                        //verificar
                        string strRol = userService.rolLoggedIn(user.id);
                        if (Request.Form["checkRemember"] != null)
                        {
                            string valueCheckRemember = Request.Form["checkRemember"];
                            if (valueCheckRemember == "on")
                            {
                                remembermeLater(user, Login1.UserName);
                            }
                        }                        
                        Session["user"] = user;
                        //verificar
                        Session[strRol] = strRol;
                        Response.Redirect(strRedirect, true);
                    }
                    else
                        Response.Redirect("Login.aspx", true);
                }
                else
                {
                    lblEmailNonexistent.Text = "Correo no registrado";
                }
            }
            catch (LoginException ex)
            {
                lblBlockedAccount.Text = ex.getMessage();
            }
        }

        protected void btnLoginModal_Click(object sender, EventArgs e)
        {
            string cookieNameUser = "";
            string valueCookie = "";
            var camposView = new List<string>();
            camposView.Add("nombres");
            camposView.Add("apellidoP");
            camposView.Add("apellidoM");
            camposView.Add("image");            
            try
            {
                string pass = Request.Form["password"];
                cookieNameUser = Request.Form["dataUseridC"];               
                if (cookieNameUser != null)
                {
                    valueCookie = getValueBynameValueCookieIndex(cookieNameUser);
                    if (userService.validateIfExistEmailInstitutional(valueCookie))
                    {
                        if (pass != null && pass != "")
                        {
                            string urlRederic = "indexUser.aspx";
                            if (ValidateUser(valueCookie, pass, ref urlRederic))
                            {
                                User user = userService.retriveUser(valueCookie);
                                string strRol = userService.rolLoggedIn(user.id);
                                remembermeLater(user, valueCookie);
                                Session["user"] = user;
                                Session[strRol] =strRol;
                                Response.Redirect(urlRederic);
                            }
                            else
                            {
                                datasUserCookiesModal(valueCookie, camposView, cookieNameUser);
                                getModalShow = true;
                                getPassIncorrect = true;
                            }
                        }
                        else
                        {
                            datasUserCookiesModal(valueCookie, camposView, cookieNameUser);
                            getModalShow = true;
                            getEmptyPassword = true;
                        }
                    }
                }
            }
            catch (LoginException ex)
            {
                getModalShow = true;
                getBlockedAccount = true;
                getBlockedAccountMsj = ex.getMessage();
                datasUserCookiesModal(valueCookie,camposView, cookieNameUser);
            }
        }
        private void datasUserCookiesModal(string valueCookie, List<string> camposView,string cookieNameUser)
        {
            var usersCookiesIncorrectData = new List<User>();
            var user = userService.retriveUser(valueCookie, camposView);
            user.nameCookie = cookieNameUser;
            usersCookiesIncorrectData.Add(user);
            getJsonUserCookiesDataIncorrect = Converter.ToJson(usersCookiesIncorrectData);            
        }
        private string getValueBynameValueCookieIndex(string cookieNameUser)
        {
            var cookies = Request.Cookies;            
            var valuesCookie = cookies.Get(cookieNameUser);
            return valuesCookie.Values[0];
        }
        private void remembermeLater(User user,string email)
        {
            var cookieUser = Request.Cookies.Get("user" + user.id);
            if (cookieUser != null)
            {                
                cookieUser.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Add(cookieUser);
            }
            else
            {               
                HttpCookie cookieNewUser = new HttpCookie("user"+user.id);
                cookieNewUser.Values["valueEmail1"] = email.Trim();
                Response.Cookies.Add(cookieNewUser);
                cookieNewUser.Expires = DateTime.Now.AddDays(2);
            }
            //HttpCookie cookieEmail = new HttpCookie("tokenEmail", email);
            //cookieEmail.Expires = DateTime.Now.AddDays(2);
            //this.Response.Cookies.Add(cookieEmail);
            //HttpCookie cookiePassword = new HttpCookie("tokenPassword", pass);
            //cookiePassword.Expires = DateTime.Now.AddDays(2);
            //this.Response.Cookies.Add(cookiePassword);
            //HttpCookie cookieImage = new HttpCookie("tokenImage", user.image);
            //cookieImage.Expires = DateTime.Now.AddDays(2);
            //this.Response.Cookies.Add(cookieImage);

            //HttpCookie cookieNames = new HttpCookie("tokenNames", user.nombres);
            //cookieNames.Expires = DateTime.Now.AddDays(2);
            //this.Response.Cookies.Add(cookieNames);

            //HttpCookie cookieLastName = new HttpCookie("tokenLastName", user.apellidoP + " " + user.apellidoM);
            //cookieLastName.Expires = DateTime.Now.AddDays(2);
            //this.Response.Cookies.Add(cookieLastName);

        }
        private void expirerCookies(User user, string email, string pass)
        {
            HttpCookie cookieEmail = new HttpCookie("tokenEmail", email);
            cookieEmail.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(cookieEmail);
            HttpCookie cookiePassword = new HttpCookie("tokenPassword", pass);
            cookiePassword.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(cookiePassword);

            HttpCookie cookieImage = new HttpCookie("tokenImage", user.image);
            cookieImage.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(cookieImage);

            HttpCookie cookieNames = new HttpCookie("tokenNames", user.nombres);
            cookieNames.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(cookieNames);

            HttpCookie cookieLastName = new HttpCookie("tokenLastName", user.apellidoP + " " + user.apellidoM);
            cookieLastName.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(cookieLastName);
        }
     
     
    }
}