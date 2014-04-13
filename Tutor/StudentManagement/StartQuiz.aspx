<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="StartQuiz.aspx.cs" Inherits="Tutor.StudentManagement.OpenQuizzzz" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type ="text/javascript">
    function startTime() {
        var dt = new Date();
        document.getElementById('txt').innerHTML = dt.toLocaleTimeString();
//        var today = new Date();
//        var h = today.getHours();
//        var m = today.getMinutes();
//        var s = today.getSeconds();
//        // add a zero in front of numbers<10
//        m = checkTime(m);
//        s = checkTime(s);
//        //   document.getElementById('txt').innerHTML = h + ":" + m + ":" + s;
//        var time = h + ":" + m + ":" + s;
//        document.getElementById('txt').innerHTML = time;
//      //  setInterval('startTime()', 1000);
//           //    t = setTimeout(function () { startTime() }, 50000);
//               //t = setTimeoutstartTime(),5000);
               window.setTimeout('startTime()',1000);
    }

    function checkTime(i) {
        if (i < 10) {
            i = "0" + i;
        }
        return i;
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br />
<asp:Button id="startTest" runat="server" OnClick="startTest_Click" Text="Start Test" />
<asp:Label runat="server" ID="gg"></asp:Label>
<asp:Label runat="server" ID="lblxx"></asp:Label><br />
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering ="true">
    </asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
       <%--<asp:HiddenField ID="txt" runat ="server" ClientIDMode ="Static" />--%>
      <%--<div style="width :300px; height:100px; background:gray;">--%>  <%--<asp:Label id="txt" ClientIDMode ="Static" runat ="server" Text="kk"></asp:Label><%--</div>--%>
     <%--  <div id="txt" style="width :300px; height:100px; background:gray;"></div>--%>
        <br /><br />
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="quesOrder" Text='<%# Eval("QuestionOrder") %>'></asp:Label>
                                            <asp:Label runat="server" ID="Question" Text='<%# Eval("Question") %>'></asp:Label><br />
                                        </td>
                                        <td>
                                            <asp:Button ID="SaveAnswer" Text="Save" runat="server" onCommand="SaveAnswer_Click"
                                                CommandName="SaveAnswerClick" CommandArgument='<%# Eval("QuestionOrder") %>'
                                                ForeColor="Red" />
                                            <asp:Button ID="ChangeAnswer" Text="Change Answer" runat="server" onCommand="ChangeAnswer_Click"
                                                CommandName="ChangeAnswerClick" CommandArgument='<%# Eval("QuestionOrder") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="ansA" runat="server" GroupName="Answers" />
                                            <asp:Label runat="server" ID="Label1" Text="A."></asp:Label>
                                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("AnswerOptionA") %>'></asp:Label><br />
                                            <asp:RadioButton ID="ansB" runat="server" GroupName="Answers" />
                                            <asp:Label runat="server" ID="Label3" Text="B."></asp:Label>
                                            <asp:Label runat="server" ID="Label4" Text='<%# Eval("AnswerOptionB") %>'></asp:Label><br />
                                            <asp:RadioButton ID="ansC" runat="server" GroupName="Answers" />
                                            <asp:Label runat="server" ID="Label5" Text="C."></asp:Label>
                                            <asp:Label runat="server" ID="Label6" Text='<%# Eval("AnswerOptionC") %>'></asp:Label><br />
                                            <asp:RadioButton ID="ansD" runat="server" GroupName="Answers" />
                                            <asp:Label runat="server" ID="Label7" Text="D."></asp:Label>
                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("AnswerOptionD") %>'></asp:Label><br />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </ContentTemplate>
                            <Triggers >
                            <asp:AsyncPostBackTrigger ControlID="SaveAnswer" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="ChangeAnswer" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                </ItemTemplate>
            </asp:Repeater>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
   <asp:Button ID="btnSubmit" runat ="server" Text ="Submit" onClick="btnSubmit_Click"  /> 
    <asp:Label runat="server" ID="ll"></asp:Label>
</asp:Content>
