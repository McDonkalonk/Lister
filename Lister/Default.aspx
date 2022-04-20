<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lister._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Lister</h1>
        <p class="lead">A free website that helps you organize your life whether it be for short or long term!</p>
        <p><a href="https://localhost:44378/Register.aspx" class="btn btn-primary btn-lg">Sign Up &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                List making can be a whole new experience with our website!
            </p>
            <p>
                <a class="btn btn-default" href="https://localhost:44378/Lists">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-8">
            <h2>Contact Us</h2>
            <p>
                Feel free to contatct us! just click the link</p>
            <p>
                <a class="btn btn-default" href="https://localhost:44378/Contact">Learn more &raquo;</a>
            </p>
        </div>
        

    </div>
</asp:Content>
