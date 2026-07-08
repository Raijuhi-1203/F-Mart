using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_delivery_boy_report : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Order odr = new Order();
    Master mst = new Master();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            mst.BindDropDown(dbl_delivery_boy, "delivery_boy_id", "delivery_boy_name", "Select delivery_boy_id,delivery_boy_name from ecommerce_delivery_boy Where delivery_boy_status='Active'");
        }
    }

    private void Bind_By_Delivery_Boy()
    {
        rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(order_delivery_date) as order_delivery_date,Max(total_order_amount) as total_order_amount,Max(order_status) as order_status FROM ecommerce_order where delivery_boy_id='" + dbl_delivery_boy.SelectedValue+ "' AND (order_status='Delivered' OR order_status='Out For Delivery') AND order_section='Grocery' Group by order_id order by id desc");
        rptbinddata.DataBind();
    }

    private void Bind_By_Delivery_Boy_Date()
    {
        rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(order_delivery_date) as order_delivery_date,Max(total_order_amount) as total_order_amount,Max(order_status) as order_status FROM ecommerce_order where delivery_boy_id='" + dbl_delivery_boy.SelectedValue + "' AND (order_status='Delivered' OR order_status='Out For Delivery') AND order_section='Grocery'  AND order_date between '" + txt_date_from.Text + "' And '" + txt_date_to.Text + "'  Group by order_id order by id desc");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblorderid = (Label)e.Item.FindControl("lblorderid");
            Label lblnoofitems = (Label)e.Item.FindControl("lblnoofitems");

            lblnoofitems.Text = odr.GetNoOfItemsOrder(lblorderid.Text);
        }
    }

    protected void btnsearch_ServerClick(object sender, EventArgs e)
    {
        if (txt_date_to.Text.Length > 0 && txt_date_from.Text.Length > 0 && dbl_delivery_boy.SelectedItem.Text!="Please Select")
        {
            Bind_By_Delivery_Boy_Date();
        }
        else
        {
            Bind_By_Delivery_Boy();
        }
    }

    protected void dbl_delivery_boy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dbl_delivery_boy.SelectedItem.Text!="Please Select")
        {
            Bind_By_Delivery_Boy();
        }
    }
}