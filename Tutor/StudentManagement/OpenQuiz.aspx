<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="OpenQuiz.aspx.cs" Inherits="Tutor.StudentManagement.OpenQuiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br />
<asp:Button id="startTest" runat="server" OnClick="startTest_Click" Text="Start Test" />
<asp:Label runat="server" ID="gg"></asp:Label>
<asp:Label runat="server" ID="Label1"></asp:Label><br />
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <table></table>
    </HeaderTemplate>
    <ItemTemplate>
     <div >
   
    
    <table >
   <tr>
   <td>
   <asp:Label runat ="server" ID="quesOrder" Text='<%# Eval("QuestionOrder") %>'></asp:Label>
   <asp:Label runat ="server" ID="Question" Text='<%# Eval("Question") %>'></asp:Label><br />
   </td>
   <td>
   <asp:Button ID="SaveAnswer" Text="Save" runat="server" OnCommand="SaveAnswer_Click" CommandName="SaveAnswerClick" CommandArgument='<%# Eval("QuestionOrder") %>' ForeColor="Red" />
   <asp:Button ID="ChangeAnswer" Text="Change Answer" runat="server" OnCommand="ChangeAnswer_Click" CommandName="ChangeAnswerClick" CommandArgument='<%# Eval("QuestionOrder") %>' />

   </td>
   </tr>
   <tr>
   <td>    
   <asp:RadioButton ID="ansA" runat="server" GroupName="Answers" /> <asp:Label runat ="server" ID="Label1" Text="A."></asp:Label>
   <asp:Label runat ="server" ID="Label2" Text='<%# Eval("AnswerOptionA") %>'></asp:Label><br />
   <asp:RadioButton ID="ansB" runat="server" GroupName="Answers" /> <asp:Label runat ="server" ID="Label3" Text="B."></asp:Label>
   <asp:Label runat ="server" ID="Label4" Text='<%# Eval("AnswerOptionB") %>'></asp:Label><br />
   <asp:RadioButton ID="ansC" runat="server" GroupName="Answers" /> <asp:Label runat ="server" ID="Label5" Text="C."></asp:Label>
   <asp:Label runat ="server" ID="Label6" Text='<%# Eval("AnswerOptionC") %>'></asp:Label><br />
   <asp:RadioButton ID="ansD" runat="server" GroupName="Answers" /> <asp:Label runat ="server" ID="Label7" Text="D."></asp:Label>
   <asp:Label runat ="server" ID="Label8" Text='<%# Eval("AnswerOptionD") %>'></asp:Label><br />
   </td>
   <td></td>
   
   </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
    <FooterTemplate>
   
    </FooterTemplate>
    </asp:Repeater>
    <asp:Label runat="server" ID="ll"></asp:Label>
</asp:Content>
