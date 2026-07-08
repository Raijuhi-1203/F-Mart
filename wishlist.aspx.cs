using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wishlist : System.Web.UI.Page
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
           
            BindData2();

        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    private void BindData2()
    {
        Repeater1.DataSource = mst.GetData("select a.*,b.*,c.*,d.* from ecommerce_wishlist a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id left join ecommerce_product as d on a.product_id=d.product_id where a.customer_id='" + Session["customer_id"].ToString() + "'");
        Repeater1.DataBind();

        if (Repeater1.Items.Count == 0)
        {
            Panel1.Visible = true;
        }
        else
        {
            Panel1.Visible = false;
        }

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            string product_id = Convert.ToString(e.CommandArgument);
            wb.removetowishlist(Session["customer_id"].ToString(), product_id, get_price_id(product_id));
            Response.Write("<script>alert('Product remove from wishlist.');</script>");
            BindData2();
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

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