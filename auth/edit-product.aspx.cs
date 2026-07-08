using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_edit_product : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Backend bnc = new Backend();
    BackendExt bncExt = new BackendExt();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);

        if (!IsPostBack)
        {
            BindCategory();

            BindData_Photos();

            BindData_Price();

            BindBrand();

            // Get data of product


            SqlDataReader dr_product_data = mst.Select_Operation("select * from ecommerce_product where product_id='" + Request.QueryString[0] + "' ");
            if(dr_product_data.Read())
            {
                txt_country_of_origin.Text = dr_product_data["country_of_origin"].ToString();
                txtdescription.Text = dr_product_data["product_description"].ToString();
                txtfulldescription.Text = dr_product_data["product_full_description"].ToString();
                txtproducthsnsac.Text = dr_product_data["product_hsnORsac"].ToString();
                txtproductname.Text = dr_product_data["product_full_name"].ToString();
                dbl_publish.SelectedValue = dr_product_data["publish_status"].ToString();
                dbl_brand.SelectedValue = dr_product_data["product_brand_name"].ToString();

                txt_sku.Text = dr_product_data["product_sku"].ToString();

                dblparentcategory.SelectedValue = dr_product_data["product_parent_category_id"].ToString();

                BindSubCategory();

                dblsubcategory.SelectedValue = dr_product_data["product_sub_category_id"].ToString();
            }

            dr_product_data.Close();
         
            add_price_btn.HRef = "add-product-price.aspx?ref=" + Request.QueryString[0];
        }
    }


    private void BindData_Photos()
    {
        rptbindphotos.DataSource = mst.GetData("SELECT * FROM ecommerce_product_photos where product_id='" + Request.QueryString[0] + "' order by id asc");
        rptbindphotos.DataBind();
    }

    private void BindData_Price()
    {
        rptbinddataprice.DataSource = mst.GetData("SELECT * FROM ecommerce_product_price where product_id='" + Request.QueryString[0] + "' order by id asc");
        rptbinddataprice.DataBind();
    }

    private void BindBrand()
    {
        dbl_brand.Items.Clear();
        dbl_brand.Items.Add(new ListItem("Please Select", " "));
        dbl_brand.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT brand_name  from ecommerce_brand order by brand_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_brand.DataSource = cmd.ExecuteReader();
            dbl_brand.DataTextField = "brand_name";
            dbl_brand.DataValueField = "brand_name";
            dbl_brand.DataBind();
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


    private void BindCategory()
    {
        dblparentcategory.Items.Clear();
        dblparentcategory.Items.Add(new ListItem("Please Select", "0"));
        dblparentcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where main_category_id=@main_category_id AND category_type=@category_type";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@main_category_id", "0");
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
    
    private void BindSubCategory()
    {
        dblsubcategory.Items.Clear();
        dblsubcategory.Items.Add(new ListItem("Please Select", "0"));
        dblsubcategory.Items.Add(new ListItem("None", ""));
        dblsubcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where main_category_id=@main_category_id AND category_type=@category_type";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@main_category_id", dblparentcategory.SelectedValue);
        cmd.Parameters.AddWithValue("@category_type", "Grocery");
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
        BindSubCategory();
    }


    protected void btnupdateinformation_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtproductname.Text.Length > 0 && txt_country_of_origin.Text.Length>0)
            {
                int success = bnc.Edit_Product(txtproductname.Text, txtdescription.Text, txtproducthsnsac.Text,txt_country_of_origin.Text, txtfulldescription.Text,dbl_publish.SelectedValue,dbl_brand.SelectedValue,"",txt_sku.Text, "0", Request.QueryString[0]);

                if (success > 0)
                {
                    ShowMessage("Product information has been updated.", MessageType.Success);
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

    protected void btnupdatecategory_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if ( dblparentcategory.SelectedItem.Text != "Please Select" && dblsubcategory.SelectedItem.Text != "Please Select")
            {
                int success = bnc.Edit_Product_Category(dblparentcategory.SelectedValue, dblparentcategory.SelectedItem.Text, dblsubcategory.SelectedValue, dblsubcategory.SelectedItem.Text,"","", Request.QueryString[0]);

                if (success > 0)
                {
                    ShowMessage("Product category has been updated.", MessageType.Success);
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

    protected void rptbindphotos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblphotorowdeleteid = (Label)rptbindphotos.Items[e.Item.ItemIndex].FindControl("lblphotorowdeleteid");
           
            SqlDataReader dr_delete_photo =mst.Select_Operation("Select * from ecommerce_product_photos where id='" + lblphotorowdeleteid.Text + "'");
            if (dr_delete_photo.Read())
            {
                var filePath = Server.MapPath(dr_delete_photo["photo_path"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                dr_delete_photo.Close();
            }
            
            SqlDataReader dr_delete_data = mst.Delete_Operation("delete from ecommerce_product_photos where id='" + lblphotorowdeleteid.Text + "'");
            dr_delete_data.Close();

            ShowMessage("Delete operation success.", MessageType.Success);

            BindData_Photos();
        }
    }


    protected void rptbinddataprice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbinddataprice.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");
           
            SqlDataReader dr_price_data =mst.Delete_Operation("delete from ecommerce_product_price where id='" + lblrowdeleteid.Text + "'");
            dr_price_data.Close();

            ShowMessage("Delete operation success.", MessageType.Success);

            BindData_Price();
        }
    }

    protected void btnupdatephotos_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (uploadphoto.PostedFile != null && uploadphoto.PostedFile.FileName != "")
            {
                //then save it to the Folder
                foreach (HttpPostedFile postedFile in uploadphoto.PostedFiles)
                {
                    string imgName = postedFile.FileName.ToString();
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("upload/product-photo/") + imgName + Request.QueryString[0] + extension);

                    //sets the image path
                    string imgPath = "upload/product-photo/" + imgName + Request.QueryString[0] + extension;

                    int success_photo = bnc.Add_Product_Photo(Request.QueryString[0], imgPath);
                }

                ShowMessage("Product photos has been updated.",MessageType.Success);

                BindData_Photos();

            }
            else
            {
                ShowMessage("Please choose photos.", MessageType.Error);
            }

        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }

   
}