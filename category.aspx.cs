using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class category : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };
    WebService wb = new WebService();
    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindData2();
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        Page.Title = "Furniture Mart – Explore Furniture by Office, School, Mattress.";
        Page.MetaDescription = "Discover premium furniture by category—office, school, and mattress—at Furniture Mart. Affordable, durable, and designed for modern living.";
        base.OnLoad(e);
    }
    private void BindData()
    {
        rptbinddata.DataSource = mst.GetData("SELECT * FROM ecommerce_category order by id asc");
        rptbinddata.DataBind();
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("category"))
        {
            Label catnm = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("catnm");

            Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where product_parent_category_id='"+ catnm.Text +"'");
            Repeater1.DataBind();

            if (Repeater1.Items.Count == 0)
            {
                NoDataPanel.Visible = true;
            }
            else
            {
                NoDataPanel.Visible = false;
            }

        }

        if (Session["customer_id"] != null)
        {
            if (e.CommandName == "AddCart")
            {
                string product_id = Convert.ToString(e.CommandArgument);
                wb.addtocart("1", Session["customer_id"].ToString(), "", product_id, get_price_id(product_id));
                Response.Write("<script>alert('Product added in cart.');</script>");
                BindData();
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }

       

    }

    private void BindData2()
    {
        Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id");
        Repeater1.DataBind();

        if (Repeater1.Items.Count == 0)
        {
            NoDataPanel.Visible = true;
        }
        else
        {
            NoDataPanel.Visible = false;
        }

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
    }

    protected void rptbinddata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
    }

    protected void cat_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        RepeaterItem rptItem = (RepeaterItem)btn.NamingContainer;
        Label lb = (Label)rptItem.FindControl("catnm");

        Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where product_parent_category_id='" + lb.Text + "'");
        Repeater1.DataBind();

        if (Repeater1.Items.Count == 0)
        {
            NoDataPanel.Visible = true;
        }
        else
        {
            NoDataPanel.Visible = false;
        }

    }

    protected void btnsearch_ServerClick(object sender, EventArgs e)
    {
        Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where a.product_parent_category_name like '%" + productSearch.Text + "%' or  a.product_full_name like '%" + productSearch.Text + "%' or  a.product_short_name like '%" + productSearch.Text + "%'");
        Repeater1.DataBind();

        if (Repeater1.Items.Count == 0)
        {
            NoDataPanel.Visible = true;
        }
        else
        {
            NoDataPanel.Visible = false;
        }
    }

    protected void priceRange_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(priceRange.SelectedValue.ToString() == "10000 to 25000")
        {
            Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where b.product_sell_price between '10000' and '25000'");
            Repeater1.DataBind();

            if (Repeater1.Items.Count == 0)
            {
                NoDataPanel.Visible = true;
            }
            else
            {
                NoDataPanel.Visible = false;
            }
        }
        else if (priceRange.SelectedValue.ToString() == "25000 to 50000")
        {
            Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where b.product_sell_price between '25000' and '50000'");
            Repeater1.DataBind();

            if (Repeater1.Items.Count == 0)
            {
                NoDataPanel.Visible = true;
            }
            else
            {
                NoDataPanel.Visible = false;
            }
        }
        else if (priceRange.SelectedValue.ToString() == "50000 to Above")
        {
            Repeater1.DataSource = mst.GetData("select a.*,b.*,c.* from ecommerce_product a left join ecommerce_product_price as b on a.product_id=b.product_id left join ecommerce_product_photos as c on a.product_id=c.product_id where b.product_sell_price > '50000'");
            Repeater1.DataBind();

            if (Repeater1.Items.Count == 0)
            {
                NoDataPanel.Visible = true;
            }
            else
            {
                NoDataPanel.Visible = false;
            }
        }
        
        
        
    }

    private string get_price_id(string product_id)
    {
        string id = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT id FROM ecommerce_product_price where product_id='" + product_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            int i = 1;
            while (rdr.Read())
            {
                id = rdr["id"].ToString();
            }
        }
        return id;
    }
}