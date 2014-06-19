using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AjaxControlToolkit;
namespace Tutor.StudentManagement
{
    public partial class MyBatchesAsStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              Page.Header.DataBind();
              if (!IsPostBack)
              {
                  LoadGridView();
                 
              }
        }

        private void LoadGridView()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand("MyBatchesAsStudent", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@studentid", SqlDbType.Int).Value = Convert.ToInt32(Session["StudentID"].ToString());

            SqlDataReader r = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(r);
            gvBatch.DataSource = d; gvBatch.DataBind();
            if (c != null)
            {
                c.Close();
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

        protected void gvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // bind batchDay gridview data
                string strBatchID = gvBatch.DataKeys[e.Row.RowIndex].Value.ToString();
                int intBatchID = Convert.ToInt32(strBatchID);
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;

                string cmdText = "select * from BatchDay where BatchID = " + intBatchID;
                gvBDetails.DataSource = GetBatchDetailsData(cmdText);
                gvBDetails.DataBind();

                //GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;
                //string strBatchID = ((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString();
                //int intBatchID = Convert.ToInt32(strBatchID);
                ////javascript confirmation in gridview command field
                ////LinkButton deselect = (LinkButton)e.Row.Cells[8].Controls[0];
                ////deselect.OnClientClick = "if(!confirm('Are you sure you want to deselect this batch?'))return;";



                ////SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                ////c.Open();
                //string cmdText = "select * from BatchDay where BatchID = " + intBatchID;


                //gvBDetails.DataSource = GetBatchDetailsData(cmdText);
                //gvBDetails.DataBind();
            }
        }

        protected double CheckStatusBeforeWithdraw(int batchid)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
          

            int studentID = Convert.ToInt32(Session["StudentID"].ToString());
            //  LabelConfirm0.Text = "studentid: " + Session["StudentID"].ToString();
            //       batchid = Convert.ToInt32(gvBatch.DataKeys[gvBatch.SelectedIndex].Value);
            SqlCommand cmd = new SqlCommand("VerifyBatchDeselectionStatus", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = batchid;
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            cmd.Parameters.Add("@stdate", SqlDbType.Date);
            cmd.Parameters["@stdate"].Direction = ParameterDirection.Output;
            c.Open();
            cmd.ExecuteNonQuery();
            string stDate = cmd.Parameters["@stdate"].Value.ToString();
            DateTime startDate = DateTime.Parse(stDate).Date;
            string today = DateTime.Now.ToShortDateString();
            //string today = Session["ClientCurrentDate"].ToString();
            DateTime today1 = DateTime.Parse(today).Date;

            double totaldays = (startDate - today1).TotalDays;

            return totaldays;
        }
        protected void WithdrawFromBatch(object sender, EventArgs e)
        {
         //   int batchid = 0;
            int batchid = int.Parse((sender as LinkButton).CommandArgument);
            SqlConnection c = null;
            try
            {
               
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();

                int studentID = Convert.ToInt32(Session["StudentID"].ToString());
                //  LabelConfirm0.Text = "studentid: " + Session["StudentID"].ToString();
         //       batchid = Convert.ToInt32(gvBatch.DataKeys[gvBatch.SelectedIndex].Value);
                SqlCommand cmd = new SqlCommand("VerifyBatchDeselectionStatus", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = batchid;
                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
                cmd.Parameters.Add("@stdate", SqlDbType.Date);
                cmd.Parameters["@stdate"].Direction = ParameterDirection.Output;
            
                cmd.ExecuteNonQuery();
                string stDate = cmd.Parameters["@stdate"].Value.ToString();
                DateTime startDate = DateTime.Parse(stDate).Date;
                string today = DateTime.Now.ToShortDateString();
               


                //string today = Session["ClientCurrentDate"].ToString();
                DateTime today1 = DateTime.Parse(today).Date;
              
                double totaldays = (startDate - today1).TotalDays;
                diff.Text = "total days: " + totaldays;
                if (totaldays > 7)
                {
                    DeselectStudent(batchid, studentID);
                }
                else
                {              
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunc", "showHideMessageDiv();", true);
                   //Label1.Text = "You cannot deselect Batch " + batchid + " now. You can only deselect a batch 7 days before the batch start date.";
               //    Label1.Visible = true;
                
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
            }
            finally
            {
                if (c != null)
                {
                    c.Close();
                }
            }
         
        }
        protected void gvBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void DeselectStudent(int batchid, int studentID)
        {
            SqlConnection c = null;
            try
            {
              
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
            
                SqlCommand cmd = new SqlCommand("DeselectBatchByStudent", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = batchid;
                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;

             
                cmd.ExecuteNonQuery();
              
                LoadGridView();
                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
            }
            finally
            {
                if (c != null)
                {
                    c.Close();
                }
            }
        }

        protected void gvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Withdraw")
            {

                GridViewRow rows = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int index = rows.RowIndex;
                GridViewRow row = gvBatch.Rows[index];
                ModalPopupExtender modalPopupExtender1 = (ModalPopupExtender)row.FindControl("mpe");

                Panel panelpopup = (Panel)row.FindControl("pnlPopup");

                Label lb = (Label)panelpopup.FindControl("lblTextPrompt");

                int batchid = Convert.ToInt32(e.CommandArgument.ToString());
              
                
                double totalDaysToStartBatch=CheckStatusBeforeWithdraw(batchid);
                if (totalDaysToStartBatch > 7)
                {
                    lb.Text = "Are you sure you want to withdraw from the batch " + batchid + "?"+"<br /><br/>"+ "N.B. Student can withdraw from batch 7 days before the batch start date.";
                }
                else
                {
                    lb.Text = "You cannot withdraw from the batch "+batchid+" now. The batch will start in less than 7 days."+"<br /><br/>"+ "N.B. Student can withdraw from batch 7 days before the batch start date.";
                }
              


                modalPopupExtender1.Show();


            }
           
        }
        // when modal popup OK button is pressed
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            int batchid = int.Parse((sender as Button).CommandArgument);
            int studentID = Convert.ToInt32(Session["StudentID"].ToString());
            DeselectStudent(batchid, studentID);

        }
     
     
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBatch.PageIndex = e.NewPageIndex;
            LoadGridView();
        }

        
    }
}