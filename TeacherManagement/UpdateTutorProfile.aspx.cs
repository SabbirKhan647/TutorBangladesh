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
namespace Tutor.TeacherManagement
{
    public partial class UpdateTutorProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //get userid
                MembershipUser userInfo = Membership.GetUser();
                Guid userid = (Guid)userInfo.ProviderUserKey;
                Image1.ImageUrl = "~/RetrieveImage.ashx?id=" + userid;
                bindDetailtView();
           
            }
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
                Guid userid =(Guid) userInfo.ProviderUserKey;
                string userid1 = userInfo.ProviderUserKey.ToString();
                //check if image already exists in the database
                SqlConnection c =new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlCommand cmd = new SqlCommand("FindImage", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userid", SqlDbType.UniqueIdentifier).Value =userid;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    UpdateImage(userid, filename, contenttype, bytes);
                }
                else
                {
                   
                    InsertImage(userid, filename,contenttype,bytes);
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

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {

        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            TextBox txtFirstname = (TextBox)DetailsView1.FindControl("txtFirstname");
            TextBox txtLastName = (TextBox)DetailsView1.FindControl("txtLastName");
            TextBox txtEmail = (TextBox)DetailsView1.FindControl("txtemail");
            TextBox txtPhone = (TextBox)DetailsView1.FindControl("txtphone");
            TextBox txtAddress = (TextBox)DetailsView1.FindControl("txtAddress");
            DropDownList drDistrict = (DropDownList)DetailsView1.FindControl("drDistrict");
            DropDownList drDivision = (DropDownList)DetailsView1.FindControl("drDivision");
            DropDownList drGender = (DropDownList)DetailsView1.FindControl("drGender");
            TextBox txtinstitute = (TextBox)DetailsView1.FindControl("txtinstitute");
            TextBox txtdegrees = (TextBox)DetailsView1.FindControl("txtdegrees");
            TextBox txtprofile = (TextBox)DetailsView1.FindControl("txtprofile");
            //string Query = "Update Employee Set FirstName='" + txtFirstname.Text + "' ,LastName ='" + txtLastName.Text + "' ,City ='" + txtCity.Text + "',Address='" + txtAddress.Text + "',PinNo='" + txtPinNo.Text + "',MobileNo='" + txtMobileNo.Text + "' where ID =" + lblIDEdit.Text;
            //ExecuteQuery(Query);
           
            //display Tutor Profile
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand("UpdateTutorProfile", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = txtFirstname.Text;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = txtLastName.Text;
            cmd.Parameters.Add("@em", SqlDbType.VarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@ph", SqlDbType.VarChar).Value = txtPhone.Text;
            cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = txtAddress.Text;
            cmd.Parameters.Add("@dis", SqlDbType.VarChar).Value = drDistrict.SelectedValue;
            cmd.Parameters.Add("@div", SqlDbType.VarChar).Value = drDivision.SelectedValue;
            cmd.Parameters.Add("@g", SqlDbType.Char).Value = drGender.SelectedValue;
            cmd.Parameters.Add("@ins", SqlDbType.VarChar).Value = txtinstitute.Text;
            cmd.Parameters.Add("@deg", SqlDbType.VarChar).Value = txtdegrees.Text;
            cmd.Parameters.Add("@pro", SqlDbType.VarChar).Value = txtprofile.Text;
            cmd.ExecuteNonQuery();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //DetailsView1.DataSource = ds;
            //DetailsView1.DataBind();
            //c.Close();
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            bindDetailtView();
            //call javascript function to hide notification image
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "myKey", "HideNotificationImage();", true);
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {

        }

        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "Edit":
                    DetailsView1.ChangeMode(DetailsViewMode.Edit);
                    bindDetailtView();
                    break;
                case "Cancel":
                    DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                    bindDetailtView();
                    break;
                //case "New":
                //    DetailsViewExample.ChangeMode(DetailsViewMode.Insert);
                //    bindDetailtView();
                //    break;
            }
        }

        private void bindDetailtView()
        {
            //display Tutor Profile
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand("getTutorProfile", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();
            c.Close();   
        }
      
       
       
     
       
    }
}