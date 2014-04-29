<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="CreateTest.aspx.cs" Inherits="Tutor.TeacherManagement.CreateTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 100%;
        }

        .style2 {
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListBatch" ErrorMessage="Please select batch name." Font-Bold="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Test Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownTestName" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownTestName" ErrorMessage="Please select test name." Font-Bold="True"></asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownTestDuration" ErrorMessage="Please select duration." Font-Bold="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--  <tr>
                       <td ID="Td1" class="style2">
                           <asp:Label ID="Label7" runat="server" Text="Total Questions"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="DropDownTestTotalQuestion" runat="server">
                            
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownTestTotalQuestion" ErrorMessage="Please select total question." Font-Bold="True"></asp:RequiredFieldValidator>
                        </td>
                   </tr>--%>
            <%--<tr>
                       <td class="style2">
                           <asp:Label ID="Label8" runat="server" Text="Total Marks"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="DropDownTestTotalMark" runat="server">
                            
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownTestTotalMark" ErrorMessage="Please select total mark." Font-Bold="True"></asp:RequiredFieldValidator>
                       </td>
                   </tr>--%>
            <tr>
                <td id="Batch Name" class="style2">
                    <asp:Label ID="Label5" runat="server" Text="Test Available Date"></asp:Label>
                </td>
                <td>
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                    <asp:TextBox ID="txtTestAvailableDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalenderExtender1" runat="server"
                        TargetControlID="txtTestAvailableDate">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTestAvailableDate" ErrorMessage="Please select date." Font-Bold="True"></asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTestExpireDate" ErrorMessage="Please select date." Font-Bold="True"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnCreateTest" runat="server" Text="Create Test" class="buttonstyle"
                        OnClick="btnCreateTest_Click" />
                </td>
            </tr>

        </table>

        <span onclick="return confirm('Are you sure you want to create this test?')">
            <br />
        </span>
        <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#009933" Visible="false" ></asp:Label><br />
        <asp:Label ID="Label11" runat="server" Text="Label" Font-Bold="True"
            ForeColor="#009933" Visible="False"></asp:Label>




    </asp:Panel>
</asp:Content>
