using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_product_to_section : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSection();
        }
    }



    void PopulateGridview()
    {
        DataTable dtbl = new DataTable();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT id,section_id,product_id FROM ecommerce_section_product where seller_id='1' AND section_id='" + dblsection.SelectedValue+"' order by id asc";
        cmd.Connection = con;
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
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

    protected void grdproducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdproducts.PageIndex = e.NewPageIndex;
        PopulateGridview();
    }

    protected void grdproducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblproductid = (Label)e.Row.FindControl("lblproductid");

            Label lblproductname = (Label)e.Row.FindControl("lblproductname");
            Label lblcategoryname = (Label)e.Row.FindControl("lblcategoryname");


            SqlDataReader get_product_data = mst.Select_Operation("Select product_full_name,product_parent_category_name,product_sub_category_name from ecommerce_product where product_id='" + lblproductid.Text+"' ");
            if(get_product_data.Read())
            {
                lblproductname.Text = get_product_data["product_full_name"].ToString();
                lblcategoryname.Text = get_product_data["product_parent_category_name"].ToString();
            }

            get_product_data.Close();


        }
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        LinkButton lnkdel = (LinkButton)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)lnkdel.NamingContainer; // get the GridViewRow that contains the linkbutton

        lbldeleteproductid.Text = lnkdel.CommandArgument;

        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Rs. ('#Del').modal()", true);//show the modal
    }

    protected void lnkdelete_ServerClick(object sender, EventArgs e)
    {
        // Delete Item

        SqlDataReader delete_item = mst.Delete_Operation("delete from ecommerce_section_product where product_id='"+ lbldeleteproductid.Text+ "' ");
        delete_item.Close();

        ShowMessage("Delete operation has been success.", MessageType.Error);
    }


    private void BindSection()
    {
        dblsection.Items.Clear();
        dblsection.Items.Add(new ListItem("Please Select", "0"));
        dblsection.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT id,section_name FROM ecommerce_custom_section order by id asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblsection.DataSource = cmd.ExecuteReader();
            dblsection.DataTextField = "section_name";
            dblsection.DataValueField = "id";
            dblsection.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }



    protected void dblsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dblsection.SelectedItem.Text!="Please Select")
        {
            PopulateGridview();
        }
        else
        {
            ShowMessage("Please Select Section.",MessageType.Error);
        }
    }

    protected void btndelete_ServerClick(object sender, EventArgs e)
    {
        int i = 0;
        foreach (GridViewRow row in grdproducts.Rows)
        {
            if ((row.FindControl("chk_delete") as CheckBox).Checked)
            {
                SqlDataReader delete_item = mst.Delete_Operation("delete from ecommerce_section_product where product_id='" + (row.FindControl("lblproductid") as Label).Text + "' ");
                delete_item.Close();

                i++;
            }
        }

        if(i>0)
        {
            ShowMessage("Delete operation success.", MessageType.Success);
        }

        PopulateGridview();
    }
}