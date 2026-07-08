using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_restaurant_items : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData_Price();
        }
    }

    private void BindData_Price()
    {
        rptbinddataprice.DataSource = mst.GetData("SELECT * FROM ecommerce_product_price where price_seller_id='" + Request.QueryString[0] + "' order by id asc");
        rptbinddataprice.DataBind();
    }

    protected void rptbinddataprice_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl_product_id = (Label)e.Item.FindControl("lbl_product_id");
            Label lbl_item_name = (Label)e.Item.FindControl("lbl_item_name");

            SqlDataReader getData = mst.Select_Operation("Select product_full_name from ecommerce_product Where product_id='"+ lbl_product_id.Text + "'");
            if(getData.Read())
            {
                lbl_item_name.Text = getData["product_full_name"].ToString();
            }

            getData.Close();

        }
    }

    protected void rptbinddataprice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbinddataprice.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            SqlDataReader dr_price_data = mst.Delete_Operation("delete from ecommerce_product_price where id='" + lblrowdeleteid.Text + "'");
            dr_price_data.Close();

            ShowMessage("Delete operation success.", MessageType.Success);

            BindData_Price();
        }
    }
}