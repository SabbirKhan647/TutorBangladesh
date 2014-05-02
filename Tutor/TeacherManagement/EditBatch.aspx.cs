using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Tutor.TeacherManagement
{
    public partial class EditBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetBatchData();
            }
        }
        private void GetBatchData()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DisplayBatchInfo";

            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tid";
            param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

            //string cmdText = "SELECT BatchID, MaxStudent FROM Batch1 where ";
            //cmdText += "TeacherID = " + Convert.ToInt32(Session["TeacherID"]);

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
            gvBatch.DataSource = dd;
            gvBatch.DataBind();

            // GridViewBatchByTutor.Visible = true;
            if (c != null)
            {
                c.Close();
            }
            

        }
      

        protected void gvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                int RowIndex = Convert.ToInt16(e.CommandArgument.ToString());
                string strbatchid = gvBatch.DataKeys[RowIndex].Value.ToString();
                ViewState["BatchId"] = strbatchid;
                BindDetailsView();
                lblMessage.Visible = false;
            } 

        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
           
            if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
            {

                //;;;;;;;;;;;;;
                //populate dropdownlist in child gridview edit itemtemplate
                DropDownList editDrStartTime = (DropDownList)DetailsView1.FindControl("cmbStartTimeEdit");
                for (int i = 420; i < 1460; i++)
                {
                    editDrStartTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                    i = i + 29;
                }
                // To make it the first element at the list, use 0 index : 
                editDrStartTime.Items.Insert(0, new ListItem("Select", string.Empty)); 
                DropDownList editDrEndTime = (DropDownList)DetailsView1.FindControl("cmbEndTimeEdit");
                for (int i = 480; i < 1460; i++)
                {
                    editDrEndTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                    i = i + 29;
                }
                // To make it the first element at the list, use 0 index : 
                editDrEndTime.Items.Insert(0, new ListItem("Select", string.Empty)); 

                DropDownList editDay = (DropDownList)DetailsView1.FindControl("cmbDayNameEdit");
                editDay.Items.Add("Saturday"); 
                editDay.Items.Add("Sunday"); 
                editDay.Items.Add("Monday");
                editDay.Items.Add("Tuesday"); 
                editDay.Items.Add("Wednesday"); 
                editDay.Items.Add("Thursday"); 
                editDay.Items.Add("Friday");
                // To make it the first element at the list, use 0 index : 
                editDay.Items.Insert(0, new ListItem("Select", string.Empty)); 
            } 
        }

        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            //if (e.CommandName.Equals("New"))
            //{
            //    DetailsView1.ChangeMode(DetailsViewMode.Insert);
            //    BindDetailsView();
            //}
            if (e.CommandName.Equals("Cancel"))
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailsView();
            }
            else if (e.CommandName.Equals("Edit"))
            {
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                BindDetailsView();
            } 

        }

        protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            Label lblday = (Label)DetailsView1.FindControl("lblDay");
            Label lblsttime = (Label)DetailsView1.FindControl("lblstTime");
            Label lblendtime = (Label)DetailsView1.FindControl("lblendtime");
           
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("DeleteBatchDaySP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value =Convert.ToInt32 (ViewState["BatchId"]);
            cmd.Parameters.Add("@day", SqlDbType.VarChar).Value = lblday.Text;
            cmd.Parameters.Add("@sttime", SqlDbType.VarChar).Value = lblsttime.Text;
            cmd.Parameters.Add("@endtime", SqlDbType.VarChar).Value =lblendtime.Text;
            c.Open();
            cmd.ExecuteNonQuery();

             c.Close();
         //   DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetailsView();
            lblMessage.Text = "Delete successful.";
        }

       
        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            DropDownList drDay = (DropDownList)DetailsView1.FindControl("cmbDayNameEdit");
            DropDownList drsttime = (DropDownList)DetailsView1.FindControl("cmbStartTimeEdit");
            DropDownList drendtime = (DropDownList)DetailsView1.FindControl("cmbEndTimeEdit");

            string sttime = drsttime.SelectedItem.Text;
            string endtime = drendtime.SelectedItem.Text;
            DateTime sttime1 = Convert.ToDateTime(drsttime.SelectedItem.Text);
           // string sttime1 = Convert.ToString(sttime);
            DateTime endtime1 = Convert.ToDateTime(drendtime.SelectedItem.Text);
         //   string endtime1 = Convert.ToString(endtime);
            TimeSpan duration1 = endtime1.Subtract(sttime1);

            double p = duration1.TotalMilliseconds;
            float duration = Convert.ToInt32(p / 3600000); 
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
           
            SqlCommand cmd = new SqlCommand("UpdateBatchDaySP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value =Convert.ToInt32 (ViewState["BatchId"]);
            cmd.Parameters.Add("@day", SqlDbType.VarChar).Value = drDay.SelectedItem.Text;
            cmd.Parameters.Add("@sttime", SqlDbType.VarChar).Value = sttime;
            cmd.Parameters.Add("@endtime", SqlDbType.VarChar).Value = endtime;
            //cmd.Parameters.Add("@sttime", SqlDbType.Time).Value = DateTime.Parse(sttime).TimeOfDay;
            //cmd.Parameters.Add("@endtime", SqlDbType.Time).Value = DateTime.Parse(endtime).TimeOfDay;
            cmd.Parameters.Add("@d", SqlDbType.Float).Value = duration;

            c.Open();
            cmd.ExecuteNonQuery();
            
            c.Close();
         //   DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetailsView();
            lblMessage.Text = "Update successful.";

        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {

        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            DetailsView1.PageIndex = e.NewPageIndex;
            BindDetailsView(); 

        }
        private void BindDetailsView()
        {
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand("GetBatchDaySP", c);
            cmd.CommandType = CommandType.StoredProcedure;
            int batchid=Convert.ToInt32(ViewState["BatchId"]);
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value =batchid;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();
            c.Close();
        }

        protected void gvBatch_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBatch.EditIndex = e.NewEditIndex;
            GetBatchData();
            msg.Visible = false;
        }

        protected void gvBatch_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);

            TextBox txtstdate = (TextBox)gvBatch.Rows[e.RowIndex].FindControl("txtstDate");
            DateTime stdate = DateTime.Parse(txtstdate.Text).Date;
           
           
            TextBox MaxStu = (TextBox)gvBatch.Rows[e.RowIndex].FindControl("txtMaxStu");
            int p = Convert.ToInt32(MaxStu.Text.Trim());

            Label batchid = (Label)gvBatch.Rows[e.RowIndex].FindControl("lblBatchID");
            int q = Convert.ToInt32(batchid.Text.Trim());
            SqlCommand cmd = new SqlCommand("Update Batch set startdate=@stdate, MaxStudent= @max where BatchID = @bid", c);
            cmd.Parameters.AddWithValue("@stdate", stdate);
            cmd.Parameters.AddWithValue("@max", p);
            cmd.Parameters.AddWithValue("@bid", q);
            c.Open();
          
            cmd.ExecuteNonQuery();
            gvBatch.EditIndex = -1;
            GetBatchData();
            msg.Text = "Record updated successfully.";
            msg.Visible = true;
            if (c != null)
            {
                c.Close();
            }
        }

        protected void gvBatch_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBatch.EditIndex = -1;
            GetBatchData();
        }
    }
}