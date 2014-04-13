<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="displayDocumentOnPageTry.aspx.cs" Inherits="Tutor.TeacherManagement.displayDocumentOnPageTry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LinkButton ID="ff" runat ="server" Text="open image" onclick="ff_Click"></asp:LinkButton><br />
<iframe id="holdsImage" runat ="server" width="200px" height ="200px"></iframe>
<br />
<div>
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand" >
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
     <div >
   <%--
    <tr>
    <td>--%>
    <asp:HiddenField id="HiddenField1" runat="server" Value='<%#Eval("WorksheetID") %>' />
    <%--</td>
    <td>--%>
    
    <table >
    <tr>
    <td>
   
      <asp:LinkButton ID="OpenDoc" runat="server" Text='<%#Eval("WorksheetName") %>'></asp:LinkButton>
   </td>
 
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
    <br />
    
<iframe id="holdsDoc" runat ="server" width="800px" height ="900px" visible ="false"></iframe>
</asp:Content>
