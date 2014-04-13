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
    public partial class WorksheetforStudent : System.Web.UI.Page
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
                cmd.CommandText = "DropDownWithRegisteredSubjectName";

                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@studentid";
                param.Value = Convert.ToInt32(Session["StudentID"].ToString());
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                DataTable dd = new DataTable();
                adapt.Fill(dd);
                drSubject.DataSource = dd;
                drSubject .DataTextField = "subname";
                drSubject .DataValueField = "subjectid";
                drSubject .DataBind();
                //  GridViewWorksheet.Visible = true;
                if (c != null)
                {
                    c.Close();
                }
                

        //    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

        //    c.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = c;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "WorksheetForStudent";

        //    //2. Define parameter
        //    SqlParameter param = new SqlParameter();
        //    param.ParameterName = "@studentid";
        //    param.Value = Convert.ToInt32(Session["StudentID"].ToString());
        //    cmd.Parameters.Add(param);
        //    SqlParameter param1 = new SqlParameter();
        //    param1.ParameterName = "@subjectid";
        //   // param1.Value = Convert.ToInt32(DropDownListSubject.DataValueField);
        //    param1.Value = 1;
        //    cmd.Parameters.Add(param1);
        //    cmd.ExecuteNonQuery();

        //    SqlDataAdapter adapt = new SqlDataAdapter(cmd);

        //    DataTable dd = new DataTable();
        //    adapt.Fill(dd);
        //    GridViewWorksheet.DataSource = dd;
        //    GridViewWorksheet.DataBind();
        //    //  GridViewWorksheet.Visible = true;
        //    if (c != null)
        //    {
        //        c.Close();
        //    }
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

        protected void DropDownListSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void DropDownListSubject_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }

        protected void drSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void showWorksheet_Click(object sender, EventArgs e)
        {
           
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "WorksheetForStudent";

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@studentid";
            param.Value = Convert.ToInt32(Session["StudentID"].ToString());
            cmd.Parameters.Add(param);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@subjectid";
            param1.Value = Convert.ToInt32(drSubject.SelectedValue);
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            DataTable dd = new DataTable();
            adapt.Fill(dd);
            GridViewWorksheet.DataSource = dd;
            GridViewWorksheet.DataBind();
            //  GridViewWorksheet.Visible = true;
            if (c != null)
            {
                c.Close();
            }
        }
    }
}