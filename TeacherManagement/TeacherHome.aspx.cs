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
    public partial class Teacher2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // date.Text = Session["ClientCurrentDate"].ToString();
                int techerID = 0;
                MembershipUser userInfo = Membership.GetUser();
                string userid = userInfo.ProviderUserKey.ToString();

                SqlConnection c;
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlCommand cmd = new SqlCommand("select TeacherID from Teacher where UserId= @userid", c);
                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@userid";
                param.Value = userid;
                cmd.Parameters.Add(param);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    techerID = rdr.GetInt32(0);
                }

                // store TeacherID in session


                Session["TeacherID"] = techerID;
                FillSubjectDropDown();
                FillGradeDropDown();
                FillBatchDropDown();
                //   Label1.Text = Session["TeacherID"].ToString();
                if (c != null)
                {
                    c.Close();
                }
                MyAllStudent(techerID);
              
            }
        }

        private void FillBatchDropDown()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DropDownWithRegBatchNameAsTutor", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable(); da.Fill(d);
            MyStudentByBatch.DataSource = d;
            MyStudentByBatch.DataTextField = "BatchName";
            MyStudentByBatch.DataValueField = "BatchID";
            MyStudentByBatch.DataBind();

            c.Close();
        }

        private void FillGradeDropDown()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DropDownWithRegGradeNameAsTutor", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable(); da.Fill(d);
            MyStudentByGrade.DataSource = d;
            MyStudentByGrade.DataTextField = "GradeName";
            MyStudentByGrade.DataValueField = "GradeID";
            MyStudentByGrade.DataBind();

            c.Close();
        }

        private void FillSubjectDropDown()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DropDownWithRegSubNameAsTutor", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable(); da.Fill(d);
            MyStudentBySubject.DataSource = d;
            MyStudentBySubject.DataTextField = "subName";
            MyStudentBySubject.DataValueField = "SUbjectID";
            MyStudentBySubject.DataBind();
        
            c.Close();
        }

        private void FillAllDropDown()
        {
           
            
        }

private void MyAllStudent(int techerID)
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand("MyAllStudent", c);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
    MyStudent.DataSource = ds;
    MyStudent.DataBind();
    c.Close();
}

protected void MyStudentByGrade_SelectedIndexChanged(object sender, EventArgs e)
{

}

protected void MyStudentBySubject_SelectedIndexChanged(object sender, EventArgs e)
{

}

protected void MyStudentByBatch_SelectedIndexChanged(object sender, EventArgs e)
{

}

        
            
         
    }
}