using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class changepassword : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Warning };
    Encrypt ob = new Encrypt();
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txtcurrentpassword.Text.Length>0 && txtnewpassword.Text.Length>0)
            {
                string Querycheck = "Select backend_password from ecommerce_backend where id='" + Session["id"] + "'";
                con.Open();
                SqlCommand cmdcheck = new SqlCommand(Querycheck, con);
                SqlDataReader drcheck = cmdcheck.ExecuteReader();
                if (drcheck.Read())
                {
                    if (ob.Decrypted(drcheck["backend_password"].ToString()) == txtcurrentpassword.Text)
                    {

                        drcheck.Close();
                        string updatepassword = "UPDATE ecommerce_backend SET backend_password='" + ob.Encrypted(txtnewpassword.Text) + "' where id='" + Session["id"] + "'";
                        SqlCommand updatecmdpassword = new SqlCommand(updatepassword, con);
                        SqlDataReader updateaddedpassword = updatecmdpassword.ExecuteReader();
                        ShowMessage("Password has been Changed.", MessageType.Success);
                        con.Close();
                    }
                    else
                    {
                        ShowMessage("Current Password does not match. Please try again...", MessageType.Error);
                    }
                }
            }
            else
            {
                ShowMessage("Current Password & New Password is required.", MessageType.Error);
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
}