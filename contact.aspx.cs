using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
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

        }
    }

    protected override void OnLoad(EventArgs e)
    {
        Page.Title = "Contact Furniture’s Mart | We're Here to Help";
        Page.MetaDescription = "Get in touch with Furniture’s Mart for customer support, product info, or general inquiries. We’re just a\r\nmessage or call away—reach out today!";
        base.OnLoad(e);
    }

    protected void btnsend_ServerClick(object sender, EventArgs e)
    {
        if (name.Text.Length > 0 && email.Text.Length > 0 && phone.Text.Length > 0 && message.Text.Length > 0)
        {
            int success = mst.Insert_Enquiry(name.Text, email.Text, phone.Text, message.Text, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm tt"));

            if (success > 0)
            {
                ShowMessage("Message Send.", MessageType.Success);
                Response.Write("<script>alert('Message Send.');</script>");
                name.Text = string.Empty;
                email.Text = string.Empty;
                phone.Text = string.Empty;
                message.Text = string.Empty;

            }
        }
        else
        {

        }
    }
}