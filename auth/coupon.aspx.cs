using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_coupon : System.Web.UI.Page
{
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
        rptbindgstdata.DataSource = mst.GetData("SELECT * FROM ecommerce_coupan order by id desc");
        rptbindgstdata.DataBind();
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtcouponcode.Text.Length > 0 && txtcouponvalue.Text.Length>0 && txt_date.Text.Length>0 && txt_short_description.Text.Length>0 && txt_max_discount.Text.Length>0 && txt_minimum_order.Text.Length>0)
            {
                int success = bnc.Add_Coupon(txtcouponcode.Text, txtcouponvalue.Text, txt_date.Text,txt_short_description.Text,txt_minimum_order.Text,txt_max_discount.Text);

                if (success > 0)
                {
                    ShowMessage("Coupon has been saved.", MessageType.Success);

                    txtcouponvalue.Text = string.Empty;
                    txtcouponcode.Text = string.Empty;
                    txt_max_discount.Text = string.Empty;
                    txt_minimum_order.Text = string.Empty;


                    txtcouponcode.Focus();

                    BindData();
                }
            }
            else
            {
                ShowMessage("All field is required.", MessageType.Error);
            }

        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    protected void rptbindgstdata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");
            SqlDataReader dr_delete = mst.Delete_Operation("delete from ecommerce_coupan where id='" + lblrowdeleteid.Text + "'");
            dr_delete.Close();

            ShowMessage("Delete operation successful.", MessageType.Success);

            BindData();
        }

        if (e.CommandName.Equals("btnsavechange"))
        {
            Label lbl_edit_row_id = (Label)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("lbl_edit_row_id");
      
            TextBox txt_edit_couponcode = (TextBox)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("txt_edit_couponcode");
            TextBox txt_edit_couponvalue = (TextBox)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("txt_edit_couponvalue");
            TextBox txt_edit_date = (TextBox)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("txt_edit_date");
            TextBox txt_edit_short_description = (TextBox)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("txt_edit_short_description");

            TextBox txt_edit_minimum_order = (TextBox)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("txt_edit_minimum_order");
            TextBox txt_edit_max_discount = (TextBox)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("txt_edit_max_discount");

            if (txt_edit_couponcode.Text.Length > 0 && txt_edit_couponvalue.Text.Length > 0 && txt_edit_date.Text.Length > 0 && txt_edit_short_description.Text.Length > 0 && txt_edit_max_discount.Text.Length>0 && txt_edit_minimum_order.Text.Length>0)
            {
                int success = bnc.Edit_Coupon(txt_edit_couponcode.Text, txt_edit_couponvalue.Text, txt_edit_date.Text, txt_edit_short_description.Text,txt_edit_minimum_order.Text,txt_edit_max_discount.Text, lbl_edit_row_id.Text);

                if (success > 0)
                {
                    ShowMessage("Coupon has been updated.", MessageType.Success);

                    BindData();
                }
            }
            else
            {
                ShowMessage("All field is required.", MessageType.Error);
            }


        }

    }
}