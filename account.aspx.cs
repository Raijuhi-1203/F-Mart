using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class account : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Encrypt enc = new Encrypt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customer_id"] != null)
        {
            BindData();
            BindData2();
            BindData3();
            
            int orderct = mst.Count_data("SELECT count(*) FROM ecommerce_order where customer_id='"+ Session["customer_id"].ToString() + "'");
            ordercount.InnerText = orderct.ToString();
            
            int wishct = mst.Count_data("SELECT count(*) FROM ecommerce_wishlist where customer_id='" + Session["customer_id"].ToString() + "'");
            wishlistcount.InnerText = wishct.ToString();

            username.InnerText = Session["customer_name"].ToString();

            SqlDataReader dr_data = mst.Select_Operation("select * from ecommerce_customer where customer_id='" + Session["customer_id"].ToString() + "'");
            if (dr_data.Read())
            {
                currentPassword.Text = enc.Decrypted(dr_data["customer_password"].ToString());
                name.Text = dr_data["customer_name"].ToString();
                email.Text = dr_data["customer_email"].ToString();
                phone.Text = dr_data["customer_mobileno"].ToString();
            }

            dr_data.Close();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT *,(SELECT count(*) FROM ecommerce_order where customer_id='" + Session["customer_id"].ToString() + "') as total_item FROM ecommerce_order where customer_id='" + Session["customer_id"].ToString() + "'");
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
    
    private void BindData2()
    {
        Repeater1.DataSource = mst.GetData("select a.*,b.*,c.*,d.* from ecommerce_wishlist a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id left join ecommerce_product as d on a.product_id=d.product_id where a.customer_id='" + Session["customer_id"].ToString() + "'");
        Repeater1.DataBind();

        if (Repeater1.Items.Count == 0)
        {
            Panel1.Visible = true;
        }
        else
        {
            Panel1.Visible = false;
        }

    }

    private void BindData3()
    {
        Repeater2.DataSource = mst.GetData("select a.* from ecommerce_customer_address a where a.customer_id='" + Session["customer_id"].ToString() + "'");
        Repeater2.DataBind();

        if (Repeater2.Items.Count == 0)
        {
            Panel2.Visible = true;
        }
        else
        {
            Panel2.Visible = false;
        }

    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }

    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void btnaddress_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("add-address.aspx");
    }

    protected void btnprofileupdate_ServerClick(object sender, EventArgs e)
    {
        if (name.Text.Length > 0 && email.Text.Length > 0 && phone.Text.Length > 0)
        {
            int success = mst.Update_Profile(Session["customer_id"].ToString(), name.Text, email.Text, phone.Text);

            if (success > 0)
            {
                
                Response.Write("<script>alert('Profile has been updated.');</script>");
                name.Text = string.Empty;
                email.Text = string.Empty;
                phone.Text = string.Empty;

            }
        }
        else
        {

        }
    }

    protected void btnupdatepassword_ServerClick(object sender, EventArgs e)
    {
        if (currentPassword.Text.Length > 0 && newPassword.Text.Length > 0 && confirmPassword.Text.Length > 0)
        {
            int success = mst.Update_Password(Session["customer_id"].ToString(), currentPassword.Text, newPassword.Text, confirmPassword.Text);

            if (success > 0)
            {
                Response.Write("<script>alert('Password has been updated.');</script>");
                currentPassword.Text = string.Empty;
                newPassword.Text = string.Empty;
                confirmPassword.Text = string.Empty;
            }
        }
        else
        {

        }
    }



    protected void btndelete_ServerClick(object sender, EventArgs e)
    {
        int success = mst.Delete_Account(Session["customer_id"].ToString());

        if (success > 0)
        {
            Response.Write("<script>alert('Account has been permanantly deleted.');</script>");
            Response.Redirect("logout.aspx");
        }
    }
}