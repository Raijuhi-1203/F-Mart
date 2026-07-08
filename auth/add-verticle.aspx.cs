using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_verticle : System.Web.UI.Page
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
        if(dblparentcategory.SelectedItem.Text!="Please Select")
        {
            BindSubCategory();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(dblparentcategory.SelectedItem.Text!="Please Select" && txt_verticle.Text.Length>0 && txt_title.Text.Length>0)
            {
                int success = bnc.Add_Verticle(dblparentcategory.SelectedValue,dblsubcategory.SelectedValue,txt_verticle.Text,dblstatus.SelectedValue,"0",txt_title.Text);

                if(success>0)
                {
                    ShowMessage("Verticle has been saved.",MessageType.Success);

                    txt_verticle.Text = string.Empty;
                    txt_title.Text = string.Empty;
                    txt_verticle.Focus();
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