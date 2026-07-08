using System;
using System.Data.SqlClient;
using System.IO;
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

    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (upldfile.PostedFile != null && upldfile.PostedFile.FileName != "")
            {
                SqlDataReader dr_delete_file = mst.Select_Operation("Select integration_path from ecommerce_integration where integration_title='Google Webmaster'");
                if (dr_delete_file.Read())
                {
                    var filePath = Server.MapPath(dr_delete_file["integration_path"].ToString());
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                }

                dr_delete_file.Close();

                SqlDataReader delete_old_file = mst.Delete_Operation("Delete from ecommerce_integration where integration_title='Google Webmaster'");
                delete_old_file.Close();

                string fileName = upldfile.FileName.ToString();
                string extension = Path.GetExtension(upldfile.FileName);
                upldfile.SaveAs(Server.MapPath("../") + fileName + extension);

                //sets the image path
                string imgPath =  fileName + extension;

                int success = bnc.Add_Google_inetration("Google Webmaster", imgPath,"");

                if(success>0)
                {
                    ShowMessage("Google Webmaster has been uploded.", MessageType.Success);
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