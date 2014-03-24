<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="PreviewTestQuestion.aspx.cs" Inherits="Tutor.TeacherManagement.PreviewTestQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="CreateTest.aspx" runat="server">Create Test</a></li>
            <li><a id="A2" href="InsertTestQuestion.aspx" runat="server">Insert Question </a></li>
              
            <li><a id="A5" href="PreviewTestQuestion.aspx" runat="server">Preview Question </a></li>
            <li><a id="A6" href="ChangeTestDate.aspx" runat="server">Change Test Date </a></li>
             </ul>       
           </div>
           </div>
           <br />
           <h3 class="pageHeading">Preview Test Question</h3>
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
                <asp:Button ID="btnPreviewTestQuestion" runat="server" Text="Get Question" Height="21px" 
                    onclick="btnPreviewTestQuestion_Click" />
            </td>
        </tr>
        </table>
           <div class="">
    <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand"  >
    <HeaderTemplate>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div >
   
    
    <table >
   <tr>
   <td>
   <asp:Label runat ="server" ID="quesOrder" Text='<%# Eval("QuestionOrder") %>'></asp:Label>
 <%--  <asp:TextBox runat ="server" ID="txtQorder" Text='<%# Eval("QuestionOrder") %>' ></asp:TextBox>--%>
   <asp:Label runat ="server" ID="Question" Text='<%# Eval("Question") %>'></asp:Label>
   <asp:TextBox runat ="server" ID="txtQues" Text='<%# Eval("Question") %>' visible="false"></asp:TextBox>
   <br />
   <asp:RadioButton ID="ansA" runat="server" GroupName="Answers"/>
   <asp:Label runat ="server" ID="Label1" Text="A."></asp:Label>
   <asp:Label runat ="server" ID="Label2" Text='<%# Eval("AnswerOptionA") %>'></asp:Label>
   <asp:TextBox runat ="server" ID="txtAnsA" Text='<%# Eval("AnswerOptionA") %>' visible="false" ></asp:TextBox>
   <br />
   <asp:RadioButton ID="ansB" runat="server" GroupName="Answers"/> 
   <asp:Label runat ="server" ID="Label3" Text="B."></asp:Label>
   <asp:Label runat ="server" ID="Label4" Text='<%# Eval("AnswerOptionB") %>'></asp:Label>
   <asp:TextBox runat ="server" ID="txtAnsB" Text='<%# Eval("AnswerOptionB") %>' visible="false"></asp:TextBox>
   <br />
   <asp:RadioButton ID="ansC" runat="server" GroupName="Answers"/> 
   <asp:Label runat ="server" ID="Label5" Text="C."></asp:Label>
   <asp:Label runat ="server" ID="Label6" Text='<%# Eval("AnswerOptionC") %>'></asp:Label>
   <asp:TextBox runat ="server" ID="txtAnsC" Text='<%# Eval("AnswerOptionC") %>' visible="false" ></asp:TextBox>
   <br />
   <asp:RadioButton ID="ansD" runat="server" GroupName="Answers"/>
   <asp:Label runat ="server" ID="Label7" Text="D."></asp:Label>
   <asp:Label runat ="server" ID="Label8" Text='<%# Eval("AnswerOptionD") %>'></asp:Label>
   <asp:TextBox runat ="server" ID="txtAnsD" Text='<%# Eval("AnswerOptionD") %>' visible="false"></asp:TextBox>
   <br />
  <asp:Button runat="server" ID="Button1" Text="Edit"  />
  <asp:Button runat="server" ID="Button2" Text="Update"  />
   <asp:Button runat="server" ID="SaveAnswer" Text="Delete"  />
   </td>
       
   
   </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
    <FooterTemplate>
   
    </FooterTemplate>
    </asp:Repeater>
    </div>
    <asp:Label ID="ll" runat="server" Text="mm"></asp:Label>
</asp:Content>
