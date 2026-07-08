using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_customer_profile : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Customer cmr = new Customer();
    Order odr = new Order();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataReader customer_data = cmr.Customer_Info(Request.QueryString[0]);
            if (customer_data.Read())
            {
                lbl_email.Text = customer_data["customer_email"].ToString();
                lbl_mobileno.Text = customer_data["customer_mobileno"].ToString();
                lbl_customer_name.Text = customer_data["customer_name"].ToString();
                lbl_gender.Text = customer_data["customer_gender"].ToString();

                //if(customer_data["customer_profilephoto"].ToString()!="")
                //{
                //    photo.Src =   customer_data["customer_profilephoto"].ToString();
                //}
                //else
                //{
                //    photo.Src = "upload/profile-photo/avatar.png";
                //}

            }

            customer_data.Close();

            // Get Details

            SqlDataReader get_bank_details = mst.Select_Operation("Select * from ecommerce_bank_account where customer_id='" + Request.QueryString[0] + "' ");
            if (get_bank_details.Read())
            {
                lbl_bank_name.Text = get_bank_details["bank_name"].ToString();
                lbl_bank_account_holder.Text = get_bank_details["bank_ac_holder_name"].ToString();

                lbl_bank_ac_number.Text = get_bank_details["bank_ac_no"].ToString();
                lbl_bank_ifsc.Text = get_bank_details["bank_ifsc"].ToString();

            }

            get_bank_details.Close();

            
            BindAddressData();
            BindOrder();
            Bind_Most_Ordered();
        }
    }

    private void Bind_Most_Ordered()
    {
        rpt_data.DataSource = mst.GetData("SELECT  Max(product_id) as product_id,Max(product_name) as product_name,Max(product_price_id) as product_price_id,Max(product_unit) as product_unit,Max(product_unit_value) as product_unit_value, COUNT(product_price_id) as item_count,SUM(product_qty) as product_qty,SUM(total_amount_of_product) as total_sell_amount FROM ecommerce_order where order_status='Delivered' AND customer_id='" + Request.QueryString[0] + "' group by product_price_id order by item_count desc");
        rpt_data.DataBind();
    }


    private void BindAddressData()
    {
        rpt_customer_address.DataSource = mst.GetData("SELECT * FROM ecommerce_customer_address where customer_id='" + Request.QueryString[0] + "' ");
        rpt_customer_address.DataBind();
    }

    private void BindOrder()
    {
         rptbindorderdata.DataSource = mst.GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(order_status) as order_status,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount,Max(customer_mobileno) as customer_mobileno FROM ecommerce_order where customer_id='" + Request.QueryString[0] + "' Group by order_id order by id desc");
        rptbindorderdata.DataBind();
    }

    protected void rpt_customer_address_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lbl_address_row_id = (Label)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("lbl_address_row_id");

            SqlDataReader delete_address = mst.Delete_Operation("delete from ecommerce_customer_address where id='" + lbl_address_row_id.Text + "' ");
            delete_address.Close();

            ShowMessage("Delete operation successful.",MessageType.Success);

            BindAddressData();
        }


        if (e.CommandName.Equals("lnkupdateaddress"))
        {
            Label lbl_edit_address_row_id = (Label)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("lbl_edit_address_row_id");

            TextBox txtcustomername = (TextBox)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("txtcustomername");
            TextBox txtcustomeremail = (TextBox)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("txtcustomeremail");
            TextBox txtcustomermobileno = (TextBox)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("txtcustomermobileno");
            TextBox txtaddressline1 = (TextBox)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("txtaddressline1");
            TextBox txtaddressline2 = (TextBox)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("txtaddressline2");
           
            TextBox txt_pincode = (TextBox)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("txt_pincode");
            TextBox txtlandmark = (TextBox)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("txtlandmark");

            Label lbl_address_default = (Label)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("lbl_address_default");
            DropDownList dbl_edit_address_state = (DropDownList)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("dbl_edit_address_state");
            DropDownList dbl_edit_address_city = (DropDownList)rpt_customer_address.Items[e.Item.ItemIndex].FindControl("dbl_edit_address_city");

            if (txtcustomername.Text.Length>0 && txtcustomeremail.Text.Length>0 && txtcustomermobileno.Text.Length>0 && txtaddressline1.Text.Length>0 && txtaddressline2.Text.Length>0 && dbl_edit_address_state.SelectedItem.Text != "Please Select" && dbl_edit_address_city.SelectedItem.Text != "Please Select" && txt_pincode.Text.Length>0)
            {
                int success = cmr.Updtae_Address(txtcustomername.Text, txtcustomermobileno.Text, txtcustomeremail.Text, txtaddressline1.Text, txtaddressline2.Text, dbl_edit_address_city.SelectedValue, dbl_edit_address_city.SelectedItem.Text, dbl_edit_address_state.SelectedValue, dbl_edit_address_state.SelectedItem.Text, txt_pincode.Text, txtlandmark.Text, lbl_address_default.Text, lbl_edit_address_row_id.Text);

                if (success>0)
                {
                    ShowMessage("Address has been updated.",MessageType.Success);
                }
            }
            else
            {
                ShowMessage("All * field are required.",MessageType.Error);
            }
            
        }
    }


    protected void rptbindorderdata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblorderid = (Label)e.Item.FindControl("lblorderid");
            Label lblnoofitems = (Label)e.Item.FindControl("lblnoofitems");

            lblnoofitems.Text = odr.GetNoOfItemsOrder(lblorderid.Text);
        }
    }


    protected void rptbindorderdata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblroworderid = (Label)rptbindorderdata.Items[e.Item.ItemIndex].FindControl("lblroworderid");
           
            SqlDataReader dr_delete_order = mst.Delete_Operation("delete from ecommerce_order where order_id='" + lblroworderid.Text + "'");
            dr_delete_order.Close();

            ShowMessage("Delete operation success.", MessageType.Success);
            BindOrder();
        }
    }

    protected void rpt_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl_product_id = (Label)e.Item.FindControl("lbl_product_id");
            Label lbl_product = (Label)e.Item.FindControl("lbl_product");

            Label lbl_qty = (Label)e.Item.FindControl("lbl_qty");
            Label lbl_final_qty = (Label)e.Item.FindControl("lbl_final_qty");
            Label lbl_product_unit_value = (Label)e.Item.FindControl("lbl_product_unit_value");

            SqlDataReader get_data = mst.Select_Operation("Select product_full_name from ecommerce_product where product_id='" + lbl_product_id.Text + "' ");
            if (get_data.Read())
            {
                lbl_product.Text = get_data["product_full_name"].ToString();
            }

            get_data.Close();

            if (IsNumeric(lbl_product_unit_value.Text.Trim()))
            {
                lbl_final_qty.Text = Convert.ToString(Convert.ToInt32(lbl_qty.Text) * Convert.ToInt32(lbl_product_unit_value.Text));
            }
            else
            {
                lbl_final_qty.Text = lbl_qty.Text;
            }
        }
    }


    public bool IsNumeric(String str)
    {
        try
        {
            if (!string.IsNullOrEmpty(str))
            {
                int num;
                if (int.TryParse(str, out num))
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {

        }

        return false;
    }

    protected void rpt_customer_address_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
           
        }
    }
}