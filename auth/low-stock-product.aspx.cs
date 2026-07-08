using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class auth_Default : System.Web.UI.Page
{
    Master mst = new Master();

    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
        {
            Bind_Low_Stock();
        }
    }

    private void Bind_Low_Stock()
    {
        rpt_low_stock_product.DataSource = mst.GetData("SELECT R.product_id,R.product_unit_value,R.product_unit,R.product_stock,P.product_full_name FROM ecommerce_product_price R inner join ecommerce_product P ON R.product_id=P.product_id where product_seller_id='0' AND product_type='Grocery' AND product_stock < 20 order by product_stock asc");
        rpt_low_stock_product.DataBind();
    }
}