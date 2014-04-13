using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tutor.TeacherManagement
{
    public partial class batch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
            
                //BoundField bfield = new BoundField();
                //bfield.HeaderText = "B11";
                //bfield.DataField = "BatchID";
                //GridViewBatchByTutor.Columns.Add(bfield);

                //TemplateField tt = new TemplateField();
                //tt.EditItemTemplate = (TextBox)n;
                //n.id = "ll";


            
        }
        private void LoadData()
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
            GridViewBatchByTutor.DataSource = dd;

            GridViewBatchByTutor.DataBind();

            // GridViewBatchByTutor.Visible = true;
            if (c != null)
            {
                c.Close();
            }
        }

        protected void GridViewBatchByTutor_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
          
            
            
        }

        protected void GridViewBatchByTutor_PreRender(object sender, EventArgs e)
        {
            //    this.GridViewBatchByTutor.Columns[1].HeaderText = "Subject Name";
            //}
        }
    }
}