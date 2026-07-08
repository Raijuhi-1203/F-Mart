using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_menu_category : System.Web.UI.Page
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
        if (!IsPostBack)
        {
           
        }
    }

    private void GenerateCategoryId()
    {
        con.Close();
        con.Open();
        string queryreadid = "SELECT category_temp_id FROM ecommerce_category ORDER BY category_temp_id DESC";
        SqlCommand cmdreadid = new SqlCommand(queryreadid, con);
        SqlDataReader readiddr = cmdreadid.ExecuteReader();
        if (readiddr.Read())
        {
            if (readiddr["category_temp_id"] == DBNull.Value)
            {
                lblcategoryidtemp.Text = "1";
                lblcategoryid.Text = "M0" + Convert.ToString(lblcategoryidtemp.Text);
            }
            else
            {
                lblcategoryidplus.Text = readiddr["category_temp_id"].ToString();
                lblcategoryidtemp.Text = Convert.ToString(Convert.ToInt32(lblcategoryidplus.Text) + 1);
                lblcategoryid.Text = "M0" + Convert.ToString(lblcategoryidtemp.Text);
            }
        }
        else
        {
            lblcategoryidtemp.Text = "1";
            lblcategoryid.Text = "M0" + Convert.ToString(lblcategoryidtemp.Text);
        }
        con.Close();
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        GenerateCategoryId();

        try
        {
            if (uploadphoto.PostedFile != null && uploadphoto.PostedFile.FileName != "")
            {
                //then save it to the Folder
                foreach (HttpPostedFile postedFile in uploadphoto.PostedFiles)
                {
                    string fileName = Guid.NewGuid().ToString() ;
                    string fileExtension = Path.GetExtension(postedFile.FileName);

                    string filePath = "upload/category-photo/" + fileName + fileExtension;

                    postedFile.SaveAs(Server.MapPath(filePath));
                  
                    //validates the posted file before saving

                    if (uploadphoto.PostedFile.ContentLength > 5000000) // 5120 KB means 5MB
                    {
                        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.Upload picture upto 5MB')", true);
                    }
                    else
                    {
                        if (txt_category_name.Text.Length > 0 && txt_title.Text.Length > 0)
                        {
                            int category_exist = pdt.Check_Category_name(txt_category_name.Text);

                            if (category_exist > 0)
                            {
                                ShowMessage("Category already exist.", MessageType.Error);
                            }
                            else
                            {
                                con.Open();

                                string insert_category = "insert into ecommerce_category(category_temp_id,category_id,category_name,main_category_id,category_photo,category_status,category_display,category_orderno,category_type,category_title,super_point) values (@category_temp_id,@category_id,@category_name,@main_category_id,@category_photo,@category_status,@category_display,@category_orderno,@category_type,@category_title,@super_point)";
                                SqlCommand cmd_category = new SqlCommand(insert_category, con);

                                cmd_category.Parameters.AddWithValue("@category_temp_id", lblcategoryidtemp.Text);
                                cmd_category.Parameters.AddWithValue("@category_id", lblcategoryid.Text);
                                cmd_category.Parameters.AddWithValue("@category_name", txt_category_name.Text);
                                cmd_category.Parameters.AddWithValue("@main_category_id", "0");
                                cmd_category.Parameters.AddWithValue("@category_photo", filePath);
                                cmd_category.Parameters.AddWithValue("@category_status", dblstatus.SelectedValue);
                                cmd_category.Parameters.AddWithValue("@category_display", "Yes");
                                cmd_category.Parameters.AddWithValue("@category_orderno", txt_position_no.Text);
                                cmd_category.Parameters.AddWithValue("@category_type", "Restaurant");
                                cmd_category.Parameters.AddWithValue("@category_title", txt_title.Text);
                                cmd_category.Parameters.AddWithValue("@super_point", "0");


                                int success = cmd_category.ExecuteNonQuery();
                                if (success > 0)
                                {
                                    ShowMessage("Menu category has been saved.", MessageType.Success);

                                    txt_category_name.Text = string.Empty;
                                    txt_title.Text = string.Empty;

                                }
                                else
                                {
                                    ShowMessage("Something went wrong.", MessageType.Warning);
                                }
                            }
                        }
                        else
                        {
                            ShowMessage("All field are required.", MessageType.Error);
                        }


                    }
                }

            }
            else
            {
                ShowMessage("Please choose category photo.", MessageType.Error);
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
            SqlDataReader get_position = mst.Select_Operation("Select category_name from ecommerce_category where category_orderno='" + txt_position_no.Text + "' AND category_type='Restaurant' ");
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