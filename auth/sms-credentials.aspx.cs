using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class auth_sms_credentials : System.Web.UI.Page
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
            SqlDataReader get_data = mst.Select_Operation("Select * from ecommerce_sms");
            if (get_data.Read())
            {
                txt_email.Text = get_data["sms_user_name"].ToString();
                txt_hash_key.Text = get_data["sms_hash"].ToString();
                txt_sender_name.Text = get_data["sms_sender"].ToString();
            }

            get_data.Close();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txt_sender_name.Text.Length>0 && txt_hash_key.Text.Length>0 && txt_email.Text.Length>0)
            {
                int count = mst.Count_data("Select Count(id) from ecommerce_sms");

                if(count>0)
                {
                    int update = bnc.Update_SMS_Api(txt_email.Text,txt_hash_key.Text,txt_sender_name.Text);

                    if(update>0)
                    {
                        ShowMessage("SMS Credentials has been updated.",MessageType.Success);
                    }
                }
                else
                {
                    int success = bnc.Add_SMS_Api("Text Local",txt_email.Text, txt_hash_key.Text, txt_sender_name.Text);

                    if (success > 0)
                    {
                        ShowMessage("SMS Credentials has been saved.", MessageType.Success);
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