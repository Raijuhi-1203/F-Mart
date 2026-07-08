using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

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
        string customer_id = getuserid();
        if (email.Text.Length > 0 && password.Text.Length > 0 && fullName.Text.Length > 0)
        {
            con.Open();
            string get_query = "Select * from ecommerce_customer where customer_email='" + email.Text + "'";
            SqlCommand get_cmd = new SqlCommand(get_query, con);
            SqlDataReader get_data = get_cmd.ExecuteReader();
            if (get_data.Read())
            {
                ShowMessage("Already have an account Please login!", MessageType.Error);
                
            }
            else
            {
                get_data.Close();
                con.Close();

                con.Open();
                string get_query1 = "insert into ecommerce_customer (customer_time,customer_date,customer_status,customer_id,customer_name,customer_email,customer_password) values ('"+DateTime.Now.ToString("HH:mm:ss")+ "','"+DateTime.Now.ToString("yyyy/MM/dd")+ "','Active','"+ customer_id + "','"+ fullName.Text + "','"+ email.Text +"','"+ Encrypted(password.Text) +"')";
                SqlCommand get_cmd1 = new SqlCommand(get_query1, con);
                SqlDataReader get_data1 = get_cmd1.ExecuteReader();
                
                get_data1.Close();
                con.Close();

                con.Open();
                string get_query2 = "select * from ecommerce_customer where customer_email='" + email.Text + "'";
                SqlCommand get_cmd2 = new SqlCommand(get_query2, con);
                SqlDataReader get_data2 = get_cmd2.ExecuteReader();
                UserID = get_data2["customer_id"].ToString();
                Name = get_data2["customer_name"].ToString();
                Contactno = get_data2["customer_mobileno"].ToString();
                Cemail = get_data2["customer_email"].ToString();
                user_type = get_data2["customer_gender"].ToString();
                string sessionId = HttpContext.Current.Session.SessionID;
                Password = get_data2["customer_password"].ToString();
                pincode = get_data2["customer_status"].ToString();

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


    public string getuserid()
    {
        string id = "";
        try
        {


            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT MAX(customer_temp_id) as customer_temp_id FROM ecommerce_customer";
                #endregion
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int i = 1;
                while (rdr.Read())
                {
                    string tempidplus = rdr["customer_temp_id"].ToString();
                    string tempid = Convert.ToString(Convert.ToInt32(tempidplus) + 1);
                    id = DateTime.Now.Year + "0" + DateTime.Now.Month + Convert.ToString(tempid);
                }
            }

        }
        catch (Exception ex)
        {
            string text = "My text that I want to display";

        }
        return id;
    }


}