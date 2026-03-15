<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="actas_numero.aspx.cs" Inherits="ProyectoONPE.actas_numero" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<html>
<head>
    <title>ONPE - Oficina Nacional de Procesos Electorales</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="screen" />
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
            <img src="images/f-actas.jpg" width="1170" height="248" class="img-responsive mg30top">

            <section class="menu navbar-default menu05">
                <nav class="navbar-collapse bs-navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="bt-azul"><a href="presidencial.aspx">PRESIDENCIAL</a></li>
                        <li class="bt-amarillo act-amarillo"><a href="actas_ubigeo.aspx">ACTAS</a></li>
                        <li class="bt-rojo"><a href="participacion.aspx">PARTICIPACIÓN CIUDADANA</a></li>
                    </ul>
                </nav>
            </section>
            
            <br /><br /><br /><br />

            <section class="contenedor">
                <div class="row">
                    <div class="col-xs-12 col-md-3">
                        <div class="menu-interna">
                            <ul>
                                <li><a href="actas_ubigeo.aspx">Actas por ubigeo</a></li>
                                <li><a href="actas_numero.aspx" class="act-izq">Actas por número</a></li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-xs-12 col-md-9" id="impreso">
                        <div class="contenido-interna">
                            <div class="titulos col-xs-12">
                                <div class="col-xs-11">
                                    <h3><span class="glyphicon glyphicon-circle-arrow-right"></span> SEGUNDA ELECCIÓN PRESIDENCIAL 2016: ACTAS POR NÚMERO</h3>
                                </div>
                            </div>

                            <div class="col-xs-12">
                                <div class="row ptop20 pbot20" style="text-align: center; border-bottom: 1px solid #eee; margin-bottom: 20px;">
                                    <div class="col-md-12 form-inline">
                                        <label style="margin-right: 10px;">INGRESE EL NÚMERO DE ACTA:</label>
                                        <asp:TextBox ID="txtNroMesa" runat="server" MaxLength="6" CssClass="form-control" style="width: 150px; display: inline-block;"></asp:TextBox>
                                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary" OnClick="btnBuscar_Click" style="margin-left: 10px;">
                                            <span class="glyphicon glyphicon-search"></span> BUSCAR
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <div id="divDetalle" class="ptop20">
                                    <asp:Panel ID="pnlError" runat="server" Visible="false">
                                        <div class="alert alert-danger text-center">EL NÚMERO DE MESA NO EXISTE</div>
                                    </asp:Panel>

                                    <div id="divDetalleMesa" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-md-12 text-center">
                                                <div class="mesap01" style="display: inline-block; float: none; width: 350px;">
                                                    <img src="images/mp-sin.jpg" class="img-responsive centered">
                                                    <p class="mg10top" style="font-size: 11px;">Si requiere la imagen del acta, solicítela...</p>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row ptop20">
                                            <div class="col-md-12">
                                                <p class="subtitle1">ACTA ELECTORAL</p>
                                                <table class="table13" width="100%">
                                                    <thead><tr><th width="50%">Mesa N°</th><th width="50%">N° Copia</th></tr></thead>
                                                    <tbody><tr>
                                                        <td><asp:Label ID="lblMesaNumero" runat="server"></asp:Label></td>
                                                        <td><asp:Label ID="lblCopia" runat="server"></asp:Label></td>
                                                    </tr></tbody>
                                                </table>

                                                <p class="subtitle1">INFORMACIÓN UBIGEO</p>
                                                <table class="table14" width="100%">
                                                    <tr class="titulo_tabla"><td>DEPARTAMENTO</td><td>PROVINCIA</td><td>DISTRITO</td></tr>
                                                    <tr>
                                                        <td><asp:Label ID="lblDepInfo" runat="server"></asp:Label></td>
                                                        <td><asp:Label ID="lblProvInfo" runat="server"></asp:Label></td>
                                                        <td><asp:Label ID="lblDistInfo" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="titulo_tabla"><td colspan="2">LOCAL</td><td>DIRECCIÓN</td></tr>
                                                    <tr>
                                                        <td colspan="2"><asp:Label ID="lblLocalInfo" runat="server"></asp:Label></td>
                                                        <td><asp:Label ID="lblDireccionInfo" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>

                                                <p class="subtitle1">INFORMACIÓN MESA</p>
                                                <table class="table15" width="100%">
                                                    <tr class="titulo_tabla"><td>HÁBILES</td><td>VOTANTES</td><td>ESTADO</td></tr>
                                                    <tr>
                                                        <td><asp:Label ID="lblElectoresHabiles" runat="server"></asp:Label></td>
                                                        <td><asp:Label ID="lblTotalVotantes" runat="server"></asp:Label></td>
                                                        <td><asp:Label ID="lblEstadoActa" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>

                                                <p class="subtitle1">INFORMACIÓN DEL ACTA ELECTORAL</p>
                                                <table class="table06" width="100%">
                                                    <tr class="titulo_tabla"><td colspan="2">Organización política</td><td>Total de Votos</td></tr>
                                                    <tr>
                                                        <td>PERUANOS POR EL KAMBIO</td>
                                                        <td class="text-center"><img width="40px" src="images/simbolo_pkk.jpg"></td>
                                                        <td><asp:Label ID="lblVotosPPK" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>FUERZA POPULAR</td>
                                                        <td class="text-center"><img width="40px" src="images/simbolo_keyko.jpg"></td>
                                                        <td><asp:Label ID="lblVotosKeiko" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr><td colspan="2">VOTOS EN BLANCO</td><td><asp:Label ID="lblVotosBlanco" runat="server"></asp:Label></td></tr>
                                                    <tr><td colspan="2">VOTOS NULOS</td><td><asp:Label ID="lblVotosNulos" runat="server"></asp:Label></td></tr>
                                                    <tr><td colspan="2">VOTOS IMPUGNADOS</td><td><asp:Label ID="lblVotosImpugnados" runat="server"></asp:Label></td></tr>
                                                    <tr style="font-weight:bold; background:#eee">
                                                        <td colspan="2">TOTAL DE VOTOS EMITIDOS</td>
                                                        <td><asp:Label ID="lblTotalEmitidos" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
</body>
</html>