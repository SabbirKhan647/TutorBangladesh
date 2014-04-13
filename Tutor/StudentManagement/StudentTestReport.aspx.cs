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
    public partial class StudentTestReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  int id = Convert.ToInt32(Request.QueryString["ID"]);
                showid.Text = "Test ID: " + Request.QueryString["ID"];
               DisplayTestScore();
               DisplayExplanationForWrongAnswers();
            }
        }

        private void DisplayExplanationForWrongAnswers()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetExplanationForWrongAnswerSP", c);
            cmd.CommandType = CommandType.StoredProcedure;
           

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@sttestid";
            param.Value = Convert.ToInt32(Request.QueryString["ID"].ToString());
            cmd.Parameters.Add(param);

            c.Open();
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
        private void DisplayTestScore()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("StudentTestScoreSP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            

            //2. Define parameter
            SqlParameter parm = new SqlParameter("@sttestid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Request.QueryString["ID"].ToString());
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);



            cmd.Parameters.Add("@totalques", SqlDbType.Int);
            cmd.Parameters["@totalques"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@attempted", SqlDbType.Int);
            cmd.Parameters["@attempted"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@totalCorrect", SqlDbType.Int);
            cmd.Parameters["@totalCorrect"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@totalWrong", SqlDbType.Int);
            cmd.Parameters["@totalWrong"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@totalWorth", SqlDbType.Float);
            cmd.Parameters["@totalWorth"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@score", SqlDbType.Float);
            cmd.Parameters["@score"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@scorePercentage", SqlDbType.Float);
            cmd.Parameters["@scorePercentage"].Direction = ParameterDirection.Output;

            c.Open();
            cmd.ExecuteNonQuery();

            lblTQues.Text = cmd.Parameters["@totalques"].Value.ToString();
            lblAttempted.Text = cmd.Parameters["@attempted"].Value.ToString();
            lblCorrect.Text = cmd.Parameters["@totalCorrect"].Value.ToString();
            lblWrong.Text = cmd.Parameters["@totalWrong"].Value.ToString();
            lblWorth.Text = cmd.Parameters["@totalWorth"].Value.ToString(); 
            lblScore.Text = cmd.Parameters["@score"].Value.ToString();
            float scorepercent = Convert.ToSingle(cmd.Parameters["@scorePercentage"].Value.ToString());//fix if score is 0
            if (scorepercent > 0)
            {
                lblScorePercentage.Text = Math.Round((float)scorepercent, 2).ToString();
            }
            else
            {
                lblScorePercentage.Text = cmd.Parameters["@scorePercentage"].Value.ToString();
            }


            if (c != null)
            {
                c.Close();
            }
        }
    }
}