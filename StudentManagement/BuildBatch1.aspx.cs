﻿using System;
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

                Adapter = new SqlDataAdapter("select GradeID from Grade", c);
                d = new DataTable(); Adapter.Fill(d);
                DropDownGrade.DataSource = d; DropDownGrade.DataTextField = "GradeID"; DropDownGrade.DataValueField = "GradeID";
                DropDownGrade.DataBind();
                if (c != null)
                {
                    c.Close();
                }
               
            }

        }
        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            PanelTeacher.Visible = true;
           
            c.Open();
            SqlCommand cmd = new SqlCommand("ViewBatch", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@subid", SqlDbType.Int).Value = Convert.ToInt32(DropDownSub.SelectedValue);
            cmd.Parameters.Add("@grd", SqlDbType.Int).Value = Convert.ToInt32(DropDownGrade.SelectedValue);
           
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
      
        protected void gvBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int batchid=0;
           // string dateJoined = null;
            //reference master page content
            //HiddenField curDate = (HiddenField)Master.FindControl("CurrentDateInMasterPage");
            //if (curDate != null)
            //{
            //    dateJoined = curDate.Value;
            //}
            try
            {
                
                 //string clientsidedate= HiddenField1.Value;
                 //string dateJoined = DateTime.Parse(clientsidedate).ToShortDateString();  
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                //TeacherSite1 tmaster = (TeacherSite1)Page.Master;
                //string dateJoined=tmaster.HiddenValue;
                string dateJoined = DateTime.Now.ToShortDateString();
             //   string dateJoined = Session["ClientCurrentDate"].ToString();
                int studentID = Convert.ToInt32(Session["StudentID"].ToString());
               // LabelConfirm0.Text = "studentid: " + Session["StudentID"].ToString();
                batchid = Convert.ToInt32(gvBatch.DataKeys[gvBatch.SelectedIndex].Value);
                SqlCommand cmd = new SqlCommand("BatchStu", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = batchid;
                cmd.Parameters.Add("@s", SqlDbType.Int).Value = studentID;
                cmd.Parameters.Add("dat", SqlDbType.Date).Value = DateTime.Parse(dateJoined).Date; ;
              
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Are you sure you want to proceed?');</script>");
                ScriptManager .RegisterStartupScript(this,this.GetType(),"script","confirm('Are you sure you want to proceed?');",true );
                cmd.ExecuteNonQuery();
                LabelConfirm.Text = "Batch Registration Confirmed";
                LabelConfirm.Visible = true;
              
               
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

    


        protected void gvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;
                string strBatchID = ((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString();
                int intBatchID = Convert.ToInt32(strBatchID);
                //SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                //c.Open();
                string cmdText = "select * from BatchDay where BatchID = " + intBatchID;


                gvBDetails.DataSource = GetBatchDetailsData(cmdText);
                gvBDetails.DataBind();
               }

               
        }
    }
}