<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preRegisterStudent.aspx.cs" Inherits="centroEscolar.gentelella_master.production.preRegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	 <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
    
      <!-- jquery.inputmask -->
   <%-- <script src="../vendors/jquery.inputmask/dist/min/jquery.inputmask.bundle.min.js"></script>--%>
    <title></title>
</head>
<body>
	<div class="x_panel">
		<div class="x_title">
			<div class="title_left">
				<h3>Pre-registro<small>                alumnos</small></h3>
			</div>
		</div>
	</div>
	<form method="post" enctype="multipart/form-data" id="form1">	
		<div class="row">
            <div class="col-md-6 ">
				<div class="x_panel">
					<div class="x_title">
						<h2>Datos de ingreso</h2>
						<ul class="nav navbar-right panel_toolbox">
							<li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
							</li>						
							<li><a class="close-link"><i class="fa fa-close"></i></a>
							</li>
						</ul>
						<div class="clearfix"></div>
					</div>
					<div class="x_content">
					<br>					
						<div class="form-group row">
							<label class="control-label col-md-3 col-sm-3 ">Carrera</label>
							<div class="col-md-9 col-sm-9 ">
								<select class="form-control" id="carreras" required="required" name="carrera" onchange="divisionesXcarreraPre()">
									 <option selected="selected" value="-1">Seleccione una opción</option>
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
						<div class="form-group row">
							<label class="control-label col-md-3 col-sm-3 ">Divisiones</label>
							<div class="col-md-9 col-sm-9 ">
								<select class="form-control" id="divisiones" required="required" name="divisiones" onchange="">
									 <option selected value="-1">Seleccione una opción</option>
								</select>
							</div>
						</div>
					</div>
				</div>				
				<div class="x_panel">
					<div class="x_title">
						<h2>Datos de Domicilio</h2>
						<ul class="nav navbar-right panel_toolbox">
							<li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
							</li>						
							<li><a class="close-link"><i class="fa fa-close"></i></a>
							</li>
						</ul>
						<div class="clearfix"></div>
					</div>
					<div class="x_content">
					<br>					
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="nomcalle" id="nomCalle" placeholder="Nombre de la calle"/>
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>
						<br />
						<br />
						<br />
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="noInterior" id="noInterior" placeholder="Número interior"/>
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>
						<br />
						<br />
						<br />
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="noExterior" id="noExterior" placeholder="Número exterior"/>
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>
					</div>
				</div>
			</div>
			<div class="col-md-6 ">
				<div class="x_panel">
					<div class="x_title">
						<h2>Datos de personales</h2>
						<ul class="nav navbar-right panel_toolbox">
							<li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
							</li>						
							<li><a class="close-link"><i class="fa fa-close"></i></a>
							</li>
						</ul>
						<div class="clearfix"></div>
					</div>
					<div class="x_content">
					<br>											
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="nombres" id="nombres" placeholder="Nombre(s)"/>
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="apellidoP" id="apellidoP" placeholder="Apellido paterno"/>
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>												
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="apellidoM" id="apellidoM" placeholder="Apellido materno"/>
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="text" name="curp" class="form-control has-feedback-left" required="required" id="curp" placeholder="Curp"/>
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
							<a href="https://www.gob.mx/curp/"  target="_blank">Traminar curp</a>
						</div>												
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="email" class="form-control has-feedback-left" data-validate-linked='email' required="required" name="email" id="email" placeholder="Correo personal"/>
							<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
						</div>
						<div class="col-md-12 col-sm-12 field item form-group">
							<input type="number" minlength="10" maxlength="10" required="required" class="form-control" id="tel" name="tel" placeholder="Teléfono"/>
							<span class="fa fa-phone form-control-feedback right" aria-hidden="true"></span>
						</div>
						<div class="col-md-12 col-sm-12 field item form-group">
							<label class="col-form-label col-md-3 col-sm-3 label-align">Fecha de nacimiento
								<span class="required">*</span>
							</label>
							<input id="fechaNac" name="fechaNac" class="date-picker form-control parsley-error" placeholder="dd-mm-yyyy" type="date" required="required" onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'"  data-parsley-id="16"/>
						</div>
					</div>
				</div>
				<div class="x_panel">					
					<div class="x_content">
					<br>					
						<div class="form-group">
							<div class="col-md-6 offset-md-3">
								<button type="reset" class="btn btn-success">Limpiar</button>
							    <button type="submit" class="btn btn-primary" onclick="add()">Enviar registro</button>							    
							</div>
                        </div>
					</div>
				</div>
			</div>
		</div>		
	</form>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
	<script src="js/personalizados/utils/validatorForm.js"></script>
	    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- validator -->
    <!-- <script src="../vendors/validator/validator.js"></script> -->

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
	<script src="js/personalizados/utils/currentDate.js"></script>
    
    <script src="js/personalizados/preRegisterStudent/addStudent.js"></script>
    <script src="js/personalizados/preRegisterStudent/ajax/recoverDataDivisions.js"></script>
    <script src="js/personalizados/preRegisterStudent/divisionesXcarrera.js"></script>
    <script src="js/personalizados/preRegisterStudent/buildDivisionsInSelect.js"></script>
    <script src="js/personalizados/preRegisterStudent/ajax/addStudentCandidate.js"></script>
	<script src="js/personalizados/preRegisterStudent/alertWithDatas.js"></script>
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.15.5/dist/sweetalert2.all.min.js" integrity="sha256-92U7H+uBjYAJfmb+iNPi7DPoj795ZCTY4ZYmplsn/fQ=" crossorigin="anonymous"></script>
    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.css">

	<script type="text/javascript">
		window.onload = function () {
            document.getElementById('fechaNac').value = currentDate(document.getElementById("fechaNac").value);
        }
    </script>
</body>
</html>
