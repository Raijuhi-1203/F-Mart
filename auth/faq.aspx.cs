using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_faq : System.Web.UI.Page
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
            BindData();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txtdescription.Text.Length > 0 && txttitle.Text.Length>0)
        {
            try
            {

                int success = bnc.Add_Faq(txttitle.Text,txtdescription.Text);
                if (success > 0)
                {
                    ShowMessage("FAQ has been saved.", MessageType.Success);

                    txtdescription.Text = string.Empty;
                    txttitle.Text = string.Empty;

                    BindData();
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

    private void BindData()
    {
         rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_faq order by id desc");
         rptbinddata.DataBind();
    }

  


    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lbliddelete = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbliddelete");
           
          
            SqlDataReader delete_faq = mst.Delete_Operation("delete from ecommerce_faq where id='" + lbliddelete.Text + "'");
            delete_faq.Close();

            ShowMessage("FAQ has been deleted.", MessageType.Success);

            BindData();
        }
    }
}