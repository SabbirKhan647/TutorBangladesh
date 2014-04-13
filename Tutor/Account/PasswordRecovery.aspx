<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="Tutor.Account.PasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
    <MailDefinition From="usalma2002@yahoo.com" Priority="High" 
        Subject="Your New Temporary Password">
    </MailDefinition>
</asp:PasswordRecovery>
</asp:Content>
