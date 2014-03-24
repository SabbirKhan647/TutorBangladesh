<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tutor.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
<%--<script language ="javascript" src="<%# ResolveUrl("~/Scripts/autoimageslider.js") %>" type="text/javascript"></script>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/autoimagechange.js") %>" type="text/javascript"></script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="middle">
<div id="columnA">
<div class="welcome">
       <h3 class="welcome1">Welcome!</h3>
       <p class="welcomeMessage">
       Welcome to Tutoring Management Webportal. This is your gateway to tutoring information and learning activities. </p>
</div>
<div class="ForStudent">
       <h4 style="padding-bottom:10px">Student</h4>
       <ul class="list">
       <li>View available tutor for any subject, any grade, any location</li>
       <li>Form Group or select Private tutor</li>
       <li>Download worksheet</li>
       <li>Submit assignment</li>
       <li>Participate in online quiz</li>
       <li>View timetable </li>
       <li>and more. </li>
       </ul>
 </div>
      <div class="ForTutor">
       <h4 style="padding-bottom:10px">Tutor</h4>
       <ul class="list">
      <li> Manage tutoring</li>
      <li> Create available timing</li>
      <li> Upload contents</li>
       <li>Upload quiz</li>
       <li>Manage Timetable</li>
        <li>Get Email upon student registers</li>
       </ul>
       </div>
   

</div>
<%--<div id="columnB">--%>
<%--auto image change--%>
<%--<div id="fadeshow1"></div>
--%>


<%--<ul id="features">
<li> Select your tutor for any subject, any grade</li>
<li>See availability of batch and then select</li>
<li> Download worksheet from any where</li>
<li> View Grade</li>
<li>Online quiz and instant result helps you evaluate your preparation</li>
<li> Email your teacher and peers</li>
<li>Chat with your teacher and peers</li>
</ul>
--%>
</div>
<div class="availabletutor" >
<p> Available Tutors</p>
<div class="repeaterContainer">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemdatabound="Repeater1_ItemDataBound">
    <HeaderTemplate>
    <%--<table>
    <tr>
    <td>
    </td>
    <td></td>
    <td></td>
    </tr>
    --%>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div class="Horizontal">
   <%--
    <tr>
    <td>--%>
    <asp:HiddenField id="HiddenField1" runat="server" Value='<%#Eval("userid") %>' />
    <%--</td>
    <td>--%>
    
    <table >
    <tr>
    <td class="tabledata">
     <asp:HyperLink ID="a" runat="server" NavigateUrl="~/Default.aspx"><asp:Image ID="tutorImage" runat="server" Width="50px" Height="60px" /></asp:HyperLink>
   </td>
   <%-- </td>
    <td>--%>
    <td class="tabledata1">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("TeacherId","StudentManagement/ViewTutorProfile.aspx?ID={0}") %>'>
     <asp:Label ID="lblTeacherID" runat ="server" Text='<%# Eval("TeacherID") %>'></asp:Label>                   
     <asp:Label ID="lblName" runat ="server" Text='<%# Eval("Name") %>'></asp:Label>                          
    </asp:HyperLink>
    </td>
   <%-- </td>
    </tr>--%>
    </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
    <FooterTemplate>
   <%-- <tr>
    <td>test</td>
    <td></td>
    <td></td>
    </tr>
    </table>--%>
    </FooterTemplate>
    </asp:Repeater>
    </div>
 </div>      


</asp:Content>
