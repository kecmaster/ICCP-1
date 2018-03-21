﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ICCPReclamos.Presentacion.index" %>

<!DOCTYPE html>
<html lang ="es-cl">
<head runat="server">
    <title>Reclamos</title>
    <meta charset="utf-8"> 
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://afeld.github.io/emoji-css/emoji.css" rel="stylesheet">
    <link href="custom.css" rel="stylesheet">
</head>
<body>


<div class="container">


    <nav class="navbar navbar-inverse navbar-fixed-top">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">Robotech ICCP.Net</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="index.aspx">Inicio</a></li>
      <li><a href="Listado.cshtml">Listado Reclamos</a></li>
      <li><a href="#">NOTENABLED</a></li>
    </ul>
    <ul class="nav navbar-nav navbar-right">
      <li><a href="#"><span class="glyphicon glyphicon-user"></span> Registro</a></li>
      <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
    </ul>
  </div>
</nav>
      <form class="form-horizontal" runat="server">
          <h2 class="form-heading">Ingreso de Reclamos</h2>

   <div class="form-group">
    <label class="control-label col-sm-2" for="firstname">Nombre:</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="firstname" class="form-control" id="firstname" placeholder="Nombre" required autofocus></asp:TextBox>
    </div>
  </div>

             <div class="form-group">
          <label class="control-label col-sm-2" for="lastname">Apellido:</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="lastname" class="form-control" id="lastname" placeholder="Apellido" required></asp:TextBox>
    </div>
  </div>
             <div class="form-group">
              <label class="control-label col-sm-2" for="rut">RUT:</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="text" class="form-control" id="rut" placeholder="11.111.111-1" required></asp:TextBox>
    </div>
  </div>

  <div class="form-group">
    <label class="control-label col-sm-2" for="email">Email:</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="email" class="form-control" id="email" placeholder="usuario@dominio.com" required></asp:TextBox>
    </div>
  </div>

          <div class="form-group">
              <label class="control-label col-sm-2" for="tel">Telefono:</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="tel" class="form-control" id="tel" placeholder="9xxxxxxxx" maxlength="9"></asp:TextBox>
    </div>
  </div>
          <div class="form-group">
              <label class="control-label col-sm-2" for="type">Área:</label>
    <div class="col-sm-4">
      <asp:DropDownList runat="server" class="form-control" id="type">
      </asp:DropDownList>
    </div>
  </div>

          <div class="form-group">
              <label class="control-label col-sm-2" for="comment">Detalles:</label>
    <div class="col-sm-4">
<asp:textbox TextMode="MultiLine" runat="server" class="form-control" rows="5" id="comment" placeholder="Cuéntanos en breve los detalles de tu incidencia" required></asp:textbox>
    </div>
  </div>

                    <div class="form-group">
              <label class="control-label col-sm-2" for="tel">SLA en Horas</label>
    <div class="col-sm-4">
      <asp:TextBox runat="server" type="number" class="form-control" id="slaHoras" placeholder="0"></asp:TextBox>
    </div>
  </div>

  <div class="form-group"> 
    <div class="col-sm-offset-2 col-sm-10">
      <asp:button type="submit" class="btn btn-default" id="btnEnviar" runat="server" Text="Enviar" onclick="btnEnviar_Click"></asp:button>
        <asp:button type="reset" class="btn btn-default" runat="server" Text="Reestablecer"></asp:button></div>
    </div>
  </div>
    </form>

    <footer class="blog-footer">
      <p>ICCP.Net Platform made with ♥ by <a href="index.aspx">Robotech INC</a></p>
      <p>
        <a href="#">Hacia arriba !</a>
      </p>
        </footer>
</body>

<!-- bootstrap 3 minimizado -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

<!-- jQuery -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<!-- último js de bs 3 -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</html>