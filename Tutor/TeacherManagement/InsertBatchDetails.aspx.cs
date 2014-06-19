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
                // To make it the first element at the list, use 0 index : 
                DropDownListDay.Items.Insert(0, new ListItem("Select", string.Empty)); 
                for (int i = 420; i < 1460; i++)
                {
                    DropDownStTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                    i = i + 29;
                }
                // To make it the first element at the list, use 0 index : 
                DropDownStTime.Items.Insert(0, new ListItem("Select", string.Empty)); 
                for (int i = 480; i < 1460; i++)
                {
                    DropDownEndTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                    i = i + 29;
                }
                // To make it the first element at the list, use 0 index : 
                DropDownEndTime.Items.Insert(0, new ListItem("Select", string.Empty)); 
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
                // To make it the first element at the list, use 0 index : 
                DropDownListBatch.Items.Insert(0, new ListItem("Select", string.Empty)); 
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
         //   bool conflict = TimeConflict();
         //   Label2.Text = checktime;

            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("batchtimeconflict", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Session["TeacherID"].ToString ());
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@dayname", SqlDbType.VarChar);
            parm.Value = DropDownListDay.SelectedItem.Text;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@starttime", SqlDbType.VarChar);
            parm.Value = DropDownStTime.SelectedItem.Text;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@endtime", SqlDbType.VarChar);
            parm.Value = DropDownEndTime.SelectedItem.Text;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            //parm = new SqlParameter("@starttime", SqlDbType.Time);
            //parm.Value = DateTime.Parse(DropDownStTime.SelectedItem.Text).TimeOfDay;
            //parm.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(parm);

            //parm = new SqlParameter("@endtime", SqlDbType.Time);
            //parm.Value = DateTime.Parse(DropDownEndTime.SelectedItem.Text).TimeOfDay;
            //parm.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(parm);

            cmd.Parameters.Add("@result", SqlDbType.Int );
            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
            
            c.Open();
            cmd.ExecuteNonQuery();
       //     int conflict = Convert.ToInt16(cmd.Parameters["@result"].Value.ToString());
        //    if (conflict ==0)
        //    {
               Teacher.InsertBatchDetails(batchid, day, sttime1, endtime1, duration);
               lblInsertSuccessfulMsg.Text = "Insert successful";
               lblInsertSuccessfulMsg.Visible = true;
        //    }
            //else {
            //   lblTimeConflictMsg.Text = "Time conflict. Select a new day/time.";
            //   lblTimeConflictMsg.Visible = true;
            //    DropDownStTime.Focus();
            //}
        }
       
        //protected bool TimeConflict()
        //{

        //    SqlConnection c;
        //    c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
        //    c.Open();
        //    SqlCommand cmd = new SqlCommand("select DayName, startTime, endTime  from Batch inner join BatchDay on Batch.BatchID=BatchDay.BatchID where Batch.teacherId= @tid", c);
        //    //2. Define parameter
        //    SqlParameter param = new SqlParameter();
        //    param.ParameterName = "@tid";
        //    param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
        //    cmd.Parameters.Add(param);
        //    SqlDataReader rdr = null;
        //    rdr = cmd.ExecuteReader();
        //    bool a = false;
        //    while (rdr.Read())
        //    {
        //        //compare day
        //        string existingday = rdr[1].ToString().Trim() ;
        //        string selectedday = DropDownListDay.SelectedItem.Text;
        //        lblselectedday.Text ="selected day: " + selectedday;
        //        lblexistingday.Text = "existing day: " + existingday;
          
        //        // start time
        //        TimeSpan selectedstartTime = DateTime.Parse(DropDownStTime.SelectedItem.Text).TimeOfDay;
        //        TimeSpan existingstartTime = DateTime.Parse(rdr[2].ToString()).TimeOfDay;
        //      //  int samestarttime = existingTime.CompareTo(selectedTime);

        //        // end time

        //        TimeSpan selectedendTime = DateTime.Parse(DropDownEndTime.SelectedItem.Text).TimeOfDay;
        //        TimeSpan existingendTime = DateTime.Parse(rdr[3].ToString()).TimeOfDay;

        //        //compare overlap
        //        if (String.Equals(selectedday, existingday, StringComparison.OrdinalIgnoreCase) == true)
        //         {
        //            //  if(selectedstartTime <=existingendTime && selectedendTime <existingstartTime ){
        //            //if(existingendTime <=selectedstartTime || existingstartTime >selectedendTime ){
        //            if (selectedstartTime <= existingendTime || selectedendTime < existingstartTime)
        //            {

        //                a = true;
        //                break;
        //            }
        //            else
        //            {
                       
        //                break;
        //            }

        //        }
        //        else
        //        {
        //          break;
        //        }
        //    }
        //    return a;
        //}

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            lblTimeConflictMsg.Visible = false;
            lblInsertSuccessfulMsg.Visible = false;
        }
    }
}