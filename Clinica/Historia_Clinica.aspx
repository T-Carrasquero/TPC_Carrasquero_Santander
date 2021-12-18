<%@ Page Title="Historia Clinica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historia_Clinica.aspx.cs" Inherits="Clinica.Historia_Clinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display:flex; flex-direction:column; margin-top:1em; box-shadow : 0 0 10px black; padding:2em; justify-content:space-around; align-items:center; margin-top: 2em;">
     <div id="titulo" style="display:flex;  flex-direction:row; justify-content:space-between; width:100%; margin-bottom: 2em;">
         <h3>Paciente: <%: pac.Apellido %>, <%: pac.Nombre %> </h3>
         <asp:Button Text="Volver" cssClass="btn btn-outline-secondary" ID="Volver" runat="server" OnClick="Volver_Click" />
    </div>
   
    
    <% if (Session["tipoUsuario"].ToString() == "Medico" || Session["tipoUsuario"].ToString() == "Administrador" )
        {


            if (turnos.Count != 0)
            {%>
                    <div id="turnos" style="display:flex;  flex-direction:column; justify-content:space-between; width:100%;  margin-bottom: 2em;">

            
                   <% foreach (var item in turnos)
                       {%>
                         <div class="card" style="margin-bottom: 2em;">
                            <div class="card-header"><%: item.Especialidad %> - <%: item.Fecha.ToString("dd-MM-yyyy") %> </div>
                              <div class="card-body">
                                <h5 class="card-title">Dr/Dra: <%: item.Medico %></h5>
                                <p class="card-text">Informe: <%: item.Informe %></p>
                                 <p class="card-text">Indicaciones: <%: item.Indicaciones %></p>
                              </div>
                            </div>                
                    <%}%>
                 </div>
            <%  }
                else
                { %>

                <div>
                        <h6 class="card-subtitle mb-2 text-muted">No hay registros del paciente</h6>
                </div>

              <%} %>
    <% }%>
  </div>

</asp:Content>
