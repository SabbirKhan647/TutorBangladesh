<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="ViewDropboxSubmission.aspx.cs" Inherits="Tutor.TeacherManagement.ViewDropboxSubmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <h3 class="pageHeading">Grade Submission</h3><br />
            <table >
            <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Subject:"></asp:Label></td>
             <td> <asp:DropDownList ID="drBatch" runat ="server"></asp:DropDownList></td>
             <td> <asp:Button ID="DisplayAssignments" runat ="server" Text="Get Assignments"  OnClick="DisplayAssignments_Click" /></td>
            </tr>
            <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Assignments: "></asp:Label></td>
             <td> <asp:DropDownList ID="drAssignments" runat ="server"></asp:DropDownList></td>
             <td><asp:Label ID="lblWorth" runat ="server" Text="Total Marks"></asp:Label></td>
             <td><asp:Label ID="lblHoldsMarks" runat ="server" font-bold="true"></asp:Label></td>
             <td> <asp:Button ID="btnDisplaySubmission" runat ="server" Text="Show Submission"  OnClick="btnDisplaySubmission_Click" />
             
             </td>
            </tr>
           
            </table>
      
        <br />

 <div>
    <asp:Repeater ID="Repeater1" runat="server"  >
    <HeaderTemplate>
    <table>
    <tr>
    <td width="100px">Student ID
    </td>
    <td width="200px"> Student Name
   
    </td>
    <td width="300px"> Date Submitted
    </td>
   <td width="200px"> File Name    </td>
   <td width="200px">Enter Marks</td>
   
    </tr>
    </table>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div>
   
    
    <table >
    <tr>
 
    <td width="100px"><asp:Label id="lblStudentID" runat="server" Text='<%#Eval("StudentID") %>' /></td>
    <td  width="200px"><asp:Label id="Label1" runat="server" Text='<%#Eval("StudentName") %>' /></td>
    <td  width="300px"><asp:Label id="Label3" runat="server" Text='<%#Eval("DateSubmitted") %>' /></td>
    <td width="400px">
     <asp:LinkButton ID="lbSubmittedAssgnmtDocTitle" runat="server" Text='<%#Eval("SubmittedAssgnmtDocTitle") %>' onCommand="lbSubmittedAssgnmtDocTitle_Click"
     CommandName="lbSubmittedAssgnmtDocTitle" CommandArgument='<%# Eval("StudentAssignmentID") %>'>
     </asp:LinkButton>
     <asp:HiddenField ID="hfStudentAssignmentID" runat ="server" Value='<%#Eval("StudentAssignmentID") %>' />
        </td>                                  
   <td width="200px"><asp:TextBox ID="txtassgnmtMarks" runat ="server" width="30px"></asp:TextBox>
   <asp:Button ID="btnEnterMarks" runat ="server" Text="Enter" CommandName="btnEnterMarksClick" onCommand="btnEnterMarks_Click"
   CommandArgument='<%# Eval("StudentAssignmentID") %>'></asp:Button><br />
   <asp:Label ID="lblMessage" runat ="server" Visible ="false"  ></asp:Label>
   </td>
   
    </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
   
    </asp:Repeater>
    </div>
<br />
<iframe id="holdsDoc" runat ="server" width="800px" height ="900px" ></iframe>

</asp:Content>
