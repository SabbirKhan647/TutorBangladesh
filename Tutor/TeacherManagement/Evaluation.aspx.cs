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
    public partial class Evaluation : System.Web.UI.Page
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
              protected void btnGO_Click(object sender, EventArgs e)
        {
          
            BindTestIDDropDown();

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
              protected void btnPreviewTestQuestion_Click(object sender, EventArgs e)
              {
                  DisplayTestResultByBatch();
                  

              }

              private void DisplayTestResultByBatch()
              {
                  SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                  SqlCommand cmd = new SqlCommand("DisplayOneTestResultByBatchSP", c);
                  cmd.CommandType = CommandType.StoredProcedure;

                  SqlParameter parm = new SqlParameter("@batchid", SqlDbType.Int);
                  parm.Value = Convert.ToInt32(DropDownListBatchName.SelectedValue);
                  parm.Direction = ParameterDirection.Input;
                  cmd.Parameters.Add(parm);

                  parm = new SqlParameter("@testid", SqlDbType.Int);
                  parm.Value = Convert.ToInt32(DropDownListTestID.SelectedValue);
                  parm.Direction = ParameterDirection.Input;
                  cmd.Parameters.Add(parm);

                  cmd.Parameters.Add("@totalStudent", SqlDbType.Int);
                  cmd.Parameters["@totalStudent"].Direction = ParameterDirection.Output;

                  cmd.Parameters.Add("@totalPresent", SqlDbType.Int);
                  cmd.Parameters["@totalPresent"].Direction = ParameterDirection.Output;

                  cmd.Parameters.Add("@totalAbsent", SqlDbType.Int);
                  cmd.Parameters["@totalAbsent"].Direction = ParameterDirection.Output;

                  cmd.Parameters.Add("@totalQues", SqlDbType.Int);
                  cmd.Parameters["@totalQues"].Direction = ParameterDirection.Output;

                  cmd.Parameters.Add("@totalWorth", SqlDbType.Float);
                  cmd.Parameters["@totalWorth"].Direction = ParameterDirection.Output;

                  cmd.Parameters.Add("@batchAvgPercent", SqlDbType.Float);
                  cmd.Parameters["@batchAvgPercent"].Direction = ParameterDirection.Output;

                  cmd.Parameters.Add("@batchMax", SqlDbType.Float);
                  cmd.Parameters["@batchMax"].Direction = ParameterDirection.Output;


                  c.Open();
                  cmd.ExecuteNonQuery();

                  lbltStu.Text = cmd.Parameters["@totalStudent"].Value.ToString();
                  lbltPresnt.Text = cmd.Parameters["@totalPresent"].Value.ToString();
                  lbltAbsent.Text = cmd.Parameters["@totalAbsent"].Value.ToString();
                  lblTQues.Text = cmd.Parameters["@totalQues"].Value.ToString();
                  lbltMarks.Text = cmd.Parameters["@totalWorth"].Value.ToString();
                  string r = cmd.Parameters["@batchAvgPercent"].Value.ToString();
                  if (!String.IsNullOrEmpty (r))
                  {
                      float p = Convert.ToSingle(cmd.Parameters["@batchAvgPercent"].Value.ToString());
                      lblAvg.Text = Math.Round(p, 2).ToString();
                  }
                  else
                  {
                      lblAvg.Text = "0.00";
                  }
                  string s = cmd.Parameters["@batchMax"].Value.ToString();
                  if (!String.IsNullOrEmpty(s))
                  {
                      lblhighMark.Text = cmd.Parameters["@batchMax"].Value.ToString();
                  }
                  else
                  {
                      lblhighMark.Text = "0.00";
                  }
                 
                  c.Close();
              }

    }
}