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
    Backend bnc = new Backend();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);

        if (!IsPostBack)
        {
            BindCategory();
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
                lblproductid.Text = "F0" + DateTime.Now.Month + Convert.ToString(lblproductidtemp.Text);
            }
            else
            {
                lblproductidplus.Text = readiddr["product_temp_id"].ToString();
                lblproductidtemp.Text = Convert.ToString(Convert.ToInt32(lblproductidplus.Text) + 1);
                lblproductid.Text = "F0" + DateTime.Now.Month + Convert.ToString(lblproductidtemp.Text);
            }
        }
        else
        {
            lblproductidtemp.Text = "1";
            lblproductid.Text = "F0" + DateTime.Now.Month + Convert.ToString(lblproductidtemp.Text);
        }

        readiddr.Close();

    }

    private void BindCategory()
    {
        dblparentcategory.Items.Clear();
        dblparentcategory.Items.Add(new ListItem("Please Select", "0"));
        dblparentcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where category_type=@category_type";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@category_type", "Restaurant");
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

    protected void btnsaveAndnext_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtproductname.Text.Length > 0 && dblparentcategory.SelectedItem.Text != "Please Select" && dbl_food_type.SelectedItem.Text != "Please Select")
            {
                GenerateProductId();

                int success = bnc.Add_Food_Item(lblproductidtemp.Text, lblproductid.Text, txtproductname.Text, txtdescription.Text, dblparentcategory.SelectedValue, dblparentcategory.SelectedItem.Text,txtdescription.Text, dbl_publish.SelectedValue, "Restaurant", dbl_food_type.SelectedValue);

                if (success > 0)
                {
                    if (uploadphoto.PostedFile != null && uploadphoto.PostedFile.FileName != "")
                    {
                        //then save it to the Folder
                        foreach (HttpPostedFile postedFile in uploadphoto.PostedFiles)
                        {
                            string imgName = postedFile.FileName.ToString();
                            string extension = Path.GetExtension(postedFile.FileName);
                            postedFile.SaveAs(Server.MapPath("upload/food-photo/") + imgName + lblproductid.Text + extension);

                            //sets the image path
                            string imgPath = "upload/food-photo/" + imgName + lblproductid.Text + extension;

                            // Save Photo Query

                            int success_photo = bnc.Add_Product_Photo(lblproductid.Text, imgPath);

                        }
                    }
                    else
                    {
                        ShowMessage("Please choose photos.", MessageType.Error);
                    }

                    ShowMessage("New food item has been saved.", MessageType.Success);

                    Response.Redirect("add-food-price.aspx?ref=" + lblproductid.Text + "&mode=new");
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
}