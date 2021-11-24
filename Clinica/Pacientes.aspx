<%@ Page Title="Pacientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Clinica.Pacientes" %>
<asp:Content ID="BodyPacientes" ContentPlaceHolderID="MainContent" runat="server">

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
               <h3>Pacientes Registrados</h3>
                <a class="w3-button w3-green" href="/NuevoPaciente.aspx">+</a>
       
        </div>
        <div id="tableContenedor" style="margin-top:2em;">
             <table id="example" class="w3-table w3-bordered w3-hoverable" style="width:100%; padding-top:1em;  padding-bottom:1em;">
            <thead>
                <tr>
                    <th>Apellido y Nombre</th>            
                    <th>Domicilio</th>
                    <th>Correo Electronico</th>
                    <th>Telefono</th>
                    <th>Accion</th>
                </tr>
            </thead>    
            <tbody>
            
                 <% foreach (var item in listaPaciente)
                     {  %>
                        <tr>
                          <td><%:item.Apellido + ", " + item.Nombre %></td>
                          <td><%:item.Direccion + " - "+ item.Localidad %></td>
                          <td><%:item.Mail%></td>
                          <td><%:item.Telefono%></td>
     
                          <td>
                          
                              <a class="btn" href="/NuevoPaciente.aspx?dni=<%:item.Dni%>" aria-label="Edit"> <i class="material-icons" aria-hidden="true">edit</i></a>
                              <a class="btn" href="/Paciente.aspx?dni=<%:item.Dni%>" aria-label="Delete"> <i class="material-icons" aria-hidden="true">delete</i></a>
                      

                          </td>
                        </tr>
             
                 <% }  %>
           
            </tbody>
            <tfoot>
                <tr>
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
