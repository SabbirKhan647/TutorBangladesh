using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tutor.TeacherManagement
{
    public partial class CreateTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string time = "90";
                TimeSpan interval;
                if (TimeSpan.TryParseExact(time, "%m", null, out interval))
                {
                    Label1.Text = interval.ToString();
                }

                for (int i = 5; i <= 100; i = i + 5)
                {
                    DropDownTestTotalQuestion.Items.Add(i.ToString()); 
                
                }
                for (int i = 20; i <= 100; i = i + 5)
                {
                    DropDownTestTotalMark.Items.Add(i.ToString());

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
                FillTaskNameDropDownList();
            }
        }

        protected void DropDownTestDuration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCreateTest_Click(object sender, EventArgs e)
        {
           // TimeSpan ts;  
            if (DropDownTestDuration.SelectedIndex== 0) 
            {
                // ts = new TimeSpan(0, 30, 0);
                //Label1.Text =ts.ToString(@"\.hh\:mm\:ss");
              
            }
            else if (DropDownTestDuration.SelectedIndex == 1)
            {
               //ts = new TimeSpan(1, 0, 0);
               // Label1.Text = ts.ToString(@"\.hh\:mm\:ss");
            }
            else if (DropDownTestDuration.SelectedIndex == 2)
            {
               //ts = new TimeSpan(1, 30, 0);
               // Label1.Text = ts.ToString(@"\.hh\:mm\:ss");
            }
            else if (DropDownTestDuration.SelectedIndex == 3)
            {
                // ts = new TimeSpan(2, 0, 0);
                //Label1.Text = ts.ToString(@"\.hh\:mm\:ss");
            }
            else if (DropDownTestDuration.SelectedIndex == 4)
            {
                // ts = new TimeSpan(2, 30, 0);
                //Label1.Text = ts.ToString(@"\.hh\:mm\:ss");
            }
            else {
                // ts = new TimeSpan(3, 0, 0);
                //Label1.Text = ts.ToString(@"\.hh\:mm\:ss");
            }
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            String insertString = "CreateTestSP";

            SqlCommand cmd1 = new SqlCommand(insertString, c);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
            cmd1.Parameters.Add("@bid", SqlDbType.Int).Value = Convert.ToInt32(DropDownListBatch.SelectedValue);
            cmd1.Parameters.Add("@tname", SqlDbType.VarChar).Value = DropDownTestName.SelectedValue;
           // cmd1.Parameters.Add("@du", SqlDbType.Time).Value = ts; 
            cmd1.Parameters.Add("@tad", SqlDbType.Date).Value =DateTime .Parse (txtTestAvailableDate.Text).Date;
            cmd1.Parameters.Add("@ted", SqlDbType.Date).Value =DateTime .Parse(txtTestExpireDate.Text).Date;
            cmd1.Parameters.Add("@tq", SqlDbType.Int).Value =Convert .ToInt32 (DropDownTestTotalQuestion.SelectedValue);
            cmd1.Parameters.Add("@tw", SqlDbType.Int).Value = Convert.ToInt32(DropDownTestTotalMark.SelectedValue);

            //3. Call ExecuteNonQuery to send the command
            cmd1.ExecuteNonQuery();
            //5. Close the connection
            if (c != null)
            {
                c.Close();
            }
            }
        private void FillTaskNameDropDownList()
        {

            SqlConnection c;
            c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT TaskName from TaskName", c);
            //2. Define parameter

            DataTable d = new DataTable();
            adapt.Fill(d);
            
            DropDownTestName.DataTextField = "TaskName"; DropDownTestName.DataValueField = "TaskName";
            DropDownTestName.DataSource = d; DropDownTestName.DataBind();

            if (c != null)
            {
                c.Close();
            }
        }
       
    }
}