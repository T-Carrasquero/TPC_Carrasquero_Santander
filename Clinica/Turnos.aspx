<%@ Page Title="Turnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Clinica.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
<div style="display:flex; flex-direction:column; margin-top:1em; box-shadow : 0 0 10px black; padding:2em; justify-content:space-around; align-items:center; margin-top: 2em;">

        <script>
            $(document).ready(function () {
                $('#example').DataTable({
                    columnDefs: [
                        { orderable: false, targets: 5 }
                    ],
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                    }
                });
            });
        </script>
   
    <div id="titulo" style="display:flex;  flex-direction:row; justify-content:space-between; width:100%;  margin-bottom: 2em;">
         <h3>Turnos</h3>
         <a Text="Solicitar Turno" class="btn btn-outline-success" ID="Button1" href="/Solicitar_Turno.aspx">Solicitar Turno</a>
    </div>
    
    
    <% if (Session["tipoUsuario"].ToString() == "Paciente")
        {


            if (turnosLista != null)
            {%>
                    <div id="turnos" style="display:flex;  flex-direction:row; justify-content:space-between; width:100%;  margin-bottom: 2em;">

            
                   <% foreach (var item in turnosLista)
                       {%>
                            <div>
                                <div class="card" style="width: 18rem;">
                                  <div class="card-body">
                                    <h5 class="card-title">Dr/Dra: <%:item.Medico%></h5>
                                    <h6 class="card-subtitle mb-2 text-muted">Especialidad</h6>
                                      <br />
                                    <p class="card-text">Estado: <%:item.Estado%></p>
                                    <p href="#" class="card-text">Fecha: <%:item.Fecha.ToString("dd-MM-yyyy")%></p>
                                    <p href="#" class="card-text">Horario: <%:item.Hora%>hs</p>
                                  </div>
                                </div>
                            </div>                    
                    <%}%>
                 </div>
            <%  }
                else
                { %>

                <div>
                        <h6 class="card-subtitle mb-2 text-muted">No tiene turnos a su nombre</h6>
                </div>

              <%} %>
    <% }
        else if(Session["tipoUsuario"].ToString() == "Administrador")
        { %>
    
         <table id="example" class="w3-table w3-bordered w3-hoverable" style="width:100%; padding-top:1em;  padding-bottom:1em; margin-top:2em; ">
        <thead>
            <tr>
                <th>Paciente (DNI)</th>            
                <th>Medico </th>
                <th>Fecha</th>  
                <th>Hora</th>
                <th>Estado</th>
                <th>Acciones</th>
            </tr>
        </thead>    
        <tbody>
            
             <% foreach (var item in turnosLista)
                 {  %>
                    <tr>
                      <td><%:item.Paciente %> </td>
                      <td><%:item.Medico%></td>
                      <td><%:item.Fecha %></td>
                      <td><%:item.Hora + ":00 hs" %></td>
                      <td><%:item.Estado %></td>
                      <td>   
                       <%if (item.Estado.ToString() != "Cancelado")
                              {%>
                         <a class="btn" href="/Turnos.aspx?idCancel=<%:item.id%>" aria-label="Delete"> <i class="material-icons" aria-hidden="true">delete</i></a>
                       <%} %>
                          <%if (item.Estado.ToString() == "A confirmar")
                              {%>
                          <a class="btn" href="/Turnos.aspx?idConfirm=<%:item.id%>" aria-label="Check"> <i class="material-icons" aria-hidden="true">check</i></a>
                          <%} %>
                      </td>                    
                       
                    </tr>
             
             <% }%>
           
        </tbody>
        <tfoot>
            <tr>
                 <th>Paciente (DNI)</th>            
                <th>Medico </th>
                <th>Fecha</th>  
                <th>Hora</th>
                <th>Estado</th>
                <th>Acciones</th>
                 
            </tr>
        </tfoot>

     
    </table>
        
        
       <% }%>
</div>


</asp:Content>
