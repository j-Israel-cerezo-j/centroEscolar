<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageClassrooms.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageClassrooms" MasterPageFile="~/gentelella-master/production/Site1.Master" %>
<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar salones</title>
	<script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">	
	<div class="x_panel">
		<div class="x_content">
			<h2 id="labelMsjAction">Agregar salón</h2>
			<br>
			<form id="form1" class="row g-3 needs-validation" novalidate>
				<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12 form-group" style="margin-top:15px;padding-right: 0px;padding-left:10px;">
					<input  style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="clave" id="clave" placeholder="Clave"  onkeyup="onkeyupInputEmtyy('clave')">
					<div class="valid-feedback">
							¡ Buen trabajo!
					</div>
					<div class="invalid-feedback">
						La clave del salón es requerida
					</div>
					<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
				</div>
				<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12"  style="padding-right: 0px;margin-top:15px;padding-left:10px;">
					<input  style="border-radius:6px" type="number" class="form-control has-feedback-left" required="required" name="cupo" id="cupo" placeholder="Cupo"  onkeyup="onkeyupInputEmtyy('cupo')">
					<div class="valid-feedback">
							¡ Buen trabajo!
					</div>
					<div class="invalid-feedback">
						Cupo es requerido
					</div>
					<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
				</div>
				<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12" style="padding-right: 0px;padding-left: 10px;margin-top:15px">
					<label class="control-label">Tipos de salones</label>
					<select  style="border-radius:6px" class="form-control" id="tipo" required="required" name="tipoSalones" onchange="onkeyupNoSelectInSlc('tipo')">
						 <option selected value="">Seleccione una opción</option> 
						<%if (getTypeClassrooms != null)
                            {
                                foreach (var item in getTypeClassrooms) {  %>
								<option value="<%=item.id%>"><%=item.nombre%></option>
							<%}
					}
					%>
					</select>
					<div class="valid-feedback">
						¡ Buen trabajo!
					</div>
					<div class="invalid-feedback">
						El tipo de salón es requerido
					</div>
				</div>
				<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12" style="padding-right: 0px; padding-left:10px;margin-top:15px">
					<label class="control-label">Edificios</label>
					<select  style="border-radius:6px" class="form-control" id="edificios" required="required" name="edificios" onchange="onkeyupNoSelectInSlc('edificios')">
						 <option selected value="">Seleccione una opción</option>                
					<%if (getBuildings != null)
                        {
                            foreach (var item in getBuildings) {  %>
								<option value="<%=item.idEdificio%>"><%=item.nombre%></option>
							<%}
					}
					%>
					</select>
					<div class="valid-feedback">
						¡ Buen trabajo!
					</div>
					<div class="invalid-feedback">
						Edificio requerido
					</div>
				</div>
				<div class="row" style="margin-top:30px" >
					<div class="col-md-6 col-sm-6">
						<div class="form-group row">
							<div class="col-md-6 col-sm-6" id="ctrl-principal">								
								<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deleteClassroom(event)">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
										<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
									</svg>
									Eliminar
								</button>
								<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addClassroom()">
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
					</div>
				</div>
				<input type="hidden" name="catalogo" value="salones" />
			</form>
			<div style="margin-top:30px;" class="x_title"></div>
			<h2>Salones<small></small></h2>
			<div class="row">
				<div class="col-lg-3 col-md-6 col-sm-6" style="margin-top:10px">
					<label class="control-label">
						<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-sort-down" viewBox="0 0 16 16">
							<path d="M3.5 2.5a.5.5 0 0 0-1 0v8.793l-1.146-1.147a.5.5 0 0 0-.708.708l2 1.999.007.007a.497.497 0 0 0 .7-.006l2-2a.5.5 0 0 0-.707-.708L3.5 11.293V2.5zm3.5 1a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zM7.5 6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5zm0 3a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1h-3zm0 3a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1h-1z"/>
						</svg>
						Filtrar por
					</label>
					<select class="form-control" id="filterBySlc" required="required" onchange="responseOptionTypeClassroom()">
						<option selected value="-1">Seleccione una opción</option>
						<option value="fkEdificio">Edificios</option>
						<option value="fkTipoSalon">Tipos de salones</option>
						<option value="fkCarreras">Carreras</option>
					</select>
				</div>
				<div class="col-lg-3 col-md-6 col-sm-6" style="margin-top:10px">
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-sort-down" viewBox="0 0 16 16">
						<path d="M3.5 2.5a.5.5 0 0 0-1 0v8.793l-1.146-1.147a.5.5 0 0 0-.708.708l2 1.999.007.007a.497.497 0 0 0 .7-.006l2-2a.5.5 0 0 0-.707-.708L3.5 11.293V2.5zm3.5 1a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zM7.5 6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5zm0 3a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1h-3zm0 3a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1h-1z"/>
					</svg>
					<label id="lblSlcTypeClassroomOptions" class="control-label">						
						Filtrar por
					</label>
					<select class="form-control" id="typeClassroomOptions" required="required" onchange="responseClassroomOptionType()">
						 <option selected value="-1">Seleccione una opción</option>
						<option value="-2">Todos los registros</option>
					</select>
				</div>
				<div class="col-lg-6 col-md-6 col-sm-6"  style="margin-top:30px;justify-content:right">
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
			<div id="containerTableClassrooms"></div>			
			<%-- Tabla Final--%>			
		</div>
	</div>
    <script src="js/personalizados/classrooms/add.js"></script>
    <script src="js/personalizados/classrooms/buildTable.js"></script>
    <script src="js/personalizados/classrooms/delete.js"></script>
    <script src="js/personalizados/classrooms/OnkeyupSearch.js"></script>
    <script src="js/personalizados/classrooms/recoverDatas.js"></script>
    <script src="js/personalizados/classrooms/update.js"></script>
    <script src="js/personalizados/classrooms/ajax/responseTypeClassroomOptions.js"></script>
    <script src="js/personalizados/classrooms/buildSelects/builSelectResponseTypeClassrooOption.js"></script>
    <script src="js/personalizados/classrooms/respTypeClassroomOpt.js"></script>	
    <script src="js/personalizados/classrooms/ajax/responseClassroomOptionsType.js"></script>
    <script src="js/personalizados/classrooms/responseClassroomsByOptions.js"></script>

	<script src="js/personalizados/Ajax/recoverData.js"></script>
    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>

    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
	<script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
    <script src="js/personalizados/utils/onkeyupNoSelectInSlc.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>
	<script type="text/javascript">
		window.onload = function () {
			const json = <%=getJsonClassrooms %>
                buildTableClassrooms(json);
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