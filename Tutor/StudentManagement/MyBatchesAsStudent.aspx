<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="MyBatchesAsStudent.aspx.cs" Inherits="Tutor.StudentManagement.MyBatchesAsStudent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
    <script src="<%# ResolveUrl("~/Scripts/CollapsableGridview.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function showHideMessageDiv() {
            document.getElementById('messageDiv').style.display = "block";
        }
        function closeDiv() {
            if ((document.getElementById('closeImage'))||(document.getElementById('btnOK'))) {
                document.getElementById('messageDiv').style.display = "none";
            }
        }
    </script>

    <style type="text/css">
    /*body
    {
        font-family: Arial;
        font-size: 10pt;
    }*/
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.4;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        width: 400px;
        border: 3px solid #0DA9D0;
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
     .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: left;
        font-weight: bold;
        padding-left :15px;
        padding-right :15px;
    }
    .modalPopup .footer
    {
        padding: 3px;
    }
    .modalPopup .yes, .modalPopup .no
    {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        margin-top :35px;
        margin-bottom :35px;
        
    }
    .modalPopup .yes
    {
        background-color: #2FBDF1;
        border: 1px solid #0DA9D0;
         margin-left :275px;
    }
    .modalPopup .no
    {
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }
    /* Grid View Pager style
        --------------------------*/
       .GridPager a, .GridPager span
    {
        display: block;
        height: 15px;
        width: 15px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #d9d9ff;
        color: #000;
        border: 1px solid #3AC0F2;
    }
     .EmptyGrid {
        text-align: center;font-size: 15px;font-family: Verdana;color :#bd1313;font-weight:bold ;
    }
     /*.btnOK {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        background-color: #2FBDF1;
        border: 1px solid #0DA9D0;
        left:230px;
        margin-top :30px;
        }*/
/*#messageDiv {
min-width:500px;
min-height :200px;
z-index :3;
position :absolute ;
top:250px;
left:330px;
background-color :#FFFFFF;
display :none;
padding-top: 25px;
margin-top:5px;
margin-bottom :10px;
border: 3px solid #0DA9D0;
}
.divHeader {
    min-width: 500px;
    height: 30px;
    z-index: 3;
    position: absolute;
    top: 0px;
    left: 0px;
    background-color:#2FBDF1;
    color: White;
    text-align: center;
    font-weight: bold;
    line-height: 30px;
}
.close {
    position :absolute ;
    right :5px;
    top:0px;
   
}
.message {
    padding-top: 25px;
    padding-left :15px;
    padding-right :15px;
    font-size: medium;
    position :inherit ;
    margin-top:5px;
   }
.message-label {
    font-weight :bold;
}*/
   
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="menubar1">
        <div class="menupublic1">
            <ul id="navmenu1">
                <li><a id="A2" href="MyBatchesAsStudent.aspx" runat="server">My Batches</a></li>

                <li><a id="A1" href="BuildBatch1.aspx" runat="server">Build Batch</a></li>

            </ul>
        </div>
    </div>

    <br />
 <%--   <h3 class="pageHeading">My Batches    </h3>--%>
      <div class="formTitle">
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: left;">
                      <span class="titleText">My Batches</span>
                    </td>
                    <td style="text-align: right;"><span class="round-button">Help</span></td>
                </tr>
            </table>
        </div>
 
    <br />
        <ajaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolKit:ToolkitScriptManager>
 
    <asp:GridView ID="gvBatch" runat="server"  CssClass="Grid" 
    DataKeyNames="BatchID" 
    AutoGenerateColumns="false" 
    AllowPaging="true" 
    OnRowCommand="gvBatch_RowCommand" 
    OnRowDataBound ="gvBatch_RowDataBound"
          EmptyDataText="No batch is joined at this moment." >
           
         
           <PagerStyle HorizontalAlign = "Right" CssClass = "GridPager" />
          <EmptyDataRowStyle CssClass = "EmptyGrid"/>
        <Columns>

            <asp:TemplateField>
                <ItemTemplate>

                    <img alt="" style="cursor: pointer" src="../Images/plus.gif" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvBatchDetails" runat="server"  CssClass="ChildGrid" 
                            AutoGenerateColumns="false"  >
                            <Columns>
                                <asp:BoundField DataField="BatchID" HeaderText="Batch ID"  Visible ="false" />
                                <asp:BoundField HeaderText="Day" DataField="dayName" ItemStyle-Width="5%" />
                                <asp:BoundField HeaderText="Start Time" DataField="starttime" ItemStyle-Width="5%" />
                                <asp:BoundField HeaderText="End Time" DataField="endtime" ItemStyle-Width="5%" />
                              <%--  <asp:BoundField HeaderText="Duration" DataField="duration" ItemStyle-Width="5%" />--%>

                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="BatchID" HeaderText="Batch ID" visible="false"   />
              <asp:BoundField DataField="batchname" HeaderText="Batch" ItemStyle-Width="28%" >
                
            </asp:BoundField>
            <asp:BoundField DataField="StudentID" HeaderText="ID" />
            <asp:BoundField DataField="StudentName" HeaderText="Name" />              
            <asp:BoundField DataField="TutorName" HeaderText="Tutor" />
            <asp:BoundField DataField="dateJoined" HeaderText="Joined" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="startdate" HeaderText="Starts" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="enddate" HeaderText="Ends" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:TemplateField >
                  <ItemTemplate>
                     <asp:LinkButton ID="linkbtnWithdraw" CommandArgument='<%# Eval("BatchID")  %>' CommandName="Withdraw"  CssClass="round-button round-button-blue"
                        runat="server" Text="Withdraw"></asp:LinkButton>
    
                    <asp:Button id="dummyButton" runat="server" style="display:none;" />             
                                            
                    <ajaxToolKit:ConfirmButtonExtender ID="cbe" runat="server" DisplayModalPopupID="mpe" TargetControlID="dummyButton">
                    </ajaxToolKit:ConfirmButtonExtender>
                    <ajaxToolKit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="dummyButton" DropShadow="true"
                       CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                    </ajaxToolKit:ModalPopupExtender>
                                      

                    <%--this is the modal popup for the delete confirmation--%>
                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none" >
                        <div class="header">
                            Confirmation
                         </div>
                        <div class="body"><br />
                              <asp:Label ID="lblTextPrompt" runat="server" Text="Yo yo yo!!!"></asp:Label><br />
                        
                             <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" OnClick="btn_OK_Click" CommandArgument='<%# Eval("BatchID")  %>' />
                            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
                        </div>
                 
                    </asp:Panel>
             
                      
                       </ItemTemplate>
            </asp:TemplateField>
         
        </Columns>
    </asp:GridView>
 
       <br /><br /> <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" CssClass="message"></asp:Label>
 

    <asp:Label ID="diff" runat="server" Text="label2"></asp:Label>
</asp:Content>
