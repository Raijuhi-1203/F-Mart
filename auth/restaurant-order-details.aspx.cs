using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class auth_order_details : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Product pdt = new Product();
    Order odr = new Order();
    RestaurantOrder foodOdr = new RestaurantOrder();
    Bulksms_gateway bulksms = new Bulksms_gateway();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindOrderItem();

            lblorderno.Text = Request.QueryString[0].ToString();

            printinvoicelink.HRef = "print-invoice-full.aspx?ref=" + Request.QueryString[0];

            // Get Order Info

            SqlDataReader get_order_info = foodOdr.Get_Order_info_by_Order_id(lblorderno.Text);
            
            if (get_order_info.Read())
            {
                lblbillingaddress.Text = get_order_info["billing_address_line1"].ToString() + "<br/>" + get_order_info["billing_address_line2"].ToString();
                lblbillingcitystatepincode.Text = get_order_info["billing_city_name"].ToString() + ", " + get_order_info["billing_state_name"].ToString() + "-" + get_order_info["billing_pincode"].ToString();

                lblbillingname.Text = get_order_info["customer_name"].ToString();
                lblbillingemail.Text = get_order_info["customer_email"].ToString();

               // lblbillingmobileno.Text = get_order_info["customer_mobileno"].ToString();
                lblpaymentmethod.Text = get_order_info["payment_mode"].ToString();

                lblbillinglandmark.Text = get_order_info["billing_landmark"].ToString();
                lblorderplacedate.Text = get_order_info["order_date"].ToString()+" "+ get_order_info["order_time"].ToString();

                lblcoupon.Text = get_order_info["coupan_value"].ToString();
                lbl_refund_mode.Text = get_order_info["refund_mode"].ToString();

                lbl_customer_id.Text = get_order_info["customer_id"].ToString();

                lbl_seller_id.Text = get_order_info["product_sellerid"].ToString();

                lbl_schedule_time.Text = get_order_info["delivery_schedule_time"].ToString();
            }

            
            get_order_info.Close();

            SqlDataReader get_cust_mob = foodOdr.Get_cust_mobileno(lbl_customer_id.Text);
            if (get_cust_mob.Read())
            {
                lblbillingmobileno.Text = get_cust_mob["customer_mobileno"].ToString();
            }
            get_cust_mob.Close();
            // Total

            lbltotaldiscount.Text = Convert.ToString(mst.Count_data("select case when  Count(*) <= 1 then ISNULL(Sum(product_discount_price),0)*isnull(sum(product_qty),0) else ISNULL(Sum(product_discount_price),0) end from  ecommerce_order where order_id='" + Request.QueryString[0] + "'  AND order_status!='Cancelled' "));
                     
            lbltotalgstamount.Text = foodOdr.GetTotalAmountGSTOrder(lblorderno.Text);

            if (foodOdr.GetTotalAmountShippingOrder(lblorderno.Text) == "")
            {
                lblgrandtotalamount.Text = Convert.ToString(Convert.ToDecimal(foodOdr.GetTotalAmountOrder(lblorderno.Text)) + Convert.ToDecimal(0)-Convert.ToDecimal(lblcoupon.Text)-Convert.ToDecimal(lbltotaldiscount.Text));
            }
            else
            {
                lblgrandtotalamount.Text = Convert.ToString(Convert.ToDecimal(foodOdr.GetTotalAmountOrder(lblorderno.Text)) + Convert.ToDecimal(foodOdr.GetTotalAmountShippingOrder(lblorderno.Text))-Convert.ToDecimal(lblcoupon.Text)-Convert.ToDecimal(lbltotaldiscount.Text));
            }

            lblsubtotal.Text = Convert.ToString(mst.Count_data("Select ISNULL(Sum(total_amount_of_product),0) from  ecommerce_order where order_id='" + Request.QueryString[0] + "' AND order_status!='Cancelled' "));

            // shipping charge calculate

            string order_section = odr.GetOrderSection(lblorderno.Text);

            if (Convert.ToDecimal(lblsubtotal.Text) > Convert.ToDecimal(149) && order_section == "Grocery")
            {
                lbltotalshippingamount.Text = "Free";
            }
            else if (Convert.ToDecimal(lblsubtotal.Text) > Convert.ToDecimal(99) && order_section == "Restaurant")
            {
                lbltotalshippingamount.Text = "Free";
            }
            else
            {
                lbltotalshippingamount.Text = odr.GetTotalAmountShippingOrder(lblorderno.Text);
            }

            // Get Restaurant Data

            SqlDataReader get_restaurant_data = mst.Select_Operation("Select * from ecommerce_seller where seller_id='" + lbl_seller_id.Text + "' ");
            if (get_restaurant_data.Read())
            {
                lbl_restaurant_mobile.Text = get_restaurant_data["seller_mobileno"].ToString();
                lbl_restaurant_address.Text = get_restaurant_data["seller_address_line_1"].ToString()+", "+ get_restaurant_data["seller_city_name"].ToString()+"<br/>"+ get_restaurant_data["seller_pincode"].ToString();
                lbl_restaurant_name.Text = get_restaurant_data["seller_firm_name"].ToString();
            }

            get_restaurant_data.Close();

        }
    }
   
    private void BindOrderItem()
    {
        rptbinddataprice.DataSource = mst.GetData("SELECT * FROM ecommerce_order where order_id='" + Request.QueryString[0] + "' ");
        rptbinddataprice.DataBind();
    }

    protected void rptbinddataprice_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblproductid = (Label)e.Item.FindControl("lblproductid");
            Label lblorderstatus = (Label)e.Item.FindControl("lblorderstatus");
            DropDownList dblorderstatus = (DropDownList)e.Item.FindControl("dblorderstatus");

            dblorderstatus.SelectedValue = lblorderstatus.Text;

            Status_Option(dblorderstatus);
            Status_Option(dblchangeorderstatus);
        }
    }

    private void Status_Option(DropDownList orderstatus)
    {
        int no_of_order = mst.Count_data("Select Count(id) from ecommerce_order Where order_id='" + Request.QueryString[0] + "' ");

        int no_of_cancelled_request = mst.Count_data("Select Count(id) from ecommerce_order Where order_id='" + Request.QueryString[0] + "' AND order_status='Cancelled Request' ");

        int no_of_cancelled = mst.Count_data("Select Count(id) from ecommerce_order Where order_id='" + Request.QueryString[0] + "' AND order_status='Cancelled' ");

        if (no_of_order == no_of_cancelled)
        {
            orderstatus.Enabled = false;
        }
    }

    protected void rptbinddataprice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btnstatuschangesuborder"))
        {
            Label lblsuborderid = (Label)e.Item.FindControl("lblsuborderid");
            DropDownList dblorderstatus = (DropDownList)e.Item.FindControl("dblorderstatus");
            Label lbl_total_amount_of_product = (Label)e.Item.FindControl("lbl_total_amount_of_product");

            string status = dblorderstatus.SelectedValue;

            switch(status)
            {
                case "Confirm":

                    int confirm = foodOdr.Update_Order_status_Normal(lblsuborderid.Text,dblorderstatus.SelectedValue);

                    if(confirm>0)
                    {
                        ShowMessage("Order has been "+dblorderstatus.SelectedValue+".",MessageType.Success);

                        bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblorderstatus.SelectedValue + ": Your Arshit Order " + lblsuborderid.Text + " has been confirmed. Thanks for your patience.");

                        BindOrderItem();
                    }

                    break;

                case "Dispatched":

                    int dispatched = foodOdr.Update_Order_status_Normal(lblsuborderid.Text, dblorderstatus.SelectedValue);

                    if (dispatched > 0)
                    {
                        ShowMessage("Order has been " + dblorderstatus.SelectedValue + ".", MessageType.Success);

                        bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblorderstatus.SelectedValue + ": Your Arshit Order " + lblsuborderid.Text + " has been dispatched. Thanks for your patience.");

                        BindOrderItem();
                    }


                    break;

                case "Delivered":

                    int delivered = foodOdr.Update_Order_status_Deliver(lblsuborderid.Text, dblorderstatus.SelectedValue,DateTime.Now.ToString("yyyy-MM-dd"),DateTime.Now.ToString("hh:mm tt"));

                    if (delivered > 0)
                    {
                        ShowMessage("Order has been " + dblorderstatus.SelectedValue + ".", MessageType.Success);

                       bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblorderstatus.SelectedValue + ": Your Arshit Order " + lblsuborderid.Text + " was successfully delivered. Please review us on Google.");

                        BindOrderItem();
                    }

                    break;

                case "Cancelled":

                    int cancelled = foodOdr.Update_Order_status_Cancel(lblsuborderid.Text, dblorderstatus.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm tt"));

                    if (cancelled > 0)
                    {

                        string new_total_order_amount= Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDecimal(lblgrandtotalamount.Text) -Convert.ToDecimal(lbl_total_amount_of_product.Text)), 0, MidpointRounding.AwayFromZero));

                        int update_total_order_amount = foodOdr.Update_Total_Order_Amount(new_total_order_amount,Request.QueryString[0]);

                        // Refund Amount

                        if(lblpaymentmethod.Text== "Razor Pay" || lblpaymentmethod.Text == "Cash on delivery")
                        {
                            ShowMessage("Order has been " + dblorderstatus.SelectedValue + ".", MessageType.Success);

                            bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblorderstatus.SelectedValue + ": Your Arshit Order " + lblsuborderid.Text + " has been cancelled. Once we pickup cancelled item. Refund will be credited within 1 week.");

                        }
                        else
                        {
                            if (lbl_refund_mode.Text == "Bank Account")
                            {
                                ShowMessage("Order has been " + dblorderstatus.SelectedValue + ".", MessageType.Success);

                                bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblorderstatus.SelectedValue + ": Your Arshit Order " + lblsuborderid.Text + " has been cancelled. Once we pickup cancelled item. Refund will be credited within 1 week.");

                            }
                           
                        }

                        BindOrderItem();
                    }

                    break;
              
            }

        }
    }

    protected void btnorderstatusupdate_ServerClick(object sender, EventArgs e)
    {
        string status = dblchangeorderstatus.SelectedValue;

        switch (status)
        {
            case "Confirm":

                int confirm = foodOdr.Update_Order_status_Normal_OrderID(Request.QueryString[0], dblchangeorderstatus.SelectedValue);

                if (confirm > 0)
                {
                    ShowMessage("Order has been " + dblchangeorderstatus.SelectedValue + ".", MessageType.Success);

                    bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblchangeorderstatus.SelectedValue + ": Your Arshit Order " + Request.QueryString[0] + " has been confirmed. Thanks for your patience.");


                    BindOrderItem();
                }

                break;

            case "Dispatched":

                int dispatched = foodOdr.Update_Order_status_Normal_OrderID(Request.QueryString[0], dblchangeorderstatus.SelectedValue);

                if (dispatched > 0)
                {
                    ShowMessage("Order has been " + dblchangeorderstatus.SelectedValue + ".", MessageType.Success);

                    bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblchangeorderstatus.SelectedValue + ": Your Arshit Order " + Request.QueryString[0] + " has been dispatched. Thanks for your patience.");

                    BindOrderItem();
                }

                break;

            case "Delivered":

                int delivered = foodOdr.Update_Order_status_Deliver_OrderID(Request.QueryString[0], dblchangeorderstatus.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm tt"));

                if (delivered > 0)
                {
                   
                    ShowMessage("Order has been " + dblchangeorderstatus.SelectedValue + ".", MessageType.Success);

                   
                    bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblchangeorderstatus.SelectedValue + ": Your Arshit Order " + Request.QueryString[0] + " was successfully delivered. Please review us on Google.");

                    BindOrderItem();
                }

                break;

            case "Cancelled":

                int cancelled = foodOdr.Update_Order_status_Cancel_OrderID(Request.QueryString[0], dblchangeorderstatus.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm tt"));

                if (cancelled > 0)
                {
                    // Refund Amount

                    if (lblpaymentmethod.Text == "Razor Pay" || lblpaymentmethod.Text == "Cash on delivery")
                    {
                        ShowMessage("Order has been " + dblchangeorderstatus.SelectedValue + ".", MessageType.Success);

                        bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblchangeorderstatus.SelectedValue + ": Your Arshit Order " + Request.QueryString[0] + " has been cancelled. Once we pickup cancelled item. Refund will be credited within 1 week.");
                    }
                    else
                    {
                        if (lbl_refund_mode.Text == "Bank Account")
                        {
                            ShowMessage("Order has been " + dblchangeorderstatus.SelectedValue + ".", MessageType.Success);

                            bulksms.sendMessage(lblbillingmobileno.Text, "Order " + dblchangeorderstatus.SelectedValue + ": Your Arshit Order " + Request.QueryString[0] + " has been cancelled. Once we pickup cancelled item. Refund will be credited within 1 week.");
                        }
                        

                    }

                    BindOrderItem();
                }

                break;

        }
    }

   
}