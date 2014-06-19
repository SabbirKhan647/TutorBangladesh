<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Tutor.WebForm1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="min-height: 700px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Click here to show the modal" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
            runat="server" CancelControlID="btnCancel" OkControlID="btnOkay" TargetControlID="Button1"
            PopupControlID="Panel1" Drag="true" PopupDragHandleControlID="PopupHeader">
        </cc1:ModalPopupExtender>
        <div id="Panel1" style="display: none;" class="popupConfirmation">
            <div class="popup_Container">
                <div class="popup_Titlebar" id="PopupHeader">
                    <div class="TitlebarLeft">Popup Header</div>
                    <div class="TitlebarRight"></div>
                </div>
                <div class="popup_Body">
                    <p>
                        This is a simple modal dialog
                    </p>
                </div>
                <div class="popup_Buttons">
                    <input id="btnOkay" value="Done" type="button" />
                    <input id="btnCancel" value="Cancel" type="button" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
