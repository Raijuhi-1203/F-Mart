using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_product_price : System.Web.UI.Page
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

        if(!IsPostBack)
        {
            BindUnit();
            BindGST();
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
        if(dblgstpercentage.SelectedItem.Text!="Please Select")
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
        if(dbltaxtype.SelectedValue== "Exclusive")
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
        Response.Redirect("manage-product.aspx");
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txtdiscountpercentage.Text.Length>0 && txtdisvalue.Text.Length>0 && txtfinalprice.Text.Length>0 && txtmarketprice.Text.Length>0 && txtsellprice.Text.Length>0 && txtshippingcharge.Text.Length>0 && txtstock.Text.Length>0 && txtunitvalue.Text.Length>0 && dbltaxtype.SelectedItem.Text!= "Please Select" && dblunit.SelectedItem.Text!= "Please Select" && txt_shop_price.Text.Length>0)
            {
                int success = bnc.Add_Product_Price(Request.QueryString[0], dblunit.SelectedValue, txtunitvalue.Text, dblgsttype.SelectedValue, dblgstpercentage.SelectedValue,Convert.ToString(Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100),Convert.ToString(Convert.ToDecimal(dblgstpercentage.SelectedValue) / 2),Convert.ToString(Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100 / 2),Convert.ToString(Convert.ToDecimal(dblgstpercentage.SelectedValue) / 2),Convert.ToString(Convert.ToDecimal(txtsellprice.Text) * Convert.ToDecimal(dblgstpercentage.SelectedValue) / 100 / 2), txtmarketprice.Text,txtsellprice.Text,txtdiscountpercentage.Text,txtdisvalue.Text, txtfinalprice.Text, txtfinalprice.Text,"0",txtstock.Text,dbltaxtype.SelectedValue, txt_shop_price.Text);

                if(success>0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "<script>Rs. ('#confirm').modal('show');</script>", false);

                    txtdiscountpercentage.Text = "0";
                    txtdisvalue.Text = "0";

                    txtfinalprice.Text = string.Empty;
                    txtmarketprice.Text = string.Empty;
                    txtsellprice.Text = "0";
                    txtshippingcharge.Text = "0";
                    txtstock.Text = "5000";
                    txtunitvalue.Text = string.Empty;
                    txt_shop_price.Text = "0";

                    BindGST();
                    BindUnit();
                }
                else
                {
                    ShowMessage("Problem in internet connectivity.", MessageType.Error);
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
                txtdiscountpercentage.Text = Convert.ToString(Convert.ToDecimal(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtsellprice.Text))/ Convert.ToDecimal(txtmarketprice.Text)*100);

                txtdisvalue.Text = Convert.ToString(Convert.ToDecimal(txtmarketprice.Text) - Convert.ToDecimal(txtsellprice.Text));
            }
            else
            {
                ShowMessage("Please type market price and Price.", MessageType.Error);
            }
        }
    }

}