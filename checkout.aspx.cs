using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class checkout : System.Web.UI.Page
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
            BindData();
            subtotal.InnerText = "Rs. " + (getsubtotal(Session["customer_id"].ToString()));
            totalamt.InnerText = "Rs. " + (gettotal(Session["customer_id"].ToString()));
            placeorder.InnerText = "Rs. " + (gettotal(Session["customer_id"].ToString()));
            string q = "Select count(*) from ecommerce_cart where customer_id='" + Session["customer_id"].ToString() + "'";
            item_count.InnerText = mst.Count_data(q).ToString()+ " Items";
        }
        else
        {
            Response.Redirect("login.aspx");
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
        rptbinddata.DataSource = mst.GetData("select d.*,a.*,b.*,c.*,(CAST(d.cart_qty as float) * CAST(b.product_sell_price as float)) as total from ecommerce_cart d left join ecommerce_product as a on d.product_id=a.product_id left join ecommerce_product_price as b on d.product_id=b.product_id left join ecommerce_product_photos as c on d.product_id=c.product_id where d.customer_id='" + Session["customer_id"].ToString() + "'");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }

    protected void btnorder_ServerClick(object sender, EventArgs e)
    {
        int success = 0;

        string order_id_temp = getorder_id_temp();
        string order_id = "ODR" + order_id_temp;


        if (firstname.Text.Length > 0 && lastname.Text.Length > 0 && email.Text.Length > 0 && phone.Text.Length > 0 && address.Text.Length > 0 && apartment.Text.Length > 0 && state.Text.Length > 0 && city.Text.Length > 0 && pincode.Text.Length > 0)
        {
            foreach (RepeaterItem item in rptbinddata.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                   
                    Label product_id = (Label)item.FindControl("product_id");
                    Label price_id = (Label)item.FindControl("price_id");

                    success = mst.Add_Order(Session["customer_id"].ToString(), firstname.Text + " " + lastname.Text, email.Text, phone.Text, address.Text, apartment.Text, state.Text, city.Text, pincode.Text, product_id.Text, price_id.Text, gettotal(Session["customer_id"].ToString()), order_id, order_id_temp);

                    wb.removetocart(Session["customer_id"].ToString(), "", product_id.Text, price_id.Text);
                }
            }
            
            if (success > 0)
            {
                ShowMessage("Order Placed.", MessageType.Success);
                Response.Write("<script>alert('Order Placed.');</script>");
                Response.Redirect("order-confirmation.aspx?ref=" + order_id);
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

    
}