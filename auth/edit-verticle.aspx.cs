using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class auth_edit_verticle : System.Web.UI.Page
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
            BindCategory();

            SqlDataReader get_data = mst.Select_Operation("Select * from ecommerce_verticle where id='"+Request.QueryString[0]+"' ");
            if(get_data.Read())
            {
                dblparentcategory.SelectedValue = get_data["category_id"].ToString();

                BindSubCategory();

                dblsubcategory.SelectedValue = get_data["sub_category_id"].ToString();
                dblstatus.SelectedValue = get_data["verticle_status"].ToString();

                txt_verticle.Text = get_data["verticle_name"].ToString();
                txt_title.Text = get_data["verticle_title"].ToString();
            }

            get_data.Close();
        }
    }


    private void BindCategory()
    {
        dblparentcategory.Items.Clear();
        dblparentcategory.Items.Add(new ListItem("Please Select", "0"));
        dblparentcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where main_category_id=@main_category_id";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@main_category_id", "0");
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

    private void BindSubCategory()
    {
        dblsubcategory.Items.Clear();
        dblsubcategory.Items.Add(new ListItem("None", "0"));
        dblsubcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where main_category_id=@main_category_id";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@main_category_id", dblparentcategory.SelectedValue);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblsubcategory.DataSource = cmd.ExecuteReader();
            dblsubcategory.DataTextField = "category_name";
            dblsubcategory.DataValueField = "category_id";
            dblsubcategory.DataBind();
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
            BindSubCategory();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (dblparentcategory.SelectedItem.Text != "Please Select" && txt_verticle.Text.Length > 0 && txt_title.Text.Length>0)
            {
                int success = bnc.Edit_Verticle(dblparentcategory.SelectedValue, dblsubcategory.SelectedValue, txt_verticle.Text, dblstatus.SelectedValue,txt_title.Text, Request.QueryString[0]);

                int update_product_vertical = bnc.Edit_Product_vertical_name(txt_verticle.Text, Request.QueryString[0]);

                if (success > 0)
                {
                    ShowMessage("Verticle has been updated.", MessageType.Success);
                }
            }
            else
            {
                ShowMessage("All * field are required.", MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

}