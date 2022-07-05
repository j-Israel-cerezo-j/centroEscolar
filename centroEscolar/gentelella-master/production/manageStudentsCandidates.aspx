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

	<script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<div class="container">
		<div>
			<div class="x_panel">					
				<div class="x_content">					
					<form id="form1" class="form-label-left input_mask" novalidate>
						<div class="row" style="margin-left:230px">
							<div class="form-group col-lg-6 col-md-12 col-sm-12">
								<label class="control-label col-md-3 col-sm-3 ">Carrera</label>
								<div class="col-md-9 col-sm-9 ">
									<select class="form-control" id="carreras" required="required" name="carrera" onchange="divisionesXcarreraPre()">
										 <option selected value="-1">Seleccione una</option>
										<%if (getCarrers != null)
										{                              
											foreach (var item in getCarrers) {  %>
												<option value="<%=item.idCarrera%>"><%=item.nombre%></option>
											<%}
										}
										%>
									</select>
								</div>
							</div>
							<div class="form-group col-lg-6 col-md-12 col-sm-12">
								<label class="control-label col-md-3 col-sm-3 ">Divisiones</label>
								<div class="col-md-9 col-sm-9 ">
									<select class="form-control" id="divisiones" required="required" name="carrera" onchange="tableXdiviones()">
										 <option selected value="-1">Seleccione una</option>
									</select>
								</div>
							</div>
						</div>						
						 <%-- Tabla Inicio--%>
							<div class="clearfix"></div>		
							<div style="margin-left:230px">
							    <div class="x_panel">
									<div id="containerTableCandidates"></div>
								</div>
							</div>		
						<%-- Tabla Final--%>
						<input type="hidden" name="catalogo" value="alumnos" />
					</form>
				</div>
			</div>		
		</div>		 
	</div>
	 <script src="js/personalizados/candidates/ajax/recoverDataTableCandidatesXdivis.js"></script>
    <script src="js/personalizados/candidates/tableXdivsion.js"></script>
    <script src="js/personalizados/candidates/buildTableCandidates.js"></script>

    <script src="js/personalizados/preRegisterStudent/buildDivisionsInSelect.js"></script>
    <script src="js/personalizados/preRegisterStudent/divisionesXcarrera.js"></script>
    <script src="js/personalizados/preRegisterStudent/ajax/recoverDataDivisions.js"></script>
   	

    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/hideshow.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>    
               
	<script type="text/javascript">
        window.onload = function () {
            const json =<%=getJsonStudents%>
            buildTableCandidates(json);
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