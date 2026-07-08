using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class auth_printreceipt : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    Master mst = new Master();
    Order odr = new Order();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();

            lblorderid.Text = Request.QueryString[0].ToString();

            // Get Order Info

            SqlDataReader get_order_info = odr.Get_Order_info_by_Order_id(Request.QueryString[0]);
            if (get_order_info.Read())
            {
                lbladdress.Text = get_order_info["billing_address_line1"].ToString() + "<br/>" + get_order_info["billing_address_line2"].ToString();
                lblbuyeraddress.Text = get_order_info["billing_address_line1"].ToString() + "<br/>" + get_order_info["billing_address_line2"].ToString();

                lblbillingcitystatepincode.Text = get_order_info["billing_city_name"].ToString() + ", " + get_order_info["billing_state_name"].ToString() + "-" + get_order_info["billing_pincode"].ToString();
                lblshippingcitystatepincode.Text = get_order_info["billing_city_name"].ToString() + ", " + get_order_info["billing_state_name"].ToString() + "-" + get_order_info["billing_pincode"].ToString();

                lblbillingname.Text = get_order_info["customer_name"].ToString();
                lblshippingname.Text = get_order_info["customer_name"].ToString();

                if(get_order_info["customer_email"].ToString()!="None")
                {
                    lblbillingemail.Text = get_order_info["customer_email"].ToString();
                    lblshippingemail.Text = get_order_info["customer_email"].ToString();
                }

                lblbillingmobileno.Text = get_order_info["customer_mobileno"].ToString();
                lblshippingmobileno.Text = get_order_info["customer_mobileno"].ToString();

                lblorderplacedate.Text = get_order_info["order_date"].ToString() + " " + get_order_info["order_time"].ToString();
               // lblinvoicedate.Text = get_order_info["order_date"].ToString();

                lblcoupon.InnerText =  get_order_info["coupan_value"].ToString();
                lbl_payment_mode.Text = get_order_info["payment_mode"].ToString();


            }
            get_order_info.Close();

            // Invoice details

            //SqlDataReader get_invoice_data = mst.Select_Operation("Select * from ecommerce_gst_invoice Where order_id='"+Request.QueryString[0]+ "' AND invoide_status='Confirm' ");
            //if(get_invoice_data.Read())
            //{
            //    lblinvoicedate.Text = get_invoice_data["invoice_date"].ToString();
            //    lbl_invoice_no.Text = get_invoice_data["invoice_no"].ToString();
            //}
            //else
            //{
            //    invoice_no_div.Visible = false;
            //}

            //get_invoice_data.Close();



            lblsubtotal.InnerText = Convert.ToString(mst.Count_data("Select ISNULL(Sum(total_amount_of_product),0) from  ecommerce_order where order_id='" + Request.QueryString[0] + "' AND order_status!='Cancelled' "));

            lblshippingcharge.InnerText = odr.GetTotalAmountShippingOrder(Request.QueryString[0].ToString());

            lbldiscountamount.InnerText ="-" +Convert.ToString(mst.Count_data("Select ISNULL(Sum(product_discount_price),0) from  ecommerce_order where order_id='" + Request.QueryString[0] + "'  AND order_status!='Cancelled' "));


            lbl_cgst_amount.InnerText =Convert.ToString(Convert.ToDecimal(odr.GetTotalAmountGSTOrder(Request.QueryString[0].ToString()))/2);

            lbl_sgst_amount.InnerText = lbl_cgst_amount.InnerText;

            //if (lblcoupon.InnerText != "")
            //{
            //    if (Convert.ToDecimal(lblsubtotal.InnerText) > Convert.ToInt32(odr.Get_free_delievry()))
            //    {
            //       // lblshippingcharge.InnerText = "Free";

            //        lblgrandtotal.Text = Convert.ToString(Convert.ToDecimal(odr.GetTotalAmountOrder(Request.QueryString[0].ToString())) - Convert.ToDecimal(lblcoupon.InnerText));

            //    }
            //    else
            //    {
            //       // lblshippingcharge.InnerText = odr.GetTotalAmountShippingOrder(Request.QueryString[0].ToString());

            //        lblgrandtotal.Text = Convert.ToString(Convert.ToDecimal(odr.GetTotalAmountOrder(Request.QueryString[0].ToString())) + Convert.ToDecimal(odr.GetTotalAmountShippingOrder(Request.QueryString[0].ToString())) - Convert.ToDecimal(lblcoupon.InnerText));
            //    }
            //}

            if (odr.GetTotalAmountShippingOrder(Request.QueryString[0]) == "")
            {
                lblgrandtotal.Text = Convert.ToString(Convert.ToDecimal(odr.GetTotalAmountOrder(Request.QueryString[0])) + Convert.ToDecimal(0) - Convert.ToDecimal(lblcoupon.InnerText) + Convert.ToDecimal(lbldiscountamount.InnerText));
            }
            else
            {
                lblgrandtotal.Text = Convert.ToString(Convert.ToDecimal(odr.GetTotalAmountOrder(Request.QueryString[0])) + Convert.ToDecimal(odr.GetTotalAmountShippingOrder(Request.QueryString[0])) - Convert.ToDecimal(lblcoupon.InnerText) + Convert.ToDecimal(lbldiscountamount.InnerText));
            }

            string order_section = odr.GetOrderSection(Request.QueryString[0]);

            if (Convert.ToDecimal(lblsubtotal.InnerText) > Convert.ToDecimal(149) && order_section == "Grocery")
            {
                lblshippingcharge.InnerText = "Free";
            }
            else if (Convert.ToDecimal(lblsubtotal.InnerText) > Convert.ToDecimal(99) && order_section == "Restaurant")
            {
                lblshippingcharge.InnerText = "Free";
            }
            else
            {
                lblshippingcharge.InnerText = odr.GetTotalAmountShippingOrder(Request.QueryString[0]);
            }

        }
    }


    private void BindData()
    {
        rptorderproduct.DataSource = mst.GetData("SELECT * FROM ecommerce_order where order_id='" + Request.QueryString[0]+ "' AND order_status!='Cancelled' ");
        rptorderproduct.DataBind();
    }
}