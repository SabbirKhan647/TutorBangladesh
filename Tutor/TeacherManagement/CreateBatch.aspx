<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="CreateBatch.aspx.cs" Inherits="Tutor.TeacherManagement.CreateBatch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery-latest.js") %>" type="text/javascript"></script>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/HighlightCurrentMenuItem.js") %>" type="text/javascript"></script>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/currentDate.js") %>" type="text/javascript"></script>
<%--<script type = "text/javascript">
    function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("Please log in")) {
            confirm_value.value = "OK";
        } 
        document.forms[0].appendChild(confirm_value);
    }
    </script>--%>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 148px;
        }
    </style>

 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="CreateBatch.aspx" runat="server">Create Batch</a></li>
            <li><a id="A2" href="InsertBatchDetails.aspx" runat="server">Insert Batch Day/Time </a></li>
            <li><a id="A6" href="MyBatchesAsTutor.aspx" runat="server">My Batches </a></li>
            <li><a id="A4" href="EditBatch.aspx" runat="server">Edit Batch </a></li>
             </ul>       
           </div>
           </div>
<%--<div class="sideNavigation">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherManagement/CreateBatch.aspx">Create Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl ="#">Delete Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Switch Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl ="#">Delete Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl ="~/TeacherManagement/RefreshBatch.aspx">Refresh Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl ="#">Enroll Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl ="#">Change Batch Time</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/TeacherManagement/MyBatchesforTutor.aspx">My Batches</asp:HyperLink>
 </div>--%>
    <div>
    <br />
 <h3 class="pageHeading">Create Batch</h3>
        <table class="style1" width="400px">
            <tr>
                <td class="style2">
     <asp:Label ID="Label1" runat="server" Text="Select subject" 
            style="position :relative " Width="100px" ></asp:Label>
                </td>
                <td>
      <asp:DropDownList ID="DropDownListSubject" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
       <asp:Label ID="Label10" runat="server" Text="Select grade" Width="100px"></asp:Label>
                </td>
                <td>
      <asp:DropDownList ID="DropDownListGrade" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
       <asp:Label ID="Label7" runat="server" Text="Maximum student" Width="150px"></asp:Label>
                </td>
                <td>
          <asp:DropDownList ID="DropDownNoOfStu" runat="server">   
                 </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="Label9" runat="server" Text="Start Date" Width="100px"></asp:Label>
                </td>
                <td>
      
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
    <asp:CalendarExtender ID="CalenderExtender1" runat="server" 
        TargetControlID="txtStartDate">
    </asp:CalendarExtender>
    <br />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
         <span onclick ="return confirm('Are you sure you want to create this batch?')">
         <asp:Button ID="BtnGenerate" runat="server" Text="Create Batch" 
                     onclick="BtnGenerate_Click" style="height: 29px" 
                        onclientclick="currentdate();" /> 
        </span>
                </td>
            </tr>
        </table>
        
         <span onclick ="return confirm('Are you sure you want to create this batch?')">
         <br /> 
        </span>
        <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="#009933"></asp:Label><br />
        <asp:Label ID="Label11" runat="server" Text="Label" Font-Bold="True" 
            ForeColor="#009933" Visible="False"></asp:Label>
        
    </div>
   
   
  
    <br />
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
    <asp:HyperLink ID="HyperLink8" runat="server" ForeColor="#3333FF" 
        NavigateUrl ="~/TeacherManagement/InsertBatchDetails.aspx" Enabled="true" 
        ToolTip="Please create batch first and then this link will be enabled">Click here to enter Day and Time for the batch</asp:HyperLink>
    <br />
    
</asp:Content>
