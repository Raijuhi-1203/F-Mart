using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_user : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    Encrypt ob = new Encrypt();
    public enum MessageType { Success, Error, Info, Qarning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
        }
    }
    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txtname.Text.Length > 0 && txtemail.Text.Length>0 && txtmobileno.Text.Length>0 && txtpassword.Text.Length>0)
        {
            try
            {
                string insert_query = "insert into ecommerce_backend(backend_name,backend_email,backend_mobileno,backend_role,backend_password,vendor_pincode) values (@backend_name,@backend_email,@backend_mobileno,@backend_role,@backend_password,@vendor_pincode) ";
                con.Open();
                SqlCommand insert_cmd = new SqlCommand(insert_query, con);

                insert_cmd.Parameters.AddWithValue("@backend_name",txtname.Text);
                insert_cmd.Parameters.AddWithValue("@backend_email",txtemail.Text);
                insert_cmd.Parameters.AddWithValue("@backend_mobileno",txtmobileno.Text);
                insert_cmd.Parameters.AddWithValue("@backend_role",dblrole.SelectedValue);
                insert_cmd.Parameters.AddWithValue("@backend_password",ob.Encrypted(txtpassword.Text));
                insert_cmd.Parameters.AddWithValue("@vendor_pincode", txtpincode.Text);


                int success = insert_cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    ShowMessage("User has been saved.", MessageType.Success);
                }
            }
            catch (SqlException ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Success);
        }
    }
    
}