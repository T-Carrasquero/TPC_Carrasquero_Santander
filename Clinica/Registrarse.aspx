<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Clinica.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display:flex; flex-direction:column; align-items:center; justify-content:center;">
        <h1>TPC CLINICA</h1>
        <div class="form-floating-mb" style="display:flex; flex-direction:column; align-items:center; justify-content:center; width:50%; margin-top:2em; padding:2em; box-shadow : 0 0 10px black; "> 
            <div>
                <h2>Registrarse</h2>
            </div>

             <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="usuario">Nombre</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="nombre" placeholder="Nombre"/> 
            </div>

            <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="apellido">Apellido</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="apellido" placeholder="Apellido"/> 
            </div>

             <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                 <label for="dni">Dni</label>
                 <asp:TextBox type="text" class="form-control" id="dni" placeholder="Dni" required="true" runat="server" />
            </div> 

            <div id="sexo" class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
              
                       <asp:RadioButtonList ID="rblist" runat="server" >
                           <asp:ListItem Value="m" cssClass="w3-radio" id="rbtnM" >Masculino</asp:ListItem>
                           <asp:ListItem Value="f" cssClass="w3-radio" id="rbtnF">Femenino</asp:ListItem>
                           <asp:ListItem Value="x" cssClass="w3-radio" id="rbtnX">Otro</asp:ListItem>
                       </asp:RadioButtonList>
                           
            </div>

            <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="usuario">Usuario</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="usuario" placeholder="Nombre de usuario"/> 
            </div>

            <div class="form-group" style="width:70%; align-items:center; justify-content:center; padding:1em;">
                  <label for="Password">Contraseña</label>
                  <asp:TextBox runat="server" type="password" class="form-control" id="Password" placeholder="Contraseña" />  
            </div>

            <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="email">Email</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="email" placeholder="Email"/> 
            </div>
            
             <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="telefono">Telefono</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="telefono" placeholder="telefono"/> 
            </div>

             <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="codigoPostal">Codigo Postal</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="codigoPostal" placeholder="Codigo Postal"/> 
            </div>

            <div class="form-group" style="width:70%; align-items:center; justify-content:center;padding:1em;">
                <label for="direccion">Direccion</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="direccion" placeholder="Direccion"/> 
            </div>

            <div  style="width:70%; align-items:center; justify-content:center; padding:1em;">
                   <asp:Button Text="Guardar" id="guardar" cssClass="btn btn-primary" onClick="guardar_Click" runat="server" />
                   <hr/>
            </div>
        
            <div  style="width:70%; align-items:center; justify-content:center;">

                   <a class="dropdown-item" href="Login.aspx">Cancelar</a>
            </div>
        </div>
    </div>



</asp:Content>
