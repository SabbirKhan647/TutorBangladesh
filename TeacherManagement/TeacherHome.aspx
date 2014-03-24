<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="TeacherHome.aspx.cs" Inherits="Tutor.Teacher2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <asp:Label ID="date" runat ="server" Text ="dddddddd" ></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="By Grade:"></asp:Label>
    <asp:DropDownList ID="MyStudentByGrade" runat="server" 
        onselectedindexchanged="MyStudentByGrade_SelectedIndexChanged"> </asp:DropDownList>
         <asp:Label ID="Label2" runat="server" Text="By Subject:"></asp:Label>
    <asp:DropDownList ID="MyStudentBySubject" runat="server" 
        onselectedindexchanged="MyStudentBySubject_SelectedIndexChanged"></asp:DropDownList>
         <asp:Label ID="Label3" runat="server" Text="By Batch:"></asp:Label>
    <asp:DropDownList ID="MyStudentByBatch" runat="server" 
        onselectedindexchanged="MyStudentByBatch_SelectedIndexChanged"></asp:DropDownList>
    <asp:GridView ID="MyStudent" runat="server">
    </asp:GridView>

  
</asp:Content>
