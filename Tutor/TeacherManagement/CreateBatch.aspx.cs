using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Tutor.Class;
using System.Net;
namespace Tutor.TeacherManagement
{
    public partial class CreateBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
       //     Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", "currentdate();", true);
        
            // runs onload function
            //HtmlGenericControl body = this.Master.FindControl("body") as HtmlGenericControl;
            //body.Attributes.Add("onLoad", "currentdate();");

            Label2.Visible = false;
              SqlConnection c;

              for (int i = 1; i <= 30; i++)
              {
                  string j = Convert.ToString(i);
                  DropDownNoOfStu.Items.Add(j);
              }
              // To make it the first element at the list, use 0 index : 
              DropDownNoOfStu.Items.Insert(0, new ListItem("Select", string.Empty)); 


        if (!IsPostBack)
        {
           c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
                DataTable d = new DataTable(); Adapter.Fill(d);
                DropDownListSubject.DataSource = d; DropDownListSubject.DataTextField = "SubName"; 
                DropDownListSubject.DataValueField = "SubjectID";
                DropDownListSubject.DataBind();
                // To make it the first element at the list, use 0 index : 
                DropDownListSubject.Items.Insert(0, new ListItem("Select", string.Empty)); 

                Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
                d = new DataTable(); Adapter.Fill(d);
                DropDownListGrade.DataSource = d; DropDownListGrade.DataTextField = "GradeName"; 
                DropDownListGrade.DataValueField = "GradeID";
                DropDownListGrade.DataBind();
                // To make it the first element at the list, use 0 index : 
                DropDownListGrade.Items.Insert(0, new ListItem("Select", string.Empty)); 
                if (c != null)
                {
                    c.Close();
                }
            }
    
        }

        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            string clientsidedate=null;
            //reference master page content
            HiddenField curDate = (HiddenField)Master.FindControl("CurrentDateInMasterPage");
            if(curDate !=null ){
                clientsidedate = curDate.Value;
            }
            
            string teacherid = Session["TeacherID"].ToString(); 
           
             string maxStu=DropDownNoOfStu.SelectedItem .Text ;
            // string clientsidedate= HiddenField1.Value;
           //  string clientsidedate = Session["ClientCurrentDate"].ToString ();
             string dateCreated = DateTime.Parse(clientsidedate).ToShortDateString();  
     
            string timeCreated = DateTime.Now.ToShortTimeString();
            
            string stDate = txtStartDate.Text;
      
            // get batch name from stored procedure
           
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("createBatchSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(teacherid);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@d", SqlDbType.Date);
            parm.Value = DateTime.Parse(dateCreated).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@t", SqlDbType.Time);
            parm.Value = DateTime.Parse(timeCreated).TimeOfDay;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@sid", SqlDbType.Int);
            parm.Value = DropDownListSubject.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@gid", SqlDbType.Int);
            parm.Value = DropDownListGrade.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@ms", SqlDbType.Int);
            parm.Value = Convert.ToDouble(maxStu);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@sd", SqlDbType.Date);
            parm.Value = DateTime.Parse(stDate).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            cmd.Parameters.Add("@BName", SqlDbType.VarChar, 50);
            cmd.Parameters["@BName"].Direction = ParameterDirection.Output;
            c.Open();
            cmd.ExecuteNonQuery();
               
            Label2.Text = "Batch has been created successfully.";
           Label11.Text="The Batch Name is: " + cmd.Parameters["@BName"].Value.ToString();
         
           
            Label2.Visible = true;
            Label11.Visible = true;
            HyperLink1.Visible = true;
            c.Close();
        }
        }
    }
