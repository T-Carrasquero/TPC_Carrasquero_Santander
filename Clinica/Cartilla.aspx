<%@ Page Title="Cartilla" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cartilla.aspx.cs" Inherits="Clinica.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table id="example" class="w3-table-all w3-hoverable" style="width:100%; margin-top:3em">
        <thead>
            <tr>
                <th>Nombre</th>
                <th>Apellido</th>
                <th>Especialidad</th>
                <th>Matricula</th>
            </tr>
        </thead>
        <tbody>
            
             <% foreach (var item in medico)
                {  %>
                    <tr>
                      <td><%:item.Nombre %></td>
                      <td><%:item.Apellido %></td>
                      <td><%:item.Especialidad %></td>
                      <td><%:item.Matricula %></td>
                    </tr>
             
             <% }  %>
           
        </tbody>
        <tfoot>
            <tr>
                <th>Nombre</th>
                <th>Apellido</th>
                <th>Especialidad</th>
                <th>Matricula</th>
            </tr>
        </tfoot>
    </table>
    


</asp:Content>
