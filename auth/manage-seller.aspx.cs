using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_seller : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Backend bnc = new Backend();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
         rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_seller order by id asc");
         rptbinddata.DataBind();
    }


    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btnenable"))
        {
            Label lblrowenableid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowenableid");

            int success = bnc.Update_Seller_Status("Yes", lblrowenableid.Text);

            if (success > 0)
            {
                ShowMessage("Status has been changed.", MessageType.Success);
            }
           
            BindData();

        }

        if (e.CommandName.Equals("btndisable"))
        {
            Label lbldisablerowid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldisablerowid");

            int success = bnc.Update_Seller_Status("No", lbldisablerowid.Text); 

            if (success > 0)
            {
                ShowMessage("Status has been changed.", MessageType.Success);
            }

            BindData();
        }

        if (e.CommandName.Equals("btndelete"))
        {
            Label lbldeletesellerid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldeletesellerid");

            SqlDataReader get_photo = mst.Select_Operation("Select seller_photo from ecommerce_seller where seller_id='" + lbldeletesellerid.Text + "' ");
            if (get_photo.Read())
            {
                var filePath = Server.MapPath(get_photo["seller_photo"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            get_photo.Close();

            SqlDataReader dr_delete_seller = mst.Delete_Operation("delete from ecommerce_seller where seller_id='" + lbldeletesellerid.Text + "'");
            dr_delete_seller.Close();

            SqlDataReader dr_delete_seller_product = mst.Delete_Operation("delete from ecommerce_product where product_seller_id='" + lbldeletesellerid.Text + "'");
            dr_delete_seller_product.Close();

         
            SqlDataReader dr_delete_seller_section_product = mst.Delete_Operation("delete from ecommerce_section_product where seller_id='" + lbldeletesellerid.Text + "'");
            dr_delete_seller_section_product.Close();


            ShowMessage("Delete operation success.", MessageType.Success);

            BindData();
        }
    }

    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl_seller_area_id = (Label)e.Item.FindControl("lbl_seller_area_id");
            Label lbl_area_name = (Label)e.Item.FindControl("lbl_area_name");

            // Get Area Name

            SqlDataReader getData = mst.Select_Operation("Select area from ecommerce_pincode Where id='"+ lbl_seller_area_id.Text + "' ");
            if(getData.Read())
            {
                lbl_area_name.Text = getData["area"].ToString();
            }

            getData.Close();
        }
    }
}