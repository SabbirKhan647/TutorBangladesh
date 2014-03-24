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
    public partial class PreviewTestQuestion : System.Web.UI.Page
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
        protected void SaveAnswer_Click(object sender, EventArgs e)
        {
            ll.Text = "save button works";
            foreach (RepeaterItem item in Repeater1.Items) {
                RadioButton r1 = (RadioButton)item.FindControl("ansA");
                RadioButton r2 = (RadioButton)item.FindControl("ansB");
                RadioButton r3 = (RadioButton)item.FindControl("ansC");
                RadioButton r4 = (RadioButton)item.FindControl("ansD");
                if (r1 !=null && r1.Checked == true) { ll.Text = "You pressed: A "; }
                if (r2 != null && r2.Checked == true) { ll.Text = "You pressed: B "; }
                if (r3 != null && r3.Checked == true) { ll.Text = "You pressed: C"; }
                if (r4 != null && r4.Checked == true) { ll.Text = "You pressed: D "; }
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
        private void PreviewTestQuestionByTestID()
        {
            /////////
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetAllQuestionByTestIDSP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@testid";
            param.Value = Convert.ToInt32(DropDownListTestID.SelectedValue);
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
        protected void btnGO_Click(object sender, EventArgs e)
        {
          
            BindTestIDDropDown();

        }
        protected void btnPreviewTestQuestion_Click(object sender, EventArgs e)
        {

            PreviewTestQuestionByTestID();

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

       
    }
}