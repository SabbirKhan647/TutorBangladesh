using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Configuration;
namespace Tutor.TeacherManagement
{
    public partial class ViewDropboxSubmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DropDownWithRegBatchNameAsTutor";

                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@tid";
                param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                DataTable dd = new DataTable();
                adapt.Fill(dd);
                drBatch.DataSource = dd;
                drBatch.DataTextField = "BatchName";
                drBatch.DataValueField = "BatchID";
                drBatch.DataBind();
                //  GridViewWorksheet.Visible = true;
                if (c != null)
                {
                    c.Close();
                }

            }
        }

       

        protected void DisplayAssignments_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetGivenAssignmentName";

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = Convert.ToInt32(drBatch.SelectedValue);
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            DataTable dd = new DataTable();
            adapt.Fill(dd);
            drAssignments.DataSource = dd;
            drAssignments.DataTextField = "AssignmentName";
            drAssignments.DataValueField = "AssignmentID";
            drAssignments.DataBind();
            
            //  GridViewWorksheet.Visible = true;
            if (c != null)
            {
                c.Close();
            }
        }

        protected void btnDisplaySubmission_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("ViewSubmittedAssignmentSP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parm = new SqlParameter("@bid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(drBatch.SelectedValue);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
            parm = new SqlParameter("@assgnmtid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(drAssignments .SelectedValue);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
            c.Open();
            SqlDataReader r = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(r);
            Repeater1.DataSource = d;
            Repeater1.DataBind();

            if (c != null)
            {
                c.Close();
            }
          ViewState ["AssignmentID"]=drAssignments .SelectedValue .ToString ();
        }
        protected void btnEnterMarks_Click(object sender, CommandEventArgs e)
        {

            foreach (RepeaterItem item in Repeater1.Items)
            {
                HiddenField hfAssgnmtID = (HiddenField)item.FindControl("hfStudentAssignmentID");
                Button btnEnterMarks = (Button)item.FindControl("btnEnterMarks");
                Label lblMessage=(Label )item.FindControl ("lblMessage");
                if (e.CommandName == "btnEnterMarksClick")
                {
                    string assgnmtid = (string)e.CommandArgument; //assignment id value as enter marks button command argument
                    int intassgnmtid = Convert.ToUInt16(assgnmtid);
                    string assid = hfAssgnmtID.Value;
                    int intassid = Convert.ToInt16(assid);
                    if (intassid == intassgnmtid)//if hiddenfield assignment id and enter marks button command argument is equal
                    {
                     TextBox marks=(TextBox )item.FindControl ("txtassgnmtMarks");
                      string score=marks.Text ;
                      string assignmentid=  ViewState ["AssignmentID"].ToString();
                      SaveStudentAssignmentMarks(intassgnmtid, assignmentid, score);
                      lblMessage.Text = "Marks entered successfully.";
                      lblMessage.ForeColor = System.Drawing.Color.Green;
                      lblMessage.Visible = true;
                    }
                }
            }
        }
        protected void lbSubmittedAssgnmtDocTitle_Click(object sender, CommandEventArgs e)
        {

            foreach (RepeaterItem item in Repeater1.Items)
            {
                HiddenField hfAssgnmtID = (HiddenField)item.FindControl("hfStudentAssignmentID");
                LinkButton lb = (LinkButton)item.FindControl("lbSubmittedAssgnmtDocTitle");

                if (e.CommandName == "lbSubmittedAssgnmtDocTitle")
                {
                    string assgnmtid = (string)e.CommandArgument; //assignment id value as submit button command argument
                    int intassgnmtid = Convert.ToUInt16(assgnmtid);
                    string assid = hfAssgnmtID.Value;
                    int intassid = Convert.ToInt16(assid);
                    if (intassid == intassgnmtid)//if hiddenfield assignment id and submit button command argument is equal
                    {
                        //works for pdf file

                        string filename = lb.Text;

                        string d = "pdf";
                        bool b = filename.Contains(d);
                     //   showdata.Text = filename;

                        //string val = hfAssgnmtID.Value;
                        //holdsDoc.Attributes.Add("src", "../RetrieveAssignmentDoc.ashx?id=" + val);
                        //if (hfAssgnmtID != null)
                        //{
                        string val = hfAssgnmtID.Value;
                        if (b == true)
                        {
                            //open pdf file in iframe
                            holdsDoc.Attributes.Add("src", "../RetrieveAssignmentSubmission.ashx?id=" + val);
                            // holdsDoc.Visible = true;
                        }
                        else
                        {
                            //download files other than pdf
                            DownLoadWordFile(val);
                        }

                    }
                }
            }




        }

        protected void DownLoadWordFile(string val)
        {
            int id = Convert.ToInt32(val);

            DataTable file = Modify.GetASubmittedAssignmentFile(id);
            DataRow row = file.Rows[0];

            string name = (string)row["SubmittedAssgnmtDocTitle"];
            string contentType = (string)row["ContentType"];
            Byte[] data = (Byte[])row["SubmittedAssgnmtDocData"];

            // Send the file to the browser
            Response.AddHeader("Content-type", contentType);
            Response.AddHeader("Content-Disposition", "inline; filename=" + name);
            Response.BinaryWrite(data);
            Response.Flush();
            Response.End();

            //    int id = Convert.ToInt32(val);
            //    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            //    c.Open();

            //    SqlDataAdapter adapter = new SqlDataAdapter("SELECT AssgnmtFileName, AssignmentData FROM Assignment WHERE AssignmentID=" + id, c);

            //    DataTable file = new DataTable();
            //    adapter.Fill(file);
            //    DataRow row = file.Rows[0];

            //    string name = (string)row["AssgnmtFileName"];
            ////    string contentType = (string)row["worksheetType"];
            //    Byte[] data = (Byte[])row["AssignmentData"];

            //    // Send the file to the browser
            ////    Response.AddHeader("Content-type", contentType);
            //    Response.AddHeader("Content-Disposition", "inline; filename=" + name);
            //    Response.BinaryWrite(data);
            //    Response.Flush();
            //    Response.End();
        }
        private void SaveStudentAssignmentMarks(int stassgnmtid, string assignmentid,string score)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("StudentAssignmentResultSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@stassgnmtid", SqlDbType.Int);
            parm.Value = stassgnmtid;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@assignmentid", SqlDbType.Int);
            parm.Value = Convert.ToInt16(assignmentid);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@score", SqlDbType.Float);
            parm.Value = Convert.ToSingle(score);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
            c.Open();
            cmd.ExecuteNonQuery();

            c.Close();

        }
    }
}