using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_custom_section : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
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

    private void BindData()
    {
        rptbind.DataSource = mst.GetData("SELECT * FROM ecommerce_custom_section order by id asc");
        rptbind.DataBind();
    }

    protected void rptbind_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbind.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            SqlDataReader delete_row = mst.Delete_Operation("delete from ecommerce_custom_section where id='"+lblrowdeleteid.Text+"' ");
            delete_row.Close();

            SqlDataReader delete_section_product = mst.Delete_Operation("delete from ecommerce_section_product where section_id='"+lblrowdeleteid.Text+"' ");
            delete_section_product.Close();

            ShowMessage("Delete operation has been success.",MessageType.Success);

            BindData();
        }


        if (e.CommandName.Equals("btnupdate"))
        {
            Label lblroweditid = (Label)rptbind.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            TextBox txteditsectionaname = (TextBox)rptbind.Items[e.Item.ItemIndex].FindControl("txteditsectionaname");
            TextBox txteditdescription = (TextBox)rptbind.Items[e.Item.ItemIndex].FindControl("txteditdescription");
            TextBox txt_edit_priority = (TextBox)rptbind.Items[e.Item.ItemIndex].FindControl("txt_edit_priority");

            DropDownList dbl_edit_publish = (DropDownList)rptbind.Items[e.Item.ItemIndex].FindControl("dbl_edit_publish");

            if (txteditsectionaname.Text.Length > 0 && txt_edit_priority.Text.Length > 0)
            {
                int success = bnc.Update_Custom_Section(txteditsectionaname.Text, txteditdescription.Text, txt_edit_priority.Text, dbl_edit_publish.SelectedValue, lblroweditid.Text);

                if (success > 0)
                {
                    ShowMessage("Data has been updated.", MessageType.Success);

                    BindData();
                }
            }
            else
            {
                ShowMessage("All * field are required.", MessageType.Success);
            }

               

        }


    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txtsectionaname.Text.Length>0 && txt_priority.Text.Length>0)
            {
                int max_5_section = mst.Count_data("Select Count(*) from ecommerce_custom_section");

                if(max_5_section<4)
                {
                    int success = bnc.Add_Custom_Section(txtsectionaname.Text, txtdescription.Text,txt_priority.Text,dbl_publish.SelectedValue);
                    if (success > 0)
                    {
                        ShowMessage("Custom Section has been created.", MessageType.Success);

                        txtdescription.Text = string.Empty;
                        txtsectionaname.Text = string.Empty;

                        BindData();
                    }
                }
                else
                {
                    ShowMessage("Maximum three custom section is allow.",MessageType.Error);
                }
            }
            else
            {
                ShowMessage("All * field are required.",MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }

    protected void rptbind_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl_section_status = (Label)e.Item.FindControl("lbl_section_status");
            DropDownList dbl_edit_publish = (DropDownList)e.Item.FindControl("dbl_edit_publish");

            dbl_edit_publish.SelectedValue = lbl_section_status.Text;

        }
    }
}