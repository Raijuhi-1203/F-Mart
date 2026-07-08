using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class auth_gst : System.Web.UI.Page
{
    Backend bnc = new Backend();
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
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_gst");
        rptbinddata.DataBind();
    }


    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txtgst.Text.Length>0)
            {
                int success = bnc.Add_GST(txtgst.Text);

                if(success>0)
                {
                    ShowMessage("GST has been saved.",MessageType.Success);

                    txtgst.Text = string.Empty;

                    BindData();

                }
            }
            else
            {
                ShowMessage("All field are required.",MessageType.Error);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            SqlDataReader delete_data= mst.Delete_Operation("delete from ecommerce_gst where id='" + lblrowdeleteid.Text + "'");
            delete_data.Close();

            ShowMessage("Data has been deleted.", MessageType.Success);

            BindData();
        }
    }
}