<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="UploadWorksheet.aspx.cs" Inherits="Tutor.TeacherManagement.UploadWorksheet1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="menubar1">
        <div class="menupublic1">
            <ul id="navmenu1">
                <li><a id="A3" href="Worksheet.aspx" runat="server">View Worksheet </a></li>
                <li><a id="A1" href="UploadWorksheet.aspx" runat="server">Upload Worksheet</a></li>
                <li><a id="A2" href="#" runat="server">Delete Worksheet </a></li>
            </ul>
        </div>
    </div>
           <br />
  <br />
 <h3 class="pageHeading">Upload Worksheet</h3>
  <%-- <div class="sideNavigation"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl ="#">Upload Worksheet</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl ="#">Delete Worksheet</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Replace Worksheet</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/TeacherManagement/Worksheet.aspx">View Worksheet</asp:HyperLink>
 </div>--%>
        &nbsp;
       <%-- <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Download" Width="177px" />--%>
        <br />
&nbsp;<%--<asp:Panel ID="PanelUpDownload" runat="server">--%><br /><div>
    <asp:Label ID="Label1" runat="server" Text="Choose Subject:" Width="170px" ></asp:Label>
    <asp:DropDownList ID="DropDownListSub" runat="server"></asp:DropDownList><br /><br />
    <asp:Label ID="Label2" runat="server" Text="Choose Grade:" Width="170px"></asp:Label>
     <asp:DropDownList ID="DropDownListGrade" runat="server"></asp:DropDownList><br /><br />
     <asp:Label ID="Label3" runat="server" Text="Level of Difficulty:" Width="170px"></asp:Label>
     <asp:DropDownList ID="DropDownListLOD" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList><br /><br />
<asp:FileUpload ID="FileUpload1" runat="server" Visible="True" />
<asp:Label ID="lblMessage" runat="server"></asp:Label>
 <asp:Button ID="ButtonUpload" runat="server" OnClick="ButtonUpload_Click" Text="Upload" Visible="True" class="buttonstyle"/>
  <asp:GridView ID="GridViewWorksheet" runat="server" DataKeyNames="WorksheetID" OnSelectedIndexChanged="GridViewWorksheet_SelectedIndexChanged" style="margin-left: 0px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("WorksheetId", "GetFile.aspx?ID={0}") %>'
                            Text="Download"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="View" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
</div>


           <%-- <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Choose Subject:
                                    <%--<asp:DropDownList ID="DropDownListSub" runat="server">
                                    </asp:DropDownList>
                              <%--  </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Choose&nbsp; Grade:&nbsp;
                                    <asp:DropDownList ID="DropDownListGrade" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Level Of Difficulty:
                                    <asp:DropDownList ID="DropDownListLOD" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="ButtonShow" runat="server" OnClick="ButtonShow_Click" Text="Show List for download" Visible="False" Width="171px" />
                                </td>
                                <td class="auto-style4">
                                    <asp:Button ID="ButtonUpload" runat="server" OnClick="ButtonUpload_Click" Text="Upload" Visible="False" Width="97px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:GridView ID="GridViewWorksheet" runat="server" DataKeyNames="WorksheetID" OnSelectedIndexChanged="GridViewWorksheet_SelectedIndexChanged" style="margin-left: 0px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("WorksheetId", "GetFile.aspx?ID={0}") %>'
                            Text="Download"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="View" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <br />
        <br />
<br />--%>
</asp:Content>
