<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridViewPaging.ascx.cs" Inherits="Tutor.GridViewPaging" %>
<style type="text/css">
      /*.navigationButton {
      -webkit-box-shadow: rgba(0,0,0,0.2) 0 1px 0 0;
      -moz-box-shadow: rgba(0,0,0,0.2) 0 1px 0 0;
      box-shadow: rgba(0,0,0,0.2) 0 1px 0 0;
      border-bottom-color: #333;
      border: 1px solid #ffffff;
      background-color: #EAF2D3;
      border-radius: 5px;
      -moz-border-radius: 5px;
      -webkit-border-radius: 5px;
      color: #0d76c3;
      font-family: Verdana;
      font-size: 12px;
      text-shadow: #b2e2f5 0 1px 0;
      padding: 5px;
      cursor: pointer;
 }*/
.tablePaging {
      font-family:verdana;
      width: 99%;
      border :none ;
      border-collapse: collapse;
      /*margin-top:-40px;*/
      height:34px;
 }
.tablePaging td {
      font-size: 1em;
      /*border: 1px solid #ffffff;*/
      padding: 3px 7px 4px 7px;
       background-color: #d9d9ff ;
      font-size: 10pt;
 } 
</style>
<table class="tablePaging">
 <tr>
    <%-- <td style="width: 15%; text-align: center;">
     <asp:Label ID="lblPageSize" runat="server" Text="Page Size: "></asp:Label>
     <asp:DropDownList ID="PageRowSize" runat="server">
          <asp:ListItem Selected="True">10</asp:ListItem>
          <asp:ListItem>20</asp:ListItem>
          <asp:ListItem>50</asp:ListItem>
          <asp:ListItem>100</asp:ListItem>
    </asp:DropDownList>
 </td>--%>
 <td style="width: 35%; text-align:left;">
     <asp:Label ID="RecordDisplaySummary" runat="server"></asp:Label>

 </td>
   <%--  <td style="width: 25%"></td>--%>
 <%--<td style="width: 20%; text-align: center;">
     <asp:Label ID="PageDisplaySummary" runat="server"></asp:Label>

 </td>--%>
 <td style="width: 65%;text-align :right ;">
     <asp:Button ID="First" runat="server" Text="First" Width="45px" OnClick="First_Click" CssClass="navigationButton" BackColor="#D9D9FF" BorderStyle="None" Font-Bold="True" />&nbsp;<span>|</span>
     <asp:Button ID="Previous" runat="server" Text="Prev" Width="45px" OnClick="Previous_Click" CssClass="navigationButton" BackColor="#D9D9FF" BorderStyle="None" Font-Bold="True"  />&nbsp;<span>|</span>
       <asp:Label ID="PageDisplaySummary" runat="server" Width="90px"></asp:Label>

     <asp:TextBox ID="SelectedPageNo" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" backcolor="#EAF2D3" 
     Font-Names="Verdana" Font-Size="Large" OnTextChanged="SelectedPageNo_TextChanged" Width="20px" AutoPostBack="True"   
    Visible ="false" ></asp:TextBox>&nbsp;<span>|</span>
     <asp:Button ID="Next" runat="server" Text="Next" Width="45px" OnClick="Next_Click" CssClass="navigationButton" BackColor="#D9D9FF" BorderStyle="None" Font-Bold="True"  />&nbsp;<span>|</span>
     <asp:Button ID="Last" runat="server" Text="Last" Width="45px" OnClick="Last_Click" CssClass="navigationButton" BackColor="#D9D9FF" BorderStyle="None" Font-Bold="True"  />&nbsp; 
 </td>
 </tr>
 <tr id="trErrorMessage" runat="server" visible="false">
     <td colspan="4" style="background-color: #e9e1e1;">
     <asp:Label ID="GridViewPagingError" runat="server" Font-Names="Verdana" Font-Size="9pt" ForeColor="Red"></asp:Label>
     <asp:HiddenField ID="TotalRows" runat="server" Value="0" />
     </td>
 </tr>
</table>