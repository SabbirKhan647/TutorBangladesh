<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="RefreshBatch.aspx.cs" Inherits="Tutor.TeacherManagement.RefreshBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="sideNavigation">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherManagement/CreateBatch.aspx">Create Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl ="#">Delete Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Switch Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl ="#">Delete Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl ="~/TeacherManagement/RefreshBatch.aspx">Refresh Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl ="#">Enroll Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl ="#">Available Seat</asp:HyperLink>
 </div>
</asp:Content>
