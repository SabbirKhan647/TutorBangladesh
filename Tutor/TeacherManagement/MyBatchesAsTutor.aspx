<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="MyBatchesAsTutor.aspx.cs" Inherits="Tutor.TeacherManagement.MyBatchesAsTutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language ="javascript" src="<%# ResolveUrl("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
<script language ="javascript" src="<%# ResolveUrl("~/Scripts/CollapsableGridview.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menubar1">
             <div class="menupublic1">             
            <ul id="navmenu1">
            <li><a id="A6" href="MyBatchesAsTutor.aspx" runat="server">My Batches </a></li>
            <li><a id="A1" href="CreateBatch.aspx" runat="server">Create Batch</a></li>
            <li><a id="A2" href="InsertBatchDetails.aspx" runat="server">Insert Batch Day/Time </a></li>
            <li><a id="A4" href="EditBatch.aspx" runat="server">Edit Batch </a></li>

             </ul>       
           </div>
           </div>

 <br />
 <h3 class="pageHeading">My Batches</h3>
<asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="false" CssClass="Grid" 
        DataKeyNames="BatchID" OnRowDataBound="OnRowDataBound" 
        ondatabound="gvBatch_DataBound" 
        onrowcancelingedit="gvBatch_RowCancelingEdit" 
        onrowdeleting="gvBatch_RowDeleting" onrowediting="gvBatch_RowEditing" 
        onrowcreated="gvBatch_RowCreated" AllowPaging="True" 
        HorizontalAlign="Center" ShowHeaderWhenEmpty="True" 
        onrowcommand="gvBatch_RowCommand" GridLines="Horizontal" 
    onrowupdating="gvBatch_RowUpdating" >
        <HeaderStyle HorizontalAlign ="Center" Width="10%" />
        <RowStyle HorizontalAlign ="Center" Width="10%" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="../Images/plus.gif" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvBatchDetails" runat="server" AutoGenerateColumns="false"  CssClass = "ChildGrid" OnRowDataBound ="childOnRowDataBound" OnDataBound ="childDataBound">
                            <HeaderStyle HorizontalAlign ="Center" Width="10%"/>
                            <RowStyle HorizontalAlign ="Center" Width="10%"/>
                            <Columns>
                               <asp:TemplateField HeaderText="Batch ID" >
                                <ItemTemplate >
                                     <asp:Label ID="lblchildBatchID" runat ="server" Text='<%# Eval("BatchID") %>'></asp:Label>
                                 </ItemTemplate>
                                 </asp:TemplateField>

                                <asp:TemplateField HeaderText="Day" >
                                <ItemTemplate>
                                     <asp:Label ID="lblDay" runat ="server" Text='<%# Eval("DayName") %>' ItemStyle-Width="150px"></asp:Label></ItemTemplate>
                                <EditItemTemplate>
                                     <asp:DropDownList ID="EditDropDownListDay" runat="server"  autoPostBack="true" ItemStyle-Width="150px"></asp:DropDownList>
                                </EditItemTemplate>
                               <%-- <FooterTemplate>
                                     <asp:DropDownList ID="FooterDropDownListDay" runat="server" autoPostBack="false" ItemStyle-Width="150px" OnSelectedIndexChanged ="FooterDropDownListDay_SelectedIndexChanged"></asp:DropDownList>
                                </FooterTemplate>--%>
                            </asp:TemplateField>
                               <%-- <asp:BoundField ItemStyle-Width="150px" DataField="startTime" HeaderText="Start Time" />--%>
                                 <asp:TemplateField HeaderText="Start Time">
                                    <ItemTemplate>
                                        <asp:Label runat ="server" ID="lblStartTime" Text ='<%# Eval("starttime") %>' ItemStyle-Width="150px" ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate >
                                        <asp:DropDownList ID="ChildDropDownListStartTime" runat="server" autoPostBack="false" ItemStyle-Width="150px"> </asp:DropDownList>
                                    </EditItemTemplate>
                                   <%-- <FooterTemplate>
                                        <asp:DropDownList ID="ChildFooterDropDownListStartTime" runat="server" autoPostBack="false" ItemStyle-Width="150px"> </asp:DropDownList>
                                    </FooterTemplate>--%>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="End Time">
                                    <ItemTemplate>
                                        <asp:Label runat ="server" ID="lblendTime" Text ='<%# Eval("endtime") %>' ItemStyle-Width="150px" ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate >
                                        <asp:DropDownList ID="ChildDropDownListEndTime" runat="server" autoPostBack="false" ItemStyle-Width="150px"> </asp:DropDownList>
                                    </EditItemTemplate>
                                  <%--  <FooterTemplate>
                                        <asp:DropDownList ID="ChildFooterDropDownListEndTime" runat="server" autoPostBack="false" ItemStyle-Width="150px"> </asp:DropDownList>
                                    </FooterTemplate>--%>
                                </asp:TemplateField>
                               <%-- <asp:CommandField HeaderText="Edit" ShowEditButton="True"  />--%>
                                <%--<asp:CommandField  HeaderText ="Delete" ShowDeleteButton ="true" />--%>
                                 <%-- <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkDeleteBatchDetails" CommandName="DeleteBarchDetails" runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate>--%>
                                    <%--<FooterTemplate>
                                        <asp:LinkButton ID="linkAddBatchDetails" CommandName="AddBatchDetails" runat="server">Add</asp:LinkButton>
                                    </FooterTemplate>--%>
                              <%--  </asp:TemplateField>
                           --%>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
               </ItemTemplate>
            </asp:TemplateField>
          <%-- <asp:BoundField  DataField="BatchID" HeaderText="Batch ID" />--%>
           <asp:TemplateField HeaderText ="Batch ID">
           <ItemTemplate  >
           <asp:Label runat ="server" ID="lblBatchID" Text ='<%# Eval("batchid") %>'></asp:Label>
           </ItemTemplate>
           
           </asp:TemplateField>
           
             <asp:TemplateField HeaderText="Subject" >
                    <ItemTemplate><%# Eval("subname") %></ItemTemplate>
                    <EditItemTemplate>
                     <asp:DropDownList ID="EditDropDownListSubject" runat="server" ></asp:DropDownList>
                    </EditItemTemplate>
                   <%-- <FooterTemplate>
                        <asp:DropDownList ID="DropDownListSubject" runat="server"></asp:DropDownList>
                    </FooterTemplate>--%>
                    </asp:TemplateField>
              <asp:TemplateField HeaderText="Grade" >
                    <ItemTemplate><%# Eval("gradename") %></ItemTemplate>
                    <EditItemTemplate>
                        <%--<asp:TextBox ID="txtGradeName" Text='<%# Eval("gradename") %>' runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="EditDropDownListGrade" runat="server"></asp:DropDownList>
                     </EditItemTemplate>
                   <%-- <FooterTemplate>
                        <asp:DropDownList ID="DropDownListGrade" runat="server" ></asp:DropDownList>
                    </FooterTemplate>--%>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Start Date" >
                   <ItemTemplate><%# Eval("startdate") %></ItemTemplate>
                   <ItemTemplate >
                   <asp:Label runat="server" ID="lblStartDate" Text ='<%# Bind("startdate", "{0:MM/dd/yyyy}")%>'></asp:Label>
                   </ItemTemplate>
                    <EditItemTemplate>
                       <%-- <asp:TextBox ID="txtstartdate" Text='<%# Eval("startdate") %>' runat="server"></asp:TextBox>--%>
                        <asp:Calendar ID="EditCalendar" runat="server"></asp:Calendar>
                    </EditItemTemplate>
                   <%-- <FooterTemplate>
                        <asp:Calendar ID="FooterCalendar" runat="server"></asp:Calendar>
                    </FooterTemplate>--%>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Max Student" >
                    <ItemTemplate><%# Eval("maxstudent") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMaxStudent" Text='<%# Eval("maxstudent") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <%--<FooterTemplate>
                        <asp:DropDownList ID="DropDownListGrade" runat="server"></asp:DropDownList>
                    </FooterTemplate>--%>
                </asp:TemplateField>
           <%-- <asp:BoundField ItemStyle-Width="150px" DataField="gradename" HeaderText="Grade" />--%>
           <%--  <asp:CommandField HeaderText="Edit/" ShowEditButton="True" />--%>
           
			   <%-- <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        
                        <asp:LinkButton ID="linkDeleteBatch" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>--%>
                  <%--  <FooterTemplate>
                        <asp:LinkButton ID="linkAddBatch" CommandName="AddBatch" runat="server">Add</asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
