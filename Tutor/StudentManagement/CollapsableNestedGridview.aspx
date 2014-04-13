<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="CollapsableNestedGridview.aspx.cs" Inherits="Tutor.StudentManagement.CollapsableNestedGridview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
		body
		{
			font-family: Arial;
			font-size: 10pt;
		}
		.Grid td
		{
			background-color: White;
			color: Black;
			font-size: 10pt;
			line-height: 200%;
		}
		.Grid th
		{
			background-color: Navy;
			color: White;
			font-size: 10pt;
			line-height: 200%;
		}
		.ChildGrid td
		{
			background-color:Gray;
			color: White;
			font-size: 10pt;
			line-height: 200%;
		}
		.ChildGrid th
		{
			background-color:Blue;
			color: White;
			font-size: 10pt;
			line-height: 200%;
		}
	</style>
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
	<script type="text/javascript">
	    function divexpandcollapse(divname) {
	        var img = "img" + divname;
	        if ($("#" + img).attr("src") == "../images/plus.png") {
	            $("#" + img)
				.closest("tr")
				.after("<tr><td></td><td colspan = '100%'>" + $("#" + divname)
				.html() + "</td></tr>");
	            $("#" + img).attr("src", "../images/minus.png");
	        } else {
	            $("#" + img).closest("tr").next().remove();
	            $("#" + img).attr("src", "../images/plus.png");
	        }
	    }
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:GridView ID="gridViewBatch" runat="server" AutoGenerateColumns="false" DataKeyNames="BatchID"
			OnRowDataBound="gridViewBatch_OnRowDataBound" CssClass="Grid">
			<Columns>
				<asp:TemplateField ItemStyle-Width="20px">
					<ItemTemplate>
						<a href="JavaScript:divexpandcollapse('div<%# Eval("BatchID") %>');">
							<img alt="Details" id="imgdiv<%# Eval("BatchID") %>" src="../Images/plus.png" />
						</a>
						<div id="div<%# Eval("BatchID") %>" style="display: none;">
							<asp:GridView ID="grdViewBatchDetails" runat="server" AutoGenerateColumns="false"
								DataKeyNames="BatchID" CssClass="ChildGrid">
								<Columns>
									<asp:BoundField  DataField="BatchID" HeaderText="Batch ID" />
                                    <asp:BoundField  DataField="Day" HeaderText="Day" />
                                    <asp:BoundField  DataField="startTime" HeaderText="Start Time" />
                                    <asp:BoundField  DataField="endTime" HeaderText="End Time" />
                                 </Columns>
							</asp:GridView>
						</div>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField ItemStyle-Width="150px" DataField="BatchID" HeaderText="Batch ID" />
				<asp:BoundField ItemStyle-Width="150px" DataField="TeacherID" HeaderText="Teacher ID" />
       		</Columns>
		</asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
