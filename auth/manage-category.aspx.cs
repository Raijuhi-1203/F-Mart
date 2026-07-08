using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_service : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }


    private void BindData()
    {
       rptbinddata.DataSource = GetData("SELECT * FROM ecommerce_category where main_category_id='0' AND category_type='Grocery' order by category_orderno asc");
        rptbinddata.DataBind();
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

            string update_status = "Update ecommerce_category set category_status=@category_status where category_id=@category_id";
            SqlCommand cmd_status = new SqlCommand(update_status, con);

            cmd_status.Parameters.AddWithValue("@category_status", "Yes");
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

            cmd_status.Parameters.AddWithValue("@category_status", "No");
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
    }
}