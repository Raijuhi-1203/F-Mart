using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class categories_product : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

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
            
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        Page.Title = "Furniture Mart – Shop Premium Office & Executive Chairs";
        Page.MetaDescription = "Shop premium executive chairs at Furniture Mart. Ergonomic, stylish, and built for comfort—ideal for office and professional workspace settings.";
        base.OnLoad(e);
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where a.product_parent_category_id='" + Request.QueryString[0] + "' or a.product_sub_category_id='"+ Request.QueryString[0] + "'");
        rptbinddata.DataBind();

        if (rptbinddata.Items.Count == 0)
        {
            NoDataPanel.Visible = true;
        }
        else
        {
            NoDataPanel.Visible = false;
        }
    }
    
    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            if (e.CommandName == "AddCart")
            {
                string product_id = Convert.ToString(e.CommandArgument);
                wb.addtocart("1", Session["customer_id"].ToString(), "", product_id, get_price_id(product_id));
                Response.Write("<script>alert('Product added in cart.');</script>");
                BindData();
            }
            if (e.CommandName == "Wishlist")
            {
                string product_id = Convert.ToString(e.CommandArgument);
                wb.addtowishlist("1", Session["customer_id"].ToString(), product_id, get_price_id(product_id));
                Response.Write("<script>alert('Product added in wishlist.');</script>");
                BindData();
            }
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
}