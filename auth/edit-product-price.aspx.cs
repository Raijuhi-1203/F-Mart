using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_edit_product_price : System.Web.UI.Page
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
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);

        if (!IsPostBack)
        {
            BindUnit();
            BindGST();

            // Get Price & Stock information

           
            SqlDataReader dr_get_data = mst.Select_Operation("select * from ecommerce_product_price where id='" + Request.QueryString[0] + "' ");
            if (dr_get_data.Read())
            {
                txtdiscountpercentage.Text = dr_get_data["product_discount_percentage"].ToString();
                txtdisvalue.Text = dr_get_data["product_discount_price"].ToString();
                txtfinalprice.Text = dr_get_data["product_final_sell_price"].ToString();
                txtmarketprice.Text = dr_get_data["product_market_price"].ToString();
                txtsellprice.Text = dr_get_data["product_sell_price"].ToString();
                txtshippingcharge.Text = dr_get_data["product_shipping_charge"].ToString();
                txtstock.Text = dr_get_data["product_stock"].ToString();
                txtunitvalue.Text = dr_get_data["product_unit_value"].ToString();

                dblgstpercentage.SelectedValue = dr_get_data["product_GST_percentage"].ToString();
                dblgsttype.SelectedValue = dr_get_data["product_GST_type"].ToString();
                dbltaxtype.SelectedValue = dr_get_data["product_tax_type"].ToString();
                dblunit.SelectedValue = dr_get_data["product_unit"].ToString();

                txt_shop_price.Text = dr_get_data["original_price"].ToString();
            }

            dr_get_data.Close();
        }
    }


    private void BindUnit()
    {
        dblunit.Items.Clear();
        dblunit.Items.Add(new ListItem("Please Select", ""));
        dblunit.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [unit_name] FROM [ecommerce_unit]";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblunit.DataSource = cmd.ExecuteReader();
            dblunit.DataTextField = "unit_name";
            dblunit.DataValueField = "unit_name";
            dblunit.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    private void BindGST()
    {
        dblgstpercentage.Items.Clear();
        dblgstpercentage.Items.Add(new ListItem("Please Select", ""));
        dblgstpercentage.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [gst_value] FROM [ecommerce_gst]";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblgstpercentage.DataSource = cmd.ExecuteReader();
            dblgstpercentage.DataTextField = "gst_value";
            dblgstpercentage.DataValueField = "gst_value";
            dblgstpercentage.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    protected void txtdiscountpercentage_TextChanged(object sender, EventArgs e)
    {
        if (dblgstpercentage.SelectedItem.Text != "Please Select")
        {
            if (txtmarketprice.Text.Length > 0 && txtdiscountpercentage.Text.Length > 0)
            {
                txtdisvalue.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);

                txtsellprice.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);


                if (dbltaxtype.SelectedValue == "Exclusive")
                {
                    if (dblgstpercentage.SelectedItem.Text != "Please Select")
                    {
                        txtfinalprice.Text = Convert.ToString(Convert.ToDecimal(txtsellprice.Text) + Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100);
                    }
                    else
                    {
                        ShowMessage("Please select GST.", MessageType.Error);
                    }
                }
                else
                {
                    txtfinalprice.Text = txtsellprice.Text;
                }

            }
            else
            {
                ShowMessage("Please type market price and discount.", MessageType.Error);
            }
        }
        else
        {
            if (txtmarketprice.Text.Length > 0 && txtdiscountpercentage.Text.Length > 0)
            {
                txtdisvalue.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);

                txtsellprice.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);
            }
            else
            {
                ShowMessage("Please type market price and discount.", MessageType.Error);
            }
        }
    }

    protected void txtmarketprice_TextChanged(object sender, EventArgs e)
    {
        if (dblgstpercentage.SelectedItem.Text != "Please Select")
        {
            if (txtmarketprice.Text.Length > 0 && txtdiscountpercentage.Text.Length > 0)
            {
                txtdisvalue.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);

                txtsellprice.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);


                if (dbltaxtype.SelectedValue == "Exclusive")
                {
                    if (dblgstpercentage.SelectedItem.Text != "Please Select")
                    {
                        txtfinalprice.Text = Convert.ToString(Convert.ToDecimal(txtsellprice.Text) + Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100);
                    }
                    else
                    {
                        ShowMessage("Please select GST.", MessageType.Error);
                    }
                }
                else
                {
                    txtfinalprice.Text = txtsellprice.Text;
                }

            }
            else
            {
                ShowMessage("Please type market price and discount.", MessageType.Error);
            }
        }
        else
        {
            if (txtmarketprice.Text.Length > 0 && txtdiscountpercentage.Text.Length > 0)
            {
                txtdisvalue.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);

                txtsellprice.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);
            }
            else
            {
                ShowMessage("Please type market price and discount.", MessageType.Error);
            }
        }
    }

    protected void dbltaxtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dbltaxtype.SelectedValue == "Exclusive")
        {
            if (dblgstpercentage.SelectedItem.Text != "Please Select")
            {
                txtfinalprice.Text = Convert.ToString(Convert.ToDecimal(txtsellprice.Text) + Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100);
            }
            else
            {
                ShowMessage("Please select GST.", MessageType.Error);
            }
        }
        else
        {
            txtfinalprice.Text = txtsellprice.Text;
        }


    }

    protected void btnno_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("manage-product");
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtdiscountpercentage.Text.Length > 0 && txtdisvalue.Text.Length > 0 && txtfinalprice.Text.Length > 0 && txtmarketprice.Text.Length > 0 && txtsellprice.Text.Length > 0 && txtshippingcharge.Text.Length > 0 && txtstock.Text.Length > 0 && txtunitvalue.Text.Length > 0 && dblunit.SelectedItem.Text != "Please Select" && txt_shop_price.Text.Length>0)
            {
                int success = bnc.Edit_Product_Price(dblunit.SelectedValue, txtunitvalue.Text, dblgsttype.SelectedValue, dblgstpercentage.SelectedValue, Convert.ToString(Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100), Convert.ToString(Convert.ToDecimal(dblgstpercentage.SelectedValue) / 2), Convert.ToString(Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100 / 2), Convert.ToString(Convert.ToDecimal(dblgstpercentage.SelectedValue) / 2), Convert.ToString(Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100 / 2), txtmarketprice.Text, txtsellprice.Text, txtdiscountpercentage.Text, txtdisvalue.Text, txtfinalprice.Text, txtfinalprice.Text, txtstock.Text, dbltaxtype.SelectedValue,txt_shop_price.Text, Request.QueryString[0]);
                if (success > 0)
                {
                    ShowMessage("Price has been updated.",MessageType.Success);
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

    protected void txtsellprice_TextChanged(object sender, EventArgs e)
    {
        if (dblgstpercentage.SelectedItem.Text != "Please Select")
        {
            if (txtmarketprice.Text.Length > 0 && txtsellprice.Text.Length > 0)
            {
                txtdiscountpercentage.Text = Convert.ToString(Convert.ToDecimal(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtsellprice.Text)) / Convert.ToDecimal(txtmarketprice.Text) * 100);
                txtdisvalue.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtsellprice.Text));

                //  txtsellprice.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtmarketprice.Text) * Convert.ToDecimal(txtdiscountpercentage.Text) / 100);

                if (dbltaxtype.SelectedValue == "Exclusive")
                {
                    if (dblgstpercentage.SelectedItem.Text != "Please Select")
                    {
                        txtfinalprice.Text = Convert.ToString(Convert.ToDecimal(txtsellprice.Text) + Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100);
                    }
                    else
                    {
                        ShowMessage("Please select GST.", MessageType.Error);
                    }
                }
                else
                {
                    txtfinalprice.Text = txtsellprice.Text;
                }

            }
            else
            {
                ShowMessage("Please type market price and price.", MessageType.Error);
            }
        }
        else
        {
            if (txtmarketprice.Text.Length > 0 && txtsellprice.Text.Length > 0)
            {
                txtdiscountpercentage.Text = Convert.ToString(Convert.ToDecimal(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtsellprice.Text)) / Convert.ToDecimal(txtmarketprice.Text) * 100);
                txtdisvalue.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtsellprice.Text));
            }
            else
            {
                ShowMessage("Please type market price and Price.", MessageType.Error);
            }
        }
    }
}