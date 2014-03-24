using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Connection
/// </summary>
public static class Connection
{
    public static SqlConnection connect()
    {
        SqlConnection con = new SqlConnection(@"Data Source=OWNER-KABIR\SQLSERVER2012;Initial Catalog=Tutor;Integrated Security=True");
        return con;
    }

    public static int StudentID = 1;
}