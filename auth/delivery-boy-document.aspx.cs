using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_delivery_boy_document : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    DeliveryBoy bnc = new DeliveryBoy();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString[1].ToString()=="new")
            {
                lnk_skip.Visible = true;
                lnk_skip.HRef = "manage-delivery-boy";
            }
           else
            {
                lnk_skip.Visible = false;
            }

            BindData();
        }
    }

    private void BindData()
    {
        rptbind_document.DataSource = mst.GetData("SELECT * FROM delivery_boy_document where delivery_boy_id='" + Request.QueryString[0] + "' order by id asc");
        rptbind_document.DataBind();
    }


    protected void rptbind_document_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lbl_rowdeleteid = (Label)rptbind_document.Items[e.Item.ItemIndex].FindControl("lbl_rowdeleteid");

            SqlDataReader dr_delete_photo = mst.Select_Operation("Select * from delivery_boy_document where id='" + lbl_rowdeleteid.Text + "'");
            if (dr_delete_photo.Read())
            {
                var filePath = Server.MapPath(dr_delete_photo["document_path"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                dr_delete_photo.Close();
            }

            SqlDataReader dr_delete_data = mst.Delete_Operation("delete from delivery_boy_document where id='" + lbl_rowdeleteid.Text + "'");
            dr_delete_data.Close();

            ShowMessage("Delete operation success.", MessageType.Success);

            BindData();
        }
    }

    protected void btnsaveAndnext_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (upld_document.PostedFile != null && upld_document.PostedFile.FileName != "")
            {
                foreach (HttpPostedFile postedFile in upld_document.PostedFiles)
                {
                    string imgName = postedFile.FileName.ToString();
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("upload/delivery-boy-document/") + imgName + Request.QueryString[0] + extension);

                    //sets the image path
                    string imgPath = "upload/delivery-boy-document/" + imgName + Request.QueryString[0] + extension;

                    int success = bnc.Add_delivery_boy_document(Request.QueryString[0],txt_title.Text,imgPath);

                    if(success>0)
                    {
                        ShowMessage("Document has been saved.",MessageType.Success);
                    }

                }

                BindData();
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