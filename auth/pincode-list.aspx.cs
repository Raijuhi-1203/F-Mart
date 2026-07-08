using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_pincode_list : System.Web.UI.Page
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
            BindData();
        }
    }

    private void BindData()
    {
        rpt_data.DataSource = mst.GetData("SELECT pincode,area FROM ecommerce_pincode where city_name='" + Request.QueryString[0] + "' order by pincode asc");
        rpt_data.DataBind();
    }

    protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rpt_data.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            SqlDataReader delete_pincode = mst.Delete_Operation("delete from ecommerce_pincode where pincode='" + lblrowdeleteid.Text + "'");
            delete_pincode.Close();

            ShowMessage("Data has been deleted.", MessageType.Error);

            BindData();
        }
    }

}