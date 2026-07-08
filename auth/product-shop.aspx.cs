using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class auth_product_shop : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    BackendExt bnc = new BackendExt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mst.PopulateCheckbox(chkproduct, "product_id", "product_full_name", "Select product_id,product_full_name from ecommerce_product Where product_type='Grocery' Order By product_id desc ");
            BindData();
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT * FROM product_shop order by id asc");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            SqlDataReader delete_data = mst.Delete_Operation("delete from product_shop where id='" + lblrowdeleteid.Text + "'");
            delete_data.Close();

            ShowMessage("Data has been deleted.", MessageType.Success);

            BindData();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txt_shop_name.Text.Length>0)
            {
                int saveData = 0;

                int totalChecked = chkproduct.Items.Cast<ListItem>().Count(li => li.Selected);

                if(totalChecked > 0)
                {
                    for (int i = 0; i < chkproduct.Items.Count; i++)
                    {
                        if (chkproduct.Items[i].Selected == true)
                        {
                            int checkItemForShop = mst.Count_data("Select Count(id) from product_shop Where product_id='" + chkproduct.Items[i].Value + "' AND shop_name='" + txt_shop_name.Text + "' ");
                           
                            if (checkItemForShop < 1)
                            {
                                saveData = bnc.Add_Product_Shop(txt_shop_name.Text, chkproduct.Items[i].Value, chkproduct.Items[i].Text, DateTime.Now.ToString("yyyy-MM-dd"));

                            }

                        }
                    }
                }
                else
                {
                    ShowMessage("All field are required.", MessageType.Error);
                }


                if (saveData>0)
                {
                    ShowMessage("Data has been saved.",MessageType.Success);
                   
                    txt_shop_name.Text = string.Empty;

                    BindData();
                }
            }
            else
            {
                ShowMessage("All field are required.",MessageType.Error);
            }

        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }
}