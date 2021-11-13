﻿<%@ Page Title="Cartilla" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="Clinica.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            $('#example').DataTable({
                columnDefs: [
                    { orderable: false, targets: 4 }
                ],
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                }
            });
        });
    </script>

    <div style="display:flex; justify-content:space-between; align-items:center; margin-top: 2em;" title="Nuevo Registro" >
           <h3>Cartilla de Profesionales</h3>
            <button class="w3-button w3-green" style="display:flex; height:40%;"><a href="/Cartilla_Crear.aspx" style="text-decoration:none;">+</a></button>
       
    </div>
    <div id="tableContenedor" style="margin-top:2em;">
         <table id="example" class="w3-table w3-bordered w3-hoverable" style="width:100%; padding-top:1em;  padding-bottom:1em;">
        <thead>
            <tr>
                <th>Nombre</th>            
                <th>Apellido</th>
                <th>Especialidad</th>
                <th>Matricula</th>
                <th>Accion</th>
            </tr>
        </thead>    
        <tbody>
            
             <% foreach (var item in medico)
                {  %>
                    <tr>
                      <td><%:item.Nombre %></td>
                      <td><%:item.Apellido %></td>
                      <td><%:item.Especialidad%></td>
                      <td><%:item.Matricula %></td>
                      <td>
                          <a class="btn" href="path/to/settings" aria-label="Delete"> <i class="material-icons" aria-hidden="true">edit</i></a>
                          <a class="btn" href="path/to/settings" aria-label="Delete"> <i class="material-icons" aria-hidden="true">delete</i></a>
                      </td>
                    </tr>
             
             <% }  %>
           
        </tbody>
        <tfoot>
            <tr>
                <th>Nombre</th>
                <th>Apellido</th>
                <th>Especialidad</th>
                <th>Matricula</th>
                <th>Accion</th>
            </tr>
        </tfoot>
    </table>
    </div>
   
    


</asp:Content>
