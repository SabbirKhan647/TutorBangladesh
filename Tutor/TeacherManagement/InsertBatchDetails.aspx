<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="InsertBatchDetails.aspx.cs" Inherits="Tutor.TeacherManagement.InsertBatchDetails"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A6" href="MyBatchesAsTutor.aspx" runat="server">My Batches </a></li>
            <li><a id="A1" href="CreateBatch.aspx" runat="server">Create Batch</a></li>
            <li><a id="A2" href="InsertBatchDetails.aspx" runat="server">Insert Batch Day/Time </a></li>
            <li><a id="A4" href="EditBatch.aspx" runat="server">Edit Batch </a></li>

             </ul>       
           </div>
           </div>
             <br /><br />
 <h3 class="pageHeading">Insert Batch Day/Time</h3>

        
    <table class="style1" width="400px">
        <tr>
            <td class="style2">

                Select Batch:</td>
            <td>
                     
                <asp:DropDownList ID="DropDownListBatch" runat="server">
                </asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListBatch" ErrorMessage="Please select batch." Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">

        <asp:Label ID="Label11" runat="server" Text="Day" Width="100px"></asp:Label>
                     
            </td>
            <td>
                     
            <asp:DropDownList ID="DropDownListDay" runat="server">
            <asp:ListItem value="Sunday" selected="False"></asp:ListItem>
            <asp:ListItem value="Monday" selected="False"></asp:ListItem>
            <asp:ListItem value="Tuesday" selected="False"></asp:ListItem>
            <asp:ListItem value="Wednesday" selected="False"></asp:ListItem>
            <asp:ListItem value="Thursday" selected="False"></asp:ListItem>
            <asp:ListItem value="Friday" selected="False"></asp:ListItem>
            <asp:ListItem value="Saturday" selected="False"></asp:ListItem>
            </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListDay" ErrorMessage="Please select day." Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
       <asp:Label ID="Label12" runat="server" Text="Start time" Width="100px"></asp:Label>
            </td>
            <td>
       <asp:DropDownList ID="DropDownStTime" runat="server">   </asp:DropDownList>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownStTime" ErrorMessage="Please select time." Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
         <asp:Label ID="Label6" runat="server" Text="End time" Width="100px"></asp:Label>
            </td>
            <td>
         <asp:DropDownList ID="DropDownEndTime" runat="server"> </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownEndTime" ErrorMessage="Please select day." Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
   
    <asp:Button ID="Button1" runat="server" Text="Insert" class="buttonstyle"
        onclick="Button1_Click" />
                <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
   
    <asp:Label ID="lblInsertSuccessfulMsg" runat="server" Text="Label" ForeColor="#009933" Visible ="False" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
   
    <asp:Label ID="lblTimeConflictMsg" runat="server" Text="Label" ForeColor="#009933" Visible ="False" ></asp:Label>
            </td>
        </tr>
    </table>
    <br />
   
    <br />
   
    <asp:Label ID="lblselectedday" runat="server" Text="Label" ForeColor="#009933"  ></asp:Label>
            <br />
   
    <asp:Label ID="lblexistingday" runat="server" Text="Label" ForeColor="#009933"  ></asp:Label>
    <br />
         <br />
    <%-- <span onclick ="return confirm('Are you sure want to create this timing?')">--%>
   
    <br />
    
    <%--</span>--%>
   
   <%--</span>--%>
    <br />
    <br />
</asp:Content>
