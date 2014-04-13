<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxTimer.aspx.cs" Inherits="Tutor.AjaxTimer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <script type ="text/javascript">
    function startTime() {
        var dt = new Date();
        var time=dt.toLocaleTimeString();
        document.getElementById('hiddenfield1').value = time;
//        var today = new Date();
//        var h = today.getHours();
//        var m = today.getMinutes();
//        var s = today.getSeconds();
//        // add a zero in front of numbers<10
//        m = checkTime(m);
//        s = checkTime(s);
//        //   document.getElementById('txt').innerHTML = h + ":" + m + ":" + s;
//        var time = h + ":" + m + ":" + s;
//        document.getElementById('txt').innerHTML = time;
//      //  setInterval('startTime()', 1000);
//           //    t = setTimeout(function () { startTime() }, 50000);
//               //t = setTimeoutstartTime(),5000);
          //     window.setTimeout('startTime()',1000);
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField ID="hiddenfield1" runat ="server" ClientIDMode ="Static" />
    <asp:ScriptManager ID="ScriptManager1" runat ="server" ></asp:ScriptManager>
    <asp:Timer ID="TimerTime" runat ="server" Interval ="1000"></asp:Timer>
    <asp:UpdatePanel ID="updatePanel1" runat ="server" >
    <ContentTemplate >
    <asp:Label ID="lblDateToDay" runat ="server" ></asp:Label>
    <asp:Label ID="lblTime" runat ="server" ></asp:Label>
    </ContentTemplate>
    <Triggers>
   <asp:AsyncPostBackTrigger ControlID="TimerTime" EventName="Tick" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
