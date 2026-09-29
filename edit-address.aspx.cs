using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class edit_address : System.Web.UI.Page
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
            if (Session["customer_id"] != null)
            {
                SqlDataReader dr_data = mst.Select_Operation("select * from ecommerce_customer_address where id='" + Request.QueryString[0] + "'");
                if (dr_data.Read())
                {
                    address1.Text = dr_data["address_line_1"].ToString();
                    address2.Text = dr_data["address_line_2"].ToString();
                    name.Text = dr_data["address_customer_name"].ToString();
                    email.Text = dr_data["address_customer_email"].ToString();
                    phone.Text = dr_data["address_customer_mobileno"].ToString();
                    state.Text= dr_data["address_state_name"].ToString();
                    city.Text= dr_data["address_city_name"].ToString();
                    pincode.Text= dr_data["address_pincode"].ToString();
                }

                dr_data.Close();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        
    }

    protected void btnsend_ServerClick(object sender, EventArgs e)
    {
        if (name.Text.Length > 0 && email.Text.Length > 0 && phone.Text.Length > 0 && address1.Text.Length > 0 && state.Text.Length > 0 && city.Text.Length > 0 && pincode.Text.Length > 0)
        {
            int success = mst.Edit_Address(Request.QueryString[0], name.Text, email.Text, phone.Text, address1.Text, address2.Text, state.Text, city.Text, pincode.Text);

            if (success > 0)
            {
                
                Response.Write("<script>alert('Address updated.');</script>");
                Response.Redirect("account.aspx");
            }
        }
        else
        {

        }
    }

}