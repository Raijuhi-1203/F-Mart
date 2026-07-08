using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class auth_manage_product_position : System.Web.UI.Page
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
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Dropdown();", true);

        if (!IsPostBack)
        {
            BindCategory();
        }
    }



    void PopulateGridview()
    {
        DataTable dtbl = new DataTable();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT id,product_id,product_full_name,product_postion_no FROM ecommerce_product where product_sub_category_id='"+dblsubcategory.SelectedValue+"' order by id asc";
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



    protected void grdproducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
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


        }
    }


    private void BindCategory()
    {
        dblparentcategory.Items.Clear();
        dblparentcategory.Items.Add(new ListItem("Please Select", "0"));
        dblparentcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where main_category_id=@main_category_id";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@main_category_id", "0");
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblparentcategory.DataSource = cmd.ExecuteReader();
            dblparentcategory.DataTextField = "category_name";
            dblparentcategory.DataValueField = "category_id";
            dblparentcategory.DataBind();
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


    private void BindSubCategory()
    {
        dblsubcategory.Items.Clear();
        dblsubcategory.Items.Add(new ListItem("Please Select", "0"));
        dblsubcategory.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT [category_name], [category_id] FROM [ecommerce_category] where main_category_id=@main_category_id";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@main_category_id", dblparentcategory.SelectedValue);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblsubcategory.DataSource = cmd.ExecuteReader();
            dblsubcategory.DataTextField = "category_name";
            dblsubcategory.DataValueField = "category_id";
            dblsubcategory.DataBind();
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

    protected void dblparentcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubCategory();
    }



    protected void dblsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dblsubcategory.SelectedItem.Text!="Please Select")
        {
            PopulateGridview();
        }
        else
        {
            ShowMessage("Please select sub category.",MessageType.Error);
        }


    }

    protected void txt_position_no_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)txt.Parent.Parent;
        Label lblproductid = (Label)(gvr.FindControl("lblproductid"));

        TextBox txt_position_no = (TextBox)(gvr.FindControl("txt_position_no"));

        if (txt_position_no.Text.Length > 0)
        {
            SqlDataReader check_data = mst.Select_Operation("Select product_full_name from ecommerce_product where product_postion_no='" + txt_position_no.Text + "' AND product_sub_category_id='" + dblsubcategory.SelectedValue + "' ");
            if (check_data.Read())
            {
                ShowMessage("Position already assign to " + check_data["product_full_name"], MessageType.Warning);
            }
            else
            {
                int success = bnc.Update_Product_postion_no(lblproductid.Text, txt_position_no.Text);

                if(success>0)
                {
                    lbl_success.Text="Position Updated.";
                }
            }
        }
    }
}