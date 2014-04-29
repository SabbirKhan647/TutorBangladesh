<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tutor.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
        If you don't have an account, click here for&nbsp; <a href="Register.aspx">
        Registration </a>&nbsp;&nbsp; <%--<a href="TeacherRegistration.aspx">
        Teacher Registration</a> or <a href="StudentRegistration.aspx">Student 
        Registration</a><div> </div>--%>
        <asp:Login ID="Login1" runat="server" 
            PasswordRecoveryText="Forgot your password?" 
            onauthenticate="Login1_Authenticate" onloggedin="Login1_LoggedIn" DestinationPageUrl="~/Student/myTutor.aspx"   
          >
            <LoginButtonStyle CssClass="buttonstyle" />
        </asp:Login>
    </p>
  
   
</asp:Content>
