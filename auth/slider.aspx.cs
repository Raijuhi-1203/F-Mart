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

            if (upldphoto.PostedFile != null && upldphoto.PostedFile.FileName != "")
            {
                //then save it to the Folder
                foreach (HttpPostedFile postedFile in upldphoto.PostedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("upload/slider/") + fileName);

                    int imgSize = upldphoto.PostedFile.ContentLength;
                    //validates the posted file before saving

                    if (upldphoto.PostedFile.ContentLength > 5000000) // 5120 KB means 5MB
                    {
                        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.Upload picture upto 5MB')", true);
                    }
                    else
                    {
                        int success = bnc.Add_Slider("upload/slider/" + fileName,dbl_category.SelectedValue,"Mobile");
                        if (success > 0)
                        {
                            count++;
                        }
                        else
                        {
                            ShowMessage("Something went wrong.", MessageType.Error);
                        }
                    }
                }

                if (count > 0)
                {
                    ShowMessage("Slider has been saved.", MessageType.Success);
                    BindData();
                }

            }
            else
            {
                ShowMessage("Please choose photo.", MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_slider order by id desc");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btnupdate"))
        {
            Label lbl_edit_id = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbl_edit_id");
            DropDownList dbl_edit_category = (DropDownList)rptbinddata.Items[e.Item.ItemIndex].FindControl("dbl_edit_category");

            int success = bnc.Update_Slider_Link(dbl_edit_category.SelectedValue, lbl_edit_id.Text);

            if (success > 0)
            {
                ShowMessage("Link has been updated.", MessageType.Success);

                BindData();
            }

        }

        if (e.CommandName.Equals("btndelete"))
        {
            Label lblrowdeleteid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            // Delete

            SqlDataReader get_slider = mst.Select_Operation("Select * from ecommerce_slider where id='" + lblrowdeleteid.Text + "' ");
            if (get_slider.Read())
            {
                var filePath = Server.MapPath(get_slider["slider_photo"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            get_slider.Close();

            SqlDataReader delete_row = mst.Delete_Operation("delete from ecommerce_slider where id='" + lblrowdeleteid.Text + "'");
            delete_row.Close();

            ShowMessage("Data has been deleted.", MessageType.Success);

            BindData();
        }
    }

    private void BindCategory()
    {
        dbl_category.Items.Clear();
        dbl_category.Items.Add(new ListItem("None", ""));
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



    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DropDownList dbl_edit_category = (DropDownList)e.Item.FindControl("dbl_edit_category");

            Label lbl_slider_link = (Label)e.Item.FindControl("lbl_slider_link");
            Label lbl_link_name = (Label)e.Item.FindControl("lbl_link_name");

            dbl_edit_category.Items.Clear();
            dbl_edit_category.Items.Add(new ListItem("None", ""));
            dbl_edit_category.Items.Add(new ListItem("Offer", "offer"));
            dbl_edit_category.AppendDataBoundItems = true;

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

                dbl_edit_category.DataSource = cmd.ExecuteReader();
                dbl_edit_category.DataTextField = "category_name";
                dbl_edit_category.DataValueField = "category_id";
                dbl_edit_category.DataBind();
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



            SqlDataReader get_data = mst.Select_Operation("Select category_name from ecommerce_category where category_id='"+ lbl_slider_link.Text + "' ");
            if(get_data.Read())
            {
                if(lbl_slider_link.Text!="offer")
                {
                    lbl_link_name.Text = get_data["category_name"].ToString();

                }
                else
                {
                    lbl_link_name.Text = "Offer";

                }

            }

            get_data.Close();
        }
    }
}