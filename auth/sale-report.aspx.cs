using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_sale_report : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Order odr = new Order();
    Master mst = new Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            date_from.Visible = false;date_to.Visible = false; btn_search.Visible = false;

            string value = Request.QueryString[0];

            switch (value)
            {
                case "Current-Month":

                    BindOrderCurrentMonth();

                    TotalCouponOrderCurrentMonth();
                    TotalSaleOrderCurrentMonth();

                    break;

                case "Daily":

                    BindOrderDaily();

                    TotalCouponOrderDaily();
                    TotalSaleOrderDaily();

                    break;

                case "Last-Month":

                    BindOrderLastMonth();

                    TotalCouponOrderLastMonth();
                    TotalSaleOrderLastMonth();


                    break;

                case "Last-3-Month":

                    BindOrderLast3Month();

                    TotalCouponOrderLast3Month();
                    TotalSaleOrderLast3Month();

                    break;

                case "Last-6-Month":

                    BindOrderLast6Month();

                    TotalCouponOrderLast6Month();
                    TotalSaleOrderLast6Month();

                    break;

                case "Last-week":

                    BindOrderWeeky();

                    TotalCouponOrderWeeky();
                    TotalSaleOrderWeeky();

                    break;

                case "date-range":


                    date_from.Visible = true;
                    date_to.Visible = true;
                    btn_search.Visible = true;

                  
                    break;
            }
        }
    }

    public void TotalSaleOrder_date_range()
    {
        lbltotalsale.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(total_amount_of_product),0) FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND order_date between '" + txt_date_from.Text + "' AND '" + txt_date_to + "' "));
    }

    public void TotalCouponOrder_date_range()
    {
        lblcoupon.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(coupan_value),0) FROM (SELECT order_id,coupan_value FROM ecommerce_order where  order_status='Delivered'  AND order_section='Grocery'  AND order_date between '" + txt_date_from.Text + "' AND '" + txt_date_to.Text + "' GROUP BY order_id,coupan_value ) a"));
    }


    public void TotalSaleOrderCurrentMonth()
    {
        lbltotalsale.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(total_amount_of_product),0) FROM ecommerce_order where order_status='Delivered'  AND order_section='Grocery' AND DATEPART(m, order_date) = DATEPART(m, GETDATE()) AND DATEPART(yyyy, order_date) = DATEPART(yyyy, GETDATE())"));
    }

    public void TotalCouponOrderCurrentMonth()
    {
        lblcoupon.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(coupan_value),0) FROM (SELECT order_id,coupan_value FROM ecommerce_order where  order_status='Delivered' AND order_section='Grocery'  AND DATEPART(m, order_date) = DATEPART(m, GETDATE()) AND DATEPART(yyyy, order_date) = DATEPART(yyyy, GETDATE()) GROUP BY order_id,coupan_value ) a"));
    }


    public void TotalSaleOrderDaily()
    {
        lbltotalsale.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(total_amount_of_product),0) FROM ecommerce_order where order_status='Delivered'  AND order_section='Grocery' AND order_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' "));
    }

    public void TotalCouponOrderDaily()
    {
        lblcoupon.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(coupan_value),0) FROM (SELECT order_id,coupan_value FROM ecommerce_order where  order_status='Delivered' AND order_section='Grocery'  AND order_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' GROUP BY order_id,coupan_value ) a"));
    }


    public void TotalSaleOrderLastMonth()
    {
        lbltotalsale.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(total_amount_of_product),0) FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND DATEPART(m, order_date) = DATEPART(m, DATEADD(m, -1, GETDATE())) AND DATEPART(yyyy, order_date) = DATEPART(yyyy, DATEADD(m, -1, GETDATE()))"));
    }

    public void TotalCouponOrderLastMonth()
    {
        lblcoupon.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(coupan_value),0) FROM (SELECT order_id,coupan_value FROM ecommerce_order where  order_status='Delivered' AND order_section='Grocery'  AND DATEPART(m, order_date) = DATEPART(m, DATEADD(m, -1, GETDATE())) AND DATEPART(yyyy, order_date) = DATEPART(yyyy, DATEADD(m, -1, GETDATE())) GROUP BY order_id,coupan_value ) a"));
    }


    public void TotalSaleOrderLast3Month()
    {
        lbltotalsale.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(total_amount_of_product),0) FROM ecommerce_order where order_status='Delivered'  AND  order_date >= DATEADD(DAY, -90, GETDATE())"));
    }

    public void TotalCouponOrderLast3Month()
    {
        lblcoupon.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(coupan_value),0) FROM (SELECT order_id,coupan_value FROM ecommerce_order where  order_status='Delivered' AND order_section='Grocery'  AND order_date >= DATEADD(DAY, -90, GETDATE()) GROUP BY order_id,coupan_value ) a"));
    }


    public void TotalSaleOrderLast6Month()
    {
        lbltotalsale.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(total_amount_of_product),0) FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND  order_date >= DATEADD(DAY, -180, GETDATE())"));
    }

    public void TotalCouponOrderLast6Month()
    {
        lblcoupon.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(coupan_value),0) FROM (SELECT order_id,coupan_value FROM ecommerce_order where  order_status='Delivered' AND order_section='Grocery'  AND order_date >= DATEADD(DAY, -180, GETDATE()) GROUP BY order_id,coupan_value ) a"));
    }

    public void TotalSaleOrderWeeky()
    {
        lbltotalsale.Text = Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(total_amount_of_product),0) FROM ecommerce_order where order_status='Delivered'  AND order_section='Grocery' AND order_date >= DATEADD(day, -7, GETDATE())"));
    }

    public void TotalCouponOrderWeeky()
    {
        lblcoupon.Text =Convert.ToString(mst.Count_data("SELECT ISNULL(SUM(coupan_value),0) FROM (SELECT order_id,coupan_value FROM ecommerce_order where  order_status='Delivered' AND order_section='Grocery' AND order_date >= DATEADD(day, -7, GETDATE()) GROUP BY order_id,coupan_value ) a"));
    }

    private void BindOrder_date_range()
    {
         rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND order_date between '" + txt_date_from.Text+"' And '"+txt_date_to.Text+"'  Group by order_id order by id desc");
         rptbinddata.DataBind();
    }

    private void BindOrderCurrentMonth()
    {
         rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND DATEPART(m, order_date) = DATEPART(m, GETDATE()) AND DATEPART(yyyy, order_date) = DATEPART(yyyy, GETDATE()) Group by order_id order by id desc");
        rptbinddata.DataBind();
    }


    private void BindOrderDaily()
    {
         rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND order_date='" + DateTime.Now.ToString("yyyy-MM-dd")+ "' Group by order_id order by id desc");
         rptbinddata.DataBind();
    }

    private void BindOrderWeeky()
    {
         rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status='Delivered'  AND order_section='Grocery' AND order_date >= DATEADD(day, -7, GETDATE()) Group by order_id order by id desc");
         rptbinddata.DataBind();
    }

    private void BindOrderLastMonth()
    {
         rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND DATEPART(m, order_date) = DATEPART(m, DATEADD(m, -1, GETDATE())) AND DATEPART(yyyy, order_date) = DATEPART(yyyy, DATEADD(m, -1, GETDATE())) Group by order_id order by id desc");
         rptbinddata.DataBind();
    }

    private void BindOrderLast3Month()
    {
        rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND  order_date >= DATEADD(DAY, -90, GETDATE()) Group by order_id order by id desc");
        rptbinddata.DataBind();
    }

    private void BindOrderLast6Month()
    {
         rptbinddata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount FROM ecommerce_order where order_status='Delivered' AND order_section='Grocery'  AND  order_date >= DATEADD(DAY, -180, GETDATE()) Group by order_id order by id desc");
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
        if(txt_date_to.Text.Length>0 && txt_date_from.Text.Length>0)
        {
            BindOrder_date_range();

            TotalCouponOrder_date_range();
            TotalSaleOrder_date_range();
        }
        else
        {
            ShowMessage("Please Enter Date field.",MessageType.Error);
        }
    }
}