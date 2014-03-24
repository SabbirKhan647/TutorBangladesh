<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="WorksheetforStudent.aspx.cs" Inherits="Tutor.StudentManagement.WorksheetforStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<h3 class="pageHeading">Worksheet    </h3>
   
   
        <asp:Label ID="Label2" runat="server" Text="Subject:"></asp:Label>
   
    <asp:DropDownList ID="drSubject" runat ="server" 
        onselectedindexchanged="drSubject_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="showWorksheet" runat ="server" 
        onclick="showWorksheet_Click" Text="Go" CssClass="gap" />
        <br />
<asp:GridView ID="GridViewWorksheet" runat="server"  DataKeyNames="WorksheetID" OnSelectedIndexChanged="GridViewWorksheet_SelectedIndexChanged" style="margin-left: 0px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("WorksheetId", "GetFile1.aspx?ID={0}") %>'
                            Text="Download"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="View" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
</asp:Content>
