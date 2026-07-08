using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_edit_delivery_boy : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    DeliveryBoy bnc = new DeliveryBoy();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
            Bind_State();

            SqlDataReader get_data = mst.Select_Operation("Select * from ecommerce_delivery_boy where  delivery_boy_id='"+Request.QueryString[0]+"' ");
            if(get_data.Read())
            {
                txt_address_line_1.Text = get_data["delivery_boy_address_line_1"].ToString();
                txt_email.Text = get_data["delivery_boy_email"].ToString();
                txt_mobileno.Text = get_data["delivery_boy_mobileno"].ToString();
                txt_name.Text = get_data["delivery_boy_name"].ToString();
                txt_pincode.Text = get_data["delivery_boy_pincode"].ToString();

                dbl_status.SelectedValue = get_data["delivery_boy_status"].ToString();
                dbl_state.SelectedValue = get_data["delivery_boy_state_id"].ToString();

                Bind_City();

                dbl_city.SelectedValue = get_data["delivery_boy_city_id"].ToString();
                dbl_gender.SelectedValue = get_data["delivery_boy_gender"].ToString();

                delivery_boy_photo.Src = get_data["delivery_boy_photo"].ToString();

            }

            get_data.Close();
        }
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


    protected void btnbasicupdate_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txt_address_line_1.Text.Length > 0 && txt_mobileno.Text.Length > 0 && txt_name.Text.Length > 0 && txt_pincode.Text.Length > 0 && dbl_state.SelectedItem.Text != "Please Select" && dbl_city.SelectedItem.Text != "Please Select" && dbl_gender.SelectedItem.Text != "Please Select")
            {
                int success = bnc.Edit_Delivery_Boy(txt_name.Text,txt_email.Text,txt_mobileno.Text,dbl_gender.SelectedValue,txt_address_line_1.Text,"",dbl_state.SelectedValue,dbl_state.SelectedItem.Text,dbl_city.SelectedValue,dbl_city.SelectedItem.Text,txt_pincode.Text,dbl_status.SelectedValue,Request.QueryString[0]);

                if(success>0)
                {
                    ShowMessage("Data has been updated.",MessageType.Error);
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

    protected void btnupdatephoto_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (upld_photo.PostedFile != null && upld_photo.PostedFile.FileName != "")
            {
                SqlDataReader dr_delete_document = mst.Select_Operation("Select delivery_boy_photo from ecommerce_delivery_boy where delivery_boy_id='" + Request.QueryString[0] + "'  ");
                if (dr_delete_document.Read())
                {
                    var filePath = Server.MapPath(dr_delete_document["delivery_boy_photo"].ToString());
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                dr_delete_document.Close();


                string imgName = upld_photo.FileName.ToString();
                string extension = Path.GetExtension(upld_photo.FileName);
                upld_photo.SaveAs(Server.MapPath("upload/delivery-boy-photo/") + imgName + Request.QueryString[0] + extension);

                //sets the image path
                string imgPath = "upload/delivery-boy-photo/" + imgName + Request.QueryString[0].ToString() + extension;

                int success_photo = bnc.Update_delivery_boy_photo(imgPath, Request.QueryString[0].ToString());

                if (success_photo > 0)
                {
                    ShowMessage("Photo has been saved.", MessageType.Success);
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
        rptbind_document.DataSource = mst.GetData("SELECT * FROM delivery_boy_document where delivery_boy_id='" + Request.QueryString[0] + "' order by id asc");
        rptbind_document.DataBind();
    }

    protected void rptbind_document_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lbl_rowdeleteid = (Label)rptbind_document.Items[e.Item.ItemIndex].FindControl("lbl_rowdeleteid");

            SqlDataReader dr_delete_photo = mst.Select_Operation("Select * from delivery_boy_document where id='" + lbl_rowdeleteid.Text + "'");
            if (dr_delete_photo.Read())
            {
                var filePath = Server.MapPath(dr_delete_photo["document_path"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                dr_delete_photo.Close();
            }

            SqlDataReader dr_delete_data = mst.Delete_Operation("delete from delivery_boy_document where id='" + lbl_rowdeleteid.Text + "'");
            dr_delete_data.Close();

            ShowMessage("Delete operation success.", MessageType.Success);

            BindData();
        }
    }
}