using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Configuration;
namespace Tutor.StudentManagement
{
    public partial class Quiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showSessionID.Text = "Session ID: " + Session["SessionID"].ToString();
            if (!IsPostBack)
            {
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DropDownWithRegBatchNameAsStudent";

                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@sid";
                param.Value = Convert.ToInt32(Session["StudentID"].ToString());
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                DataTable dd = new DataTable();
                adapt.Fill(dd);
                drBatch.DataSource = dd;
                drBatch.DataTextField = "BatchName";
                drBatch.DataValueField = "BatchID";
                drBatch.DataBind();
                //  GridViewWorksheet.Visible = true;
                if (c != null)
                {
                    c.Close();
                }

            }
        }
        //protected void Repeater1_Load(object sender, EventArgs e)
        //{
        //    //disable hyperlink if test expire date is earlier than current date
        //    foreach (RepeaterItem item in Repeater1.Items)
        //    {
        //        Label teststartdate = (Label)item.FindControl("lblTestAvailableDate");
        //        DateTime teststartdate1 = DateTime.Parse(teststartdate.Text).Date;
        //        Label testexpiredate = (Label)item.FindControl("lbltestExpireDate");
        //        DateTime testexpiredate1 = DateTime.Parse(testexpiredate.Text).Date;

        //        DateTime currentdate = DateTime.Today;

        //    //    int result = DateTime.Compare(teststartdate1, currentdate);
        //        int result1 = DateTime.Compare(testexpiredate1, currentdate);

        //        //    if((teststartdate1.Date<currentdate)&&(testexpiredate1.Date<currentdate))

        //        if (result1 < 0)
        //        {
        //            HyperLink p = (HyperLink)item.FindControl("HyperLink1");
        //            p.Enabled = false;
        //        }

        //    }
        //}

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //disable hyperlink if test expire date is earlier than current date

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Label teststartdate = (Label)e.Item.FindControl("lblTestAvailableDate");
                DateTime teststartdate1 = DateTime.Parse(teststartdate.Text).Date;
                Label testexpiredate = (Label)e.Item.FindControl("lbltestExpireDate");
                DateTime testexpiredate1 = DateTime.Parse(testexpiredate.Text).Date;
                Label lbltestname = (Label)e.Item.FindControl("lbltestname");
                string testname = lbltestname.Text;

                string d = "Assignment";
                bool b = testname.Contains(d);
                if (b == true)
                {
                    lbltestname.Visible = false;
                    teststartdate.Visible = false;
                    testexpiredate.Visible = false;
                }
            
                  DateTime currentdate = DateTime.Today;//client date
             //   DateTime currentdate =DateTime .Parse (Session["ClientCurrentDate"].ToString()).Date;
                int result1 = DateTime.Compare(testexpiredate1, currentdate);

                if (result1 < 0)
                {
                    HyperLink p = (HyperLink)e.Item.FindControl("HyperLink1");
                    p.Enabled = false;
                    p.CssClass = "DisableHyperlink";
                }

            }

        }
        protected void DisplayQuiz_Click(object sender, EventArgs e)
        {
            Session["BatchID"] = drBatch.SelectedValue;
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("AllgivenTaskNameforStudent", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parm = new SqlParameter("@sid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Session["StudentID"].ToString());
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
            parm = new SqlParameter("@bid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(drBatch.SelectedValue);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
            parm = new SqlParameter("@currentdate", SqlDbType.Date);
            parm.Value = DateTime.Today;//need to change to client side date
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
           
            c.Open();
            SqlDataReader r = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(r);
            Repeater1.DataSource = d;
            Repeater1.DataBind();

            if (c != null)
            {
                c.Close();
            }
           // string taskname = null;
           // SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                
           // c.Open();
           // SqlCommand cmd = new SqlCommand("StudentTask", c);
           // cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add("@sid", SqlDbType.Int).Value = Convert .ToInt32 (Session ["StudentID"].ToString());
           // cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Convert .ToInt32 (drBatch.SelectedValue);
           // SqlDataReader rdr = cmd.ExecuteReader();
           // while (rdr.Read())
           // {
               
           //     taskname = rdr.GetString(0);
           // }
           // c.Close();
           // hyperlinktoTest.Text = taskname;
           
           // c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

           
           // cmd = new SqlCommand("GetStudentTaskID", c);
           // cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add("@sid", SqlDbType.Int).Value = Convert.ToInt32(Session["StudentID"].ToString());
           // cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Convert.ToInt32(drBatch.SelectedValue);
           // cmd.Parameters.Add("@testid", SqlDbType.Int);
           // cmd.Parameters["@testid"].Direction = ParameterDirection.Output;
           // c.Open();
           // cmd.ExecuteNonQuery();
           //string testid= cmd.Parameters["@testid"].Value.ToString();
           // c.Close();
           //hyperlinktoTest.NavigateUrl = string.Format("OpenQuiz.aspx?id={0}",testid);
        
        }
    }
}