<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Clinica.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
<div style="display:flex; flex-direction:column; margin-top:1em; box-shadow : 0 0 10px black; padding:2em; justify-content:space-around; align-items:center; margin-top: 2em;">
   
    <div id="titulo" style="display:flex;  flex-direction:row; justify-content:space-between; width:100%;  margin-bottom: 2em;">
         <h3>Turnos</h3>
         <a Text="Solicitar Turno" class="btn btn-outline-success" ID="Button1" href="/Solicitar_Turno.aspx">Solicitar Turno</a>
    </div>
    
    <% if (turnosLista != null)
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
    <% }
        else
        { %>

        <div>
                <h6 class="card-subtitle mb-2 text-muted">No tiene turnos a su nombre</h6>
        </div>

      <%} %>
</div>


</asp:Content>
