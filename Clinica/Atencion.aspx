<%@ Page Title="Atencion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Atencion.aspx.cs" Inherits="Clinica.Atencion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display:flex; flex-direction:column; margin-top:1em; box-shadow : 0 0 10px black; padding:2em; justify-content:space-around; align-items:center; margin-top: 2em;">
   
    <div id="titulo" style="display:flex;  flex-direction:row; justify-content:space-between; width:100%;  margin-bottom: 2em;">
         <h3>Informe del turno</h3>
         <a Text="Consultar historia clinica del paciente" class="btn btn-outline-primary" ID="Button1" href="/Historia_Clinica.aspx?idHistoria=<%:tur.dniPaciente %>&origin=atencion&idTurno=<%:tur.id %>">Consultar historia clinica del paciente</a>
    </div>
    <div id="form" style="display:flex; flex-direction:column; justify-content:space-around; width:100%;">

                <div class="col-1" id="columna1" style="width:100%; padding: 2em;" >

                    <div class="form-floating mb-3 style="width:100%; padding: 2em;"">
                        <asp:TextBox type="text" cssClass="form-control" id="Paciente" Readonly="true" placeholder="Paciente" required="true" runat="server" mode="multiline" lines="10" cols="10" wrap="true" rows="3" />
                        <label for="Paciente">Paciente</label>
                   </div>   

                   <div class="form-floating mb-3 style="width:100%; padding: 2em;"">
                        <asp:TextBox type="text" cssClass="form-control" id="Informe" placeholder="Informe" required="true" runat="server" mode="multiline" lines="10" cols="10" wrap="true" rows="3" />
                        <label for="Informe">Informe *</label>
                   </div>                

                        <div class="form-floating mb-3">
                         <asp:TextBox type="text" cssClass="form-control" id="Indicaciones" placeholder="Indicaciones" required="true" runat="server" />
                        <label for="Indicaciones">Indicaciones *</label>
                    </div>
   
               </div>
        
         <div id="historia" class="col-3" style="display:flex; justify-content:flex-end; width:100%;  margin-top: 2em;">
            
        </div>

        <div id="agregar" class="col-3" style="display:flex; justify-content:space-between; width:100%;  margin-top: 2em;">
             <p>(*) Campos obligatorios</p>
             <asp:Button Text="Guardar" cssClass="btn btn-outline-success" ID="Guardar" runat="server" OnClick="Guardar_Click" />
        </div>


</div>



    </div>
</asp:Content>
