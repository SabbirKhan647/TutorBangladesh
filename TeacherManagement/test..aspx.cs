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
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (!IsPostBack)
            {
                string cmdText = "select top 4 * from Batch1 ";
             
                gvBatch.DataSource = GetData(cmdText);
                gvBatch.DataBind();
            }
        }
        #region functions
        private static DataTable GetData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString;
            //   SqlConnection con = new SqlConnection(@"Data Source=OWNER-KABIR\SQLSERVER2012;Initial Catalog=Northwind;Integrated Security=True");
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strBatchID = gvBatch.DataKeys[e.Row.RowIndex].Value.ToString();
                int intBatchID = Convert.ToInt32(strBatchID);
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;
                string cmdText = "select * from BatchDetails where BatchID = "+intBatchID ;
                gvBDetails.DataSource = GetData(cmdText);
                gvBDetails.DataBind();
            }
           
        }

     
        private void LoadData()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            //string cmdText = "SELECT BatchID, MaxStudent FROM Batch1 where ";
            //cmdText += "TeacherID = " + Convert.ToInt32(Session["TeacherID"]);
            string cmdText = "select * from batch1";
            SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
            gvBatch.DataSource = dd;
            gvBatch.DataBind();
          
            if (c != null)
            {
                c.Close();
            }

        }

        #endregion




        #region GridView Batch Event Handlers
        protected void gvBatch_DataBound(object sender, EventArgs e)
        {
            //filling footer dropdownlist with subject name
            DropDownList drSubject = (DropDownList)gvBatch.FooterRow.FindControl("DropDownListSubject");
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
            DataTable d = new DataTable(); Adapter.Fill(d);
            drSubject.DataSource = d; drSubject.DataTextField = "SubName"; drSubject.DataValueField = "SubjectID";
            drSubject.DataBind();
            drSubject.Items.Insert(0, new ListItem("Select Subject", "0"));
            //DropDownList drGrade = (DropDownList)gvBatch.FooterRow.FindControl("DropDownListGrade");
            //Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
            //d = new DataTable(); Adapter.Fill(d);
            //drGrade.DataSource = d; drGrade.DataTextField = "GradeName"; drGrade.DataValueField = "GradeID";
            //drGrade.DataBind();
            //drGrade.Items.Insert(0, new ListItem("Select Grade", "0"));
            if (c != null)
            {
                c.Close();
            }

        }
      
       
        protected void gvBatch_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBatch.EditIndex = e.NewEditIndex;
            LoadData();
        }
        protected void gvBatch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();

            string strBatchID = gvBatch.DataKeys[e.RowIndex].Value.ToString();
            int intBatchID = Convert.ToInt32(strBatchID);
            SqlCommand cmd = new SqlCommand("Delete from Batch1 where BatchID = @bid", c);
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = intBatchID;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            gvBatch.EditIndex = -1;

            LoadData();

            //   Label1.Text = "Record deleted successfully.";
            if (c != null)
            {
                c.Close();
            }
        }

        protected void gvBatch_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBatch.EditIndex = -1;
            LoadData();
        }
        //fire nested gridview events from parent gridview
        protected void gvBatch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;
                // gvBDetails.RowCommand += new GridViewCommandEventHandler(gvBatchDetails_RowEditing);
                // gvBDetails.RowEditing += new GridViewCommandEventHandler(gvBDetails_RowEditing);
                gvBDetails.RowEditing += new GridViewEditEventHandler(gvBDetails_RowEditing);
                //   gvBDetails.RowDeleting += new GridViewDeleteEventHandler(gvBDetails_RowDeleting);
                gvBDetails.RowCancelingEdit += new GridViewCancelEditEventHandler(gvBDetails_RowCancelingEdit);
                gvBDetails.RowCommand += new GridViewCommandEventHandler(gvBDetails_RowCommand);

            }
        }
      
        #endregion
        #region GridView BatchDetails Event Handlers
        protected void gvBDetails_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

        }
        protected void gvBDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView gvBDetails = (GridView)sender;
            gvBDetails.EditIndex = -1;
            string cmdText = "select * from BatchDetails ";
            gvBDetails.DataSource = GetData(cmdText);
            gvBDetails.DataBind();
            gvBDetails.Visible = true;
            // LoadData();
        }

        protected void gvBDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label1.Text = "edit button is working";
            GridView gvBDetails = (GridView)sender;
            gvBDetails.EditIndex = e.NewEditIndex;
            string cmdText = "select * from BatchDetails ";
            gvBDetails.DataSource = GetData(cmdText);
            gvBDetails.DataBind();
            gvBDetails.Visible = true;
            // LoadData();
        }
        #endregion
    }
}
