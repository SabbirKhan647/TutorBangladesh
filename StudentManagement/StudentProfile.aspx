<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="Tutor.StudentManagement.StudentProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br /><br />
        <h3 class="pageHeading">Profile</h3>
 <asp:Image ID="Image1" runat="server" style="width :100px" ImageURL="~/Images/NoImage.jpeg" /><br />
    <asp:Button ID="Button1" runat="server" Text="Change/Upload Picture"  onclick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>



 <asp:FileUpload ID="FileUpload1" runat="server" visible="false" />
 <asp:Button ID="btnUpload" runat="server" Text="Upload" visible="false" onclick="btnUpload_Click" /><br />

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
</asp:Content>
