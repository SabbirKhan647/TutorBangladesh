using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace Tutor.TeacherManagement
{
    public partial class NewAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int teacherid = Convert.ToInt32(Session["TeacherID"]);

                SqlConnection c;
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT BatchID, BatchName from Batch where TeacherID = " + teacherid.ToString(), c);
                //2. Define parameter

                DataTable d = new DataTable();
                adapt.Fill(d);

                batch.DataTextField = "BatchName"; batch.DataValueField = "BatchID";
                batch.DataSource = d; batch.DataBind();

                if (c != null)
                {
                    c.Close();
                }
            }
        }

        protected void btnCreateAssignment_Click(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            int size = FileUpload1.PostedFile.ContentLength;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            if (contenttype != String.Empty)
            {
                //FileStream fs = (FileStream)FileUpload1.PostedFile.InputStream;
                Stream fs = FileUpload1.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                MemoryStream ms = new MemoryStream();
                fs.CopyTo(ms);
                byte[] result = ms.GetBuffer();
                byte[] justdata = new byte[ms.Length];
                Array.Copy(result, justdata, ms.Length);

                string batchID = batch.SelectedValue;
                string AssgnName = batch.SelectedItem + "/ " + Assignment.SelectedItem;
                DateTime stdate = DateTime.Parse(txtstdate.Text).Date;
                DateTime duedate = DateTime.Parse(txtduedate.Text).Date;

                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                String insertString = "NewAssignmentSP";

                SqlCommand cmd1 = new SqlCommand(insertString, c);
                cmd1.CommandType = CommandType.StoredProcedure;
              
                
                cmd1.Parameters.Add("@assgnName", SqlDbType.VarChar).Value = AssgnName;
                cmd1.Parameters.Add("@assgnData", SqlDbType.VarBinary).Value = justdata;
                cmd1.Parameters.Add("@assgnStDate", SqlDbType.Date).Value = stdate;
                cmd1.Parameters.Add("@assgnDueDate", SqlDbType.DateTime).Value = duedate;
                cmd1.Parameters.Add("@bid", SqlDbType.Int).Value = Convert.ToInt32(batch.SelectedValue);
                cmd1.Parameters.Add("@assgnmtFileName", SqlDbType.VarChar).Value = filename;
                cmd1.Parameters.Add("@contenttype", SqlDbType.VarChar).Value = contenttype;
              
                if (cmd1.ExecuteNonQuery() == 1)
                
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "File Uploaded Successfully";
                    lblMessage.Visible = true;
                }

            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised." +
                  " Upload Image/Word/PDF/Excel formats";
            }

        }
    }
}