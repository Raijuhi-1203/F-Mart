using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_brand : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Backend bnc = new Backend();
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
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_brand");
        rptbinddata.DataBind();
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txt_brand.Text.Length>0)
            {
                int count = mst.Count_data("Select Count(brand_name) from ecommerce_brand where brand_name='"+txt_brand.Text+"' ");

                if(count>0)
                {
                    ShowMessage("Brand name already in database.",MessageType.Error);
                }
                else
                {
                    int success = bnc.Add_Brand(txt_brand.Text,"0");

                    if(success>0)
                    {
                        ShowMessage("Brand has been saved.",MessageType.Success);

                        txt_brand.Text = string.Empty;
                        txt_brand.Focus();
                        BindData();
                    }
                }
            }
            else
            {
                ShowMessage("Brand name is required.",MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            SqlDataReader delete_data = mst.Delete_Operation("delete from ecommerce_brand where id='" + lblrowdeleteid.Text + "'");
            delete_data.Close();

            ShowMessage("Data has been deleted.", MessageType.Success);

            BindData();
        }


        if (e.CommandName.Equals("btneditbrand"))
        {
            Label lbl_edit_row_id = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbl_edit_row_id");
            TextBox txt_edit_brand = (TextBox)rptbinddata.Items[e.Item.ItemIndex].FindControl("txt_edit_brand");

            try
            {
                if (txt_edit_brand.Text.Length > 0)
                {
                    int count = mst.Count_data("Select Count(brand_name) from ecommerce_brand where brand_name='" + txt_edit_brand.Text + "' ");

                    if (count > 0)
                    {
                        ShowMessage("Brand name already in database.", MessageType.Error);
                    }
                    else
                    {
                        int success = bnc.Edit_Brand(txt_edit_brand.Text, "0", lbl_edit_row_id.Text);

                        if (success > 0)
                        {
                            ShowMessage("Data has been updated.", MessageType.Success);

                            BindData();

                        }
                    }
                }
                else
                {
                    ShowMessage("Brand name is required.", MessageType.Error);
                }
            }
            catch (SqlException ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
           
        }
    }
}