<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="InsertTestQuestion.aspx.cs" Inherits="Tutor.TeacherManagement.InsertTestQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 173px;
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
             <li><a id="A3" href="ChangeTestDate.aspx" runat="server">Change Test Date </a></li>
             </ul>       
           </div>
           </div>
           <br />
           <h3 class="pageHeading">Insert Test Question</h3>
    <table class="style1">
    <tr>
            <td class="style2">
                <asp:Label ID="Label11" runat="server" Text="Batch Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListBatchName" runat="server">
                </asp:DropDownList>
                 <asp:Button ID="btnGO" runat="server" Text="GO" Height="21px" 
                    onclick="btnGO_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListTestID" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Question Order"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListQuesOrder" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Question "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Width="469px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Answer Option A"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnswerA" runat="server" TextMode="MultiLine" Width="466px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Answer Option B"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnswerB" runat="server" TextMode="MultiLine" Width="465px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="Answer Option C"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnswerC" runat="server" TextMode="MultiLine" Width="464px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Answer Option D"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnswerD" runat="server" TextMode="MultiLine" Width="456px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label8" runat="server" Text="Correct Answer"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListCorrectAnswer" runat="server">
                <asp:ListItem runat="server" Text="Select correct answer"></asp:ListItem>
                <asp:ListItem runat="server" Text="A"></asp:ListItem>
                <asp:ListItem runat="server" Text="B"></asp:ListItem>
                <asp:ListItem runat="server" Text="C"></asp:ListItem>
                <asp:ListItem runat="server" Text="D"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label9" runat="server" Text="Answer Explanation"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnswerExplanation" runat="server" TextMode="MultiLine" 
                    Width="455px"></asp:TextBox>
&nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label10" runat="server" Text="Worth"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListWorth" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                    onclick="btnRefresh_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
