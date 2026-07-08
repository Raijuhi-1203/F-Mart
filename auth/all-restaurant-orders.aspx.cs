using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_all_orders : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Order odr = new Order();
    Bulksms_gateway sms = new Bulksms_gateway();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOrder();
        }
    }

    protected void btnsearch_ServerClick(object sender, EventArgs e)
    {
        if (txt_date_from.Text.Length > 0)
        {
            BindOrder_Date();
        }
    }

    private void BindOrder_Date()
    {
        this.rptbindorderdata.DataSource = GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount,Max(customer_mobileno) as customer_mobileno,Max(product_sellername) as product_sellername FROM ecommerce_order where order_section='Restaurant' AND order_date='" + txt_date_from.Text + "' and order_status!='Cancelled' Group by order_id order by id desc");
        this.rptbindorderdata.DataBind();
    }

    private void BindOrder()
    {
         rptbindorderdata.DataSource = GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount,Max(customer_mobileno) as customer_mobileno,Max(product_sellername) as product_sellername FROM ecommerce_order where order_status='Processing' AND order_section='Restaurant' Group by order_id order by id desc");
         rptbindorderdata.DataBind();
    }

    private void BindOrderByStatus()
    {
         rptbindorderdata.DataSource = GetData("SELECT Max(id) as id, Max(order_id) as order_id,Max(order_delivery_time) as order_delivery_time,Max(order_date) as order_date,Max(customer_name) as customer_name,Max(payment_mode) as payment_mode,Max(total_order_amount) as total_order_amount,Max(customer_mobileno) as customer_mobileno,Max(product_sellername) as product_sellername FROM ecommerce_order where order_status='" + dblorderstatus.SelectedValue+ "' AND order_section='Restaurant'  Group by order_id order by id desc");
        rptbindorderdata.DataBind();
    }

    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }

    protected void rptbindorderdata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblroworderid = (Label)rptbindorderdata.Items[e.Item.ItemIndex].FindControl("lblroworderid");

            con.Open();

            string query_delete_order = "delete from ecommerce_order where order_id='" + lblroworderid.Text + "'";
            SqlCommand cmd_delete_order = new SqlCommand(query_delete_order, con);
            SqlDataReader dr_delete_order = cmd_delete_order.ExecuteReader();
            dr_delete_order.Close();

            con.Close();
            ShowMessage("Delete operation success.", MessageType.Success);
            BindOrder();
        }
    }

    protected void rptbindorderdata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblorderid = (Label)e.Item.FindControl("lblorderid");
            Label lblnoofitems = (Label)e.Item.FindControl("lblnoofitems");

            if(dblorderstatus.SelectedItem.Text== "Cancelled")
            {
                lblnoofitems.Text = odr.GetNoOfItemsOrder_cancel(lblorderid.Text);

            }
            else
            {
                lblnoofitems.Text = odr.GetNoOfItemsOrder(lblorderid.Text);

            }

        }
    }

    protected void dblorderstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindOrderByStatus();
    }
}