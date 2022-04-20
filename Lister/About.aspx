<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Lister.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <h3>This is where you will make your lists</h3>
    <asp:Panel ID="pnlAddLists" runat="server" ClientIDMode="Static">
        <label for="txtTitle">Add your lists here</label>
        <br />
        <asp:TextBox ID="txtTitle" runat="server" ClientIDMode="Static"></asp:TextBox>
        <asp:Label ID="lblFeedback" runat="server" Visible="False"></asp:Label>
        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Characters Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnTitle" runat="server" ClientIDMode="Static" OnClick="btnSubmit_Click" Text="Add List" />

    </asp:Panel>


</asp:Content>
