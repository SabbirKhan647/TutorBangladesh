<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Tutor.Public.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table>
        <!-- Name -->
        <tr>
            <td align="left">Name</td>
            <td>
                <asp:TextBox ID="txtName"
                    runat="server"
                    Columns="50" Width="335px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">Email *</td>
            <td>
                <asp:TextBox ID="txtEmail"
                    runat="server"
                    Columns="50" Width="335px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                     ControlToValidate="txtEmail"  Display="Static" 
                     Style="z-index: 160; left: 550px; position: absolute; top: 200px" 
                     Font-Size="Small"
                     ErrorMessage="Please enter email address."
                     ForeColor="IndianRed" Font-Bold="True"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                    runat="server" Display="Static"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Please enter a valid email address." ClientIDMode="Static"
                    Font-Bold="True"
                    Font-Size="Small"
                    ForeColor="IndianRed"
                    Style="z-index: 160; left: 550px; position: absolute; top: 200px"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
      
        <tr>
            <td align="left">Mobile</td>
            <td>
                <asp:TextBox ID="txtMobile"
                    runat="server"
                    Columns="50" Width="335px"></asp:TextBox>
            </td>
        </tr>
        <!-- Subject -->
        <tr>
            <td align="left">Subject</td>
            <td>
                <asp:TextBox ID="txtsubject" runat="server" Width="333px"></asp:TextBox>
                <%-- <asp:DropDownList ID="ddlSubject" runat="server">
                <asp:ListItem>Ask a question</asp:ListItem>
                <asp:ListItem>Report a bug</asp:ListItem>
                <asp:ListItem>Customer support ticket</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>--%>
            </td>
        </tr>

        <!-- Message -->
        <tr>
            <td align="left">Message </td>
            <td>
                <asp:TextBox ID="txtMessage"
                    runat="server"
                    Columns="40"
                    Rows="6"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>

        <!-- Submit -->
        <tr align="center">
            <td colspan="2">
                <asp:Button ID="btnSubmit" runat="server" Text="Send" class="buttonstyle"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>

        <!-- Results -->
        <tr align="center">
            <td colspan="2">
                <asp:Label ID="lblResult" runat="server" ForeColor="#cc0000" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
