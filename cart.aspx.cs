using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class cart : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (Session["customer_id"] != null)
            {
                BindData();

                subtotal.InnerText = "Rs. " + (getsubtotal(Session["customer_id"].ToString()));
                totalamt.InnerText = "Rs. " + (gettotal(Session["customer_id"].ToString()));
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

        if (mrp == "")
        {
            mrp = "0.0";
        }
        else
        {
            mrp = mrp;
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
        rptbinddata.DataSource = mst.GetData("select d.*,a.*,b.*,c.*,(CAST(d.cart_qty as float) * CAST(b.product_sell_price as float)) as total from ecommerce_cart d left join ecommerce_product as a on d.product_id=a.product_id left join ecommerce_product_price as b on d.product_id=b.product_id left join ecommerce_product_photos as c on d.product_id=c.product_id where d.customer_id='" + Session["customer_id"].ToString() +"'");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        RepeaterItem item = e.Item;
        TextBox changeqty = item.FindControl("changeqty") as TextBox;
        Label total = item.FindControl("total") as Label;
        //Label mrp = item.FindControl("mrp") as Label;

        if (e.CommandName == "Remove")
        {
            string product_id = Convert.ToString(e.CommandArgument);
            wb.removetocart(Session["customer_id"].ToString(), "", product_id, get_price_id(product_id));
            Response.Write("<script>alert('Product remove from cart.');</script>");
            BindData();
        }

        if (e.CommandName == "Minus")
        {
            string product_id = Convert.ToString(e.CommandArgument);
            string price_id = get_price_id(product_id);
            string qty = get_cart_qty(Session["customer_id"].ToString(),product_id);
            int cq = Convert.ToInt32(qty);

            if (cq > 1)
            {
                cq--;
                int a = cq;
                changeqty.Text = a.ToString();
                string mrpp = get_product_mrp(price_id);
                double price = Convert.ToDouble(mrpp) * Convert.ToDouble(a);
                total.Text = price.ToString();
                wb.addtocart_changeqty(changeqty.Text, Session["customer_id"].ToString(), "", product_id, price_id);
                BindData();
            }
            else if (cq == 1)
            {
                wb.removetocart(Session["customer_id"].ToString(), "", product_id, price_id);
            }
            
            
        }

        if (e.CommandName == "Add")
        {
            
            string product_id = Convert.ToString(e.CommandArgument);
            string price_id = get_price_id(product_id);
            string qty = get_cart_qty(Session["customer_id"].ToString(), product_id);
            int cq = Convert.ToInt32(qty);
            cq++;
            int a = cq;
            changeqty.Text = a.ToString();
            string mrpp = get_product_mrp(price_id);
            double price = Convert.ToDouble(mrpp) * Convert.ToDouble(a);
            total.Text = price.ToString();
            wb.addtocart_changeqty(changeqty.Text, Session["customer_id"].ToString(), "", product_id, price_id);
            BindData();
        }
    }

    private string get_product_mrp(string price_id)
    {
        string mrp = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT product_sell_price FROM ecommerce_product_price where id='" + price_id + "'";
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

    private string get_price_id(string product_id)
    {
        string id = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT id FROM ecommerce_product_price where product_id='" + product_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            int i = 1;
            while (rdr.Read())
            {
                id = rdr["id"].ToString();
            }
        }
        return id;
    }

    public string get_cart_qty(string customer_id, string product_id)
    {
        string output = string.Empty;
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT cart_qty as carttotal from ecommerce_cart where customer_id='" + customer_id + "' and product_id='"+ product_id + "'";
                #endregion 
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output = rdr["carttotal"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            string text = ex.ToString();

        }
        return output;

    }

    protected void btnupdatecart_ServerClick(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnclearcart_ServerClick(object sender, EventArgs e)
    {
        removetocart(Session["customer_id"].ToString());
    }

    public void removetocart(string customer_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("delete from ecommerce_cart where customer_id='" + customer_id + "'"))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

            }
        }
    }


}