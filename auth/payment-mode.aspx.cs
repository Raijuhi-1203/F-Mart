using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_payment_mode : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Backend bnc = new Backend();


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        rptbindgstdata.DataSource = mst.GetData("SELECT * FROM ecommerce_payment_mode");
        rptbindgstdata.DataBind();
    }

    protected void rptbindgstdata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btnenable"))
        {
            int success = bnc.Update_Payment_Mode_Status("Yes",e.CommandArgument.ToString());

            if(success>0)
            {
                ShowMessage("Payment mode has been enabled.",MessageType.Success);

                BindData();
            }
        }


        if (e.CommandName.Equals("btndisable"))
        {
            int success = bnc.Update_Payment_Mode_Status("No", e.CommandArgument.ToString());

            if (success > 0)
            {
                ShowMessage("Payment mode has been disabled.", MessageType.Success);

                BindData();
            }
        }
    }
}