<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recepcionistas.aspx.cs" Inherits="Clinica.Recepcionistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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

        <div style="margin-top:1em; box-shadow : 0 0 10px black; padding:2em;">   
        <div style="display:flex; justify-content:space-between;  align-items:center;" title="Nuevo Registro" >
               <h3>Recepcionistas</h3>
                <a class="w3-button w3-green" href="/NuevoRecepcionista.aspx">+</a>
       
        </div>
        <div id="tableContenedor" style="margin-top:2em;">
             <table id="example" class="w3-table w3-bordered w3-hoverable" style="width:100%; padding-top:1em;  padding-bottom:1em;">
            <thead>
                <tr>
                    <th>Legajo</th>            
                    <th>Apellido y Nombre</th>            
                    <th>Domicilio</th>
                    <th>Correo Electronico</th>
                    <th>Telefono</th>
                    <th>Accion</th>
                </tr>
            </thead>    
            <tbody>
            
                 <% foreach (var item in listaRecepcionistas)
                     {  %>
                        <tr>
                          <td><%:item.Legajo%></td>
                          <td><%:item.Apellido + ", " + item.Nombre %></td>
                          <td><%:item.Direccion + " - "+ item.Localidad %></td>
                          <td><%:item.Mail%></td>
                          <td><%:item.Telefono%></td>
                          <td>
                          
                              <a class="btn" href="/NuevoRecepcionista.aspx?dni=<%:item.Dni%>" aria-label="Edit"> <i class="material-icons" aria-hidden="true">edit</i></a>
                              <a class="btn" href="/Recepcionistas.aspx?dni=<%:item.Dni%>" aria-label="Delete"> <i class="material-icons" aria-hidden="true">delete</i></a>
                      

                          </td>
                        </tr>
             
                 <% }  %>
               
            </tbody>
            <tfoot>
                <tr>
                    <th>Legajo</th>
                    <th>Apellido y Nombre</th>            
                    <th>Domicilio</th>
                    <th>Correo Electronico</th>
                    <th>Telefono</th>
                    <th>Accion</th>
                </tr>
            </tfoot>

     
        </table>
      </div>
    </div>

</asp:Content>
