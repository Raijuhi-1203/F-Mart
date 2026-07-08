using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product_details : System.Web.UI.Page
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
            BindData();

            SqlDataReader dr_get_data = mst.Select_Operation("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where a.product_id='" + Request.QueryString[0] + "'");
            if (dr_get_data.Read())
            {
                category.InnerText = dr_get_data["product_parent_category_name"].ToString();
                product_name.InnerText = dr_get_data["product_full_name"].ToString();
                sell_price.InnerText = "Rs. "+dr_get_data["product_final_sell_price"].ToString();
                shop_price.InnerText = "Rs. " + dr_get_data["product_market_price"].ToString();
                discount_price.InnerText = "Save Rs. " + dr_get_data["product_discount_price"].ToString();
                discount_percentage.InnerText = "(" + dr_get_data["product_discount_percentage"].ToString()+ "% off)";
                description.Text = dr_get_data["product_description"].ToString();
                descp.Text = dr_get_data["product_description"].ToString();
                product_img.ImageUrl = "auth/"+dr_get_data["photo_path"].ToString();
                
            }
            dr_get_data.Close();
        }
    }


    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("select a.* from ecommerce_product_photos a where a.product_id='" + Request.QueryString[0] +"'");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }



    protected void btncart_ServerClick(object sender, EventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            
            wb.addtocart("1", Session["customer_id"].ToString(), "", Request.QueryString[0], get_price_id(Request.QueryString[0]));
            Response.Write("<script>alert('Product added in cart.');</script>");
            
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btncart2_ServerClick(object sender, EventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            
            wb.addtocart("1", Session["customer_id"].ToString(), "", Request.QueryString[0], get_price_id(Request.QueryString[0]));
            Response.Write("<script>alert('Product added in cart.');</script>");
            Response.Redirect("cart.aspx");
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btnwishlist_ServerClick(object sender, EventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            
            wb.addtowishlist("1", Session["customer_id"].ToString(), Request.QueryString[0], get_price_id(Request.QueryString[0]));
            Response.Write("<script>alert('Product added in wishlist.');</script>");
        }
        else
        {
            Response.Redirect("login.aspx");
        }
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


    protected void minus_ServerClick(object sender, EventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            string product_id = Convert.ToString(Request.QueryString[0]);
            string price_id = get_price_id(product_id);
            string qty = changeqty.Text;
            int cq = Convert.ToInt32(qty);

        if (cq > 1)
        {
            cq--;
            int a = cq;
            changeqty.Text = a.ToString();
            string mrpp = get_product_mrp(price_id);
            double price = Convert.ToDouble(mrpp) * Convert.ToDouble(a);
            sell_price.InnerText = "Rs. " + price.ToString();
            wb.addtocart_changeqty(changeqty.Text, Session["customer_id"].ToString(), "", product_id, price_id);
            
        }
        else if (cq == 1)
        {
            wb.removetocart(Session["customer_id"].ToString(), "", product_id, price_id);
        }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void plus_ServerClick(object sender, EventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            string product_id = Convert.ToString(Request.QueryString[0]);
        string price_id = get_price_id(product_id);
        string qty = changeqty.Text;
        int cq = Convert.ToInt32(qty);
        cq++;
        int a = cq;
        changeqty.Text = a.ToString();
        string mrpp = get_product_mrp(price_id);
        double price = Convert.ToDouble(mrpp) * Convert.ToDouble(a);
        sell_price.InnerText = "Rs. " + price.ToString();
        wb.addtocart_changeqty(changeqty.Text, Session["customer_id"].ToString(), "", product_id, price_id);
        
        }
        else
        {
            Response.Redirect("login.aspx");
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

    public string get_cart_qty(string customer_id, string product_id)
    {
        string output = string.Empty;
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT cart_qty as carttotal from ecommerce_cart where customer_id='" + customer_id + "' and product_id='" + product_id + "'";
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


}