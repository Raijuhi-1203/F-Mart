using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_order_cancel_request : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        this.rptbindorderdata.DataSource = GetData("SELECT * FROM ecommerce_order where (order_status='Return Request' OR order_status='Cancelled Request') AND order_section='Grocery' order by id desc");
        this.rptbindorderdata.DataBind();
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


    //protected void rptbindorderdata_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if (e.CommandName.Equals("btndelete"))
    //    {
    //        Label lblrowsuborderid = (Label)rptbindorderdata.Items[e.Item.ItemIndex].FindControl("lblrowsuborderid");

    //        con.Open();

    //        string query_delete_order = "delete from ecommerce_order where sub_order_id='" + lblrowsuborderid.Text + "'";
    //        SqlCommand cmd_delete_order = new SqlCommand(query_delete_order, con);
    //        SqlDataReader dr_delete_order = cmd_delete_order.ExecuteReader();
    //        dr_delete_order.Close();

    //        con.Close();
    //        ShowMessage("Delete operation success.", MessageType.Success);
    //        BindData();
    //    }
    //}
}