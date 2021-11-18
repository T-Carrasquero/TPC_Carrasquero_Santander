<%@ Page Title="Nuevo Registro Profesional" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cartilla_Crear.aspx.cs" Inherits="Clinica.Cartilla_Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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

<div style="display:flex; flex-direction:column; justify-content:space-around; align-items:center; margin-top: 2em;">
   
    <div id="titulo" style="display:flex; flex-direction:column; justify-content:space-between; width:100%;  margin-bottom: 2em;">
         <h3>Agregar nuevo Profesional</h3>
    </div>

    <div id="form" style="display:flex; flex-direction:row; justify-content:space-around; width:100%;">

                <div class="col-1" id="columna1" style="width:45%;" >
                   <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="nombre" placeholder="Nombre" required="true" runat="server" />
                        <label for="nombre">Nombre *</label>
                   </div>
        
                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="Apellido" placeholder="Apellido" required="true" runat="server" />
                        <label for="Apellido">Apellido *</label>
                   </div>
       
                    <div class="form-floating mb-3" >
                        <asp:TextBox type="text" class="form-control" id="Dni" placeholder="Dni" required="true" runat="server" />
                        <label for="Dni">Dni *</label>
                   </div> 

                   <div id="sexo">
              
                       <asp:RadioButtonList ID="rblist" runat="server" >
                           <asp:ListItem Value="m" cssClass="w3-radio" id="rbtnM" >Masculino</asp:ListItem>
                           <asp:ListItem Value="f" cssClass="w3-radio" id="rbtnF">Femenino</asp:ListItem>
                           <asp:ListItem Value="x" cssClass="w3-radio" id="rbtnX">Otro</asp:ListItem>
                       </asp:RadioButtonList>
                           
                    </div>
                    <div id="especialidad-ls" style="padding-top:20px;">
                        <asp:DropDownList id="ddlEspecialidad" runat="server" class="form-select" aria-label="Default select example" required="true">
                            <asp:ListItem Text="Especialidad *" />
                        </asp:DropDownList>


                     <%-- <select class="form-select" aria-label="Default select example" required>
                        <option selected>Especialidad *</option>
                               <%var id = 0;
                               foreach (var item in Especialidad) { %>                       
                                    <option value="<%: id %>"><%: item.Descripcion %></option>
                                    <%id ++ ;%> 
                               <%} %>
                      </select>--%>
                   </div>
   
               </div>
                <div class="col-2" id="columna2" style="display:flex; flex-direction:column; justify-content:space-around; width:45%;">
                    <div class="form-floating mb-3">
                         <asp:TextBox type="text" cssClass="form-control" id="matricula" placeholder="Matricula" required="true" runat="server" />
                        <label for="matricula">Matricula *</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" ID="email" placeholder="name@example.com" CssClass="form-control" runat="server" />
                        <label for="email">Email</label>
                   </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="codigoPostal" placeholder="Codigo Postal" runat="server" />
                        <label for="codigoPostal">Codigo Postal</label>
                    </div>
                
                     <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="direccion" placeholder="Direccion" runat="server" />
                        <label for="direccion">Direccion</label>
                    </div>
                     <div class="form-floating mb-3">
                        <asp:TextBox type="tel" cssClass="form-control" id="telefono" placeholder="Telefono" runat="server" />
                        <label for="telefono">Telefono</label>
                    </div>

                    
                </div>
         </div>

        <div id="agregar" class="col-3" style="display:flex; justify-content:space-between; width:100%;  margin-top: 2em;">
             <p>(*) Campos obligatorios</p>
             <asp:Button Text="Agregar" cssClass="btn btn-outline-success" ID="Agregar" OnClick="btnAgregar_Click" runat="server" />
        </div>


</div>


</asp:Content>
