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
    public partial class Task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillBatchDropDownList();
                FillTaskNameDropDownList();
            }
        }
        private void FillBatchDropDownList() {
            int teacherid = Convert.ToInt32(Session["TeacherID"]);

            SqlConnection c;
            c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT BatchID, BatchName from Batch where TeacherID = " + teacherid.ToString(), c);
            //2. Define parameter

            DataTable d = new DataTable();
            adapt.Fill(d);

            DropDownListBatchName.DataTextField = "BatchName"; DropDownListBatchName.DataValueField = "BatchID";
            DropDownListBatchName.DataSource = d; DropDownListBatchName.DataBind();

            if (c != null)
            {
                c.Close();
            }
        }
        private void FillTaskNameDropDownList()
        {
           
            SqlConnection c;
            c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT TaskName from TaskName", c);
            //2. Define parameter

            DataTable d = new DataTable();
            adapt.Fill(d);

            DropDownTaskName.DataTextField = "TaskName"; DropDownTaskName.DataValueField = "TaskName";
            DropDownTaskName.DataSource = d; DropDownTaskName.DataBind();

            if (c != null)
            {
                c.Close();
            }
        }
        protected void btnGenerateTask_Click(object sender, EventArgs e) {
            ll.Text = "button works";
          //  string teacherid = Session["TeacherID"].ToString();

          //  string maxStu = DropDownNoOfStu.SelectedItem.Text;
          ////  string clientsidedate = HiddenField1.Value;
          ////  string dateCreated = DateTime.Parse(clientsidedate).ToShortDateString();
          //  //     string dateCreated= DateTime.Now.ToShortDateString();
          //  string timeCreated = DateTime.Now.ToShortTimeString();
          //  //string dateCreated = Session["dateCreated"].ToString();
          //  //string timeCreated = Session["timeCreated"].ToString(); ;
          //  string stDate = Calendar1.SelectedDate.ToShortDateString();
          //  //   Teacher.CreateBatch(teacherid, dateCreated, timeCreated,subid, gradeid, maxStu, stDate);
          //  // get batch name from stored procedure

            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GiveTasktoStudent", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(Session ["TeacherID"].ToString());
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@bid", SqlDbType.Int);
            parm.Value = DropDownListBatchName.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@tskname", SqlDbType.VarChar);
            parm.Value = DropDownTaskName.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@stdate", SqlDbType.Date);
            parm.Value = DateTime.Parse(stdate.SelectedDate.ToShortDateString()).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@enddate", SqlDbType.Date);
            parm.Value = DateTime.Parse(enddate.SelectedDate.ToShortDateString()).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@endtime", SqlDbType.Time);
            parm.Value = DateTime.Parse(lblendtime.Text).TimeOfDay;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

           
            c.Open();
            cmd.ExecuteNonQuery();

           // Label2.Text = "Batch has been created successfully.";
            //Label11.Text = "The Batch Name is: " + cmd.Parameters["@BName"].Value.ToString();
            //Label2.Visible = true;
            //Label11.Visible = true;
            c.Close();
        }
    }
}