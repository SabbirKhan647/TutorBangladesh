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
                MyAllStudent();
               
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
            DropDownMyBatch.DataSource = d;
            DropDownMyBatch.DataTextField = "BatchName";
            DropDownMyBatch.DataValueField = "BatchID";
            DropDownMyBatch.DataBind();

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
            DropDownMyGrade.DataSource = d;
            DropDownMyGrade.DataTextField = "GradeName";
            DropDownMyGrade.DataValueField = "GradeID";
            DropDownMyGrade.DataBind();

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
            DropDownMySubject.DataSource = d;
            DropDownMySubject.DataTextField = "subName";
            DropDownMySubject.DataValueField = "SUbjectID";
            DropDownMySubject.DataBind();
        
            c.Close();
        }

        private void FillAllDropDown()
        {
           
            
        }

private void MyAllStudent()
{
  
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MyAllStudent", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tid";
            param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
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

protected void btnSearch_Click(object sender, EventArgs e)
{
    if (chkBatch.Checked == true)
    {
        int batchid=Convert.ToInt16(DropDownMyBatch.SelectedValue);
        lblBatchName.Text = "Batch Name: "+DropDownMyBatch.SelectedItem.ToString();
        MyAllSTudentByBatch(batchid);
    }
     if (chkGrade.Checked==true)
     {
         int subid = Convert.ToInt16(DropDownMySubject.SelectedValue);
         int gradeid = Convert.ToInt16(DropDownMyGrade.SelectedValue);
         lblBatchName.Text = "Subject and Grade: " + DropDownMySubject.SelectedItem.ToString();
         MyAllStudentBySubjectGrade(subid, gradeid);
     }
     if (chkSubject .Checked ==true)
     {
         int subid = Convert.ToInt16(DropDownMySubject.SelectedValue);
         int gradeid = Convert.ToInt16(DropDownMyGrade.SelectedValue);
         lblBatchName.Text = "Subject and Grade: " + DropDownMySubject.SelectedItem.ToString();
         MyAllStudentBySubjectGrade(subid, gradeid);
     }
}

private void MyAllStudentBySubjectGrade(int subid, int gradeid)
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand("MyAllStudentBySubjectGrade", c);
    cmd.CommandType = CommandType.StoredProcedure;
    c.Open();

    //2. Define parameter
    SqlParameter param = new SqlParameter();
    param.ParameterName = "@sid";
    param.Value = subid;
    cmd.Parameters.Add(param);
    param = new SqlParameter();
    param.ParameterName = "@gid";
    param.Value = gradeid;
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
}

private void MyAllSTudentByBatch(int batchid)
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand("MyAllStudentByBatch", c);
    cmd.CommandType = CommandType.StoredProcedure;
    c.Open();

    //2. Define parameter
    SqlParameter param = new SqlParameter();
    param.ParameterName = "@bid";
    param.Value = batchid;
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
            
      
}

//protected void ChkBatch_CheckedChanged(object sender, EventArgs e)
//{
//    if (ChkBatch.Checked == true)
//    {
//        DropDownMyBatch.Visible = true;
//        ChkGrade.Enabled = false;
//        ChkSubject.Enabled = false;
//    }
//    else
//    {
//        ChkGrade.Enabled = true;
//        ChkSubject.Enabled = true;
//        DropDownMyBatch.Visible = false;
//    }
//}

//protected void ChkSubject_CheckedChanged(object sender, EventArgs e)
//{
//    if (ChkSubject.Checked == true)
//    {
//        ChkBatch.Enabled = false;
//        DropDownMyBatch.Visible = false;
//    }
//    else
//    {
//        ChkBatch.Enabled = true;
//    }
//}

//protected void ChkGrade_CheckedChanged(object sender, EventArgs e)
//{
//    if (ChkGrade.Checked == true)
//    {
//        ChkBatch.Enabled = false;
//        DropDownMyBatch.Visible = false;
//    }
//    else
//    {
//        ChkBatch.Enabled = true;
//    }
//}

        
            
         
    }
}