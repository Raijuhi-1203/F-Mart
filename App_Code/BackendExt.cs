using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BackendExt
/// </summary>
public class BackendExt
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public BackendExt()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Update_Product_Variend(string attribute_value_1, string attribute_value_2, string attribute_value_3,string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set attribute_value_1=@attribute_value_1,attribute_value_2=@attribute_value_2,attribute_value_3=@attribute_value_3 Where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@attribute_value_1", SqlDbType.NVarChar).Value = attribute_value_1;
            cmd.Parameters.AddWithValue("@attribute_value_2", SqlDbType.NVarChar).Value = attribute_value_2;
            cmd.Parameters.AddWithValue("@attribute_value_3", SqlDbType.NVarChar).Value = attribute_value_3;
           
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Product_Shop(string shop_name,string product_id, string product_name, string create_date)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into product_shop(shop_name,product_id,product_name,create_date) values (@shop_name,@product_id,@product_name,@create_date)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@shop_name", SqlDbType.NVarChar).Value = shop_name;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@product_name", SqlDbType.NVarChar).Value = product_name;
            cmd.Parameters.AddWithValue("@create_date", SqlDbType.NVarChar).Value = create_date;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Product_Shop_Name(string new_shop_name, string shop_name)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update product_shop Set shop_name=@new_shop_name Where shop_name=@shop_name";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@new_shop_name", SqlDbType.NVarChar).Value = new_shop_name;
            cmd.Parameters.AddWithValue("@shop_name", SqlDbType.NVarChar).Value = shop_name;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

}