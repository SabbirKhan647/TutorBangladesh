<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="Dropbox.aspx.cs" Inherits="Tutor.StudentManagement.Dropbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type ="text/javascript">
        function showHideMessageDiv() {
            document.getElementById('messageDiv').style.display = "block";
        }
        function closeDiv() {
            if (document.getElementById('closeImage')) {
                document.getElementById('messageDiv').style.display = "none";
            }
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h3 class="pageHeading">Assignments    </h3>
   
   
        <asp:Label ID="Label2" runat="server" Text="Subject:"></asp:Label>
   
    <asp:DropDownList ID="drBatch" runat ="server"></asp:DropDownList>
        <asp:Button ID="DisplayAssignment" runat ="server" 
         Text="Go" CssClass="gap" OnClick="DisplayAssignment_Click" />
        <br />
     
   <div>
    <asp:Label id="noData" runat ="server" Visible ="false" cssClass="NoData" ></asp:Label>

    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" Visible ="false"  >
    <HeaderTemplate>
    <table>
    <tr>
    <td width="400px">Assignments
    </td>
    <td width="100px">
    Start Date
    </td>
    <td width="200px">
    Due Date/Time
    </td>
   
    </tr>
    </table>
    
    </HeaderTemplate>
    <ItemTemplate>
     <div>
   
    
    <table >
    <tr>
 
    <td width="400px" >
    <asp:HiddenField id="HiddenField1" runat="server" Value='<%#Eval("AssignmentID") %>' />
     <asp:LinkButton ID="LBAssgnmtName" runat="server" Text='<%#Eval("Assignmentname") %>' onCommand="LBAssgnmtName_Click"
     CommandName="LBAssgnmtNameClick" CommandArgument='<%# Eval("AssignmentID") %>'>
     </asp:LinkButton>
                                          
     <asp:HiddenField id="HiddenField2" runat="server" Value='<%#Eval("AssgnmtFileName") %>' />
      <asp:Button ID="btnSubmit" runat="server" Text="Submit" onCommand="btnSubmit_Click"
     CommandName="btnSubmitClick" CommandArgument='<%# Eval("AssignmentID") %>'>
     </asp:Button><br />
     <div id="messageDiv">
        <div class="divHeader"><img class="close" id="closeImage" src="../Images/cross.jpg" width="20px" height="20px"alt="close image" title="Close" onclick="javascript:closeDiv();"/></div>
      <asp:FileUpload ID="uploadAssignment" runat ="server" CssClass ="upload"/>
     <asp:Button ID="btnUpload" runat="server" Text="Upload File" onCommand="btnUpload_Click" cssClass="btnupload"
     CommandName="btnUploadClick" CommandArgument='<%# Eval("AssignmentID") %>'></asp:Button><br /><br />
     <asp:Label id="lblMessage" runat ="server" Text="DD" Visible ="false" CssClass ="fileuploadsuccessful"> </asp:Label>
     </div>
    

    </td>
    <td width="100px">
     <asp:Label id="lblTestAvailableDate" runat ="server" Text='<%# Bind("AssgnmtStartDate","{0:yyyy-MM-dd}") %>' ></asp:Label>
    </td>
   <td width="200px">
   <asp:Label id="lbltestExpireDate" runat ="server" Text='<%# Eval("AssgnmtDueDateTime") %>'></asp:Label>
   
   </td>
    </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
   
    </asp:Repeater>
    </div>
     <br />
 <asp:Label ID="showdata" runat ="server" Text="dd"></asp:Label>   
<iframe id="holdsDoc" runat ="server" width="800px" height ="900px" visible="false" ></iframe>
</asp:Content>
