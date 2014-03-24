<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true" CodeBehind="UpdateTutorProfile.aspx.cs" Inherits="Tutor.TeacherManagement.UpdateTutorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 171px;
        }
        .style4
        {
            width: 322px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
        <h3 class="pageHeading">Profile</h3>
        <div class="ImageColumn">
 <asp:Image ID="Image1" runat="server" style="width :100px" ImageURL="~/Images/NoImage.jpeg" /><br />
    <asp:Button ID="Button1" runat="server" Text="Change/Upload Picture"  onclick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    

 <asp:FileUpload ID="FileUpload1" runat="server" visible="false" />
 <asp:Button ID="btnUpload" runat="server" Text="Upload" visible="false" onclick="btnUpload_Click" /><br />

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
    </div>
    <div class="ProfileColumn">
    <%--<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>--%>
  
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" 
            Width="396px" datakeynames="TeacherID" AutoGenerateRows="False"  
            onitemupdating="DetailsView1_ItemUpdating" onmodechanging="DetailsView1_ModeChanging" 
            onitemcommand="DetailsView1_ItemCommand" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
                <Fields>
                <asp:TemplateField HeaderText="Tutor ID">
                    <ItemTemplate>
                        <asp:Label ID="lblID" Text='<%# Eval("TeacherID") %>' Visible="true" runat="server"></asp:Label>
                     
                    </ItemTemplate>
                 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="txtFirstname" Text='<%# Eval("FirstName") %>' runat="server" CssClass="textbox"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server" CssClass="textbox"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblemail" Text='<%# Eval("email") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtemail" Text='<%# Eval("email") %>' runat="server" CssClass="textbox"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblphone" Text='<%# Eval("phone") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtphone" Text='<%# Eval("phone") %>' runat="server" CssClass="textbox"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" Text='<%# Eval("Address") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAddress" Text='<%# Eval("Address") %>' runat="server" CssClass="textbox"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="District">
                    <ItemTemplate>
                        <asp:Label ID="lblDistrict" Text='<%# Eval("district") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                      <%--  <asp:TextBox ID="txtPinNo" Text='<%# Eval("district") %>' runat="server" CssClass="textbox"></asp:TextBox>--%>
                      <asp:DropDownList ID="drDistrict" Text='<%# Eval("district") %>'  runat="server">
                        <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Bagerhat</asp:ListItem>
                                <asp:ListItem>Bandarban</asp:ListItem>
                                <asp:ListItem>Barguna</asp:ListItem>
                                <asp:ListItem>Barisal</asp:ListItem>
                                <asp:ListItem>Bhola</asp:ListItem>
                                <asp:ListItem>Bogra</asp:ListItem>
                                <asp:ListItem>Brahmanbaria</asp:ListItem>
                                <asp:ListItem>Chandpur</asp:ListItem>
                                <asp:ListItem>Chittagong</asp:ListItem>
                                <asp:ListItem>Chuadanga</asp:ListItem>
                                <asp:ListItem>Comilla</asp:ListItem>
                                <asp:ListItem>Cox's Bazar</asp:ListItem>
                                <asp:ListItem>Dhaka</asp:ListItem>
                                <asp:ListItem>Dinajpur</asp:ListItem>
                                <asp:ListItem>Faridpur</asp:ListItem>
                                <asp:ListItem>Feni</asp:ListItem>
                                <asp:ListItem>Gaibandha</asp:ListItem>
                                <asp:ListItem>Gazipur</asp:ListItem>
                                <asp:ListItem>Gopalganj</asp:ListItem>
                                <asp:ListItem>Habiganj</asp:ListItem>
                                <asp:ListItem>Jaipurhat</asp:ListItem>
                                <asp:ListItem>Jamalpur</asp:ListItem>
                                <asp:ListItem>Jessore</asp:ListItem>
                                <asp:ListItem>Jhalakati</asp:ListItem>
                                <asp:ListItem>Jhenaidah</asp:ListItem>
                                <asp:ListItem>Khagrachari</asp:ListItem>
                                <asp:ListItem>Khulna</asp:ListItem>
                                <asp:ListItem>Kishoreganj</asp:ListItem>
                                <asp:ListItem>Kurigram</asp:ListItem>
                                <asp:ListItem>Kushtia</asp:ListItem>
                                <asp:ListItem>Lakshmipur</asp:ListItem>
                                <asp:ListItem>Lalmonirhat</asp:ListItem>
                                <asp:ListItem>Madaripur</asp:ListItem>
                                <asp:ListItem>Magura</asp:ListItem>
                                <asp:ListItem>Manikganj</asp:ListItem>
                                <asp:ListItem>Meherpur</asp:ListItem>
                                <asp:ListItem>Moulvibazar</asp:ListItem>
                                <asp:ListItem>Munshiganj</asp:ListItem>
                                <asp:ListItem>Mymensingh</asp:ListItem>
                                <asp:ListItem>Naogaon</asp:ListItem>
                                <asp:ListItem>Narail</asp:ListItem>
                                <asp:ListItem>Narayanganj</asp:ListItem>
                                <asp:ListItem>Narsingdi</asp:ListItem>
                                <asp:ListItem>Natore</asp:ListItem>
                                <asp:ListItem>Nawabganj</asp:ListItem>
                                <asp:ListItem>Netrakona</asp:ListItem>
                                <asp:ListItem>Nilphamari</asp:ListItem>
                                <asp:ListItem>Noakhali</asp:ListItem>
                                <asp:ListItem>Pabna</asp:ListItem>
                                <asp:ListItem>Panchagarh</asp:ListItem>
                                <asp:ListItem>Parbattya Chattagram</asp:ListItem>
                                <asp:ListItem>Patuakhali</asp:ListItem>
                                <asp:ListItem>Pirojpur</asp:ListItem>
                                <asp:ListItem>Rajbari</asp:ListItem>
                                <asp:ListItem>Rajshahi</asp:ListItem>
                                <asp:ListItem>Rangpur</asp:ListItem>
                                <asp:ListItem>Satkhira</asp:ListItem>
                                <asp:ListItem>Shariatpur</asp:ListItem>
                                <asp:ListItem>Sherpur</asp:ListItem>
                                <asp:ListItem>Sirajganj</asp:ListItem>
                                <asp:ListItem>Sunamganj</asp:ListItem>
                                <asp:ListItem>Sylhet</asp:ListItem>
                                <asp:ListItem>Tangail</asp:ListItem>
                                <asp:ListItem>Thakurgaon</asp:ListItem>
                                </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Division">
                    <ItemTemplate>
                        <asp:Label ID="lbldivision" Text='<%# Eval("division") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <%-- <asp:TextBox ID="txtMobileNo" Text='<%# Eval("MobileNo") %>' runat="server" CssClass="textbox"></asp:TextBox>--%>
                         <asp:DropDownList ID="drDivision" Text='<%# Eval("division") %>'  runat="server">
                         <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Dhaka</asp:ListItem>
                                <asp:ListItem>Chittagong</asp:ListItem>
                                <asp:ListItem>Rajshahi</asp:ListItem>
                                <asp:ListItem>Khulna</asp:ListItem>
                                <asp:ListItem>Barisal</asp:ListItem>
                                <asp:ListItem>Rangpur</asp:ListItem>
                                <asp:ListItem>Sylhet</asp:ListItem>
                                </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label ID="lblgender" Text='<%# Eval("gender") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <%-- <asp:TextBox ID="txtMobileNo" Text='<%# Eval("MobileNo") %>' runat="server" CssClass="textbox"></asp:TextBox>--%>
                         <asp:DropDownList ID="drGender" Text='<%# Eval("gender") %>'  runat="server">
                          <asp:ListItem></asp:ListItem>
                                <asp:ListItem>M</asp:ListItem>
                                <asp:ListItem>F</asp:ListItem>
                          </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Institute">
                    <ItemTemplate>
                        <asp:Label ID="lblinstitute" Text='<%# Eval("institute") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <asp:TextBox ID="txtinstitute" Text='<%# Eval("institute") %>' runat="server" CssClass="textbox"></asp:TextBox>
                       
                    </EditItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Degrees">
                    <ItemTemplate>
                        <asp:Label ID="lbldegrees" Text='<%# Eval("degrees") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <asp:TextBox ID="txtdegrees" Text='<%# Eval("degrees") %>' runat="server" CssClass="textbox"></asp:TextBox>
                       
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Profile">
                    <ItemTemplate>
                        <asp:Label ID="lblprofile" Text='<%# Eval("profile") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <asp:TextBox ID="txtprofile" Text='<%# Eval("profile") %>' runat="server" CssClass="textbox" ></asp:TextBox>
                       
                    </EditItemTemplate>
                </asp:TemplateField>






                <asp:CommandField Visible="true" ShowCancelButton="true" ShowEditButton="true" ButtonType="Button" />
            </Fields>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Width ="200px" />
            <PagerStyle CssClass="Foter" BackColor="#284775" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle Width="80px" CssClass="Header" BackColor="#E9ECF1" Font-Bold="True" />












                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />












                    </asp:DetailsView>

   
 
    </asp:Content>
