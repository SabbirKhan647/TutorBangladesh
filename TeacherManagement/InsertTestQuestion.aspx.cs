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
    public partial class InsertTestQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int teacherid = Convert.ToInt32(Session["TeacherID"]);

                SqlConnection c;
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT BatchID, BatchName from Batch where TeacherID = " + teacherid.ToString(), c);
                //2. Define parameter

                DataTable d = new DataTable();
                adapt.Fill(d);

                DropDownListBatchName.DataTextField = "BatchName"; DropDownListBatchName.DataValueField = "BatchID";
                DropDownListBatchName.DataSource = d; DropDownListBatchName.DataBind();

                if (c != null)
                {
                    c.Close();
                }
               
            }
        }
        private void BindTestIDDropDown()
        {
           
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTestIDbyTeacherID";

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tid";
            param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
            cmd.Parameters.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = Convert.ToInt32(DropDownListBatchName.SelectedValue);
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();


            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
            DropDownListTestID.DataTextField = "TestName"; DropDownListTestID.DataValueField = "TestID";
            DropDownListTestID.DataSource = dd; DropDownListTestID.DataBind();

         
            if (c != null)
            {
                c.Close();
            }

            
        }

        protected void btnGO_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                DropDownListQuesOrder.Items.Add(Convert.ToString(i));
            }
            for (float i = (float)0.5; i <= 15; i = i + (float)0.5)
            {

                DropDownListWorth.Items.Add(Convert.ToString(i));
            }
               BindTestIDDropDown();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
                   
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SaveTestQuestionSP";

            //2. Define parameter
            //SqlCommand cmd1 = new SqlCommand(insertString, c);
          //  cmd1.CommandType = CommandType.StoredProcedure;

          //  SqlParameter param = new SqlParameter();
            //param.ParameterName = "@testid";
            //param.Value = Convert.ToInt32(DropDownListTestID.SelectedValue);
            //cmd.Parameters.Add(param);
            //param = new SqlParameter();
            //param.ParameterName = "@qor";
            //param.Value = Convert.ToInt32(DropDownListQuesOrder.SelectedValue);
            //cmd.Parameters.Add(param);

            cmd.Parameters.Add("@testid", SqlDbType.Int).Value = Convert.ToInt32(DropDownListTestID.SelectedValue);
            cmd.Parameters.Add("@qor", SqlDbType.Int).Value = Convert.ToInt32(DropDownListQuesOrder.SelectedValue);
         
            cmd.Parameters.Add("@qus", SqlDbType.NVarChar).Value = txtQuestion.Text;
            cmd.Parameters.Add("@ansA", SqlDbType.NVarChar).Value = txtAnswerA.Text;
            cmd.Parameters.Add("@ansB", SqlDbType.NVarChar).Value = txtAnswerB.Text;
            cmd.Parameters.Add("@ansC", SqlDbType.NVarChar).Value = txtAnswerC.Text;
            cmd.Parameters.Add("@ansD", SqlDbType.NVarChar).Value = txtAnswerD.Text;
            cmd.Parameters.Add("@corAns", SqlDbType.Char).Value = Convert.ToChar(DropDownListCorrectAnswer.SelectedValue);
      
            cmd.Parameters.Add("@ansExp", SqlDbType.NVarChar).Value = txtAnswerExplanation.Text;
            cmd.Parameters.Add("@worth", SqlDbType.Float).Value = Convert.ToDecimal(DropDownListWorth.SelectedValue);
      
            //param = new SqlParameter();
            //param.ParameterName = "@qus";
            //param.Value = txtQuestion.Text;
            //cmd.Parameters.Add(param);

            //param = new SqlParameter();
            //param.ParameterName = "@ansA";
            //param.Value = txtAnswerA.Text;
            //cmd.Parameters.Add(param);

            //param = new SqlParameter();
            //param.ParameterName = "@ansB";
            //param.Value = txtAnswerB.Text;
            //cmd.Parameters.Add(param);
            
            //param = new SqlParameter();
            //param.ParameterName = "@ansC";
            //param.Value = txtAnswerC.Text;
            //cmd.Parameters.Add(param);
            
            //param = new SqlParameter();
            //param.ParameterName = "@ansD";
            //param.Value = txtAnswerD.Text;
            //cmd.Parameters.Add(param);
            
            //param = new SqlParameter();
            //param.ParameterName = "@corAns";
            //param.Value = Convert.ToChar(DropDownListCorrectAnswer.SelectedValue);
            //cmd.Parameters.Add(param);
            
            //param = new SqlParameter();
            //param.ParameterName = "@ansExp";
            //param.Value = txtAnswerExplanation.Text;
            //cmd.Parameters.Add(param);
            
            //param = new SqlParameter();
            //param.ParameterName = "@worth";
            //param.Value = Convert .ToDecimal (DropDownListWorth.SelectedValue );
            //cmd.Parameters.Add(param);
            
            
            
            cmd.ExecuteNonQuery();


            //SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            //DataTable dd = new DataTable();
            //adapt.Fill(dd);
            //DropDownListTestID.DataTextField = "TestName"; DropDownListTestID.DataValueField = "TestID";
            //DropDownListTestID.DataSource = dd; DropDownListTestID.DataBind();

         
            if (c != null)
            {
                c.Close();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtAnswerExplanation.Text = "";
            txtQuestion.Text = "";
            txtAnswerA.Text = "";
            txtAnswerB.Text = "";
            txtAnswerC.Text = "";
            txtAnswerD.Text = "";
            DropDownListWorth.DataBind();
            DropDownListQuesOrder.DataBind();
            DropDownListCorrectAnswer.DataBind();
           // DropDownListQuesOrder.
        }
    }
}