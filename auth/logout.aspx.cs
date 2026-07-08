using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gesture_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Cookies.Clear();

        Response.Cookies["AdminUserName"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["AdminPassword"].Expires = DateTime.Now.AddDays(-1);

        Response.Redirect("login.aspx");
    }
}