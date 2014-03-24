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
    public partial class collapse2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            gvParent.DataSource =
            SelectData("SELECT top 3 BatchID, TeacherID FROM Batch1");
            gvParent.DataBind();
        }
        private DataTable SelectData(string sqlQuery)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, c))
            {
                DataTable dt = new DataTable("Batch1");
                sqlDataAdapter.Fill(dt);
                return dt;
            }
        }
        protected void gvParent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dtChildTable = GetChildTableData();
                DataTable dtCloneChildTable = dtChildTable.Clone();
                Image img = (Image)e.Row.Cells[0].FindControl("img1");
                Literal ltrl = (Literal)e.Row.FindControl("lit1");
                ltrl.Text = ltrl.Text.Replace("trCollapseGrid", "trCollapseGrid" + e.Row.RowIndex.ToString());
                string str = "trCollapseGrid" + e.Row.RowIndex.ToString();
                e.Row.Cells[0].Attributes.Add("OnClick", "OpenTable('" + str + "','" + img.ClientID + "')");
                e.Row.Cells[0].RowSpan = 1;
                System.Web.UI.WebControls.GridView gvChild = (System.Web.UI.WebControls.GridView)e.Row.FindControl("gvChild");
                int bid = Convert.ToInt32(e.Row.Cells[1].Text);
             //   DataRow[] gvChildRows = dtChildTable.Select("BatchID = " + bid);
                DataRow[] gvChildRows = dtChildTable.Select();
                foreach (DataRow gvChildRow in gvChildRows)
                {
                    dtCloneChildTable.ImportRow(gvChildRow);
                }
                gvChild.DataSource = dtCloneChildTable;
                gvChild.DataBind();
            }
        }
        private DataTable GetChildTableData() 
        {
            //int batchID = Convert.ToInt32(gridViewBatch.DataKeys[e.Row.RowIndex].Value.ToString());
            //Label1.Text = batchID.ToString();
          //  GridView gvBatchDetails = (GridView)e.Row.FindControl("grdViewBatchDetails");
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            string cmdText = "SELECT BatchID, Day,startTime, endTime FROM BatchDetails ";
            //   cmdText += "batchID";

            SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            DataTable dd = new DataTable();
            return dd;     
      
        }

    }
}