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
    public partial class Worksheet1 : System.Web.UI.Page
    {
        SqlConnection c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
                DataTable d = new DataTable(); Adapter.Fill(d);
                DropDownListSub.DataSource = d; DropDownListSub.DataTextField = "SubName"; DropDownListSub.DataValueField = "SubjectID";
                DropDownListSub.DataBind();

                Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
                d = new DataTable(); Adapter.Fill(d);
                DropDownListGrade.DataSource = d; DropDownListGrade.DataTextField = "GradeName"; DropDownListGrade.DataValueField = "GradeID";
                DropDownListGrade.DataBind();
                if (c != null)
                {
                    c.Close();
                }

            }
        }
        
        protected void ButtonShow_Click(object sender, EventArgs e)
        {

            
            c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            string cmdText = "SELECT WorksheetID, SubjectID, GradeID, WorksheetName, LevelOfDifficulty, sizeA, worksheetData, worksheetType FROM Worksheet where SubjectID = ";
            cmdText += DropDownListSub.SelectedValue + " and GradeID = " + DropDownListGrade.SelectedValue + " and LevelOfDifficulty = " + DropDownListLOD.SelectedValue + " and TeacherID = " +Convert .ToInt32 (Session["TeacherID"]);
            SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
            GridViewWorksheet.DataSource = dd;
            GridViewWorksheet.DataBind();
            GridViewWorksheet.Visible = true;
            if (c != null)
            {
                c.Close();
            }

        }
        protected void GridViewWorksheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridViewWorksheet.DataKeys[GridViewWorksheet.SelectedIndex].Value);
         
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