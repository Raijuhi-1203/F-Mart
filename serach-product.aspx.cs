using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class serach_product : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
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

        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where a.product_parent_category_name like '%" + Request.QueryString[0] + "%' or  a.product_full_name like '%" + Request.QueryString[0] + "%' or  a.product_short_name like '%" + Request.QueryString[0] + "%'");
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

    }


}