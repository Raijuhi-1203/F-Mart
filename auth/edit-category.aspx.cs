using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_edit_service : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            BindCategory();

            SqlDataReader dr_data = mst.Select_Operation("select * from ecommerce_category where category_id='" + Request.QueryString[0] + "' ");
            if(dr_data.Read())
            {
                txt_category_name.Text = dr_data["category_name"].ToString();
                txt_title.Text = dr_data["category_title"].ToString();
                dblparentcategory.SelectedValue = dr_data["main_category_id"].ToString();
                dblstatus.SelectedValue = dr_data["category_status"].ToString();

                txt_position_no.Text = dr_data["category_orderno"].ToString();
            }

            dr_data.Close();
        }
    }

    private void BindCategory()
    {
        dblparentcategory.Items.Clear();
        dblparentcategory.Items.Add(new ListItem("None", "0"));
        dblparentcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where main_category_id=@main_category_id AND category_display!=@category_display AND category_type=@category_type";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@main_category_id", "0");
        cmd.Parameters.AddWithValue("@category_display", "No");
        cmd.Parameters.AddWithValue("@category_type", "Grocery");
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

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txt_category_name.Text.Length>0 && txt_title.Text.Length>0)
            {
                int success = bnc.Edit_Category(dblparentcategory.SelectedValue, txt_category_name.Text, dblstatus.SelectedValue, txt_position_no.Text,txt_title.Text, Request.QueryString[0]);

                int update_product_main_category = bnc.Edit_Product_Main_Category_name(txt_category_name.Text,Request.QueryString[0]);
                int update_product_sub_category = bnc.Edit_Product_Sub_Category_name(txt_category_name.Text, Request.QueryString[0]);

                if (success > 0)
                {
                    ShowMessage("Category data has been updated.", MessageType.Success);
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

    protected void btnphotoupdate_ServerClick(object sender, EventArgs e)
    {
        try
        {
            try
            {
                if (uploadphoto.PostedFile != null && uploadphoto.PostedFile.FileName != "")
                {

                    //then save it to the Folder
                    foreach (HttpPostedFile postedFile in uploadphoto.PostedFiles)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        string fileExtension = Path.GetExtension(postedFile.FileName);

                        string fileSavePath = "upload/category-photo/" + fileName + fileExtension;

                      
                        //validates the posted file before saving

                        if (uploadphoto.PostedFile.ContentLength > 5000000) // 5120 KB means 5MB
                        {
                            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.Upload picture upto 5MB')", true);
                        }
                        else
                        {
                            con.Open();

                            string query_delete_photo = "Select * from ecommerce_category where category_id='" + Request.QueryString[0] + "'";
                            SqlCommand cmd_delete_photo = new SqlCommand(query_delete_photo, con);
                            SqlDataReader dr_delete_photo = cmd_delete_photo.ExecuteReader();

                            if (dr_delete_photo.Read())
                            {
                                var filePath = Server.MapPath(dr_delete_photo["category_photo"].ToString());
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                }
                                dr_delete_photo.Close();
                            }

                            postedFile.SaveAs(Server.MapPath(fileSavePath));


                            string insert_service_provider = "Update ecommerce_category Set category_photo=@category_photo where category_id=@category_id";
                            SqlCommand cmd_service_provider = new SqlCommand(insert_service_provider, con);

                            cmd_service_provider.Parameters.AddWithValue("@category_photo", fileSavePath);
                            cmd_service_provider.Parameters.AddWithValue("@category_id", Request.QueryString[0]);

                            int success = cmd_service_provider.ExecuteNonQuery();
                            if (success > 0)
                            {
                                ShowMessage("Category photo has been updated.", MessageType.Success);
                            }
                            else
                            {
                                ShowMessage("Something went wrong.", MessageType.Warning);
                            }
                        }
                    }
                }
                else
                {
                    ShowMessage("Please choose service photo.", MessageType.Error);
                }
            }
            catch (SqlException ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    protected void txt_position_no_TextChanged(object sender, EventArgs e)
    {
        if (txt_position_no.Text.Length > 0)
        {
            SqlDataReader get_position = mst.Select_Operation("Select category_name from ecommerce_category where category_orderno='" + txt_position_no.Text + "' ");
            if (get_position.Read())
            {
                lbl_error.Text = "Please try another position no. Already assign to " + get_position["category_name"];
            }
            else
            {
                lbl_error.Text = string.Empty;
            }
            get_position.Close();

        }
        else
        {
            lbl_error.Text = "Please enter position no.";
        }
    }

}