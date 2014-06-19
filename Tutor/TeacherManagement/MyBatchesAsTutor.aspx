<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="MyBatchesAsTutor.aspx.cs" Inherits="Tutor.TeacherManagement.MyBatchesAsTutor" %>
<%@ Register Src="~/Controls/GridViewPaging.ascx" TagPrefix="usercontrol" TagName="GridViewPaging"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/CollapsableGridview.js") %>" type="text/javascript"></script>
<%--<script language="javascript" src="<%# ResolveUrl("~/Scripts/currentDate.js") %>" type="text/javascript"></script>--%>
    <script type ="text/javascript" >
        function closeDiv() {
            if (document.getElementById('closeImage')) {
                document.getElementById('pnlPopup').style.display = "none";
            }
        }
    </script>
<style type="text/css">
    /*body
    {
        font-family: verdana;
        font-size: 10pt;
    }*/
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
        /*--------------------------*/
   /*    .GridPager a , .GridPager span
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
    }*/
    /*.GridPager span
    {
        background-color: #d9d9ff;
        color: #000;
        border: 1px solid #3AC0F2;
    }*/
      .EmptyGrid {
        text-align: center;font-size: 15px;font-family: Verdana;color :#bd1313;font-weight:bold ;
    }
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A6" href="MyBatchesAsTutor.aspx" runat="server">My Batches </a></li>
            <li><a id="A1" href="CreateBatch.aspx" runat="server">New Batch</a></li>
         

             </ul>       
           </div>
           </div>

 <br />
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
    <asp:Panel runat ="server"  ID="MessagePanel" class="formMessagDiv" Visible ="false" >

          <asp:Label ID="lblmessage" runat ="server" class="formMsg" visible="false" ></asp:Label><br />
    </asp:Panel>
    
      <ajaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolKit:ToolkitScriptManager>
 
    <%--  <asp:Label id="noData" runat ="server" Visible ="false" cssClass="NoData" ></asp:Label><br />--%>
     <asp:GridView ID="gvBatch"  runat="server" CssClass = "Grid" AutoGenerateColumns ="false" DataKeyNames="BatchID" 
    AllowPaging="true" 
    OnRowDataBound="gvBatch_RowDataBound"
    OnRowCommand="gvBatch_RowCommand"
    EmptyDataText="No batch is created at this moment." >
   <%-- <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#9471DE"></SelectedRowStyle>--%>
         <AlternatingRowStyle CssClass="AltRow" />
        <%--  <PagerStyle HorizontalAlign ="Center" CssClass = "GridPager" />   
         <PagerSettings Mode="NextPreviousFirstLast" PageButtonCount="4" PreviousPageText="Previous"  
             NextPageText="Next" FirstPageText="First" LastPageText="Last"/>--%>
           <EmptyDataRowStyle CssClass = "EmptyGrid"/>
    <Columns>
           <asp:TemplateField>
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="../Images/plus.gif" class="pluscolumn" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvBatchDetails" runat="server" CssClass = "ChildGrid" AutoGenerateColumns="false"  >
                        
                            <Columns>
                                 <asp:BoundField DataField="BatchID" HeaderText="Batch ID"  Visible ="false" />
                            
                                <asp:TemplateField HeaderText="Day" >
                                <ItemTemplate>
                                     <asp:Label ID="lblDay" runat ="server" BorderStyle ="None" Text='<%# Eval("DayName") %>' ItemStyle-Width="150px"></asp:Label></ItemTemplate>
                          
                            </asp:TemplateField>
                           
                                 <asp:TemplateField HeaderText="Start Time">
                                    <ItemTemplate>
                                        <asp:Label runat ="server" ID="lblStartTime" BorderStyle ="None" Text ='<%# Eval("starttime") %>'  ItemStyle-Width="150px" ></asp:Label>
                                    </ItemTemplate>
                               
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="End Time">
                                    <ItemTemplate>
                                        <asp:Label runat ="server" ID="lblendTime" BorderStyle ="None" Text ='<%# Eval("endtime") %>' ItemStyle-Width="150px" ></asp:Label>
                                    </ItemTemplate>
                                
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
               </ItemTemplate>
            </asp:TemplateField>
      
         
            <asp:BoundField DataField="BatchID" HeaderText="Batch ID" Visible="false" />
            <asp:TemplateField HeaderText="Batch" >
                    <ItemTemplate  >
                          <asp:Label runat="server" ID="lblBatchName" Text ='<%# Bind("BatchName")%>'></asp:Label>
                   
                     

                    </ItemTemplate>
                  
                
                   </asp:TemplateField>
       
                 <asp:TemplateField HeaderText="Start Date" >
                    
                   <ItemTemplate>
                   <asp:Label runat="server" ID="lblStartDate" Text ='<%# Bind("startdate", "{0:MM/dd/yyyy}")%>' font-size="15px"></asp:Label>
                   
                     </ItemTemplate>
                
                </asp:TemplateField>
            <asp:TemplateField HeaderText="End Date" >
                    
                   <ItemTemplate>
                   <asp:Label runat="server" ID="lblEndDate" Text ='<%# Bind("enddate", "{0:MM/dd/yyyy}")%>' Font-Size="15px"></asp:Label>
                   
                   </ItemTemplate>
                
                  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Capacity" >
                    <ItemTemplate>
                         <asp:Label runat="server" ID="lblCapacity" Text ='<%# Bind("maxstudent")%>'></asp:Label>
                   
                    </ItemTemplate>
                  
                 
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Seat Left" >
                    <ItemTemplate>
                         <asp:Label runat="server" ID="lblSeatLeft" Text ='<%# Bind("seatleft")%>' ItemStyle-Width="450px"></asp:Label>
                   
                   </ItemTemplate>
               
                </asp:TemplateField>
        
             <asp:TemplateField >
                    <ItemTemplate>
                       <asp:HiddenField ID="hiddenfieldbatchstatus"    runat="server" Value ='<%# Eval("statusID")  %>'  />  </ItemTemplate>

                </asp:TemplateField>
              <asp:TemplateField >
                  <ItemTemplate>
                      <asp:LinkButton ID="linkbtnactivate" runat ="server" CssClass="round-button round-button-blue  activate" CommandName="Activate" CommandArgument='<%# Eval("BatchID")  %>' Text ="Activate" ></asp:LinkButton>
                   <asp:HyperLink ID="HyperLink1" runat="server" CssClass="round-button round-button-blue"
                            NavigateUrl='<%# Eval("BatchId","CreateBatch.aspx?ID={0}") %>'
                            Text="Update"></asp:HyperLink>
                     <%--  <asp:LinkButton ID="linkDeleteBatch" CommandName="Remove" runat="server" CommandArgument='<%# Eval("BatchID")  %>' CssClass="round-button round-button-blue" >Remove</asp:LinkButton>
                   --%>
                       <asp:LinkButton ID="lnkDelete" CommandArgument='<%# Eval("BatchID")  %>' CommandName="Remove"  CssClass="round-button round-button-blue"
                        runat="server" Text="Remove"></asp:LinkButton>
               <%--       <asp:LinkButton ID="lnkDoSomething" runat="server" onClick="lnkDoSomething_Click">Do Something</asp:LinkButton>--%>
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
                      <%--  <div class="footer" align="right">
                           <%-- <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
                            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />--%>
                     <%--    </div>--%>
                    </asp:Panel>
                       
                       </ItemTemplate>
               
   
              </asp:TemplateField>
         
          
        
    </Columns>
   <%-- <PagerStyle  />--%>
</asp:GridView>
     <usercontrol:GridViewPaging runat="server" id="GridViewPagingControl"  />







     <%-- <asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="false" CssClass="Grid" width="97%"
        DataKeyNames="BatchID" OnRowDataBound="OnRowDataBound" 
        AllowPaging ="false" 
        HorizontalAlign="Center" ShowHeaderWhenEmpty="True" 
        onrowcommand="gvBatch_RowCommand" GridLines="Horizontal" 
         PageSize="20"  BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Top" Font-Names="Verdana"  >
  
      
     <rowstyle backcolor="#D3D3D3"  BorderStyle ="Solid" BorderColor="#c0c0c0" Height ="50px" HorizontalAlign ="Center" Width="10%" forecolor="black" />

        <alternatingrowstyle backcolor="#D3D1DE"   BorderStyle ="None" Height ="50px"  forecolor="black"   />
     <headerstyle HorizontalAlign ="Center" Width="10%"   backcolor="#adadad" BorderStyle ="None" forecolor="Black"  />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="../Images/plus.gif" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvBatchDetails" BorderStyle ="None"  runat="server" AutoGenerateColumns="false" width="70%" CssClass = "ChildGrid" Font-Names="Verdana"  >
                            <HeaderStyle HorizontalAlign ="Center" Width="10%" BorderStyle ="None"  />
                         
                             <rowstyle backcolor="#D7E0DC" HorizontalAlign ="Center" Width="10%" forecolor="black" BorderStyle ="None" height="40px"  />
                             <headerstyle backcolor="#a9a9a9" forecolor="black" />
                            
                            <Columns>
                                 <asp:BoundField DataField="BatchID" HeaderText="Batch ID"  Visible ="false" />
                            
                                <asp:TemplateField HeaderText="Day" >
                                <ItemTemplate>
                                     <asp:Label ID="lblDay" runat ="server" BorderStyle ="None" Text='<%# Eval("DayName") %>' ItemStyle-Width="150px"></asp:Label></ItemTemplate>
                          
                            </asp:TemplateField>
                           
                                 <asp:TemplateField HeaderText="Start Time">
                                    <ItemTemplate>
                                        <asp:Label runat ="server" ID="lblStartTime" BorderStyle ="None" Text ='<%# Eval("starttime") %>'  ItemStyle-Width="150px" ></asp:Label>
                                    </ItemTemplate>
                               
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="End Time">
                                    <ItemTemplate>
                                        <asp:Label runat ="server" ID="lblendTime" BorderStyle ="None" Text ='<%# Eval("endtime") %>' ItemStyle-Width="150px" ></asp:Label>
                                    </ItemTemplate>
                                
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
               </ItemTemplate>
            </asp:TemplateField>
      
         
            <asp:BoundField DataField="BatchID" HeaderText="Batch ID" Visible="false" />
            <asp:TemplateField HeaderText="Batch" >
                    <ItemTemplate  >
                          <asp:Label runat="server" ID="lblBatchName" Text ='<%# Bind("BatchName")%>'></asp:Label>
                   
                     

                    </ItemTemplate>
                  
                
                   </asp:TemplateField>
       
                 <asp:TemplateField HeaderText="Start Date" >
                    
                   <ItemTemplate>
                   <asp:Label runat="server" ID="lblStartDate" Text ='<%# Bind("startdate", "{0:MM/dd/yyyy}")%>'></asp:Label>
                   
                     </ItemTemplate>
                
                </asp:TemplateField>
            <asp:TemplateField HeaderText="End Date" >
                    
                   <ItemTemplate>
                   <asp:Label runat="server" ID="lblEndDate" Text ='<%# Bind("enddate", "{0:MM/dd/yyyy}")%>'></asp:Label>
                   
                   </ItemTemplate>
                
                  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Capacity" >
                    <ItemTemplate>
                         <asp:Label runat="server" ID="lblCapacity" Text ='<%# Bind("maxstudent")%>'></asp:Label>
                   
                    </ItemTemplate>
                  
                 
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Seat Left" >
                    <ItemTemplate>
                         <asp:Label runat="server" ID="lblSeatLeft" Text ='<%# Bind("seatleft")%>'></asp:Label>
                   
                   </ItemTemplate>
               
                </asp:TemplateField>
        
             <asp:TemplateField >
                    <ItemTemplate>
                       <asp:HiddenField ID="hiddenfieldbatchstatus"    runat="server" Value ='<%# Eval("statusID")  %>'  />  </ItemTemplate>

                </asp:TemplateField>
              <asp:TemplateField >
                  <ItemTemplate>
                      <asp:LinkButton ID="linkbtnactivate" runat ="server" CssClass="round-button round-button-blue" CommandName="Activate" CommandArgument='<%# Eval("BatchID")  %>' Text ="Activate" ></asp:LinkButton>
                   <asp:HyperLink ID="HyperLink1" runat="server" CssClass="round-button round-button-blue"
                            NavigateUrl='<%# Eval("BatchId","CreateBatch.aspx?ID={0}") %>'
                            Text="Update"></asp:HyperLink>
                     <%--  <asp:LinkButton ID="linkDeleteBatch" CommandName="Remove" runat="server" CommandArgument='<%# Eval("BatchID")  %>' CssClass="round-button round-button-blue" >Remove</asp:LinkButton>
                   --%>
               <%--        <asp:LinkButton ID="lnkDelete" CommandArgument='<%# Eval("BatchID")  %>' CommandName="Remove"  CssClass="round-button round-button-blue"
                        runat="server" Text="Remove"></asp:LinkButton>
               <%--       <asp:LinkButton ID="lnkDoSomething" runat="server" onClick="lnkDoSomething_Click">Do Something</asp:LinkButton>--%>
             <%--       <asp:Button id="dummyButton" runat="server" style="display:none;" />

                   




                 <%--   <ajaxToolKit:ConfirmButtonExtender ID="cbe" runat="server" DisplayModalPopupID="mpe" TargetControlID="dummyButton">
                    </ajaxToolKit:ConfirmButtonExtender>
                    <ajaxToolKit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="dummyButton" DropShadow="true"
                       CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                    </ajaxToolKit:ModalPopupExtender>

                    <%--   <asp:ModalPopupExtender ID="mpelnklnkDoSomething" runat="server" 
                      BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="controlToPopUpId"
                      PopupDragHandleControlID="pnlDragHandlerForlnkDoSomething" 
                      TargetControlID="dummyButton"></asp:ModalPopupExtender>--%>

                    <%--this is the modal popup for the delete confirmation--%>
                <%--    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none" >
                        <div class="header">
                            Confirmation
                         </div>
                        <div class="body"><br />
                              <asp:Label ID="lblTextPrompt" runat="server" Text="Yo yo yo!!!"></asp:Label><br />
                           <%-- Do you want to delete the batch?<br /><br />--%>
                          <%--   <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" OnClick="btn_OK_Click" CommandArgument='<%# Eval("BatchID")  %>' />
                            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
                        </div>--%>
                      <%--  <div class="footer" align="right">
                           <%-- <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
                            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />--%>
                     <%--    </div>--%>
                     <%--  </asp:Panel>
                       
                       </ItemTemplate>
               
   
              </asp:TemplateField>
         
          
        
               
        </Columns>
    </asp:GridView>
     
   --%>
   

    <asp:Button ID="addnew" runat ="server" Text ="New Batch" CssClass="buttonstyle" OnClick="addnew_Click" /><br />
  
</asp:Content>
