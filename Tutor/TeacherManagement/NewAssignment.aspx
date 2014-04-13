<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="NewAssignment.aspx.cs" Inherits="Tutor.TeacherManagement.NewAssignment" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 121px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="~/TeacherManagement/ViewDropboxSubmission.aspx" runat="server">Grade Dropbox Submission</a></li>
            <li><a id="A2" href="~/TeacherManagement/NewAssignment.aspx" runat="server">New Assignment</a></li>
             </ul>       
           </div>
           </div>
   <h3 class="pageHeading">New Assignment</h3><br />
    <table class="style1">
        <tr>
            <td class="style2">
<asp:Label ID="lblBatch" runat ="server" Text="Batch"></asp:Label>
            </td>
            <td>
<asp:DropDownList ID="batch" runat ="server" >
</asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td class="style2">
<asp:Label ID="Label1" runat ="server" Text="Assignment"></asp:Label>
            </td>
            <td>
<asp:DropDownList ID="Assignment" runat ="server" >
<asp:ListItem Text="Assignment 1"></asp:ListItem>
<asp:ListItem Text="Assignment 2"></asp:ListItem>
<asp:ListItem Text="Assignment 3"></asp:ListItem>
<asp:ListItem Text="Assignment 4"></asp:ListItem>
<asp:ListItem Text="Assignment 5"></asp:ListItem>
<asp:ListItem Text="Assignment 6"></asp:ListItem>
</asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
<asp:Label ID="Label2" runat ="server" Text="Start Date: "></asp:Label>
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
            </td>
            <td>
<asp:TextBox id="txtstdate" runat ="server"></asp:TextBox>
<asp:CalendarExtender ID="CalenderExtender1" runat="server" 
                                TargetControlID="txtstdate">
                            </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">
<asp:Label ID="Label3" runat ="server" Text="Due Date: "></asp:Label>
            </td>
            <td>
<asp:TextBox id="txtduedate" runat ="server"></asp:TextBox>
<asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtduedate">
                            </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">


<asp:Label ID="lblselectfile" runat ="server" Text ="Select File: "></asp:Label>
            </td>
            <td>
<asp:FileUpload ID="FileUpload1" runat ="server" />

            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnCreateAssignment" runat="server" Text="Add Assignment" 
                    onclick="btnCreateAssignment_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>


<asp:Label ID="lblMessage" runat ="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
<br />
    <br />
    <br />


</asp:Content>
