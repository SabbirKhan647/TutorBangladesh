<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="BuildBatch1.aspx.cs" Inherits="Tutor.StudentManagement.BuildBatch1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
    <script src="<%# ResolveUrl("~/Scripts/CollapsableGridview.js") %>" type="text/javascript"></script>
    <script src="<%# ResolveUrl("~/Scripts/currentDate.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function showHideMessageDiv() {
            document.getElementById('messageDiv').style.display = "block";
        }
        function closeDiv() {
            if (document.getElementById('closeImage')) {
                document.getElementById('messageDiv').style.display = "none";
            }
        }
    </script>
<style type ="text/css" >
       /*  modal pop up
        ------------------------*/
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
        text-align: center ;
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
    /*.close {
    position :absolute ;
    right :0px;
    top:0px;
   
}*/
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
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="menubar1">
        <div class="menupublic1">
            <ul id="navmenu1">
                <li><a id="A2" href="MyBatchesAsStudent.aspx" runat="server">My Batches</a></li>

                <li><a id="A1" href="BuildBatch1.aspx" runat="server">Join Batch</a></li>

            </ul>
        </div>
    </div>

    <br />
  <%--  <h3 class="pageHeading">Build Batch</h3>--%>
    <div class="inputFormContainer">
      <div class="formTitle">
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: left;">
                      <span class="titleText">Join Batch</span>
                    </td>
                    <td style="text-align: right;"><span class="round-button">Help</span></td>
                </tr>
            </table>
        </div>
     <div class="formFields">
            <table style="width: 100%;">
                <tr>
                    <td style="vertical-align: top; width: 70%;">
                       <%-- <table style="width: 100%;">
                            <tr>
                                <td style="width: 70%;">--%>
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="Label5" runat="server" Text=" Subject:" class="input-label-rounded"></asp:Label>
                                        </div>
                                        <asp:DropDownList ID="DropDownSub" runat="server" class="input-box-rounded" Font-Names="Verdana" Font-Size="Medium"></asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic" ControlToValidate="DropDownSub" ErrorMessage="Please select subject." Font-Bold="True" Font-Size="Smaller" ForeColor="IndianRed"></asp:RequiredFieldValidator>
                                        <%--   <input name="participantid" type="text" id="participantid" class="input-box-rounded" size="30" value="00000" disabled="disabled" />--%>
                                    </div>
                                </td>
                                <td style="width: 29%;">
                                    <div style="width: 300px; height: 100px; background-color: #F6F6FF; font-size: 13px; top: 150px; z-index: 3; position: absolute; top: 220px; right: 230px;">
                                        <div style="padding: 5px 5px; border-bottom: 1px solid #dddddd; text-align :center "><span >Quick Help</span></div>
                                        <div style="padding: 5px 0 0 5px;line-height :25px;">
                                            <ul><li style="list-style-type :square;">	Join button is disabled for batches that you are already registered with.</li>
                                               
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

                                        <asp:DropDownList ID="DropDownGrade" runat="server" class="input-box-rounded" Font-Names="Verdana" Font-Size="Medium"></asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownGrade" ErrorMessage="Please select grade." Font-Bold="True" Font-Size="Smaller" Display="Dynamic" ForeColor="IndianRed"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                           
                       
                        </table>

</div>
        </div>
           <asp:Button ID="Button1" runat="server" Text="Show Available Tutor" class="buttonstyle" OnClick="ButtonShow_Click" />

         <br /><br />
      <asp:Panel runat="server" ID="MessagePanel" class="formMessagDiv" Visible="false" ClientIDMode="Static">
            <div>
                <asp:Label ID="Label1" runat="server" class="formMsg" ClientIDMode="Static" Visible="false"></asp:Label>
            </div>
          </asp:Panel> 
      <ajaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolKit:ToolkitScriptManager>
   <%-- <asp:Label ID="noData" runat="server" Visible="false" CssClass="NoData"></asp:Label>--%>
    <asp:Panel ID="PanelTeacher" runat="server" Visible="False">

    <%--    <asp:Label ID="Label3" runat="server" Text="Available Batch with Teacher Listed:"></asp:Label><br />--%>
        <asp:GridView ID="gvBatch" runat="server" cssclass="Grid"     
    AutoGenerateColumns ="false" DataKeyNames="BatchID"
    AllowPaging="true" 
    OnRowCommand="gvBatch_RowCommand"
    OnRowDataBound="gvBatch_RowDataBound"
    EmptyDataText="No tutor is available at this moment." >      
            <PagerStyle HorizontalAlign = "Right" CssClass = "GridPager" />   
            <EmptyDataRowStyle CssClass = "EmptyGrid"/>
            <Columns>

                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" style="cursor: pointer" src="../Images/plus.gif" />
                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                            <asp:GridView ID="gvBatchDetails" runat="server" 
                                AutoGenerateColumns="false" CssClass="ChildGrid" >
                              
                                <Columns>
                                    <asp:BoundField HeaderText="Day" DataField="dayName" ItemStyle-Width="5%" />
                                    <asp:BoundField HeaderText="Start Time" DataField="starttime" ItemStyle-Width="5%" />
                                    <asp:BoundField HeaderText="End Time" DataField="endtime" ItemStyle-Width="5%" />
                                 <%--   <asp:BoundField HeaderText="Duration" DataField="duration" ItemStyle-Width="5%" />--%>

                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="BatchID" HeaderText="Batch ID" visible="false" />
                <asp:BoundField DataField="BatchName" HeaderText="Batch" />
                <asp:BoundField DataField="name" HeaderText="Teacher's Name" />
                <asp:BoundField DataField="address" HeaderText="Address" ItemStyle-Width="8%" />
                <asp:BoundField DataField="district" HeaderText="District" />
                <asp:BoundField DataField="startdate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="enddate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="seatleft" HeaderText="Seat Left" />
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:Label ID="TeacherID" runat ="server" Visible ="false" Text ='<%# Bind("TeacherID")%>' ></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tutor Profile">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="round-button round-button-blue"
                            NavigateUrl='<%# Eval("TeacherId","ViewTutorProfile.aspx?ID={0}") %>'
                            Text="View"></asp:HyperLink>
                    </ItemTemplate>

                </asp:TemplateField>
                 <asp:TemplateField >
                  <ItemTemplate>
               <%-- <asp:CommandField HeaderText="Join" ShowSelectButton="true" />--%>
                        <asp:LinkButton ID="lnkJoin" CommandArgument='<%# Eval("BatchID")  %>' CommandName="Join"  CssClass="round-button round-button-blue"
                        runat="server" Text="Join"></asp:LinkButton>
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
                           <%-- Do you want to delete the batch?<br /><br />--%>
                             <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" OnClick="btn_OK_Click" CommandArgument='<%# Eval("BatchID")  %>' />
                            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
                        </div>
                   
                    </asp:Panel>
                      </ItemTemplate>
                     </asp:TemplateField>
                  <asp:TemplateField >
                  <ItemTemplate>

                      <asp:LinkButton ID="lnkpopup" CommandArgument='<%# Eval("BatchID")  %>' CommandName="ViewProfileinPopUp"  CssClass="round-button round-button-blue"
                        runat="server" Text="profile"></asp:LinkButton>
               <%--       <asp:LinkButton ID="lnkDoSomething" runat="server" onClick="lnkDoSomething_Click">Do Something</asp:LinkButton>--%>
                    <asp:Button id="dummyButtonProfile" runat="server" style="display:none;" />             
                                            
                <%--    <ajaxToolKit:ConfirmButtonExtender ID="cbe" runat="server" DisplayModalPopupID="mpe" TargetControlID="dummyButton">
                    </ajaxToolKit:ConfirmButtonExtender>--%>
                    <ajaxToolKit:ModalPopupExtender ID="mpeProfile" runat="server" PopupControlID="pnlProfilePopup" TargetControlID="dummyButton" DropShadow="true"
                       CancelControlID="btnNoProfile" BackgroundCssClass="modalBackground">
                    </ajaxToolKit:ModalPopupExtender>
                         <%--this is the modal popup for the delete confirmation--%>
                    <asp:Panel ID="pnlProfilePopup" runat="server" CssClass="modalPopup" Style="display: none" >
                        <div class="header">
                          Profile
                         </div>
                        <div class="body"><br />
                              <asp:Label ID="lblTutorName" runat="server" Text="Yo yo yo!!!"></asp:Label><br />
                              <asp:Image ID="Image1" runat="server" Height="150px" Width="130px" ImageUrl="~/Images/NoImage.jpeg" />
                              <div class="divHeader">
                               <asp:ImageButton ID="closeImage" runat ="server" ImageUrl="../Images/closecross.png" width="18px" height="18px" OnClientClick="javascript:closeDiv();" ToolTip ="Close"/>
                   
                              </div>
                     
                            <asp:Button ID="btnNoProfile" runat="server" Text="No" CssClass="no" />
                        </div>
                    
                    </asp:Panel>
                      </ItemTemplate> 
                      </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
   
        <br />

         
      <%--  <asp:Label ID="Label1" runat="server"></asp:Label>--%>
    </asp:Panel>
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
</asp:Content>


























   <%-- <asp:Panel ID="PanelGrade" runat="server">
        Choose Your Subject that you want tutoring:&nbsp;
        <%--<asp:DropDownList ID="DropDownSub" runat="server">
        </asp:DropDownList>--%>
   <%--      <br />
        Choose Your Grade:&nbsp;
        <asp:DropDownList ID="DropDownGrade" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonShow" runat="server" Text="Show Available Tutor" class="buttonstyle" OnClick="ButtonShow_Click" />
    </asp:Panel>
    <br />
    <asp:Label ID="noData" runat="server" Visible="false" CssClass="NoData"></asp:Label>
    <asp:Panel ID="PanelTeacher" runat="server" Visible="False">

        <asp:Label ID="availableBatch" runat="server" Text="Available Batch with Teacher Listed:"></asp:Label><br />
        <asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="false" CssClass="Grid" Visible="false" EmptyDataText="No tutor is available at this moment."
            DataKeyNames="BatchID"
            AllowPaging="True"
            HorizontalAlign="Center" ShowHeaderWhenEmpty="True"
            OnRowDataBound="gvBatch_RowDataBound" OnSelectedIndexChanged="gvBatch_SelectedIndexChanged" GridLines="None">
            <HeaderStyle HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <Columns>

                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" style="cursor: pointer" src="../Images/plus.gif" />
                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                            <asp:GridView ID="gvBatchDetails" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid" GridLines="None">
                                <HeaderStyle HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField HeaderText="Day" DataField="dayName" ItemStyle-Width="5%" />
                                    <asp:BoundField HeaderText="Start Time" DataField="starttime" ItemStyle-Width="5%" />
                                    <asp:BoundField HeaderText="End Time" DataField="endtime" ItemStyle-Width="5%" />
                                    <asp:BoundField HeaderText="Duration" DataField="duration" ItemStyle-Width="5%" />

                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="BatchID" HeaderText="Batch ID" />
                <asp:BoundField DataField="name" HeaderText="Teacher's Name" />
                <asp:BoundField DataField="address" HeaderText="Address" ItemStyle-Width="8%" />
                <asp:BoundField DataField="district" HeaderText="District" />
                <asp:BoundField DataField="startdate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="seatleft" HeaderText="Seat Left" />
                <asp:TemplateField HeaderText="Tutor Profile">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("TeacherId","ViewTutorProfile.aspx?ID={0}") %>'
                      <%--       Text="View"></asp:HyperLink>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:CommandField HeaderText="Join" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
        <br />
         <div id="messageDiv">
        <div class="divHeader">
              <img class="info" id="Img1" src="../Images/information.jpg" width="20px" height="20px" alt="information icon"  />
            <img class="close" id="closeImage" src="../Images/cross.jpg" width="18px" height="18px" alt="close image" onclick="javascript:closeDiv();" title="Close"/></div>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" CssClass="message"></asp:Label>
        <button  class ="buttonstyle" id="btnOK" onclick="javascript: closeDiv();" style="position :absolute ; top:110px; right:30px; z-index :3;height:20px;">OK</button>
    </div>--%>
        <%--    <asp:Label ID="LabelConfirm" runat="server" ForeColor="#009933" Visible="False"></asp:Label>--%>
     <%--   <br />
        <asp:Label ID="LabelConfirm0" runat="server"></asp:Label>
    </asp:Panel>
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
</asp:Content>--%>
