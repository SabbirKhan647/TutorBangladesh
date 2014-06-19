using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AjaxControlToolkit;
namespace Tutor
{
    public partial class GridViewPagerStyle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dataBind();
             //   this.GetBatchesPageWise(1);
            }
            //---------------------------------------------------------------------
            //Step 2: Event Handler for First, Previous, Next and Last Button Click
            //---------------------------------------------------------------------
            GridViewPagingControl.pagingClickArgs += new EventHandler(Paging_Click);

            //if (!IsPostBack)
            //{
            //  //  Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", "currentdate();", true);

            //    GetBatchData();
            //  // this.GetBatchesPageWise(1);

            //}
        }
        private void GetBatchData()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DisplayBatchInfo";

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tid";
            param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();



            SqlDataAdapter adapt = new SqlDataAdapter(cmd);


            DataTable d = new DataTable();
            adapt.Fill(d);
            if (d.Rows.Count > 0)
            {
                gvBatch.DataSource = d;
                gvBatch.DataBind();
                gvBatch.Visible = true;
             //   noData.Visible = false;
            }
            else
            {
             //   noData.Text = "No batch is created at this moment.";
             //   noData.Visible = true;
                gvBatch.Visible = false;

            }




            if (c != null)
            {
                c.Close();
            }

        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBatch.PageIndex = e.NewPageIndex;
            GetBatchData();
        }

        protected void gvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {

                GridViewRow rows = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int index = rows.RowIndex;
                GridViewRow row = gvBatch.Rows[index];
                ModalPopupExtender modalPopupExtender1 = (ModalPopupExtender)row.FindControl("mpe");

                Panel panelpopup = (Panel)row.FindControl("pnlPopup");

                Label lb = (Label)panelpopup.FindControl("lblTextPrompt");

                int batchid = Convert.ToInt32(e.CommandArgument.ToString());
                int totalEnrolledStudent = CheckBatchStatusBeforeRemove(batchid);
                if (totalEnrolledStudent > 0)
                {
                    lb.Text = "There are " + totalEnrolledStudent + " student(s) enrolled to the batch " + batchid + ". Are you sure you want to remove the batch " + batchid + "?";
                }
                else
                {
                    lb.Text = " Are you sure you want to remove the batch " + batchid + "?";
                }


                modalPopupExtender1.Show();


            }
         
        }
        // when modal popup OK button is pressed
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            int batchid = int.Parse((sender as Button).CommandArgument);
            RemoveBatchAndBatchDay(batchid);
            gvBatch.PageSize = 4;
            gvBatch.PageIndex = Convert.ToInt32(((TextBox)GridViewPagingControl.FindControl("SelectedPageNo")).Text) - 1;
            ////calling user control function
            //GridViewPaging uc1 = (GridViewPaging)LoadControl("~/Controls/GridViewPaging.ascx");
            //uc1.GetPageDisplaySummary();
          
            dataBind();
           

        }
        private void RemoveBatchAndBatchDay(int batchid)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("RemoveBatchAndBatchDaySP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = batchid;
            cmd.Parameters.Add(param);
            c.Open();
            cmd.ExecuteNonQuery();
            gvBatch.EditIndex = -1;

            if (c != null)
            {
                c.Close();
            }
            GetBatchData();
            //lblmessage.Text = "Batch " + batchid + " is removed successfully.";
            //lblmessage.Visible = true;
            //MessagePanel.Visible = true;
        }

        private int CheckBatchStatusBeforeRemove(int batchid)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("checkBatchStatusBeforeRemove", c);
            cmd.CommandType = CommandType.StoredProcedure;

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = batchid;
            cmd.Parameters.Add(param);

            cmd.Parameters.Add("@times", SqlDbType.Int);
            cmd.Parameters["@times"].Direction = ParameterDirection.Output;

            c.Open();
            cmd.ExecuteNonQuery();
            int times = Convert.ToInt16(cmd.Parameters["@times"].Value.ToString());
            if (c != null)
            {
                c.Close();
            }
            return times;
        }

        protected void gvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //disable ACTIVATE button if batch is already activated

                LinkButton lnkactivate = (LinkButton)e.Row.FindControl("linkbtnactivate");
                HiddenField hfstatusid = (HiddenField)e.Row.FindControl("hiddenfieldbatchstatus");
                Label enddate = (Label)e.Row.FindControl("lblEndDate");
                Label startdate = (Label)e.Row.FindControl("lblStartDate");
                Label batchname = (Label)e.Row.FindControl("lblBatchName");
                Label capacity = (Label)e.Row.FindControl("lblCapacity");
                Label seatleft = (Label)e.Row.FindControl("lblSeatLeft");

                DateTime enddate1 = DateTime.Parse(enddate.Text);
                int statusid = Convert.ToInt16(hfstatusid.Value.ToString());
                if (statusid == 2)
                {
                    lnkactivate.Enabled = false;
                    lnkactivate.ForeColor = System.Drawing.Color.Gray;
                }
                if (enddate1 < DateTime.Now)
                {
                    enddate.ForeColor = System.Drawing.Color.Red;
                    startdate.ForeColor = System.Drawing.Color.Red;
                    capacity.ForeColor = System.Drawing.Color.Red;
                    seatleft.ForeColor = System.Drawing.Color.Red;
                    batchname.ForeColor = System.Drawing.Color.Red;

                }
                // bind batchDay gridview data
                string strBatchID = gvBatch.DataKeys[e.Row.RowIndex].Value.ToString();
                int intBatchID = Convert.ToInt32(strBatchID);
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;

                string cmdText = "select * from BatchDay where BatchID = " + intBatchID;
                gvBDetails.DataSource = GetBatchDetailsData(cmdText);
                gvBDetails.DataBind();

            }
        }
        private static DataTable GetBatchDetailsData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString;

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
    
        // Step 3: Add Below Function which gets call on User Controls First, Previous, Next and Last Button Click
        //--------------------------------------------------------------------------------------------------------
        private void Paging_Click(object sender, EventArgs e)
        {
           //gvBatch.PageSize = Convert.ToInt32(((DropDownList)GridViewPagingControl.FindControl("PageRowSize")).SelectedValue);
           //gvBatch.PageIndex = Convert.ToInt32(((TextBox)GridViewPagingControl.FindControl("SelectedPageNo")).Text) - 1;
            gvBatch.PageSize = 4;
            gvBatch.PageIndex = Convert.ToInt32(((TextBox)GridViewPagingControl.FindControl("SelectedPageNo")).Text) - 1;
            dataBind();
           
        }
        private void dataBind()
        {
      
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            DataSet ds = new DataSet();
            SqlCommand cmdSql = new SqlCommand();
            cmdSql.Connection = c;
            cmdSql.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSql.CommandText = "GetBatchesPageWise";
                      
            cmdSql.Parameters.Add(new SqlParameter("@pageIndex",gvBatch.PageIndex));
            cmdSql.Parameters.Add(new SqlParameter("@pageSize",4));
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tid";
            param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
            cmdSql.Parameters.Add(param);
            c.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdSql);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                //---------------------------------------------------------------------------------
                //Step 5: Store No. of Total Rows in Hidden Field which is situated in User Control
                //---------------------------------------------------------------------------------
                ((HiddenField)GridViewPagingControl.FindControl("TotalRows")).Value = ds.Tables[0].Rows[0]["tRecordCount"].ToString();
            }

           gvBatch.DataSource = ds;
           gvBatch.DataBind();
           c.Close();
        }
    



    }
}