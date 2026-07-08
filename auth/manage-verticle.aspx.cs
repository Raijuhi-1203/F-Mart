using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_verticle : System.Web.UI.Page
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

    private void BindData()
    {
         rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_verticle order by id desc");
         rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName.Equals("btnenable"))
        {
            Label lblrowenableid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowenableid");
            int success = bnc.Edit_Verticle_Status("Yes", lblrowenableid.Text);
            if (success > 0)
            {
                ShowMessage("Status has been changed.", MessageType.Success);
            }

            BindData();

        }


        if (e.CommandName.Equals("btndisable"))
        {
            Label lbldisablerowid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldisablerowid");

            int success = bnc.Edit_Verticle_Status("No", lbldisablerowid.Text);
            if (success > 0)
            {
                ShowMessage("Status has been changed.", MessageType.Success);
            }

            BindData();

        }



        if (e.CommandName.Equals("btndelete"))
        {
            Label lbldeletecategoryid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldeletecategoryid");

            // Main Category Delete

            SqlDataReader delete_verticle = mst.Delete_Operation("delete from ecommerce_verticle where id='" + lbldeletecategoryid.Text + "'");
            delete_verticle.Close();
           
            ShowMessage("Delete operation success.", MessageType.Success);

            BindData();
        }
    }

    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbl_category_id = (Label)e.Item.FindControl("lbl_category_id");
            Label lbl_sub_category_id = (Label)e.Item.FindControl("lbl_sub_category_id");

            Label lbl_category_name = (Label)e.Item.FindControl("lbl_category_name");

            SqlDataReader main_category = mst.Select_Operation("Select category_name from ecommerce_category where category_id='"+ lbl_category_id.Text + "' ");
            if(main_category.Read())
            {
                lbl_category_name.Text = main_category["category_name"].ToString();
            }

            main_category.Close();


            SqlDataReader sub_category = mst.Select_Operation("Select category_name from ecommerce_category where category_id='" + lbl_sub_category_id.Text + "' ");
            if (sub_category.Read())
            {
                lbl_category_name.Text = lbl_category_name.Text+" > "+ sub_category["category_name"].ToString();
            }

            sub_category.Close();
        }
    }
}