using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;


public partial class gesture_login : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Warning };
    Encrypt ob = new Encrypt();
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    string Name, UserID, Password, Contactno, email,pincode,user_type;
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
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

    
    protected void btnlogin_ServerClick(object sender, EventArgs e)
    {
        if(txtemail.Text.Length>0 && txtpassword.Text.Length>0)
        {
            con.Open();
            string get_query = "Select * from ecommerce_backend where backend_email='" + txtemail.Text + "'";
            SqlCommand get_cmd = new SqlCommand(get_query, con);
            SqlDataReader get_data = get_cmd.ExecuteReader();
            if (get_data.Read())
            {
                UserID = get_data["id"].ToString();

                Name = get_data["backend_name"].ToString();
                Contactno = get_data["backend_mobileno"].ToString();
                email = get_data["backend_email"].ToString();
                user_type = get_data["backend_role"].ToString();
                string sessionId = HttpContext.Current.Session.SessionID;
                Password = get_data["backend_password"].ToString();
                pincode = get_data["vendor_pincode"].ToString();

                // string pass = ob.Decrypted(Password);
                if (email == txtemail.Text && Password == txtpassword.Text)
                {
                    Session["id"] = UserID;

                    Session["backend_name"] = Name;
                    Session["backend_mobileno"] = Contactno;
                    Session["backend_email"] = email;
                    Session["backend_role"] = user_type;
                    Session["vendor_pincode"] = pincode;

                   if(user_type=="Admin")
                    {
                        Response.Redirect("dashboard.aspx");
                    }
                   else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                else
                {
                    ShowMessage("Invalid User Name or Password! Please try again!", MessageType.Error);
                }

            }
            else
            {
                ShowMessage("Invalid User Name or Password! Please try again!", MessageType.Error);
            }
        }
        else
        {
            ShowMessage("Please enter Email and Password.",MessageType.Error);
        }
       
    }
}