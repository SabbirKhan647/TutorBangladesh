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
    public partial class CreateNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                int teacherid = Convert.ToInt32(Session["TeacherId"].ToString());
                SqlConnection c;
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT BatchID, BatchName from Batch where TeacherID = " + teacherid.ToString(), c);
                //2. Define parameter

                DataTable d = new DataTable();
                adapt.Fill(d);

                DropDownListBatch.DataTextField = "BatchName"; DropDownListBatch.DataValueField = "BatchID";
                DropDownListBatch.DataSource = d; DropDownListBatch.DataBind();

                if (c != null)
                {
                    c.Close();
                }
            
            }
        }

        protected void btnGenerateNotice_Click(object sender, EventArgs e)
        {
            string clientsidedate = null;
            //reference master page content
            HiddenField curDate = (HiddenField)Master.FindControl("CurrentDateInMasterPage");
            if (curDate != null)
            {
                clientsidedate = curDate.Value;
            }

            string teacherid = Session["TeacherID"].ToString(); 
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NewNoticeSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(teacherid);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@bid", SqlDbType.Int);
            parm.Value = Convert .ToInt32 (DropDownListBatch.SelectedValue );
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@sub", SqlDbType.VarChar);
            parm.Value = txtSubject.Text ;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@msg", SqlDbType.VarChar);
            parm.Value = txtMessage .Text ;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@date", SqlDbType.DateTime);
            parm.Value = DateTime .Parse (txtDate.Text ).Date ;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

           
           
            c.Open();
            cmd.ExecuteNonQuery();
               
            lblMessage.Text = "Notice is posted successfully.";
         
            c.Close();
        }
        
    }
}