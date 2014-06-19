using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Tutor.Class;
using System.Net;
namespace Tutor.TeacherManagement
{
    public partial class CreateBatch : System.Web.UI.Page
    {
        string subjectname, gradename, maxstudent, startdate, enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  hdPrevURL.Value = Request.UrlReferrer.AbsoluteUri;
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
                Page.Header.DataBind();

                int btchid = Convert.ToInt32(Request.QueryString["ID"]);
                if (btchid != 0)//existing batxh
                {
                   // Label4.Text = btchid.ToString();
                  //  Label4.Visible = true;
                    frmTitle1.Visible = true;
                    BtnUpdateBatch.Visible = true;
                    //check batch status
                    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("CheckBatchStatusBeforeUpdate", c);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parm = new SqlParameter("@bid", SqlDbType.Int);
                    parm.Value = Convert.ToInt32(btchid);
                    parm.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(parm);

                    cmd.Parameters.Add("@result", SqlDbType.VarChar, 25);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    c.Open();
                    cmd.ExecuteNonQuery();

                    string result = cmd.Parameters["@result"].Value.ToString();
                    if (result == "CannotUpdateDayTimeSubjectGradeStartDate")
                    {
                        DropDownListSubject.Enabled = false;
                        DropDownListGrade.Enabled = false;
                        chkListBoxDay.Enabled = false;
                        txtStartDate.Enabled = false;
                        ddlSaturdayStTime.Enabled = false;
                        ddlSundayStTime.Enabled = false;
                        ddlMondayStTime.Enabled = false;
                        ddlTuesdayStTime.Enabled = false;
                        ddlWednesdayStTime.Enabled = false;
                        ddlThursdayStTime.Enabled = false;
                        ddlFridayStTime.Enabled = false;

                        ddlSaturdayEndTime.Enabled = false;
                        ddlSundayEndTime.Enabled = false;
                        ddlMondayEndTime.Enabled = false;
                        ddlTuesdayEndTime.Enabled = false;
                        ddlWednesdayEndTime.Enabled = false;
                        ddlThursdayEndTime.Enabled = false;
                        ddlFridayEndTime.Enabled = false;



                    }
                    if (result == "CanUpdateMaxStudentStartDate")
                    {
                        DropDownListSubject.Enabled = false;
                        DropDownListGrade.Enabled = false;
                        chkListBoxDay.Enabled = false;

                        ddlSaturdayStTime.Enabled = false;
                        ddlSundayStTime.Enabled = false;
                        ddlMondayStTime.Enabled = false;
                        ddlTuesdayStTime.Enabled = false;
                        ddlWednesdayStTime.Enabled = false;
                        ddlThursdayStTime.Enabled = false;
                        ddlFridayStTime.Enabled = false;

                        ddlSaturdayEndTime.Enabled = false;
                        ddlSundayEndTime.Enabled = false;
                        ddlMondayEndTime.Enabled = false;
                        ddlTuesdayEndTime.Enabled = false;
                        ddlWednesdayEndTime.Enabled = false;
                        ddlThursdayEndTime.Enabled = false;
                        ddlFridayEndTime.Enabled = false;



                    }

                    DisplayBatch(btchid);
                    GetSelectedData();
                }
                else  //new batch
                {
                    GetAllList();
                    frmTitle.Visible = true;
                    BtnGenerate.Visible = true;
                }
            }
        }

        private void GetSelectedData()
        {

            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
            DataTable d = new DataTable(); Adapter.Fill(d);
            DropDownListSubject.DataSource = d; DropDownListSubject.DataTextField = "SubName";
            DropDownListSubject.DataValueField = "SubjectID";
            DropDownListSubject.DataBind();
            DropDownListSubject.Items.FindByText(subjectname).Selected = true;

            Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
            d = new DataTable(); Adapter.Fill(d);
            DropDownListGrade.DataSource = d; DropDownListGrade.DataTextField = "GradeName";
            DropDownListGrade.DataValueField = "GradeID";
            DropDownListGrade.DataBind();
            DropDownListGrade.Items.FindByText(gradename).Selected = true;

            c.Close();
            for (int i = 1; i <= 30; i++)
            {
                string j = Convert.ToString(i);
                DropDownNoOfStu.Items.Add(j);
            }
            DropDownNoOfStu.Items.FindByText(maxstudent).Selected = true;
            txtStartDate.Text = startdate;
            txtEndDate.Text = enddate;

        }
        //for new batch
        private void GetAllList()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
            DataTable d = new DataTable(); Adapter.Fill(d);
            DropDownListSubject.DataSource = d; DropDownListSubject.DataTextField = "SubName";
            DropDownListSubject.DataValueField = "SubjectID";
            DropDownListSubject.DataBind();
            // To make it the first element at the list, use 0 index : 
            DropDownListSubject.Items.Insert(0, new ListItem("Select", string.Empty));
            Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
            d = new DataTable(); Adapter.Fill(d);
            DropDownListGrade.DataSource = d; DropDownListGrade.DataTextField = "GradeName";
            DropDownListGrade.DataValueField = "GradeID";
            DropDownListGrade.DataBind();
            // To make it the first element at the list, use 0 index : 
            DropDownListGrade.Items.Insert(0, new ListItem("Select", string.Empty));

            if (c != null)
            {
                c.Close();
            }
            for (int i = 1; i <= 30; i++)
            {
                string j = Convert.ToString(i);
                DropDownNoOfStu.Items.Add(j);
            }
            //// To make it the first element at the list, use 0 index : 
            DropDownNoOfStu.Items.Insert(0, new ListItem("Select", string.Empty));
            FillTimeDropDownLists();

        }

        private void DisplayBatch(int btchid)
        {

            FillTimeDropDownLists();
            string founditem = null;
            SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand("DisplayBatchDataforUpdate", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = btchid;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                subjectname = rdr.GetString(0);
                gradename = rdr.GetString(1);
                maxstudent = rdr.GetString(2);
                startdate = rdr.GetString(3);
                enddate = rdr.GetString(4);

            }
            c.Close();
            c.Open();
            cmd = new SqlCommand("DisplayBatchTIMINGforUpdate", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = btchid;
            cmd.ExecuteNonQuery();


            SqlDataAdapter adapt = new SqlDataAdapter(cmd);


            DataTable d = new DataTable();
            adapt.Fill(d);
            if (d.Rows.Count > 0)
            {

                int p = 0;
                string g = null;
                string previousrowDayName = null;
                foreach (DataRow row in d.Rows)
                {

                    foreach (DataColumn col in d.Columns)
                    {

                     //   Label2.Text = col.ColumnName.ToString();
                    //    Label2.Visible = true;
                        //compare day name
                        switch (col.ColumnName.ToString())
                        //  switch (col.)
                        {
                            case "DayName":
                                founditem = row[col].ToString();
                                if (previousrowDayName != founditem)
                                {

                                    for (int i = 0; i < chkListBoxDay.Items.Count; i++)
                                    {
                                        if (chkListBoxDay.Items[i].Text == founditem)
                                        {
                                            chkListBoxDay.Items[i].Selected = true;
                                            if (previousrowDayName == null)
                                            {
                                                previousrowDayName = chkListBoxDay.Items[i].Text;

                                            }
                                        }
                                    }
                                }
                                break;
                            case "StartTime":

                                founditem = row[col].ToString();
                           //     Label11.Text = founditem;
                           //     Label11.Visible = true;
                                for (int i = 0; i < chkListBoxDay.Items.Count; i++)
                                {

                                    if (chkListBoxDay.Items[i].Selected)
                                    {
                                        if (previousrowDayName != chkListBoxDay.Items[i].Text && p > 0)
                                        {
                                            switch (i)
                                            {
                                                case 0:


                                                    ddlSaturdayStTime.Items.FindByText(founditem).Selected = true;

                                                    break;
                                                case 1:


                                                    ddlSundayStTime.Items.FindByText(founditem).Selected = true;

                                                    break;
                                                case 2:

                                                    ddlMondayStTime.Items.FindByText(founditem).Selected = true;

                                                    break;
                                                case 3:

                                                    ddlTuesdayStTime.Items.FindByText(founditem).Selected = true;

                                                    break;
                                                case 4:

                                                    ddlWednesdayStTime.Items.FindByText(founditem).Selected = true;

                                                    break;
                                                case 5:

                                                    ddlThursdayStTime.Items.FindByText(founditem).Selected = true;

                                                    break;
                                                default:

                                                    ddlFridayStTime.Items.FindByText(founditem).Selected = true;

                                                    break;

                                            }
                                        }
                                        if (p == 0)
                                        {
                                            switch (i)
                                            {
                                                case 0:

                                                    ddlSaturdayStTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 1:

                                                    ddlSundayStTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 2:

                                                    ddlMondayStTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 3:

                                                    ddlTuesdayStTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 4:

                                                    ddlWednesdayStTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 5:

                                                    ddlThursdayStTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                default:

                                                    ddlFridayStTime.Items.FindByText(founditem).Selected = true;
                                                    break;

                                            }
                                        }
                                    }

                                }
                                break;
                            default:
                                founditem = row[col].ToString();
                       //         Label11.Text = founditem;
                          //      Label11.Visible = true;
                                for (int i = 0; i < chkListBoxDay.Items.Count; i++)
                                {
                                    if (chkListBoxDay.Items[i].Selected)
                                    {
                                        if (previousrowDayName != chkListBoxDay.Items[i].Text && p > 0)
                                        {
                                            switch (i)
                                            {
                                                case 0:

                                                    ddlSaturdayEndTime.Items.FindByText(founditem).Selected = true;
                                                    //ddlSaturdayEndTime.BackColor = System.Drawing.Color.Gray;
                                                    break;
                                                case 1:

                                                    ddlSundayEndTime.Items.FindByText(founditem).Selected = true;
                                                    //ddlSundayEndTime.BackColor = System.Drawing.Color.Gray;
                                                    break;
                                                case 2:

                                                    ddlMondayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 3:

                                                    ddlTuesdayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 4:

                                                    ddlWednesdayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 5:

                                                    ddlThursdayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                default:

                                                    ddlFridayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;

                                            }
                                        }
                                        if (p == 0)
                                        {
                                            switch (i)
                                            {
                                                case 0:

                                                    ddlSaturdayEndTime.Items.FindByText(founditem).Selected = true;
                                                 
                                                    break;
                                                case 1:

                                                    ddlSundayEndTime.Items.FindByText(founditem).Selected = true;

                                                    break;
                                                case 2:

                                                    ddlMondayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 3:

                                                    ddlTuesdayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                case 4:

                                                    ddlWednesdayEndTime.Items.FindByText(founditem).Selected = true;
                                                  
                                                    break;
                                                case 5:

                                                    ddlThursdayEndTime.Items.FindByText(founditem).Selected = true;
                                                    break;
                                                default:

                                                    ddlFridayEndTime.Items.FindByText(founditem).Selected = true;

                                                    break;

                                            }
                                        }
                                    }
                                }
                                break;

                        }//end outer swich case

                    }// end inner for loop
                    p++;
                }
            }









            c.Close();


        }



        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            lblTimeConflictSat.Visible = false;
            lblTimeConflictSun.Visible = false;
            lblTimeConflictMon.Visible = false;
            lblTimeConflictTues.Visible = false;
            lblTimeConflictWed.Visible = false;
            lblTimeConflictThu.Visible = false;
            lblTimeConflictFri.Visible = false;

            lblSmallEndTimeSat.Visible = false;
            lblSmallEndTimeSun.Visible = false;
            lblSmallEndTimeMon.Visible = false;
            lblSmallEndTimeTues.Visible = false;
            lblSmallEndTimeWed.Visible = false;
            lblSmallEndTimeThu.Visible = false;
            lblSmallEndTimeFri.Visible = false;

            lblBatchCreationUpdateMsg.Visible = false;
            lblBatchName.Visible = false;
            MessagePanel.Visible = false;
            //validationresult array hold two validation check results; smallendtime and timeconflict
            string[] validationresult = new string[14];
        
           
            validationresult = Validation();
          
            if (validationresult[0].Equals ("false") && validationresult[1].Equals ("false")
                && validationresult[2].Equals("false") && validationresult[3].Equals("false")
                && validationresult[4].Equals("false") && validationresult[5].Equals("false")
                && validationresult[6].Equals("false") && validationresult[7].Equals("false")
                && validationresult[8].Equals("false") && validationresult[9].Equals("false")
                && validationresult[10].Equals("false") && validationresult[11].Equals("false")
                && validationresult[12].Equals("false") && validationresult[13].Equals("false"))
            {
                 string bid = NewBatch();
                 BatchDayTVP(bid);
            }

        }

        private string[] Validation()
        {
            string[] validationresult = new string[14];
            //initialize array elements to false
            for (int i = 0; i < 14; i++)
            {
                validationresult[i] = "false";
            }
           
            int teacherid = Convert.ToInt16(Session["TeacherID"]);
            string conflict = null;
            TimeSpan sttime = TimeSpan.Zero;
            TimeSpan endtime = TimeSpan.Zero;
            for (int i = 0; i < chkListBoxDay.Items.Count; i++)
            {

                if (chkListBoxDay.Items[i].Selected)
                {
                    switch (i)
                    {
                        case 0:
                            sttime = DateTime.Parse(ddlSaturdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlSaturdayEndTime.SelectedItem.Text).TimeOfDay;
                            //compare starttime is bigger than endtime
                            int timediff = sttime.CompareTo(endtime);
                            if (timediff < 0)//small end time
                            {
                                conflict = timeconflict(teacherid, chkListBoxDay.Items[i].Text, sttime, endtime);
                                if (conflict == "1")
                                {
                                    lblTimeConflictSat.Text = "Time conflict on " + chkListBoxDay.Items[i].Text + ". Select another day/ time.";
                                    lblTimeConflictSat.Visible = true;
                                    MessagePanel.Visible = true;                              
                                    validationresult[1] = "true";//conflict
                                    validationresult[0] = "false";//not bigger
                                }
                                else
                                {
                                    validationresult[1] = "false";//no conflict
                                    validationresult[0] = "false";//not bigger
                                
                                }
                            }
                            else
                            {
                                lblSmallEndTimeSat.Text = "On " + chkListBoxDay.Items[i].Text + ", end tine should be bigger than start time.";
                                lblSmallEndTimeSat.Visible = true;
                                MessagePanel.Visible = true;
                                                         
                                validationresult[0] = "true";//bigger
                            }
                            break;
                        case 1:
                            sttime = DateTime.Parse(ddlSundayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlSundayEndTime.SelectedItem.Text).TimeOfDay;
                            timediff = sttime.CompareTo(endtime);
                            if (timediff < 0)
                            {
                                conflict = timeconflict(teacherid, chkListBoxDay.Items[i].Text, sttime, endtime);
                                if (conflict == "1")
                                {
                                    lblTimeConflictSun.Text = "Time conflict on " + chkListBoxDay.Items[i].Text + ". Select another day/ time.";
                                    lblTimeConflictSun.Visible = true;
                                    MessagePanel.Visible = true;                              
                                 
                                    validationresult[3] = "true";//conflict
                                    validationresult[2] = "false";//not bigger
                                }
                                else
                                {
                                  
                                    validationresult[3] = "false";//no conflict
                                    validationresult[2] = "false";//not bigger
                                  
                                }
                            }
                            else
                            {
                                lblSmallEndTimeSun.Text = "On " + chkListBoxDay.Items[i].Text + ", end tine should be bigger than start time.";
                                lblSmallEndTimeSun.Visible = true;
                                MessagePanel.Visible = true;
                                //validationresult [0]="true";
                                validationresult[2] = "true";
                         
                            }
                            break;
                        case 2:
                            sttime = DateTime.Parse(ddlMondayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlMondayEndTime.SelectedItem.Text).TimeOfDay;
                            timediff = sttime.CompareTo(endtime);
                            if (timediff < 0)
                            {
                                conflict = timeconflict(teacherid, chkListBoxDay.Items[i].Text, sttime, endtime);
                                if (conflict == "1")
                                {
                                    lblTimeConflictMon.Text = "Time conflict on " + chkListBoxDay.Items[i].Text + ". Select another day/ time.";
                                    lblTimeConflictMon.Visible = true;
                                    MessagePanel.Visible = true;
                                
                                    //validationresult[1] = "true";//conflict
                                    //validationresult[0] = "false";//not bigger
                                    validationresult[5] = "true";//conflict
                                    validationresult[4] = "false";//not bigger
                                }
                                else
                                {
                                    //validationresult[1] = "false";//no conflict
                                    //validationresult[0] = "false";//not bigger
                                    validationresult[5] = "false";//no conflict
                                    validationresult[4] = "false";//not bigger
                                }
                            }
                            else
                            {
                                lblSmallEndTimeSun.Text = "On " + chkListBoxDay.Items[i].Text + ", end tine should be bigger than start time.";
                                lblSmallEndTimeSun.Visible = true;
                                MessagePanel.Visible = true;
                             
                                //validationresult[0] = "true";
                                validationresult[4] = "true";
                            }
                            break;
                        case 3:
                            sttime = DateTime.Parse(ddlTuesdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlTuesdayEndTime.SelectedItem.Text).TimeOfDay;
                            timediff = sttime.CompareTo(endtime);
                            if (timediff < 0)
                            {
                                conflict = timeconflict(teacherid, chkListBoxDay.Items[i].Text, sttime, endtime);
                                if (conflict == "1")
                                {
                                   lblTimeConflictTues .Text  = "Time conflict on " + chkListBoxDay.Items[i].Text + ". Select another day/ time.";
                                   lblTimeConflictTues.Visible = true;
                                    MessagePanel.Visible = true;
                               
                                    //validationresult[1] = "true";//conflict
                                    //validationresult[0] = "false";//not bigger
                                    validationresult[7] = "true";//conflict
                                    validationresult[6] = "false";//not bigger
                                }
                                else
                                {
                                    //validationresult[1] = "false";//no conflict
                                    //validationresult[0] = "false";//not bigger
                                    validationresult[7] = "false";//no conflict
                                    validationresult[6] = "false";//not bigger
                                   
                                }
                            }
                            else
                            {
                               lblSmallEndTimeTues .Text  = "On " + chkListBoxDay.Items[i].Text + ", end tine should be bigger than start time.";
                               lblSmallEndTimeTues .Visible = true;
                                MessagePanel.Visible = true;
                                //validationresult [0]="true";
                                validationresult[6] = "true";
                            }
                            break;
                        case 4:
                            sttime = DateTime.Parse(ddlWednesdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlWednesdayEndTime.SelectedItem.Text).TimeOfDay;
                            timediff = sttime.CompareTo(endtime);
                            if (timediff < 0)
                            {
                                conflict = timeconflict(teacherid, chkListBoxDay.Items[i].Text, sttime, endtime);
                                if (conflict == "1")
                                {
                                    lblTimeConflictWed.Text = "Time conflict on " + chkListBoxDay.Items[i].Text + ". Select another day/ time.";
                                    lblTimeConflictWed.Visible = true;
                                    MessagePanel.Visible = true;
                                    validationresult[9] = "true";//conflict
                                    validationresult[8] = "false";//not bigger
                                }
                                else
                                {
                                    validationresult[9] = "false";//no conflict
                                    validationresult[8] = "false";//not bigger
                                }
                            }
                            else
                            {
                                lblSmallEndTimeWed.Text = "On " + chkListBoxDay.Items[i].Text + ", end tine should be bigger than start time.";
                                lblSmallEndTimeWed.Visible = true;
                                MessagePanel.Visible = true;
                                //validationresult[0] = "true";
                                validationresult[8] = "true";
                            }
                            break;
                        case 5:
                            sttime = DateTime.Parse(ddlThursdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlThursdayEndTime.SelectedItem.Text).TimeOfDay;
                            timediff = sttime.CompareTo(endtime);
                            if (timediff < 0)
                            {
                                conflict = timeconflict(teacherid, chkListBoxDay.Items[i].Text, sttime, endtime);
                                if (conflict == "1")
                                {
                                    lblTimeConflictThu.Text = "Time conflict on " + chkListBoxDay.Items[i].Text + ". Select another day/ time.";
                                    lblTimeConflictThu.Visible = true;
                                    MessagePanel.Visible = true;
                                    //validationresult[1] = "true";//conflict
                                    //validationresult[0] = "false";//not bigger
                                    validationresult[11] = "true";//conflict
                                    validationresult[10] = "false";//not bigger
                                }
                                else
                                {
                                    //validationresult[1] = "false";//no conflict
                                    //validationresult[0] = "false";//not bigger

                                    validationresult[11] = "false";//no conflict
                                    validationresult[10] = "false";//not bigger
                                  
                                }
                            }
                            else
                            {
                                lblSmallEndTimeThu.Text = "On " + chkListBoxDay.Items[i].Text + ", end tine should be bigger than start time.";
                                lblSmallEndTimeThu.Visible = true;
                                MessagePanel.Visible = true;
                                //validationresult[0] = "true";
                                validationresult[10] = "true";
                            }
                            break;
                        default:
                            sttime = DateTime.Parse(ddlFridayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlFridayEndTime.SelectedItem.Text).TimeOfDay;
                            timediff = sttime.CompareTo(endtime);
                            if (timediff < 0)
                            {
                                conflict = timeconflict(teacherid, chkListBoxDay.Items[i].Text, sttime, endtime);
                                if (conflict == "1")
                                {
                                    lblTimeConflictFri.Text = "Time conflict on " + chkListBoxDay.Items[i].Text + ". Select another day/ time.";
                                    lblTimeConflictFri.Visible = true;
                                    MessagePanel.Visible = true;
                                    //validationresult[1] = "true";//conflict
                                    //validationresult[0] = "false";//not bigger
                                    validationresult[13] = "true";//conflict
                                    validationresult[12] = "false";//not bigger
                                }
                                else
                                {
                                    //validationresult[1] = "false";//no conflict
                                    //validationresult[0] = "false";//not bigger
                                    validationresult[13] = "false";//no conflict
                                    validationresult[12] = "false";//not bigger
                                   
                                }
                            }
                            else
                            {
                                lblSmallEndTimeFri .Text = "On " + chkListBoxDay.Items[i].Text + ", end tine should be bigger than start time.";
                                lblSmallEndTimeFri.Visible = true;
                                MessagePanel.Visible = true;
                                //validationresult[0] = "true";
                                validationresult[12] = "true";
                            }
                            break;

                    }
                }


                sttime = TimeSpan.Zero;
                endtime = TimeSpan.Zero;

            }
            return validationresult;//return array 
        }

        private void BatchDayTVP(string bid)
        {
            int batchid = Convert.ToInt16(bid);
            DataTable d = CreateDataTable1(batchid);


            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("BatchDayTVPSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@dayTimeTVP", d); //Needed TVP
            tvpParam.SqlDbType = SqlDbType.Structured; //tells ADO.NET we are passing TVP
            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();
            //Label4.Text = "batch day is inserted successfully.";
            //Label4.Visible = true;
        }

        private DataTable CreateDataTable1(int batchid)
        {
             int teacherid = Convert.ToInt16(Session["TeacherID"]);
             TimeSpan sttime = TimeSpan.Zero;
            TimeSpan endtime = TimeSpan.Zero;
            //passing table value parameters  to insert multiple records at one round-trip to one-to-many tables
            DataTable dt;
            // create data table to insert items
            dt = new DataTable("TVPBatchDay");
            dt.Columns.Add("BatchID", typeof(int));
            dt.Columns.Add("DayName", typeof(string));
            dt.Columns.Add("startTime", typeof(TimeSpan));
            dt.Columns.Add("endtime", typeof(TimeSpan));

            for (int i = 0; i < chkListBoxDay.Items.Count; i++)
            {

                if (chkListBoxDay.Items[i].Selected)
                {
                    switch (i)
                    {
                        case 0:

                            sttime = DateTime.Parse(ddlSaturdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlSaturdayEndTime.SelectedItem.Text).TimeOfDay;
                         
                                    dt.Rows.Add(batchid, chkListBoxDay.Items[i].Text, sttime, endtime);
                          
                            break;
                        case 1:


                            sttime = DateTime.Parse(ddlSundayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlSundayEndTime.SelectedItem.Text).TimeOfDay;
                          
                                    dt.Rows.Add(batchid, chkListBoxDay.Items[i].Text, sttime, endtime);
                       
                            break;
                        case 2:
                            sttime = DateTime.Parse(ddlMondayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlMondayEndTime.SelectedItem.Text).TimeOfDay;
                           
                                    dt.Rows.Add(batchid, chkListBoxDay.Items[i].Text, sttime, endtime);
                         
                            break;
                        case 3:
                            sttime = DateTime.Parse(ddlTuesdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlTuesdayEndTime.SelectedItem.Text).TimeOfDay;
                           
                                    dt.Rows.Add(batchid, chkListBoxDay.Items[i].Text, sttime, endtime);
                         
                            break;
                        case 4:
                            sttime = DateTime.Parse(ddlWednesdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlWednesdayEndTime.SelectedItem.Text).TimeOfDay;
                           
                                    dt.Rows.Add(batchid, chkListBoxDay.Items[i].Text, sttime, endtime);
                          
                            break;
                        case 5:
                            sttime = DateTime.Parse(ddlThursdayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlThursdayEndTime.SelectedItem.Text).TimeOfDay;
                          
                                    dt.Rows.Add(batchid, chkListBoxDay.Items[i].Text, sttime, endtime);
                           
                            break;
                        default:
                            sttime = DateTime.Parse(ddlFridayStTime.SelectedItem.Text).TimeOfDay;
                            endtime = DateTime.Parse(ddlFridayEndTime.SelectedItem.Text).TimeOfDay;
                           
                                    dt.Rows.Add(batchid, chkListBoxDay.Items[i].Text, sttime, endtime);
                         
                            break;

                    }
                }


                sttime = TimeSpan.Zero;
                endtime = TimeSpan.Zero;

            }
            return dt;
        }


        private string NewBatch()
        {


            string teacherid = Session["TeacherID"].ToString();

            string maxStu = DropDownNoOfStu.SelectedItem.Text;


            string stDate = txtStartDate.Text;
            string enddate = txtEndDate.Text;
            // get batch name from stored procedure

            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NewBatchSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(teacherid);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@dt", SqlDbType.DateTime);
            parm.Value = DateTime.Today;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

        
            parm = new SqlParameter("@sid", SqlDbType.Int);
            parm.Value = DropDownListSubject.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@gid", SqlDbType.Int);
            parm.Value = DropDownListGrade.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@sd", SqlDbType.Date);
            parm.Value = DateTime.Parse(stDate).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@endd", SqlDbType.Date);
            parm.Value = DateTime.Parse(enddate).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@ms", SqlDbType.Int);
            parm.Value = Convert.ToDouble(maxStu);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);


            cmd.Parameters.Add("@BName", SqlDbType.VarChar, 50);
            cmd.Parameters["@BName"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@BID", SqlDbType.Int);
            cmd.Parameters["@BID"].Direction = ParameterDirection.Output;
            c.Open();
            cmd.ExecuteNonQuery();

       //     Label2.Text = "Batch is created successfully.";
        //    Label11.Text = "The Batch Name is: " + cmd.Parameters["@BName"].Value.ToString();
      //      Label3.Text = "The batch id is: " + cmd.Parameters["@BID"].Value.ToString();
            string bid = cmd.Parameters["@BID"].Value.ToString();
            //Label2.Visible = true;
            //Label11.Visible = true;
            //Label3.Visible = true;
          //  MessagePanel.Visible = true;
            
            lblBatchCreationUpdateMsg.Text = "Batch is created successfuly.";
            lblBatchCreationUpdateMsg.Visible = true;
            lblBatchName.Text = "The Batch Name is: " + cmd.Parameters["@BName"].Value.ToString();
            lblBatchName.Visible = true;
            MessagePanel.Visible = true;
            c.Close();
            return bid;
        }

        protected void BtnUpdateBatch_Click(object sender, EventArgs e)
        {
            int btchid = Convert.ToInt32(Request.QueryString["ID"]);
            string[] validationresult = new string[14];
            //delete existing day time first, otherwise during creating data table parameter, it shows time conflict error
            DeleteExistingDayTimeBeforeUpdate(btchid);
            validationresult = Validation();

          if (validationresult[0].Equals ("false") && validationresult[1].Equals ("false")
                && validationresult[2].Equals("false") && validationresult[3].Equals("false")
                && validationresult[4].Equals("false") && validationresult[5].Equals("false")
                && validationresult[6].Equals("false") && validationresult[7].Equals("false")
                && validationresult[8].Equals("false") && validationresult[9].Equals("false")
                && validationresult[10].Equals("false") && validationresult[11].Equals("false")
                && validationresult[12].Equals("false") && validationresult[13].Equals("false"))
            {
                UpdateBatch(btchid);
                UpdateBatchTiming(btchid);
                lblBatchCreationUpdateMsg.Text = "Batch " + btchid + " is Updateed successfully;";
                lblBatchCreationUpdateMsg.Visible = true;
                MessagePanel.Visible = true;
           
            }

        }

        private void DeleteExistingDayTimeBeforeUpdate(int batchid)
        {
            DataTable d = CreateDataTable1(batchid);


            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DeleteExistingDayTimeBeforeUpdate", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@dayTimeTVP", d); //Needed TVP
            tvpParam.SqlDbType = SqlDbType.Structured; //tells ADO.NET we are passing TVP
            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();
        }

        private void UpdateBatchTiming(int btchid)
        {

            DataTable d = CreateDataTable1(btchid);
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UpdateBatchDayTVPSP", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@dayTimeTVP", d); //Needed TVP
            tvpParam.SqlDbType = SqlDbType.Structured; //tells ADO.NET we are passing TVP
            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();
        
    
        }

        private void UpdateBatch(int btchid)
        {
            string teacherid = Session["TeacherID"].ToString();

            string maxStu = DropDownNoOfStu.SelectedItem.Text;

            string stDate = txtStartDate.Text;
            string enddate = txtEndDate.Text;

            // get batch name from stored procedure

            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UpdateBatch", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@bid", SqlDbType.Int);
            parm.Value = Convert.ToInt32(btchid);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);


            parm = new SqlParameter("@dc", SqlDbType.DateTime);
            parm.Value = DateTime.Today;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@sid", SqlDbType.Int);
            parm.Value = DropDownListSubject.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@gid", SqlDbType.Int);
            parm.Value = DropDownListGrade.SelectedValue;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@std", SqlDbType.Date);
            parm.Value = DateTime.Parse(stDate).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@enddate", SqlDbType.Date);
            parm.Value = DateTime.Parse(enddate).Date;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);


            parm = new SqlParameter("@mx", SqlDbType.Int);
            parm.Value = Convert.ToDouble(maxStu);
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
                      
            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();

            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            }
        }

     

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }
        private string timeconflict(int teacherid, string dayname, TimeSpan starttime, TimeSpan endtime)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("TutorsBatchTimeConflict", c);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
            parm.Value = teacherid;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@dayname", SqlDbType.VarChar);
            parm.Value = dayname;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@selectedStarttime", SqlDbType.Time);
            parm.Value = starttime;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@selectedEndtime", SqlDbType.Time);
            parm.Value = endtime;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);
                      
            cmd.Parameters.Add("@result", SqlDbType.Int);
            cmd.Parameters["@result"].Direction = ParameterDirection.Output;

            c.Open();
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@result"].Value.ToString();
            return result;

        }
        private void FillTimeDropDownLists()
        {
            for (int i = 420; i < 1460; i++)
            {
                string time = DateTime.MinValue.AddMinutes(i).ToString("h:mmtt");
                ddlSaturdayStTime.Items.Add(time);
                ddlSundayStTime.Items.Add(time);
                ddlMondayStTime.Items.Add(time);
                ddlTuesdayStTime.Items.Add(time);
                ddlWednesdayStTime.Items.Add(time);
                ddlThursdayStTime.Items.Add(time);
                ddlFridayStTime.Items.Add(time);
                i = i + 29;
            }
            //// To make it the first element at the list, use 0 index : 
            ddlSaturdayStTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlSundayStTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlMondayStTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlTuesdayStTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlWednesdayStTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlThursdayStTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlFridayStTime.Items.Insert(0, new ListItem("Select", string.Empty));
            for (int i = 480; i < 1460; i++)
            {
                string time = DateTime.MinValue.AddMinutes(i).ToString("h:mmtt");
                ddlSaturdayEndTime.Items.Add(time);
                ddlSundayEndTime.Items.Add(time);
                ddlMondayEndTime.Items.Add(time);
                ddlTuesdayEndTime.Items.Add(time);
                ddlWednesdayEndTime.Items.Add(time);
                ddlThursdayEndTime.Items.Add(time);
                ddlFridayEndTime.Items.Add(time);
                i = i + 29;
            }
            ddlSaturdayEndTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlSundayEndTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlMondayEndTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlTuesdayEndTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlWednesdayEndTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlThursdayEndTime.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlFridayEndTime.Items.Insert(0, new ListItem("Select", string.Empty));
        }

        protected void ddlSundayStTime_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
     
    }
}
