<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Tutor.StudentManagement.Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>Quiz
<asp:Label ID="showSessionID" runat ="server"></asp:Label>
</div>
<h3 class="pageHeading">Quiz    </h3>
   
   
        <asp:Label ID="Label2" runat="server" Text="Subject:"></asp:Label>
   
    <asp:DropDownList ID="drBatch" runat ="server"></asp:DropDownList>
        <asp:Button ID="DisplayQuiz" runat ="server" 
         Text="Go" CssClass="gap" OnClick="DisplayQuiz_Click" />
        <br />
     
   <div>
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
    <HeaderTemplate>
    <table>
    <tr>
    <td width="400px">
    </td>
    <td width="100px">
    Start Date
    </td>
    <td width="200px">
    Due Date/Time
    </td>
   
    </tr>
    </table>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div>
   
    
    <table >
    <tr>
 
    <td width="400px" >
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("TestID","StartQuiz.aspx?ID={0}") %>'>
     <asp:Label ID="lbltestname" runat ="server" Text='<%# Eval("testname") %>'></asp:Label>                   
                         
    </asp:HyperLink>
    </td>
    <td width="100px">
     <asp:Label id="lblTestAvailableDate" runat ="server" Text='<%# Bind("TestAvalilableDate","{0:yyyy-MM-dd}") %>' ></asp:Label>
    </td>
   <td width="200px">
   <asp:Label id="lbltestExpireDate" runat ="server" Text='<%# Eval("TestExpireDate") %>'></asp:Label>
   
   </td>
    </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
   
    </asp:Repeater>
    </div>
</asp:Content>
