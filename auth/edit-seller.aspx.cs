using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_edit_seller : System.Web.UI.Page
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
            Bind_State();
            Bind_GST_State();

            SqlDataReader get_data = mst.Select_Operation("Select * from ecommerce_seller where seller_id='" + Request.QueryString[0] + "' ");
            if (get_data.Read())
            {
                txtmobileno.Text = get_data["seller_mobileno"].ToString();
                txtname.Text = get_data["seller_name"].ToString();
                txt_address_line_1.Text = get_data["seller_address_line_1"].ToString();
                txt_email.Text = get_data["seller_email"].ToString();
                txt_firm_name.Text = get_data["seller_firm_name"].ToString();

                dbl_gst_state.SelectedValue = get_data["seller_gst_state_code"].ToString();

                txt_gst.Text = get_data["seller_gst"].ToString();

                dbl_state.SelectedValue = get_data["seller_state_id"].ToString();

                Bind_City();

                dbl_city.SelectedValue = get_data["seller_city_name"].ToString();

                mst.BindDropDown(dbl_pincode, "pincode", "pincode", "Select pincode from ecommerce_pincode Where city_name='" + dbl_city.SelectedValue + "' ");

                dbl_pincode.SelectedValue = get_data["seller_pincode"].ToString();

                mst.BindDropDown(dbl_area, "id", "area", "Select id,area from ecommerce_pincode Where pincode='" + dbl_pincode.SelectedValue + "' ");

                dbl_area.SelectedValue = get_data["seller_area_id"].ToString();

                txt_opening_time.Text = get_data["opening_time"].ToString();
                txt_closing_time.Text = get_data["closing_time"].ToString();

            }

            get_data.Close();

            Bind_Document();
        }
    }

    private void Bind_Document()
    {
        rptbindphotos.DataSource = mst.GetData("SELECT * FROM ecommerce_seller_document where seller_id='" + Request.QueryString[0] + "' order by id asc");
        rptbindphotos.DataBind();
    }

    private void Bind_State()
    {
        dbl_state.Items.Clear();
        dbl_state.Items.Add(new ListItem("Please Select", " "));
        dbl_state.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT * FROM ecommerce_state order by state_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_state.DataSource = cmd.ExecuteReader();
            dbl_state.DataTextField = "state_name";
            dbl_state.DataValueField = "state_id";
            dbl_state.DataBind();
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

    private void Bind_City()
    {
        dbl_city.Items.Clear();
        dbl_city.Items.Add(new ListItem("Please Select", " "));
        dbl_city.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT district_id,district_name FROM ecommerce_city where state_id='" + dbl_state.SelectedValue + "' order by district_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_city.DataSource = cmd.ExecuteReader();
            dbl_city.DataTextField = "district_name";
            dbl_city.DataValueField = "district_name";
            dbl_city.DataBind();
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

    private void Bind_GST_State()
    {
        dbl_gst_state.Items.Clear();
        //  dbl_gst_state.Items.Add(new ListItem("Please Select", " "));
        dbl_gst_state.Items.Add(new ListItem("None", " "));
        dbl_gst_state.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT * FROM ecommerce_gst_state order by state_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_gst_state.DataSource = cmd.ExecuteReader();
            dbl_gst_state.DataTextField = "state_name";
            dbl_gst_state.DataValueField = "state_code";
            dbl_gst_state.DataBind();
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

    protected void dbl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dbl_state.SelectedItem.Text != "Please Select")
        {
            Bind_City();
        }
        else
        {
            ShowMessage("Please choose State.", MessageType.Error);
        }
    }


    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txtmobileno.Text.Length>0 && txtname.Text.Length>0 && txt_address_line_1.Text.Length>0 &&  txt_firm_name.Text.Length>0 &&  dbl_city.SelectedItem.Text!="Please Select" && dbl_gst_state.SelectedItem.Text!="Please Select" && dbl_state.SelectedItem.Text!="Please Select" && dbl_area.SelectedItem.Text!="Please Select" && dbl_pincode.SelectedItem.Text!="Please Select" && txt_closing_time.Text.Length>0 && txt_opening_time.Text.Length>0)
            {
                int success = bnc.Update_Seller_Profile(txtname.Text,txtmobileno.Text,txt_firm_name.Text,txt_address_line_1.Text,dbl_state.SelectedValue,dbl_state.SelectedItem.Text,"",dbl_city.SelectedItem.Text,dbl_pincode.SelectedValue,dbl_area.SelectedValue, dbl_gst_state.SelectedValue,dbl_gst_state.SelectedItem.Text,txt_gst.Text,txt_opening_time.Text,txt_closing_time.Text, Request.QueryString[0]);

                if(success>0)
                {
                    ShowMessage("Profile has been updated.",MessageType.Success);
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

    protected void btnsavedocument_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (upld_scan_copy.PostedFile != null && upld_scan_copy.PostedFile.FileName != "")
            {
                SqlDataReader dr_delete_document = mst.Select_Operation("Select document_path from ecommerce_seller_document where seller_id='" + Request.QueryString[0] + "' AND document_name='"+dbl_options.SelectedValue+"'  ");
                if (dr_delete_document.Read())
                {
                    var filePath = Server.MapPath(dr_delete_document["document_path"].ToString());
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }       

                dr_delete_document.Close();


                // Delect Doc

                SqlDataReader dr_delete_seller_dc = mst.Delete_Operation("delete from ecommerce_seller_document where seller_id='" + Request.QueryString[0] + "' AND document_name='" + dbl_options.SelectedValue + "' ");
                dr_delete_seller_dc.Close();

                string imgName = upld_scan_copy.FileName.ToString();
                string extension = Path.GetExtension(upld_scan_copy.FileName);
                upld_scan_copy.SaveAs(Server.MapPath("upload/identity-photo/") + imgName + Request.QueryString[0] + extension);

                //sets the image path
                string imgPath = "upload/identity-photo/" + imgName + Session["seller_id"].ToString() + extension;

                int document = bnc.Add_Seller_Document(Request.QueryString[0], dbl_options.SelectedValue, imgPath, "Web",txt_identitty_no.Text);

                if(document>0)
                {
                    ShowMessage("Document has been saved.",MessageType.Success);
                }
            }
            else
            {
                ShowMessage("Please choose file.",MessageType.Error);
            }

        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    protected void btn_upload_photo_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (upld_photo.PostedFile != null && upld_photo.PostedFile.FileName != "")
            {
                SqlDataReader dr_delete_document = mst.Select_Operation("Select seller_photo from ecommerce_seller where seller_id='" + Request.QueryString[0] + "'  ");
                if (dr_delete_document.Read())
                {
                    var filePath = Server.MapPath(dr_delete_document["seller_photo"].ToString());
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                dr_delete_document.Close();


                string imgName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(upld_photo.FileName);
                upld_photo.SaveAs(Server.MapPath("upload/seller/") + imgName + Request.QueryString[0] + extension);

                //sets the image path
                string imgPath = "upload/seller/" + imgName + Request.QueryString[0].ToString() + extension;

                int success_photo = bnc.Update_Seller_Photo(imgPath, Request.QueryString[0].ToString());

                if (success_photo > 0)
                {
                    ShowMessage("Photo has been saved.", MessageType.Success);
                }
            }
            else
            {
                ShowMessage("Please choose photo.",MessageType.Error);
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
            Label lblrowdeleteid = (Label)rptbindphotos.Items[e.Item.ItemIndex].FindControl("lblrowdeleteid");

            SqlDataReader dr_delete_photo = mst.Select_Operation("Select * from ecommerce_seller_document where id='" + lblrowdeleteid.Text + "'");
            if (dr_delete_photo.Read())
            {
                var filePath = Server.MapPath( dr_delete_photo["document_path"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
               
            }

            dr_delete_photo.Close();

            SqlDataReader dr_delete_data = mst.Delete_Operation("delete from ecommerce_seller_document where id='" + lblrowdeleteid.Text + "'");
            dr_delete_data.Close();

            ShowMessage("Delete operation success.", MessageType.Success);

            Bind_Document();
        }
    }

    protected void dbl_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dbl_city.SelectedItem.Text != "Please Select")
        {
            mst.BindDropDown(dbl_pincode, "pincode", "pincode", "Select pincode from ecommerce_pincode Where city_name='" + dbl_city.SelectedValue + "' ");

        }
    }

    protected void dbl_pincode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dbl_pincode.SelectedItem.Text != "Please Select")
        {
            mst.BindDropDown(dbl_area, "id", "area", "Select id,area from ecommerce_pincode Where pincode='" + dbl_pincode.SelectedValue + "' ");

        }
    }



}