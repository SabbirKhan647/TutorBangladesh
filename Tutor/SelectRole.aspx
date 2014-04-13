<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="SelectRole.aspx.cs" Inherits="Tutor.Account.SelectRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>
        Welcome to Tutoring Management Webportal&nbsp; Manage
    </h2>
    <p>
    </p>
    <asp:Panel ID="PanelChoose" runat="server" >
        <p>
            Choose your role:<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Tutor</asp:ListItem>
                <asp:ListItem>Student</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
            <br />
        </p>
    </asp:Panel>

</asp:Content>
