<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="ViewTutorProfile.aspx.cs" Inherits="Tutor.StudentManagement.ViewTutorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <br />
<%-- <h3 class="pageHeading">Tutor Profile</h3>--%>
      <div class="inputFormContainer">
     <div class="formTitle">
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: left;">
                      <span class="titleText">Tutor Profile</span>
                    </td>
                    <td style="text-align: right;"><span class="round-button">Help</span></td>
                </tr>
            </table>
        </div>
     </div> 
       <div class="formFields">
            <table style="width: 100%;">
                <tr>
                    <td style="vertical-align: top; width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 70%;">
                                    <div class="input-container">
                                        <div class="input_label user">
                                           <asp:Image ID="Image1" runat="server" Height="150px" Width="130px" ImageUrl="~/Images/NoImage.jpeg" />
                                        </div>                                       
                                    </div>
                                </td>
                                <td style="width: 29%;">
                                    <div style="width: 300px; height: 200px; background-color: #F6F6FF; font-size: 12px; top: 150px; z-index: 3; position: absolute; top: 170px; right: 230px;">
                                        <div style="padding: 5px 5px; border-bottom: 1px solid #dddddd; text-align :center "><span >Quick Help</span></div>
                                        <div style="padding: 5px 0 0 5px;line-height :25px;">
                                            <ul><li style="list-style-type :square;">	Select start time and end time underneath day name for that day</li>
                                                <li style="list-style-type :square;">	Batch would not be created if time conflicts with active batches</li>
                                            </ul>

                                        </div>
                                    </div>
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                            <asp:Label ID="lblfn" runat ="server" Text ="First Name" class="input-label-rounded"></asp:Label>
                                        </div>
                                            <asp:Label ID="lblfirstName" runat ="server" Text ="c" class="input-box-rounded"></asp:Label><br />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                             <asp:Label ID="lblln" runat="server" Text="Last Name" class="input-label-rounded"></asp:Label>
                                        </div>
                                          <asp:Label ID="lblLastName" runat="server" Text="c" class="input-box-rounded"></asp:Label>                                 
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                             <asp:Label ID="lblema" runat="server" Text="Email" class="input-label-rounded"></asp:Label>
                                        </div>
                                            <asp:Label ID="lblEmail" runat="server" Text="c" class="input-box-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                                 <asp:Label ID="lblp" runat="server" Text="Phone" class="input-label-rounded"></asp:Label>
                                        </div>
                                            <asp:Label ID="lblPhone" runat="server" Text="c" class="input-box-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                               </tr>
                               <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                                <asp:Label ID="lblAd" runat="server" Text="Address" class="input-label-rounded"></asp:Label>
                                        </div>
                                            <asp:Label ID="lblAddress" runat="server" Text="c" class="input-box-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                              <asp:Label ID="lblDIs" runat="server" Text="District" class="input-label-rounded"></asp:Label>
                                        </div>
                                              <asp:Label ID="lblDistrict" runat="server" Text="c" class="input-box-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                               <asp:Label ID="lbllDiv" runat="server" Text="Division" class="input-label-rounded"></asp:Label>
                                        </div>
                                         <asp:Label ID="lblDivision" runat="server" Text="c" class="input-box-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                               <asp:Label ID="lblG" runat="server" Text="Gender" class="input-label-rounded"></asp:Label>
                                        </div>
                                           <asp:Label ID="lblGender" runat="server" Text="c" class="input-box-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                               <asp:Label ID="lbllns" runat="server" Text="Name of Institute" class="input-label-rounded"></asp:Label>
                                        </div>
                                            <asp:Label ID="lblInstitute" runat="server" Text="Not provided" class="input-box-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                                <asp:Label ID="lblDeg" runat="server" Text="Degrees" class="input-label-rounded"></asp:Label>
                                        </div>
                                             <asp:Label ID="lblDegrees" runat="server" Text="Not provided" class="input-box-rounded">></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-container">
                                        <div class="input_label user">
                                                <asp:Label ID="lblPro" runat="server" Text="Profile" class="input-label-rounded"></asp:Label>
                                        </div>
                                             <asp:Label ID="lblProfile" runat="server" Text="Not provided" class="input-label-rounded"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <div class="input-container">
                                      

                                        <asp:Button ID="btnCancel" runat="server" Text="Back to Join Batch" class="buttonstyle" OnClick="btnCancel_Click"
                                            OnClientClick="javascript:history.go(-1)" />
                                       

                                    </div>
                                </td>
                            </tr>
                        </table>
































 <%--<div class="ImageColumn">
   <%-- <asp:Image ID="Image1" runat="server" Height="150px" Width="130px" ImageUrl="~/Images/NoImage.jpeg" />--%>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br /><br />
   <%--return to previous page with state--%>
   <%--   <a href="javascript:history.go(-1)">GO BACK</a>
    </div>
    <%-- <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br /><br />--%>

      
    <%--  <div class="ProfileColumn">
    
    <asp:Panel ID="displayProfile" runat ="server">
    <table>
    <tr>
    <td class="style3">
  <%--  <asp:Label ID="lblfn" runat ="server" Text ="First Name"></asp:Label>--%>
     <%-- </td>
    <td class="style4">
 <%--   <asp:Label ID="lblfirstName" runat ="server" Text ="c"></asp:Label><br />--%>
    <%--  </td>
    </tr>
        <tr>
                <td class="style3">
                  <%--  <asp:Label ID="lblln" runat="server" Text="Last Name"></asp:Label>--%>
            <%--      </td>
                <td class="style4">
                  <%--  <asp:Label ID="lblLastName" runat="server" Text="c"></asp:Label>--%>
           <%--       </td>
            </tr>
            <tr>
                <td class="style3">
                 <%--   <asp:Label ID="lblema" runat="server" Text="Email"></asp:Label>--%>
               <%--   </td>
                <td class="style4">
                <%--    <asp:Label ID="lblEmail" runat="server" Text="c"></asp:Label>--%>
            <%--      </td>
            </tr>
            <tr>
                <td class="style3">
                <%--    <asp:Label ID="lblp" runat="server" Text="Phone"></asp:Label>--%>
              <%--    </td>
                <td class="style4">
               <%--     <asp:Label ID="lblPhone" runat="server" Text="c"></asp:Label>--%>
            <%--      </td>
            </tr>
            <tr>
                <td class="style3">
                   <%-- <asp:Label ID="lblAd" runat="server" Text="Address"></asp:Label>--%>
              <%--    </td>
                <td class="style4">
                   <%-- <asp:Label ID="lblAddress" runat="server" Text="c"></asp:Label>--%>
               <%--   </td>
            </tr>
            <tr>
                <td class="style3">
                <%--    <asp:Label ID="lblDIs" runat="server" Text="District"></asp:Label>--%>
             <%--     </td>
                <td class="style4">
                 <%--   <asp:Label ID="lblDistrict" runat="server" Text="c"></asp:Label>--%>
             <%--     </td>
            </tr>
            <tr>
                <td class="style3">
                  <%--  <asp:Label ID="lbllDiv" runat="server" Text="Division"></asp:Label>--%>
              <%--    </td>
                <td class="style4">
                   <%-- <asp:Label ID="lblDivision" runat="server" Text="c"></asp:Label>--%>
              <%--    </td>
            </tr>
            <tr>
                <td class="style3">
                   <%-- <asp:Label ID="lblG" runat="server" Text="Gender"></asp:Label>--%>
              <%--    </td>
                <td class="style4">
                  <%--  <asp:Label ID="lblGender" runat="server" Text="c"></asp:Label>--%>
               <%--   </td>
            </tr>
            <tr>
                <td class="style3">
                  <%--  <asp:Label ID="lbllns" runat="server" Text="Name of Institute"></asp:Label>--%>
               <%--   </td>
                <td class="style4">
                  <%--  <asp:Label ID="lblInstitute" runat="server" Text="Not provided"></asp:Label>--%>
              <%--    </td>
            </tr>
            <tr>
                <td class="style3">
                  <%--  <asp:Label ID="lblDeg" runat="server" Text="Degrees"></asp:Label>--%>
              <%--    </td>
                <td class="style4">
                   <%-- <asp:Label ID="lblDegrees" runat="server" Text="Not provided"></asp:Label>--%>
             <%--     </td>
            </tr>
            <tr>
                <td class="style3">
                   <%-- <asp:Label ID="lblPro" runat="server" Text="Profile"></asp:Label>--%>
               <%--   </td>
                <td class="style4">
                   <%-- <asp:Label ID="lblProfile" runat="server" Text="Not provided"></asp:Label>--%>
              <%--    </td>
            </tr>
    
       
    </table>
    </asp:Panel>
    </div>--%>
</asp:Content>
