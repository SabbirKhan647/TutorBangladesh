<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="test..aspx.cs" Inherits="Tutor.TeacherManagement.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .Grid td
        {
            background-color: #A1DCF2;
            color: black;
            font-size: 10pt;
            line-height:200%
        }
        .Grid th
        {
            background-color: #3AC0F2;
            color: White;
            font-size: 10pt;
            line-height:200%
        }
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height:200%
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height:200%
        }
    </style>
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "../Images/minus.gif");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "../Images/plus.gif");
        $(this).closest("tr").next().remove();
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="false" CssClass="Grid"
        DataKeyNames="BatchID" OnRowDataBound="OnRowDataBound" 
        ondatabound="gvBatch_DataBound" 
        onrowcancelingedit="gvBatch_RowCancelingEdit" 
        onrowdeleting="gvBatch_RowDeleting" onrowediting="gvBatch_RowEditing" 
        ShowFooter="True" onrowcreated="gvBatch_RowCreated">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="../Images/plus.gif" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvBatchDetails" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass = "ChildGrid">
                            <Columns>
                                <%--<asp:BoundField ItemStyle-Width="150px" DataField="Day" HeaderText="Day" />--%>
                                <asp:TemplateField HeaderText="Day" >
                                <ItemTemplate><%# Eval("Day") %></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDay" Text='<%# Eval("Day") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                      <%--  <asp:TextBox ID="txtSubName" Text='' runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="DropDownListDay" runat="server">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                                <asp:BoundField ItemStyle-Width="150px" DataField="startTime" HeaderText="Start Time" />
                                <asp:CommandField HeaderText="Edit" ShowEditButton="True"  />
                                <%--<asp:CommandField  HeaderText ="Delete" ShowDeleteButton ="true" />--%>
                                  <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkDeleteBatchDetails" CommandName="DeleteBarchDetails" runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="linkAddBatchDetails" CommandName="AddBatchDetails" runat="server">Add</asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                           
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
               </ItemTemplate>
            </asp:TemplateField>
           <asp:BoundField ItemStyle-Width="150px" DataField="BatchID" HeaderText="Batch ID" />
             <asp:TemplateField HeaderText="Subject IDnnnnn" >
                    <ItemTemplate><%# Eval("subjectID") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSubName" Text='<%# Eval("subjectID") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListSubject" runat="server"></asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="150px" DataField="gradeID" HeaderText="Grade" />
             <asp:CommandField HeaderText="Edit/" ShowEditButton="True" />
			    <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDeleteBatch" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="linkAddBatch" CommandName="AddBatch" runat="server">Add</asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
