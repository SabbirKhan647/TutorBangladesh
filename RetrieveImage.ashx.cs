using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Tutor.TeacherManagement
{
    /// <summary>
    /// Summary description for TutorProfile
    /// </summary>
    public class TutorProfile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ////get userid
            //MembershipUser userInfo = Membership.GetUser();
            //Guid userid = (Guid)userInfo.ProviderUserKey;
            Guid userid;
            if (context.Request.QueryString["id"] != null)
              userid= new Guid(context.Request.QueryString["id"].ToString ());
            else
                throw new ArgumentException("No parameter specified");

            context.Response.ContentType = "image/jpeg";
            Stream strm = ShowImage(userid);
         
            
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }      
        
        }
        public Stream ShowImage(Guid userid)
        {
            string conn = ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            string sql = "SELECT data FROM Image WHERE UserID = @userid";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@userid", SqlDbType.UniqueIdentifier).Value = userid;
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