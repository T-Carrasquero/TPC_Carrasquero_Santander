<%@ Page Title="Cartilla" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="Clinica.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            $('#example').DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                }
            });
        });
    </script>

    <table id="example" class="w3-table w3-bordered w3-hoverable" style="width:100%; margin-top:5em;">
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
                      <td><%:item.Especialidad %></td>
                      <td><%:item.Matricula %></td>
                      <td><a class="btn btn-danger" href="path/to/settings" aria-label="Delete"> <i class="fas fa-trash" aria-hidden="true"></i></a></td>
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
    


</asp:Content>
