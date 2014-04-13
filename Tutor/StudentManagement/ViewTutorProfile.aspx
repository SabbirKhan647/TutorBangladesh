<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="ViewTutorProfile.aspx.cs" Inherits="Tutor.StudentManagement.ViewTutorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <br />
 <h3 class="pageHeading">Tutor Profile</h3>
 <div class="ImageColumn">
    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl="~/Images/NoImage.jpeg" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br /><br />
   <%--return to previous page with state--%>
    <a href="javascript:history.go(-1)">GO BACK</a>
    </div>
    <%-- <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br /><br />--%>
    <div class="ProfileColumn">
    
    <asp:Panel ID="displayProfile" runat ="server">
    <table>
    <tr>
    <td class="style3">
    <asp:Label ID="lblfn" runat ="server" Text ="First Name"></asp:Label>
    </td>
    <td class="style4">
    <asp:Label ID="lblfirstName" runat ="server" Text ="c"></asp:Label><br />
    </td>
    </tr>
        <tr>
                <td class="style3">
                    <asp:Label ID="lblln" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblLastName" runat="server" Text="c"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblema" runat="server" Text="Email"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblEmail" runat="server" Text="c"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblp" runat="server" Text="Phone"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblPhone" runat="server" Text="c"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblAd" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblAddress" runat="server" Text="c"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblDIs" runat="server" Text="District"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblDistrict" runat="server" Text="c"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lbllDiv" runat="server" Text="Division"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblDivision" runat="server" Text="c"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblG" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblGender" runat="server" Text="c"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lbllns" runat="server" Text="Name of Institute"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblInstitute" runat="server" Text="Not provided"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblDeg" runat="server" Text="Degrees"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblDegrees" runat="server" Text="Not provided"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblPro" runat="server" Text="Profile"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblProfile" runat="server" Text="Not provided"></asp:Label>
                </td>
            </tr>
    
       
    </table>
    </asp:Panel>
    </div>
</asp:Content>
