<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clinica._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
     
    <h1>TPC Clinica</h1>

    <div class="jumbotron">
        <%--<h1>ASP.NET</h1> 
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
     <%--   <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>

    </div>
</asp:Content>
