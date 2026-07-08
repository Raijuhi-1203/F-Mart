using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public partial class home : System.Web.UI.MasterPage
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        if (!IsPostBack)
        {
            if (Session["backend_name"] != null)
            {

            }
            else
            {
                Response.Redirect("login.aspx");
            }

       
        }

    }

}
