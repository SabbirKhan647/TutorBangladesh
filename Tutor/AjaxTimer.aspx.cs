using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace Tutor
{
    public partial class AjaxTimer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                Page.Header.DataBind();
                // runs onload function
                //HtmlGenericControl body = this.FindControl("body") as HtmlGenericControl;
                //body.Attributes.Add("onLoad", "startTime();");
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", "startTime();", true);
               // lblTime.Text = DateTime.Now.ToLocalTime().ToLongTimeString();
                var c = hiddenfield1.Value;
                lblDateToDay.Text = c.ToString();
                TimeSpan d = DateTime.Parse(c).TimeOfDay;
                 lblTime.Text = d.ToString ();
           // }
        }
        protected void TimerTime_Tick(object sender, EventArgs e)
        {
          //  lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
          //  lblTime.Text = DateTime.Now.ToLocalTime().ToLongTimeString();
          //  lblTime.Text = hiddenfield1.Value;
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", "startTime();", true);
            var c = hiddenfield1.Value;
            lblDateToDay.Text = c.ToString();
           TimeSpan d = DateTime.Parse(c).TimeOfDay;
            lblTime.Text = d.ToString();
        }
    }
}