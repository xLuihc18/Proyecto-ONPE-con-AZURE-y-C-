<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="participacion_total.aspx.cs" Inherits="ProyectoONPE.participacion_total" MaintainScrollPositionOnPostback="true"%>
<!DOCTYPE html> 
<html>
<head>
    <title>ONPE - Resultados de Participación</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <div class="container">
            <div class="pull-left logo-onpe">
                <div class="pull-left"><a href="index.aspx"><img src="images/onpe-trans.png"></a></div>
                <div class="pull-left"><h1>PRESENTACIÓN DE RESULTADOS</h1></div>
            </div>
            <div class="pull-right logo"><img src="images/eegg2016-trans.png" width="218" height="35"></div>
        </div>
    </header>

    <div class="container">
        <img src="images/f-participacion.jpg" class="img-responsive mg30top">
        <section class="menu navbar-default menu05">
            <nav class="navbar-collapse bs-navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li class="bt-azul"><a href="presidencial.aspx">PRESIDENCIAL</a></li>
                    <li class="bt-amarillo"><a href="actas_ubigeo.aspx">ACTAS</a></li>
                    <li class="bt-rojo act-rojo"><a href="participacion.aspx">PARTICIPACIÓN CIUDADANA</a></li>
                </ul>
            </nav>
        </section>
        <br/><br/><br/><br/>

        <section class="contenedor">
            <div class="row">
                <div class="col-xs-12 col-md-3">
                    <div class="menu-interna">
                        <ul><li><a href="participacion_total.aspx" class="act-izq">TOTAL</a></li></ul>
                    </div>
                </div>
                <div class="col-xs-12 col-md-9" id="impreso">
                    <div class="contenido-interna">
                        <div class="titulos col-xs-12">
                            <div class="col-xs-11">
                                <h3><span class="glyphicon glyphicon-circle-arrow-right"></span> SEGUNDA ELECCIÓN PRESIDENCIAL 2016: PARTICIPACIÓN CIUDADANA</h3>
                            </div>
                        </div>
                        
                        <div class="row ptop20">
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrito_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-xs-12 line pbot30 ptop20">
                            <div class="col-xs-12 col-md-6">
                                <div id="grafico_dinamico" style="width: 100%; height: 280px;"></div>
                            </div>
                            <div class="col-xs-12 col-md-6">
                                <div class="cont-recto" style="margin-bottom:10px">
                                    Ámbito: <asp:Label ID="lblAmbito" runat="server" Text="Nacional"></asp:Label>
                                </div>
                                <p class="subtitle">ELECTORES HÁBILES: <asp:Label ID="lblHabilesTotal" runat="server"></asp:Label></p>
                                <table class="table09_2">
                                    <thead>
                                        <tr><th>PARTICIPACIÓN</th><th>AUSENTISMO</th></tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>TOTAL: <asp:Label ID="lblParticipacionTotal" runat="server"></asp:Label></td>
                                            <td>TOTAL: <asp:Label ID="lblAusentismoTotal" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>% TOTAL: <asp:Label ID="lblParticipacionPorc" runat="server"></asp:Label>%</td>
                                            <td>% TOTAL: <asp:Label ID="lblAusentismoPorc" runat="server"></asp:Label>%</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <div class="col-xs-12">
                            <p class="subtitle">Consulta de participación DETALLADO </p>
                            <table class="table21">
                                <thead>
                                    <tr class="titulo_tabla">
                                        <td>UBIGEO</td>
                                        <td>ASISTENTES</td>
                                        <td>% ASISTENTES</td>
                                        <td>AUSENTES</td>
                                        <td>% AUSENTES</td>
                                        <td>HÁBILES</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpParticipacion" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("DPD") %></td>
                                                <td><%# Eval("TV", "{0:N0}") %></td>
                                                <td><%# Eval("PTV") %></td>
                                                <td><%# Eval("TA", "{0:N0}") %></td>
                                                <td><%# Eval("PTA") %></td>
                                                <td><%# Eval("EH", "{0:N0}") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div style="clear: both; height: 100px;"></div>
    <footer class="footer-inside">
      <div class="container">
        <div class="row">
          <div class="col-md-12 direc01">
            <span>CONTÁCTENOS</span>
            <p>Jr. Washington 1894, Cercado de Lima </p>
            <p>Correo electrónico: <a href="#">informes@onpe.gob.pe</a></p>
            <p>Central Telefónica: 417 - 0630 / Lunes a Viernes 08:30 - 16:30 hrs</p>
          </div>
        </div>
      </div>
    </footer>
    </form>

    <script src="https://www.gstatic.com/charts/loader.js"></script>
        <script type="text/javascript">
            google.charts.load('current', { 'packages': ['corechart'] });
            google.charts.setOnLoadCallback(drawChart);

            function drawChart() {
                var participacion = parseFloat('<%= lblParticipacionPorc.Text %>');
                var ausentismo = parseFloat('<%= lblAusentismoPorc.Text %>');

                if (isNaN(participacion) || participacion === 0) participacion = 0;
                if (isNaN(ausentismo) || ausentismo === 0) ausentismo = 0;

                var data = google.visualization.arrayToDataTable([
                    ['Estado', 'Porcentaje'],
                    ['Participación', participacion],
                    ['Ausentismo', ausentismo]
                ]);

                var options = {
                    title: '',
                    pieHole: 0, 
                    colors: ['#334d7d', '#999999'], 
                    chartArea: { width: '90%', height: '80%' },
                    legend: { position: 'bottom' },
                    animation: { startup: true, duration: 1000, easing: 'out' }
                };

                var chart = new google.visualization.PieChart(document.getElementById('grafico_dinamico'));
                chart.draw(data, options);
            }
        </script>
</body>
</html>