<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preRegisterStudent.aspx.cs" Inherits="centroEscolar.gentelella_master.production.preRegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Gentelella Alela! | </title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet"/>

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet"/>
    
</head>
<body class="nav-md">
    <form id="form1" method="post">
	    <div class="">
          <div class="main_container">        
            <!-- page content -->
            <div class="right_col" role="main">
              <div class="">            
                <div class="clearfix"></div>
                <div class="row">
                  <div class="col-md-12 col-sm-12 ">
                    <div class="x_panel">
                      <div class="x_title">
                        <h2>Pre-registro <small>    Datos del alumno</small></h2>
                        <ul class="nav navbar-right panel_toolbox">
                          <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                          </li>                     
                          <li><a class="close-link"><i class="fa fa-close"></i></a>
                          </li>
                        </ul>
                        <div class="clearfix"></div>
                      </div>
                      <div class="x_content">
                        <!-- Smart Wizard -->                    
                        <div id="wizard" class="form_wizard wizard_horizontal">
                          <ul class="wizard_steps">
                            <li>
                              <a href="#step-1">
                                <span class="step_no">1</span>
                                <span class="step_descr">
                                    Paso 1<br />
                                    <small>Ingreso</small>
                                </span>
                              </a>
                            </li>
                            <li>
                              <a href="#step-2">
                                <span class="step_no">2</span>
                                <span class="step_descr">
                                    Paso 2<br />
                                    <small>Domicilio</small>
                                </span>
                              </a>
                            </li>
                            <li>
                              <a href="#step-3">
                                <span class="step_no">3</span>
                                <span class="step_descr">
                                    Paso 3<br />
                                    <small>Personales</small>
                                </span>
                              </a>
                            </li>
                        </ul>
                        <div id="step-1">
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <div class="form-group">
                              		    <label  class="control-label col-md-3 col-sm-3 ">Carrera</label>
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
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <div class="form-group">
                              		    <label class="control-label col-md-3 col-sm-3 ">Divisiones</label>
                              		    <div class="col-md-9 col-sm-9 ">
                              		    	<select class="form-control" id="divisiones" required="required" name="divisiones" onchange="">
                              		    		 <option selected value="-1">Seleccione una opción</option>
                              		    	</select>
                              		    </div>
                              	    </div>
                                </div>
                            </div>
                        </div>
                        <div id="step-2" style="justify-content:center">
                            <br>                            
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="field item form-group bad">
								        <label class="col-form-label col-md-3 col-sm-3 label-align">Calle<span class="required">*</span></label>
								        <div class="col-8 field item form-group">
								        	<input type="text" class="form-control has-feedback-left" required="required" name="nomcalle" id="nomCalle" placeholder="Nombre de la calle"/>
								        	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
								        </div>
							        </div>                                    
                                </div>                               
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <div class="field item form-group bad">
								        <label class="col-form-label col-md-3 col-sm-3">Nùmero interior<span class="required">*</span></label>
								        <div class="col-8 field item form-group">
								        	<input type="text" class="form-control has-feedback-left" required="required" name="noInterior" id="noInterior" placeholder="Número interior"/>
								        	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
								        </div>
							        </div>                                    
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <div class="field item form-group bad">
								        <label class="col-form-label col-md-3 col-sm-3">Número exterior<span class="required">*</span></label>
								        <div class="col-8 field item form-group">
								        	<input type="text" class="form-control has-feedback-left" required="required" name="noExterior" id="noExterior" placeholder="Número exterior"/>
								        	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
								        </div>
							        </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <div class="form-group">
                              		    <label class="control-label col-md-3 col-sm-3 ">Estado</label>
                              		    <div class="col-md-9 col-sm-9 ">
                              		    	<select class="form-control" id="estadosMexico" required="required" name="state" onchange="XMLHttpRequestMunicipiossByState()">
                              		    		 <option selected value="-1">Seleccione una opción</option>
                              		    	</select>
                              		    </div>
                              	    </div>
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <div class="form-group">
                              		    <label class="control-label col-md-3 col-sm-3 ">Municipio</label>
                              		    <div class="col-md-9 col-sm-9 ">
                              		    	<select class="form-control" id="municipios" required="required" name="municipio"  onchange="XMLHttpRequestCPByMunicipe()">
                              		    		 <option selected value="-1">Seleccione una opción</option>
                              		    	</select>
                              		    </div>
                              	    </div>
                                </div>
                            </div>                                                                                            
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12" style="margin-top:30px">
                                    <div class="form-group">
                              		    <label class="control-label col-md-3 col-sm-3 ">CP</label>
                              		    <div class="col-md-9 col-sm-9 ">
                              		    	<select class="form-control" id="cp" required="required" name="cp"  onchange="XMLHttpRequestColoniassByCP()">
                              		    		 <option selected value="-1">Seleccione una opción</option>
                              		    	</select>
                              		    </div>
                              	    </div>
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12"  style="margin-top:30px">
                                    <div class="form-group">
                              		    <label class="control-label col-md-3 col-sm-3 ">Colonia</label>
                              		    <div class="col-md-9 col-sm-9 ">
                              		    	<select class="form-control" id="colonia" required="required" name="colonia" >
                              		    		 <option selected value="-1">Seleccione una opción</option>
                              		    	</select>
                              		    </div>
                              	    </div>
                                </div>
                            </div>                                                       
                        </div>
                        <div id="step-3">                            
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <label class="control-label col-md-3 col-sm-3 ">Nombre(s)</label>
                            	    <div class="col-md-12 col-sm-12 field item form-group">                                        
                            	    	<input type="text" class="form-control has-feedback-left" required="required" name="nombres" id="nombres" placeholder="Nombre(s)"/>
                            	    	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                            	    </div>
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <label class="control-label col-md-3 col-sm-3 ">Apellido paterno</label>
                            	    <div class="col-md-12 col-sm-12 field item form-group">
                            	    	<input type="text" class="form-control has-feedback-left" required="required" name="apellidoP" id="apellidoP" placeholder="Apellido paterno"/>
                            	    	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                            	    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <label class="control-label col-md-3 col-sm-3 ">Apellido materno</label>
                            	    <div class="col-md-12 col-sm-12 field item form-group">
                            	    	<input type="text" class="form-control has-feedback-left" required="required" name="apellidoM" id="apellidoM" placeholder="Apellido materno"/>
                            	    	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                            	    </div>
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <label class="control-label col-md-3 col-sm-3 ">Curp</label>
                            	    <div class="col-md-12 col-sm-12 field item form-group">
                            	    	<input type="text" name="curp" class="form-control has-feedback-left" required="required" id="curp" placeholder="Curp"/>
                            	    	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                            	    	<a href="https://www.gob.mx/curp/"  target="_blank">Traminar curp</a>
                            	    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <label class="control-label col-md-3 col-sm-3 ">Correo electronico</label>
                            	    <div class="col-md-12 col-sm-12 field item form-group">
                            	    	<input type="email" class="form-control has-feedback-left" data-validate-linked='email' required="required" name="email" id="email" placeholder="Correo personal"/>
                            	    	<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
                            	    </div>
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <label class="control-label col-md-3 col-sm-3 ">Teléfono</label>
                            	    <div class="col-md-12 col-sm-12 field item form-group">
                            	    	<input type="number" minlength="10" maxlength="10" required="required" class="form-control" id="tel" name="tel" placeholder="Teléfono"/>
                            	    	<span class="fa fa-phone form-control-feedback right" aria-hidden="true"></span>
                            	    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <label class="control-label col-md-3 col-sm-3 ">Fecha de nacímiento</label>
                            	    <div class="col-md-12 col-sm-12 field item form-group">
                            	    	<label class="col-form-label col-md-3 col-sm-3 label-align">Fecha de nacimiento
                            	    		<span class="required">*</span>
                            	    	</label>
                            	    	<input id="fechaNac" name="fechaNac" class="date-picker form-control parsley-error" placeholder="dd-mm-yyyy" type="date" required="required" onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'"  data-parsley-id="16"/>
                            	    </div>
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12" style="margin-top:30px">
                                    <div class="form-group">
	    					            <div class="col-md-6 offset-md-3">							    	
	    					                <button type="button" class="btn btn-primary" onclick="addStudentCandidate(event)">Enviar registro</button>							    
	    					            </div>
                                    </div>
                                </div>
                            </div>                                                   
                        </div>                        
                    </div>
                        <!-- End SmartWizard Content -->                    
                </div>
            </div>
        </div>
    </div>
</div>
            </div>
            <!-- /page content -->        
          </div>
        </div>
    </form>
   <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
   <script src="../vendors/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- jQuery Smart Wizard -->
    <script src="../vendors/jQuery-Smart-Wizard/js/jquery.smartWizard.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>	
    <script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
	
    <script src="js/personalizados/preRegisterStudent/ajax/recoverDataDivisions.js"></script>    
    <script src="js/personalizados/preRegisterStudent/buildDivisionsInSelect.js"></script>
    <script src="js/personalizados/preRegisterStudent/divisionesXcarrera.js"></script>

    <script src="js/personalizados/preRegisterStudent/ajax/addStudentCandidates.js"></script>
    <script src="js/personalizados/preRegisterStudent/alertWithDataas.js"></script>
    <script src="js/personalizados/utils/currentDate.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>

    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestColoniasByCP.js"></script>
    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestCPByMunicipio.js"></script>
    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestMunicipiosByState.js"></script>
    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestStatesMexico.js"></script>

    <script src="js/personalizados/utils/buildColoniasByCP.js"></script>
    <script src="js/personalizados/utils/buildCPInSelect.js"></script>
    <script src="js/personalizados/utils/builMunicipios.js"></script>
    <script src="js/personalizados/utils/buildMexicoStates.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.15.5/dist/sweetalert2.all.min.js" integrity="sha256-92U7H+uBjYAJfmb+iNPi7DPoj795ZCTY4ZYmplsn/fQ=" crossorigin="anonymous"></script>
        

	<script type="text/javascript">
		window.onload = function () {
            document.getElementById('fechaNac').value = currentDate(document.getElementById("fechaNac").value);
            XMLHttpRequestStatesMexico();
        }
    </script>
</body>
</html>