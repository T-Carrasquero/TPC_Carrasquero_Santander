<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Solicitar_Turno.aspx.cs" Inherits="Clinica.Solicitar_Turno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display:flex; flex-direction:column; margin-top:1em; box-shadow : 0 0 10px black; padding:2em; justify-content:space-around; align-items:center; margin-top: 2em;">
   
    <div id="titulo" style="display:flex;  flex-direction:row; justify-content:space-between; width:100%;  margin-bottom: 2em;">
         <h3>Solicitar Turno</h3>
    </div>
        <div id="form" style="display:flex; flex-direction:row; justify-content:space-around; width:100%;">
            <div class="col-1" id="columna1" style="width:45%;">
                <%if (Session["tipoUsuario"].ToString() == "Administrador")
                  {  %>
                    <div id="paciente-ls" style="padding-top:20px;">
                        <label for="ddlPaciente">Paciente *</label>
                        <asp:DropDownList id="ddlPaciente"  runat="server" class="form-select" aria-label="Default select example" required="true">
                            <asp:ListItem Text="Paciente *" Enabled="false"/>
                       </asp:DropDownList>
                    </div>
                <%} %>
                    <div id="especialidad-ls" style="padding-top:20px;">
                        <label for="ddlEspecialidad">Especialidad *</label>
                        <asp:DropDownList id="ddlEspecialidad" runat="server" AutoPostBack="true" class="form-select" aria-label="Default select example" required="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                            <asp:ListItem Text="Especialidad *" />
                        </asp:DropDownList>
                    </div>

                    <div id="medicos-ls" style="padding-top:20px;">
                        <label for="ddlMedicos">Profesional *</label>
                        <asp:DropDownList id="ddlMedicos" runat="server" class="form-select" aria-label="Default select example" required="true">
                            <asp:ListItem Text="Medicos *" />
                        </asp:DropDownList>
                    </div>

            </div>
            <div class="col-1" id="columna2" style="width:45%;">

                    <div id="fecha-ls" style="padding-top:20px;">

                        <label for="fecha">Fecha *</label>
                        <asp:textbox type="date" id="fecha" class="form-select" AutoPostBack="true" runat="server" OnTextChanged="fecha_TextChanged"></asp:textbox>

                    </div>
                    <div id="hora-ls" style="padding-top:20px;">
                        <label for="ddlHorarios">Horario *</label>
                        <asp:DropDownList id="ddlHorarios"  runat="server" class="form-select" aria-label="Default select example" required="true">
                            <asp:ListItem Text="Horarios *" Enabled="false"/>
                       </asp:DropDownList>
                    </div>
            </div>

   
        </div>
             <div id="agregar" class="col-3" style="display:flex; justify-content:space-between; width:100%;  margin-top: 2em;">
                 <p>(*) Campos obligatorios</p>
                 <asp:Button Text="Solicitar" cssClass="btn btn-outline-success" ID="Agregar"  runat="server" OnClick="Agregar_Click" />
            </div>


                     
   </div>


</asp:Content>
