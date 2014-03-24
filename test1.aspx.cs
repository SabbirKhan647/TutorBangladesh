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
namespace Tutor
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DisplayImageinRepeater", c);
            cmd.CommandType = CommandType.StoredProcedure;
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
            HiddenField hf = e.Item.FindControl("HiddenField1") as HiddenField;
            if (hf != null)
            {
                string val = hf.Value;
                Image img = e.Item.FindControl("tutorImage") as Image;
                img.ImageUrl = "~/RetrieveImage.ashx?id=" + val;
            }
        }
    }
}