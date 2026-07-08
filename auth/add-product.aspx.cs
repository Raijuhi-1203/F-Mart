using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_product : Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Product pdt = new Product();
    Backend bnc = new Backend();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);

        if (!IsPostBack)
        {
            BindCategory();
            BindBrand();
        }
    }

    private void GenerateProductId()
    {
        SqlDataReader readiddr = mst.Select_Operation("SELECT product_temp_id FROM ecommerce_product ORDER BY product_temp_id DESC");
        if (readiddr.Read())
        {
            if (readiddr["product_temp_id"] == DBNull.Value)
            {
                lblproductidtemp.Text = "1";
                lblproductid.Text = "P0" + DateTime.Now.Month + Convert.ToString(lblproductidtemp.Text);
            }
            else
            {
                lblproductidplus.Text = readiddr["product_temp_id"].ToString();
                lblproductidtemp.Text = Convert.ToString(Convert.ToInt32(lblproductidplus.Text) + 1);
                lblproductid.Text = "P0" + DateTime.Now.Month + Convert.ToString(lblproductidtemp.Text);
            }
        }
        else
        {
            lblproductidtemp.Text = "1";
            lblproductid.Text = "P0" + DateTime.Now.Month + Convert.ToString(lblproductidtemp.Text);
        }

        readiddr.Close();

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

    protected void dblparentcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubCategory();
    }

    protected void btnsaveAndnext_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtproductname.Text.Length > 0 && dblparentcategory.SelectedItem.Text != "Please Select" && txt_country_of_origin.Text.Length > 0 && dblsubcategory.SelectedItem.Text != "Please Select")
            {
                int product_exist = pdt.Check_Category_name(txtproductname.Text);

                if (product_exist > 0)
                {
                    ShowMessage("Product already exist.", MessageType.Error);
                }
                else
                {
                    GenerateProductId();

                    int success = bnc.Add_Product(lblproductidtemp.Text, lblproductid.Text, txtproductname.Text, txtdescription.Text, txtproducthsnsac.Text, dblparentcategory.SelectedValue, dblparentcategory.SelectedItem.Text, dblsubcategory.SelectedValue, dblsubcategory.SelectedItem.Text, txtfulldescription.Text, dbl_publish.SelectedValue, txt_position_no.Text, txt_country_of_origin.Text,"", "", dbl_brand.SelectedValue, "", "0", "Arshit", txt_sku.Text, "0", "Grocery");

                    if (success > 0)
                    {
                        // Add Product

                        if (uploadphoto.PostedFile != null && uploadphoto.PostedFile.FileName != "")
                        {
                            //then save it to the Folder
                            foreach (HttpPostedFile postedFile in uploadphoto.PostedFiles)
                            {
                                string imgName = postedFile.FileName.ToString();
                                string extension = Path.GetExtension(postedFile.FileName);
                                postedFile.SaveAs(Server.MapPath("upload/product-photo/") + imgName + lblproductid.Text + extension);

                                //sets the image path
                                string imgPath = "upload/product-photo/" + imgName + lblproductid.Text + extension;

                                // Save Photo Query

                                int success_photo = bnc.Add_Product_Photo(lblproductid.Text, imgPath);

                            }
                        }
                        else
                        {
                            ShowMessage("Please choose photos.", MessageType.Error);
                        }

                        ShowMessage("New Product data has been saved.", MessageType.Success);

                        Response.Redirect("add-product-price.aspx?ref=" + lblproductid.Text + "&mode=new");
                    }
                }
            }
            else
            {
                ShowMessage("All * field are required.", MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Warning);
        }
    }

    protected void txt_position_no_TextChanged(object sender, EventArgs e)
    {
        if (txt_position_no.Text.Length > 0)
        {
            SqlDataReader get_position = mst.Select_Operation("Select product_full_name from ecommerce_product where product_postion_no='" + txt_position_no.Text + "' AND product_sub_category_id='" + dblsubcategory.SelectedValue + "' ");
            if (get_position.Read())
            {
                lbl_error.Text = "Please try another position no. Already assign to " + get_position["product_full_name"];
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