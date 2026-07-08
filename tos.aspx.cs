using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tos : System.Web.UI.Page
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

            }
            get_data.Close();
            con.Close();
        }
    }
}