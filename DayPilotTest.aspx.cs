using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
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
//using BeforeTimeHeaderRenderEventArgs = DayPilot.Web.Ui.Events.Calendar.BeforeTimeHeaderRenderEventArgs;
//using CommandEventArgs = DayPilot.Web.Ui.Events.CommandEventArgs;
namespace Tutor
{
    public partial class DayPilotTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DayPilotCalendar1.StartDate = Convert.ToDateTime("19 February 2014");
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "Proceduretimetabletest";

                //cmd.ExecuteNonQuery();
                //SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                //DataTable dd = new DataTable();
                //adapt.Fill(dd);
                //DayPilotCalendar1.DataSource = dd;
                //DayPilotCalendar1.DataStartField = "start";
                //DayPilotCalendar1.DataEndField = "end1";
                //DayPilotCalendar1.DataTextField = "name";
                //DayPilotCalendar1.DataValueField = "id";

                //DayPilotCalendar1.Days = 4;
                //DayPilotCalendar1.DataBind();
                //DataBind();


                cmd.CommandText = "aa";

                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@teacherid";
                param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dd = new DataTable();
                adapt.Fill(dd);
                DayPilotCalendar1.DataSource = dd;
                DayPilotCalendar1.DataStartField = "startDatetime";
                DayPilotCalendar1.DataEndField = "endDatetime";
                DayPilotCalendar1.DataTextField = "subname";
                DayPilotCalendar1.DataValueField = "SerialNo";

                DayPilotCalendar1.Days = 14;
                DayPilotCalendar1.DataBind();
                DataBind();
                if (c != null)
                {
                    c.Close();
                }
            }
        }
    }
}