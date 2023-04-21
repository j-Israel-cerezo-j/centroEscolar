<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="centroEscolar.gentelella_master.production.binderSurvey.Encuesta" MasterPageFile="~/gentelella-master/production/binderSurvey/masterSurvay.Master" %>


<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<link href="css/cssEncuesta.css" rel="stylesheet" />
	<title>Encuesta</title>
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<form id="form1">
        <div style="margin-top:150px" id="todo" class="col-lg-12 col-md-12 col-xs-12">
            <div class="titulo">
                <h2>Cuestionario De Desercion Escolar</h2>
            </div>
            <div class="container">
                <div class="row preguntas">
                    <div class="col-12 col-md-12 col-lg-12 col-xs-12">
                        <div>
                            <h3>UNIVERSIDAD</h3>
                        </div>
                        <div class="mb-3">
                            <label for="exampleFormControlInput1" class="form-label">Universidades de puebla</label>
                             <select name="slcUnivesitys" class="form-select" aria-label="Default select example">
                                <option selected="selected" value="-1">Seleccion una opcion</option>
                                <%if (getUniversitysList!=null)
                                    {
                                        foreach (var item in getUniversitysList)
                                        {%>
                                            <option  value="<%=item.universidad_id %>"><%=item.universidad_nombre %></option>
                                        <%}
                                    } %>
                            </select>
                        </div>                        
                    </div>
                </div>
                <div class="row preguntas">
                    <div class="col-12 col-md-12 col-lg-12 col-xs-12">
                        <div>
                            <h3>DATOS PERSONALES</h3>
                        </div>
                        <div class="mb-3">
                            <label for="exampleFormControlInput1" class="form-label">Nombres</label>
                            <input type="text" name="nombres" class="form-control" id="exampleFormControlInput1" placeholder="Escribe tu nombre" required/>
                        </div>
                        <div class="mb-3">
                            <label for="exampleFormControlInput1" class="form-label">Apellido Paterno</label>
                            <input type="text" name="apellidoP" class="form-control" id="exampleFormControlInput2" placeholder="Escribe tu apellido paterno" required/>
                        </div>
                        <div class="mb-3">
                            <label for="exampleFormControlInput1" class="form-label">Apellido Materno</label>
                            <input  type="text" name="apellidoM" class="form-control" id="exampleFormControlInput3" placeholder="Escribe tu apellido materno" required/>
                        </div>
                        <div class="mb-3">
                            <label for="exampleFormControlInput1" class="form-label">Correo Electronico</label>
                            <input type="email" name="email" class="form-control" id="exampleFormControlInput4" placeholder="Escribe tu correo electronico" required/>
                        </div>
                    </div>
                </div>


                <div id="containerQuestions">

                </div>                               
            </div>
            <div class="boton" style="margin-bottom:10px">
                <button type="button" class="btn btn-outline-warning" onclick="addSurveys()">Enviar</button>
            </div>
        </div>
        <input type="hidden" value="encuesta" name="catalogo" />
        <footer class="bg-dark p-2 text-center">
            <div class="container">
                <p class="text-white"> Copyright © 2022. Todos los derechos reservados.</p>
            </div>
        </footer>
    </form>
    <script src="js/encuesta/ajax/closeSessionAjax.js"></script>
    <script src="js/encuesta/groupQuestionAndAnswerAndAddItToTheFormm.js"></script>
    <script src="js/encuesta/add.js"></script>
    <script src="js/utils/Ajax/crudCatalogsAjax.js"></script>
    <script src="js/encuesta/buildQuestionsWhitdAnswer.js"></script>
    <script src="js/encuesta/onkeyupSearchUniversity.js"></script>
    <script src="js/utils/Ajax/onkeyupSearchUniversitysAjax.js"></script>
    <script src="js/encuesta/buildUniversidades.js"></script>
    <script src="js/universidades.js"></script>        
    <script type="text/javascript">
        window.onload = function () {
            var questionsList =<%=getJsonQuestions %>
                buildQuestionsWhitdAnswer(questionsList);


        }
    </script>
</asp:content> 
