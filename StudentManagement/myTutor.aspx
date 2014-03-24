<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/StudentSite.master" AutoEventWireup="true"
    CodeBehind="myTutor.aspx.cs" Inherits="Tutor._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
 <h3 class="pageHeading">Notices/Events</h3>
  <asp:Repeater ID="Repeater1" runat="server"  >
    <HeaderTemplate>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div class="NoticeContainer">
   
    
    <table >
   <tr>
   <td>
  <div class="NoticeBatchName"> <asp:Label runat ="server"  ID="lblBatch" Text='<%# Eval("BatchName") %>'></asp:Label></div>
   <div class="NoticeDate"><asp:Label runat ="server" ID="dd" Text="Posted on:"></asp:Label> <asp:Label runat ="server" ID="Date" Text='<%# Eval("Date") %>' ></asp:Label><br /></div> 
   <div class="NoticeSubject"> <asp:Label runat ="server"  ID="lblSubject" Text='<%# Eval("Subject") %>' Font-Bold="true"></asp:Label><br /></div>
   <div class="NoticeMessage">  <asp:Label runat ="server"  ID="lblMessage" Text='<%# Eval("Message") %>'></asp:Label><br /></div>
   </td>
 <%--  <asp:TextBox runat ="server" ID="txtQorder" Text='<%# Eval("QuestionOrder") %>' ></asp:TextBox>--%>
   <td>
   
   
  
   <hr />
  
   </td>
       
   
   </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
    <FooterTemplate>
   
    </FooterTemplate>
    </asp:Repeater>
  
  <%--  <asp:Label ID="Label2" runat="server" Text="Student ID"></asp:Label>--%>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
  
</asp:Content>
