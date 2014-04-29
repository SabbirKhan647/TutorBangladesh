<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="Tutor.TeacherManagement.Evaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="~/TeacherManagement/Evaluation.aspx" runat="server">Test Report By Batch</a></li>
            <li><a id="A2" href="~/TeacherManagement/EvaluationByStudent.aspx" runat="server">Test Report By Student </a></li>
            </ul>       
           </div>
           </div>
    <br />
            <h3 class="pageHeading">Test Report by Batch</h3>
           <br />
           <br />
            <table class="style1">
    <tr>
            <td class="style2">
                <asp:Label ID="Label11" runat="server" Text="Batch Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListBatchName" runat="server">
                </asp:DropDownList>
                 <asp:Button ID="btnGO" runat="server" Text="Get Test" Height="21px" 
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
                <asp:Button ID="btnPreviewTestQuestion" runat="server" Text="Get Report" Height="21px" 
                    onclick="btnPreviewTestQuestion_Click" />
            </td>
        </tr>
        </table>
        <br />
        <br />
        <table>
        <tr>
        <th width="120px" style="border-right:1px solid gray;border-left:1px solid gray;"> Total Student  </th> 
        <th width="120px" style="border-right:1px solid gray;"> Total Present  </th> 
        <th width="120px" style="border-right:1px solid gray;"> Total Absent  </th> 
        <th width="120px" style="border-right:1px solid gray;"> Total Marks  </th> 
        <th width="120px" style="border-right:1px solid gray;"> Total Questions  </th> 
        <th width="120px" style="border-right:1px solid gray;"> Average (%)  </th> 
        <th width="120px" style="border-right:1px solid gray;"> Highest Mark  </th> 
        </tr>
        <tr>
        <td width="120px" style="border-right:1px solid gray;border-left:1px solid gray;"><asp:Label ID="lbltStu" runat ="server" width="120px" CssClass ="TestReport" ></asp:Label></td>
         <td width="120px" style="border-right:1px solid gray;"><asp:Label ID="lbltPresnt" runat ="server" width="120px" CssClass ="TestReport" ></asp:Label></td> 
         <td width="120px" style="border-right:1px solid gray;"><asp:Label ID="lbltAbsent" runat ="server" width="120px" CssClass ="TestReport"></asp:Label></td> 
         <td width="120px" style="border-right:1px solid gray;"><asp:Label ID="lbltMarks" runat ="server" width="120px" CssClass ="TestReport"></asp:Label></td> 
         <td width="120px" style="border-right:1px solid gray;"><asp:Label ID="lblTQues" runat ="server" width="120px" CssClass ="TestReport"></asp:Label></td> 
         <td width="120px" style="border-right:1px solid gray;"><asp:Label ID="lblAvg" runat ="server" width="120px" CssClass ="TestReport"></asp:Label></td>
         <td width="120px" style="border-right:1px solid gray;"><asp:Label ID="lblhighMark" runat ="server" width="120px" CssClass ="TestReport" ></asp:Label></td>
        
        </tr>
        
        
        </table>
</asp:Content>
