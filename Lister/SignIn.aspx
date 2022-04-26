<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Lister.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="txtUsername">Username</label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
        <label for="txtPassword">Password</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" ClintIDMode="Static" TextMode="Password"></asp:TextBox>
       <br />
        <asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-primary" Text="Sign In" OnClick="btnSignin_Click"/>
        <label ID="lblSignInFailed" runat="server" CssClass="alert alert-danger" Visible="false"></label>
    </div>
</asp:Content>
