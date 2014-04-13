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
//using System.Web.SessionState;
namespace Tutor.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //prevents the users who try to skip the login step by visit specified page
            if (!Page.IsPostBack)
            {
                Session.Abandon();
            }
        }
          protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
           
            //are the credentials valid?
            if (Membership.ValidateUser(Login1.UserName, Login1.Password))
            {
                //is the password expired?
                MembershipUser userInfo = Membership.GetUser();
                //        if (userInfo != null)
                //        {
                //            int daysSincePwdChange = Convert.ToInt32(DateTime.Now.Subtract(userInfo.LastPasswordChangedDate).TotalDays);
                //            if (daysSincePwdChange > SecurityUtils.DefaultPasswordExpiryInDays)
                //            {
                //                //password expired, send user to change password
                //                Response.Redirect("~/ChangePassword.aspx?UserName=" + Server.UrlEncode(Login1.UserName));
                //            }
                //            else
                //            {
                //                e.Authenticated = true; //credentials valid and password is correct
                //            }
                //        }
                //        else
                //        {
                //            e.Authenticated = false; //invalid
                //        }

                //    }
                e.Authenticated = true;
                Session["username"] = Login1.UserName;
                Session["SessionID"] = HttpContext.Current.Session.SessionID;
              //  string userid=userInfo.ProviderUserKey.ToString();
            
              
                
            }
        }

          protected void Login1_LoggedIn(object sender, EventArgs e)
          {
              //  redirect user to apprapriate page 
              if (Roles.IsUserInRole(Login1.UserName ,"Tutor"))
              {
                  Response.Redirect("~/TeacherManagement/TeacherHome.aspx");
              }
              if (Roles.IsUserInRole(Login1 .UserName ,"Student"))
              {
                  Response.Redirect("~/StudentManagement/myTutor.aspx");
              }
          }

          protected void Button1_Click(object sender, EventArgs e)
          {
              Response.Redirect("~/Account/TeacherRegistration.aspx");
          }

         

         
    }
    }





