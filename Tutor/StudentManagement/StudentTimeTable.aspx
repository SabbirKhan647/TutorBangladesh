<%@ Page Title="" Language="C#" MasterPageFile="~/StudentSite.Master" AutoEventWireup="true" CodeBehind="StudentTimeTable.aspx.cs" Inherits="Tutor.StudentManagement.StudentTimeTable" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3 class="pageHeading">Time Table</h3>
    <div class="weekNavigation">
        <div class="previousWeek">
            <asp:Button ID="previousWeek1" runat="server" Text="<< Previous Week" OnClick="previousWeek1_Click" class="nextweek1" />
        </div>
        <div class="WeekDayName">
            <asp:Label ID="Label2" runat="server" Text="DayName" CssClass="dayName">Sunday to Saturday</asp:Label>
        </div>
        <div class="NextWeek">
            <asp:Button ID="NextWeek1" runat="server" Text="Next Week >>" OnClick="NextWeek1_Click" class="nextweek1" />
        </div>
    </div>
    <asp:HiddenField ID="storeNextWeekDate" runat="server" />
    <div class="dayPilotContainer">
        <DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server"
            TimeFormat="Clock24Hours" BusinessBeginsHour="6" BusinessEndsHour="23"
            HeightSpec="BusinessHoursNoScroll" Width="500px" />
    </div>
</asp:Content>
