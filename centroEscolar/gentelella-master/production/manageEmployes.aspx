<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageEmployes.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageEmployes" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

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
		<div style="margin-left:230px">
			<div class="x_panel">					
				<div class="x_content">					
					<form id="form1" class="form-label-left input_mask" novalidate>
						<div class="col-md-6 col-sm-6 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="nombres" id="nombres" placeholder="Nombre(s)">
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>						
						<div class="col-md-6 col-sm-6 field item form-group">
							<input type="text" class="form-control" name="apellidoP" required="required" id="apellidoP" placeholder="Apellido paterno">
							<span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6 field item form-group">
							<input type="text" class="form-control" name="apellidoM" required="required" id="apellidoM" placeholder="Apellido materno">
							<span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6 field item form-group">
							<input type="text" name="curp" class="form-control has-feedback-left" required="required" id="curp" placeholder="Curp">
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
							<a href="https://www.gob.mx/curp/"  target="_blank">Traminar curp</a>
						</div>												
						<div class="col-md-6 col-sm-6 field item form-group">
							<input type="email" class="form-control has-feedback-left" data-validate-linked='email' required="required" name="email" id="email" placeholder="Email">
							<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6 field item form-group">
							<input type="number" minlength="10" maxlength="10" required="required" class="form-control" id="tel" name="tel" placeholder="Teléfono">
							<span class="fa fa-phone form-control-feedback right" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6 field item form-group">
							<label class="col-form-label col-md-3 col-sm-3  label-align">Contraseña<span class="required">*</span></label>
							<div class="col-md-6 col-sm-6">
								<input class="form-control" type="password" id="password" name="password" title="Mínimo 8 caracteres, incluidas letras mayúsculas y minúsculas, un número y un carácter único" required />
								<span style="position: absolute;right:15px;top:7px;" onclick="hideshow()" >
									<i id="slash" class="fa fa-eye-slash"></i>
									<i id="eye" class="fa fa-eye"></i>
								</span>
							</div>
						</div>
						<div class="col-md-6 col-sm-6 field item form-group">
							<label class="col-form-label col-md-3 col-sm-3  label-align">Confirmar contraseña<span class="required">*</span></label>
							<div class="col-md-6 col-sm-6">
								<input class="form-control" type="password" id="confirmPassword" data-validate-linked='password' name="confirmPassword" title="Mínimo 8 caracteres, incluidas letras mayúsculas y minúsculas, un número y un carácter único" required />
								<span style="position: absolute;right:15px;top:7px;" onclick="hideshowConfirm()" >
									<i style="display:none" id="slashConfirm" class="fa fa-eye-slash"></i>
									<i id="eyeConfirm" class="fa fa-eye"></i>
								</span>
							</div>
						</div>																							
						<div class="ln_solid"></div>
						<div class="item form-group row">
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-principal">								
								<button class="btn btn-danger" id="delete" type="button" onclick="deleteStudent(event)">Eliminar</button>
								<button type="button" class="btn btn-success" id="add" onclick="addS()">Agregar</button>
								<button class="btn btn-primary" type="reset">Reset</button>
							</div>
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-update" style="display: none">
								<button type="button" class="btn btn-success" id="save"  onclick="update()" >Guardar</button>
								<button type="button" class="btn btn-danger" id="cancel" onclick="cancelUpdate()">Cancelar</button>
							</div>
						</div>
						<input type="hidden" name="catalogo" value="alumnos" />
					</form>
				</div>
			</div>		
		</div>
		  <%-- Tabla Inicio--%>

		<div class="clearfix"></div>		
			<div style="margin-left:230px">
                <div class="x_panel">
					<div id="containerTableStudents"></div>
				</div>
			</div>		
        <%-- Tabla Final--%>
	</div>

	<script src="js/personalizados/students/recoverData.js"></script>
    <script src="js/personalizados/students/deleteStudent.js"></script>
	<script src="js/personalizados/students/buildTableStudents.js"></script>
	<script src="js/personalizados/students/addStudent.js"></script>
	<script src="js/personalizados/students/update.js"></script>

	<script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>
	<script src="js/personalizados/Ajax/recoverData.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>


    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/hideshow.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>    
               
	<script type="text/javascript">
        window.onload = function () {
            const json =""
                buildTableStudents(json);
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