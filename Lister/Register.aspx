 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Lister.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="txtEmail">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ClintIDMode="Static"></asp:TextBox>
        <label for="txtUsername">Username</label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
        <label for="txtPassword">Password</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" ClintIDMode="Static" TextMode="Password"></asp:TextBox>
       
    </div>
    <div class="form-group">
        <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" Text="Register" />
        <label ID="lblRegisterFailed" runat="server" CssClass="alert alert-danger" Visible="false"></label>
    </div>
</asp:Content>
