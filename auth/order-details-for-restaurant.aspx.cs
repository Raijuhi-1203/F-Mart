using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class auth_order_details : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Order odr = new Order();
    RestaurantOrder foodOdr = new RestaurantOrder();
    Encrypt enc = new Encrypt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindOrderItem();

            lblorderno.Text = enc.Decrypted(Request.QueryString[0].ToString());

            // Get Order Info

            SqlDataReader get_order_info = foodOdr.Get_Order_info_by_Order_id(lblorderno.Text);
            if (get_order_info.Read())
            {
                lblbillingaddress.Text = get_order_info["billing_address_line1"].ToString() + "<br/>" + get_order_info["billing_address_line2"].ToString();
                lblbillingcitystatepincode.Text = get_order_info["billing_city_name"].ToString() + ", " + get_order_info["billing_state_name"].ToString() + "-" + get_order_info["billing_pincode"].ToString();

                lblbillingname.Text = get_order_info["customer_name"].ToString();
                lblbillingemail.Text = get_order_info["customer_email"].ToString();

                lblbillingmobileno.Text = get_order_info["customer_mobileno"].ToString();
                lblpaymentmethod.Text = get_order_info["payment_mode"].ToString();

                lblbillinglandmark.Text = get_order_info["billing_landmark"].ToString();
                lblorderplacedate.Text = get_order_info["order_date"].ToString()+" "+ get_order_info["order_time"].ToString();

                lblcoupon.Text = get_order_info["coupan_value"].ToString();

                lbl_customer_id.Text = get_order_info["customer_id"].ToString();

                lbl_seller_id.Text = get_order_info["product_sellerid"].ToString();

            }

            get_order_info.Close();

            // Total

            lbltotaldiscount.Text = Convert.ToString(mst.Count_data("Select ISNULL(Sum(product_discount_price),0) from  ecommerce_order where order_id='" + enc.Decrypted(Request.QueryString[0].ToString()) + "'  AND order_status!='Cancelled' "));
                     
            lbltotalgstamount.Text = foodOdr.GetTotalAmountGSTOrder(lblorderno.Text);

            if (foodOdr.GetTotalAmountShippingOrder(lblorderno.Text) == "")
            {
                lblgrandtotalamount.Text = Convert.ToString(Convert.ToDecimal(foodOdr.GetTotalAmountOrder(lblorderno.Text)) + Convert.ToDecimal(0)-Convert.ToDecimal(lblcoupon.Text));
            }
            else
            {
                lblgrandtotalamount.Text = Convert.ToString(Convert.ToDecimal(foodOdr.GetTotalAmountOrder(lblorderno.Text)) + Convert.ToDecimal(foodOdr.GetTotalAmountShippingOrder(lblorderno.Text))-Convert.ToDecimal(lblcoupon.Text));
            }

            lblsubtotal.Text = Convert.ToString(mst.Count_data("Select ISNULL(Sum(total_market_price),0) from  ecommerce_order where order_id='" + enc.Decrypted(Request.QueryString[0].ToString()) + "' AND order_status!='Cancelled' "));
           
            if (Convert.ToDecimal(lblgrandtotalamount.Text) > Convert.ToInt32(odr.Get_free_delievry()))
            {
                lbltotalshippingamount.Text = "Free";
            }
            else
            {
                lbltotalshippingamount.Text = foodOdr.GetTotalAmountShippingOrder(lblorderno.Text);
            }

        }
    }
   
    private void BindOrderItem()
    {
        rptbinddataprice.DataSource = mst.GetData("SELECT * FROM restaurant_order where order_id='" + enc.Decrypted(Request.QueryString[0].ToString()) + "' ");
        rptbinddataprice.DataBind();
    }

}