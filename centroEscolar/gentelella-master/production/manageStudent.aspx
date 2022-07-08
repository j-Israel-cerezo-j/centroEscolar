<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageStudent.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageStudent" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

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

    <script src="../vendors/jQuery-Smart-Wizard/js/jquery.smartWizard.js"></script>
	<script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
<div class="container">
	<form id="form1" class="form-label-left input_mask" novalidate>
		<div class="row" style="margin-left:220px">
          <div class="col-md-12 col-sm-12 ">
            <div class="x_panel">
              <div class="x_title">
                <h2>Datos del alumno</h2>
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
                    <div class="stepContainer" style="height: 250px;">
                        <div id="step-1" class="content" style="display: block;">
                            <div class="x_content">
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
					            	<input type="email" class="form-control has-feedback-left" data-validate-linked='email' required="required" name="email" id="email" placeholder="Correo personal">
					            	<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
					            </div>
					            <div class="col-md-6 col-sm-6 field item form-group">
					            	<input type="number" minlength="10" maxlength="10" required="required" class="form-control" id="tel" name="tel" placeholder="Teléfono">
					            	<span class="fa fa-phone form-control-feedback right" aria-hidden="true"></span>
					            </div>					            	
					            <input type="hidden" name="catalogo" value="alumnos" />					            
				            </div>
                        </div>
                        <div id="step-2" class="content" style="display: none;">					
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
							<input id="idDomicilie" name="idDomicilie" type="hidden" />
                        </div>                           
                    </div>
                    <div>
                        <a href="#" class="btn btn-round btn-primary" onclick="displaySmartWizarddstep1Block()">Generales</a>
                        <a href="#" class="btn btn-round btn btn-info" onclick="displaySmartWizarddstep2Block()">Domciliario</a>
                    </div>
                    <div class="ln_solid"></div>
					<div class="item form-group row">
						<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-principal">
							<button type="button" class="btn btn-success" id="save"  onclick="update()" >Guardar todo</button>	
							<button class="btn btn-danger" id="delete" type="button" onclick="deleteStudent(event)">Eliminar</button>
						</div>							
					</div>
                </div>
                <!-- End SmartWizard Content -->                    
              </div>
            </div>
          </div>
        </div>

	</form>
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
    <script src="js/personalizados/students/displaySmartWizard.js"></script>

	<script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>
	<script src="js/personalizados/Ajax/recoverData.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>


    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/hideshow.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>    
                   
    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestColoniasByCP.js"></script>
    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestCPByMunicipio.js"></script>
    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestMunicipiosByState.js"></script>
    <script src="js/personalizados/utils/XMLHttpRquest/XMLHttpRequestStatesMexico.js"></script>

    <script src="js/personalizados/utils/buildCPInSelect.js"></script>
    <script src="js/personalizados/utils/buildColoniasByCP.js"></script>
    <script src="js/personalizados/utils/buildMexicoStates.js"></script>
    <script src="js/personalizados/utils/builMunicipios.js"></script>


	<script type="text/javascript">
        window.onload = function () {
            const json =<%=getJsonStudents %>
                buildTableStudents(json);
            $('#tbl-roles input[type=checkbox]').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                handle: 'checkbox'
            });
            var checkAll = document.getElementById('check-all');
            if (checkAll != undefined) {
                checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
            }

            XMLHttpRequestStatesMexico();
		}       
    </script>
</asp:content> 