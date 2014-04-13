<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherSite.Master" AutoEventWireup="true"
    CodeBehind="TeacherHome.aspx.cs" Inherits="Tutor.Teacher2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 84px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function disablecontrolbasedonBatch() {
            if (document.getElementById('chkBatch').checked == true) {
                document.getElementById('chkGrade').disabled = true;
                document.getElementById('chkSubject').disabled = true;
                document.getElementById('DropDownMyBatch').style.display = 'block';
                document.getElementById('DropDownMyGrade').style.display = 'none';
                document.getElementById('DropDownMySubject').style.display = 'none';
                document.getElementById('lblBatch').style.display = 'block';
                document.getElementById('lblGrade').style.display = 'none';
                document.getElementById('lblSubject').style.display = 'none';
                document.getElementById('btnSearch').style.display = 'block';
            }
            else {
                document.getElementById('chkGrade').disabled = false;
                document.getElementById('chkSubject').disabled = false;
                document.getElementById('DropDownMyBatch').style.display = 'none';
                document.getElementById('DropDownMyGrade').style.display = 'none';
                document.getElementById('DropDownMySubject').style.display = 'none';
                document.getElementById('lblBatch').style.display = 'none';
                document.getElementById('lblGrade').style.display = 'none';
                document.getElementById('lblSubject').style.display = 'none';
                document.getElementById('btnSearch').style.display = 'none';
            }
        }
        function disablecontrolbasedonGrade() {
            if (document.getElementById('chkGrade').checked == true) {
                document.getElementById('chkBatch').disabled = true;
                document.getElementById('DropDownMyBatch').style.display = 'none';
                document.getElementById('DropDownMyGrade').style.display = 'block';
                document.getElementById('DropDownMySubject').style.display = 'block';
                document.getElementById('lblBatch').style.display = 'none';
                document.getElementById('lblGrade').style.display = 'block';
                document.getElementById('lblSubject').style.display = 'block';
                document.getElementById('btnSearch').style.display = 'block';
            }
            else {
                document.getElementById('chkBatch').disabled = false;
                document.getElementById('DropDownMyBatch').style.display = 'none';
                document.getElementById('DropDownMyGrade').style.display = 'none';
                document.getElementById('DropDownMySubject').style.display = 'none';
                document.getElementById('lblBatch').style.display = 'none';
                document.getElementById('lblGrade').style.display = 'none';
                document.getElementById('lblSubject').style.display = 'none';
                document.getElementById('btnSearch').style.display = 'none';
            }
        }
        function disablecontrolbasedonSubject() {
            if (document.getElementById('chkSubject').checked == true) {
                document.getElementById('chkBatch').disabled = true;
                document.getElementById('DropDownMyBatch').style.display = 'none';
                document.getElementById('DropDownMyGrade').style.display = 'block';
                document.getElementById('DropDownMySubject').style.display = 'block';
                document.getElementById('lblBatch').style.display = 'none';
                document.getElementById('lblGrade').style.display = 'block';
                document.getElementById('lblSubject').style.display = 'block';
                document.getElementById('btnSearch').style.display = 'block';
            }
            else {
                document.getElementById('chkBatch').disabled = false;
                document.getElementById('DropDownMyBatch').style.display = 'none';
                document.getElementById('DropDownMyGrade').style.display = 'none';
                document.getElementById('DropDownMySubject').style.display = 'none';
                document.getElementById('lblBatch').style.display = 'none';
                document.getElementById('lblGrade').style.display = 'none';
                document.getElementById('lblSubject').style.display = 'none';
               document.getElementById('btnSearch').style.display = 'none';

            }
        }
        function ShowControls() {
      //  var element=document.getElementById('DropDownMyBatch');
            // if (element){
            document.getElementById('lblBatch').style.display = 'block';
            document.getElementById('DropDownMyBatch').style.display = 'block';
        //    alert("javascript inside search button is working");
        //    }
        
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="pageHeading">
        My Students</h3>
    <asp:Label ID="date" runat="server" Text="dddddddd"></asp:Label>
    <asp:Panel runat="server" Width="350px" Style="border: 1px solid #ccc; padding: 5px;">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Search By:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkBatch" runat="server" Text="Batch" Checked="false" OnChange="javascript:disablecontrolbasedonBatch();"
                        ClientIDMode="Static" />
                    <asp:CheckBox ID="chkGrade" runat="server" Text="Grade" Checked="false" ClientIDMode="Static"
                        OnChange="javascript:disablecontrolbasedonGrade();" />
                    <asp:CheckBox ID="chkSubject" runat="server" Text="Subject" Checked="false" ClientIDMode="Static"
                        OnChange="javascript:disablecontrolbasedonSubject();" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblBatch" runat="server" Text="Batch:" Style="display: none" ClientIDMode="Static"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownMyBatch" runat="server" ClientIDMode="Static" Style="display: none">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblGrade" runat="server" Text="Grade:" Style="display: none" ClientIDMode="Static"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownMyGrade" runat="server" Style="display: none" OnSelectedIndexChanged="MyStudentByGrade_SelectedIndexChanged"
                        ClientIDMode="Static">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblSubject" runat="server" Text="Subject:" Style="display: none" ClientIDMode="Static"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownMySubject" runat="server" Style="display: none" OnSelectedIndexChanged="MyStudentBySubject_SelectedIndexChanged"
                        ClientIDMode="Static">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search"  ClientIDMode="Static" Style="display:none;"
                        onclick="btnSearch_Click" onclientclick="ShowControls()" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />

  <asp:Label ID="lblBatchName" runat ="server" Font-Bold="true"></asp:Label><br />
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table cellpadding="1" cellspacing ="1" width ="100%" style="border:1px solid #c0c0c0">
            <tr bgcolor="#FF781E" style="border:1px solid #c0c0c0" >
                <th  >ID
                </th>
                <th >Name
                </th>
                <th  >Phone
                </th>
                <th  >Email
                </th>
                <th  >Address
                </th>
                <th  >Gender
                </th>
                <th  >Grade
                </th>
                <th >Institute
                </th>
                 <th  >Guardian
                </th>
                 <th >Guardian Phone
                </th>
                </tr>
           
        </HeaderTemplate>
      
        <ItemTemplate>
          
             
                    <tr style="background-color:White ;border:1px solid #c0c0c0;">
                        <td  ><%# Eval("StudentID") %>
                         <%--   <asp:Label runat="server" ID="quesOrder" Text='<%# Eval("StudentID") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("Name") %>
                          <%--  <asp:Label runat="server" ID="Question" Text='<%# Eval("Name") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("Phone") %>
                         <%--   <asp:Label runat="server" ID="Label1" Text='<%# Eval("Phone") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("email") %>
                          <%--  <asp:Label runat="server" ID="Label2" Text='<%# Eval("email") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("address") %>
                          <%--  <asp:Label runat="server" ID="Label3" Text='<%# Eval("address") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("gender") %>
                         <%--   <asp:Label runat="server" ID="Label5" Text='<%# Eval("gender") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("Grade") %>
                          <%--  <asp:Label runat="server" ID="Label9" Text='<%# Eval("Grade") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("Institute") %>
                        <%--    <asp:Label runat="server" ID="Label6" Text='<%# Eval("Institute") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("Guardian") %>
                        <%--    <asp:Label runat="server" ID="Label7" Text='<%# Eval("Guardian") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("Guardian_Phone") %>
                          <%--  <asp:Label runat="server" ID="Label8" Text='<%# Eval("Guardian_Phone") %>'></asp:Label>--%>
                        </td>
                    </tr>
              
            </div>
        </ItemTemplate>
          <AlternatingItemTemplate >
    
                    <tr bgcolor="#D8D8D8" style="border :1px solid #c0c0c0;">
                        <td  ><%# Eval("StudentID") %>
                      <%--  <asp:Label runat="server" ID="quesOrder" Text='<%# Eval("StudentID") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("Name") %>
                         <%--   <asp:Label runat="server" ID="Question" Text='<%# Eval("Name") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("Phone") %>
                          <%--  <asp:Label runat="server" ID="Label1" Text='<%# Eval("Phone") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("email") %>
                          <%--  <asp:Label runat="server" ID="Label2" Text='<%# Eval("email") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("address") %>
                         <%--   <asp:Label runat="server" ID="Label3" Text='<%# Eval("address") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("gender") %>
                          <%--  <asp:Label runat="server" ID="Label5" Text='<%# Eval("gender") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("Grade") %>
                        <%--    <asp:Label runat="server" ID="Label9" Text='<%# Eval("Grade") %>'></asp:Label>--%>
                        </td>
                        <td  ><%# Eval("Institute") %>
                           <%-- <asp:Label runat="server" ID="Label6" Text='<%# Eval("Institute") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("Guardian") %>
                         <%--   <asp:Label runat="server" ID="Label7" Text='<%# Eval("Guardian") %>'></asp:Label>--%>
                        </td>
                        <td ><%# Eval("Guardian_Phone") %>
                          <%--  <asp:Label runat="server" ID="Label8" Text='<%# Eval("Guardian_Phone") %>'></asp:Label>--%>
                        </td>
                    </tr>
             
        
        </AlternatingItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
