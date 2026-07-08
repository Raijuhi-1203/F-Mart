using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class auth_slider : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            BindCategory();
            BindData();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int count = 0;

            int banner_count = mst.Count_data("Select Count(id) from ecommerce_banner");

            if(banner_count<5)
            {
                if (upldphoto.PostedFile != null && upldphoto.PostedFile.FileName != "")
                {
                    //then save it to the Folder
                    foreach (HttpPostedFile postedFile in upldphoto.PostedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        postedFile.SaveAs(Server.MapPath("upload/offer-banner/") + fileName);

                        int imgSize = upldphoto.PostedFile.ContentLength;
                        //validates the posted file before saving

                        int success = bnc.Add_Offer_Banner("upload/offer-banner/" + fileName,dbl_category.SelectedValue, "Yes");
                        if (success > 0)
                        {
                            count++;
                        }
                        else
                        {
                            ShowMessage("Something went wrong.", MessageType.Error);
                        }
                    }

                    if (count > 0)
                    {
                        ShowMessage("Data has been saved.", MessageType.Success);

                        BindData();
                    }

                }
                else
                {
                    ShowMessage("Please choose photo.", MessageType.Error);
                }
            }
            else
            {
                ShowMessage("Maximum 4 banner allowed.",MessageType.Error);
            }

           
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_banner order by id desc");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            // Delete

            SqlDataReader get_photo = mst.Select_Operation("Select banner_path from ecommerce_banner where id='" + lblrowdeleteid.Text + "' ");
            if (get_photo.Read())
            {
                var filePath = Server.MapPath(get_photo["banner_path"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            get_photo.Close();

            SqlDataReader delete_row = mst.Delete_Operation("delete from ecommerce_banner where id='" + lblrowdeleteid.Text + "'");
            delete_row.Close();

            ShowMessage("Data has been deleted.", MessageType.Success);

            BindData();
        }
    }

    private void BindCategory()
    {
        dbl_category.Items.Clear();
        dbl_category.Items.Add(new ListItem("None", "0"));
        dbl_category.Items.Add(new ListItem("Offer", "offer"));
        dbl_category.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT category_name, category_id FROM ecommerce_category where category_status='Yes'";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_category.DataSource = cmd.ExecuteReader();
            dbl_category.DataTextField = "category_name";
            dbl_category.DataValueField = "category_id";
            dbl_category.DataBind();
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

}