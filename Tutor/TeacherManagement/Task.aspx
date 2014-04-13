<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="Tutor.TeacherManagement.Task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    task

    <br />
    <table>
     <tr><td>
        <asp:Label ID="Label2" runat="server" Text="Batch Name"></asp:Label>
        </td><td>
        <asp:DropDownList runat ="server" ID="DropDownListBatchName">
        
        </asp:DropDownList></td></tr>
    <tr><td>
        <asp:Label ID="Label1" runat="server" Text="Task Name"></asp:Label>
        </td><td>
        <asp:DropDownList runat ="server" ID="DropDownTaskName">
        
        </asp:DropDownList></td></tr>
     <tr><td>
        <asp:Label ID="Label3" runat="server" Text="Start Date"></asp:Label>
        </td><td>
       <asp:Calendar ID="stdate" runat ="server"></asp:Calendar>
        </td></tr>
        
           <tr><td>
        <asp:Label ID="Label4" runat="server" Text="End Date"></asp:Label>
        </td><td>
       <asp:Calendar ID="enddate" runat ="server"></asp:Calendar>
        </td></tr>  
           <tr><td>
        <asp:Label ID="Label5" runat="server" Text="End Time"></asp:Label>
        </td><td>
      <asp:Label runat ="server" ID="lblendtime" Text="12:00 AM"></asp:Label>
        </td></tr>  
            <tr><td>
        
        </td><td>
     <asp:Button runat="server" ID="btnGenerateTask" Text="Create Task" onClick="btnGenerateTask_Click"/>
        </td></tr>  
        
        </table>
        <asp:Label runat="server" ID="ll" Text ="m"></asp:Label>
</asp:Content>
