<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="CreateTest.aspx.cs" Inherits="Tutor.TeacherManagement.CreateTest" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 153px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="CreateTest.aspx" runat="server">Create Test</a></li>
            <li><a id="A2" href="InsertTestQuestion.aspx" runat="server">Insert Question </a></li>
             <li><a id="A5" href="PreviewTestQuestion.aspx" runat="server">Preview Question </a></li>
             <li><a id="A3" href="#" runat="server">Change Test Date </a></li>
             </ul>       
           </div>
           </div>
           <br />
           <h3 class="pageHeading">Create Test</h3>
           <asp:Panel ID="createtest" runat="server">
               <table class="style1">
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
                           <asp:Label ID="Label2" runat="server" Text="Test Name"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="DropDownTestName" runat="server">
                        
                           </asp:DropDownList>
                       </td>
                   </tr>
                  
                   <tr>
                       <td class="style2">
                           <asp:Label ID="Label4" runat="server" Text="Duration"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="DropDownTestDuration" runat="server">
                           <asp:ListItem Text="30 minute" runat="server"></asp:ListItem>
                            <asp:ListItem Text="1:00 Hour" runat="server"></asp:ListItem>
                            <asp:ListItem Text="1:30 Hour" runat="server"></asp:ListItem>
                             <asp:ListItem Text="2:00 Hour" runat="server"></asp:ListItem>
                            <asp:ListItem Text="2:30 Hour" runat="server"></asp:ListItem>
                            <asp:ListItem Text="3:00 Hour" runat="server"></asp:ListItem>
                            
                           </asp:DropDownList>
                       </td>
                   </tr>
                    <tr>
                       <td ID="Td1" class="style2">
                           <asp:Label ID="Label7" runat="server" Text="Total Questions"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="DropDownTestTotalQuestion" runat="server">
                            
                           </asp:DropDownList>
                        </td>
                   </tr>
                   <tr>
                       <td class="style2">
                           <asp:Label ID="Label8" runat="server" Text="Total Marks"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="DropDownTestTotalMark" runat="server">
                            
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td ID="Batch Name" class="style2">
                           <asp:Label ID="Label5" runat="server" Text="Test Available Date"></asp:Label>
                       </td>
                       <td>
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                            <asp:TextBox ID="txtTestAvailableDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalenderExtender1" runat="server" 
                                TargetControlID="txtTestAvailableDate">
                            </asp:CalendarExtender>
                       </td>
                   </tr>
                   <tr>
                       <td class="style2">
                           <asp:Label ID="Label9" runat="server" Text="Test Expire Date"></asp:Label>
                       </td>
                       <td>
                        
                         <asp:TextBox ID="txtTestExpireDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                TargetControlID="txtTestExpireDate">
                            </asp:CalendarExtender>
                       </td>
                   </tr>
                  
                   <tr>
                       <td class="style2">
                           &nbsp;</td>
                       <td>
                           <asp:Button ID="btnCreateTest" runat="server" Text="Create Test" 
                               onclick="btnCreateTest_Click" />
                       </td>
                   </tr>
               </table>
           
           
           
           
           
           
           </asp:Panel>
</asp:Content>
