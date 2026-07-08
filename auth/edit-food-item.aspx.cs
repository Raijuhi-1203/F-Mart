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

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);

        if (!IsPostBack)
        {
            BindCategory();
            BindData_Photos();
            BindData_Price();
         
            // Get data of product

            SqlDataReader dr_product_data = mst.Select_Operation("select * from ecommerce_product where product_id='" + Request.QueryString[0] + "' ");
            if(dr_product_data.Read())
            {
                txtdescription.Text = dr_product_data["product_description"].ToString();
                txtproductname.Text = dr_product_data["product_full_name"].ToString();
                dbl_publish.SelectedValue = dr_product_data["publish_status"].ToString();
                dbl_food_type.SelectedValue = dr_product_data["food_type"].ToString();
                dblparentcategory.SelectedValue = dr_product_data["product_parent_category_id"].ToString();
            }

            dr_product_data.Close();
         
            add_price_btn.HRef = "add-food-price.aspx?ref=" + Request.QueryString[0];
        }
    }


    private void BindData_Photos()
    {
        rptbindphotos.DataSource = mst.GetData("SELECT Top 1 * FROM ecommerce_product_photos where product_id='" + Request.QueryString[0] + "' order by id asc");
        rptbindphotos.DataBind();
    }

    private void BindData_Price()
    {
        rptbinddataprice.DataSource = mst.GetData("SELECT * FROM ecommerce_product_price where product_id='" + Request.QueryString[0] + "' order by id asc");
        rptbinddataprice.DataBind();
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

    protected void btnupdateinformation_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtproductname.Text.Length > 0 && dblparentcategory.SelectedItem.Text!="Please Select")
            {
                int success = bnc.Edit_Food_Item(txtproductname.Text, txtdescription.Text,dblparentcategory.SelectedValue,dblparentcategory.SelectedItem.Text,txtdescription.Text ,dbl_publish.SelectedValue, "Restaurant",dbl_food_type.SelectedValue, Request.QueryString[0]);

                if (success > 0)
                {
                    ShowMessage("Food item has been updated.", MessageType.Success);
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
                SqlDataReader dr_delete_photo = mst.Select_Operation("Select photo_path from ecommerce_product_photos Where product_id='" + Request.QueryString[0] +"'");
                if (dr_delete_photo.Read())
                {
                    var filePath = Server.MapPath(dr_delete_photo["photo_path"].ToString());
                   
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                dr_delete_photo.Close();

                // Delete Data

                SqlDataReader deleteData = mst.Delete_Operation("Delete from ecommerce_product_photos Where product_id='" + Request.QueryString[0] +"' ");
                deleteData.Close();

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

                ShowMessage("Item photos has been updated.",MessageType.Success);

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