<%@ Page Title="Lists" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lists.aspx.cs" Inherits="Lister.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <h3>This is where you will make your lists</h3>
    <asp:Panel ID="pnlAddLists" runat="server" ClientIDMode="Static">
        <label for="txtTitle">Add your lists here</label>
        <br />
        <asp:TextBox ID="txtTitle" runat="server" ClientIDMode="Static"></asp:TextBox>
        <asp:Label ID="lblFeedback" runat="server" Visible="False"></asp:Label>
        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Characters Required" ForeColor="Red" ValidationGroup="AddList"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnTitle" runat="server" ClientIDMode="Static" OnClick="btnSubmit_Click" Text="Add List" CssClass="btn btn-success" ValidationGroup="AddList" />

        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="Save" Visible="False" />
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click" Text="Cancel" Visible="False" />
        <asp:Label ID="lblListID" runat="server" Text="Label" Visible="False"></asp:Label>

    </asp:Panel>
    <br />
    <asp:Panel ID="pnlTitleList" runat="server">
        <asp:GridView ID="gvListTitle" runat="server" cssclass="table table-hover" AutoGenerateColumns="False" OnRowCommand="gvListTitle_RowCommand" OnRowDataBound="gvListTitle_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ListID" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="List Titles" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-info" Text="Edit" CommandName="EditList" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('are you positive you want to delete?')" Text="Delete" CommandName="DeleteList" />
                        <asp:Button ID="btnGo" runat="server" CssClass="btn btn-success" Text="Go!" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </asp:Panel>


</asp:Content>
