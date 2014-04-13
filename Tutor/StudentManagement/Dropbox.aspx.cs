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
namespace Tutor.StudentManagement
{
    public partial class Dropbox : System.Web.UI.Page
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
                cmd.CommandText = "DropDownWithRegBatchNameAsStudent";

                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@sid";
                param.Value = Convert.ToInt32(Session["StudentID"].ToString());
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
        protected void DisplayAssignment_Click(object sender, EventArgs e)
        {
            Session["BatchID"] = drBatch.SelectedValue;
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("AllgivenAssignmentforStudent", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parm = new SqlParameter("@sid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Session["StudentID"].ToString());
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
            parm = new SqlParameter("@bid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(drBatch.SelectedValue);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
            parm = new SqlParameter("@currentdate", SqlDbType.Date);
            parm.Value = DateTime.Today;//need to change to client side date
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
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ////disable hyperlink if test expire date is earlier than current date

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Label teststartdate = (Label)e.Item.FindControl("lblTestAvailableDate");
                DateTime teststartdate1 = DateTime.Parse(teststartdate.Text).Date;
                Label testexpiredate = (Label)e.Item.FindControl("lbltestExpireDate");
                DateTime testexpiredate1 = DateTime.Parse(testexpiredate.Text).Date;
                
                DateTime currentdate = DateTime.Today;//client date
                //   DateTime currentdate =DateTime .Parse (Session["ClientCurrentDate"].ToString()).Date;
                int result1 = DateTime.Compare(testexpiredate1, currentdate);

                if (result1 < 0)
                {
                    LinkButton p = (LinkButton)e.Item.FindControl("LBAssgnmtName");
                    p.Enabled = false;
                    p.CssClass = "DisableHyperlink";
                }

            }

        }
      
             protected void LBAssgnmtName_Click(object sender, CommandEventArgs e)
             {

            foreach (RepeaterItem item in Repeater1.Items)
            {
                HiddenField hfAssgnmtID = (HiddenField)item.FindControl("HiddenField1");
                LinkButton lb = (LinkButton)item.FindControl("LBAssgnmtName");
                HiddenField hfFileName = (HiddenField)item.FindControl("HiddenField2");

                if (e.CommandName == "LBAssgnmtNameClick")
                {
                    string assgnmtid = (string)e.CommandArgument; //assignment id value as submit button command argument
                    int intassgnmtid = Convert.ToUInt16(assgnmtid);
                    string assid=hfAssgnmtID.Value;
                    int intassid=Convert .ToInt16 (assid );
                    if (intassid == intassgnmtid)//if hiddenfield assignment id and submit button command argument is equal
                    {
                    //works for pdf file

                    string filename = hfFileName.Value;

                    string d = "pdf";
                    bool b = filename.Contains(d);
                    showdata.Text = filename;

                    //string val = hfAssgnmtID.Value;
                    //holdsDoc.Attributes.Add("src", "../RetrieveAssignmentDoc.ashx?id=" + val);
                    //if (hfAssgnmtID != null)
                    //{
                    string val = hfAssgnmtID.Value;
                    if (b == true)
                    {
                        //open pdf file in iframe
                        holdsDoc.Attributes.Add("src", "../RetrieveAssignmentDoc.ashx?id=" + val);
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

            DataTable file = Modify.GetAAssignmentFile(id);
            DataRow row = file.Rows[0];

            string name = (string)row["AssgnmtFileName"];
            string contentType = (string)row["ContentType"];
            Byte[] data = (Byte[])row["AssignmentData"];

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

        protected void btnSubmit_Click(object sender, CommandEventArgs e)
        {

            foreach (RepeaterItem item in Repeater1.Items)
            {
                FileUpload fu = (FileUpload)item.FindControl("uploadAssignment");
                Button btnUpload = (Button)item.FindControl("btnUpload");
                HiddenField hfAssgnmtid=(HiddenField )item .FindControl ("HiddenField1");
                if (e.CommandName == "btnSubmitClick")
                {
                    string assgnmtid = (string)e.CommandArgument; //assignment id value as submit button command argument
                    int intassgnmtid = Convert.ToUInt16(assgnmtid);
                    string assid=hfAssgnmtid.Value;
                    int intassid=Convert .ToInt16 (assid );
                    if (intassid == intassgnmtid)//if hiddenfield assignment id and submit button command argument is equal
                    {
                        fu.Visible = true;
                        btnUpload.Visible = true;
                    }
                }
            }
        }
        protected void btnUpload_Click(object sender, CommandEventArgs e)
        {

            foreach (RepeaterItem item in Repeater1.Items)
            {
                FileUpload fu = (FileUpload)item.FindControl("uploadAssignment");
                Button btnUpload = (Button)item.FindControl("btnUpload");
                HiddenField hfAssgnmtid = (HiddenField)item.FindControl("HiddenField1");
                Label lblMessage = (Label)item.FindControl("lblMessage");
                if (e.CommandName == "btnUploadClick")
                {
                    string assgnmtid = (string)e.CommandArgument; //assignment id value as submit button command argument
                    int intassgnmtid = Convert.ToUInt16(assgnmtid);
                    string assid = hfAssgnmtid.Value;
                    int intassid = Convert.ToInt16(assid);
                    if (intassid == intassgnmtid)//if hiddenfield assignment id and submit button command argument is equal
                    {
                        // Read the file and convert it to Byte Array
                        string filePath = fu.PostedFile.FileName;
                        string filename = Path.GetFileName(filePath);
                        string ext = Path.GetExtension(filename);
                        string contenttype = String.Empty;
                     

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
                            Stream fs = fu.PostedFile.InputStream;
                            //BinaryReader br = new BinaryReader(fs);
                            //Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            MemoryStream ms = new MemoryStream();
                            fs.CopyTo(ms);
                            byte[] result = ms.GetBuffer();
                            byte[] justdata = new byte[ms.Length];
                            Array.Copy(result, justdata, ms.Length);

                          
                            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                            c.Open();
                            String insertString = "StudentAssignmentSP";

                            SqlCommand cmd1 = new SqlCommand(insertString, c);
                            cmd1.CommandType = CommandType.StoredProcedure;
            
                
                            cmd1.Parameters.Add("@sid", SqlDbType.Int).Value =Convert.ToInt32 (Session["StudentID"].ToString());
                            cmd1.Parameters.Add("@assgnid", SqlDbType.Int).Value = intassid;
                            cmd1.Parameters.Add("@bid", SqlDbType.Int).Value = Convert.ToInt32 (drBatch .SelectedValue );
                            cmd1.Parameters.Add("@dt", SqlDbType.DateTime).Value =DateTime .Today ;//pick clientside datetime
                          
                            cmd1.Parameters.Add("@title", SqlDbType.VarChar).Value = filename;
                            cmd1.Parameters.Add("@data", SqlDbType.VarBinary).Value = justdata;
                            cmd1.Parameters.Add("@contenttype", SqlDbType.VarChar).Value = contenttype;
                            cmd1.ExecuteNonQuery();
                            //if (cmd1.ExecuteNonQuery() == 1)
                
                            //{
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                lblMessage.Text = "Assignment Submitted Successfully";
                                lblMessage.Visible = true;
                           // }

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
        }
    }
}