﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="CreateNotice.aspx.cs" Inherits="Tutor.TeacherManagement.CreateNotice" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 110px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div>
    <br />
 <h3 class="pageHeading">New Notice</h3>
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
     <table class="style1">
      <tr>
             <td class="style2">
                 <asp:Label ID="Label5" runat="server" Text="Type"></asp:Label>
             </td>
             <td>
                 <asp:RadioButton ID="ForBatch" GroupName ="NoticeType" runat="server" Text="For Batch" />
&nbsp;
                 <asp:RadioButton ID="ForIndividualStudent" runat="server" 
                     GroupName ="NoticeType" Text="For Individual Student" />
             </td>
         </tr>
         <tr>
             <td class="style2">
                 <asp:Label ID="Label1" runat="server" Text="Batch Name"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="DropDownListBatch" runat="server">
                 </asp:DropDownList>
             </td>
         </tr>
         <tr>
             <td class="style2">
                 <asp:Label ID="Label2" runat="server" Text="Subject"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style2">
                 <asp:Label ID="Label3" runat="server" Text="Message"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style2">
             
                 <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                 
             </td>
             <td>
                 <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                 <asp:CalendarExtender ID="CalenderExtender1" runat="server" TargetControlID="txtDate"> </asp:CalendarExtender>
             </td>
         </tr>
         <tr>
             <td class="style2">
                 &nbsp;</td>
             <td>
                 <asp:Button ID="btnGenerateNotice" runat="server" Text="Generate " 
                     onclick="btnGenerateNotice_Click" />
             </td>
         </tr>
         <tr>
             <td class="style2">
                 &nbsp;</td>
             <td>
                 <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
             </td>
         </tr>
     </table>

</asp:Content>
