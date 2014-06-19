﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using Data;
//using DayPilot.Json;
using DayPilot.Utils;
using DayPilot.Web.Ui;
using DayPilot.Web.Ui.Data;
using DayPilot.Web.Ui.Enums;
using DayPilot.Web.Ui.Events;
using DayPilot.Web.Ui.Events.Scheduler;
using System.Configuration;
namespace Tutor.TeacherManagement
{
    public partial class TutorTimeTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // get the first week day date of the current week ex.date of sunday
                DateTime aDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                //store date in hidden field
                storeNextWeekDate.Value = aDate.ToShortDateString().ToString();
                //   previousWeek1.Text = aDate.ToShortDateString().ToString();
                string adate1 = aDate.ToShortDateString().ToString();
                DateTime aShortDate = Convert.ToDateTime(adate1);
                LoadDayPilotCalendar(aShortDate);
            }
        }
               private void LoadDayPilotCalendar(DateTime aShortDate)
        {


               DayPilotCalendar1.StartDate = aShortDate;
               SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "TutorTimeTable1";
                cmd.CommandText = "TutorTimeTableLatest1";
                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@tid";
                param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dd = new DataTable();
                adapt.Fill(dd);
                DayPilotCalendar1.DataSource = dd;
                DayPilotCalendar1.DataStartField = "startDateTime";
                DayPilotCalendar1.DataEndField = "endDateTime";
                DayPilotCalendar1.DataTextField = "batchname";
                DayPilotCalendar1.DataValueField = "SerialNo";

                DayPilotCalendar1.Days =7;
                DayPilotCalendar1.DataBind();
                DataBind();
                if (c != null)
                {
                    c.Close();
                }
               }


               protected void NextWeek1_Click(object sender, EventArgs e)
               {
                   DateTime getHiddenFielddate = Convert.ToDateTime(storeNextWeekDate.Value);
                   DateTime newweekDate = getHiddenFielddate.AddDays(7);
                   //  previousWeek1.Text = newweekDate.ToShortDateString().ToString();
                   LoadDayPilotCalendar(newweekDate);
                   storeNextWeekDate.Value = newweekDate.ToShortDateString().ToString();
               }
               protected void previousWeek1_Click(object sender, EventArgs e)
               {
                   DateTime getHiddenFielddate = Convert.ToDateTime(storeNextWeekDate.Value);
                   DateTime newweekDate = getHiddenFielddate.AddDays(-7);
                   //  previousWeek1.Text = newweekDate.ToShortDateString().ToString();
                   LoadDayPilotCalendar(newweekDate);
                   storeNextWeekDate.Value = newweekDate.ToShortDateString().ToString();
               }

        }
    }
