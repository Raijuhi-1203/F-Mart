using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class bill_receipt : System.Web.UI.Page
{
    Master mst = new Master();
    Order odr = new Order();
    Customer cmr = new Customer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();

            lblorderid.Text = Request.QueryString[0].ToString();

            // Get Order Info

            SqlDataReader get_order_info = odr.Get_Order_info_by_Order_id(Request.QueryString[0]);
            if (get_order_info.Read())
            {
                lbladdress.Text = get_order_info["billing_address_line1"].ToString() + "<br/>" + get_order_info["billing_address_line2"].ToString();

                lblbillingcitystatepincode.Text = get_order_info["billing_city_name"].ToString() + ", " + get_order_info["billing_state_name"].ToString() + "-" + get_order_info["billing_pincode"].ToString();

                lblbillingname.Text = get_order_info["customer_name"].ToString();
                lblbillingmobileno.Text = get_order_info["customer_mobileno"].ToString();

                lblorderplacedate.Text = get_order_info["order_date"].ToString() ;
                lblcoupon.InnerText = get_order_info["coupan_value"].ToString();

                lbl_payment_mode.Text = get_order_info["payment_mode"].ToString();

               
            }
            get_order_info.Close();

            lblsubtotal.InnerText = Convert.ToString(mst.Count_data("Select ISNULL(Sum(total_market_price),0) from  ecommerce_order where order_id='" + Request.QueryString[0] + "' AND order_status!='Cancelled' "));

            //lblsubtotal.InnerText = odr.GetTotalAmountOrder(Request.QueryString[0].ToString());

            lblshippingcharge.InnerText = odr.GetTotalAmountShippingOrder(Request.QueryString[0].ToString());

            lbldiscountamount.InnerText = Convert.ToString(mst.Count_data("Select ISNULL(Sum(product_discount_price),0) from  ecommerce_order where order_id='" + Request.QueryString[0] + "'  AND order_status!='Cancelled' "));

           // lbldiscountamount.InnerText = odr.GetTotalAmountDiscountOrder(Request.QueryString[0].ToString());

            lblgstamount.Text = odr.GetTotalAmountGSTOrder(Request.QueryString[0].ToString());

            lbl_total_qty.Text =Convert.ToString(mst.Count_data("Select SUM(product_qty) from ecommerce_order where order_id='"+ Request.QueryString[0].ToString() + "' AND order_status!='Cancelled' "));
            lbl_total_items.Text = Convert.ToString(mst.Count_data("Select Count(sub_order_id) from ecommerce_order where order_id='" + Request.QueryString[0].ToString() + "' AND order_status!='Cancelled' "));

            if (lblcoupon.InnerText != "")
            {
                if (Convert.ToDecimal(lblsubtotal.InnerText) > Convert.ToInt32(odr.Get_free_delievry()))
                {
                    lblshippingcharge.InnerText = "Free";
                    lblgrandtotal.Text = Convert.ToString(Convert.ToDecimal(odr.GetTotalAmountOrder(Request.QueryString[0].ToString()))  - Convert.ToDecimal(lblcoupon.InnerText));

                }
                else
                {
                    lblshippingcharge.InnerText = odr.GetTotalAmountShippingOrder(Request.QueryString[0].ToString());

                    lblgrandtotal.Text = Convert.ToString(Convert.ToDecimal(odr.GetTotalAmountOrder(Request.QueryString[0].ToString())) + Convert.ToDecimal(odr.GetTotalAmountShippingOrder(Request.QueryString[0].ToString())) - Convert.ToDecimal(lblcoupon.InnerText));
                }

              
            }

        }
    }


    private void BindData()
    {
         rptorderproduct.DataSource = mst.GetData("SELECT * FROM ecommerce_order where order_id='" + Request.QueryString[0] + "' AND order_status!='Cancelled' ");
         rptorderproduct.DataBind();
    }

   
}