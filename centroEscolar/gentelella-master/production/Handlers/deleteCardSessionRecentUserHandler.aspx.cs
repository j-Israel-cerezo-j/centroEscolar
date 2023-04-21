using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json.Linq;

using Newtonsoft.Json;

namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class deleteCardSessionRecentUserHandler : System.Web.UI.Page
    {
        public string getJsonResponse { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            recoverData();
        }        
        private void recoverData()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                var userCookie = Request.Form["cookieUserDelete"];
                if (userCookie!=null && userCookie!="")
                {
                    var cookieUser = Request.Cookies.Get(userCookie);
                    if (cookieUser != null)
                    {
                        cookieUser.Expires = DateTime.Now.AddDays(-2);
                        Response.Cookies.Add(cookieUser);
                        response.success = true;
                    }
                }                
            }
            catch (Exception e)
            {
                response.error = "¡Error inesperado en el servidor!";
            }

            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private string getValueBynameValueCookieIndex(string cookieNameUser)
        {
            var cookies = Request.Cookies;
            var valuesCookie = cookies.Get(cookieNameUser);
            return valuesCookie.Values[0];
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