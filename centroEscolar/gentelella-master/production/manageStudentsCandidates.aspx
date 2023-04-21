<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageStudentsCandidates.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageStudentsCandidates" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">  	
	  <link href="../vendors/iCheck/skins/flat/green.css" rel="stylesheet">
	<!-- bootstrap-wysiwyg -->
	<link href="../vendors/google-code-prettify/bin/prettify.min.css" rel="stylesheet">
	<!-- Select2 -->
	<link href="../vendors/select2/dist/css/select2.min.css" rel="stylesheet">
	<!-- Switchery -->
	<link href="../vendors/switchery/dist/switchery.min.css" rel="stylesheet">
	<!-- starrr -->
	<link href="../vendors/starrr/dist/starrr.css" rel="stylesheet">
	<!-- bootstrap-daterangepicker -->
	<link href="../vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">
	
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
	<script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
	<title>Gestionar estudiantes candidatos</title>
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<div class="x_panel">	
		<div class="x_content" style="margin-top:40px">	
			<%if (!getExistingRecords)
            {%>
               <div style="margin-top:20px" class="x_content">
					<div class="stepContainer">
					    <div class="alert alert-info alert-dismissible" id="success-alert">
					        <strong>Sin registros por el momentos.</strong>
					    </div>
					    <div align="center">
					        <img src="images/perzonalizadas/vacio/fotoefectos.com_.jpg"  width="300" height="300"/>
					    </div>
					</div>
               </div>
            <%}
            else
            {%>								
				<form id="form1" class="form-label-left input_mask" novalidate>
					<div class="row">
						<div class="form-group col-lg-6 col-md-12 col-sm-12 col-xsm-12">							
							<div class="col-md-9 col-sm-9 ">
								<label class="control-label">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-sort-down" viewBox="0 0 16 16">
										<path d="M3.5 2.5a.5.5 0 0 0-1 0v8.793l-1.146-1.147a.5.5 0 0 0-.708.708l2 1.999.007.007a.497.497 0 0 0 .7-.006l2-2a.5.5 0 0 0-.707-.708L3.5 11.293V2.5zm3.5 1a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zM7.5 6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5zm0 3a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1h-3zm0 3a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1h-1z"/>
									</svg>
									Filtrar por Carreras
								</label>
								<select class="form-control" id="carreras" required="required" name="carrera" onchange="divisionXcarreraMangeCan()">
									<option selected value="-1">Seleccione una opción</option>
									<option value="-2">Todos los candidatos</option>
									<%if (getCarrers != null)
				                        {
				                            foreach (var item in getCarrers)
				                            {  %>
											<option value="<%=item.idCarrera%>"><%=item.nombre%></option>
										<%}
				                            }
									%>
								</select>
							</div>
						</div>
						<div class="form-group col-lg-6 col-md-12 col-sm-12 col-xsm-12">
							<div class="col-md-9 col-sm-9 ">
								<label class="control-label">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-sort-down" viewBox="0 0 16 16">
										<path d="M3.5 2.5a.5.5 0 0 0-1 0v8.793l-1.146-1.147a.5.5 0 0 0-.708.708l2 1.999.007.007a.497.497 0 0 0 .7-.006l2-2a.5.5 0 0 0-.707-.708L3.5 11.293V2.5zm3.5 1a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zM7.5 6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5zm0 3a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1h-3zm0 3a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1h-1z"/>
									</svg>
									Filtrar por Divisiones
								</label>
								<select class="form-control" id="divisiones" required="required" name="divisiones" onchange="tableXdiviones()">
									 <option selected value="-1">Seleccione una carrera</option>
								</select>
							</div>
						</div>
					</div>
				</form>
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
						<div id="containerTableCandidates"></div>
					<%-- Tabla Final--%>				
			<%} %>
			</div>
		</div>
	<script src="js/personalizados/candidates/ajax/recoverDataTableCandidatesXdivis.js"></script>
    <script src="js/personalizados/candidates/ajax/manageStatusCandidate.js"></script>
    <script src="js/personalizados/candidates/tableXdivsion.js"></script>    
    <script src="js/personalizados/candidates/changeStatus.js"></script>    
	<script src="js/personalizados/candidates/buildTableCandidates.js"></script>
    <script src="js/personalizados/candidates/divsionsXcarreraManageCandidate.js"></script>
    <script src="js/personalizados/candidates/onkeyupSearch.js"></script>
    <script src="js/personalizados/candidates/ajax/requestStatusCandidate.js"></script>

    <script src="js/personalizados/preRegisterStudent/buildDivisionsInSelect.js"></script>
    <script src="js/personalizados/preRegisterStudent/divisionesXcarrera.js"></script>
    <script src="js/personalizados/preRegisterStudent/ajax/recoverDataDivisions.js"></script>

    <script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/hideshow.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>    
               
	<script type="text/javascript">
		window.onload = function () {
			const json =<%=getJsonStudents%>
			const listStatusCandidates=<%=getStatusCandidates%>
                buildTableCandidates(json, listStatusCandidates);
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