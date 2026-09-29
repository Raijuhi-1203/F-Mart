using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class print_bill : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindData();
            date.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            order_id.InnerText = Request.QueryString[0];
            nettotal.InnerText = "Rs. " + (getsubtotal(Session["customer_id"].ToString()));
            totalamt.InnerText = "Rs. " + (gettotal(Session["customer_id"].ToString()));

            SqlDataReader dr_get_data = mst.Select_Operation("select * from ecommerce_order where order_id='" + Request.QueryString[0] + "'");
            if (dr_get_data.Read())
            {
                add1.InnerText = dr_get_data["billing_address_line1"].ToString();
                add2.InnerText = dr_get_data["billing_address_line2"].ToString();
                city.InnerText = dr_get_data["billing_city_name"].ToString()+", "+dr_get_data["billing_state_name"].ToString()+"-"+dr_get_data["billing_pincode"].ToString();
            }
            dr_get_data.Close();
        }
    }

    private string gettotal(string customer_id)
    {
        string mrp = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT top 1  a.total_order_amount as product_sell_price FROM  ecommerce_order a where order_id='" + Request.QueryString[0] + "'";
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
            cmd.CommandText = @"SELECT top 1 a.total_order_amount as product_sell_price FROM  ecommerce_order a where order_id='" + Request.QueryString[0] + "'";
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
        rptbinddata.DataSource = mst.GetData("select d.*,a.*,b.*,c.*,(CAST(d.product_qty as float) * CAST(b.product_sell_price as float)) as total from ecommerce_order d left join ecommerce_product as a on d.product_id=a.product_id left join ecommerce_product_price as b on d.product_id=b.product_id left join ecommerce_product_photos as c on d.product_id=c.product_id where d.order_id='" + Request.QueryString[0] + "'");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

}