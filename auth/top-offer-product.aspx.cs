using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class auth_top_offer_product : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Product pdt = new Product();
    Master mst = new Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);
        if (!IsPostBack)
        {
            BindCategory();
            BindTopOfferproduct();
        }
    }


    private void Product()
    {
        DataSet ds = new DataSet();
        string cmdstr = "SELECT * FROM ecommerce_product where product_seller_id='0' AND (product_parent_category_id='" + dblparentcategory.SelectedValue + "' OR product_sub_category_id='" + dblparentcategory.SelectedValue + "') order by id desc";
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);
        chkproduct.DataSource = ds;
        chkproduct.DataTextField = "product_full_name";
        chkproduct.DataValueField = "product_id";
        chkproduct.DataBind();
        con.Close();
    }

    private void Selected_Product()
    {
        con.Open();
        string subcategory_query = "SELECT * FROM ecommerce_product where product_seller_id='0' AND (product_parent_category_id='" + dblparentcategory.SelectedValue + "' OR product_sub_category_id='" + dblparentcategory.SelectedValue + "') AND offer_product_status='True' ";
        SqlCommand subcategory_cmd = new SqlCommand(subcategory_query, con);
        SqlDataReader subcategory_dr = subcategory_cmd.ExecuteReader();

        while (subcategory_dr.Read())
        {
            ListItem listItem = this.chkproduct.Items.FindByValue(subcategory_dr["product_id"].ToString());
            if (listItem != null) listItem.Selected = true;
        }
        con.Close();
    }

    private void BindCategory()
    {
        dblparentcategory.Items.Clear();
        dblparentcategory.Items.Add(new ListItem("Please Select", "0"));
        dblparentcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] Where main_category_id='0' AND category_type='Grocery' ";
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
    protected void dblparentcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dblparentcategory.SelectedItem.Text != "Please Select")
        {
            Product();
            Selected_Product();
        }
        else
        {
            ShowMessage("Please choose category.", MessageType.Warning);
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        for (int i = 0; i < chkproduct.Items.Count; i++)
        {
            if (chkproduct.Items[i].Selected == true)
            {
                // Change top offer Status true of Selected Product

                int saveTrue = pdt.Update_TopOfferStatus(chkproduct.Items[i].Value, "True");
            }

        }


        for (int j = 0; j < chkproduct.Items.Count; j++)
        {
            if (chkproduct.Items[j].Selected == false)
            {
                // Change Top offer Status false of Selected Product

                int saveFalse = pdt.Update_TopOfferStatus(chkproduct.Items[j].Value, "False");

            }

        }


        ShowMessage("Data has been saved.", MessageType.Success);

        BindTopOfferproduct();
    }


    private void BindTopOfferproduct()
    {
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_product where product_seller_id='0' AND product_type='Grocery' AND offer_product_status='True' order by id asc");
        rptbinddata.DataBind();
    }


    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            // Photo get

            Label lblproductid = (Label)e.Item.FindControl("lblproductid");
            HtmlImage item_photo = (HtmlImage)e.Item.FindControl("item_photo");

            con.Open();

            string get_photo = "select * from ecommerce_product_photos where product_id='" + lblproductid.Text + "' order by id asc ";
            SqlCommand cmd_get_photo = new SqlCommand(get_photo, con);
            SqlDataReader dr_get_photo = cmd_get_photo.ExecuteReader();

            if (dr_get_photo.Read())
            {
                item_photo.Src = dr_get_photo["photo_path"].ToString();
            }

            dr_get_photo.Close();

            con.Close();

        }
    }

}