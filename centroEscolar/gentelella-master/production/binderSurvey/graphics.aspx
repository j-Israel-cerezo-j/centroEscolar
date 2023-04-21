<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graphics.aspx.cs" Inherits="centroEscolar.gentelella_master.production.binderSurvey.graphics" MasterPageFile="~/gentelella-master/production/binderSurvey/masterCentroEscolar.Master" %>


<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">	
	<title>Informes</title>
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="row"  style="justify-content:center">
        <div  class="col-lg-9 col-md-6 col-sm-12 col-xsm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Deserción academica de alumnos <small>por categoria</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>                        
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                  <canvas id="grapicCategorys"></canvas>
                </div>
            </div>
        </div>

        <div class="col-lg-9 col-md-6 col-sm-12 col-xsm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Universidades con mayor deserción de alumnos</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>                        
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                  <canvas width="10" height="10" id="grapicUniversitys"></canvas>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.0.1/chart.min.js" integrity="sha512-tQYZBKe34uzoeOjY9jr3MX7R/mo7n25vnqbnrkskGr4D6YOoPYSpyafUAzQVjV6xAozAqUFIEFsCO4z8mnVBXA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.0.1/chart.js" integrity="sha512-zulXrCFpnkALZBNUHe4E6rTUt7IhNLDUuLTLqTyKb93z7CrEVzFdL8KfPV6VPplL8+b4MZGOdh00+d2nzGiveg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.0.1/chart.umd.js" integrity="sha512-gQhCDsnnnUfaRzD8k1L5llCCV6O9HN09zClIzzeJ8OJ9MpGmIlCxm+pdCkqTwqJ4JcjbojFr79rl2F1mzcoLMQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.0.1/chart.umd.min.js" integrity="sha512-HyprZz2W40JOnIBIXDYHCFlkSscDdYaNe2FYl34g1DOmE9J+zEPoT4HHHZ2b3+milFBtiKVWb4sorDVVp+iuqA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.0.1/helpers.js" integrity="sha512-wGzztNvoC00n0GzfyGz17CaVJ8rihq5cFnoJDJvF2Ul3wy1K2UsnXHutmZcjIHQOTGjeZTuAL3PH9GwjwZ7aHA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.0.1/helpers.min.js" integrity="sha512-c0j5ITIxnG5CknVw3Tl4LrXCBV6Vevg3OFbTFWnuItsDokxEix501UjCggJC2McxWe2Arq4XYJdHd0VLKUc9aQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script type="text/javascript">
        var grapicCategorys = document.getElementById("grapicCategorys").getContext("2d");

        var grapicUniversitys = document.getElementById("grapicUniversitys").getContext("2d");

        var chartCategorys = new Chart(grapicCategorys, {
            <%=getStrFormantGraphycChartByCategorys%>
        }) 

        var chartUniversitys = new Chart(grapicUniversitys, {
           <%=getStrFormantGraphycChartByUniversitys%>
         }) 

    </script>
</asp:content>

