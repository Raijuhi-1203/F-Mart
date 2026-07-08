using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class auth_edit_product_shop : System.Web.UI.Page
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
            Selected_Product();

            SqlDataReader getData = mst.Select_Operation("Select shop_name from product_shop Where shop_name='" + Request.QueryString[0] +"'");
            if(getData.Read())
            {
                txt_shop_name.Text = getData["shop_name"].ToString();
            }

            getData.Close();

        }
    }

    private void Selected_Product()
    {
        SqlDataReader getData = mst.Select_Operation("Select product_id from product_shop Where shop_name='" + Request.QueryString[0] +"' ");
        while (getData.Read())
        {
            ListItem listItem = this.chkproduct.Items.FindByValue(getData["product_id"].ToString());
            if (listItem != null) listItem.Selected = true;
        }
       
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txt_shop_name.Text.Length > 0)
            {
                int saveData = 0;

                int totalChecked = chkproduct.Items.Cast<ListItem>().Count(li => li.Selected);

                if (totalChecked > 0)
                {
                    // Delete Old

                    SqlDataReader delete_old = mst.Select_Operation("Delete from product_shop Where shop_name='" + txt_shop_name.Text +"' ");
                    delete_old.Close();

                    for (int i = 0; i < chkproduct.Items.Count; i++)
                    {
                        if (chkproduct.Items[i].Selected == true)
                        {
                            int checkItemForShop = mst.Count_data("Select Count(id) from product_shop Where product_id='" + chkproduct.Items[i].Value + "' AND shop_name='" + txt_shop_name.Text + "' ");

                            if(checkItemForShop<1)
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


                if (saveData > 0)
                {
                    ShowMessage("Data has been saved.", MessageType.Success);

                }
            }
            else
            {
                ShowMessage("All field are required.", MessageType.Error);
            }

        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }


    protected void btnsaveChange_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txt_shop_name.Text.Length>0)
            {
                int saveData = bnc.Edit_Product_Shop_Name(txt_shop_name.Text, Request.QueryString[0]);

                if(saveData>0)
                {
                    ShowMessage("Data has been updated.",MessageType.Success);
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
}