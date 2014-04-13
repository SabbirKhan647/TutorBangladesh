using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace AjaxDBInsert
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string INSERT_RECORD(string stuname, string stuclass, string rollno, string fathername)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into AjaxDBInsert values('" + stuname + "','" + stuclass + "','" + rollno + "','" + fathername + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Success";
            }

            catch (Exception ex)
            {
                return "failure";
            }

        }
    }
}