using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order_confirmation : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    WebService wb = new WebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            
            order_id.InnerText = "Order #" + Request.QueryString["ref"];
            order_date.InnerText = DateTime.Now.ToString("D");
           
            subtotal.InnerText = "Rs. " + (getsubtotal(Session["customer_id"].ToString()));
            totalamt.InnerText = "Rs. " + (gettotal(Session["customer_id"].ToString()));

            SqlDataReader dr_product_data = mst.Select_Operation("select * from ecommerce_order where order_id='" + Request.QueryString[0] + "'");
            if (dr_product_data.Read())
            {
                add.InnerText = dr_product_data["billing_address_line1"].ToString()+", "+ dr_product_data["billing_address_line2"].ToString()+", "+ dr_product_data["billing_city_name"].ToString()+", "+ dr_product_data["billing_state_name"].ToString()+"-"+ dr_product_data["billing_pincode"].ToString();
                email.InnerText = "Email : "+dr_product_data["customer_email"].ToString();
                phone.InnerText = "Mobile No.: " + dr_product_data["customer_mobileno"].ToString();
                
            }
            dr_product_data.Close();
            BindData();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("select * from ecommerce_order where order_id='" + Request.QueryString[0] + "'");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }


    private string gettotal(string customer_id)
    {
        string mrp = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT sum(cast(a.total_amount_of_product as float))product_sell_price FROM  ecommerce_order a where order_id='" + Request.QueryString["ref"] +"'";
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
            cmd.CommandText = @"SELECT sum(cast(a.total_amount_of_product as float))product_sell_price FROM  ecommerce_order a where order_id='" + Request.QueryString["ref"] + "'";
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

}