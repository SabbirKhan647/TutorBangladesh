<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="GridViewPagerStyle.aspx.cs" Inherits="Tutor.GridViewPagerStyle" %>
<%@ Register Src="~/Controls/GridViewPaging.ascx" TagPrefix="usercontrol" TagName="GridViewPaging"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/CollapsableGridview.js") %>" type="text/javascript"></script>
    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
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
        
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <ajaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolKit:ToolkitScriptManager>
 <br /><br />
    <asp:GridView ID="gvBatch" HeaderStyle-BackColor="#d9d9ff" HeaderStyle-ForeColor="#000" Width ="97%" GridLines="None" AllowPaging="True" 
    DataKeyNames="BatchID" Font-Names="Verdana" 
    HeaderStyle-Height ="40px"
    RowStyle-BackColor="White"  
    AlternatingRowStyle-BackColor="#f5f5f5" 
    AlternatingRowStyle-ForeColor="#000" 
    AlternatingRowStyle-HorizontalAlign ="Center" 
    RowStyle-Height ="40px" 
    RowStyle-HorizontalAlign ="Center" 
    AlternatingRowStyle-Height ="40px"
    runat="server" AutoGenerateColumns="false" 
    OnRowCommand="gvBatch_RowCommand"
    OnRowDataBound="gvBatch_RowDataBound">
   <%-- <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#9471DE"></SelectedRowStyle>--%>
      <%--  <PagerStyle HorizontalAlign = "Right" CssClass = "GridPager" />--%>
         
    <Columns>
           <asp:TemplateField>
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="Images/plus.gif" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvBatchDetails" GridLines="None"
                            runat="server" 
                            AutoGenerateColumns="false" width="70%" CssClass = "ChildGrid" 
                            Font-Names="Verdana"
                            HeaderStyle-BackColor="#d9d9ff" 
                            HeaderStyle-ForeColor="#000" 
                            AlternatingRowStyle-BackColor="#f5f5f5" 
                            RowStyle-BackColor ="#f5f5f5" 
                            HeaderStyle-Height ="30px"
                            AlternatingRowStyle-Height ="30px"
                            RowStyle-Height ="30px" 
                            RowStyle-HorizontalAlign ="Center" 
                            AlternatingRowStyle-HorizontalAlign ="Center"   >
                           <%-- <HeaderStyle HorizontalAlign ="Center" Width="10%" BorderStyle ="None"  />
                         
                             <rowstyle backcolor="#D7E0DC" HorizontalAlign ="Center" Width="10%" forecolor="black" BorderStyle ="None" height="40px"  />
                             <headerstyle backcolor="#a9a9a9" forecolor="black" />--%>
                            
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
                       <asp:LinkButton ID="lnkDelete" CommandArgument='<%# Eval("BatchID")  %>' CommandName="Remove"  CssClass="round-button round-button-blue"
                        runat="server" Text="Remove"></asp:LinkButton>
               <%--       <asp:LinkButton ID="lnkDoSomething" runat="server" onClick="lnkDoSomething_Click">Do Something</asp:LinkButton>--%>
                    <asp:Button id="dummyButton" runat="server" style="display:none;" />

                   




                    <ajaxToolKit:ConfirmButtonExtender ID="cbe" runat="server" DisplayModalPopupID="mpe" TargetControlID="dummyButton">
                    </ajaxToolKit:ConfirmButtonExtender>
                    <ajaxToolKit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="dummyButton" DropShadow="true"
                       CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                    </ajaxToolKit:ModalPopupExtender>

                    <%--   <asp:ModalPopupExtender ID="mpelnklnkDoSomething" runat="server" 
                      BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="controlToPopUpId"
                      PopupDragHandleControlID="pnlDragHandlerForlnkDoSomething" 
                      TargetControlID="dummyButton"></asp:ModalPopupExtender>--%>

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
  
</asp:GridView>
 <usercontrol:GridViewPaging runat="server" id="GridViewPagingControl"  />
 
</asp:Content>
