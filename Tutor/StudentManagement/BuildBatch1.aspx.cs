using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using AjaxControlToolkit;
namespace Tutor.StudentManagement
{
    public partial class BuildBatch1 : System.Web.UI.Page
    {
        SqlConnection c;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                Page.Header.DataBind();
             //   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", "currentdate();", true);
                SqlConnection c =new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
                DataTable d = new DataTable(); Adapter.Fill(d);
                DropDownSub.DataSource = d; DropDownSub.DataTextField = "SubName"; DropDownSub.DataValueField = "SubjectID";
                DropDownSub.DataBind();
                // To make it the first element at the list, use 0 index : 
                DropDownSub.Items.Insert(0, new ListItem("Select", string.Empty));

                Adapter = new SqlDataAdapter("select GradeID from Grade", c);
                d = new DataTable(); Adapter.Fill(d);
                DropDownGrade.DataSource = d; DropDownGrade.DataTextField = "GradeID"; DropDownGrade.DataValueField = "GradeID";
                DropDownGrade.DataBind();
                // To make it the first element at the list, use 0 index : 
                DropDownGrade.Items.Insert(0, new ListItem("Select", string.Empty));
                if (c != null)
                {
                    c.Close();
                }
               
            }

        }
        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            GetBatchData();
           
           
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
      
        protected void gvBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
           // int batchid = Convert.ToInt32(gvBatch.DataKeys[gvBatch.SelectedIndex].Value);
           //// string dateJoined = null;
           // //reference master page content
           // //HiddenField curDate = (HiddenField)Master.FindControl("CurrentDateInMasterPage");
           // //if (curDate != null)
           // //{
           // //    dateJoined = curDate.Value;
           // //}
           // try
           // {
           //     int found= SearchStudentinBatch(batchid);
           //     if (found == 0)
           //     {
           //         AddStudenttoBatch(batchid);
           //     }
           //     else
           //     {
           //         Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunc", "showHideMessageDiv();", true);
           //     //    Label1.Text = "You are already registered to the Batch "+batchid +".";
           //       //  Label1.Visible = true;
           //     }
            
            
           // }
           // catch (Exception ex)
           // {
           //     ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
           // }
           // finally
           // {
           //     if (c != null)
           //     {
           //         c.Close();
           //     }
           // }
            
        }

        private int SearchStudentinBatch(int batchid)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            string dateJoined = DateTime.Now.ToShortDateString();
            //   string dateJoined = Session["ClientCurrentDate"].ToString();
            int studentID = Convert.ToInt32(Session["StudentID"].ToString());
           
            SqlCommand cmd = new SqlCommand("SearchStudentinBatch", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = batchid;
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;

            cmd.Parameters.Add("@found", SqlDbType.Int);
            cmd.Parameters["@found"].Direction = ParameterDirection.Output;
            
            c.Open();
            cmd.ExecuteNonQuery();
            int found =Convert .ToInt16 (cmd.Parameters["@found"].Value.ToString());
                    
            c.Close();
            return found;
        }
        private void AddStudenttoBatch(int batchid)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
         
            
            string dateJoined = DateTime.Now.ToShortDateString();
            //   string dateJoined = Session["ClientCurrentDate"].ToString();
            int studentID = Convert.ToInt32(Session["StudentID"].ToString());
          
            SqlCommand cmd = new SqlCommand("BatchStu", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@b", SqlDbType.Int).Value = batchid;
            cmd.Parameters.Add("@s", SqlDbType.Int).Value = studentID;
            cmd.Parameters.Add("dat", SqlDbType.Date).Value = DateTime.Parse(dateJoined).Date; ;
                      
            c.Open();
            cmd.ExecuteNonQuery();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunc", "showHideMessageDiv();", true);

            Label1.Text = "Batch Registration Confirmed";
            Label1.Visible = true;
            MessagePanel.Visible = true;
            //send email to student and tutor
            //StudentJoinedEmail();
         //   Label1.Visible = true;
            c.Close();
        }
    


        protected void gvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //disable Join button if student is already joined to the batch

                LinkButton lnkjoin = (LinkButton)e.Row.FindControl("lnkJoin");
                string strBatchID = ((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString();
                int batchid = Convert.ToInt32(strBatchID);
                          
                int found = SearchStudentinBatch(batchid);
                if (found != 0)
                {
                    lnkjoin.Enabled = false;
                    lnkjoin.ForeColor = System.Drawing.Color.Gray;
                    lnkjoin.BackColor = System.Drawing.Color.GhostWhite;
                }
                //bind BatchDay Table
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;
              
                string cmdText = "select * from BatchDay where BatchID = " + batchid;


                gvBDetails.DataSource = GetBatchDetailsData(cmdText);
                gvBDetails.DataBind();
               }

               
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBatch.PageIndex = e.NewPageIndex;
            GetBatchData();
        }
        protected void GetBatchData()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);


            SqlCommand cmd = new SqlCommand("ViewBatch", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@subid", SqlDbType.Int).Value = Convert.ToInt32(DropDownSub.SelectedValue);
            cmd.Parameters.Add("@grd", SqlDbType.Int).Value = Convert.ToInt32(DropDownGrade.SelectedValue);
            c.Open();
            SqlDataReader r = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(r);
            //if (d.Rows.Count > 0)
           
                gvBatch.DataSource = d;
                gvBatch.DataBind();
                PanelTeacher.Visible = true;
                gvBatch.Visible = true;
              
            if (c != null)
            {
                c.Close();
            }
        }

        protected void gvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Join")
            {

                GridViewRow rows = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int index = rows.RowIndex;
                GridViewRow row = gvBatch.Rows[index];
                ModalPopupExtender modalPopupExtender1 = (ModalPopupExtender)row.FindControl("mpe");

                Panel panelpopup = (Panel)row.FindControl("pnlPopup");

                Label lb = (Label)panelpopup.FindControl("lblTextPrompt");

                int batchid = Convert.ToInt32(e.CommandArgument.ToString());
                //     int totalEnrolledStudent=CheckBatchStatusBeforeRemove(batchid);
                //     if (totalEnrolledStudent > 0)
                //     {
                //     lb.Text = "There are "+ totalEnrolledStudent + " students enrolled to the batch "+batchid+". Are you sure you want to remove the batch "+batchid +"?";
                //}
                //else
                //{
                lb.Text = " Are you sure you want to join the batch " + batchid + "?";
                //}


                modalPopupExtender1.Show();

            }
            if (e.CommandName == "ViewProfileinPopUp")
            {

                GridViewRow rows = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int index = rows.RowIndex;
                GridViewRow row = gvBatch.Rows[index];
                Label tutorid = (Label)row.FindControl("TeacherID");
                int teacherid = Convert.ToInt32(tutorid.Text);
                ModalPopupExtender modalPopupExtender1 = (ModalPopupExtender)row.FindControl("mpeProfile");

                Panel panelpopup = (Panel)row.FindControl("pnlProfilePopup");

                Label lb = (Label)panelpopup.FindControl("lbltutorName");
                Image img = (Image)panelpopup.FindControl("Image1");
                Guid userid = GetTutorUserID(teacherid);
                img.ImageUrl = "~/RetrieveImage.ashx?id=" + userid;
                int batchid = Convert.ToInt32(e.CommandArgument.ToString());
         //       int totalEnrolledStudent = CheckBatchStatusBeforeRemove(batchid);
                //if (totalEnrolledStudent > 0)
                //{
                //    lb.Text = "There are " + totalEnrolledStudent + " student(s) enrolled to the batch " + batchid + ". Are you sure you want to remove the batch " + batchid + "?";
                //}
                //else
                //{
                    lb.Text = " Are you sure you want to remove the batch " + batchid + "?";
           //     }


                modalPopupExtender1.Show();


            }
        }
        private Guid GetTutorUserID(int teacherid)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getUseridToViewTutorImage";

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tid";
            param.Value = teacherid;
            cmd.Parameters.Add(param);

            cmd.Parameters.Add("@userid", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@userid"].Direction = ParameterDirection.Output;
            c.Open();
            cmd.ExecuteNonQuery();
            string uid = cmd.Parameters["@userid"].Value.ToString();

            if (c != null)
            {
                c.Close();
            }
            Guid userid = new Guid(uid);
            return userid;

           

        }
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            int batchid = int.Parse((sender as Button).CommandArgument);
            AddStudenttoBatch(batchid);
        }
    }
}