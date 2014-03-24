<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="MyStudent.aspx.cs" Inherits="Tutor.TeacherManagement.MyStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--<h3 class="pageHeading">My Student</h3>--%>
<div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="#" runat="server">By Grade</a></li>
            <li><a id="A2" href="#" runat="server">By Batch </a></li>
            <li><a id="A3" href="#" runat="server">Find Student</a></li>
            <li><a id="A4" href="#" runat="server">Register Student </a></li>
            <li><a id="A5" href="#" runat="server">Delete Student </a></li>
             </ul>       
           </div>
           </div>
<%--<div class="sideNavigation"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl ="#">By Grade</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl ="#">By Batch</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Find Student</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl ="#">Register Student</asp:HyperLink><br />
  <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl ="#">Delete Student</asp:HyperLink><br />
   <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl ="#">Update Student Information</asp:HyperLink><br />
 </div>--%>
</asp:Content>
