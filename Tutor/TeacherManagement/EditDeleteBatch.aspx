<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="EditDeleteBatch.aspx.cs" Inherits="Tutor.TeacherManagement.MyBatchesforTutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="CreateBatch.aspx" runat="server">Create Batch</a></li>
            <li><a id="A2" href="InsertBatchDetails.aspx" runat="server">Insert Batch Day/Time </a></li>
            <li><a id="A6" href="MyBatchesAsTutor.aspx" runat="server">My Batches </a></li>
            <li><a id="A3" href="EditDeleteBatch.aspx" runat="server">Edit Batch </a></li>

             </ul>       
           </div>
           </div>
<%--<div class="sideNavigation">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherManagement/CreateBatch.aspx">Create Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeacherManagement/EditDeleteBatch.aspx">Edit / Delete Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Switch Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl ="#">Delete Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl ="~/TeacherManagement/RefreshBatch.aspx">Refresh Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl ="#">Enroll Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl ="#">Available Seat</asp:HyperLink><br />
<%--<asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/TeacherManagement/MyBatchesforTutor.aspx">My Batches</asp:HyperLink><br />--%>
 <%--<asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/TeacherManagement/Batch.aspx">My Batches</asp:HyperLink>
 </div>--%>
 <br /><br />
  <h3 class="pageHeading">Edit Batch</h3>
    <asp:GridView ID="GridViewBatchByTutor" runat="server" DataKeyNames="BatchID"
        onrowdeleting="GridViewBatchByTutor_RowDeleting" 
        onrowcreated="GridViewBatchByTutor_RowCreated" 
        onrowdatabound="GridViewBatchByTutor_RowDataBound" 
        onrowediting="GridViewBatchByTutor_RowEditing1" 
        onrowupdating="GridViewBatchByTutor_RowUpdating" 
        onrowcancelingedit="GridViewBatchByTutor_RowCancelingEdit">
        <Columns>
         

        <asp:TemplateField HeaderText ="BatchID" Visible ="false">
             <ItemTemplate >
               <asp:Label ID="lblBatchID" runat ="server" Text ='<%#Eval("BatchID") %>'></asp:Label>          
             </ItemTemplate>
             <HeaderStyle Width ="10%" />
         </asp:TemplateField>
        
         <asp:TemplateField HeaderText="Max Student">
              <ItemTemplate >
                <asp:Label ID="lblMaxStu" runat ="server" Text ='<%#Eval("MaxStudent") %>'></asp:Label>
              </ItemTemplate>
              <EditItemTemplate >
              <asp:TextBox id="txtMaxStu" runat ="server" Text ='<%#Eval("MaxStudent") %>'></asp:TextBox>
              </EditItemTemplate>
              <FooterTemplate >
              <asp:TextBox ID="txtAddMaxStu" runat ="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="reqMaxStu" ControlToValidate ="txtAddMaxStu" runat ="server" ErrorMessage ="Please enter a number"></asp:RequiredFieldValidator>
              </FooterTemplate>
              <HeaderStyle Width ="10%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText ="Edit/Delete" HeaderStyle-Width="10%">
                <ItemTemplate >
                    <asp:LinkButton ID="btnEdit" Text ="Edit" runat ="server" CommandName ="Edit"></asp:LinkButton>
                  <span onclick ="return confirm('Are you sure want to delete?')">
                    <asp:LinkButton ID="btnDelete" Text ="Delete" runat ="server" CommandName ="Delete"></asp:LinkButton>
                  </span>
                </ItemTemplate>
                <EditItemTemplate >
                    <asp:LinkButton ID="btnUpdate" Text ="Update" runat ="server" CommandName ="Update"></asp:LinkButton>
                     <asp:LinkButton ID="btnCancel" Text ="Cancel" runat ="server" CommandName ="Cancel"></asp:LinkButton>
                </EditItemTemplate>
        
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor ="Green"></asp:Label>
</asp:Content>
