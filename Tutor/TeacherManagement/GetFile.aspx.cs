using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Tutor.TeacherManagement
{
    public partial class GetFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the file id from the query string
            int id = Convert.ToInt16(Request.QueryString["ID"]);

            // Get the file from the database
            DataTable file = Modify.GetAFile(id);
            DataRow row = file.Rows[0];

            string name = (string)row["WorksheetName"];
            string contentType = (string)row["worksheetType"];
            Byte[] data = (Byte[])row["worksheetData"];

            // Send the file to the browser
            Response.AddHeader("Content-type", contentType);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
            Response.BinaryWrite(data);
            Response.Flush();
            Response.End();

        }

    }
}