<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="Tutor.test1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="repeaterContainer">
<p> Available Tutors</p>
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemdatabound="Repeater1_ItemDataBound">
    <HeaderTemplate>
    <%--<table>
    <tr>
    <td>
    </td>
    <td></td>
    <td></td>
    </tr>
    --%>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div class="Horizontal">
   <%--
    <tr>
    <td>--%>
    <asp:HiddenField id="HiddenField1" runat="server" Value='<%#Eval("userid") %>' />
    <%--</td>
    <td>--%>
    
    <table >
    <tr>
    <td class="tabledata">
     <asp:HyperLink ID="a" runat="server" NavigateUrl="~/Default.aspx"><asp:Image ID="tutorImage" runat="server" Width="50px" Height="60px" /></asp:HyperLink>
   </td>
   <%-- </td>
    <td>--%>
    <td class="tabledata1">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("TeacherId","ViewTutorProfile.aspx?ID={0}") %>'>
     <asp:Label ID="lblTeacherID" runat ="server" Text='<%# Eval("TeacherID") %>'></asp:Label>                   
     <asp:Label ID="lblName" runat ="server" Text='<%# Eval("Name") %>'></asp:Label>                          
    </asp:HyperLink>
    </td>
   <%-- </td>
    </tr>--%>
    </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
    <FooterTemplate>
   <%-- <tr>
    <td>test</td>
    <td></td>
    <td></td>
    </tr>
    </table>--%>
    </FooterTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
