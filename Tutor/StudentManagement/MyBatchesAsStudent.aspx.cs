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
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;
                string strBatchID = ((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString();
                int intBatchID = Convert.ToInt32(strBatchID);
                //javascript confirmation in gridview command field
                LinkButton deselect=(LinkButton )e.Row .Cells [9].Controls [0];
                deselect.OnClientClick ="if(!confirm('Are you sure you want to deselect this batch?'))return;";
                //SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                //c.Open();
                string cmdText = "select * from BatchDay where BatchID = " + intBatchID;


                gvBDetails.DataSource = GetBatchDetailsData(cmdText);
                gvBDetails.DataBind();
            }
        }

        protected void gvBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int batchid = 0;
            SqlConnection c=null;
            try
            {
                //string clientsidedate= HiddenField1.Value;
                //string dateJoined = DateTime.Parse(clientsidedate).ToShortDateString();  
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
               
                int studentID = Convert.ToInt32(Session["StudentID"].ToString());
                //  LabelConfirm0.Text = "studentid: " + Session["StudentID"].ToString();
                batchid = Convert.ToInt32(gvBatch.DataKeys[gvBatch.SelectedIndex].Value);
                SqlCommand cmd = new SqlCommand("VerifyBatchDeselectionStatus", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = batchid;
                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
                cmd.Parameters.Add("@stdate", SqlDbType.Date);
                cmd.Parameters["@stdate"].Direction = ParameterDirection.Output;
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Are you sure you want to proceed?');</script>");
              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "confirm('Are you sure you want to proceed?');", true);
                cmd.ExecuteNonQuery();
                string stDate = cmd.Parameters["@stdate"].Value.ToString();
                DateTime startDate = DateTime.Parse(stDate).Date;
                string today = DateTime.Now.ToShortDateString();
                //string today = null;
                ////reference master page content
                //HiddenField curDate = (HiddenField)Master.FindControl("CurrentDateInMasterPage");
                //if (curDate != null)
                //{
                //    today = curDate.Value;
                //}
                
                
                //string today = Session["ClientCurrentDate"].ToString();
                DateTime today1 = DateTime.Parse(today).Date;
            //    TimeSpan difference = startDate.Subtract(today1);
            //    double totaldays = difference.TotalDays;
                //Label1.Text = totaldays.ToString();
                //Label1.Visible = true;
                double totaldays = (startDate-today1).TotalDays;
                diff.Text = "total days: " + totaldays;
                if (totaldays > 7) {
                    DeselectStudent(batchid,studentID); 
                }
                else {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunc", "showHideMessageDiv();", true);
                    Label1.Text = "You cannot deselect Batch "+batchid +" now. You can only deselect a batch 7 days before the batch start date.";
                    Label1.Visible = true;
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

        private void DeselectStudent(int batchid, int studentID)
        {
            SqlConnection c = null;
            try
            {
                //string clientsidedate= HiddenField1.Value;
                //string dateJoined = DateTime.Parse(clientsidedate).ToShortDateString();  
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
              //  string dateJoined = DateTime.Now.ToShortDateString();
               // int studentID = Convert.ToInt32(Session["StudentID"].ToString());
                //  LabelConfirm0.Text = "studentid: " + Session["StudentID"].ToString();
             //   batchid = Convert.ToInt32(gvBatch.DataKeys[gvBatch.SelectedIndex].Value);
                SqlCommand cmd = new SqlCommand("DeselectBatchByStudent", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = batchid;
                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;

                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Are you sure you want to proceed?');</script>");
              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "confirm('Are you sure you want to proceed?');", true);
                cmd.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunc", "showHideMessageDiv();", true);

               
                Label1.Text = "You have been withdrawn from the batch.";
                Label1.Visible = true;
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

        }

        
    }
}