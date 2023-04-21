<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageHours.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageHours" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar horas</title>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
    
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">	
	<div class="x_panel">					
		<div class="x_content">
			<h2 id="labelMsjAction">Agregar hora</h2>
			<br>
			<form id="form1" class="row g-3 needs-validation" novalidate>											
				<div class="row" style="margin-top:20px">
					<div class="item col-lg-6 col-sm-12">
						<label class="col-form-label col-md-3 col-sm-3 label-align">Hora inicio
							<span class="required">*</span>
						</label>
						<input id="horaInicio" type="time" class="form-control" name="horaInicio" value="07:00" required>
						<div class="valid-feedback">
							¡ Buen trabajo!
						</div>					
					</div>
					<div class="item col-lg-6 col-sm-12">
						<label class="col-form-label col-md-3 col-sm-3 label-align">Hora término
							<span class="required">*</span>
						</label>
						<input id="horaTermino" type="time" class="form-control" name="horaTermino" value="07:50" required>
						<div class="valid-feedback">
							¡ Buen trabajo!
						</div>	
					</div>
				</div>	
				<br />
				<div class="form-group row" style="margin-top:20px">
					<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-principal">								
						<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deleteHours(event)">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
								<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
							</svg>
							Eliminar
						</button>
						<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addHour()">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
								<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
							</svg>
							Agregar
						</button>
					</div>
					<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-update" style="display: none">
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
				</div>
				<input type="hidden" name="catalogo" value="horas" />
			</form>					
		</div>
		<%-- Tabla Inicio--%>
		<div class="clearfix"></div>
		<div id="containerTableHours"></div>
		<%-- Tabla Final--%>
	</div>			
    <script src="js/personalizados/hours/add.js"></script>
    <script src="js/personalizados/hours/buildTableHours.js"></script>
    <script src="js/personalizados/hours/delete.js"></script>
    <script src="js/personalizados/hours/recoverData.js"></script>
    <script src="js/personalizados/hours/update.js"></script>
    <script src="js/personalizados/hours/OnkeyupSearch.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>

    <script src="js/personalizados/Ajax/recoverData.js"></script>
    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>  
  
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/currentDate.js"></script>
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
	
    <!-- Bootstrap -->
	<script type="text/javascript">
		window.onload = function () {
			const json = <%=getJsonHours%>;
            buildTableHours(json);
            $('#tbl-roles input[type=checkbox]').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                handle: 'checkbox'
            });
			var checkAll = document.getElementById('check-all');
			if (checkAll != undefined) {
                checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
			}
		}       
    </script>
</asp:content> 