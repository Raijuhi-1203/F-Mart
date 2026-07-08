using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_delivery_boy : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    DeliveryBoy bnc = new DeliveryBoy();
    Encrypt enc = new Encrypt();
    Bulksms_gateway sms = new Bulksms_gateway();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Bind_State();
        }
    }

    private void GenerateId()
    {
        SqlDataReader readiddr = mst.Select_Operation("SELECT Max(delivery_boy_id) as delivery_boy_id FROM ecommerce_delivery_boy ");
        if (readiddr.Read())
        {
            if (readiddr["delivery_boy_id"] == DBNull.Value)
            {
                lbl_id.Text = "1";
            }
            else
            {
                lbl_id.Text = Convert.ToString(Convert.ToInt32(readiddr["delivery_boy_id"].ToString()) + 1);
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
            dbl_city.DataValueField = "district_id";
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
            if(txt_address_line_1.Text.Length>0 && txt_mobileno.Text.Length>0 && txt_name.Text.Length>0 && txt_password.Text.Length>0 && txt_pincode.Text.Length>0 && dbl_state.SelectedItem.Text!="Please Select" && dbl_city.SelectedItem.Text!="Please Select" && dbl_gender.SelectedItem.Text!="Please Select")
            {
                GenerateId();

                if (upld_photo.PostedFile != null && upld_photo.PostedFile.FileName != "")
                {
                    string imgName = upld_photo.FileName.ToString();
                    string extension = Path.GetExtension(upld_photo.FileName);
                    upld_photo.SaveAs(Server.MapPath("upload/delivery-boy-photo/") + imgName +lbl_id.Text + extension);

                    //sets the image path
                    string imgPath = "upload/delivery-boy-photo/" + imgName + lbl_id.Text + extension;

                    int success = bnc.Add_Delivery_Boy(lbl_id.Text,txt_name.Text,txt_email.Text,txt_mobileno.Text,dbl_gender.SelectedValue,txt_address_line_1.Text,"",dbl_state.SelectedValue,dbl_state.SelectedItem.Text,dbl_city.SelectedValue,dbl_city.SelectedItem.Text,txt_pincode.Text,enc.Encrypted(txt_password.Text),imgPath,DateTime.Now.ToString("yyyy-MM-dd"),DateTime.Now.ToString("hh:mm tt"),dbl_status.SelectedValue);

                    if(success>0)
                    {
                        ShowMessage("Delivery boy has been saved.",MessageType.Success);

                        Response.Redirect("delivery-boy-document.aspx?ref="+lbl_id.Text+"&type=new");

                    }

                }
                else
                {
                    int success = bnc.Add_Delivery_Boy(lbl_id.Text, txt_name.Text, txt_email.Text, txt_mobileno.Text, dbl_gender.SelectedValue, txt_address_line_1.Text, "", dbl_state.SelectedValue, dbl_state.SelectedItem.Text, dbl_city.SelectedValue, dbl_city.SelectedItem.Text, txt_pincode.Text, enc.Encrypted(txt_password.Text), "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm tt"), dbl_status.SelectedValue);

                    if (success > 0)
                    {
                        ShowMessage("Delivery boy has been saved.", MessageType.Success);

                        Response.Redirect("delivery-boy-document.aspx?ref=" + lbl_id.Text + "&type=new");
                    }
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
}