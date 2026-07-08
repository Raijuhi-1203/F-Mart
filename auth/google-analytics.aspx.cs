using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class auth_google_analytics : System.Web.UI.Page
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
            SqlDataReader get_data = mst.Select_Operation("Select tracking_code from ecommerce_integration where integration_title='Google Analytics'");
            if(get_data.Read())
            {
                txt_tracking_code.Text = get_data["tracking_code"].ToString();
            }

            get_data.Close();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txt_tracking_code.Text.Length>0)
            {
                int count = mst.Count_data("Select Count(id) from ecommerce_integration where integration_title='Google Analytics' ");

                if(count>0)
                {
                    int success = bnc.Update_Google_inetration(txt_tracking_code.Text, "Google Analytics");

                    if (success > 0)
                    {
                        ShowMessage("Google Analytics has been updated.", MessageType.Success);
                    }
                }
                else
                {
                    int success = bnc.Add_Google_inetration("Google Analytics", "", txt_tracking_code.Text);

                    if (success > 0)
                    {
                        ShowMessage("Google Analytics has been install.", MessageType.Success);
                    }
                }
            }
            else
            {
                ShowMessage("Please choose file.",MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }
}