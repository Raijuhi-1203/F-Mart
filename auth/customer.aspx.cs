using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_customer : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Encrypt enc = new Encrypt();
    Backend bnc = new Backend();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Data();
            mst.PopulateGridview(lbl_query.Text, grd_data);
        }
    }

    private void Bind_Data()
    {
        lbl_query.Text = "Select * from ecommerce_customer where customer_date Like N'%" + txt_search.Text + "%' OR customer_name Like N'%" + txt_search.Text + "%' OR  customer_mobileno Like N'%" + txt_search.Text + "%' OR customer_email Like N'%" + txt_search.Text + "%' OR customer_password Like N'%" + txt_search.Text + "%' OR customer_id Like N'%" + txt_search.Text + "%'  Order by id desc ";
    }

    protected void btnsearch_ServerClick(object sender, EventArgs e)
    {
        if (txt_search.Text.Length > 0)
        {
            Bind_Data();
            mst.PopulateGridview(lbl_query.Text, grd_data);
        }
        else
        {
            ShowMessage("Please enter search term.", MessageType.Error);
        }
    }

    protected void btnalldata_ServerClick(object sender, EventArgs e)
    {
        txt_search.Text = string.Empty;

        Bind_Data();
        mst.PopulateGridview(lbl_query.Text, grd_data);
    }

    protected void grd_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_data.PageIndex = e.NewPageIndex;
        mst.PopulateGridview(lbl_query.Text, grd_data);
    }

    protected void grd_data_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_customer_password = (Label)e.Row.FindControl("lbl_customer_password");
            Label lbl_password = (Label)e.Row.FindControl("lbl_password");

            lbl_password.Text = enc.Decrypted(lbl_customer_password.Text);
        }
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        LinkButton lnkdel = (LinkButton)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)lnkdel.NamingContainer; // get the GridViewRow that contains the linkbutton

        lbl_delete_row_id.Text = lnkdel.CommandArgument;

        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Rs. ('#Del').modal()", true);//show the modal
    }

    protected void lnkdelete_ServerClick(object sender, EventArgs e)
    {
        // Delete

        SqlDataReader dr_delete_order = mst.Delete_Operation("delete from ecommerce_order where customer_id='" + lbl_delete_row_id.Text + "'");
        dr_delete_order.Close();


        SqlDataReader dr_delete_customer = mst.Delete_Operation("delete from ecommerce_customer where customer_id='" + lbl_delete_row_id.Text + "'");
        dr_delete_customer.Close();


        SqlDataReader dr_delete_address = mst.Delete_Operation("delete from ecommerce_customer_address where customer_id='" + lbl_delete_row_id.Text + "'");
        dr_delete_address.Close();

        ShowMessage("Data has been deleted.", MessageType.Success);

        Bind_Data();
        mst.PopulateGridview(lbl_query.Text, grd_data);
    }



    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        LinkButton lnkStatus = (LinkButton)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)lnkStatus.NamingContainer; // get the GridViewRow that contains the linkbutton

        lbl_edit_customer_id.Text = lnkStatus.CommandArgument;

        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Rs. ('#status').modal()", true);//show the modal
    }

    protected void btnUpdateStatus_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int saveStatus = bnc.Update_Customer_Status(dblstatus.SelectedValue,lbl_edit_customer_id.Text);

            if(saveStatus>0)
            {
                ShowMessage("Status has been updated.",MessageType.Success);

                Bind_Data();
                mst.PopulateGridview(lbl_query.Text, grd_data);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }
}