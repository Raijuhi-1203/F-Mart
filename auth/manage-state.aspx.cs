using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_state : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        rpt_data.DataSource = mst.GetData("SELECT * FROM ecommerce_state  order by state_name asc");
        rpt_data.DataBind();
    }

    protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lbl_state_name = (Label)rpt_data.Items[e.Item.ItemIndex].FindControl("lbl_state_name");
            Label lbl_state_id = (Label)rpt_data.Items[e.Item.ItemIndex].FindControl("lbl_state_id");

            SqlDataReader delete_state = mst.Delete_Operation("delete from ecommerce_state where state_id='" + lbl_state_id.Text + "'");
            delete_state.Close();

            SqlDataReader delete_city = mst.Delete_Operation("delete from ecommerce_city where state_id='" + lbl_state_id.Text + "'");
            delete_city.Close();

            SqlDataReader delete_pincode = mst.Delete_Operation("delete from ecommerce_pincode where state_name='" + lbl_state_name.Text + "'");
            delete_pincode.Close();

            ShowMessage("Data has been deleted.",MessageType.Success);

            BindData();
        }
    }
}