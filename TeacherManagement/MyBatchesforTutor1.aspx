<%--<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="MyBatchesforTutor.aspx.cs" Inherits="Tutor.TeacherManagement.MyBatchesforTutor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>

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

  <%--  <script language="javascript" type="text/javascript">
     function expandcollapse(obj, row) {
         var div = document.getElementById(obj);
         var img = document.getElementById('img' + obj);

         if (div.style.display == "none") {
             div.style.display = "block";
             if (row == 'alt') {
                 img.src = "../Images/minus.gif";
             }
             else {
                 img.src = "../Images/minus.gif";
             }
             img.alt = "Close to view other Customers";
         }
         else {
             div.style.display = "none";
             if (row == 'alt') {
                 img.src = "../Images/plus.gif";
             }
             else {
                 img.src = "../Images/plus.gif";
             }
             img.alt = "Expand to show Orders";
         }
     } 
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" AllowPaging="True" BackColor="White" 
            AutoGenerateColumns="false"  DataKeyNames="BatchID"
            style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 32px" 
            ShowFooter="true" Font-Size="Small"
            Font-Names="Verdana" runat="server" GridLines="None" 
            AllowSorting="true" onrowcommand="GridView1_RowCommand" 
        ondatabound="GridView1_DataBound" CssClass ="Grid">
         <%--   <RowStyle BackColor="Gainsboro" />
            <AlternatingRowStyle BackColor="White" />--%>
            <HeaderStyle BackColor="#0083C1" ForeColor="White"/>
            <FooterStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <%--<ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("BatchID") %>', 'one');">
                            <img id="imgdiv<%# Eval("BatchID") %>" alt="Click to show/hide Orders for Customer <%# Eval("BatchID") %>"  width="9px" border="0" src="../Images/plus.gif"/>
                        </a>
                    </ItemTemplate>--%>
                    <ItemTemplate >
                    <img alt="" style ="cursor :pointer " src="../Images/plus.gif" />
                 
                                   
                <asp:TemplateField HeaderText="Batch ID" SortExpression="BatchID">
                    <ItemTemplate>
                        <asp:Label ID="lblBatchID" Text='<%# Eval("BatchID") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblBatchID1" Text='<%# Eval("BatchID") %>' runat="server"></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtBatchID" Text='' runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject Name" >
                    <ItemTemplate><%# Eval("subname") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSubName" Text='<%# Eval("subname") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                      <%--  <asp:TextBox ID="txtSubName" Text='' runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="DropDownListSubject" runat="server">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Grade Name" >
                    <ItemTemplate><%# Eval("gradename") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtGradeName" Text='<%# Eval("gradename") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                       <%-- <asp:TextBox ID="txtGradeName" Text='' runat="server"></asp:TextBox>--%>
                          <asp:DropDownList ID="DropDownListGrade" runat="server">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
              <%--  <asp:TemplateField HeaderText="Number of Student" >
                    <ItemTemplate><%# Eval("numberofstudent")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContactTitle" Text='<%# Eval("ContactTitle") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtContactTitle" Text='' runat="server"></asp:TextBox>
                    </FooterTemplate>
               </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Start Date" >
                    <ItemTemplate><%# Eval("startdate")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtstartdate" Text='<%# Eval("startdate") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtstartdate1" Text='' runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Max Student" >
                    <ItemTemplate><%# Eval("maxstudent")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtmaxstudent" Text='<%# Eval("maxstudent") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtmaxstudent1" Text='' runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
			    
			    <asp:CommandField HeaderText="Edit/" ShowEditButton="True" />
			    <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDeleteBatch" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="linkAddBatch" CommandName="AddBatch" runat="server">Add</asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
			      <asp:Panel ID="pnlOrders" runat="server" Style="display: none">

                                    <asp:GridView ID="GridView2" AllowPaging="True" AllowSorting="true" BackColor="White" Width="100%" Font-Size="X-Small"
                                        AutoGenerateColumns="false" Font-Names="Verdana" runat="server" DataKeyNames="BatchID" ShowFooter="true"
                                      
                                         BorderStyle ="Solid" CssClass ="ChildGrid"
                                        >
                                       <%-- <RowStyle BackColor="Gainsboro" />
                                        <AlternatingRowStyle BackColor="White" />--%>
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White"/>
                                        <FooterStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Day" SortExpression="Day">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDay" Text='<%# Eval("Day") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDay" Text='<%# Eval("Day") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                                 <FooterTemplate>
                                                    <asp:TextBox ID="txtDay" Text='' runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Time" >
                                                <ItemTemplate><%# Eval("starttime")%></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtstarttime" Text='<%# Eval("starttime")%>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtstarttime" Text='' runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Time" >
                                                <ItemTemplate><%# Eval("endtime")%></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtendtime" Text='<%# Eval("endtime")%>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtendtime" Text='' runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                           
			                                <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
			                                <asp:TemplateField HeaderText="Delete">
                                                 <ItemTemplate>
                                                    <asp:LinkButton ID="linkDeleteCust" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                    <asp:LinkButton ID="linkAddOrder" CommandName="AddOrder" runat="server">Add</asp:LinkButton>
                                                 </FooterTemplate>
                                            </asp:TemplateField>
                                       
                                          
                                         </Columns>
                                   </asp:GridView>
                                    </asp:Panel>
                                      </ItemTemplate>			       
			                            </asp:TemplateField>



			   <%-- <asp:TemplateField>
			         <ItemTemplate>
			           <tr>
                            <td colspan="100%">
                              <%--  <div id="div<%# Eval("BatchID") %>" style="display:none;position:relative;left:15px;OVERFLOW: auto;WIDTH:97%" >--%>
                              
                               <%-- </div>--%>
                            <%-- </td>
                        </tr>--%>
			      			    
			</Columns>
        </asp:GridView>
</asp:Content>
--%>