using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Configuration;
using System.Web.Security;
namespace Tutor.StudentManagement
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //get userid
            MembershipUser userInfo = Membership.GetUser();
            Guid userid = (Guid)userInfo.ProviderUserKey;
            Image1.ImageUrl = "~/RetrieveImage.ashx?id=" + userid;
        }
        private Boolean InsertUpdateData(SqlCommand cmd)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".bmp":
                    contenttype = "image/bmp";
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
                case ".jpeg":
                    contenttype = "image/jpeg";
                    break;

            }
            if (contenttype != String.Empty)
            {

                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //get userid
                MembershipUser userInfo = Membership.GetUser();
                Guid userid = (Guid)userInfo.ProviderUserKey;
                string userid1 = userInfo.ProviderUserKey.ToString();
                //check if image already exists in the database
                SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlCommand cmd = new SqlCommand("FindImage", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userid", SqlDbType.UniqueIdentifier).Value = userid;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    UpdateImage(userid, filename, contenttype, bytes);
                }
                else
                {

                    InsertImage(userid, filename, contenttype, bytes);
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "File Uploaded Successfully";
                Image1.ImageUrl = "~/RetrieveImage.ashx?id=" + userid1;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised. Upload Image files";
            }
        }

        private void UpdateImage(Guid userid, string filename, string contenttype, byte[] bytes)
        {
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            //if image exists in the database, update previous record
            SqlCommand cmd1 = new SqlCommand("UpdateImage", c);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@userid", SqlDbType.UniqueIdentifier).Value = userid;
            cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = filename;
            cmd1.Parameters.Add("@contenttype", SqlDbType.VarChar).Value = contenttype;
            cmd1.Parameters.Add("@data", SqlDbType.VarBinary).Value = bytes;
            cmd1.ExecuteNonQuery();
            //   cmd1.ExecuteReader();
            c.Dispose();

        }

        private void InsertImage(Guid userid, string name, string contenttype, Byte[] bytes)
        {
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            //if image does not exist, then insert the image into database
            string strQuery = "insert into Image(UserId,Name, ContentType, Data) values (@UserId,@Name, @ContentType, @Data)";
            SqlCommand cmd2 = new SqlCommand(strQuery);
            cmd2.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userid;
            cmd2.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
            cmd2.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;
            cmd2.Parameters.Add("@Data", SqlDbType.VarBinary).Value = bytes;
            InsertUpdateData(cmd2);
            c.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            btnUpload.Visible = true;
            FileUpload1.Visible = true;
            // Response.Redirect("Upload.aspx");
        }
      
       
       
     
    }
}