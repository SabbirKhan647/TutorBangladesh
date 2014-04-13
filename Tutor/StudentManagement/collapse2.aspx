<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="collapse2.aspx.cs" Inherits="Tutor.StudentManagement.collapse2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript">
    function OpenTable(trRow, imgId) {
        object = document.getElementById(trRow);
        if (object.style.display == "none") {
            object.style.display = "";
            document.getElementById(imgId).src = "images/Expand.gif";
        }
        else {
            object.style.display = "none";
            document.getElementById(imgId).src = "images/Collapse.gif";
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:GridView ID="gvParent" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvParent_RowDataBound" CellPadding="4" ForeColor="#333333" ShowHeader="True">
      <Columns>
            <asp:TemplateField ItemStyle-Width="20px">
                  <ItemTemplate>
                        <asp:Image runat="server" ID="img1" ImageUrl="../Images/plus.png" />
                  </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Batch Id" DataField="BatchID">
                  <ItemStyle HorizontalAlign="Center" Width="140px" />
            </asp:BoundField>
           <asp:BoundField HeaderText="Teacher ID" DataField="TeacherID">
                  <ItemStyle HorizontalAlign="Center" Width="140px" />
            </asp:BoundField>
           <%-- <asp:BoundField HeaderText="Designation" DataField="Designation">
                  <ItemStyle HorizontalAlign="Center" Width="140px" />
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="Location">
                  <ItemTemplate>
                        <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("BatchID")%>'></asp:Label>
                        <asp:Literal runat="server" ID="lit1" Text="</td><tr id='trCollapseGrid' style='display:none' ><td colspan='5'>" />
                        <asp:GridView ID="gvChild" AutoGenerateColumns="False" runat="server" EnableViewState="False" ForeColor="#333333">
                              <RowStyle BackColor="#EFF3FB" /> 
                              <AlternatingRowStyle BackColor="White" />
                              <Columns>
                                    <asp:BoundField HeaderText="Batch ID" DataField="BatchID">
                                          <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Day" DataField="Day">
                                          <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Start Time" DataField="startTime">
                                          <ItemStyle HorizontalAlign="Center" Width="110px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="End Time" DataField="endTime">
                                          <ItemStyle HorizontalAlign="Center" Width="245px" />
                                    </asp:BoundField>
                              </Columns>
                              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:Literal runat="server" ID="lit2" Text="</td></tr>" />
                  </ItemTemplate>
            </asp:TemplateField>
      </Columns>
      <RowStyle BackColor="#EFF3FB" />
      <AlternatingRowStyle BackColor="White" />
</asp:GridView>

</asp:Content>
