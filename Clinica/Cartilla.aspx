<%@ Page Title="Cartilla" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="Clinica.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <script>
        $(document).ready(function () {
            $('#example').DataTable({
                columnDefs: [
                    { orderable: false, targets: 3 }
                ],
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                }
            });
        });
    </script>
    
    <div id="tableContenedor" style="margin-top:1em; box-shadow : 0 0 10px black; padding:2em;" >

        <div style="display:flex; justify-content:space-between; align-items:center; margin-bottom:1em;" title="Nuevo Registro" >
           <h3>Cartilla de Profesionales</h3>
        <%if (Session["tipoUsuario"].ToString() == "Administrador")
            { %>
            <a class="w3-button w3-green" href="/Cartilla_Crear.aspx">+</a>
            <% } %>
         </div>

         <table id="example" class="w3-table w3-bordered w3-hoverable" style="width:100%; padding-top:1em;  padding-bottom:1em; margin-top:2em; ">
        <thead>
            <tr>
                <th>Apellido y Nombre</th>            
                <th>Especialidad</th>
                <th>Matricula</th>  
                <th>Contacto</th>
                   <%if (Session["tipoUsuario"].ToString() == "Administrador")
                     { %>
                        <th>Acciones</th>
                  <% } %>

            </tr>
        </thead>    
        <tbody>
            
             <% foreach (var item in medicos)
                 {  %>
                    <tr>
                      <td><%:item.Apellido + ", " + item.Nombre %> </td>
                      <td><%:item.Especialidad%></td>
                      <td><%:item.Matricula %></td>
                      <td><%:item.Telefono + " - " + item.Mail %></td>
                         <%if (Session["tipoUsuario"].ToString() == "Administrador")
                           { %>
                              <td>                          
                                  <a class="btn" href="/Cartilla_Crear.aspx?dni=<%:item.Dni%>" aria-label="Edit"> <i class="material-icons" aria-hidden="true">edit</i></a>
                                  <a class="btn" href="/Cartilla.aspx?dni=<%:item.Dni%>" aria-label="Delete"> <i class="material-icons" aria-hidden="true">delete</i></a>
                              </td>                    
                        <% } %>
                    </tr>
             
             <% }  %>
           
        </tbody>
        <tfoot>
            <tr>
                <th>Nombre y Apellido</th>            
                <th>Especialidad</th>
                <th>Matricula</th>
                <th>Contacto</th>
                 <%if (Session["tipoUsuario"].ToString() == "Administrador")
                     { %>
                        <th>Acciones</th>
                  <% } %>
            </tr>
        </tfoot>

     
    </table>
  </div>
</asp:Content>
