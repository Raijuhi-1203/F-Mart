using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_sub_service : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Product pdt = new Product();
    Backend bnc = new Backend();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
   
    private void BindData()
    {
        this.rptbinddata.DataSource = GetData("SELECT * FROM ecommerce_category where main_category_id='" + Request.QueryString[0] + "' order by id desc");
        this.rptbinddata.DataBind();
    }

    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btnenable"))
        {
            Label lblrowenableid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblrowenableid");


            con.Open();

            string update_status = "update ecommerce_category set category_status=@category_status where category_id=@category_id";
            SqlCommand cmd_status = new SqlCommand(update_status, con);

            cmd_status.Parameters.AddWithValue("@category_status", "Enable");
            cmd_status.Parameters.AddWithValue("@category_id", lblrowenableid.Text);

            int success = cmd_status.ExecuteNonQuery();

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


            con.Open();

            string update_status = "update ecommerce_category set category_status=@category_status where category_id=@category_id";
            SqlCommand cmd_status = new SqlCommand(update_status, con);

            cmd_status.Parameters.AddWithValue("@category_status", "Disable");
            cmd_status.Parameters.AddWithValue("@category_id", lbldisablerowid.Text);

            int success = cmd_status.ExecuteNonQuery();

            if (success > 0)
            {
                ShowMessage("Status has been changed.", MessageType.Success);
            }

            con.Close();

            BindData();

        }



        if (e.CommandName.Equals("btndelete"))
        {


            Label lbldeletecategoryid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldeletecategoryid");

            con.Open();
            string query_delete_photo = "Select * from ecommerce_category where category_id='" + lbldeletecategoryid.Text + "'";
            SqlCommand cmd_delete_photo = new SqlCommand(query_delete_photo, con);
            SqlDataReader dr_delete_photo = cmd_delete_photo.ExecuteReader();

            if (dr_delete_photo.Read())
            {
                var filePath = Server.MapPath(dr_delete_photo["category_photo"].ToString());
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                dr_delete_photo.Close();
            }

            // Main Category Delete

            string query_delete_service = "delete from ecommerce_category where category_id='" + lbldeletecategoryid.Text + "'";
            SqlCommand cmd_delete_service = new SqlCommand(query_delete_service, con);
            SqlDataReader dr_delete_service = cmd_delete_service.ExecuteReader();

            dr_delete_service.Close();

            // Sub Category Delete

            string query_delete_sub_service = "delete from ecommerce_category where main_category_id='" + lbldeletecategoryid.Text + "'";
            SqlCommand cmd_delete_sub_service = new SqlCommand(query_delete_sub_service, con);
            SqlDataReader dr_delete_sub_service = cmd_delete_sub_service.ExecuteReader();
            dr_delete_sub_service.Close();

            con.Close();
            ShowMessage("Delete operation success.", MessageType.Success);

            BindData();
        }



        if (e.CommandName.Equals("btnaddmainsubcategory"))
        {
            Label lblmainsubcategoryid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lblmainsubcategoryid");

            TextBox txttitle = (TextBox)rptbinddata.Items[e.Item.ItemIndex].FindControl("txttitle");


            if (txttitle.Text.Length > 0)
            {
                int category_exist = pdt.Check_Category_name(txttitle.Text);

                if (category_exist > 0)
                {
                    ShowMessage("Category already exist.", MessageType.Error);
                }
                else
                {
                    con.Open();

                    string insert_category = "insert into ecommerce_category(category_temp_id,category_id,category_name,main_sub_category_id,category_status) values (@category_temp_id,@category_id,@category_name,@main_sub_category_id,@category_status)";
                    SqlCommand cmd_category = new SqlCommand(insert_category, con);

                    cmd_category.Parameters.AddWithValue("@category_temp_id", lblcategoryidtemp.Text);
                    cmd_category.Parameters.AddWithValue("@category_id", lblcategoryid.Text);
                    cmd_category.Parameters.AddWithValue("@category_name", txttitle.Text);
                    cmd_category.Parameters.AddWithValue("@main_sub_category_id", lblmainsubcategoryid.Text);

                    cmd_category.Parameters.AddWithValue("@category_status", "Yes");

                    int success = cmd_category.ExecuteNonQuery();
                    if (success > 0)
                    {
                        ShowMessage("Category has been saved.", MessageType.Success);

                        txttitle.Text = string.Empty;

                        BindData();
                    }
                    else
                    {
                        ShowMessage("Something went wrong.", MessageType.Warning);
                    }

                }
            }
            else
            {
                ShowMessage("All field are required.", MessageType.Error);
            }

        }

    }

    protected void txt_point_TextChanged(object sender, EventArgs e)
    {
        TextBox txt_point = (TextBox)sender;

        Label lbl_category_id = (Label)txt_point.Parent.FindControl("lbl_category_id");

        if(txt_point.Text.Length>0)
        {
            int update_point = bnc.Update_Category_Point(txt_point.Text, lbl_category_id.Text);

            if(update_point>0)
            {
                ShowMessage("Point updated.",MessageType.Success);
            }
        }
    }
}