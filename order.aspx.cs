using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order : System.Web.UI.Page
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
        if (Session["customer_id"] != null)
        {
            BindData();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT top 1 *,(SELECT count(*) FROM ecommerce_order where customer_id='" + Session["customer_id"].ToString() + "') as total_item FROM ecommerce_order where customer_id='" + Session["customer_id"].ToString() + "'");
        rptbinddata.DataBind();

        if (rptbinddata.Items.Count == 0)
        {
            NoDataPanel.Visible = true;
        }
        else
        {
            NoDataPanel.Visible = false;
        }

    }


    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {

            Label order_id = (Label)e.Item.FindControl("order_id");
            Repeater ChildRepeater = (Repeater)e.Item.FindControl("ChildRepeater");

            ChildRepeater.DataSource = mst.GetData("select d.*,a.*,b.*,c.*,(CAST(d.product_qty as float) * CAST(b.product_sell_price as float)) as total from ecommerce_order d left join ecommerce_product as a on d.product_id=a.product_id left join ecommerce_product_price as b on d.product_id=b.product_id left join ecommerce_product_photos as c on d.product_id=c.product_id where d.order_id='" + order_id.Text + "'");
            ChildRepeater.DataBind();
        }
    }

}