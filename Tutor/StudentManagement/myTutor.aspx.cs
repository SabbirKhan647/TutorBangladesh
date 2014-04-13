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
namespace Tutor
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int studentID = 0;
                MembershipUser userInfo = Membership.GetUser();
                string userid = userInfo.ProviderUserKey.ToString();

                SqlConnection c;
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlCommand cmd = new SqlCommand("select StudentID from Student where UserId= @userid", c);
                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@userid";
                param.Value = userid;
                cmd.Parameters.Add(param);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    studentID = rdr.GetInt32(0);
                }

                // store TeacherID in session
                Session["StudentID"] = studentID;

                Label1.Text = Session["StudentID"].ToString();
                if (c != null)
                {
                    c.Close();
                }
                DisplayNotices();
            }
        }

        private void DisplayNotices()
        {
            /////////
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DisplayNoticeSP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@sid";
            param.Value = Convert.ToInt32(Session ["StudentID"].ToString());
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            SqlDataReader r = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(r);
            Repeater1.DataSource = d;
            Repeater1.DataBind();

            if (c != null)
            {
                c.Close();
            }
            //SqlConnection  c ;
            //SqlDataReader rdr;
            //try
            //{
                             
            //    c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            //    c.Open();
            //    SqlCommand cmd = new SqlCommand("DisplayNoticeSP", c);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = Convert.ToInt32(Session["Studentid"].ToString());
            //    rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
               
            //    {
            //        // fill data in dynamic controls
            //        Panel panel = new Panel();
            //        panel.CssClass = "NoticeContainer";
            //        //   panel.ID = "panelContainer";
            //        //panel.BackColor =System .Drawing .Color .LightGray ;

            //        Label lblBatchName = new Label();
            //        lblBatchName.CssClass = "NoticeBatchName";
            //        lblBatchName.Text = rdr[0].ToString();
            //        //lblMessage .Font .Bold =true;
            //        //lblMessage .ForeColor =System.Drawing .Color .Black ;

            //        Label lbldate = new Label();
            //        lbldate.CssClass = "NoticeDate";
            //        lbldate.Text = rdr[1].ToString();

            //        Label lblSubject = new Label();
            //        lblSubject.CssClass = "NoticeSubject";
            //        lblSubject.Text = rdr[2].ToString();

            //        Label lblMessage = new Label();
            //        lblMessage.CssClass = "NoticeMessage";
            //        lblMessage.Text = rdr[3].ToString();

            //        panel.Controls.Add(lblBatchName);
            //        panel.Controls.Add(lbldate);
            //        panel.Controls.Add(new LiteralControl("<br />"));
            //        panel.Controls.Add(lblSubject);
            //        panel.Controls.Add(new LiteralControl("<br />"));
            //        panel.Controls.Add(lblMessage);
            //        PutPanelHere.Controls.Add(panel);
            //    }

            //}
            //catch (Exception e1)
            //{
            //   // Response.Write(e1.Message);
            //   // Response.End();
            //}
            ////finally
            ////{
            ////     rdr.Close();
            ////     c.Close();
            ////}
        }
    }
}