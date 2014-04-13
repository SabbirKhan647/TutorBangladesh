<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="Worksheet.aspx.cs" Inherits="Tutor.TeacherManagement.Worksheet1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 147px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A1" href="UploadWorksheet.aspx" runat="server">Upload Worksheet</a></li>
            <li><a id="A2" href="#" runat="server">Delete Worksheet </a></li>
            </ul>       
           </div>
           </div>
   <%-- <div class="sideNavigation"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherManagement/UploadWorksheet.aspx">Upload Worksheet</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl ="#">Delete Worksheet</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="#">Replace Worksheet</asp:HyperLink><br />
 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl ="#">View Worksheet</asp:HyperLink>
 </div>--%>
       <br /><br />
        <h3 class="pageHeading">View Worksheet</h3>
    <table class="style1">
        <tr>
            <td class="style2">

    <asp:Label ID="Label1" runat="server" Text="Choose Subject:"></asp:Label>
            </td>
            <td>
     <asp:DropDownList ID="DropDownListSub" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
    <asp:Label ID="Label2" runat="server" Text="Choose Grade:"></asp:Label>
            </td>
            <td>
     <asp:DropDownList ID="DropDownListGrade" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">

     <asp:Label ID="Label3" runat="server" Text="Level of Difficulty:"></asp:Label>
            </td>
            <td>
     <asp:DropDownList ID="DropDownListLOD" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
<asp:Button ID="ButtonShow" runat="server" OnClick="ButtonShow_Click" Text="Show List " 
                    Visible="True" Width="171px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    

   <br /><br />
  <asp:GridView ID="GridViewWorksheet" runat="server" DataKeyNames="WorksheetID" 
        OnSelectedIndexChanged="GridViewWorksheet_SelectedIndexChanged" 
        style="margin-left: 0px" >
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("WorksheetId", "GetFile.aspx?ID={0}") %>'
                            Text="Download"></asp:HyperLink>
                           <%-- <asp:LinkButton ID="showDoc" runat ="server" Text="View"></asp:LinkButton>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="View" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>



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
