using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Tutor.Account
{
    public partial class SelectRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Tutor")
            {
                Roles.AddUserToRole(HttpContext.Current.User.Identity.Name, "Tutor");
               //insert tutor id into teacher table
                ////get userid
                MembershipUser userInfo = Membership.GetUser();
                Guid userid = (Guid)userInfo.ProviderUserKey;

                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                String insertString = "GenerateTutorID";

                SqlCommand cmd1 = new SqlCommand(insertString, c);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters .Add ("@usid",SqlDbType.UniqueIdentifier).Value  =userid;
               
                //3. Call ExecuteNonQuery to send the command
                cmd1.ExecuteNonQuery();

                //5. Close the connection
                if (c != null)
                {
                    c.Close();
                }
                
                Response.Redirect("~/TeacherManagement/TeacherHome.aspx");
            }
            if (DropDownList1.SelectedValue == "Student")
            {
                Roles.AddUserToRole(HttpContext.Current.User.Identity.Name, "Student");
                ////get userid
                MembershipUser userInfo = Membership.GetUser();
                Guid userid = (Guid)userInfo.ProviderUserKey;

                //insert tutor id into teacher table
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                String insertString = "GenerateStudentID";

                SqlCommand cmd1 = new SqlCommand(insertString, c);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@usid", SqlDbType.UniqueIdentifier).Value = userid;

                //3. Call ExecuteNonQuery to send the command
                cmd1.ExecuteNonQuery();

                //5. Close the connection
                if (c != null)
                {
                    c.Close();
                }
                Response.Redirect("~/StudentManagement/myTutor.aspx");
            }
        }
    }
}
