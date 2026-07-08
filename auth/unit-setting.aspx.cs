using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_unit_setting : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int success = bnc.Add_Unit(txtunitname.Text);

            if (success > 0)
            {
                ShowMessage("Unit details has been saved.", MessageType.Success);
                txtunitname.Text = string.Empty;
                BindData();
            }

        }
        catch (SqlException ex)
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }


    private void BindData()
    {
         rptbindgstdata.DataSource = mst.GetData("SELECT * FROM ecommerce_unit");
         rptbindgstdata.DataBind();
    }


    protected void rptbindgstdata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

           
            SqlDataReader dr_delete = mst.Delete_Operation("delete from ecommerce_unit where id='" + lblrowdeleteid.Text + "'");
            dr_delete.Close();

            ShowMessage("Delete operation successful.", MessageType.Success);

            BindData();
        }


        if (e.CommandName.Equals("btnupdate"))
        {
            Label lblroweditid = (Label)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("lblroweditid");

            TextBox txteditunitname = (TextBox)rptbindgstdata.Items[e.Item.ItemIndex].FindControl("txteditunitname");

            int success = bnc.Edit_Unit(txteditunitname.Text, lblroweditid.Text);

            if(success>0)
            {
                ShowMessage("Update operation successful.", MessageType.Success);

                BindData();
            }
           
        }
    }
}