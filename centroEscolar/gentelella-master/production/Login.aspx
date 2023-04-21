<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="centroEscolar.gentelella_master.production.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link rel="icon" href="images/perzonalizadas/logos/controlEscolIcon.png" type="image/jpeg" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Control - Entrar</title>

    <!-- Bootstrap -->
    <link href="bootstrap-5.0.2-dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <!-- Font Awesome -->
    
    <link href="css/personalizados/login/style.css" rel="stylesheet" />
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />    
    <link href="css/personalizados/errors.css" rel="stylesheet" />
</head>
<body >    
    <form id="formLogin" runat="server">
    <section class="vh-100">
        <div class="container-fluid h-custom">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-md-9 col-lg-6 col-xl-5" >                   
                      <%if (getUsersCookies.Count == 0)
                    {%>
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
                        class="img-fluid" alt="Sample image">
                    <%} %>                    
                    <%else if (getUsersCookies.Count> 0)
                    {%>           
                        <div class="row">
                            <h2 style="text-align:center;color:green;font-family: SFProDisplay-Regular, Helvetica, Arial, sans-serif;font-size: 28px;font-weight: normal;line-height: 32px;">
                                <strong>Inicios de sesión recientes</strong>
                            </h2>
                        </div>
                        <div class="row" style=" background-image: url('https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp'); background-position: center;background-repeat: no-repeat;background-size: contain;">
                        <%for (int i = getUsersCookies.Count==1? 0:getUsersCookies.Count-1; i >= getUsersCookies.Count-3&&i>=0; i--)
                            {%>  
                            <%if (getUsersCookies[i] != null)
                                { %>        
                                    <div style="margin-top:20px;display: flex;justify-content: center;" class="col-lg-3 col-md-6 col-sm-12 col-xsm-12">
                                        <div class="card" style="width: 10rem;min-width: 158px;" onclick="toShowModal('<%=getUsersCookies[i].nameCookie %>')">                                                                                       
                                            <button type="button" class="_42ft _2d4g _t7b" id="btnSessionRecent<%=getUsersCookies[i].nameCookie%>" onclick="deleteSessionRecentUser('<%=getUsersCookies[i].nameCookie%>',event)"></button>
                                            <img id="image" alt="Cargar fotografía por favor." src="<%=getUsersCookies[i].image %>" height="130" width="158"/>
                                            <div class="card-body">
                                                <b style="font-size: 17px;"><%=getUsersCookies[i].nombres + " " + getUsersCookies[i].apellidoP %></b>
                                            </div>
                                        </div>
                                    </div>
                            <%}%>
                        <%}%>     
                        </div>
                    <%}%>     
                </div>
                <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">                    
                    <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                        <p class="lead fw-normal mb-0 me-3">Iniciar sesión</p>
                        <button type="button" class="btn btn-primary btn-floating mx-1">
                            <i class="fab fa-facebook-f"></i>
                        </button>
                        <button type="button" class="btn btn-primary btn-floating mx-1">
                            <i class="fab fa-twitter"></i>
                        </button>
                        <button type="button" class="btn btn-primary btn-floating mx-1">
                            <i class="fab fa-linkedin-in"></i>
                        </button>
                    </div>
                    <div class="divider d-flex align-items-center my-4">
                        <p class="text-center fw-bold mx-3 mb-0">Con</p>
                    </div>
                    <span class="invalid-feedback" role="alert" style="display:inline;">
                            <strong style=" font-family:Verdana">
                                <asp:Label Font-Names="Verdana" ID="lblEmailNonexistent" runat="server"></asp:Label>
                            </strong>
                             <strong style=" font-family:Verdana">
                                <asp:Label Font-Names="Verdana" ID="lblBlockedAccount" runat="server"></asp:Label>
                            </strong>
                        </span>
                     <AnonymousTemplate>
                        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" CssClass="loginWhite">
                            <LayoutTemplate>
                                <!-- Email input -->
                                <div class="form-outline mb-4">
                                    <div class="row">
                                        <asp:RequiredFieldValidator ID="UserNameRequired" CssClass="errorMessage" runat="server" ControlToValidate="UserName" ErrorMessage="Correo obligatorio." ToolTip="Correo obligatorio." ValidationGroup="ctl00$Login1">Correo obligatorio.</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="input-group w-70">
                                        <span class="input-group-text" id="basic-addon2">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                                                <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z"></path>
                                                <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z"></path>
                                            </svg>
                                        </span>                                           
                                        <asp:TextBox CssClass="form-control form-control-lg" aria-label="Input group example" placeholder="Correo institucional" ID="UserName" runat="server"></asp:TextBox>
                                    </div>                                      
                                    <div class="row">
                                        <label class="form-label" for="form3Example3">Correo</label>
                                    </div>                                                                                
                                </div>
                                <!-- Password input -->
                                <div class="form-outline mb-3">
                                    <div class="row">
                                        <asp:RequiredFieldValidator ID="PasswordRequired" CssClass="errorMessage" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="ctl00$Login1">La contraseña es obligatoria.</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="input-group w-70">
                                        <span class="input-group-text" id="basic-addon1">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-lock-fill" viewBox="0 0 16 16">
                                                <path d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2z"></path>
                                            </svg>
                                        </span>                                            
                                        <asp:TextBox CssClass="form-control form-control-lg" aria-label="Input group example"  placeholder="Contraseña" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <span style="position: absolute;right:10px;top:15px">
                                            <svg style="display:block" id="slash" xmlns="http://www.w3.org/2000/svg" width="16" onclick="hideshow('Login1_Password','slash','eye')" height="16" fill="currentColor" class="bi bi-eye-fill" viewBox="0 0 16 16">
                                              <path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"/>
                                              <path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z"/>
                                            </svg>
		            	                </span>
                                        <span style="position: absolute;right:10px;top:15px">
                                            <svg style="display:none" id="eye" xmlns="http://www.w3.org/2000/svg" width="16" onclick="hideshow('Login1_Password','slash','eye')" height="16" fill="currentColor" class="bi bi-eye-slash-fill" viewBox="0 0 16 16">
                                                <path d="m10.79 12.912-1.614-1.615a3.5 3.5 0 0 1-4.474-4.474l-2.06-2.06C.938 6.278 0 8 0 8s3 5.5 8 5.5a7.029 7.029 0 0 0 2.79-.588zM5.21 3.088A7.028 7.028 0 0 1 8 2.5c5 0 8 5.5 8 5.5s-.939 1.721-2.641 3.238l-2.062-2.062a3.5 3.5 0 0 0-4.474-4.474L5.21 3.089z"/>
                                                <path d="M5.525 7.646a2.5 2.5 0 0 0 2.829 2.829l-2.83-2.829zm4.95.708-2.829-2.83a2.5 2.5 0 0 1 2.829 2.829zm3.171 6-12-12 .708-.708 12 12-.708.708z"/>
                                            </svg>
		            	                </span>
                                    </div>                                        
                                    <div class="row">
                                        <label class="form-label" for="form3Example4">Contraseña</label>
                                    </div>
                                </div> 
                                <div clas="d-flex justify-content-between align-items-center">
                                    <!-- Checkbox -->
                                    <div class="form-check mb-0">
                                        <%--<asp:CheckBox ID="checkRemember" CssClass="checkRemmemberAccountPadding form-check-input me-2" runat="server" />--%>
                                        <input checked style="padding:10px" class="form-check-input me-2" name="checkRemember" type="checkbox"  id="form2Example3" />
                                        <label class="form-check-label" for="form2Example3">
                                          Recordar cuenta
                                        </label>
                                    </div>                                       
                                </div>
                                <div>
                                <div  class="text-center text-lg-start mt-4 pt-2" style=" text-align:center">
                                    <asp:Button CssClass="btn btnSuccesssRegistro reflejo btn-lg btnLogin" ID="LoginButton" runat="server" CommandName="Login" Text="Iniciar sesión" ValidationGroup="ctl00$Login1"/>
                                    <p class="small fw-bold mt-2 pt-1 mb-0">Versión de prueba 
                                        <%--<a  href="preRegisterStudent.aspx" class="link-danger">Registrate</a>--%>
                                    </p>
                                    <p class="link-danger">
                                        1.0.0
                                    </p>
                                </div>
                                <div class="text-center text-lg-start mt-4 pt-2" style=" text-align:center">
                                    <p style="text-align:center" class="s mt-2 pt-1 mb-0">¿Quieres regresar al inicio? 
                                        <a href="index.aspx" class="link-danger">Inicio</a>
                                    </p>
                                </div>
                            </LayoutTemplate>
                        </asp:Login>
                    </AnonymousTemplate>                  
                </div>
            </div>
        </div>
        <div class="row" style="width: 100%;position:fixed">
            <div
              class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5" style="background-color: #0b9624;">
                <!-- Copyright -->
                <div class="text-white mb-3 mb-md-0">
                  Copyright © 2022. Todos los derechos reservados.
                </div>
              <!-- Copyright -->

              <!-- Right -->
                <div>
                    <a href="#!" class="text-white me-4">
                      <i class="fab fa-facebook-f"></i>
                    </a>
                    <a href="#!" class="text-white me-4">
                      <i class="fab fa-twitter"></i>
                    </a>
                    <a href="#!" class="text-white me-4">
                      <i class="fab fa-google"></i>
                    </a>
                    <a href="#!" class="text-white">
                      <i class="fab fa-linkedin-in"></i>
                    </a>
                </div>
              <!-- Right -->
            </div>
        </div>
    </section>
     <%if (getUsersCookies != null)
        {%>        
            <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content reflejo">
                        <div class="modal-body">
                            <div class="row" style="justify-content:center;margin-top:40px">
                                <div class="col-10" style="text-align:center;border-radius:10px">
                                    <img id="imgUser" src=""  alt="..." class="img-circle profile_img" height="250" style="border-radius: 50%;width: 55%;height: 165px;" />
                                </div>                
                            </div>
                            <div class="row" style="text-align:center;margin-top:20px;">
                                <p id="namesUser" style="font-size: 17px;"></p>
                            </div>
                            <div class="row" style="text-align:center;padding:30px">
                                <div class="form-group">
                                    <%if (getPassIncorrect)
                                        { %>
                                        <span class="invalid-feedback" role="alert" style="display: inline">
                                            <strong id="passwordIncorrect">Contraseña incorrecta</strong>
                                        </span>
                                    <%} %>
                                     <%if (getEmptyPassword)
                                         { %>
                                        <span class="invalid-feedback" role="alert" style="display: inline">
                                            <strong id="ObligatoryField">La contraseña es obligatoria</strong>
                                        </span>
                                    <%} %>
                                      <%if (getBlockedAccount)
                                          { %>
                                        <span class="invalid-feedback" role="alert" style="display: inline">
                                            <strong id="blockedAccount"><%=getBlockedAccountMsj %></strong>
                                        </span>
                                    <%} %>
                                    <input style="border-radius:8px" class="form-control form-control-lg" id="passwordModal" name="password" type="password" placeholder="Contraseña" onkeyup="enterForm(event)">
                                    <span style="position: absolute;left: 420px;bottom: 200px;">
		            			        <i id="eyeModal" class="fa fa-eye" style="display:none; width:100%" onclick="hideshow('passwordModal','slashModal','eyeModal')"></i>
                                        <i id="slashModal" class="fa fa-eye-slash" style="display: block;width:100%"  onclick="hideshow('passwordModal','slashModal','eyeModal')"></i>
		            			    </span> 
                                </div>
                            </div>
                            <input type="hidden"  name="dataUseridC" id="dataUseridC" />
                            <div class="form-check" style="margin-left:30px">
                                <input style="padding:10px" class="form-check-input" type="checkbox" name="checkboxRememberPass">
                                <label style="margin-left:8px; margin-top:8px;" class="form-check-label" for="flexCheckDefault">
                                    Recordar contraseña <b><i>  Inhabilitado por el momento</i></b> 
                                </label>
                            </div>
                            <div class="row" style="text-align:center;padding:0px 40px 40px 40px; margin-top:15px;">
                                <asp:Button  CssClass="btn radiusBorder btnSuccesss" ID="btnLoginModal" runat="server" Text="Iniciar sesión" OnClick="btnLoginModal_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <%} %>
        <script src="../vendors/jquery/dist/jquery.min.js"></script>
        <script src="js/personalizados/Login/sessionRecentUser.js"></script>
        <script src="js/personalizados/Login/ajax/deleteSessionRecentAjax.js"></script>    
        <script src="js/personalizados/utils/hideshow.js"></script>
        <script src="bootstrap-5.0.2-dist/js/bootstrap.min.js"></script>
        <script type="text/javascript">
            var recentSessions = "";
            function toShowModal(valueList) {
                if (recentSessions != "") {
                    if (document.getElementById("passwordIncorrect") != undefined) {
                        document.getElementById("passwordIncorrect").innerText = ""
                    }
                    if (document.getElementById("ObligatoryField") != undefined) {
                        document.getElementById("ObligatoryField").innerText = ""
                    }
                    if (document.getElementById("blockedAccount") != undefined) {
                        document.getElementById("blockedAccount").innerText = ""
                    }
                    var datas;
                    for (var i = 0; i < recentSessions.length; i++) {
                        if (recentSessions[i].c == valueList) {
                            datas = recentSessions[i];
                            break;
                        }
                    }
                    var imgUser = document.getElementById("imgUser");
                    imgUser.setAttribute('src', datas.imagen);
                    document.getElementById("dataUseridC").value = datas.c;
                    document.getElementById("namesUser").innerText = datas.nombres + " " + datas.apellidoP
                    $('#exampleModalLong').modal('show')
                }
            }
            function enterForm(event) {
                event.preventDefault();
                if (event.keyCode === 13) {
                    document.getElementById("btnLoginModal").click();
                }
            }
            document.addEventListener('DOMContentLoaded', function () {
                var modalShow = "<%=getModalShow%>";
                var UserCookiesDataIncorrect = ""
                if (modalShow === "True") {
                    UserCookiesDataIncorrect =<%=getJsonUserCookiesDataIncorrect%>;
                    console.log(UserCookiesDataIncorrect)
                    var imgUser = document.getElementById("imgUser");
                    imgUser.setAttribute('src', UserCookiesDataIncorrect[0].imagen);
                    document.getElementById("namesUser").innerText = UserCookiesDataIncorrect[0].nombres + " " + UserCookiesDataIncorrect[0].apellidoP
                    document.getElementById("dataUseridC").value = UserCookiesDataIncorrect[0].c;
                    $('#exampleModalLong').modal('show')
                }
                recentSessions =<%=getJsonUsersCookies%>;
                console.log(recentSessions)
                document.getElementById("Login1_UserName").style.borderRadius = "8px";
                document.getElementById("Login1_Password").style.borderRadius = "8px";
                document.getElementById("Login1_LoginButton").style.borderRadius = "8px";
                document.getElementById("btnLoginModal").style.borderRadius = "8px";
            });        
           
        </script>
</form>
</body>
</html>
