using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;


public partial class auth_terms_and_contditions : System.Web.UI.Page
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
            con.Open();
            string get_query = "SELECT * FROM ecommerce_terms_condition";
            SqlCommand get_cmd = new SqlCommand(get_query, con);
            SqlDataReader get_data = get_cmd.ExecuteReader();

            if (get_data.Read())
            {
                txtterms.Text = get_data["terms_condition_information"].ToString();

                btnsave.Visible = false;
                btnupdate.Visible = true;
            }
            else
            {
                btnupdate.Visible = false;
            }

            get_data.Close();

            con.Close();
        }
    }


    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txtterms.Text.Length > 0)
        {
            try
            {
                con.Close();
                con.Open();
                string Query = "insert into ecommerce_terms_condition(terms_condition_information) values (@terms_condition_information) ";
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@terms_condition_information", SqlDbType.NVarChar).Value = txtterms.Text;

                int added = cmd.ExecuteNonQuery();
                if (added > 0)
                {
                    ShowMessage("Terms and Conditions has been saved.", MessageType.Success);

                    btnsave.Visible = false;
                    btnupdate.Visible = true;
                }

                
            }
            catch (SqlException ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }

    protected void btnupdate_ServerClick(object sender, EventArgs e)
    {
        if (txtterms.Text.Length > 0)
        {
            string Query = "Update ecommerce_terms_condition Set terms_condition_information=@terms_condition_information ";
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@terms_condition_information", SqlDbType.NVarChar).Value = txtterms.Text;

            int added = cmd.ExecuteNonQuery();

            if (added > 0)
            {
                ShowMessage("Terms and Conditions has been updated.", MessageType.Success);
            }
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Error);
        }
    }
}