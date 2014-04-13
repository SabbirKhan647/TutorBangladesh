using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Configuration;
//using Microsoft.Office.Interop.Word;
namespace Tutor.TeacherManagement
{
    public partial class displayDocumentOnPageTry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                string cmdText = "SELECT WorksheetID, WorksheetName FROM Worksheet ";
             //   cmdText += DropDownListSub.SelectedValue + " and GradeID = " + DropDownListGrade.SelectedValue + " and LevelOfDifficulty = " + DropDownListLOD.SelectedValue + " and TeacherID = " + Convert.ToInt32(Session["TeacherID"]);
                SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
                DataTable dd = new DataTable();
                adapt.Fill(dd);
                Repeater1 .DataSource = dd;
                Repeater1 .DataBind();
              
                if (c != null)
                {
                    c.Close();
                }


            }

        }

        protected void ff_Click(object sender, EventArgs e)
        {
            ////get userid
            MembershipUser userInfo = Membership.GetUser();
            Guid userid = (Guid)userInfo.ProviderUserKey;

            this.holdsImage.Attributes.Add("src", "../RetrieveImage.ashx?id=" + userid);
         
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //works for pdf file
            HiddenField hf = e.Item.FindControl("HiddenField1") as HiddenField;
            LinkButton lb=e.Item .FindControl ("OpenDoc") as LinkButton ;
            string filename = lb.Text;
          
            string d="pdf";
            bool b = filename.Contains(d);
            
            
            if (hf != null)
            {
                string val = hf.Value;
                if (b == true)
                {
                    //open pdf file in iframe
                    holdsDoc.Attributes.Add("src", "../RetrieveDoc.ashx?id=" + val);
                    holdsDoc.Visible = true;
                }
                else
                {
                    //download files other than pdf
                    DownLoadWordFile(val);
                }

            }


        

        }
        protected void DownLoadWordFile(string val)
        {

            int id = Convert.ToInt32(val);

            DataTable file = Modify.GetAFile(id);
            DataRow row = file.Rows[0];

            string name = (string)row["WorksheetName"];
            string contentType = (string)row["worksheetType"];
            Byte[] data = (Byte[])row["worksheetData"];

            // Send the file to the browser
            Response.AddHeader("Content-type", contentType);
            Response.AddHeader("Content-Disposition", "inline; filename=" + name);
            Response.BinaryWrite(data);
            Response.Flush();
            Response.End();
        }
    }
}