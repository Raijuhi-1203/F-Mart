using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;


public partial class auth_return_policy : System.Web.UI.Page
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
            SqlDataReader get_data = mst.Select_Operation("SELECT * FROM ecommerce_return_privacy");
            if (get_data.Read())
            {
                txtreturnpolicy.Text = get_data["return_information"].ToString();

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
        if (txtreturnpolicy.Text.Length > 0)
        {
            try
            {
                int success = bnc.Add_Return_Policy(txtreturnpolicy.Text);
                if (success > 0)
                {
                    ShowMessage("Return Policy has been saved.", MessageType.Success);

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
        if (txtreturnpolicy.Text.Length > 0)
        {
            int success = bnc.Edit_Return_policy(txtreturnpolicy.Text);
            if (success > 0)
            {
                ShowMessage("Return Policy has been updated.", MessageType.Success);
            }
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }
}