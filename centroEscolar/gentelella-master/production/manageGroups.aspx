<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageGroups.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageGroups" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar grupos</title>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">	
	<div class="x_panel">					
		<div class="x_content">
			<h2 id="labelMsjAction">Agregar grupo</h2>
			<br>
			<form id="form1" class="row g-3 needs-validation" novalidate>
				<div class="col-lg-6 col-md-6 col-sm-6 form-group" style="margin-top:20px">
					<input style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="grupo" id="grupo" placeholder="Agregar grupo" onkeyup="onkeyupInputEmtyy('grupo')">
					<div class="valid-feedback">
						¡ Buen trabajo!
					</div>
					<div class="invalid-feedback">
						Nombre del grupo es requerido
					</div>
					<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
				</div>
				<div class="col-lg-6 col-md-6 col-sm-6 form-group" style="margin-top:20px">
					<input style="border-radius:6px" type="number" class="form-control has-feedback-left" required="required" name="numAlum" id="numAlum" placeholder="Número de alumnos para el grupo" onkeyup="onkeyupInputEmtyy('numAlum')">
					<div class="valid-feedback">
						¡ Buen trabajo!
					</div>
					<div class="invalid-feedback">
						El número de alumnos es requerido
					</div>
					<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
				</div>
				<div class="row" style="margin-top:20px">
					<div class="col-lg-3 col-md-12 col-sm-12" style="margin-right:15px" >
						<div class="form-check">
							<input style="padding:10px" id="checkFull" class="form-check-input" type="checkbox" onchange="checkFullCarrers()">
							<label style="margin-left:8px" class="form-check-label" for="flexCheckChecked">
								Seleccionar todas las casillas
							</label>
						</div>
					</div>
				</div>
				<div class="row" id="sd">
				<%if (getCarrerList != null)
				{%>       <h4 style="margin-top:25px;">Seleccione una o mas carreas a las cuales pertenecera el grupo a agregar</h4>
						<%foreach (var item in getCarrerList) {  %>							
							<div id="checksCarrers" class="col-lg-3 col-md-3 col-sm-12 col-xsm-12" style="padding:10px;margin-right:15px">					    
								<div class="form-check">
									<input style="padding:10px" class="form-check-input" type="checkbox" value="<%=item.idCarrera %>" id="ckechCarrer<%=item.idCarrera %>"  name="checksCarrers">
									<label style="margin-left:8px" class="form-check-label" for="flexCheckChecked">
										<%=item.nombre %>
									</label>
								</div>
							</div>							
						<%}
				}
				%>
				</div>
				<div class="form-group row" style="margin-top:20px;">
					<div class="col-md-6 col-sm-6" id="ctrl-principal">
						<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deleteGroup(event)">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
								<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
							</svg>
							Eliminar
						</button>
						<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addG()">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
								<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
							</svg>
							Agregar
						</button>
					</div>
					<div class="col-md-6 col-sm-6" id="ctrl-update" style="display: none">
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
				<input type="hidden" name="catalogo" value="grupos" />
			</form>
			<div style="margin-top:30px;" class="x_title"></div>
			<h2>Grupos<small></small></h2>
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
			<div id="containerTableGroups"></div>				
			<%-- Tabla Final--%>
		</div>
	</div>
    <script src="js/personalizados/groups/addGroup.js"></script>
	<script src="js/personalizados/groups/delete.js"></script>
    <script src="js/personalizados/groups/update.js"></script>
    <script src="js/personalizados/groups/recoverDatas.js"></script>
    <script src="js/personalizados/groups/buildTableGroups.js"></script>
    <script src="js/personalizados/groups/OnkeyupSearch.js"></script>
    <script src="js/personalizados/groups/checksFullCarrers.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>
    
    <script src="js/personalizados/Ajax/recoverData.js"></script>
    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>            

    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>	
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
	<script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>

	<script type="text/javascript">
		window.onload = function () {
			const json = <%=getJsonGroups%>;
            buildTableGroups(json);
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