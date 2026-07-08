using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class auth_product_seo : System.Web.UI.Page
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
            if (Request.QueryString[1] == "new")
            {
                SqlDataReader get_data = mst.Select_Operation("Select product_full_name from ecommerce_product where product_id='" + Request.QueryString[0] + "' ");
                if (get_data.Read())
                {
                    txt_meta_description.Text = get_data["product_full_name"].ToString();
                    txt_meta_keyword.Text = get_data["product_full_name"].ToString();
                    txt_meta_title.Text = get_data["product_full_name"].ToString();
                }

                get_data.Close();

                btnskip.Visible = true;
            }
            else
            {
                SqlDataReader get_data = mst.Select_Operation("Select meta_title,meta_description,meta_keyword from ecommerce_product where product_id='" + Request.QueryString[0] + "' ");
                if (get_data.Read())
                {
                    txt_meta_description.Text = get_data["meta_description"].ToString();
                    txt_meta_keyword.Text = get_data["meta_keyword"].ToString();
                    txt_meta_title.Text = get_data["meta_title"].ToString();
                }

                get_data.Close();


                btnsave.InnerText = "Save Change";
                btnskip.Visible = false;
            }
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txt_meta_description.Text.Length>0 && txt_meta_keyword.Text.Length>0 && txt_meta_title.Text.Length>0)
            {
                int success = bnc.Edit_Product_Seo(txt_meta_title.Text,txt_meta_description.Text,txt_meta_keyword.Text,Request.QueryString[0]);

                if(success>0)
                {
                    if (Request.QueryString[1] == "new")
                    {
                        ShowMessage("Seo has been updated.", MessageType.Success);

                        Response.AppendHeader("Refresh", "1;url=add-product-price.aspx?ref=" + Request.QueryString[0]);
                    }
                    else
                    {
                        ShowMessage("Seo has been updated.", MessageType.Success);
                    }
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

    protected void btnskip_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("add-product-price.aspx?ref=" + Request.QueryString[0]);
    }


}