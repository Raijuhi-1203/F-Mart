using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        if (!IsPostBack)
        {
            BindData();
            if (Session["customer_id"] != null)
            {
                btnregister.Visible = false;
                btnuser.Visible = true;
                btnuser.InnerText = "Hello, " + Session["customer_name"].ToString();
                btnlogin.Visible = false;
                btnlogout.Visible = true;

                int orderct = mst.Count_data("SELECT count(*) FROM ecommerce_cart where customer_id='" + Session["customer_id"].ToString() + "'");
                cartcount.InnerText = orderct.ToString();

                int wishct = mst.Count_data("SELECT count(*) FROM ecommerce_wishlist where customer_id='" + Session["customer_id"].ToString() + "'");
                wishlistcount.InnerText = wishct.ToString();

            }
            else
            {
                btnregister.Visible = true;
                btnlogin.Visible = true;
                btnuser.Visible = false;
                btnlogout.Visible = false;
                //Response.Redirect("login.aspx");
            }
            
        }
    }

    private void BindData()
    {
        
        Repeater1.DataSource = mst.GetData("SELECT * FROM ecommerce_category where main_category_id='0' and category_orderno!='1' and category_orderno!='4' order by id asc");
        Repeater1.DataBind();

        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_category where main_category_id='0' and category_orderno='1' or category_orderno='4' order by id asc");
        rptbinddata.DataBind();
        
    }

    protected void btnsrch_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("serach-product.aspx?ref=" + serachtext.Text);
    }


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           
            Label currentParent = (Label)e.Item.FindControl("catid");

            Repeater Repeater2 = (Repeater)e.Item.FindControl("Repeater2");

            if (Repeater2 != null)
            {
                Repeater2.DataSource = mst.GetData("SELECT * FROM ecommerce_category where main_category_id='"+ currentParent.Text +"' order by id asc");
                Repeater2.DataBind();
            }
        }
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

}
