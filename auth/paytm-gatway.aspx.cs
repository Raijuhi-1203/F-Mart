using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class auth_paytm_gatway : System.Web.UI.Page
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
        if(!IsPostBack)
        {
            SqlDataReader get_data = mst.Select_Operation("Select api_key,secret_key from ecommerce_payment_mode where payment_mode='Paytm'");
            if(get_data.Read())
            {
                txt_merchant_key.Text = get_data["api_key"].ToString();
                txt_mid.Text = get_data["secret_key"].ToString();
            }

            get_data.Close();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(txt_merchant_key.Text.Length>0 && txt_mid.Text.Length>0)
            {
                int success = bnc.Update_Payment_Api(txt_merchant_key.Text,txt_mid.Text,"Yes", "Paytm");

                if(success>0)
                {
                    ShowMessage("Api keys has been saved.",MessageType.Success);
                }
            }
            else
            {
                ShowMessage("All field are required.",MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }
}