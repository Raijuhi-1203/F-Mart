using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_business_with_us : System.Web.UI.Page
{
    Master mst = new Master();
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {
        rptbindbusinesswithus.DataSource = mst.GetData("SELECT * FROM ecommerce_enquiry");
         rptbindbusinesswithus.DataBind();
    }
    protected void rptbindbusinesswithus_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbindbusinesswithus.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");
            SqlDataReader dr_delete = mst.Delete_Operation("delete from ecommerce_enquiry where id='" + lblrowdeleteid.Text + "'");
            dr_delete.Close();
            ShowMessage("Delete operation successful.", MessageType.Success);
            BindData();
        }

    }
}