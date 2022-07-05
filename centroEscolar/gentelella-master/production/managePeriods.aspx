<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="managePeriods.aspx.cs" Inherits="centroEscolar.gentelella_master.production.managePeriods" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	  <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
	
    
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<div class="container">        
		<div style="margin-left:230px">
			<div class="x_panel">					
				<div class="x_content">
					<form id="form1" data-parsley-validate="" class="form-horizontal form-label-left" novalidate="">
						<div class="row">
							<div class="col-6 field item form-group bad">
								<label class="col-form-label col-md-3 col-sm-3  label-align">Nombre del período<span class="required">*</span></label>
								<div class="col-8 field item form-group">
									<input type="text" class="form-control has-feedback-left" required="required" name="periodo" id="periodo" placeholder="Nombre del periodo">
									<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
								</div>
							</div>
						</div>						
						<div class="row">
							<div class="item col-lg-6 col-sm-12">
								<label class="col-form-label col-md-3 col-sm-3 label-align">Fecha de inicio
									<span class="required">*</span>
								</label>
								<input id="fechaInicio" name="fechaInicio" class="date-picker form-control parsley-error" placeholder="dd-mm-yyyy" type="date" required="required" onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'"  data-parsley-id="16">
							</div>
							<div class="item col-lg-6 col-sm-12">
								<label class="col-form-label col-md-3 col-sm-3 label-align">Fecha de término
									<span class="required">*</span>
								</label>
								<input id="fechaFinal" name="fechaFinal" class="date-picker form-control parsley-error" placeholder="dd-mm-yyyy" type="date" required="required" onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'"  data-parsley-id="16">
							</div>
						</div>		
						<br />
						<div class="form-group row">
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-principal">								
								<button class="btn btn-danger" id="delete" type="button" onclick="deletePeriods(event)">Eliminar</button>
								<button type="button" class="btn btn-success" id="add" onclick="addP()">Agregar</button>
							</div>
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-update" style="display: none">
								<button type="button" class="btn btn-success" id="save"  onclick="update()" >Guardar</button>
								<button type="button" class="btn btn-danger" id="cancel" onclick="cancelUpdate()">Cancelar</button>
							</div>
						</div>
						<input type="hidden" name="catalogo" value="periodos" />
					</form>
				</div>
			</div>		
		</div>        
       <%-- Tabla Inicio--%>

		<div class="clearfix"></div>		
			<div style="margin-left:230px">
                <div class="x_panel">
					<div id="containerTablePeriods"></div>
				</div>
			</div>		
        <%-- Tabla Final--%>
	</div>       
    <script src="js/personalizados/periods/add.js"></script>
    <script src="js/personalizados/periods/delete.js"></script>
    <script src="js/personalizados/periods/buildTablePeriods.js"></script>
    <script src="js/personalizados/periods/recoverData.js"></script>
    <script src="js/personalizados/periods/update.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>

    <script src="js/personalizados/Ajax/recoverData.js"></script>
    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>  
  
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>
    <script src="js/personalizados/utils/currentDate.js"></script>

	<script src="../vendors/validator/multifield.js"></script>	
	<script src="../vendors/validator/validator.js"></script>
	  
    <!-- Bootstrap -->
	<script type="text/javascript">
		window.onload = function () {
			const json = <%=getJsonPeriods%>;
            buildTablePeriods(json);
            $('#tbl-roles input[type=checkbox]').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                handle: 'checkbox'
            });
			var checkAll = document.getElementById('check-all');
			if (checkAll != undefined) {
                checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
			}         
            document.getElementById('fechaInicio').value = currentDate(document.getElementById("fechaInicio").value);
            document.getElementById('fechaFinal').value = currentDate(document.getElementById("fechaFinal").value)
            
		}       
    </script>
</asp:content> 