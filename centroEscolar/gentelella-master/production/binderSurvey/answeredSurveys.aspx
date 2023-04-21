<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="answeredSurveys.aspx.cs" Inherits="centroEscolar.gentelella_master.production.binderSurvey.answeredSurveys" MasterPageFile="~/gentelella-master/production/binderSurvey/masterSurvay.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<link href="css/cssEncuesta.css" rel="stylesheet" />
	<title>Encuestas contestadas</title>
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<div class="container" style="margin-top:150px">
        <div class="row preguntas">
            <div class="col-12 col-md-12 col-lg-12 col-xs-12">
                <div>
                    <h3 style="text-align:center">Encuestas contestadas totales</h3>
                </div>
                <div class="mb-3">
                    <%if (getCountAnsweredSurveys>0)
                        { %>
                            <h1 style="text-align:center"><%=getCountAnsweredSurveys %></h1>
                    <%}
                    else
                    {%>
                        <p>Aún no hay encuestas contestadas</p>
                    <%} %>
                </div>
            </div>
        </div>
        <div class="row preguntas">
            <div class="col-12 col-md-12 col-lg-12 col-xs-12">
                <div>
                    <h3>Encuestas contestadas</h3>
                </div>
                <div class="mb-3">
                    <div id="containerTable">

                    </div>
                </div>                           
            </div>
        </div>   
    </div>
    <script src="js/answeredSurveys/buildTable.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            var jsonTableAnsweredSurveys =<%=getJsonTableAnsweredSurveys%>
                buildTable(jsonTableAnsweredSurveys)
        }
    </script>
</asp:content> 
