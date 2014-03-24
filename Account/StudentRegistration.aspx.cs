using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Configuration;
using System.Text.RegularExpressions;
namespace Tutor.Account
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        SqlConnection c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //fill grade dropdown list
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                SqlDataAdapter Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
                DataTable d = new DataTable(); Adapter.Fill(d);
                drGrade.DataSource = d; drGrade.DataTextField = "GradeName"; drGrade.DataValueField = "GradeID";
                drGrade.DataBind();
                if (c != null)
                {
                    c.Close();
                }

            }
        }
        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {

            // string s = roleDropDown.SelectedValue;
            if (!Roles.IsUserInRole("Student"))
            {
                Roles.AddUserToRole(CreateUserWizard1.UserName, "Student");
            }
            //roleDropDown.Visible = false;
            //Label1.Visible = false;


            //insert data to the userDetails table
            TextBox UserNameTextBox =
            (TextBox)CreateUserWizardStep2.ContentTemplateContainer.FindControl("UserName");

            SqlDataSource DataSource =
                (SqlDataSource)CreateUserWizardStep2.ContentTemplateContainer.FindControl("InsertExtraInfo");

            MembershipUser User = Membership.GetUser(UserNameTextBox.Text);

            object UserGUID = User.ProviderUserKey;

            DataSource.InsertParameters.Add("UserId", UserGUID.ToString());

            DataSource.Insert();

            //insert data to the Teacher table


            //  Teacher.InsertTeacherId(UserGUID);
            Response.Redirect("~/Account/login.aspx");
            //}
            //if (role.Equals("Student"))
            //{
            //    int stId = Student.GetStudentId();
            //    Student.InsertStudentId(UserGUID, stId);
            //    //  Response.Redirect("~/Account/login.aspx");
            //}

        }

        protected void roleDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
        {
            // Response.Redirect("~/Account/Login.aspx");
            //  redirect user to apprapriate page 
            if (Roles.IsUserInRole("Student"))
            {
                Response.Redirect("~/StudentManagement/myTutor.aspx");
            }
            //if (Roles.IsUserInRole("Student"))
            //{
            //    Response.Redirect("~/Student/myTutor.aspx");
            //}
        }

        //protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        //{

        //      string role = roleDropDown.SelectedItem.Text;
        //      if (role.Equals("Student"))
        //      {
        //          string a=GName.Text ;
        //          string b=GAddress.Text ;
        //          if(a==null || b==null)
        //          {
        //          GNameLabel .Text ="Guardian Info is Required.";}
        //          GName.Focus ();
        //          }
        //       }


        // }
    }
}