<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="Tutor.test2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat ="server"></asp:ScriptManager>
        <cc1:Editor ID="Editor1" Width="450px" Height="200px" InitialCleanUp ="true"
            runat="server" />
       
       <br />
       <asp:Button ID="btnSubmit" Text ="Submit" runat ="server" 
            onclick="btnSubmit_Click" />
       <asp:Literal ID="ltlResult" runat ="server" ></asp:Literal>

      
    </div>
    </form>
</body>
</html>
