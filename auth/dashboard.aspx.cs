using System;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    Master mst = new Master();
    Order odr = new Order();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Total_Counter();

            BindCustomer();
            BindOrder();
            BindCancelRequest();
            Bind_Low_Stock();

            

            lbl_total_order.Text = Convert.ToString(mst.Count_data("Select Count(DISTINCT order_id) from ecommerce_order Where order_section='Grocery'"));
            lbltodayorder.Text = Convert.ToString(mst.Count_data("SELECT  Count(DISTINCT order_id) FROM ecommerce_order where  order_section='Grocery' AND order_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'"));
            lbltodaycancelrequest.Text = Convert.ToString(mst.Count_data("SELECT COUNT(id) FROM ecommerce_order where  order_section='Grocery' AND order_cancel_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'"));
            lbl_total_deliverd.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(Sum(total_amount_of_product),0) FROM ecommerce_order where  order_section='Grocery' AND order_status='Delivered'"));

         

            //lbl_total_food_order.Text = Convert.ToString(mst.Count_data("Select Count(DISTINCT order_id) from ecommerce_order Where order_section='Restaurant'"));
            //lbl_today_food_order.Text = Convert.ToString(mst.Count_data("SELECT  Count(DISTINCT order_id) FROM ecommerce_order where order_section='Restaurant' AND order_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'"));
            //lbl_today_food_order_cancel.Text = Convert.ToString(mst.Count_data("SELECT COUNT(id) FROM ecommerce_order where order_section='Restaurant' AND order_cancel_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'"));
            //lbl_food_delivered.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(Sum(total_amount_of_product),0) FROM ecommerce_order where order_section='Restaurant' AND order_status='Delivered'"));

        }
    }

   
    public void Total_Counter()
    {
        lbltotalproduct.Text = Convert.ToString(mst.Count_data("SELECT COUNT(*) FROM ecommerce_product where product_seller_id='0' AND product_type='Grocery'"));
        lbltotalcustomer.Text = Convert.ToString(mst.Count_data("SELECT COUNT(*) FROM ecommerce_customer"));

       // lbl_total_restaurant.Text = Convert.ToString(mst.Count_data("SELECT COUNT(*) FROM ecommerce_seller"));
        lbl_total_delivery_boy.Text = Convert.ToString(mst.Count_data("SELECT COUNT(*) FROM ecommerce_delivery_boy"));
    }

    private void Bind_Low_Stock()
    {
        rpt_low_stock_product.DataSource = mst.GetData("SELECT Top 5 R.product_id,R.product_stock,P.product_full_name FROM ecommerce_product_price R inner join ecommerce_product P ON R.product_id=P.product_id where product_seller_id='0' AND product_type='Grocery' AND product_stock < 20 order by product_stock asc");
        rpt_low_stock_product.DataBind();
    }

    private void BindCustomer()
    {
         rptrecentcustomer.DataSource = mst.GetData("SELECT Top 5 * FROM ecommerce_customer order by id desc");
         rptrecentcustomer.DataBind();
    }

    private void BindOrder()
    {
        rptbindorderdata.DataSource = mst.GetData("SELECT Top 5 Max(id) as id, Max(order_id) as order_id,Max(order_date) as order_date,Max(order_delivery_time) as order_delivery_time,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status!='Cancelled'  Group by order_id order by id desc");
        rptbindorderdata.DataBind();
    }

    private void BindCancelRequest()
    {
        rptbindcancelorderdata.DataSource = mst.GetData("SELECT Top 5 * FROM ecommerce_order where order_status='Return Request' order by id desc");
        rptbindcancelorderdata.DataBind();
    }


    protected void rptbindorderdata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblorderid = (Label)e.Item.FindControl("lblorderid");
            Label lblnoofitems = (Label)e.Item.FindControl("lblnoofitems");

            lblnoofitems.Text = odr.GetNoOfItemsOrder(lblorderid.Text);
        }
    }



}