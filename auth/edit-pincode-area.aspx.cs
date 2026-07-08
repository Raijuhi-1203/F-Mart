using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_edit_pincode_area : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            BindState();

            SqlDataReader getData = mst.Select_Operation("Select * from ecommerce_pincode Where id='" + Request.QueryString[0] + "' ");
            if (getData.Read())
            {
                txtpincode.Text = getData["pincode"].ToString();
                txt_area.Text = getData["area"].ToString();
                dblstate.SelectedValue = getData["state_name"].ToString();

                BindCity();

                dblcity.SelectedValue = getData["city_name"].ToString();

            }

            getData.Close();
        }
    }

    private void BindState()
    {
        dblstate.Items.Clear();
        dblstate.Items.Add(new ListItem("Please Select", ""));
        dblstate.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "select id,state_name from ecommerce_state Order by state_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblstate.DataSource = cmd.ExecuteReader();
            dblstate.DataTextField = "state_name";
            dblstate.DataValueField = "state_name";
            dblstate.DataBind();
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

    private void BindCity()
    {
        dblcity.Items.Clear();
        dblcity.Items.Add(new ListItem("Please Select", ""));
        dblcity.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT  district_name FROM ecommerce_city where state_id='" + dblstate.SelectedValue + "' order by district_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblcity.DataSource = cmd.ExecuteReader();
            dblcity.DataTextField = "district_name";
            dblcity.DataValueField = "district_name";
            dblcity.DataBind();
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

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string mobilenopattern = "^[0-9]{6}Rs. ";

            if (txtpincode.Text.Length > 0 && dblcity.SelectedItem.Text != "Please Select" && dblstate.SelectedItem.Text != "Please Select" && txt_area.Text.Length > 0)
            {
                if (Regex.IsMatch(txtpincode.Text, mobilenopattern))
                {
                    int success = bnc.Edit_Pincode_Area(dblstate.SelectedItem.Text, dblcity.SelectedValue, txtpincode.Text, txt_area.Text, Request.QueryString[0]);

                    if (success > 0)
                    {
                        ShowMessage("Pincode has been updated.", MessageType.Success);
                    }
                }
                else
                {
                    ShowMessage("Please check pincode.", MessageType.Error);
                }
            }
            else
            {
                ShowMessage("All field are required.", MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }


   
}