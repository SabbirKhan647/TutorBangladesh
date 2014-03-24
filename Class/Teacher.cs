using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

/// <summary>
/// Wraps Teacher identity data
/// </summary>
public struct TeacherIdentity
{
    public object UserId;
    public string TeacherId;
}
namespace Tutor.Class
{
    public class Teacher
    {
            protected int teacherid;
           
   static Teacher()
  {
    //
    // TODO: Add constructor logic here
    //
  }
   public static void InsertTeacherId(object a, int b)
   {
       SqlConnection conn = new SqlConnection(@"Data Source=OWNER-KABIR\SQLSERVER2012;Initial Catalog=Tutor;Integrated Security=True");

       //2. Open the connection
       conn.Open();
       string tiNew1 = Convert.ToString(b);
       String insertString = "insert into Teacher(UserId, TeacherId) values(@userid,@teacherid)";
       SqlCommand cmd1 = new SqlCommand(insertString, conn);
       
       cmd1.Parameters.Add("@userid", SqlDbType.UniqueIdentifier).Value =a;
       cmd1.Parameters.Add("@teacherid", SqlDbType.VarChar).Value = tiNew1.ToString();

       //3. Call ExecuteNonQuery to send the command
       cmd1.ExecuteNonQuery();
       //  MessageBox.Show("insert successful");

       //5. Close the connection
       if (conn != null)
       {
           conn.Close();
       }
   }
   //public static int GetTeacherId()
   //{
   //    SqlConnection conn = new SqlConnection(@"Data Source=OWNER-KABIR\SQLSERVER2012;Initial Catalog=Tutor;Integrated Security=True");
   //    //string a = MyApplicationConfiguration.DbConnectionString;
   //    //SqlConnection conn = new SqlConnection(@a);
     
      

   //    //2. Open the connection
   //    conn.Open();
   //    //3. Pass the connection to a command object
   //    SqlCommand cmd = new SqlCommand("SELECT TeacherId FROM Teacher", conn);

   //    //4. Use the connection to get query result
   //    SqlDataReader rdr = cmd.ExecuteReader();
   //    List<string> list = new List<string>();
   //    while (rdr.Read())
   //    {

   //        list.Add(rdr[0].ToString());
   //      //  ListBox1.Items.Add(rdr[0].ToString());

   //    }
   //    //close the reader
   //    if (rdr != null)
   //    {
   //        rdr.Close();
   //    }
   //    //5. Close the connection
   //    if (conn != null)
   //    {
   //        conn.Close();
   //    }
   //    //read teacherid and increase by 1 for next
   //    string ti = null;
   //    foreach (string li in list)
   //    {
   //        ti = li;
   //    }
   //    int tiNew = Convert.ToInt32(ti);
   //    int tiNew1 = tiNew + 1;
   //    return tiNew1;
   //}
   public static void CreateBatch(string teacherid,string dateCreated,string timeCreated,int subid , int gradeid ,string maxStu ,string stDate)
   {
       SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
       c.Open();
       String insertString = "createBatchSP";
      
       SqlCommand cmd1 = new SqlCommand(insertString, c);
       cmd1.CommandType = CommandType.StoredProcedure;
       
       cmd1.Parameters.Add("@tid", SqlDbType.Int).Value = Convert.ToInt32(teacherid);
       cmd1.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Parse(dateCreated).Date;
       cmd1.Parameters.Add("@t", SqlDbType.Time).Value = DateTime.Parse(timeCreated).TimeOfDay;
       cmd1.Parameters.Add("@sid", SqlDbType.Int).Value = subid;
       cmd1.Parameters.Add("@gid", SqlDbType.Int).Value = gradeid;
       
       cmd1.Parameters.Add("@ms", SqlDbType.Float).Value = Convert.ToDouble(maxStu);
       cmd1.Parameters.Add("@sd", SqlDbType.Date).Value = Convert.ToDateTime(stDate);
     
       //3. Call ExecuteNonQuery to send the command
       cmd1.ExecuteNonQuery();
       
       //5. Close the connection
       if (c != null)
       {
           c.Close();
       }

   }
   public static void InsertBatchDetails(int batchid, string day, string sttime1, string endtime1,float duration)
   {
       SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
       c.Open();
       String insertString = "batchDaySP";
       
       SqlCommand cmd1 = new SqlCommand(insertString, c);
       cmd1.CommandType = CommandType.StoredProcedure;
       cmd1.Parameters.Add("@bid", SqlDbType.Int ).Value = batchid;  
       cmd1.Parameters.Add("@dn", SqlDbType.VarChar).Value = day;         
       cmd1.Parameters.Add("@st", SqlDbType.Time).Value = DateTime.Parse(sttime1).TimeOfDay;
       cmd1.Parameters.Add("@et", SqlDbType.Time).Value = DateTime.Parse(endtime1).TimeOfDay;
       cmd1.Parameters.Add("@du", SqlDbType.Float).Value = duration;
       //3. Call ExecuteNonQuery to send the command
       cmd1.ExecuteNonQuery();
       //5. Close the connection
       if (c != null)
       {
           c.Close();
       }

   }
    }
    }







