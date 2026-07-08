using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_city : System.Web.UI.Page
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
            BindState();
        }
    }

    private void BindData()
    {
        rpt_data.DataSource = mst.GetData("SELECT id,state_name,state_id FROM ecommerce_state order by state_name asc");
        rpt_data.DataBind();
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
            dblstate.DataValueField = "id";
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


    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if(dblstate.SelectedItem.Text!="Please Select" && txt_city.Text.Length>0)
            {
                int check = mst.Count_data("Select Count(id) from ecommerce_city Where id='"+dblstate.SelectedValue+ "' AND district_name='"+txt_city.Text+"' ");

                if(check>0)
                {
                    ShowMessage("City already in database.",MessageType.Error);

                    txt_city.Focus();
                }
                else
                {
                    int success = bnc.Add_City(dblstate.SelectedValue,txt_city.Text);

                    if(success>0)
                    {
                        ShowMessage("City has been saved.",MessageType.Success);

                        txt_city.Text = string.Empty;
                        txt_city.Focus();

                    }
                }
            }
            else
            {
                ShowMessage("All * field are required.",MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message,MessageType.Error);
        }
    }



}