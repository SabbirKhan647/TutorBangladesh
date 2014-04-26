<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="Tutor.StudentManagement.Grade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="pageHeading">Grade    </h3><br />
<asp:Label ID="batch" runat ="server" Text ="Batch: "></asp:Label>

 <asp:DropDownList ID="DropDownListBatchName" runat="server"> </asp:DropDownList>
 <asp:Button ID="btnGO" runat="server" Text="GO" Height="21px" onclick="btnGO_Click" /><br /><br />
 <asp:Label id="noData" runat ="server" Visible ="false" cssClass="NoData" ></asp:Label>
<br />
     <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
    <HeaderTemplate>
    <table>
    <th class="Grade" width="320px" height="45px" style="text-decoration :underline">Test Name </th>
    <th class="Grade" width="100px" height="45px" style="text-decoration :underline">Total Marks </th>
    <th class="Grade" width="100px" height="45px" style="text-decoration :underline">Score </th>
    <th class="Grade" width="100px" height="45px" style="text-decoration :underline">Score (%)</th>
    </table>
    </HeaderTemplate>
    <ItemTemplate>
     <div >
   
    
    <table >
   <tr>
   <td width="320px" height="35px" style="border-bottom :1px solid gray">
   <asp:Label runat ="server" ID="lbltestname" Text='<%# Eval("TestName") %>'></asp:Label>
 </td>
   <td width="100px" height="35px" style="text-align :center; border-bottom :1px solid gray">
   <asp:Label runat ="server" ID="lblTotalMarks" Text='<%# Eval("TotalWorth") %>'></asp:Label>
   </td>
   <td width="100px" height="35px" style="text-align :center; border-bottom :1px solid gray">
   <asp:Label runat ="server" ID="lblScore" Text='<%# Eval("Score") %>'></asp:Label>
   </td>  
    <td width="100px" height="35px" style="text-align :center; border-bottom :1px solid gray">
   <asp:Label runat ="server" ID="lblScorePercent" Text='<%# Eval("ScorePercentage") %>'></asp:Label>
   </td> 
   </tr>
    </table>
   
    </div>
    
   
    
    </ItemTemplate>
    <FooterTemplate>
   
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
