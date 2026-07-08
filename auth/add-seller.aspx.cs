using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_seller : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Backend bnc = new Backend();
    Encrypt enc = new Encrypt();
    Bulksms_gateway sms = new Bulksms_gateway();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_State();
            Bind_GST_State();
        }
    }

    private void GenerateId()
    {
        SqlDataReader readiddr = mst.Select_Operation("SELECT Max(seller_id) as seller_id FROM ecommerce_seller ");
        if (readiddr.Read())
        {
            if (readiddr["seller_id"] == DBNull.Value)
            {
                lbl_id.Text = "1";
            }
            else
            {
                lbl_id.Text = Convert.ToString(Convert.ToInt32(readiddr["seller_id"].ToString()) + 1);
            }
        }
        else
        {
            lbl_id.Text = "1";
        }

        readiddr.Close();
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



    protected void btnsaveAndnext_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtmobileno.Text.Length > 0 && txtname.Text.Length > 0 &&   txt_firm_name.Text.Length > 0 && dbl_state.SelectedItem.Text != "Please Select" && dbl_city.SelectedItem.Text != "Please Select" && dbl_gst_state.SelectedItem.Text != "Please Select" && dbl_pincode.SelectedItem.Text!="Please Select" && dbl_area.SelectedItem.Text!="Please Select" && txt_opening_time.Text.Length>0 && txt_closing_time.Text.Length>0)
            {
                GenerateId();

                int count_exist = Convert.ToInt32(mst.Count_data("Select Count(seller_firm_name) from ecommerce_seller where seller_mobileno='" + txtmobileno.Text + "' "));

                if (count_exist > 0)
                {
                    ShowMessage("Mobile No already registered.", MessageType.Error);
                }
                else
                {
                    int success = bnc.Seller_Registration(lbl_id.Text, txtname.Text, txtmobileno.Text, "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm tt"), "0", "0", "Yes");

                    if (success > 0)
                    {
                        int success_firm = bnc.Update_Seller_Registration(txt_firm_name.Text, txt_address_line_1.Text, dbl_state.SelectedValue, dbl_state.SelectedItem.Text, "", dbl_city.SelectedItem.Text, dbl_pincode.SelectedValue,dbl_area.SelectedValue, txt_gst.Text, dbl_gst_state.SelectedValue, dbl_gst_state.SelectedItem.Text,txt_opening_time.Text,txt_closing_time.Text, lbl_id.Text);

                        if (success_firm > 0)
                        {
                            if (upld_shop_photo.PostedFile != null && upld_shop_photo.PostedFile.FileName != "")
                            {
                                string imgName = Guid.NewGuid().ToString();
                                string extension = Path.GetExtension(upld_shop_photo.FileName);
                                upld_shop_photo.SaveAs(Server.MapPath("upload/seller/") + imgName + lbl_id.Text + extension);

                                //sets the image path
                                string imgPath = "upload/seller/" + imgName + lbl_id.Text + extension;

                                int document = bnc.Update_Seller_Photo(imgPath, lbl_id.Text);

                            }

                            if (upld_scan_copy.PostedFile != null && upld_scan_copy.PostedFile.FileName != "")
                            {
                                string imgName = upld_scan_copy.FileName.ToString();
                                string extension = Path.GetExtension(upld_scan_copy.FileName);
                                upld_scan_copy.SaveAs(Server.MapPath("upload/identity-photo/") + imgName + lbl_id.Text + extension);

                                //sets the image path
                                string imgPath = "upload/identity-photo/" + imgName + lbl_id.Text + extension;

                                int document = bnc.Add_Seller_Document(lbl_id.Text, dbl_options.SelectedValue, imgPath, "Web",txt_identitty_no.Text);

                            }

                            ShowMessage("Registration has been completed.", MessageType.Success);


                            txtmobileno.Text = string.Empty;
                            txtname.Text = string.Empty;
                            txt_gst.Text = string.Empty;
                            txt_address_line_1.Text = string.Empty;
                            txt_email.Text = string.Empty;
                            txt_firm_name.Text = string.Empty;
                            txt_identitty_no.Text = string.Empty;

                            Response.Redirect("seller-menu-category.aspx?ref="+lbl_id.Text);

                        }

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
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    protected void dbl_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dbl_city.SelectedItem.Text!="Please Select")
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