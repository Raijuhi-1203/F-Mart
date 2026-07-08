using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class auth_manage_product : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
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
            PopulateGridview();
        }
    }

    void PopulateGridview()
    {
        DataTable dtbl = new DataTable();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT id,product_id,food_type,product_full_name,product_parent_category_name,publish_status FROM ecommerce_product where product_type='Restaurant' AND (product_short_name LIKE '%' + @search + '%' OR product_full_name LIKE '%' + @search + '%' OR product_description LIKE '%' + @search + '%' OR food_type LIKE '%' + @search + '%' OR product_parent_category_name LIKE '%' + @search + '%') order by id asc";
        cmd.Connection = con;
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@search", txtsearch.Text.Trim());
        sqlDa.Fill(dtbl);
        if (dtbl.Rows.Count > 0)
        {
            grdproducts.DataSource = dtbl;
            grdproducts.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            grdproducts.DataSource = dtbl;
            grdproducts.DataBind();

            grdproducts.Rows[0].Cells.Clear();
            grdproducts.Rows[0].Cells.Add(new TableCell());
            grdproducts.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            grdproducts.Rows[0].Cells[0].Text = "No Data Found ..!";
            grdproducts.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }


        con.Close();

    }

    protected void lnkdelete_ServerClick(object sender, EventArgs e)
    {
        // Product Photos delete

        con.Open();
        string query_delete_photo = "Select * from ecommerce_product_photos where product_id='" + lbldeleteproductid.Text + "'";
        SqlCommand cmd_delete_photo = new SqlCommand(query_delete_photo, con);
        SqlDataReader dr_delete_photo = cmd_delete_photo.ExecuteReader();
        if (dr_delete_photo.Read())
        {
            var filePath = Server.MapPath(dr_delete_photo["photo_path"].ToString());
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        dr_delete_photo.Close();

        string query_delete_photo_data = "delete from ecommerce_product_photos where product_id='" + lbldeleteproductid.Text + "'";
        SqlCommand cmd_delete_photo_data = new SqlCommand(query_delete_photo_data, con);
        SqlDataReader dr_delete_photo_data = cmd_delete_photo_data.ExecuteReader();

        dr_delete_photo_data.Close();

        // Product price delete

        string query_delete_price = "delete from ecommerce_product_price where product_id='" + lbldeleteproductid.Text + "'";
        SqlCommand cmd_delete_price = new SqlCommand(query_delete_price, con);
        SqlDataReader dr_delete_price = cmd_delete_price.ExecuteReader();
        dr_delete_price.Close();


        // Product delete

        string query_delete_product = "delete from ecommerce_product where product_id='" + lbldeleteproductid.Text + "'";
        SqlCommand cmd_delete_product = new SqlCommand(query_delete_product, con);
        SqlDataReader dr_delete_product = cmd_delete_product.ExecuteReader();
        dr_delete_product.Close();

        con.Close();
        ShowMessage("Delete operation success.", MessageType.Success);

        PopulateGridview();
    }

    protected void grdproducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblpublishstatus = (Label)e.Row.FindControl("lblpublishstatus");

         
            // Photo get

            Label lblproductid = e.Row.FindControl("lblproductid") as Label;
            HtmlImage item_photo = (HtmlImage)e.Row.FindControl("item_photo");

            con.Close();
            con.Open();

            string get_photo = "select * from ecommerce_product_photos where product_id='" + lblproductid.Text + "' order by id asc ";
            SqlCommand cmd_get_photo = new SqlCommand(get_photo, con);
            SqlDataReader dr_get_photo = cmd_get_photo.ExecuteReader();

            if (dr_get_photo.Read())
            {
                item_photo.Src = dr_get_photo["photo_path"].ToString();
            }

            dr_get_photo.Close();

            con.Close();

            // Color of status
            string publish_status_value = lblpublishstatus.Text;
            switch (publish_status_value)
            {
                case "No":

                    lblpublishstatus.ForeColor = Color.Red;

                    break;

                case "Yes":

                    lblpublishstatus.ForeColor = Color.Green;

                    break;
            }

        }
    }

    protected void grdproducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdproducts.PageIndex = e.NewPageIndex;
        PopulateGridview();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        grdproducts.PageIndex = e.NewPageIndex;
        PopulateGridview();
    }

    protected void btnsearch_ServerClick(object sender, EventArgs e)
    {
        this.PopulateGridview();
    }

    protected void btnalldata_ServerClick(object sender, EventArgs e)
    {
        txtsearch.Text = string.Empty;
        this.PopulateGridview();
    }

    protected void grdproducts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (!string.IsNullOrEmpty(txtsearch.Text))
        //{
        //    msg.Text = "Found " + grdproducts.Rows.Count + " rows.";
        //}
       
    }

    protected void link_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)link.NamingContainer; // get the GridViewRow that contains the linkbutton

        lblrowproductid.Text = link.CommandArgument;

        Label lblpublishstatus = (Label)row.FindControl("lblpublishstatus");

        dblavailableforsale.SelectedValue = lblpublishstatus.Text;  
      

        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Rs. ('#Status').modal()", true);//show the modal
    }

    protected void btnchangestatus_Click(object sender, EventArgs e)
    {
        con.Open();

        string update_status = "update ecommerce_product set publish_status=@publish_status where product_id=@product_id";
        SqlCommand cmd_status = new SqlCommand(update_status, con);

        cmd_status.Parameters.AddWithValue("@publish_status", dblavailableforsale.SelectedValue);
        cmd_status.Parameters.AddWithValue("@product_id", lblrowproductid.Text);

        int success = cmd_status.ExecuteNonQuery();

        if (success > 0)
        {
            ShowMessage("Status has been changed.", MessageType.Success);
        }

        con.Close();

        PopulateGridview();
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        LinkButton lnkdel = (LinkButton)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)lnkdel.NamingContainer; // get the GridViewRow that contains the linkbutton

        lbldeleteproductid.Text = lnkdel.CommandArgument;
    
        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Rs. ('#Del').modal()", true);//show the modal
    }

    protected void btndelete_ServerClick(object sender, EventArgs e)
    {
        int i = 0;

        foreach (GridViewRow row in grdproducts.Rows)
        {
            if ((row.FindControl("chk_delete") as CheckBox).Checked)
            {
                SqlDataReader dr_delete_photo = mst.Select_Operation("Select * from ecommerce_product_photos where product_id='" + (row.FindControl("lblproductid") as Label).Text + "'");

                if (dr_delete_photo.Read())
                {
                    var filePath = Server.MapPath(dr_delete_photo["photo_path"].ToString());
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                }
                dr_delete_photo.Close();


                SqlDataReader dr_delete_photo_data = mst.Delete_Operation("delete from ecommerce_product_photos where product_id='" + (row.FindControl("lblproductid") as Label).Text + "'");
                dr_delete_photo_data.Close();

                // Product price delete
                SqlDataReader dr_delete_price = mst.Delete_Operation("delete from ecommerce_product_price where product_id='" + (row.FindControl("lblproductid") as Label).Text + "'");
                dr_delete_price.Close();

                // Product delete

                SqlDataReader dr_delete_product = mst.Delete_Operation("delete from ecommerce_product where product_id='" + (row.FindControl("lblproductid") as Label).Text + "'");
                dr_delete_product.Close();

                i++;
            }
        }

        if (i > 0)
        {
            ShowMessage("Delete operation success.", MessageType.Success);
        }

        PopulateGridview();
    }

}