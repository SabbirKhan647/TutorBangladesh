using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Tutor.Class;

namespace Tutor.TeacherManagement
{
    public partial class MyBatchesforTutor1 : System.Web.UI.Page
    {
        #region Variables
        string gvUniqueID = String.Empty;
        int gvNewPageIndex = 0;
        int gvEditIndex = -1;
        string gvSortExpr = String.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Page.Header.DataBind();
            //if (!IsPostBack)
            //{
                

           
               
            //}
    
            GridView1.DataSource = LoadData();
            GridView1.DataBind();

        }
     
        ////This procedure prepares the query to bind the child GridView
        private DataTable ChildDataSource(int intBatchid)
        {
           // int intbatchid = Convert.ToInt32(strBatchid);
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            string cmdText = "SELECT Day,startTime, endTime FROM BatchDetails WHERE BatchID = " + intBatchid;
            SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
          
            if (c != null)
            {
                c.Close();
            }
            return dd;
        }
        private DataTable  LoadData(){
                  
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

                //string cmdText = "SELECT BatchID, MaxStudent FROM Batch1 where ";
                //cmdText += "TeacherID = " + Convert.ToInt32(Session["TeacherID"]);

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dd = new DataTable();
                adapt.Fill(dd);
              
                if (c != null)
                {
                    c.Close();
                }
                return dd;
            
        }
        #region GridView1 Event Handlers
        ////This event occurs for each row
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strBatchId = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                int intBatchID = Convert.ToInt32(strBatchId);
                GridView gvBatchDetails=e.Row.FindControl("GridView2") as GridView;
              //  string cmdText = "SELECT Day,startTime, endTime FROM BatchDetails WHERE BatchID = " + intBatchID;
                string cmdText = "SELECT Day,startTime, endTime FROM BatchDetails";
                //SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
                //DataTable dd = new DataTable();
                //adapt.Fill(dd);
                gvBatchDetails.DataSource = GetData(cmdText);
              //  gvBatchDetails.DataSource = GetData(string.Format("select * from Orders where CustomerId={0}", intBatchID));
                gvBatchDetails.DataBind();
            }
          
        //    GridViewRow row = e.Row;
        ////    string strSort = string.Empty;

        //    // Make sure we aren't in header/footer rows
        //    if (row.DataItem == null)
        //    {
        //        return;
        //    }
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //Find Child GridView control
        //         GridView gv = new GridView();
        //         gv = (GridView)row.FindControl("GridView2");
        //         string strbatchId = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
        //         int intBatchId = Convert.ToInt32(strbatchId);
               
        ////        //// Prepare the query for Child GridView by passing the batch ID of the parent row
        //         DataTable dd1 = ChildDataSource(intBatchId);
        //       //  DataTable dd1 = ChildDataSource(((DataRowView)e.Row.DataItem)["batchid"].ToString());
        //         gv.DataSource = dd1;
        //         gv.DataBind();
        //         //GridView1.DataSource = LoadData();
        //         //GridView1.DataBind();
        //        //Add delete confirmation message for Customer
        //        LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteCust");
        //        l.Attributes.Add("onclick", "javascript:return " +
        //        "confirm('Are you sure you want to delete this Batch " +
        //        DataBinder.Eval(e.Row.DataItem, "batchid") + "')");
             
        //        GridView1.DataSource = LoadData();
        //        GridView1.DataBind();
        //        //Expand the Child grid
        //        ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + ((DataRowView)e.Row.DataItem)["batchid"] + "','one');</script>");


        #endregion

        //   }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        //     //Check if Add button clicked
        //if (e.CommandName == "AddCustomer")
        //{
        //    try
        //    {
        //        //Get the values stored in the text boxes
        //        string strCompanyName = ((TextBox)GridView1.FooterRow.FindControl("txtCompanyName")).Text;
        //        string strContactName = ((TextBox)GridView1.FooterRow.FindControl("txtContactName")).Text;
        //        string strContactTitle = ((TextBox)GridView1.FooterRow.FindControl("txtContactTitle")).Text;
        //        string strAddress = ((TextBox)GridView1.FooterRow.FindControl("txtAddress")).Text;
        //        string strCustomerID = ((TextBox)GridView1.FooterRow.FindControl("txtCustomerID")).Text;
        //        int intteacherid = Convert.ToInt32(Session["TeacherID"].ToString());
        //       // Session["subid"] = DropDownListSubject.SelectedValue;
        //        int subid = Convert.ToInt32(Session["subid"]);
        //        //  int gradeid=Convert.ToInt32 (DropDownListGrade.SelectedValue );
        //       // Session["gradeid"] = DropDownListGrade.SelectedValue;
        //        int gradeid = Convert.ToInt32(Session["gradeid"]);
        //        string maxStu = DropDownNoOfStu.SelectedItem.Text;
        //        Session["dateCreated"] = DateTime.Now.ToShortDateString();
        //        Session["timeCreated"] = DateTime.Now.ToShortTimeString();
        //        string dateCreated = Session["dateCreated"].ToString();
        //        string timeCreated = Session["timeCreated"].ToString(); ;
        //        string stDate = Calendar1.SelectedDate.ToShortDateString();
        //        //Prepare the Insert Command of the DataSource control
        //         Teacher.CreateBatch(teacherid, dateCreated, timeCreated,subid, gradeid, stDate, maxStu);
        //         ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Batch added successfully');</script>");

        //         //Re bind the grid to refresh the data
        //         GridView1.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        //    }
        //}
        }
        private static DataTable GetData(string query)
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
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //filling footer dropdownlist with subject name
                DropDownList drSubject = (DropDownList)GridView1.FooterRow.FindControl("DropDownListSubject");
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
                DataTable d = new DataTable(); Adapter.Fill(d);
                drSubject.DataSource = d; drSubject.DataTextField = "SubName"; drSubject.DataValueField = "SubjectID";
                drSubject.DataBind();
                drSubject .Items .Insert (0,new ListItem ("Select Subject","0"));
                DropDownList drGrade = (DropDownList)GridView1.FooterRow.FindControl("DropDownListGrade");
                Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
                d = new DataTable(); Adapter.Fill(d);
                drGrade.DataSource = d; drGrade.DataTextField = "GradeName"; drGrade.DataValueField = "GradeID";
                drGrade.DataBind();
                drGrade .Items .Insert (0,new ListItem ("Select Grade","0"));
                if (c != null)
                {
                    c.Close();
                }
            
        }

        }
    }
