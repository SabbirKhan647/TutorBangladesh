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
    public partial class CollapsableNestedGridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            gridViewBatch.DataSource =
            SelectData("SELECT top 3 BatchID, TeacherID FROM Batch1");
            gridViewBatch.DataBind();

        }
        private DataTable SelectData(string sqlQuery)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, c))
            {
                DataTable dt = new DataTable("Batch1");
                sqlDataAdapter.Fill(dt);
                if (c != null)
                {
                    c.Close();
                }
                return dt;
            }


        }

        protected void gridViewBatch_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //int batchID =Convert .ToInt32 (gridViewBatch.DataKeys[e.Row.RowIndex].Value.ToString());
            //GridView gvBatchDetails = (GridView)e.Row.FindControl("grdViewBatchDetails");
            //gvBatchDetails.DataSource = SelectData("SELECT top 3 BatchID FROM BatchDetails WHERE BatchID=" + batchID);
            //gvBatchDetails.DataBind();
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int batchID = Convert.ToInt32(gridViewBatch.DataKeys[e.Row.RowIndex].Value.ToString());
                Label1.Text = batchID.ToString();
                GridView gvBatchDetails = (GridView)e.Row.FindControl("grdViewBatchDetails");
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                string cmdText = "SELECT BatchID, Day,startTime, endTime FROM BatchDetails WHERE BatchID = " + batchID;
             //   cmdText += "batchID";

                SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
                DataTable dd = new DataTable();
                adapt.Fill(dd);
                gvBatchDetails.DataSource = dd;
                gvBatchDetails.DataBind();
                //  GridViewWorksheet.Visible = true;
                if (c != null)
                {
                    c.Close();
                }




                //        int batchID =Convert .ToInt32 (gridViewBatch.DataKeys[e.Row.RowIndex].Value.ToString());
                //        GridView gvBatchDetails = (GridView)e.Row.FindControl("grdViewBatchDetails");
                //        SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                //        c.Open();

                //        SqlCommand cmd = new SqlCommand("SELECT BatchID FROM BatchDetails WHERE BatchID= @bID",c);

                //        cmd.Parameters.AddWithValue("@bID", batchID);
                //        cmd.ExecuteReader();

                //        SqlDataAdapter adapt = new SqlDataAdapter(cmd, c);
                //        DataTable dd = new DataTable();
                //        adapt.Fill(dd);
                //        gvBatchDetails.DataSource = dd;

                //        gvBatchDetails.DataBind();









                //      //  gvBatchDetails.DataSource = SelectData("SELECT BatchID FROM BatchDetails WHERE BatchID='" + batchID + "'");
                ////	    gvBatchDetails.DataBind();
                //        if (c != null)
                //        {
                //            c.Close();
                //        }
            }

        }


    }
}
