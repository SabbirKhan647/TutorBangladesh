using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Tutor.Class;
namespace Tutor.TeacherManagement
{

    public partial class MyBatchesAsTutor : System.Web.UI.Page
    {
        //  public event EventHandler<EventArgs> FooterDropDownListDay_SelectedIndexChanged;
        int intBatchID = 0;
        SqlConnection c;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();

            if (!IsPostBack)
            {
                GetBatchData();
                //string strteacherid=Session ["TeacherID"].ToString();
                //int intTeacherID = Convert.ToInt32(strteacherid);
                //string cmdText = "select * from Batch1 where teacherid= "+intTeacherID ;

                //gvBatch.DataSource = GetBatchDetailsData(cmdText);
                //gvBatch.DataBind();
            }
        }
        #region functions
        private static DataTable GetBatchDetailsData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString;
            //   SqlConnection con = new SqlConnection(@"Data Source=OWNER-KABIR\SQLSERVER2012;Initial Catalog=Northwind;Integrated Security=True");
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
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
            //SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            //c.Open();
            ////string cmdText = "SELECT BatchID, MaxStudent FROM Batch1 where ";
            ////cmdText += "TeacherID = " + Convert.ToInt32(Session["TeacherID"]);
            //string cmdText = "select * from batch1";
            //SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            //DataTable dd = new DataTable();
            //adapt.Fill(dd);
            //gvBatch.DataSource = dd;
            //gvBatch.DataBind();

            //if (c != null)
            //{
            //    c.Close();
            //}

        }

        #endregion

        #region GridView Batch Event Handlers
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //populate dropdownlist in parent gridview edit itemtemplate
                    DropDownList editDrSubject = (DropDownList)e.Row.FindControl("EditDropDownListSubject");

                    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                    c.Open();
                    SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
                    DataTable d = new DataTable();
                    Adapter.Fill(d);
                    editDrSubject.DataSource = d;
                    editDrSubject.DataTextField = "SubName";
                    editDrSubject.DataValueField = "SubjectID";
                    editDrSubject.DataBind();
                    editDrSubject.Items.Insert(0, new ListItem("Select Subject", "0"));
                    //populate dropdownlist in parent gridview edit itemtemplate
                    DropDownList drGrade = (DropDownList)e.Row.FindControl("EditDropDownListGrade");
                    Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
                    d = new DataTable(); Adapter.Fill(d);
                    drGrade.DataSource = d; drGrade.DataTextField = "GradeName"; drGrade.DataValueField = "GradeID";
                    drGrade.DataBind();
                    drGrade.Items.Insert(0, new ListItem("Select Grade", "0"));
                    if (c != null)
                    {
                        c.Close();
                    }

                }

                string strBatchID = gvBatch.DataKeys[e.Row.RowIndex].Value.ToString();
                int intBatchID = Convert.ToInt32(strBatchID);
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;

                foreach (GridView row in gvBDetails.Rows)
                {
                    DropDownList drDay = (DropDownList)gvBDetails.FooterRow.FindControl("FooterDropDownListDay");
                    drDay.Items.Add("Saturday"); drDay.Items.Add("Friday");
                }

                string cmdText = "select * from BatchDay where BatchID = " + intBatchID;
                gvBDetails.DataSource = GetBatchDetailsData(cmdText);
                gvBDetails.DataBind();


            }
        }
        protected void gvBatch_DataBound(object sender, EventArgs e)
        {
           

            ////filling footer dropdownlist with subject name
            //DropDownList drSubject = (DropDownList)gvBatch.FooterRow.FindControl("DropDownListSubject");

            //SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            //SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
            //DataTable d = new DataTable();
            //Adapter.Fill(d);
            //drSubject.DataSource = d;
            //drSubject.DataTextField = "SubName";
            //drSubject.DataValueField = "SubjectID";
            //drSubject.DataBind();
            //drSubject.Items.Insert(0, new ListItem("Select Subject", "0"));


            ////filling footer dropdownlist with grade name
            //DropDownList drGrade = (DropDownList)gvBatch.FooterRow.FindControl("DropDownListGrade");
            //Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
            //d = new DataTable(); Adapter.Fill(d);
            //drGrade.DataSource = d; drGrade.DataTextField = "GradeName"; drGrade.DataValueField = "GradeID";
            //drGrade.DataBind();
            //drGrade.Items.Insert(0, new ListItem("Select Grade", "0"));




            //if (c != null)
            //{
            //    c.Close();
            //}


        }


        protected void gvBatch_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBatch.EditIndex = e.NewEditIndex;
            GetBatchData();
        }
        protected void gvBatch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();

            string strBatchID = gvBatch.DataKeys[e.RowIndex].Value.ToString();
            int intBatchID = Convert.ToInt32(strBatchID);
            SqlCommand cmd = new SqlCommand("Delete from Batch where BatchID = @bid", c);
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = intBatchID;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            gvBatch.EditIndex = -1;

            GetBatchData();

            //   Label1.Text = "Record deleted successfully.";
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
        //fire nested gridview events from parent gridview
        protected void gvBatch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;

                gvBDetails.RowEditing += new GridViewEditEventHandler(gvBDetails_RowEditing);
                gvBDetails.RowCancelingEdit += new GridViewCancelEditEventHandler(gvBDetails_RowCancelingEdit);
                gvBDetails.RowCommand += new GridViewCommandEventHandler(gvBDetails_RowCommand);
                gvBDetails.RowDeleting += new GridViewDeleteEventHandler(gvBDetails_RowDeleting);

            }
        }

        protected void gvBDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddBatchDetails")
            {
                try
                {
                    //  if(!IsPostBack)
                    //if (e.Row.RowType == DataControlRowType.Footer)
                    //    {
                    GridView gvTemp = (GridView)sender;
                    //   string strBatchID = ((Label)gvTemp.Row[e.RowIndex].FindControl("lblCustomerID")).Text;
                    //  string strBatchID = (gvTemp.Row[e.index].FindControl("FooterDropDownListDay") as DropDownList).SelectedItem.Value;

                    // string strBatchID = gvTemp.Rows[1].Cells[1].ToString();
                    //int intBatchID = Convert.ToInt32(strBatchID);
                    //Label1.Text = "batch id: " + strBatchID;
                    //   DropDownList drp = (DropDownList)gvTemp.Controls[0].Controls[0].FindControl("FooterDropDownListDay");
                    //   string drDay = (gvTemp.FooterRow.FindControl("FooterDropDownListDay") as DropDownList).SelectedValue;
                    //   Label1.Text = "you selected: " + drDay;
                    string drDay = Session["Day"].ToString();
                    Label1.Text = "you selected: " + drDay;
                    string sttime = (gvTemp.FooterRow.FindControl("ChildFooterDropDownListStartTime") as DropDownList).SelectedValue;
                    DateTime sttime1 = Convert.ToDateTime(sttime);
                    string endtime = (gvTemp.FooterRow.FindControl("ChildFooterDropDownListStartTime") as DropDownList).SelectedValue;
                    DateTime endtime1 = Convert.ToDateTime(endtime);
                    TimeSpan duration1 = endtime1.Subtract(sttime1);
                    double p = duration1.TotalMilliseconds;
                    float duration = Convert.ToInt32(p / 3600000);
                    //string sttime1 = "03:00:00";
                    //string endtime1 = "05:00:00";

                    int intBatchID = 18;
                    c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                    c.Open();
                    String insertString = "insert into BatchDetails(BatchID,Day, startTime, endTime,Duration)";
                    insertString += "values(@batchid,@day, @stTime, @endTime,@duration)";
                    SqlCommand cmd1 = new SqlCommand(insertString, c);
                    cmd1.Parameters.Add("@batchid", SqlDbType.Int).Value = intBatchID;
                    cmd1.Parameters.Add("@day", SqlDbType.VarChar).Value = drDay;
                    cmd1.Parameters.Add("@stTime", SqlDbType.Time).Value = DateTime.Parse(sttime).TimeOfDay;
                    cmd1.Parameters.Add("@endTime", SqlDbType.Time).Value = DateTime.Parse(endtime).TimeOfDay;
                    cmd1.Parameters.Add("@duration", SqlDbType.Float).Value = duration;
                    //3. Call ExecuteNonQuery to send the command
                    cmd1.ExecuteNonQuery();
                    //5. Close the connection
                    gvBatch.DataBind();
                    GetBatchData();
                    // }
                }
                catch (Exception ex)
                {
                    //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
                }
                finally
                {
                    if (c != null)
                    {
                        c.Close();
                    }
                    //   Label1.Text = "insert succwssfull";
                }

            }
        }
        #endregion
        #region GridView BatchDetails Event Handlers
        protected void childOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //populate dropdownlist in child gridview edit itemtemplate
                    DropDownList editDrStartTime = (DropDownList)e.Row.FindControl("ChildDropDownListStartTime");
                    for (int i = 420; i < 1460; i++)
                    {
                        editDrStartTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                        i = i + 29;
                    }

                    DropDownList editDrEndTime = (DropDownList)e.Row.FindControl("ChildDropDownListEndTime");
                    for (int i = 480; i < 1460; i++)
                    {
                        editDrEndTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                        i = i + 29;
                    }


                    DropDownList editDay = (DropDownList)e.Row.FindControl("EditDropDownListDay");
                    editDay.Items.Add("Saturday"); editDay.Items.Add("Sunday"); editDay.Items.Add("Monday");
                    editDay.Items.Add("Tuesday"); editDay.Items.Add("Wednesday"); editDay.Items.Add("Thursday"); editDay.Items.Add("Friday");
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //populate dropdownlist in child gridview footer template
                //DropDownList footerDay = (DropDownList)e.Row.FindControl("FooterDropDownListDay");
                //footerDay.Items.Add("Saturday"); footerDay.Items.Add("Sunday"); footerDay.Items.Add("Monday");
                //footerDay.Items.Add("Tuesday"); footerDay.Items.Add("Wednesday"); footerDay.Items.Add("Thursday"); footerDay.Items.Add("Friday");
                //DropDownList footerstTime = (DropDownList)e.Row.FindControl("ChildFooterDropDownListStartTime");
                //for (int i = 420; i < 1460; i++)
                //{
                //    footerstTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                //    i = i + 29;
                //}
                //DropDownList footerEndTime = (DropDownList)e.Row.FindControl("ChildFooterDropDownListEndTime");
                //for (int i = 480; i < 1460; i++)
                //{
                //    footerEndTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                //    i = i + 29;
                //}
            }
        }
        protected void gvBDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label1.Text = "delete button works";
            GridView gvTemp = (GridView)sender;
            //Label batchid = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblBatchID");
            //int b = Convert.ToInt32(batchid.Text);
            int b1 = 12;
            Label lblDay = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblDay");
            string strDay = lblDay.Text;
            Label1.Text = "day: " + strDay;
            //Label lblsttime = (Label)gvTemp.Rows[e.RowIndex].FindControl("lblStartTime");
            //TimeSpan timeSTime = DateTime.Parse(lblsttime).TimeOfDay;
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();

            SqlCommand cmd = new SqlCommand("Delete from BatchDay where BatchID = @bid, DayName=@day", c);
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@bid";
            param.Value = b1;
            cmd.Parameters.Add(param);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@day";
            param1.Value = strDay;
            cmd.Parameters.Add(param1);
            //SqlParameter param2 = new SqlParameter();
            //param2.ParameterName = "@sttime";
            //param2.Value = strDay;
            //cmd.Parameters.Add(param2);

            cmd.ExecuteNonQuery();
            gvTemp.EditIndex = -1;
            //string cmdText = "select * from BatchDetails where BatchID = " + intBatchID;
            //GetBatchDetailsData();

            Label1.Text = "Record deleted successfully.";
            if (c != null)
            {
                c.Close();
            }
        }
        protected void gvBDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView gvBDetails = (GridView)sender;
            gvBDetails.EditIndex = -1;
            string cmdText = "select * from BatchDay ";
            gvBDetails.DataSource = GetBatchDetailsData(cmdText);
            gvBDetails.DataBind();
            gvBDetails.Visible = true;
            // LoadData();
        }
        protected void childDataBound(object sender, EventArgs e)
        {

        }
        protected void gvBDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label1.Text = "edit button is working";
            GridView gvBDetails = (GridView)sender;
            gvBDetails.EditIndex = e.NewEditIndex;
            string cmdText = "select * from BatchDay ";
            gvBDetails.DataSource = GetBatchDetailsData(cmdText);
            gvBDetails.DataBind();
            gvBDetails.Visible = true;
            // LoadData();
        }
        #endregion
        #region dropdown selected index change
        protected void FooterDropDownListDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ControlCollection SearchThroughThis = gvBatch.FooterRow.Controls;
            //  DropDownList ddl = (DropDownList)sender;
            Control senderControl = (Control)sender;
            GridViewRow row = (GridViewRow)senderControl.NamingContainer;
            GridView gv = (GridView)row.FindControl("gvBatchDetails");
            DropDownList ddl = (DropDownList)gv.FooterRow.FindControl("FooterDropDownListDay");
            //ControlCollection SearchThroughThis = gvBatch.Rows[0].Cells[0].Controls;
            //for (int i = 0; i < SearchThroughThis.Count; i++)
            //{
            //    if (SearchThroughThis[i].GetType() == GridView)
            //    {
            //        GridView myGridView = SearchThroughThis[i];
            //        //do stuff
            //    }
            //}
            // GridView dl=gvBatch .Columns [0].
            //   CType(gvBatch.Rows(gvBatch.SelectedIndex).Cells(0).FindControl("DropDownList1"), DropDownList).SelectedValue = 0 Then
            //  GridView gvBDetails = e.Row.FindControl("gvBatchDetails") as GridView;

            //  Session["Day"] = ((DropDownList)sender).SelectedValue;
            Session["Day"] = ddl.SelectedValue;
            ddl.AutoPostBack = true;
        }
        #endregion

        protected void gvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "AddBatch")
            //{ 
            //try
            //     {

            //             GridView gvTemp = (GridView)sender;

            //              //string drDay = Session["Day"].ToString();
            //              //Label1.Text = "you selected: " + drDay;
            //             DropDownList subject = (gvTemp.FooterRow.FindControl("DropDownListSubject") as DropDownList);
            //             int subjectid=Convert.ToInt32(subject.DataValueField) ;
            //             //DateTime sttime1 = Convert.ToDateTime(sttime);
            //             //string endtime = (gvTemp.FooterRow.FindControl("ChildFooterDropDownListStartTime") as DropDownList).SelectedValue;
            //             //DateTime endtime1 = Convert.ToDateTime(endtime);
            //             //TimeSpan duration1 = endtime1.Subtract(sttime1);
            //             //double p = duration1.TotalMilliseconds;
            //             //float duration = Convert.ToInt32(p / 3600000);
            //             ////string sttime1 = "03:00:00";
            //             //string endtime1 = "05:00:00";

            //             int intBatchID = 18;
            //             c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            //             c.Open();
            //             String insertString = "insert into BatchDetails(BatchID,Day, startTime, endTime,Duration)";
            //             insertString += "values(@batchid,@day, @stTime, @endTime,@duration)";
            //             SqlCommand cmd1 = new SqlCommand(insertString, c);
            //             cmd1.Parameters.Add("@batchid", SqlDbType.Int).Value = intBatchID;
            //             cmd1.Parameters.Add("@day", SqlDbType.VarChar).Value = drDay;
            //             cmd1.Parameters.Add("@stTime", SqlDbType.Time).Value = DateTime.Parse(sttime).TimeOfDay;
            //             cmd1.Parameters.Add("@endTime", SqlDbType.Time).Value = DateTime.Parse(endtime).TimeOfDay;
            //             cmd1.Parameters.Add("@duration", SqlDbType.Float).Value = duration;
            //             //3. Call ExecuteNonQuery to send the command
            //             cmd1.ExecuteNonQuery();
            //             //5. Close the connection
            //             gvBatch.DataBind();
            //             GetBatchData();
            //             Label1.Text = "insert successfull";
            //       // }
            //     }
            //     catch (Exception ex)
            //     {
            //       //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
            //     }
            //     finally
            //     {
            //         if (c != null)
            //         {
            //             c.Close();
            //         }

            //     }

            // }
            //}
        }

        protected void gvBatch_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void gvBatch_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //TextBox txtFirstname = (TextBox)DetailsView1.FindControl("txtFirstname");
            //TextBox txtLastName = (TextBox)DetailsView1.FindControl("txtLastName");
            //TextBox txtEmail = (TextBox)DetailsView1.FindControl("txtemail");
            //TextBox txtPhone = (TextBox)DetailsView1.FindControl("txtphone");
            //TextBox txtAddress = (TextBox)DetailsView1.FindControl("txtAddress");
            //DropDownList drDistrict = (DropDownList)DetailsView1.FindControl("drDistrict");
            //DropDownList drDivision = (DropDownList)DetailsView1.FindControl("drDivision");
            //DropDownList drGender = (DropDownList)DetailsView1.FindControl("drGender");
            //TextBox txtinstitute = (TextBox)DetailsView1.FindControl("txtinstitute");
            //TextBox txtdegrees = (TextBox)DetailsView1.FindControl("txtdegrees");
            //TextBox txtprofile = (TextBox)DetailsView1.FindControl("txtprofile");
            ////string Query = "Update Employee Set FirstName='" + txtFirstname.Text + "' ,LastName ='" + txtLastName.Text + "' ,City ='" + txtCity.Text + "',Address='" + txtAddress.Text + "',PinNo='" + txtPinNo.Text + "',MobileNo='" + txtMobileNo.Text + "' where ID =" + lblIDEdit.Text;
            ////ExecuteQuery(Query);

            ////display Tutor Profile
            //SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            //c.Open();
            //SqlCommand cmd = new SqlCommand("UpdateTutorProfile", c);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(Session["TeacherID"].ToString());
            //cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = txtFirstname.Text;
            //cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = txtLastName.Text;
            //cmd.Parameters.Add("@em", SqlDbType.VarChar).Value = txtEmail.Text;
            //cmd.Parameters.Add("@ph", SqlDbType.VarChar).Value = txtPhone.Text;
            //cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = txtAddress.Text;
            //cmd.Parameters.Add("@dis", SqlDbType.VarChar).Value = drDistrict.SelectedValue;
            //cmd.Parameters.Add("@div", SqlDbType.VarChar).Value = drDivision.SelectedValue;
            //cmd.Parameters.Add("@g", SqlDbType.Char).Value = drGender.SelectedValue;
            //cmd.Parameters.Add("@ins", SqlDbType.VarChar).Value = txtinstitute.Text;
            //cmd.Parameters.Add("@deg", SqlDbType.VarChar).Value = txtdegrees.Text;
            //cmd.Parameters.Add("@pro", SqlDbType.VarChar).Value = txtprofile.Text;
            //cmd.ExecuteNonQuery();
            ////SqlDataAdapter da = new SqlDataAdapter(cmd);
            ////DataSet ds = new DataSet();
            ////da.Fill(ds);
            ////DetailsView1.DataSource = ds;
            ////DetailsView1.DataBind();
            ////c.Close();
            //DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            //bindDetailtView();
        }
    }
}
