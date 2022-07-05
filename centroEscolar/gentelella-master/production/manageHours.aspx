<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageHours.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageHours" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

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
							<div class="item col-lg-6 col-sm-12">
								<label class="col-form-label col-md-3 col-sm-3 label-align">Hora inicio
									<span class="required">*</span>
								</label>
								<input id="horaInicio" type="time" class="form-control" name="horaInicio" value="07:00" required>
							</div>
							<div class="item col-lg-6 col-sm-12">
								<label class="col-form-label col-md-3 col-sm-3 label-align">Hora término
									<span class="required">*</span>
								</label>
								<input id="horaTermino" type="time" class="form-control" name="horaTermino" value="07:50" required>
							</div>
						</div>	
						<br />
						<div class="form-group row">
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-principal">								
								<button class="btn btn-danger" id="delete" type="button" onclick="deleteHours(event)">Eliminar</button>
								<button type="button" class="btn btn-success" id="add" onclick="addHour()">Agregar</button>
							</div>
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-update" style="display: none">
								<button type="button" class="btn btn-success" id="save"  onclick="update()" >Guardar</button>
								<button type="button" class="btn btn-danger" id="cancel" onclick="cancelUpdate()">Cancelar</button>
							</div>
						</div>
						<input type="hidden" name="catalogo" value="horas" />
					</form>
				</div>
			</div>		
		</div>        
       <%-- Tabla Inicio--%>

		<div class="clearfix"></div>		
			<div style="margin-left:230px">
                <div class="x_panel">
					<div id="containerTableHours"></div>
				</div>
			</div>		
        <%-- Tabla Final--%>
	</div>       
    <script src="js/personalizados/hours/add.js"></script>
    <script src="js/personalizados/hours/buildTableHours.js"></script>
    <script src="js/personalizados/hours/delete.js"></script>
    <script src="js/personalizados/hours/recoverData.js"></script>
    <script src="js/personalizados/hours/update.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>

    <script src="js/personalizados/Ajax/recoverData.js"></script>
    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>  
  
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>
    <script src="js/personalizados/utils/currentDate.js"></script>

	<script src="../vendors/validator/multifield.js"></script>
	  
    <!-- Bootstrap -->
	<script type="text/javascript">
		window.onload = function () {
			const json = <%=getJsonHours%>;
            buildTableHours(json);
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