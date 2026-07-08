using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_today_sale_report : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Order odr = new Order();
    Master mst = new Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }

    }

    private void BindTotal()
    {
        SqlDataReader sqlDataReader = mst.GetTotalAmount(txt_date_to.Text);

        //int s = 0;
        //int count = 1;
        //while (sqlDataReader.Read())
        //{
        //    s += Convert.ToInt32(sqlDataReader["total_order_amount"]);
        //    count++;
        //}
        //lbltotal.Text = s.ToString();

        if (sqlDataReader.Read())
        {

            lbltotal.Text = sqlDataReader["total_order_amount"].ToString();
            lblselleramount.Text = sqlDataReader["original_price"].ToString();
        }

        sqlDataReader.Close();
    }

    private void BindOrderCurrentMonth()
    {
        rptbinddata.DataSource = mst.GetData("SELECT Max(a.id) as id, Max(a.order_id) as order_id,Max(a.order_date) as order_date,max(a.product_sellername) as product_sellername,(sum(a.total_amount_of_product)-sum(a.product_discount_price)) as total_order_amount,sum(b.original_price) as original_price FROM ecommerce_order a left join ecommerce_product_price as b on b.id=a.product_price_id where a.order_section='Restaurant' AND a.order_date ='" + txt_date_to.Text + "' and a.order_status!='Cancelled' Group by a.product_sellerid");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblorderid = (Label)e.Item.FindControl("lblorderid");
            Label lbl_orderdate = (Label)e.Item.FindControl("lbl_orderdate");
            lbl_orderdate.Text = txt_date_to.Text;

        }
    }

    protected void btnsearch_ServerClick(object sender, EventArgs e)
    {
        if (txt_date_to.Text.Length > 0)
        {
            BindOrderCurrentMonth();
            BindTotal();
        }
        else
        {
            ShowMessage("Please Enter Date field.", MessageType.Error);
        }
    }


}