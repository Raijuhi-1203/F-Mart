using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;


public partial class auth_privacy_policy : System.Web.UI.Page
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
            SqlDataReader get_data = mst.Select_Operation("SELECT * FROM ecommerce_privacy");
            if (get_data.Read())
            {
                txtprivacy.Text = get_data["privacy_information"].ToString();

                btnsave.Visible = false;
                btnupdate.Visible = true;
            }
            else
            {
                btnupdate.Visible = false;
            }

            get_data.Close();

        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txtprivacy.Text.Length > 0)
        {
            try
            {
                int success = bnc.Add_privacy_policy(txtprivacy.Text);
                if (success > 0)
                {
                    ShowMessage("Privacy Policy has been saved.", MessageType.Success);

                    btnsave.Visible = false;
                    btnupdate.Visible = true;
                }
            }
            catch (SqlException ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
          
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }

    protected void btnupdate_ServerClick(object sender, EventArgs e)
    {
        if (txtprivacy.Text.Length > 0)
        {
            int success = bnc.Edit_privacy_policy(txtprivacy.Text);
            if (success > 0)
            {
                ShowMessage("Privacy Policy has been updated.", MessageType.Success);
            }
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }
}