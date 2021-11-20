<%@ Page Title="Pacientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Clinica.Pacientes" %>
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

    <nav class="navbar navbar-expand-lg navbar-light bg-light">
             <div class="container-fluid">
                <a class="navbar-brand" href="#">Clínica</a>
                  <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                      <span class="navbar-toggler-icon"></span>
                 </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent" >
                   <ul class="navbar-nav me-auto mb-2 mb-lg-0" >
                      <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="Default.aspx"><span class="material-icons">home</span> Home</a>
                     </li>
                     <li class="nav-item" style="justify-content:center;align-content:center;">
                            <a class="nav-link" href="/Cartilla"><span class="material-icons">medical_services</span> Cartilla</a>
                     </li>
                       <li class="nav-item">
                            <a class="nav-link" href="/Pacientes"><span class="material-icons">groups</span> Pacientes</a>
                     </li>
                   <!--  <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Dropdown
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="#">Action</a></li>
                                <li><a class="dropdown-item" href="#">Another action</a></li>
                                <li><hr class="dropdown-divider"></li>
                                <li><a class="dropdown-item" href="#">Something else here</a></li>
                             </ul>
                    </li>
                    <li class="nav-item">
                            <a class="nav-link disabled">Disabled</a>
                    </li>-->
                </ul>
             </div>
         </div>
    </nav>

    <div style="display:flex; justify-content:space-between; align-items:center; margin-top: 2em;" title="Nuevo Registro" >
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
</asp:Content>
