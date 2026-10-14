using Razorpay.Api;
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class generate_invoice : System.Web.UI.Page
{
    string _key = "rzp_live_Tm5LLmRLKThMuK";
    string _secret = "nY6mwpCZaJ1zuhFrAnoAFprY";
    //string _key = "rzp_test_TnGdTwLOWkY12U";
    //string _secret = "DpcwnkNEEbN3U8s9Q1RCTCyI";
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    Master mst = new Master();
    string razorpayOrderId = "";
    string paymentMethod = "";
    string paymentStatus = "";
    string customerEmail = "";
    string customerContact = "";
    string bankRRN = "";
    string customerName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string paymentId = Request.QueryString[0];
            string orderId = Request.QueryString[1];
            string signature = Request.QueryString[2];

            try
            {
                if (string.IsNullOrEmpty(paymentId))
                {
                    return;
                }

                RazorpayClient client = new RazorpayClient(_key, _secret);

                // Fetch payment from Razorpay
                Payment payment = client.Payment.Fetch(paymentId);

                string razorpayPaymentId = payment["id"].ToString();

                if (payment["order_id"] != null)
                    razorpayOrderId = payment["order_id"].ToString();

                if (payment["method"] != null)
                    paymentMethod = payment["method"].ToString();

                if (payment["status"] != null)
                    paymentStatus = payment["status"].ToString();

                if (payment["email"] != null)
                    customerEmail = payment["email"].ToString();

                if (payment["contact"] != null)
                    customerContact = payment["contact"].ToString();

                // Get RRN
                if (payment["acquirer_data"] != null)
                {
                    try
                    {
                        dynamic acquirerData = payment["acquirer_data"];

                        if (acquirerData["rrn"] != null)
                        {
                            bankRRN = acquirerData["rrn"].ToString();
                        }
                    }
                    catch
                    {
                        bankRRN = "";
                    }
                }

                // Get customer name from notes
                if (payment["notes"] != null)
                {
                    try
                    {
                        dynamic notes = payment["notes"];

                        if (notes["customer_name"] != null)
                        {
                            customerName =
                                notes["customer_name"].ToString();
                        }
                    }
                    catch
                    {
                        customerName = "";
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(
                    "Payment processing error: " +
                    ex.Message
                );
            }

            dt.InnerText = DateTime.Now.ToString("dd MMM yyyy");
            ordid.InnerText = Request.QueryString[3];
            smail.InnerText = "Email :" + customerEmail;
            smob.InnerText = "Phone :" + customerContact;


            SqlDataReader dr_data1 = mst.Select_Operation("select top 1 * from ecommerce_order where order_id='" + Request.QueryString[3] + "'");
            if (dr_data1.Read())
            {
                add.InnerText = dr_data1["billing_address_line1"].ToString();
                add2.InnerText = dr_data1["billing_address_line2"].ToString();
                add3.InnerText = dr_data1["billing_city_name"].ToString() + ", " + dr_data1["billing_state_name"].ToString() + ", " + dr_data1["billing_pincode"].ToString();
                name.InnerText = dr_data1["customer_name"].ToString();
                sname.InnerText = dr_data1["customer_name"].ToString();
                gtotal.InnerText = "₹ " + dr_data1["total_order_amount"].ToString();
                shipping.InnerText = "₹ " + dr_data1["product_shipping_charge"].ToString();
            }

            dr_data1.Close();

            SqlDataReader dr_data = mst.Select_Operation("select sum(total_amount_of_product) as total from ecommerce_order where order_id='" + Request.QueryString[3] + "'");
            if (dr_data.Read())
            {
                subtotal.InnerText = "₹ " + dr_data["total"].ToString();
                double gstt = Convert.ToDouble(dr_data["total"].ToString());

                double gstAmount = (gstt * 18) / 100;
                double totalAmount = gstt + gstAmount + 100;
                totalAmount = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero);
                gst.InnerText = "₹ "+ gstAmount.ToString();
                gtotal.InnerText = "₹ " + totalAmount.ToString();

            }
            dr_data.Close();

            

            BindData();
        }

    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_order where order_id='" + Request.QueryString[3] + "'");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }


    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}