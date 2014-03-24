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
namespace Tutor
{
    public partial class TeacherSite1 : System.Web.UI.MasterPage
    {
        public String HiddenValue
        {
            get { return CurrentDateInMasterPage.Value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Header.DataBind();
              
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", "currentdate();", true);
             //   Session["ClientCurrentDate"] = CurrentDateInMasterPage.Value;
              
                //send notification to user if profile is not updated
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("IsTutorProfileUpdated", c);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
                parm.Value = Convert.ToInt32(Session["teacherID"].ToString());
                parm.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm);

                cmd.Parameters.Add("@result", SqlDbType.Int);
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                c.Open();
                cmd.ExecuteNonQuery();

                int re = Convert.ToInt16(cmd.Parameters["@result"].Value.ToString());
                if (re == 0)
                {
                    //  notificationImage.Visible = true;
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "myKey", "ShowNotificationImage();", true);
                }
                else
                {
                    // notificationImage.Visible = false;
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "myKey", "HideNotificationImage();", true);
                }
                c.Close();
            }
        }
    }
}