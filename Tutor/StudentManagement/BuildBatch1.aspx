<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="BuildBatch1.aspx.cs" Inherits="Tutor.StudentManagement.BuildBatch1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 
<script src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
<script  src="<%# ResolveUrl("~/Scripts/CollapsableGridview.js") %>" type="text/javascript"></script>
<script  src="<%# ResolveUrl("~/Scripts/currentDate.js") %>" type="text/javascript"></script>
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
 <br />
 <h3 class="pageHeading">Build Batch</h3>
    <asp:Panel ID="PanelGrade" runat="server">
        Choose Your Subject that you want tutoring:&nbsp;
        <asp:DropDownList ID="DropDownSub" runat="server">
        </asp:DropDownList>
        <br />
        Choose Your Grade:&nbsp;
        <asp:DropDownList ID="DropDownGrade" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonShow" runat="server" Text="Show Available Teacher" Width="196px" OnClick="ButtonShow_Click" />
    </asp:Panel>
    <br />
    <asp:Label id="noData" runat ="server" Visible ="false" cssClass="NoData" ></asp:Label>
    <asp:Panel ID="PanelTeacher" runat="server" Visible="False">
    
   <asp:Label id="availableBatch" runat="server" Text="Available Batch with Teacher Listed:"></asp:Label><br />
<asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="false" CssClass="Grid" visible="false" EmptyDataText="No tutor is available at this moment."
        DataKeyNames="BatchID" 
         AllowPaging="True" 
        HorizontalAlign="Center" ShowHeaderWhenEmpty="True" 
            onrowdatabound="gvBatch_RowDataBound" OnSelectedIndexChanged="gvBatch_SelectedIndexChanged" GridLines ="None" >
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
           <asp:BoundField  DataField="name" HeaderText="Teacher's Name" />
           <asp:BoundField  DataField="address" HeaderText="Address" ItemStyle-Width="8%" />
           <asp:BoundField  DataField ="district" HeaderText ="District" />
           <asp:BoundField  DataField="startdate" HeaderText="Start Date" DataFormatString ="{0:MM/dd/yyyy}"  />
          <asp:BoundField  DataField="seatleft" HeaderText="Seat Left"   />
           <asp:TemplateField HeaderText="Tutor Profile">
                    <ItemTemplate >
                            <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("TeacherId","ViewTutorProfile.aspx?ID={0}") %>'
                            Text="View" ></asp:HyperLink>
                            </ItemTemplate>
                               
            </asp:TemplateField>
            <asp:CommandField HeaderText="Select" ShowSelectButton="true"  />
        </Columns>
    </asp:GridView>
      <br />
         <div id="messageDiv">
        <div class="divHeader"><img class="close" id="closeImage" src="../Images/cross.jpg" width="20px" height="20px"alt="close image" onclick="javascript:closeDiv();"/></div>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible ="false" CssClass ="message" ></asp:Label>
    </div>
    
<%--    <asp:Label ID="LabelConfirm" runat="server" ForeColor="#009933" Visible="False"></asp:Label>--%>
    <br />
    <asp:Label ID="LabelConfirm0" runat="server"></asp:Label>
</asp:Panel>
     <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
</asp:Content>
