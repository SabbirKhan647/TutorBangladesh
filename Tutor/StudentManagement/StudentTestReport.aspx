<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="StudentTestReport.aspx.cs" Inherits="Tutor.StudentManagement.StudentTestReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="pageHeading">Test Report</h3>

        <br />
<asp:Label ID="showid" runat ="server" text="showid"></asp:Label> <br />

<div class="StudentTestReportContainer">
<table>
<tr>
<td>Total Questions:
</td>
<td><asp:Label ID="lblTQues" runat ="server" cssClass="TestReportData"></asp:Label>
</td>


</tr>

<tr>
<td>You Attempted:
</td>
<td><asp:Label ID="lblAttempted" runat ="server" cssClass="TestReportData"></asp:Label>
</td>
</tr>
<tr>
<td>Total Correct:
</td>
<td><asp:Label ID="lblCorrect" runat ="server" cssClass="TestReportData"></asp:Label>
</td>
</tr>
<tr>
<td>Total Wrong:
</td>
<td><asp:Label ID="lblWrong" runat ="server" cssClass="TestReportData"></asp:Label>
</td>
</tr>
<tr>
<td>Total Worth:
</td>
<td><asp:Label ID="lblWorth" runat ="server" cssClass="TestReportData" ></asp:Label>
</td>
</tr>
<tr>
<td>Your Score:
</td>
<td><asp:Label ID="lblScore" runat ="server" cssClass="TestReportData" ></asp:Label>
</td>
</tr>
<tr>
<td>Score in Percentage:
</td>
<td><asp:Label ID="lblScorePercentage" runat ="server" cssClass="TestReportData" ></asp:Label>
<asp:Label ID="Label15" runat ="server" cssClass="TestReportData" Text="%"></asp:Label>
</td>
</tr>
</table>
</div>

<br /><br />
<asp:Label ID="d" runat ="server" Text="Wrong answers" Font-Bold ="true" Font-Size ="Medium"></asp:Label>
<br />
<asp:Repeater ID="Repeater1" runat="server" >
    <HeaderTemplate>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div >
   
    
    <table >
   <tr>
   <td>
   <asp:Label runat ="server" ID="quesOrder" Text='<%# Eval("QuestionOrder") %>'></asp:Label>
   <asp:Label runat ="server" ID="Question" Text='<%# Eval("Question") %>'></asp:Label>
  
   <br />
   <asp:RadioButton ID="ansA" runat="server" GroupName="Answers"/>
   <asp:Label runat ="server" ID="Label1" Text="A."></asp:Label>
   <asp:Label runat ="server" ID="Label2" Text='<%# Eval("AnswerOptionA") %>'></asp:Label>
   
   <br />
   <asp:RadioButton ID="ansB" runat="server" GroupName="Answers"/> 
   <asp:Label runat ="server" ID="Label3" Text="B."></asp:Label>
   <asp:Label runat ="server" ID="Label4" Text='<%# Eval("AnswerOptionB") %>'></asp:Label>
  
   <br />
   <asp:RadioButton ID="ansC" runat="server" GroupName="Answers"/> 
   <asp:Label runat ="server" ID="Label5" Text="C."></asp:Label>
   <asp:Label runat ="server" ID="Label6" Text='<%# Eval("AnswerOptionC") %>'></asp:Label>
   
   <br />
   <asp:RadioButton ID="ansD" runat="server" GroupName="Answers"/>
   <asp:Label runat ="server" ID="Label7" Text="D."></asp:Label>
   <asp:Label runat ="server" ID="Label8" Text='<%# Eval("AnswerOptionD") %>'></asp:Label>
  
   <br />
   <asp:Label runat ="server" ID="Label13" Text="Correct answer: " Font-Bold="true"></asp:Label>
   <asp:Label runat ="server" ID="Label14" Text='<%# Eval("CorrectAnswer") %>'></asp:Label>
  
   <br />
   <asp:Label runat ="server" ID="Label9" Text="You answered: " Font-Bold="true"></asp:Label>
   <asp:Label runat ="server" ID="Label10" Text='<%# Eval("Answer") %>'></asp:Label>
  
   <br />
   <asp:Label runat ="server" ID="Label11" Text="Explanation: " Font-Bold="true"></asp:Label>
   <asp:Label runat ="server" ID="Label12" Text='<%# Eval("AnswerExplanation") %>'></asp:Label>
  
   <br />

   <hr />
   </td>
       
   
   </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
    <FooterTemplate>
   
    </FooterTemplate>
    </asp:Repeater>








</asp:Content>
