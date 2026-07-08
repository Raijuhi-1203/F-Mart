using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_delivery_boy : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    DeliveryBoy bnc = new DeliveryBoy();
    Encrypt enc = new Encrypt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_delivery_boy order by id asc");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btnenable"))
        {
            Label lblrowenableid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowenableid");

            int success = bnc.Update_delivery_boy_Status("Active", lblrowenableid.Text);

            if (success > 0)
            {
                ShowMessage("Status has been changed.", MessageType.Success);
            }

            con.Close();

            BindData();

        }


        if (e.CommandName.Equals("btndisable"))
        {
            Label lbldisablerowid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldisablerowid");

            int success = bnc.Update_delivery_boy_Status("Deactive", lbldisablerowid.Text);

            if (success > 0)
            {
                ShowMessage("Status has been changed.", MessageType.Success);
            }

            con.Close();

            BindData();
        }

        if (e.CommandName.Equals("btndelete"))
        {
            Label lbldeletedelivery_boy_id = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldeletedelivery_boy_id");


            SqlDataReader get_photo = mst.Select_Operation("Select delivery_boy_photo from ecommerce_delivery_boy where delivery_boy_id='" + lbldeletedelivery_boy_id.Text + "' ");
            if (get_photo.Read())
            {
                var filePath = Server.MapPath(get_photo["delivery_boy_photo"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            get_photo.Close();

            SqlDataReader dr_delete_boy = mst.Delete_Operation("delete from ecommerce_delivery_boy where delivery_boy_id='" + lbldeletedelivery_boy_id.Text + "'");
            dr_delete_boy.Close();

            SqlDataReader get_document = mst.Select_Operation("Select document_path from delivery_boy_document where delivery_boy_id='" + lbldeletedelivery_boy_id.Text + "' ");
            while (get_document.Read())
            {
                var filePath = Server.MapPath(get_document["document_path"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            get_document.Close();

            SqlDataReader dr_delete_boy_document = mst.Delete_Operation("delete from delivery_boy_document where delivery_boy_id='" + lbldeletedelivery_boy_id.Text + "'");
            dr_delete_boy_document.Close();


            SqlDataReader dr_delete_pincode = mst.Delete_Operation("delete from delivery_boy_serviced_pincode where delivery_boy_id='" + lbldeletedelivery_boy_id.Text + "'");
            dr_delete_pincode.Close();

            ShowMessage("Delete operation success.", MessageType.Success);

            BindData();
        }
    }


    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl_delivery_boy_password = (Label)e.Item.FindControl("lbl_delivery_boy_password");
            Label lbl_password = (Label)e.Item.FindControl("lbl_password");

            lbl_password.Text = enc.Decrypted(lbl_delivery_boy_password.Text);
        }
    }
}