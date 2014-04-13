<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="batch.aspx.cs" Inherits="Tutor.TeacherManagement.batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="sideNavigation">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherManagement/CreateBatch.aspx">Create Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeacherManagement/EditDeleteBatch.aspx">Edit / Delete Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Switch Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl ="#">Delete Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl ="~/TeacherManagement/RefreshBatch.aspx">Refresh Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl ="#">Enroll Student</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl ="#">Available Seat</asp:HyperLink><br />
<%--<asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/TeacherManagement/MyBatchesforTutor.aspx">My Batches</asp:HyperLink><br />--%>
 <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/TeacherManagement/Batch.aspx">My Batches</asp:HyperLink>
 </div>
    <asp:GridView ID="GridViewBatchByTutor" runat="server" 
        onprerender="GridViewBatchByTutor_PreRender" 
        onrowcreated="GridViewBatchByTutor_RowCreated">
       <Columns>
      
        <asp:BoundField DataField ="BatchID" HeaderText ="Batch ID" />
        <asp:BoundField DataField ="subname" HeaderText ="Subject Name" />
        <asp:BoundField DataField ="gradename" HeaderText ="Grade Name" />
        <asp:BoundField DataField ="datecreated" DataFormatString ="{0:MM/dd/yyyy}" HtmlEncode ="false" HeaderText ="Date Created" />
        <asp:BoundField DataField ="numberofstudent" HeaderText ="Number of student" />
        <asp:BoundField DataField ="startdate" DataFormatString ="{0:MM/dd/yyyy}" HtmlEncode ="false" HeaderText ="Start Date" />
        <asp:BoundField DataField ="MaxStudent" HeaderText ="Max Student" />
       </Columns>
    </asp:GridView>

</asp:Content>
