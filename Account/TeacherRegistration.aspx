<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="TeacherRegistration.aspx.cs" Inherits="Tutor.Account.TeacherRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >Teacher Registration</div>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
        OnCreatedUser="CreateUserWizard1_CreatedUser" 
        oncontinuebuttonclick="CreateUserWizard1_ContinueButtonClick">
        <WizardSteps>
            <asp:WizardStep ID="CreateUserWizardStep0" runat="server">
                <%--</asp:WizardStep>
                <asp:WizardStep ID="CreateUserWizardStep1" runat="server">--%>
                <table>
                    <tr>
                        <th>
                            Personal Information</th>
                    </tr>
                    <tr>
                        <td>
                            First name 
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="FName" MaxLength="50" Width="188px" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="FName"
                                     ErrorMessage="First name is required." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last Name</td>
                        <td>
                            <asp:TextBox runat="server" ID="LName" MaxLength="50" Columns="15" 
                                    Height="24px" Width="190px" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="LName"
                                     ErrorMessage="Last name is required." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone:</td>
                        <td>
                            <asp:TextBox ID="Phone" runat="server" Columns="10" MaxLength="11" 
                                TextMode="Phone"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPP0" runat="server" 
                                ControlToValidate="Phone" ErrorMessage="Phone is required."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address:</td>
                        <td>
                            <asp:TextBox ID="Address" runat="server" Columns="10" MaxLength="100" 
                                Width="179px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="Address" ErrorMessage="Address is required."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            District:</td>
                        <td>
                            <asp:DropDownList ID="District" runat="server" AutoPostBack="false">
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
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="District"
                                     ErrorMessage="District is required." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Division:</td>
                        <td>
                            <asp:DropDownList ID="Division" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Dhaka</asp:ListItem>
                                <asp:ListItem>Chittagong</asp:ListItem>
                                <asp:ListItem>Rajshahi</asp:ListItem>
                                <asp:ListItem>Khulna</asp:ListItem>
                                <asp:ListItem>Barisal</asp:ListItem>
                                <asp:ListItem>Rangpur</asp:ListItem>
                                <asp:ListItem>Sylhet</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorD" ControlToValidate="Division"
                                     ErrorMessage="Division is required." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Gender:</td>
                        <td>
                            <asp:DropDownList ID="Gender" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>M</asp:ListItem>
                                <asp:ListItem>F</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Name of Institute"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TInstitute" MaxLength="200" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Degrees</td>
                        <td>
                            <asp:TextBox ID="Degrees" runat="server" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Profile"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Tprofile" runat="server" Columns="10" MaxLength="500" 
                                TextMode="MultiLine" Width="338px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <th>
                                User Information</th>
                        </tr>
                        <tr>
                            <td>
                                Username:</td>
                            <td>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="UserName" 
                                    ErrorMessage="Username is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Password:</td>
                            <td>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="Password" 
                                    ErrorMessage="Password is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Confirm Password:</td>
                            <td>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email:</td>
                            <td>
                                <asp:TextBox runat="server" ID="Email" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="Email" 
                                    ErrorMessage="Email is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Security question:</td>
                            <td>
                                <asp:TextBox runat="server" ID="Question" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="Question" 
                                    ErrorMessage="Question is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Answer:</td>
                            <td>
                                <asp:TextBox runat="server" ID="Answer" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="Answer" 
                                    ErrorMessage="Answer is required." />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="InsertExtraInfo" runat="server" ConnectionString="<%$ ConnectionStrings:TutorConnectionString %>"
                        InsertCommand="INSERT INTO [Teacher] ([FirstName], [LastName],[Email],[Phone],[Address],[District],[Division],[Gender],[Institute],[Degrees],[Profile],[UserId]) VALUES (@FirstName, @LastName, @Email, @Phone,@Address,@District,@Division,@Gender,@Institute,@Degrees,@Profile, @UserId)"
                        ProviderName="<%$ ConnectionStrings:TutorConnectionString.ProviderName %>">
                        <InsertParameters>
                            <asp:ControlParameter Name="FirstName" Type="String" ControlID="FName" PropertyName="Text" />
                            <asp:ControlParameter Name="LastName" Type="String" ControlID="LName" PropertyName="Text" />
                            <asp:ControlParameter Name="Email" Type="String" ControlID="Email" PropertyName="Text" />
                            <asp:ControlParameter Name="Phone" Type="String" ControlID="Phone" PropertyName="Text" />
                            <asp:ControlParameter Name="Address" Type="String" ControlID="Address" PropertyName="Text" />
                            <asp:ControlParameter Name="District" Type="String" ControlID="District" PropertyName="Text" />
                            <asp:ControlParameter Name="Division" Type="String" ControlID="Division" PropertyName="Text" />
                            <asp:ControlParameter Name="Gender" Type="String" ControlID="Gender" PropertyName="Text" />
                            <asp:ControlParameter Name="Institute" Type="String" ControlID="TInstitute" PropertyName="Text" />
                            <asp:ControlParameter Name="Degrees" Type="String" ControlID="Degrees" PropertyName="Text" />                                        
                            <asp:ControlParameter Name="Profile" Type="String" ControlID="TProfile" PropertyName="Text" />                        
                       </InsertParameters>
                    </asp:SqlDataSource>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
        <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
        <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px"
                Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" HorizontalAlign="Center" />
        <CreateUserButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
        <ContinueButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
        <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
        <TitleTextStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <SideBarButtonStyle ForeColor="White" />
    </asp:CreateUserWizard>
</asp:Content>
