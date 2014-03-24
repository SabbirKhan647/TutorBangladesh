<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="MyBatchesAsStudent.aspx.cs" Inherits="Tutor.StudentManagement.MyBatchesAsStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/CollapsableGridview.js") %>" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br />
<div class="menubar1">
             <div class="menupublic1">           
            <ul id="navmenu1">
            <li><a id="A1" href="BuildBatch1.aspx" runat="server">Build Batch</a></li>
          
             </ul>       
           </div>
           </div>
         
           <br />
           <h3 class="pageHeading">My Batches    </h3>
<%--<div class="sideNavigation">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StudentManagement/BuildBatch1.aspx">Build Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Switch Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl ="~/StudentManagement/MyBatchesAsStudent.aspx">My Batches</asp:HyperLink><br />
</div>  --%>     
   <br />
<asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="False" CssClass="Grid" 
        DataKeyNames="BatchID" 
         AllowPaging="True" 
        HorizontalAlign="Center" ShowHeaderWhenEmpty="True" 
           GridLines="Vertical" onrowdatabound="gvBatch_RowDataBound" 
        onselectedindexchanged="gvBatch_SelectedIndexChanged" >
        <HeaderStyle HorizontalAlign ="Center"  />
        <RowStyle HorizontalAlign ="Center" />
        <Columns>
       
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="../Images/plus.gif" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvBatchDetails" runat="server" AutoGenerateColumns="false" CssClass = "ChildGrid" GridLines ="None">
                            <HeaderStyle HorizontalAlign ="Center" />
                            <RowStyle HorizontalAlign ="Center" />
                            <Columns>
                             <asp:BoundField HeaderText ="Day" DataField ="dayName" ItemStyle-Width ="5%" />
                             <asp:BoundField HeaderText ="Start Time" DataField ="starttime" ItemStyle-Width ="5%" />
                             <asp:BoundField HeaderText ="End Time" DataField ="endtime" ItemStyle-Width ="5%"/>
                             <asp:BoundField HeaderText ="Duration" DataField ="duration" ItemStyle-Width ="5%" />
                             
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
               </ItemTemplate>
            </asp:TemplateField>
            
           <asp:BoundField  DataField="BatchID" HeaderText="Batch ID"  />
           <asp:BoundField  DataField="StudentID" HeaderText="Student ID"  />
           <asp:BoundField  DataField="StudentName" HeaderText="Student Name" />
           <asp:BoundField  DataField="subname" HeaderText="Subject" ItemStyle-Width="8%" >
<ItemStyle Width="8%"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField  DataField ="GradeName" HeaderText ="Grade" />
           <asp:BoundField  DataField ="TutorName" HeaderText ="Tutor Name" />
           <asp:BoundField  DataField="dateJoined" HeaderText="Date Joined" DataFormatString ="{0:MM/dd/yyyy}"  />
           <asp:BoundField   DataField="startdate" HeaderText="Batch Starts" DataFormatString ="{0:MM/dd/yyyy}"  />
          <asp:CommandField HeaderText="Deselect" ShowSelectButton="true" 
                DeleteText ="Deselect" SelectText="Deselect" />
          <%-- <asp:TemplateField HeaderText="Deselect Batch">
                    <ItemTemplate >
                        <asp:LinkButton ID="DeselectBatch"  runat="server">Deselect</asp:LinkButton>
                            </ItemTemplate>
                               
            </asp:TemplateField>--%>
            
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible ="false" ForeColor ="Green" ></asp:Label>
    
</asp:Content>
