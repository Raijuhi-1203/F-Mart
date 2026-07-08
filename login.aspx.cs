using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class login : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Warning };
    Encrypt ob = new Encrypt();
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    string Name, UserID, Password, Contactno, Cemail, pincode, user_type;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["backend_name"] == null)
            {
                if (Request.Cookies["AdminUserName"] != null && Request.Cookies["AdminPassword"] != null)
                {
                    // Login();
                }
            }
        }
    }


    protected void btnregister_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }

    protected void btnlogin_ServerClick(object sender, EventArgs e)
    {
        if (email.Text.Length > 0 && password.Text.Length > 0)
        {
            con.Open();
            string get_query = "Select * from ecommerce_customer where customer_email='" + email.Text + "'";
            SqlCommand get_cmd = new SqlCommand(get_query, con);
            SqlDataReader get_data = get_cmd.ExecuteReader();
            if (get_data.Read())
            {
                UserID = get_data["customer_id"].ToString();
                Name = get_data["customer_name"].ToString();
                Contactno = get_data["customer_mobileno"].ToString();
                Cemail = get_data["customer_email"].ToString();
                user_type = get_data["customer_gender"].ToString();
                string sessionId = HttpContext.Current.Session.SessionID;
                Password = get_data["customer_password"].ToString();
                pincode = get_data["customer_status"].ToString();

                if (Cemail == email.Text && Password == Encrypted(password.Text))
                {
                    Session["customer_id"] = UserID;
                    Session["customer_name"] = Name;
                    Session["customer_mobileno"] = Contactno;
                    Session["customer_email"] = email;
                    Session["customer_gender"] = user_type;
                    Session["customer_status"] = pincode;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    ShowMessage("Invalid Email or Password! Please try again!", MessageType.Error);
                }

            }
            else
            {
                ShowMessage("Invalid Email or Password! Please try again!", MessageType.Error);
            }
        }
        else
        {
            ShowMessage("Please enter Email and Password.", MessageType.Error);
        }
    }


    public string Encrypted(string clearText)
    {
        try
        {
            string EncryptionKey = "digitalbull@@1234";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }

    }

    public string Decrypted(string cipherText)
    {
        try
        {
            string EncryptionKey = "digitalbull@@1234";
            cipherText = cipherText.Replace(' ', '+');
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {

                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {

                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Decode" + ex.Message);
        }

    }

}