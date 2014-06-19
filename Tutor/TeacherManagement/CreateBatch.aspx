 <%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="CreateBatch.aspx.cs" Inherits="Tutor.TeacherManagement.CreateBatch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>New Batch</title>
    <script language="javascript" src="<%# ResolveUrl("~/Scripts/jquery-latest.js") %>" type="text/javascript"></script>
    <script language="javascript" src="<%# ResolveUrl("~/Scripts/HighlightCurrentMenuItem.js") %>" type="text/javascript"></script>
    <script language="javascript" src="<%# ResolveUrl("~/Scripts/currentDate.js") %>" type="text/javascript"></script>
    <%-- <asp:HyperLink ID="HyperLink8" runat="server" ForeColor="#3333FF"
        NavigateUrl="~/TeacherManagement/InsertBatchDetails.aspx" Enabled="true"
        ToolTip="Please create batch first and then this link will be enabled">Click here to enter Day and Time for the batch

    </asp:HyperLink>--%>
 
    <style type="text/css">
        .style2 {
            width: 148px;
        }

        </style>
  
   <script type ="text/javascript" >
       // javascript to add to your aspx page
       function ValidateDayList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 0; i < chkListinputs.length; i++) {
               if (chkListinputs[i].checked) {
                   args.IsValid = true;
                   return;
               }
           }
           args.IsValid = false;
       }

       // javascript function to check time dropdownlist validation
       function ValidateSatStTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 0; i < 1; i++) {
               if (chkListinputs[0].checked) {
                   if (document.getElementById('ddlSaturdayStTime').value != "")//if dropdown list is selected
                   {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;

                   }

               }
           }
           //  args.IsValid = false;
       }
       function ValidateSatEndTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 0; i < 1; i++) {
               if (chkListinputs[0].checked) {
                   if (document.getElementById('ddlSaturdayEndTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;

                   }
               }
           }
           //  args.IsValid = false;
       }
       function ValidateSunStTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 1; i < 2; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlSundayStTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }


               }
           }
           // args.IsValid = false;
       }
       function ValidateSunEndTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 1; i < 2; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlSundayEndTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }
               }
           }
           // args.IsValid = false;
       }
       function ValidateMonStTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 2; i < 3; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlMondayStTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }

               }
           }
           // args.IsValid = false;
       }
       function ValidateMonEndTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 2; i < 3; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlMondayEndTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }
               }
           }
           // args.IsValid = false;
       }
       function ValidateTuesStTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 3; i < 4; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlTuesdayStTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }

               }
           }
           // args.IsValid = false;
       }
       function ValidateTuesEndTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 3; i < 4; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlTuesdayEndTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }

               }
           }
           // args.IsValid = false;
       }
       function ValidateWedStTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 4; i < 5; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlWednesdayStTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }

               }
           }
           // args.IsValid = false;
       }
       function ValidateWedEndTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 4; i < 5; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlWednesdayEndTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }

               }
           }
           // args.IsValid = false;
       }
       function ValidateThuStTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 5; i < 6; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlThursdayStTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }

               }
           }
           // args.IsValid = false;
       }
       function ValidateThuEndTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 5; i < 6; i++) {
               if (chkListinputs[i].checked) {
                   if (document.getElementById('ddlThursdayEndTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }
               }
           }
           // args.IsValid = false;
       }


       function ValidateFriStTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 6; i < 7; i++) {
               if (chkListinputs[i].checked) {

                   if (document.getElementById('ddlFridayStTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }

               }
           }
           // args.IsValid = false;
       }
       function ValidateFriEndTimeList(source, args) {
           var chkListDays = document.getElementById('chkListBoxDay');
           var chkListinputs = chkListDays.getElementsByTagName("input");
           for (var i = 6; i < 7; i++) {
               if (chkListinputs[i].checked) {
                   if (document.getElementById('ddlFridayEndTime').value != "") {
                       args.IsValid = true;
                       return;
                   }
                   else {
                       args.IsValid = false;
                       return;
                   }


               }
           }
           // args.IsValid = false;
       }
       function DisplayTimeConflictSat() {


           document.getElementById("lblTimeConflictSat").innerHTML = "Time conflict on Saturday. Select another day/time";
           document.getElementById('lblTimeConflictSat').style.display = 'block'
           document.getElementById('divTimeConflictSat').style.display = 'block'


           return false;
       }
       function DisplayTimeConflictSun() {


           document.getElementById("lblTimeConflictSun").innerHTML = "Time conflict on Sunday. Select another day/time";
           document.getElementById('lblTimeConflictSun').style.display = 'block'
           document.getElementById('divTimeConflictSun').style.display = 'block'


           return false;
       }
        </script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="menubar1">
        <div class="menupublic1">
            <ul id="navmenu1">
                <li><a id="A6" href="MyBatchesAsTutor.aspx" runat="server">My Batches </a></li>
                <li><a id="A1" href="CreateBatch.aspx" runat="server">New Batch</a></li>
               <%-- <li><a id="A2" href="InsertBatchDetails.aspx" runat="server">Insert Batch Day/Time </a></li>
                <li><a id="A4" href="EditBatch.aspx" runat="server">Edit Batch </a></li>--%>
    <%--  </ul>
        </div>
    </div>--%>
    <%-- <asp:HyperLink ID="HyperLink8" runat="server" ForeColor="#3333FF"
        NavigateUrl="~/TeacherManagement/InsertBatchDetails.aspx" Enabled="true"
        ToolTip="Please create batch first and then this link will be enabled">Click here to enter Day and Time for the batch

    </asp:HyperLink>--%>


    <%--    <h3 class="pageHeading">Create Batch</h3>--%>

    <%--layout from shawmi bhai--%>
    <div class="inputFormContainer">
        <div class="formTitle">
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: left;">
                        <asp:Label ID="frmTitle" runat="server" Visible="false" class="titleText">New Batch</asp:Label>
                        <asp:Label ID="frmTitle1" runat="server" Visible="false" class="titleText">Update Batch</asp:Label>
                    </td>
                    <td style="text-align: right;"><span class="round-button">Help</span></td>
                </tr>
            </table>
        </div>

        <asp:Panel runat="server" ID="MessagePanel" class="formMessagDiv" Visible="false" ClientIDMode="Static">
            <div>
                <asp:Label ID="lblBatchCreationUpdateMsg" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblBatchName" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTimeConflictSat" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblSmallEndTimeSat" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblSmallEndTimeSun" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblSmallEndTimeTues" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblSmallEndTimeWed" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblSmallEndTimeThu" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblSmallEndTimeFri" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTimeConflictSun" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTimeConflictMon" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTimeConflictTues" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTimeConflictWed" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTimeConflictThu" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
            <asp:Label ID="lblTimeConflictFri" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            <div>
                <asp:Label ID="lblSmallEndTimeMon" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
        </asp:Panel>
 
        <div class="formFields">
            <table style="width: 100%;">
                <tr>
                    <td style="vertical-align: top; width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 70%;">
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="Label5" runat="server" Text="Subject:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <asp:DropDownList ID="DropDownListSubject" runat="server" class="input-box-rounded" Font-Names="Verdana" ></asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic" ControlToValidate="DropDownListSubject" ErrorMessage="Please select subject." Font-Bold="True" Font-Size="Smaller" ForeColor="IndianRed"></asp:RequiredFieldValidator>
                                        <%--   <input name="participantid" type="text" id="participantid" class="input-box-rounded" size="30" value="00000" disabled="disabled" />--%>
                                    </div>
                                </td>
                                <td style="width: 29%;">
                                    <div style="width: 300px; min-height: 200px; background-color: #F6F6FF; font-size: 15px; top: 150px; z-index: 3; position: absolute; top: 170px; right: 230px;">
                                        <div style="padding: 5px 5px; border-bottom: 1px solid #dddddd; text-align :center "><span >Quick Help</span></div>
                                        <div style="padding: 5px 8px 5px 5px;line-height :25px;">
                                            <ul><li style="list-style-type :square;">	Check off chosen day(s). Select the start time and the end time underneath the day selected.</li>
                                                <li style="list-style-type :square;">	Batch would not be created if time conflicts with <b>active batches</b></li>
                                            </ul></div>
                                    </div>
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="Label6" runat="server" class="input-label-rounded" Text="Grade:"></asp:Label>
                                        </div>

                                        <asp:DropDownList ID="DropDownListGrade" runat="server" class="input-box-rounded" Font-Names="Verdana" ></asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownListGrade" ErrorMessage="Please select grade." Font-Bold="True" Font-Size="Smaller" Display="Dynamic" ForeColor="IndianRed"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="Label8" runat="server" Text="Max Student:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <asp:DropDownList ID="DropDownNoOfStu" runat="server" class="input-box-rounded"></asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownNoOfStu" ErrorMessage="Please select student." Display="Dynamic" Font-Bold="True" Font-Size="Smaller" ForeColor="IndianRed"></asp:RequiredFieldValidator>

                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="Label12" runat="server" Text="Start Date:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
                                        </asp:ToolkitScriptManager>
                                        <asp:TextBox ID="txtStartDate" runat="server" class="input-box-rounded" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox><br />
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                            TargetControlID="txtStartDate">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtStartDate" ErrorMessage="Please select date." Font-Bold="True" Font-Size="Smaller" ForeColor="IndianRed"></asp:RequiredFieldValidator>

                                    </div>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="Label1" runat="server" Text="End Date:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </asp:ToolkitScriptManager>--%>
                                        <asp:TextBox ID="txtEndDate" runat="server" class="input-box-rounded"></asp:TextBox><br />
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                            TargetControlID="txtEndDate">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtEndDate"
                                             ErrorMessage="Please select date." Font-Bold="True" Font-Size="Smaller" ForeColor="IndianRed"></asp:RequiredFieldValidator>
                                         <asp:CompareValidator ID="CompareValidator1" ValidationGroup = "Date" Display="Dynamic" runat="server" 
                                             ControlToValidate = "txtEndDate" ControlToCompare = "txtStartDate" Operator="LessThanEqual" Type = "Date" 
                                             Font-Bold="True" Font-Size="Smaller" ForeColor="IndianRed" 
                                             ErrorMessage="End date must be bigger than Start date."></asp:CompareValidator>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 100%;">
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="Label13" runat="server" Text="Day:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:CheckBoxList ID="chkListBoxDay" runat="server" RepeatDirection="Horizontal" ClientIDMode ="Static"  Width="700px">
                                                <asp:ListItem>Saturday</asp:ListItem>
                                                <asp:ListItem>Sunday</asp:ListItem>
                                                <asp:ListItem>Monday</asp:ListItem>
                                                <asp:ListItem>Tuesday</asp:ListItem>
                                                <asp:ListItem>Wednesday</asp:ListItem>
                                                <asp:ListItem>Thursday</asp:ListItem>
                                                <asp:ListItem>Friday</asp:ListItem>

                                            </asp:CheckBoxList>
                                           <asp:CustomValidator runat="server" ID="cvdaylist" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateDayList"
                                                ErrorMessage="Please select atleast one day and time"></asp:CustomValidator>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%;">
                                    <div class="input-container" style="margin-top: 10px;">
                                        <div class="input_label user">
                                            <asp:Label ID="Label14" runat="server" Text="Start Time:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlSaturdayStTime" runat="server" Style="height: 34px;" ClientIDMode ="Static" ></asp:DropDownList>
                                               <asp:CustomValidator runat="server" ID="CustomValidator1" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateSatStTimeList"
                                                ErrorMessage="Please select Saturday start time"></asp:CustomValidator>

                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlSundayStTime" ClientIDMode ="Static" runat="server" Style="height: 34px;" OnSelectedIndexChanged="ddlSundayStTime_SelectedIndexChanged"></asp:DropDownList>
                                             <asp:CustomValidator runat="server" ID="CustomValidator2" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateSunStTimeList"
                                                ErrorMessage="Please select Sunday start time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlMondayStTime" ClientIDMode ="Static" runat="server" Style="height: 34px;"></asp:DropDownList>
                                            <asp:CustomValidator runat="server" ID="CustomValidator3" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateMonStTimeList"
                                                ErrorMessage="Please select Monday start time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlTuesdayStTime" ClientIDMode ="Static" runat="server" Style="height: 34px;"></asp:DropDownList>
                                              <asp:CustomValidator runat="server" ID="CustomValidator4" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction=" ValidateTuesStTimeList"
                                                ErrorMessage="Please select Tuesday start time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlWednesdayStTime" ClientIDMode ="Static" runat="server" Style="height: 34px;"></asp:DropDownList>
                                               <asp:CustomValidator runat="server" ID="CustomValidator5" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateWedStTimeList"
                                                ErrorMessage="Please select Wednesday start time"></asp:CustomValidator> 
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlThursdayStTime" ClientIDMode ="Static" runat="server" Style="height: 34px;"></asp:DropDownList>
                                                <asp:CustomValidator runat="server" ID="CustomValidator6" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateThuStTimeList"
                                                ErrorMessage="Please select Thursday start time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlFridayStTime"  ClientIDMode ="Static" runat="server" Style="height: 34px;"></asp:DropDownList>
                                              <asp:CustomValidator runat="server" ID="CustomValidator7" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateFriStTimeList"
                                                ErrorMessage="Please select Friday start time"></asp:CustomValidator>
                                            </div>

                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%;">
                                    <div class="input-container" style="margin-top: 10px;">
                                        <div class="input_label user">
                                            <asp:Label ID="Label15" runat="server" Text="End Time:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlSaturdayEndTime" runat="server" ClientIDMode ="Static" Style="height: 34px;"></asp:DropDownList>
                                                <asp:CustomValidator runat="server" ID="CustomValidator8" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateSatEndTimeList"
                                                ErrorMessage="Please select Saturday End time"></asp:CustomValidator>

                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlSundayEndTime" runat="server" ClientIDMode ="Static" Style="height: 34px;"></asp:DropDownList>
                                            <asp:CustomValidator runat="server" ID="CustomValidator9" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateSunEndTimeList"
                                                ErrorMessage="Please select Sunday end time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlMondayEndTime" runat="server" ClientIDMode ="Static" Style="height: 34px;"></asp:DropDownList>
                                              <asp:CustomValidator runat="server" ID="CustomValidator10" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateMonEndTimeList"
                                                ErrorMessage="Please select Monday end time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlTuesdayEndTime" runat="server" ClientIDMode ="Static" Style="height: 34px;"></asp:DropDownList>
                                              <asp:CustomValidator runat="server" ID="CustomValidator11" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction=" ValidateTuesEndTimeList"
                                                ErrorMessage="Please select Tuesday end time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlWednesdayEndTime" runat="server"  ClientIDMode ="Static" Style="height: 34px;"></asp:DropDownList>
                                               <asp:CustomValidator runat="server" ID="CustomValidator12" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateWedEndTimeList"
                                                ErrorMessage="Please select Wednesday end time"></asp:CustomValidator> 
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlThursdayEndTime" runat="server" ClientIDMode ="Static" Style="height: 34px;"></asp:DropDownList>
                                             <asp:CustomValidator runat="server" ID="CustomValidator13" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateThuEndTimeList"
                                                ErrorMessage="Please select Thursday end time"></asp:CustomValidator>
                                            </div>
                                            <div class="user" style="width: 100px">
                                                <asp:DropDownList ID="ddlFridayEndTime" runat="server" ClientIDMode ="Static" Style="height: 34px;"></asp:DropDownList>
                                           <asp:CustomValidator runat="server" ID="CustomValidator14" Display="Dynamic" Font-Size="Smaller" ForeColor="IndianRed" Font-Bold="true" 
                                                ClientValidationFunction="ValidateFriEndTimeList"
                                                ErrorMessage="Please select Friday end time"></asp:CustomValidator>
                                            </div>
                                        </div>

                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <%-- <div class="input_label user">--%>
                                        <%--  <asp:Label ID="Label16" runat="server" Text="Maximum student" class="input-label-rounded" Visible ="false" ></asp:Label>--%>
                                        <%-- </div>--%>

                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="buttonstyle" OnClick="btnCancel_Click"
                                            OnClientClick="javascript:history.go(-1)" />
                                        <asp:Button ID="BtnGenerate" runat="server" Text="Create Batch" Visible="false" class="buttonstyle" OnClick="BtnGenerate_Click" />
                                        <asp:Button ID="BtnUpdateBatch" runat="server" Text="Update Batch" Visible="false" class="buttonstyle" OnClick="BtnUpdateBatch_Click" />


                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <%--<div class="input_label user">--%>
                                        <%-- <asp:Label ID="Label11" runat="server" Text="Maximum student" class="input-label-rounded" Visible ="false" ></asp:Label>--%>
                                        <%--</div>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <%--<div class="input_label user">--%>
                                        <%-- <asp:Label ID="Label3" runat="server" Text="Maximum student" class="input-label-rounded" Visible ="false" ></asp:Label>--%>
                                        <%--</div>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <%-- <div class="input_label user">--%>
                                        <%-- <asp:Label ID="Label3" runat="server" Text="Maximum student" class="input-label-rounded" Visible ="false" ></asp:Label>--%>
                                        <%--</div>--%>
                                    <div class="input-container">
                                        <%-- <div class="input_label user">--%>
                                        <%-- <asp:Label ID="Label3" runat="server" Text="Maximum student" class="input-label-rounded" Visible ="false" ></asp:Label>--%>
                                        <%--</div>--%>
                                    </div>
                                    </div>
                                </td>
                            </tr>                         
                      </table>

                    </td>

                    <%-- <td style="width: 19%;"> </td>--%>
                </tr>

            </table>

        </div>

   <%-- </div>--%>
    <%-- <div style="width: 200px; height: 200px; background-color: #ecf95f; font-size: 12px; top: 150px; z-index :3; position: absolute;top:160px;right:150px;">
                                        <div style="padding: 10px 5px; border-bottom: 1px solid #dddddd;"><span>Quick Help</span></div>
                                        <div style="padding: 10px 5px;"><span>Test Words</span></div>
                                    </div>--%>
    <%--layout end--%>
































































    <%--  <table class="style1" width="400px">

            <tr>
                <td class="auto-style1">
                    <div class="input-container">
                        <div class="input_label user">
                            <asp:Label ID="Label1" runat="server" Text="Select subject" class="input-label-rounded"
                                Style="position: relative" Width="100px"></asp:Label>
                        </div>

                        <asp:DropDownList ID="DropDownListSubject1" runat="server" class="input-box-rounded"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListSubject" ErrorMessage="Please select subject." Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label10" runat="server" Text="Select grade" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListGrade1" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListGrade" ErrorMessage="Please select subject." Font-Bold="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="Maximum student" Width="150px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownNoOfStu1" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="DropDownNoOfStu" ErrorMessage="Please select grade." Font-Bold="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label9" runat="server" Text="Start Date" Width="100px"></asp:Label>
                </td>
                <td>

                    <%--                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>--%>
    <%--   <asp:TextBox ID="txtStartDate1" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalenderExtender1" runat="server"
                        TargetControlID="txtStartDate">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Please select date." Font-Bold="True"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <%--<tr>
                <td class="auto-style1">Status</td>
                <td>
                    <asp:DropDownList ID="DrStatusID" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>--%>
    <%-- <tr>
                <td class="auto-style1">Day</td>
                <td>
                    <asp:CheckBoxList ID="chkListBoxDay1" runat="server" RepeatDirection="Horizontal" Width="700px">
                        <asp:ListItem>Saturday</asp:ListItem>
                        <asp:ListItem>Sunday</asp:ListItem>
                        <asp:ListItem>Monday</asp:ListItem>
                        <asp:ListItem>Tuesday</asp:ListItem>
                        <asp:ListItem>Wednesday</asp:ListItem>
                        <asp:ListItem>Thursday</asp:ListItem>
                        <asp:ListItem>Friday</asp:ListItem>

                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Start Time</td>
                <td>
                    <table class="starttimetable">
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListDay11" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListDay21" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListDay31" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListDay41" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListDay51" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListDay61" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListDay71" runat="server"></asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">End Time</td>
                <td>
                    <table class="starttimetable">
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListEndTime11" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListEndTime21" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListEndTime31" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListEndTime41" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListEndTime51" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListEndTime61" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr class="starttime">
                            <td>
                                <asp:DropDownList ID="DropDownListEndTime71" runat="server"></asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>

                <td class="auto-style2"></td>
                <td colspan="8" class="auto-style3">
                    <asp:Button ID="BtnGenerate1" runat="server" Text="Create Batch" class="buttonstyle"
                        OnClick="BtnGenerate_Click" Style="height: 29px"
                        OnClientClick="currentdate();" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">
                    <asp:Label ID="Label21" runat="server" Text="Label" ForeColor="#009933"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">
                    <asp:Label ID="Label111" runat="server" Text="Label" Font-Bold="True"
                        ForeColor="#009933" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">
                    <asp:Label ID="Label31" runat="server" Text="Label" Font-Bold="True"
                        ForeColor="#009933" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">
                    <asp:Label ID="Label41" runat="server" Text="Label" Font-Bold="True"
                        ForeColor="#009933" Visible="False"></asp:Label>

                </td>
            </tr>--%>
    <%-- <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
               
            </tr>
            <tr>
                <td class="auto-style1">Start time</td>
                <tr>
               
             
                <td class="auto-style4">
                    <asp:DropDownList ID="DrSaturdayStTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrSundayStTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrMondayStTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrTuesdayStTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrWednesdayStTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrThursdayStTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DrFridayStTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                  
            </tr>
            <tr>
                <td class="auto-style1">End Time</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DrSaturdayEndTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrSundayEndTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrMondayEndTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrTuesdayEndTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrWedEndTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DrThursEndTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DrFriEndTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td colspan="8" class="auto-style3">
                    <asp:Button ID="BtnGenerate" runat="server" Text="Create Batch" class="buttonstyle"
                        OnClick="BtnGenerate_Click" Style="height: 29px"
                        OnClientClick="currentdate();" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">
                    <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="#009933"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">
                    <asp:Label ID="Label11" runat="server" Text="Label" Font-Bold="True"
                        ForeColor="#009933" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="8">&nbsp;</td>
            </tr>--%>
    <%--  </table>
    </div>
    </div>
        <%--  <span onclick="return confirm('Are you sure you want to create this batch?')">--%>
    <%--      <br />
        </span>--%>
    <%--  <br />

    </div>

    --%>

    <br />
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdPrevURL" runat="server" />
    <%-- <asp:HyperLink ID="HyperLink8" runat="server" ForeColor="#3333FF"
        NavigateUrl="~/TeacherManagement/InsertBatchDetails.aspx" Enabled="true"
        ToolTip="Please create batch first and then this link will be enabled">Click here to enter Day and Time for the batch

    </asp:HyperLink>--%>
    <br />

</asp:Content>
