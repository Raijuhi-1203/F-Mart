using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlDataReader Product_Price_Info(string product_id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from ecommerce_product_price where product_id=@product_id order by product_final_sell_price asc";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@product_id", product_id);
            reader = cmd.ExecuteReader();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    public SqlDataReader Product_Price_Info_id(string id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from ecommerce_product_price where id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            reader = cmd.ExecuteReader();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Product Information

    public SqlDataReader Product_Info(string product_id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from ecommerce_product where product_id=@product_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@product_id", product_id);
            reader = cmd.ExecuteReader();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Product photo

    public SqlDataReader Product_Photos(string product_id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from ecommerce_product_photos where product_id=@product_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@product_id", product_id);
            reader = cmd.ExecuteReader();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    public int Update_BastSellingStatus(string productid, string status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set best_selling_status=@best_selling_status where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@best_selling_status", status);
            cmd.Parameters.AddWithValue("@product_id", productid);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Product Top Offer Basket

    public int Update_TopOfferStatus(string productid, string status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set offer_product_status=@offer_product_status where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@offer_product_status", status);
            cmd.Parameters.AddWithValue("@product_id", productid);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Check Same Name Category

    public int Check_Category_name(string categoryname)
    {
        con.Close();
        con.Open();
        int data = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Count(id) from ecommerce_category where category_name=@category_name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@category_name", categoryname);
            data = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (data);
    }

    // Check Same Name Product

    public int Check_Product_name(string productname)
    {
        con.Close();
        con.Open();
        int data = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Count(id) from ecommerce_product where product_full_name=@product_full_name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@product_full_name", productname);
            data = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (data);
    }

   // product Viwed Count

    public int Update_Product_viewed(string product_id, string no_of_viewed)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set no_of_viewed=@no_of_viewed where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@no_of_viewed", no_of_viewed);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


}