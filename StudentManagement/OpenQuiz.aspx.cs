using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Tutor.StudentManagement
{
    public partial class OpenQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                gg.Text = "Test ID: "+Request.QueryString["ID"];
            
            }
        }
        protected void startTest_Click(object sender, EventArgs e)
        {
            GenerateStudentTestID();
            DisplayTestQuestion();
           
        }
        private void DisplayTestQuestion()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetAllQuestionByTestIDSP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@testid";
            param.Value = Convert.ToInt32(Request.QueryString["ID"]);
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            SqlDataReader r = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(r);
            Repeater1.DataSource = d;
            Repeater1.DataBind();

            if (c != null)
            {
                c.Close();
            }
        }
        private void GenerateStudentTestID()
        {

            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("StudentTestSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@sid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Session["StudentID".ToString()]);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@testid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Request.QueryString["ID"]);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@bid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Session["BatchID"].ToString());
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@ssid", SqlDbType.VarChar);
            parm.Value = Session["SessionID"].ToString();
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@dat", SqlDbType.Date);
            parm.Value = DateTime.Parse(DateTime.Now.ToShortDateString()).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@sttime", SqlDbType.Time);
            parm.Value = DateTime.Parse(DateTime.Now.ToShortTimeString()).TimeOfDay;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);


            cmd.Parameters.Add("@sttestid", SqlDbType.VarChar, 50);
            cmd.Parameters["@sttestid"].Direction = ParameterDirection.Output;
            c.Open();
            cmd.ExecuteNonQuery();

            ViewState["sttestid"] = cmd.Parameters["@sttestid"].Value.ToString();
            
            c.Close();
           // return sttestid;
        }
        
        
        protected void ChangeAnswer_Click(object sender, CommandEventArgs e)
        {

            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label qor = (Label)item.FindControl("quesOrder");
                int qq = Convert.ToInt16(qor.Text);
                RadioButton r1 = (RadioButton)item.FindControl("ansA");
                RadioButton r2 = (RadioButton)item.FindControl("ansB");
                RadioButton r3 = (RadioButton)item.FindControl("ansC");
                RadioButton r4 = (RadioButton)item.FindControl("ansD");
                Button bt = (Button)item.FindControl("SaveAnswer");
                if (e.CommandName == "ChangeAnswerClick")
                {
                    string qorr = (string)e.CommandArgument; //question order value as save button command argument
                    int qorr1 = Convert.ToUInt16(qorr);
                    if (qq == qorr1)//if question order and save button command argument is equal
                    {
                        if (r1 != null && r1.Checked == true)
                        {

                            bt.Enabled = true;
                            bt.ForeColor = System.Drawing.Color.Red;

                        }
                        if (r2 != null && r2.Checked == true)
                        {

                            bt.Enabled = true;
                            bt.ForeColor = System.Drawing.Color.Red;
                        }
                        if (r3 != null && r3.Checked == true)
                        {

                            bt.Enabled = true;
                            bt.ForeColor = System.Drawing.Color.Red;
                        }
                        if (r4 != null && r4.Checked == true)
                        {

                            bt.Enabled = true;
                            bt.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
        protected void SaveAnswer_Click(object sender, CommandEventArgs e)
        {
           
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label qor = (Label)item.FindControl("quesOrder");
                int qq=Convert.ToInt16(qor.Text );
                RadioButton r1 = (RadioButton)item.FindControl("ansA");
                RadioButton r2 = (RadioButton)item.FindControl("ansB");
                RadioButton r3 = (RadioButton)item.FindControl("ansC");
                RadioButton r4 = (RadioButton)item.FindControl("ansD");
                Button bt = (Button)item.FindControl("SaveAnswer");
                if (e.CommandName == "SaveAnswerClick")
                {
                    string qorr = (string)e.CommandArgument; //question order value as save button command argument
                    int qorr1=Convert.ToUInt16 (qorr);
                    if (qq == qorr1)//if question order and save button command argument is equal
                    {
                       if (r1 != null && r1.Checked == true)
                        {
                            string ans = "A";
                            StudentTestResponse(qorr, ans);
                            bt.Enabled=false;
                            bt.ForeColor = System.Drawing.Color.Black;
                        }
                        if (r2 != null && r2.Checked == true)
                        {
                            string ans = "B";
                            StudentTestResponse(qorr, ans);
                            bt.Enabled = false;
                            bt.ForeColor = System.Drawing.Color.Black;
                        }
                        if (r3 != null && r3.Checked == true)
                        {
                            string ans = "C";
                            StudentTestResponse(qorr, ans);
                            bt.Enabled = false;
                            bt.ForeColor = System.Drawing.Color.Black;
                        }
                        if (r4 != null && r4.Checked == true)
                        {
                            string ans = "D";
                            StudentTestResponse(qorr, ans);
                            bt.Enabled = false;
                            bt.ForeColor = System.Drawing.Color.Black;
                        }
                       
                        
                    }
                }
            }

        }
        private void StudentTestResponse(string qorder,string ans) 
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("StudentTestResponseSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@sttestid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(ViewState["sttestid"]);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@qor", SqlDbType.Int);
            parm.Value = Convert .ToInt16(qorder);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@ans", SqlDbType.Char);
            parm.Value = Convert.ToChar(ans);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            
           
            c.Open();
            cmd.ExecuteNonQuery();

            c.Close();
        
        }
    }
}