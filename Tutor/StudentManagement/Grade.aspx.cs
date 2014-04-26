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
    public partial class Grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                c.Open();
                SqlCommand cmd = new SqlCommand("MyBatchesAsStudent", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@studentid", SqlDbType.Int).Value = Convert.ToInt32(Session["StudentID"].ToString());
                
                SqlDataReader r = cmd.ExecuteReader();
                DataTable d = new DataTable();
                d.Load(r);
                //DataTable d = new DataTable();
                //adapt.Fill(d);

                DropDownListBatchName.DataTextField = "BatchName"; DropDownListBatchName.DataValueField = "BatchID";
                DropDownListBatchName.DataSource = d; DropDownListBatchName.DataBind();

              //  gvBatch.DataSource = d; gvBatch.DataBind();
                if (c != null)
                {
                    c.Close();
                }
            }
        }
        protected void btnGO_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DisplayAllTestResultsSP", c);
            cmd.CommandType = CommandType.StoredProcedure;
           
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@batchid";
            param.Value = Convert.ToInt32(DropDownListBatchName.SelectedValue);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@stid";
            param.Value = Convert.ToInt32(Session["StudentID"].ToString ());
            cmd.Parameters.Add(param);

            c.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader r = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(r);
            if (d.Rows.Count > 0)
            {
                Repeater1.DataSource = d;
                Repeater1.DataBind();
                Repeater1.Visible = true;
                noData.Visible = false;
            }
            else
            {
                noData.Text = "No assessment result is posted at this moment.";
                noData.Visible = true;
                Repeater1.Visible = false;
               
            }
           
           
            Repeater1.DataSource = d;
            Repeater1.DataBind();

            if (c != null)
            {
                c.Close();
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //disable hyperlink if test expire date is earlier than current date

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Label score = (Label)e.Item.FindControl("lblScore");
                Label scorepercent = (Label)e.Item.FindControl("lblScorePercent");
                if (score.Text =="")
                {
                    score.Text = "00";
                }
                else
                {
                    float p = Convert.ToSingle(score.Text);
                    score.Text = Math.Round(p, 2).ToString();
                }
                if (scorepercent.Text == "")
                {
                    scorepercent.Text = "0.00";
                    scorepercent.CssClass = "highlightCell";
                    score.CssClass = "highlightCell";
                }
                else
                {
                    float p = Convert.ToSingle(scorepercent.Text);
                    scorepercent.Text =Math.Round(p, 2).ToString();
                    if(p<50){
                        scorepercent.CssClass = "highlightCell";
                        score.CssClass = "highlightCell";
                    }
                    if (p >=80)
                    {
                        scorepercent.CssClass = "highlightCell1";
                        score.CssClass = "highlightCell1";
                    }
                }

            }

        }
    }
}