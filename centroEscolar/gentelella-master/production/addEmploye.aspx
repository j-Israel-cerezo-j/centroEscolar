<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addEmploye.aspx.cs" Inherits="centroEscolar.gentelella_master.production.addEmploye" MasterPageFile="~/gentelella-master/production/Site1.Master" %>

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
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
	<div class="container">
		<div style="margin-left:230px">
			<div class="x_panel">					
				<div class="x_content">
					<br>
					<form class="form-label-left input_mask">
						<div class="col-md-6 col-sm-6  form-group has-feedback">
							<input type="text" class="form-control has-feedback-left" id="nombres" placeholder="Nombre(s)">
							<span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6  form-group has-feedback">
							<input type="text" class="form-control" name="apellidoP" id="apellidoP" placeholder="Apellido paterno">
							<span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6  form-group has-feedback">
							<input type="text" class="form-control" name="apellidoM" id="apellidoM" placeholder="Apellido materno">
							<span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6  form-group has-feedback">
							<input type="email" class="form-control has-feedback-left" id="email" placeholder="Email">
							<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
						</div>
						<div class="col-md-6 col-sm-6  form-group has-feedback">
							<input type="tel" class="form-control" id="tel" placeholder="Teeléfono">
							<span class="fa fa-phone form-control-feedback right" aria-hidden="true"></span>
						</div>						
						<div class="form-group row">
							<label class="col-form-label col-md-3 col-sm-3 ">Matrícula</label>
							<div class="col-md-9 col-sm-9 ">
								<input type="text" class="form-control" disabled="disabled" name="matricula" placeholder="Matrícula">
							</div>
						</div>													
						<div class="ln_solid"></div>
						<div class="form-group row">
							<div class="col-md-9 col-sm-9  offset-md-3">
								<button type="button" class="btn btn-primary">Cancel</button>
								<button class="btn btn-primary" type="reset">Reset</button>
								<button type="submit" class="btn btn-success">Submit</button>
							</div>
						</div>
					</form>
				</div>
			</div>		
		</div>
	</div>  	
</asp:content> 