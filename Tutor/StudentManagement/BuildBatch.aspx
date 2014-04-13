<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="BuildBatch.aspx.cs" Inherits="Tutor.StudentManagement.BuildBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="#" runat="server">Build Batch</a></li>
            <li><a id="A2" href="#" runat="server">Switch Batch </a></li>
           
             </ul>       
           </div>
           </div>
           <br /><br /><br />
<%--<div class="sideNavigation">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherManagement/CreateBatch.aspx">Build Batch</asp:HyperLink><br />
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Switch Batch</asp:HyperLink><br />

 </div>--%>
 <p>
        &nbsp;Welcome to Batch Chosen Page</p>
    <br />
    <asp:Panel ID="PanelGrade" runat="server">
        Choose Your Subject That you want tutoring:&nbsp;
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
    adsad
    <br />
<asp:Panel ID="PanelTeacher" runat="server" Visible="False">
    Available Batch with Teacher Listed:<br />
    <asp:GridView ID="GridViewBatch" runat="server" DataKeyNames="BatchID" 
        OnSelectedIndexChanged="GridViewBatch_SelectedIndexChanged" 
        onrowcreated="GridViewBatch_RowCreated" 
        onrowdatabound="GridViewBatch_RowDataBound" 
        onrowcommand="GridViewBatch_RowCommand">
        <Columns>
         <asp:TemplateField HeaderText ="Select" >
             <ItemTemplate >
                <asp:CheckBox ID="checkBoxSelect" runat="server" />
             </ItemTemplate>
             <HeaderStyle Width ="10%" />
         </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="LabelConfirm" runat="server"></asp:Label>
    <br />
    <asp:Label ID="LabelConfirm0" runat="server"></asp:Label>
</asp:Panel>
<br />
<br />
<br />
<br />
</asp:Content>
