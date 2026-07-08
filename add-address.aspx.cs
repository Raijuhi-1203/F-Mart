using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add_address : System.Web.UI.Page
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
        if (Session["customer_id"] != null)
        {
            
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btnsend_ServerClick(object sender, EventArgs e)
    {
        if (name.Text.Length > 0 && email.Text.Length > 0 && phone.Text.Length > 0 && address1.Text.Length > 0 && address2.Text.Length > 0 && state.Text.Length > 0 && city.Text.Length > 0 && pincode.Text.Length > 0)
        {
            int success = mst.Add_Address(Session["customer_id"].ToString(),name.Text, email.Text, phone.Text, address1.Text, address2.Text, state.Text, city.Text, pincode.Text);

            if (success > 0)
            {
                ShowMessage("Address added.", MessageType.Success);
                Response.Write("<script>alert('Address added.');</script>");
                name.Text = string.Empty;
                email.Text = string.Empty;
                phone.Text = string.Empty;
                address1.Text = string.Empty;
                address2.Text = string.Empty;
                state.Text = string.Empty;
                city.Text = string.Empty;
                pincode.Text = string.Empty;

            }
        }
        else
        {

        }
    }

}