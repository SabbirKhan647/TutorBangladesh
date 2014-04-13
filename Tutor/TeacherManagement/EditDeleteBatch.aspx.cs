using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tutor.TeacherManagement
{
    public partial class MyBatchesforTutor : System.Web.UI.Page
    {
      //  DataTable dd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            
        }

        private void LoadData()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            string cmdText = "SELECT BatchID, MaxStudent FROM Batch where ";
            cmdText += "TeacherID = " + Convert.ToInt32(Session["TeacherID"]);

            SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
            GridViewBatchByTutor.DataSource = dd;

            GridViewBatchByTutor.DataBind();
            // GridViewBatchByTutor.Visible = true;
            if (c != null)
            {
                c.Close();
            }

        }

     protected void GridViewBatchByTutor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            Label batchid = (Label)GridViewBatchByTutor.Rows[e.RowIndex].FindControl("lblBatchID");
            int b = Convert.ToInt32(batchid.Text);
         
            SqlCommand cmd = new SqlCommand("Delete from Batch where BatchID = @bid",c);
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = b;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            GridViewBatchByTutor.EditIndex = -1;
            LoadData();

            Label1.Text = "Record deleted successfully.";
            if (c != null)
            {
                c.Close();
            }
        }

        protected void GridViewBatchByTutor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void GridViewBatchByTutor_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //in gridview, column index starts from 1
            //hide rows got from select command, columns are configured in design mode, see html source
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[3].Visible = false;
         

        }

        protected void GridViewBatchByTutor_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridViewBatchByTutor.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void GridViewBatchByTutor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
          //  SqlCommand cmd = new SqlCommand();
          //  cmd.Connection = c;
            TextBox MaxStu = (TextBox)GridViewBatchByTutor.Rows[e.RowIndex].FindControl("txtMaxStu");
            int p = Convert.ToInt32(MaxStu.Text.Trim());

            Label batchid = (Label)GridViewBatchByTutor.Rows[e.RowIndex].FindControl("lblBatchID");
            int q = Convert.ToInt32(batchid.Text.Trim());
            SqlCommand cmd = new SqlCommand("Update Batch set MaxStudent= @max where BatchID = @bid", c);

            cmd.Parameters.AddWithValue("@max",p);
            cmd.Parameters.AddWithValue("@bid",q);
            
            cmd.ExecuteNonQuery();
            GridViewBatchByTutor.EditIndex = -1;
            LoadData();

            Label1.Text = "Record updated successfully.";
            if (c != null)
            {
                c.Close();
            }
        }

        protected void GridViewBatchByTutor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBatchByTutor.EditIndex = -1;
            LoadData();
        }

       
       
    }
}