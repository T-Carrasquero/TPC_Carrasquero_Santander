﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Clinica.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display:flex; flex-direction:column; align-items:center; justify-content:center;">
        <h1>TPC CLINICA</h1>
        <div class="form-floating-mb" style="display:flex; flex-direction:column; align-items:center; justify-content:center; width:50%; margin-top:2em; padding:2em; box-shadow : 0 0 10px black; "> 
            <div>
                <h2>Registrarse</h2>
            </div>
            <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="usuario">Usuario</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="usuario" placeholder="Nombre de usuario"/> 
            </div>

            <div class="form-group" style="width:70%; align-items:center; justify-content:center; padding:1em;">
                  <label for="Password">Contraseña</label>
                  <asp:TextBox runat="server" type="password" class="form-control" id="Password" placeholder="Contraseña" />  
            </div>
            <div  style="width:70%; align-items:center; justify-content:center; padding:1em;">
                   <asp:Button Text="Ingresar" id="Ingresar" cssClass="btn btn-primary" OnClick="Ingresar_Click" runat="server" />
                   <hr/>
            </div>  
        
            <div  style="width:70%; align-items:center; justify-content:center; padding:1em;">
                   <a class="dropdown-item" href="#">¿Eres nuevo? Resgistrate!</a>
                   <a class="dropdown-item" href="#">Haz olvidado tu contraseña?</a>
            </div>
        </div>
    </div>



</asp:Content>
