using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Tutor
{
    public partial class Common : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UponLogOut(object sender, EventArgs e)
        {

            Session.RemoveAll();
            FormsAuthentication.SignOut();

            //FormsAuthentication.RedirectToLoginPage();
            Session.Abandon();
        }
    }
}