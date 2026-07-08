using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
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
            BindData1();
            BindData2();
            BindData3();
            BindData4();
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id");
        rptbinddata.DataBind();
    }
    private void BindData1()
    {
        Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id");
        Repeater1.DataBind();
    }
    private void BindData2()
    {
        Repeater2.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id");
        Repeater2.DataBind();
    }
    private void BindData3()
    {
        Repeater3.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id");
        Repeater3.DataBind();
    }
    private void BindData4()
    {
        Repeater4.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id");
        Repeater4.DataBind();
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
            cmd.CommandText = @"SELECT id FROM ecommerce_product_price where product_id='"+ product_id + "'";
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

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater4_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnwishlist_ServerClick(object sender, EventArgs e)
    {

    }

}