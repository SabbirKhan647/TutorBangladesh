using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tutor.Class;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tutor.TeacherManagement
{
    public partial class InsertBatchDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                //TimeSpan ts = new TimeSpan(0, 30, 0);

                for (int i = 420; i < 1460; i++)
                {
                    DropDownStTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                    i = i + 29;
                }
                for (int i = 480; i < 1460; i++)
                {
                    DropDownEndTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                    i = i + 29;
                }
                
                int teacherid = Convert.ToInt32(Session["TeacherID"]);
               
                SqlConnection c;
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT BatchID, BatchName from Batch where TeacherID = " + teacherid.ToString(), c);
                //2. Define parameter

                DataTable d = new DataTable();
                adapt.Fill(d);

                DropDownListBatch.DataTextField = "BatchName"; DropDownListBatch.DataValueField = "BatchID";
                DropDownListBatch.DataSource = d; DropDownListBatch.DataBind();
              
                if (c != null)
                {
                    c.Close();
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int batchid = Convert.ToInt32(DropDownListBatch.SelectedValue);//Convert.ToInt32 (Session["BatchID"]);
            string day = DropDownListDay.SelectedItem.Text;
           
            DateTime sttime = Convert.ToDateTime(DropDownStTime.SelectedItem.Text);
            string sttime1 = Convert.ToString(sttime);
            DateTime endtime = Convert.ToDateTime(DropDownEndTime.SelectedItem.Text);
            string endtime1 = Convert.ToString(endtime);
            TimeSpan duration1 = endtime.Subtract(sttime);

            double p = duration1.TotalMilliseconds;
            float duration = Convert.ToInt32(p / 3600000);
            string checktime = TimeConflict();
            Label2.Text = checktime;
            if (checktime == null)
            {
                Teacher.InsertBatchDetails(batchid, day, sttime1, endtime1, duration);
                Label1.Text = "Insert successful";
            }
            else {
                Label2.Text = checktime;
                DropDownStTime.Focus();
            }
        }
        //protected string TimeConflict()
        //{

        //    SqlConnection c;
        //    c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
        //    c.Open();
        //    SqlCommand cmd = new SqlCommand("select Batch.BatchID, DayName, startTime, endTime  from Batch, BatchDay where Batch.teacherId= @tid", c);
        //    //2. Define parameter
        //    SqlParameter param = new SqlParameter();
        //    param.ParameterName = "@tid";
        //    param.Value = Convert .ToInt32 (Session ["TeacherID"].ToString());
        //    cmd.Parameters.Add(param);
        //    SqlDataReader rdr = null;
        //    rdr = cmd.ExecuteReader();
        //    string a = null;
        //    while (rdr.Read())
        //    {
        //        string existingday = rdr[1].ToString();
        //        string selectedday=DropDownListDay .SelectedItem .Text ;
        //        int sameday = String.Compare(selectedday,existingday);
        //       TimeSpan selectedTime = DateTime.Parse(DropDownStTime.SelectedItem.Text).TimeOfDay;
        //       TimeSpan existingTime = DateTime.Parse(rdr[2].ToString()).TimeOfDay;
        //       int samestarttime = existingTime.CompareTo(selectedTime);
        //       //if both day and start time same
        //        if ((samestarttime==0) && (sameday==0) )
        //        {
        //            a= "Time conflict. Please select a new day/time";
        //            break;
                    
        //        }
        //    }
        //    return a;
        //}
        protected string TimeConflict()
        {

            SqlConnection c;
            c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand("select Batch.BatchID, DayName, startTime, endTime  from Batch, BatchDay where Batch.teacherId= @tid", c);
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tid";
            param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
            cmd.Parameters.Add(param);
            SqlDataReader rdr = null;
            rdr = cmd.ExecuteReader();
            string a = null;
            while (rdr.Read())
            {
                //compare day
                string existingday = rdr[1].ToString();
                string selectedday = DropDownListDay.SelectedItem.Text;
                int sameday = String.Compare(selectedday, existingday);

                // start time
                TimeSpan selectedstartTime = DateTime.Parse(DropDownStTime.SelectedItem.Text).TimeOfDay;
                TimeSpan existingstartTime = DateTime.Parse(rdr[2].ToString()).TimeOfDay;
              //  int samestarttime = existingTime.CompareTo(selectedTime);

                // end time

                TimeSpan selectedendTime = DateTime.Parse(DropDownEndTime.SelectedItem.Text).TimeOfDay;
                TimeSpan existingendTime = DateTime.Parse(rdr[3].ToString()).TimeOfDay;

                //compare overlap
                if (sameday == 0)
                {
                  //  if(selectedstartTime <=existingendTime && selectedendTime <existingstartTime ){
                     //if(existingendTime <=selectedstartTime || existingstartTime >selectedendTime ){
                    if(selectedstartTime <=existingendTime || selectedendTime <existingstartTime ){
                   
                    a = "Time conflict. Please select a new day/time";
                    break;
                    }

                }
            }
            return a;
        }
    }
}