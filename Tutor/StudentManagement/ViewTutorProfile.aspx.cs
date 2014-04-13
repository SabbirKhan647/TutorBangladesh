using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Tutor.StudentManagement
{
    public partial class ViewTutorProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the teacher id from the query string
                int id = Convert.ToInt32(Request.QueryString["ID"]);
              //  Label2.Text = "Teacher ID: "+Request.QueryString["ID"];

                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getUseridToViewTutorImage";

                //2. Define parameter
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@tid";
                param.Value = id;
                cmd.Parameters.Add(param);

                cmd.Parameters.Add("@userid", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@userid"].Direction = ParameterDirection.Output;
                c.Open();
                cmd.ExecuteNonQuery();
                string uid = cmd.Parameters["@userid"].Value.ToString();
                
                if (c != null)
                {
                    c.Close();
                }
                Guid userid = new Guid(uid);
                          
                Image1.ImageUrl = "~/RetrieveImage.ashx?id=" + userid;
                //display Tutor Profile
                c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                cmd = new SqlCommand("getTutorProfile", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = id;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {             
                    // displayProfile.Visible = true;
                    lblfirstName.Text = rdr.GetString(1);
                    lblLastName.Text = rdr.GetString(2);
                    lblEmail.Text = rdr.GetString(3);
                    lblPhone.Text = rdr.GetString(4);
                    lblAddress.Text = rdr.GetString(5);
                    lblDistrict.Text = rdr.GetString(6);
                    lblDivision.Text = rdr.GetString(7);
                    if (!rdr.IsDBNull(8))
                    {
                        lblGender.Text = rdr.GetString(8);
                    }
                    //check if column is null
                    if (!rdr.IsDBNull(9))
                    {
                        lblInstitute.Text = rdr.GetString(9);

                    }
                    if (!rdr.IsDBNull(9))
                    {
                        lblDegrees.Text = rdr.GetString(10);

                    }
                    if (!rdr.IsDBNull(9))
                    {
                        lblProfile.Text = rdr.GetString(11);

                    }


                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentManagement/BuildBatch1.aspx");
        }
    }
}