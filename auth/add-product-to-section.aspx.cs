using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class auth_add_product_to_section : System.Web.UI.Page
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
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);
        if (!IsPostBack)
        {
            BindCategory();
            BindSection();
            deal_div.Visible = false;
        }
    }

    private void BindCategory()
    {
        dblparentcategory.Items.Clear();
        dblparentcategory.Items.Add(new ListItem("Please Select", "0"));
        dblparentcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] Where category_type='Grocery'";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblparentcategory.DataSource = cmd.ExecuteReader();
            dblparentcategory.DataTextField = "category_name";
            dblparentcategory.DataValueField = "category_id";
            dblparentcategory.DataBind();
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

    private void BindSection()
    {
        dblsection.Items.Clear();
        dblsection.Items.Add(new ListItem("Please Select", " "));
       // dblsection.Items.Add(new ListItem("Deal of the day", "D0"));
        dblsection.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT id, section_name FROM ecommerce_custom_section";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblsection.DataSource = cmd.ExecuteReader();
            dblsection.DataTextField = "section_name";
            dblsection.DataValueField = "id";
            dblsection.DataBind();
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

    private void Product()
    {
        DataSet ds = new DataSet();
        string cmdstr = "SELECT * FROM ecommerce_product where product_seller_id='0' AND product_type='Grocery' AND (product_parent_category_id='" + dblparentcategory.SelectedValue + "' OR product_sub_category_id='" + dblparentcategory.SelectedValue + "') order by id desc";
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);
        chkproduct.DataSource = ds;
        chkproduct.DataTextField = "product_full_name";
        chkproduct.DataValueField = "product_id";
        chkproduct.DataBind();
        con.Close();
    }


    protected void dblparentcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dblparentcategory.SelectedItem.Text != "Please Select")
        {
            Product();
        }
        else
        {
            ShowMessage("Please choose category.", MessageType.Warning);
        }
    }


    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        int count = 0;

        int success = 0;

        for (int i = 0; i < chkproduct.Items.Count; i++)
        {
            if (chkproduct.Items[i].Selected == true)
            {
                count++;

                if(dblsection.SelectedValue=="D0")
                {
                    if(txt_deal_date.Text.Length>0)
                    {
                        success = bnc.Add_Product_To_Deal_Section(dblsection.SelectedValue, chkproduct.Items[i].Value,txt_deal_date.Text, "1");

                    }
                    else
                    {
                        success = 0;
                    }

                }
                else
                {
                    int check = mst.Count_data("Select Count(id) from ecommerce_section_product where product_id='"+ chkproduct.Items[i].Value + "' AND section_id='"+ dblsection.SelectedValue + "' AND seller_id='1' ");

                    if(check>0)
                    {
                        // No Add
                    }
                    else
                    {
                        success = bnc.Add_Product_To_Custom_Section(dblsection.SelectedValue, chkproduct.Items[i].Value, "1");

                    }
                }

            }

        }

        if (success > 0)
        {
            ShowMessage("Item has been added.", MessageType.Success);

            Product();
        }


        if (count < 0)
        {
            ShowMessage("Please Select Checkbox. Or Section", MessageType.Error);
        }
       
    }

    protected void dblsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dblsection.SelectedItem.Text!= "Please Select")
        {
            if(dblsection.SelectedValue=="D0")
            {
                deal_div.Visible = true;
            }
            else
            {
                deal_div.Visible = false;
            }
        }
        else
        {
            ShowMessage("Please select section.",MessageType.Error);
        }
    }
}