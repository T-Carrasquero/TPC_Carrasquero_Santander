<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaObraSocial.aspx.cs" Inherits="Clinica.NuevaObraSocial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display:flex; flex-direction:column; justify-content:space-around; align-items:center; margin-top: 2em;">
   
    <div id="titulo" style="display:flex; flex-direction:column; justify-content:space-between; width:100%;  margin-bottom: 2em;">
         <h3>Alta Obra Social</h3>
    </div>

    <div id="form" style="display:flex; flex-direction:row; justify-content:space-around; width:100%;">

                <div class="col-1" id="columna1" style="width:45%;" >
                   <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="rnos" placeholder="Rnos" required="true" runat="server" />
                        <label for="rnos">Rnos *</label>
                   </div>
                    
                    <div class="form-floating mb-3" >
                        <asp:TextBox type="text" class="form-control" id="sigla" placeholder="Sigla" required="true" runat="server" />
                        <label for="Sigla">Sigla *</label>
                   </div> 
        
                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="nombre" placeholder="Nombre" required="true" runat="server" />
                        <label for="Nombre">Nombre *</label>
                   </div>
 
               </div>
                <div class="col-2" id="columna2" style="display:flex; flex-direction:column; justify-content:space-around; width:45%;">

                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" ID="email" placeholder="name@example.com" CssClass="form-control" runat="server" />
                        <label for="Email">Email</label>
                   </div>

                     <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="direccion" placeholder="Direccion" runat="server" />
                        <label for="direccion">Direccion</label>
                    </div>
                    
                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="codigoPostal" placeholder="Codigo Postal" runat="server" />
                        <label for="codigoPostal">Codigo Postal</label>
                    </div>
                
                </div>
         </div>

        <div id="agregar" class="col-3" style="display:flex; justify-content:space-between; width:100%;  margin-top: 2em;">
             <p>(*) Campos obligatorios</p>
             <asp:Button Text="Agregar" cssClass="btn btn-outline-success" ID="Agregar" OnClick="btnAgregar_Click" runat="server" />
        </div>

</div>

</asp:Content>
