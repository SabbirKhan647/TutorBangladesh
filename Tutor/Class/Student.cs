using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Wraps Teacher identity data
/// </summary>
public struct StudentIdentity
{
    public object UserId;
    public string StudentId;
}
namespace Tutor.Class
{
    public class Student
    {
           protected int studentid;
   static Student()
  {
    //
    // TODO: Add constructor logic here
    //
  }
   public static void InsertStudentId(object a, int b)
   {
       SqlConnection conn = new SqlConnection(@"Data Source=OWNER-KABIR\SQLSERVER2012;Initial Catalog=Tutor;Integrated Security=True");

       //2. Open the connection
       conn.Open();
       string tiNew1 = Convert.ToString(b);
       String insertString = "insert into Student(UserId, StudentId) values(@userid,@studentid)";
       SqlCommand cmd1 = new SqlCommand(insertString, conn);
       
       cmd1.Parameters.Add("@userid", SqlDbType.UniqueIdentifier).Value =a;
       cmd1.Parameters.Add("@studentid", SqlDbType.VarChar).Value = tiNew1.ToString();

       //3. Call ExecuteNonQuery to send the command
       cmd1.ExecuteNonQuery();
       //  MessageBox.Show("insert successful");

       //5. Close the connection
       if (conn != null)
       {
           conn.Close();
       }
   }
   public static int GetStudentId()
   {
       SqlConnection conn = new SqlConnection(@"Data Source=OWNER-KABIR\SQLSERVER2012;Initial Catalog=Tutor;Integrated Security=True");
       //string a = MyApplicationConfiguration.DbConnectionString;
       //SqlConnection conn = new SqlConnection(@a);
     
      

       //2. Open the connection
       conn.Open();
       //3. Pass the connection to a command object
       SqlCommand cmd = new SqlCommand("SELECT StudentId FROM Student", conn);

       //4. Use the connection to get query result
       SqlDataReader rdr = cmd.ExecuteReader();
       List<string> list = new List<string>();
       while (rdr.Read())
       {

           list.Add(rdr[0].ToString());
         //  ListBox1.Items.Add(rdr[0].ToString());

       }
       //close the reader
       if (rdr != null)
       {
           rdr.Close();
       }
       //5. Close the connection
       if (conn != null)
       {
           conn.Close();
       }
       //read teacherid and increase by 1 for next
       string ti = null;
       foreach (string li in list)
       {
           ti = li;
       }
       int tiNew = Convert.ToInt32(ti);
       int tiNew1 = tiNew + 1;
       return tiNew1;
   }
    }
    }











