using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tutor.Class;

namespace Tutor.Account
{
    public partial class TeacherRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {

           // string s = roleDropDown.SelectedValue;
            if (!Roles.IsUserInRole("Tutor"))
            {
                Roles.AddUserToRole(CreateUserWizard1.UserName, "Tutor");
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
            if (Roles.IsUserInRole("Tutor"))
            {
                Response.Redirect("~/Teacher/Teacher.aspx");
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