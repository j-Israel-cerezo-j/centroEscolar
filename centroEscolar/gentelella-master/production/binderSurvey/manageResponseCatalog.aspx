<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageResponseCatalog.aspx.cs" Inherits="centroEscolar.gentelella_master.production.binderSurvey.manageResponseCatalog" MasterPageFile="~/gentelella-master/production/binderSurvey/masterCentroEscolar.Master" %>


<asp:content id="Content3" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar respuestas de preguntas</title>
    <link href="../css/personalizados/buttons.css" rel="stylesheet" />
    <link href="../css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 

<asp:content id="Content4" ContentPlaceHolderID="bodyContent" runat="server">
	<div class="x_panel">					
		<div class="x_content">
			<h2 id="labelMsjAction">Agregar posible respuestas </h2>
			<br>
			<form id="form1"  class="g-3 needs-validation" novalidate>
				<div class="row" style="margin-top:15px">
					<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12 form-group" >																				
						<input style="border-radius:6px" type="text" class="form-control has-feedback-left" id="descripcion" name="descripcion" placeholder="Escribe tu respuesta" required="required" onkeyup="onkeyupInputEmtyy('descripcion')"/>
						<div id="containerMjsValidOrInValid"></div>
						<div class="valid-feedback">
							¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Nombre del rol es requerido
						</div>
						<span class="fa fa-user form-control-feedback left " aria-hidden="true"></span>															
					</div>
					<div class="col-lg-6 col-md-12 col-sm-12 col-xsm-12" style="margin-top:20px;">
						<div class="form-group">
							<div style="margin-left: 0px;" class="col-md-7 col-sm-7" id="ctrl-principal">								
								<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deleteQuestionsAnswer(event)">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
										<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
									</svg>
									Eliminar
								</button>
								<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addReponse()">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
										<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
									</svg>
									Agregar
								</button>
							</div>
							<div class="col-md-7 col-sm-7" id="ctrl-update" style="display: none;margin-left: 0px;">
								<button type="button" class="btn btn-primary reflejo" id="save"  onclick="update()" >
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-save-fill" viewBox="0 0 16 16">
									  <path d="M8.5 1.5A1.5 1.5 0 0 1 10 0h4a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h6c-.314.418-.5.937-.5 1.5v7.793L4.854 6.646a.5.5 0 1 0-.708.708l3.5 3.5a.5.5 0 0 0 .708 0l3.5-3.5a.5.5 0 0 0-.708-.708L8.5 9.293V1.5z"/>
									</svg>
									Guardar
								</button>
								<button type="button" class="btn btn-danger reflejo" id="cancel" onclick="cancelUpdate()">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-octagon-fill" viewBox="0 0 16 16">
									  <path d="M11.46.146A.5.5 0 0 0 11.107 0H4.893a.5.5 0 0 0-.353.146L.146 4.54A.5.5 0 0 0 0 4.893v6.214a.5.5 0 0 0 .146.353l4.394 4.394a.5.5 0 0 0 .353.146h6.214a.5.5 0 0 0 .353-.146l4.394-4.394a.5.5 0 0 0 .146-.353V4.893a.5.5 0 0 0-.146-.353L11.46.146zm-6.106 4.5L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 1 1 .708-.708z"/>
									</svg>
									Cancelar
								</button>
							</div>
							<div class="col-lg-4 col-md-4 col-sm-9">
								<button style="padding:10px" class="btn btn-secondary reflejo" type="reset">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
									  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2v1z"/>
									  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466z"/>
									</svg>
									Limpiar
								</button>
							</div> 
						</div>	
					</div>
				</div>						
				<input type="hidden" value="questionsAnswer" name="catalogo" />
			</form>
			<div style="margin-top:30px;" class="x_title"></div>
			<h2>Respuestas<small></small></h2>
			<div class="row" style="justify-content:right;">
				<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12"  style="margin-top:30px;">
					<form id="formOnkeyup">												
						<div class="input-group" > 
						    <div class="form-outline" style="width: 100%;">
								<svg style=" position: absolute;width: 20px; height: 20px; left: 12px; top: 50%; transform: translateY(-50%);" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
	    							<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
	    						</svg>
						        <input class="form-control" list="datalistOptionsSerch" id="exampleDataList" placeholder="Buscar..." style="border-radius:10px; width: 100%;padding-left: 40px;padding-right: 15px;" onkeyup="onkeyupSearchh()" name="onkeyupCoincidencias">
						        <datalist id="datalistOptionsSerch"></datalist>
						    </div>
						</div>
					</form>
				</div>
			</div>
			<%-- Tabla Inicio--%>
			<div class="clearfix"></div>		
			<div id="containerTableQuestionsAnswer"></div>
			<%-- Tabla Final--%>
		</div>
	</div>
    <script src="js/reponses/recoverData.js"></script>
    <script src="js/reponses/onkeyupSearch.js"></script>
    <script src="js/reponses/add.js"></script>
    <script src="js/reponses/delete.js"></script>
    <script src="js/reponses/builTable.js"></script>
    <script src="js/reponses/update.js"></script>

	<script src="js/utils/Ajax/crudCatalogsAjax.js"></script>
    <script src="js/utils/Ajax/onkeyubSearchCatalogos.js"></script>
    <script src="js/utils/switchTablesOnkeyup.js"></script>    
    <script src="js/utils/switchCatalogosRecoverData.js"></script>
    <script src="js/utils/Ajax/recoverDataAjax.js"></script>    
    <script src="js/utils/Ajax/crudCatalogsAjax.js"></script>    
	<script src="../js/personalizados/utils/defaultBtnsDisplay.js"></script>    
	<script src="../js/personalizados/utils/onkeyupInputEmpty.js"></script>    
	<script type="text/javascript">
        window.onload = function () {
            var jsonQuestionsAnswer =<%=getJsonQuestionsAnswer%>
                buildTableQuestionsAnswer(jsonQuestionsAnswer)
            $('#tbl-roles input[type=checkbox]').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                handle: 'checkbox'
            });
            $('#radiosTW input[type=radio]').iCheck({
                radioClass: 'iradio_flat-green',
                handle: 'radio'
            });

            var checkAll = document.getElementById('check-all');
            if (checkAll != undefined) {
                checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
            }
        }

    </script>
</asp:content> 