<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="MyBatchesAsStudent.aspx.cs" Inherits="Tutor.StudentManagement.MyBatchesAsStudent" %>

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
    <h3 class="pageHeading">My Batches    </h3>
   
    <p style="color:red">Student can deselect a batch before seven (07) days of the batch start date.</p>
    <br />
    <asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="False" CssClass="Grid"
        DataKeyNames="BatchID"
        AllowPaging="True"
        HorizontalAlign="Center" ShowHeaderWhenEmpty="True"
        GridLines="Vertical" OnRowDataBound="gvBatch_RowDataBound"
        OnSelectedIndexChanged="gvBatch_SelectedIndexChanged" OnRowCommand="gvBatch_RowCommand">
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
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
            <asp:BoundField DataField="subname" HeaderText="Subject" ItemStyle-Width="8%">
                <ItemStyle Width="8%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="GradeName" HeaderText="Grade" />
            <asp:BoundField DataField="TutorName" HeaderText="Tutor Name" />
            <asp:BoundField DataField="dateJoined" HeaderText="Date Joined" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="startdate" HeaderText="Batch Starts" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:CommandField HeaderText="Deselect" ShowSelectButton="true" ButtonType="Link"
                DeleteText="Deselect" SelectText="Deselect" />
            <%-- <asp:TemplateField HeaderText="Deselect Batch">
                    <ItemTemplate >
                        <asp:LinkButton ID="DeselectBatch"  runat="server">Deselect</asp:LinkButton>
                            </ItemTemplate>
                               
            </asp:TemplateField>
            --%>
        </Columns>
    </asp:GridView>
    <div id="messageDiv">
        <div class="divHeader">
              <img class="info" id="Img1" src="../Images/information.jpg" width="20px" height="20px" alt="information icon"  />
            <img class="close" id="closeImage" src="../Images/cross.jpg" width="18px" height="18px" alt="close image" onclick="javascript:closeDiv();" title="Close"/></div>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" CssClass="message"></asp:Label>
        <button  class ="buttonstyle" id="btnOK" onclick="javascript: closeDiv();" style="position :absolute ; top:110px; right:30px; z-index :3;height:20px;">OK</button>
    </div>


    <asp:Label ID="diff" runat="server" Text="label2"></asp:Label>
</asp:Content>
