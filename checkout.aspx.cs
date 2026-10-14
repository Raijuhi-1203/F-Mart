using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class checkout : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    string _key = "rzp_live_Tm5LLmRLKThMuK";
    string _secret = "0zHgcnRLGx7tgVwDPxj1LxZj";
    //string _key = "rzp_test_TnGdTwLOWkY12U";
    //string _secret = "DpcwnkNEEbN3U8s9Q1RCTCyI";
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    WebService wb = new WebService();
    double amt,gst,  finalAmount;
    string order_id_temp = string.Empty;
    string order_id = string.Empty;
    Label product_id, price_id;

    string paymentMode, razorpayPaymentId, paymentOrderId, transactionStatus,
        bankTransactionId, gatewayName, transactionId, paymentRequestId,
        transactionPaymentMode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["customer_id"] != null)
            {
                BindData();
                subtotal.InnerText = "Rs. " + (getsubtotal(Session["customer_id"].ToString()));
                totalamt.InnerText = "Rs. " + (gettotal(Session["customer_id"].ToString()));
                placeorder.InnerText = "Rs. " + (gettotal(Session["customer_id"].ToString()));
                string q = "Select count(*) from ecommerce_cart where customer_id='" + Session["customer_id"].ToString() + "'";
                item_count.InnerText = mst.Count_data(q).ToString() + " Items";

                double amt = Convert.ToDouble(getsubtotal(Session["customer_id"].ToString()));
                double gstt = (amt * 18) / 100;
                gstin.InnerText = "Rs. " + gstt.ToString();
                double ttl = Convert.ToDouble(gettotal(Session["customer_id"].ToString()));
                ttl = ttl + gstt;
                totalamt.InnerText = "Rs. " + ttl;
                placeorder.InnerText = "Rs. " + ttl;

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }

    private string gettotal(string customer_id)
    {
        string mrp = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT sum(cast(a.product_sellername as float))product_sell_price FROM  ecommerce_cart a where customer_id='" + customer_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            int i = 1;
            while (rdr.Read())
            {
                mrp = rdr["product_sell_price"].ToString();
            }
        }

        double ttl = Convert.ToDouble(mrp) + 100.0;
        mrp = ttl.ToString();
        return mrp;
    }

    private string getsubtotal(string customer_id)
    {
        string mrp = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT sum(cast(a.product_sellername as float))product_sell_price FROM  ecommerce_cart a where customer_id='" + customer_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            int i = 1;
            while (rdr.Read())
            {
                mrp = rdr["product_sell_price"].ToString();
            }
        }
        return mrp;
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("select d.*,a.*,b.*,(select top 1 photo_path from ecommerce_product_photos where product_id=a.product_id) as photo_path,(CAST(d.cart_qty as float) * CAST(b.product_sell_price as float)) as total from ecommerce_cart d left join ecommerce_product as a on d.product_id=a.product_id left join ecommerce_product_price as b on d.product_id=b.product_id where d.customer_id='" + Session["customer_id"].ToString() + "'");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnorder_ServerClick(object sender, EventArgs e)
    {

        if (firstname.Text.Length > 0 && lastname.Text.Length > 0 && email.Text.Length > 0 && phone.Text.Length > 0 && address.Text.Length > 0 && apartment.Text.Length > 0 && state.Text.Length > 0 && city.Text.Length > 0 && pincode.Text.Length > 0)
        {
            foreach (RepeaterItem item in rptbinddata.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {

                    product_id = (Label)item.FindControl("product_id");
                    price_id = (Label)item.FindControl("price_id");

                    double amt = Convert.ToDouble(getsubtotal(Session["customer_id"].ToString()));
                    double gstt = (amt * 18) / 100;
                    double ttl = Convert.ToDouble(gettotal(Session["customer_id"].ToString()));
                    finalAmount = ttl + gstt;

                    
                    // finalAmount = 1.00;
                    long amountinSubunits = Convert.ToInt64(Math.Round(finalAmount * 100.0));
                    string currency = "INR";
                    string name = "The F-Mart";
                    string description = "Razorpay Payment Gateway";
                    string imageLogo = "assests/LOGO.png";

                    string profileName = firstname.Text + " " + lastname.Text;
                    string profileMobile = phone.Text;
                    string profileEmail = email.Text;
                    Dictionary<string, string> notes = new Dictionary<string, string>()
                    {
                        { "note 1", "this is a payment note" }, { "note 2", "here another note, you can add max 15 notes" }
                    };

                    string orderId = CreateOrder(amountinSubunits, currency, notes);

                    string jsFunction = "OpenPaymentWindow('" + _key + "', '" + amountinSubunits + "', '" + currency + "', '" + name + "', '" + description + "', '" + imageLogo + "', '" + orderId + "', '" + profileName + "', '" + profileEmail + "', '" + profileMobile + "', '" + notes + "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenPaymentWindow", jsFunction, true);


                }
            }

        }
        else
        {

        }
    }

    private string getorder_id_temp()
    {
        string order_id_temp = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"select isnull(max(order_id_temp),0)order_id_temp from ecommerce_order";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                order_id_temp = rdr["order_id_temp"].ToString();
                int a = Convert.ToInt32(order_id_temp);
                a = a + 1;
                order_id_temp = a.ToString();
            }
            rdr.Close();
            con.Close();

            return order_id_temp;
        }
    }

    private string CreateOrder(double amountInSubunits, string currency, Dictionary<string, string> notes)
    {
        try
        {
            int paymentCapture = 1;

            RazorpayClient client = new RazorpayClient(_key, _secret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amountInSubunits);
            options.Add("currency", currency);
            options.Add("payment_capture", paymentCapture);
            options.Add("notes", notes);

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.Expect100Continue = false;

            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            var orderId = orderResponse.Attributes["id"].ToString();
            return orderId;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    protected void btnPaymentSuccess_Click1(object sender, EventArgs e)
    {
        string paymentId = hfPaymentId.Value.Trim();
        string razorpayOrderId = hfOrderId.Value.Trim();
        string signature = hfSignature.Value.Trim();

        if (Session["customer_id"] == null)
        {
            ShowMessage("Please login again.", MessageType.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(paymentId) || string.IsNullOrWhiteSpace(razorpayOrderId) || string.IsNullOrWhiteSpace(signature))
        {
            ShowMessage("Payment response is incomplete.", MessageType.Error);
            return;
        }

        bool isValid = VerifyRazorpaySignature(razorpayOrderId, paymentId, signature, GetRazorpayKeySecret());

        if (!isValid)
        {
            ShowMessage("Payment verification failed.", MessageType.Error);
            return;
        }

        string customerId = Session["customer_id"].ToString();

        // Read product and price IDs from the database.
        DataTable cartItems = new DataTable();

        using (SqlConnection con = new SqlConnection(cs))
        using (SqlCommand cmd = new SqlCommand(@"SELECT d.product_id, b.id FROM ecommerce_cart d INNER JOIN ecommerce_product_price b ON d.product_id = b.product_id WHERE d.customer_id = @customer_id", con))
        {
            cmd.Parameters.AddWithValue("@customer_id", customerId);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(cartItems);
            }
        }

        if (cartItems.Rows.Count == 0)
        {
            ShowMessage("No products found in your cart.", MessageType.Error);
            return;
        }

        string internalOrderId = "ODR" + getorder_id_temp();
        string internalOrderIdTemp = internalOrderId.Substring(3);
        GetRazorpayPaymentDetails(paymentId);
        int success = 0;

        foreach (DataRow row in cartItems.Rows)
        {
            string productId = Convert.ToString(row["product_id"]);
            string priceId = Convert.ToString(row["id"]);

            double amt = Convert.ToDouble(getsubtotal(Session["customer_id"].ToString()));
            double gstt = (amt * 18) / 100;
            double ttl = Convert.ToDouble(gettotal(Session["customer_id"].ToString()));
            double tttl = ttl + gstt;

            int result = mst.Add_Order("18", gstt.ToString(),customerId, firstname.Text + " " + lastname.Text, email.Text, phone.Text, address.Text, apartment.Text, state.Text, city.Text, pincode.Text, productId, priceId, tttl.ToString(), internalOrderId, internalOrderIdTemp, paymentMode, razorpayPaymentId, paymentOrderId, transactionStatus,
        bankTransactionId, gatewayName, transactionId, paymentRequestId,
        transactionPaymentMode);

            if (result <= 0)
            {
                ShowMessage("Payment verified, but order saving needs attention.", MessageType.Error);
                return;
            }

            success++;
        }

        // Remove cart products only after all orders are saved.
        foreach (DataRow row in cartItems.Rows)
        {
            wb.removetocart(customerId, "", Convert.ToString(row["product_id"]), Convert.ToString(row["id"]));
        }

        string url = "generate_invoice.aspx?payid=" + HttpUtility.UrlEncode(paymentId) + "&orderid=" + HttpUtility.UrlEncode(razorpayOrderId) + "&sign=" + HttpUtility.UrlEncode(signature) + "&ord=" + HttpUtility.UrlEncode(internalOrderId);
        Response.Redirect(url, false);
        Context.ApplicationInstance.CompleteRequest();

    }

    private string GetRazorpayKeySecret()
    {
        string secret = _secret;

        if (string.IsNullOrWhiteSpace(secret))
        {
            throw new ConfigurationErrorsException(
                "Razorpay Key Secret is missing in Web.config.");
        }

        return secret;
    }

    private bool VerifyRazorpaySignature(string orderId, string paymentId, string razorpaySignature, string keySecret)
    {
        if (string.IsNullOrWhiteSpace(orderId) ||
            string.IsNullOrWhiteSpace(paymentId) ||
            string.IsNullOrWhiteSpace(razorpaySignature) ||
            string.IsNullOrWhiteSpace(keySecret))
        {
            return false;
        }

        string payload = orderId + "|" + paymentId;

        using (HMACSHA256 hmac = new HMACSHA256(
            Encoding.UTF8.GetBytes(keySecret)))
        {
            byte[] hash = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(payload));

            string generatedSignature =
                BitConverter.ToString(hash)
                    .Replace("-", "")
                    .ToLowerInvariant();

            return string.Equals(
                generatedSignature,
                razorpaySignature,
                StringComparison.OrdinalIgnoreCase);
        }
    }

    public void GetRazorpayPaymentDetails(string paymentId)
    {
        RazorpayClient client = new RazorpayClient(_key, _secret);

        Payment payment = client.Payment.Fetch(paymentId);

        paymentMode = Convert.ToString(payment["method"]);
        razorpayPaymentId = Convert.ToString(payment["id"]);
        paymentOrderId = Convert.ToString(payment["order_id"]);
        transactionStatus = Convert.ToString(payment["status"]);

        bankTransactionId = "";

        var acquirerData = payment["acquirer_data"];

        if (acquirerData != null)
        {
            bankTransactionId = Convert.ToString(acquirerData["bank_transaction_id"]);

            if (string.IsNullOrWhiteSpace(bankTransactionId))
            {
                bankTransactionId = Convert.ToString(acquirerData["rrn"]);
            }
        }

        gatewayName = "Razorpay";
        transactionId = razorpayPaymentId;
        paymentRequestId = "";
        transactionPaymentMode = paymentMode;

    }

}