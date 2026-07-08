using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_seller_menu_category : System.Web.UI.Page
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
            Bind_Category();
            Selected_Category();
        }
    }

    private void Bind_Category()
    {
        mst.PopulateCheckbox(chk_category, "category_id", "category_name", "SELECT category_name, category_id FROM ecommerce_category where category_type='Restaurant' ");
    }

    private void Selected_Category()
    {
        SqlDataReader category_dr = mst.Select_Operation("Select category_id from ecommerce_seller_category where seller_id='" + Request.QueryString[0] + "' ");
        while (category_dr.Read())
        {
            ListItem listItem = this.chk_category.Items.FindByValue(category_dr["category_id"].ToString());
            if (listItem != null) listItem.Selected = true;
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int totalChecked = chk_category.Items.Cast<ListItem>().Count(li => li.Selected);

            if (totalChecked > 0)
            {
                int success = 0;
                // Delete Old Category

                SqlDataReader delete_category = mst.Delete_Operation("Delete from ecommerce_seller_category Where seller_id='" + Request.QueryString[0] + "' ");
                delete_category.Close();

                for (int i = 0; i < chk_category.Items.Count; i++)
                {
                    if (chk_category.Items[i].Selected == true)
                    {
                         success = bnc.Add_Restaurant_Menu_Category(Request.QueryString[0], chk_category.Items[i].Value, chk_category.Items[i].Text);

                    }
                }

                if (success > 0)
                {
                    ShowMessage("Restaurant menu category has been saved.", MessageType.Success);
                }
            }
            else
            {
                ShowMessage("Please choose categories.", MessageType.Error);
            }


        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }
}