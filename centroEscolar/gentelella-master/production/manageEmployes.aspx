<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageEmployes.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageEmployes" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">

    <title>Gestionar empleados</title>
	<link href="../vendors/iCheck/skins/flat/green.css" rel="stylesheet">
	<!-- bootstrap-wysiwyg -->
	
	<!-- Select2 -->
	<link href="../vendors/select2/dist/css/select2.min.css" rel="stylesheet">
	<!-- Switchery -->
	<link href="../vendors/switchery/dist/switchery.min.css" rel="stylesheet">
	<!-- starrr -->
	<link href="../vendors/starrr/dist/starrr.css" rel="stylesheet">
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
	<!-- bootstrap-daterangepicker -->
	<link href="../vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">
    <link href="css/personalizados/containerBorder.css" rel="stylesheet" />
    
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<form id="form1" class="row g-3 needs-validation" novalidate enctype="multipart/form-data">
		<div class="row">
          <div class="col-md-12 col-sm-12 ">
            <div class="x_panel">
              <div class="x_title">
                <h2>Datos del trabajador</h2>
                <ul class="nav navbar-right panel_toolbox">
                  <li>
                      <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                  </li>                  
                  <li><a class="close-link"><i class="fa fa-close"></i></a>
                  </li>
                </ul>
                <div class="clearfix"></div>
              </div>
              <div class="x_content">
                <h3 style="text-align:center" id="labelMsjAction">Agregar a un trabajador</h3>			    
                <!-- Smart Wizard -->                
                <div id="wizard" class="form_wizard wizard_horizontal">
                    <div class="stepContainer">
                        <div id="step-1" class="content" style="display: block;">
                            <div class="x_content">
					            <div class="col-lg-6 col-md-6 col-sm-12 form-group">
					            	<input style="border-radius:6px"  type="text" class="form-control has-feedback-left " required="required" name="nombres" id="nombres" placeholder="Nombre(s)" onkeyup="onkeyupInputEmtyy('nombres')">
                                    <div class="valid-feedback">
					                	¡ Buen trabajo!
					                </div>
					                <div class="invalid-feedback">
					                	El nombre del empleado es requerido
					                </div>
					            	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
					            </div>						
					            <div class="col-lg-6 col-md-6 col-sm-12 form-group">
					            	<input style="border-radius:6px"  type="text" class="form-control has-feedback-left" name="apellidoP" required="required" id="apellidoP" placeholder="Apellido paterno" onkeyup="onkeyupInputEmtyy('apellidoP')">
                                    <div class="valid-feedback">
					                	¡ Buen trabajo!
					                </div>
					                <div class="invalid-feedback">
					                	Apellido paterno es requerido
					                </div>
					            	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
					            </div>
					            <div class="col-lg-6 col-md-6 col-sm-12 form-group">
					            	<input style="border-radius:6px" type="text" class="form-control has-feedback-left" name="apellidoM" required="required" id="apellidoM" placeholder="Apellido materno" onkeyup="onkeyupInputEmtyy('apellidoM')">
                                    <div class="valid-feedback">
					                	¡ Buen trabajo!
					                </div>
					                <div class="invalid-feedback">
					                	Apellido materno es requerido
					                </div>
					            	<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
					            </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 form-group">
							        <input style="border-radius:6px" type="text" name="curp" class="form-control has-feedback-left" required="required" id="curp" placeholder="Curp" onkeyup="onkeyupInputEmtyy('curp')">
                                    <div class="valid-feedback">
					                	¡ Buen trabajo!
					                </div>
					                <div class="invalid-feedback">
					                	Curp requerida
					                </div>
							        <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
							        <a href="https://www.gob.mx/curp/"  target="_blank">Traminar curp</a>
						        </div>
					            <div class="col-lg-6 col-md-6 col-sm-12 form-group">
					            	<input style="border-radius:6px" type="email" class="form-control has-feedback-left" data-validate-linked='email' required="required" name="email" id="email" placeholder="Correo personal" onkeyup="formantCorrectInput('email','inputEmpty','inputFormantIncorrect','@')">
                                    <div class="valid-feedback">
					                	¡ Buen trabajo!
					                </div>
					                <div class="invalid-feedback" id="inputEmpty">
					                	El correo personal del empelado es requerido
					                </div>
                                     <div class="invalid-feedback" id="inputFormantIncorrect" style="display:none">
					                	Formato incorrecto del correo @
					                </div>
					            	<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
					            </div>
					            <div class="col-lg-6 col-md-6 col-sm-12 form-group">
					            	<input style="border-radius:6px" type="number" minlength="10" maxlength="10" required="required" class="form-control has-feedback-left" id="tel" name="tel" placeholder="Teléfono" onkeyup="onkeyupInputEmtyy('tel')">
                                    <div class="valid-feedback">
					                	¡ Buen trabajo!
					                </div>
					                <div class="invalid-feedback">
					                	El nùmero telefònico del empelado es requerido
					                </div>
					            	<span class="fa fa-phone form-control-feedback left" aria-hidden="true"></span>
					            </div>
                            	<div class="col-lg-6 col-md-6 col-sm-12 form-group">
                            		<label style="margin-bottom:5px;">Fecha de nacimiento</label>
                            		<input style="border-radius:6px" id="fechaNac" name="fechaNac" class="date-picker form-control" placeholder="dd-mm-yyyy" type="date" required="required" onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'"  data-parsley-id="16"/>
                                    <div class="valid-feedback">
					            	    ¡ Buen trabajo!
					                </div>
					                <div class="invalid-feedback">
					                	La fecha de nacimiento es requerida
					                </div>
                            	</div>
					            <input type="hidden" name="catalogo" value="trabajadores" />					            
				            </div>
                        </div>
                        <div id="step-2" class="content" style="display: none;margin-top:10px;margin-right:10px;">
                            <div class="x_content">                             
							    <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="form-group">
							    	        <label class="col-form-label col-md-3 col-sm-3">Calle<span class="required">*</span></label>
							    	        <div class="col-lg-8 form-group">
							    	        	<input style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="nomcalle" id="nomCalle" placeholder="Nombre de la calle" onkeyup="onkeyupInputEmtyy('nomCalle')"/>
                                                <div class="valid-feedback">
					                            	¡ Buen trabajo!
					                            </div>
					                            <div class="invalid-feedback">
					                            	El nombre de la calle es requerida
					                            </div>
							    	        	<span class="fa fa-home form-control-feedback left" aria-hidden="true"></span>
							    	        </div>
							            </div>                                    
                                    </div>                               
                                </div>
                                <div class="row" style="margin-top:20px;">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
							    	        <label class="col-form-label col-md-3 col-sm-3">Nùmero interior<span class="required">*</span></label>
							    	        <div class="col-md-9 col-sm-9">
							    	        	<input style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="noInterior" id="noInterior" placeholder="Número interior" onkeyup="onkeyupInputEmtyy('noInterior')"/>
                                                <div class="valid-feedback">
					                            	¡ Buen trabajo!
					                            </div>
					                            <div class="invalid-feedback">
					                            	El nùmero interior es requerido
					                            </div>
							    	        	<span class="fa fa-home form-control-feedback left" aria-hidden="true"></span>
							    	        </div>
							            </div>                                    
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
							    	        <label class="col-form-label col-md-3 col-sm-3">Número exterior</label>
							    	        <div class="col-md-9 col-sm-9">
							    	        	<input style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="noExterior" id="noExterior" placeholder="Número exterior" onkeyup="onkeyupInputEmtyy('noExterior')"/>
                                                <div class="valid-feedback">
					                            	¡ Buen trabajo!
					                            </div>
					                            <div class="invalid-feedback">
					                            	El nùmero exterior es requerido
					                            </div>
							    	        	<span class="fa fa-home form-control-feedback left" aria-hidden="true"></span>
							    	        </div>
							            </div>
                                    </div>
                                </div>
                                <div class="row"  style="margin-top:20px;">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                  		    <label class="control-label col-md-3 col-sm-3 ">Estado</label>
                                  		    <div class="col-md-9 col-sm-9 ">
                                  		    	<select style="border-radius:6px" class="form-control" id="estadosMexico" required="required" name="state" onchange="recoverMunicipesEmploye()">
                                  		    		 <option selected value="">Seleccione una opción</option>
                                  		    	</select>
                                                <div class="valid-feedback">
					                            	¡ Buen trabajo!
					                            </div>
					                            <div class="invalid-feedback">
					                            	Estado requerido
					                            </div>
                                  		    </div>
                                  	    </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                  		    <label class="control-label col-md-3 col-sm-3 ">Municipio</label>
                                  		    <div class="col-md-9 col-sm-9 ">
                                  		    	<select style="border-radius:6px" class="form-control" id="municipios" required="required" name="municipio" onchange="onchangeSlcMuninicipes()">
                                  		    		 <option selected value="">Seleccione una opción</option>
                                  		    	</select>
                                                  <div class="valid-feedback">
					                            	¡ Buen trabajo!
					                            </div>
					                            <div class="invalid-feedback">
					                            	Municipio requerido
					                            </div>
                                  		    </div>
                                  	    </div>
                                    </div>
                                </div>                                                                                            
                                <div class="row" style="margin-top:20px;">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                  		    <label class="control-label col-md-3 col-sm-3 ">CP</label>
                                  		    <div class="col-md-9 col-sm-9 ">
                                  		    	<input style="border-radius:6px" type="text" class="form-control has-feedback-left" minlength="5" maxlength="5" required="required" name="cp" id="cp" placeholder="CP" onkeyup="lengthCorrectInput('cp','inputEmptyCP','inputFormantIncorrectCP','5','5')"/>
                                                  <div class="valid-feedback">
					                            	¡ Buen trabajo!
					                            </div>
					                            <div class="invalid-feedback" id="inputEmptyCP">
					                            	CP requerido
					                            </div>
                                                  <div class="invalid-feedback" id="inputFormantIncorrectCP" style="display:none">
					                            	La longitud del CP tiene que ser igual a 5 caracteres
					                            </div>
							    	        	<span class="fa fa-home form-control-feedback left" aria-hidden="true"></span>
                                  		    </div>
                                  	    </div>
                                    </div>
                                    <%--<div class="col-lg-6 col-md-12 col-sm-12" style="margin-top:30px">
                                        <div class="form-group">
                                  		    <label class="control-label col-md-3 col-sm-3 ">CP</label>
                                  		    <div class="col-md-9 col-sm-9 ">
                                  		    	<select class="form-control" id="cp" required="required" name="cp"  onchange="XMLHttpRequestColoniassByCP()">
                                  		    		 <option selected value="-1">Seleccione una opción</option>
                                  		    	</select>
                                  		    </div>
                                  	    </div>
                                    </div>--%>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                  		    <label class="control-label col-md-3 col-sm-3 ">Colonia</label>
                                  		    <div class="col-md-9 col-sm-9 ">
                                  		    	<input style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="colonia" id="colonia" placeholder="Colonia" onkeyup="onkeyupInputEmtyy('colonia')"/>
                                                  <div class="valid-feedback">
					                            	¡ Buen trabajo!
					                            </div>
					                            <div class="invalid-feedback">
					                            	Colonia requerida
					                            </div>
							    	        	<span class="fa fa-home form-control-feedback left" aria-hidden="true"></span>
                                  		    </div>
                                  	    </div>
                                    </div>
                                    <%--<div class="col-lg-6 col-md-12 col-sm-12"  style="margin-top:30px">
                                        <div class="form-group">
                                  		    <label class="control-label col-md-3 col-sm-3 ">Colonia</label>
                                  		    <div class="col-md-9 col-sm-9 ">
                                  		    	<select class="form-control" id="colonia" required="required" name="colonia" >
                                  		    		 <option selected value="-1">Seleccione una opción</option>
                                  		    	</select>
                                  		    </div>
                                  	    </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div id="step-3" class="content" style="display: none;">
                            <h4 style="margin-bottom:15px;">Seleccione un tipo trabajador</h4>
                            <div class="row" style="justify-content:center" id="containerTypeWorker">                                
                                <%foreach (var item in getTypesWorkers)
						    	{%>	                                    
						    		<div class="col-lg-4 col-md-12 col-sm-12">
                                       <div class="form-check">
                                           <input style="padding:9px" class="form-check-input" type="radio" value="<%=item.typeWorker%>" id="radio<%=item.typeWorker %>" name="typeWorker" onclick="recoverRolesByTypeWorkerr(event)">
                                           <label style="margin-left:8px" class="form-check-label" for="flexRadioDefault1">
                                               <%=item.descripcion %>
                                           </label>
                                       </div>
						    		</div>									
						
						    	<%} %>
                            </div>
                            <div class="valid-feedback">
					        	¡ Buen trabajo!
					        </div>
					        <div class="invalid-feedback">
					        	Tipo de trabajador requerido requerido
					        </div>
                            <div class="row" style="margin-top:25px">                                
                                <div id="divRowContainerRolesTypeWorker">
                                    <h5 id="h6Roles" style="margin-left: 15px; display: none;">Seleccione uno o mas roles para el trabajador</h5>
                                    <div id="containerRolesTypeWorker" style="margin-left: 15px;" >
                                    </div>
                                </div> 
                            </div>  
                            <div class="row" style="justify-content:center; margin-top:30px;">
                                <div id="containerCarreras" class="form-group" style="display:none">
                                    <h5 style="margin-left:15px;">Seleccione las divisiones a las cuales pertenecera</h5>
						    		<%--<label class="control-label">Divisiones</label>--%>
                                     <%if (getDivisions != null)
                                         {
                                             foreach (var item in getDivisions) {  %> 
                                                <div class="checkbox col-lg-1 col-md-3 col-sm-3 col-xs-12" style="margin:10px 30px 100px 30px">					    
					                                <div class="icheckbox_flat-green hover">
                                                        <input value="<%=item.idDivision%>" id="checkDivision<%=item.idDivision%>" type="checkbox" name="cheksDivisionsSelec" class="flat" style="opacity: 0;"><%=item.nombre%>
                                                    </div> 
					                            </div>	
                                            <%}
						    			}
						    			%>
						    	</div>
                            </div>
                        </div>                        
                        <div id="step-4" class="content" style="display: none;">
                            <div class="row">
                                <div class="col-8">
                                    <div class="mb-3" id="containerFilePhotograph">
                                        <input style="border-radius:6px" accept="image/jpeg,image/png"  class="form-control" required="required" type="file" id="formFile" onchange="MostraIma(this)" name="fotografia">
                                         <div class="valid-feedback">
					                    	¡ Buen trabajo!
					                    </div>
					                    <div class="invalid-feedback">
					                    	La fotografia del trabajador es requerida
					                    </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom:15px;">
                                <div style="text-align:center;">
                                    <div class="card reflejo" style="width: 13.9rem;">
                                        <img id="image" alt="Cargar fotografía por favor." src="" height="200" width="220"/>
                                        <div class="card-body">
                                          <div id="msjImagenCargadaAutomatica"></div>
                                        </div>
                                    </div>
                                </div>                                
                            </div>
                        </div>
                    </div>
                    <div style="float:right">
                        <a href="#" class="btn btn-round btn-primary" onclick="displaySmartWizarddstep1Block('#step-1','#step-2','#step-3','#step-4')">Generales</a>
                        <a href="#" class="btn btn-round btn-primary" onclick="displaySmartWizarddstep2Block('#step-1','#step-2','#step-3','#step-4')">Domciliario</a>
                        <a href="#" class="btn btn-round btn-primary" onclick="displaySmartWizarddstep3Block('#step-1','#step-2','#step-3','#step-4')">Roles</a>
                        <a href="#" class="btn btn-round btn-primary" onclick="displaySmartWizarddstep4Block('#step-1','#step-2','#step-3','#step-4')">Fotografía</a>
                    </div>
                    <div class="ln_solid"></div>
                    <br />
                    <br />
                    <br />
					<div class="item form-group row">
					    <div class="col-md-7 col-sm-7" id="ctrl-principal">
					    	<button class="btn btnDeletes reflejo" id="delete " type="button" onclick="deleteEmploys(event)">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                    <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
                                </svg>
                                Eliminar
                            </button>
					    	<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addE()">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-plus-fill" viewBox="0 0 16 16">
                                  <path d="M1 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H1zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z"/>
                                  <path fill-rule="evenodd" d="M13.5 5a.5.5 0 0 1 .5.5V7h1.5a.5.5 0 0 1 0 1H14v1.5a.5.5 0 0 1-1 0V8h-1.5a.5.5 0 0 1 0-1H13V5.5a.5.5 0 0 1 .5-.5z"/>
                                </svg>
                                Agregar
					    	</button>
					    </div>
					    <div class="col-md-7 col-sm-7" id="ctrl-update" style="display: none">
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
						    <button style="padding:10px" class="btn btn-secondary reflejo"type="button" onclick="buttonReset()">
						    	<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
						    	  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2v1z"/>
						    	  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466z"/>
						    	</svg>
						    	Limpiar
						    </button>
					    </div>                        
					</div>
                </div>
                <!-- End SmartWizard Content -->                    
              </div>
            </div>
          </div>
        </div>
	</form>
    <div class="row">
        <div class="col-lg-4 col-md-6 col-sm-6" style="margin-top:10px">
            <label  class="control-label">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-sort-down" viewBox="0 0 16 16">
					<path d="M3.5 2.5a.5.5 0 0 0-1 0v8.793l-1.146-1.147a.5.5 0 0 0-.708.708l2 1.999.007.007a.497.497 0 0 0 .7-.006l2-2a.5.5 0 0 0-.707-.708L3.5 11.293V2.5zm3.5 1a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zM7.5 6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5zm0 3a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1h-3zm0 3a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1h-1z"/>
				</svg>
                Tipo de trabajador
            </label>
            <select class="form-control" id="typeWorkerSlc" required="required" onchange="recoverTablesByTyperWorker()">
                <option selected="selected" value="-1">Mostrar tabla de...</option>
                <%if (getTypesWorkers != null)
                {                              
                	foreach (var item in getTypesWorkers) {  %>
                		<option value="<%=item.typeWorker%>"><%=item.descripcion%></option>
                	<%}
                }
                %>
            </select>
        </div>
        <div class="col-lg-3"></div>
		<div class="col-lg-5 col-md-6 col-sm-6" style="margin-top:30px;text-align: right">
            <form id="formOnkeyup">
	            <div class="input-group" > 
	                <div class="form-outline" style="width: 100%;">
                        <svg style=" position: absolute;width: 20px; height: 20px; left: 12px; top: 50%; transform: translateY(-50%);" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
	                        <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
	                    </svg>
	                    <input class="form-control" list="datalistOptionsSerch" id="seekerEmployes" placeholder="Buscar..." style="border-radius:10px;width: 100%;padding-left: 40px;padding-right: 15px;" onkeyup="onkeyupSearchh()" name="onkeyupCoincidencias">                         
	                    <datalist id="datalistOptionsSerch"></datalist>
	                </div>
	            </div>
	        </form>
        </div>
    </div>    
	<%-- Tabla Inicio--%>

	<div class="clearfix"></div>
    <div class="x_panel">
		<div id="containerTableEmploysFull"></div>
	</div>			
    <%-- Tabla Final--%>	

    <script src="js/personalizados/employes/buildRolesByTypeWorker.js"></script>
    <script src="js/personalizados/employes/recoverRolesByTypeWorker.js"></script>
    <script src="js/personalizados/employes/add.js"></script>
    <script src="js/personalizados/employes/builTables/buildTableEmploysGenerales.js"></script>
    <script src="js/personalizados/employes/builTables/buildTableEmploysDivisioanles.js"></script>
    <script src="js/personalizados/employes/delete.js"></script>
    <script src="js/personalizados/employes/onkeyupSearchh.js"></script>
    <script src="js/personalizados/employes/recoverDataa.js"></script>
    <script src="js/personalizados/employes/update.js"></script>    
    <script src="js/personalizados/employes/buildRolesSelected.js"></script>    
    <script src="js/personalizados/employes/buildDivisionsSelected.js"></script>
    <script src="js/personalizados/employes/recoverTablesEmployesByTypeWorker.js"></script>

    <script src="js/personalizados/employes/ajax/deleteEmployesAjax.js"></script>
    <script src="js/personalizados/employes/ajax/divisionsEmployeLocal/divisionsEmployeLocalAjax.js"></script>
    <script src="js/personalizados/employes/ajax/recoverTableByTypeWorkerAjax.js"></script>
    <script src="js/personalizados/employes/ajax/recoverDataEmployeAjax.js"></script>
    <script src="js/personalizados/employes/ajax/recoverRolesSelectedByEmploye.js"></script>
    <script src="js/personalizados/employes/ajax/updateStatusAjax.js"></script>
    <script src="js/personalizados/employes/changueStatus.js"></script>
    <script src="js/personalizados/employes/btnReset.js"></script>

	<script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>
	<script src="js/personalizados/Ajax/recoverData.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>

    <script src="js/personalizados/utils/apisPersonalizadas/funtionsByCatalogo/recoverMunicipes.js"></script>
    <script src="js/personalizados/utils/apisPersonalizadas/switcByCatalogo/switchByCatalogoo.js"></script>
    <script src="js/personalizados/utils/apisPersonalizadas/apiMexico.js"></script>
    <script src="js/personalizados/utils/buildMexicoStates.js"></script>
    <script src="js/personalizados/utils/builMunicipios.js"></script>

    <script src="js/personalizados/utils/currentDate.js"></script>
    <script src="js/personalizados/utils/Ajax/rolesByTypeWorker.js"></script>
    <script src="js/personalizados/utils/displaySmartWizard.js"></script>
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/hideshow.js"></script>
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>

    <script src="js/personalizados/employes/onchangeSlcMuninicipess.js"></script>
    <script src="js/personalizados/employes/recoverMunicipesEmpl.js"></script>

    <script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
    <script src="js/personalizados/utils/onkeyupNoSelectInSlc.js"></script>          
    <script src="js/personalizados/utils/styleBoxShadow.js"></script>
	<script type="text/javascript">
        window.onload = function () {

            const statesMexico =<%=getJsonStates%>;
            document.getElementById('fechaNac').value = currentDate(document.getElementById("fechaNac").value);

            $('#tbl-roles input[type=checkbox]').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                handle: 'checkbox'
            });                       
            var checkAll = document.getElementById('check-all');
            if (checkAll != undefined) {
                checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
            }              
            $('#containerCarreras input[type=checkbox]').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                handle: 'checkbox'
            }); 

            buildMexicoStatesInSelect(statesMexico);
        } 
        function MostraIma(input) {
            console.log(input);
            console.log(input.files);
            if (input.files && input.files[0]) {
                var image = new FileReader();
                console.log(image);
                image.onload = function (e) {
                    console.log(e)
                    document.getElementById("image").setAttribute("src", e.target.result);
                    console.log(e.target.result)
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
                }
                image.readAsDataURL(input.files[0]);
                
            }
            onkeyupInputEmtyy('formFile')
        }  
    </script>
</asp:content> 