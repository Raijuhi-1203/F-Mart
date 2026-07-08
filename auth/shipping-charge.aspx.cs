using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class auth_shipping_charge : System.Web.UI.Page
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
            SqlDataReader get_data = mst.Select_Operation("SELECT * FROM ecommerce_shipping");
            if (get_data.Read())
            {
                txt_grocery_shipping.Text = get_data["shipping_charge"].ToString();
              //  txt_restaurant_shipping.Text = get_data["restaurant_shipping_charge"].ToString();
                
                btnsave.Visible = false;
                btnupdate.Visible = true;
            }
            else
            {
                btnupdate.Visible = false;
            }

            get_data.Read();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txt_grocery_shipping.Text.Length > 0)
        {
            try
            {
               
                int success = bnc.Add_Shipping_Charge(txt_grocery_shipping.Text,"0.0");
                if (success > 0)
                {
                    ShowMessage("Shipping Charge has been saved.", MessageType.Success);

                    btnsave.Visible = false;
                    btnupdate.Visible = true;
                }

              
            }
            catch (SqlException ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
           
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }

    protected void btnupdate_ServerClick(object sender, EventArgs e)
    {
        if (txt_grocery_shipping.Text.Length > 0)
        {
            int success = bnc.Edit_Shipping_Charge(txt_grocery_shipping.Text,"0.0");
            
            if (success > 0)
            {
                ShowMessage("Shipping Charge has been updated.", MessageType.Success);
            }

        }
        else
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }
}