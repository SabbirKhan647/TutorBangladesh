using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Tutor
{
    /// <summary>
    /// Summary description for RetrieveAssignmentSubmission
    /// </summary>
    public class RetrieveAssignmentSubmission : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int assignmentid;
            if (context.Request.QueryString["id"] != null)
                assignmentid = Convert.ToInt32(context.Request.QueryString["id"].ToString());

            else
                throw new ArgumentException("No parameter specified");

            context.Response.ContentType = "application/pdf";
            Stream strm = ShowAssignmentDoc(assignmentid);


            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }
        private Stream ShowAssignmentDoc(int assignmentid)
        {
            string conn = ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            string sql = "SELECT SubmittedAssgnmtDocData FROM StudentAssignment WHERE StudentAssignmentID = @assignmentid";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@assignmentid", SqlDbType.Int).Value = assignmentid;
            connection.Open();
            object img = cmd.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])img);
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

       
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}