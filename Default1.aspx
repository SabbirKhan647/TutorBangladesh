<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="AjaxDBInsert.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnsubmit').click(function () {

                var stname = $('#txtstuname').val();
                var stclass = $('#txtstuclass').val();
                var roll_no = $('#txtrollno').val();
                var stfathername = $('#txtfathername').val();
                $.ajax({

                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: 'Default1.aspx/INSERT_RECORD',
                    data: "{'stuname':'" + stname + "','stuclass':'" + stclass + "','rollno':'" + roll_no + "','fathername':'" + stfathername + "'}",
                    async: false,
                    success: function (response) {
                        $('#txtstuname').val(''); $('#txtstuclass').val(''); $('#txtrollno').val(''); $('#txtfathername').val('');
                        alert("Record saved successfully in database");
                    },
                    error: function () {

                        alert("some problem in saving data");
                    }
                });

            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
<div>
    <table align="center" class="style1">
        <tr>
            <td>
                Studnet Name
            </td>
            <td>
                <asp:TextBox ID="txtstuname" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Class
            </td>
            <td>
                <asp:TextBox ID="txtstuclass" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Roll No
            </td>
            <td>
                <asp:TextBox ID="txtrollno" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Father Name
            </td>
            <td>
                <asp:TextBox ID="txtfathername" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <input type="button" id="btnsubmit" value="Submit" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</div>
</form>
</body>
</html>


    </div>
    </form>
</body>
</html>
