<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageAcademicLevel.aspx.cs" Inherits="centroEscolar.gentelella_master.production.manageAcademicLevel" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<div class="container">        
		<div style="margin-left:230px">
			<div class="x_panel">					
				<div class="x_content">
					<br>
					<form id="form1" class="form-label-left input_mask" novalidate>
						<div class="col-md-6 col-sm-6 field item form-group">
							<input type="text" class="form-control has-feedback-left" required="required" name="cuatrimestre" id="cuatrimestre" placeholder="Agregar cuatrimestre">
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>																			
						<div class="form-group row">
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-principal">								
								<button class="btn btn-danger" id="delete" type="button" onclick="deleteAceLev(event)">Eliminar</button>
								<button type="button" class="btn btn-success" id="add" onclick="addAcL()">Agregar</button>
							</div>
							<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-update" style="display: none">
								<button type="button" class="btn btn-success" id="save"  onclick="update()" >Guardar</button>
								<button type="button" class="btn btn-danger" id="cancel" onclick="cancelUpdate()">Cancelar</button>
							</div>
						</div>
						<input type="hidden" name="catalogo" value="cuatrimestres" />
					</form>
				</div>
			</div>		
		</div>        
       <%-- Tabla Inicio--%>

		<div class="clearfix"></div>		
			<div style="margin-left:230px">
                <div class="x_panel">
					<div id="containerTableAcademicLev"></div>
				</div>
			</div>		
        <%-- Tabla Final--%>
	</div>       
    <script src="js/personalizados/academicLevel/add.js"></script>
    <script src="js/personalizados/academicLevel/buildTableAcademicLev.js"></script>
    <script src="js/personalizados/academicLevel/delete.js"></script>
    <script src="js/personalizados/academicLevel/recoverDatas.js"></script>
    <script src="js/personalizados/academicLevel/update.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>

	<script src="js/personalizados/Ajax/recoverData.js"></script>
    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>

    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>

	<script type="text/javascript">
		window.onload = function () {
			const json = <%=getJsonLevels%>;
            buildTableAcademicLev(json);
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