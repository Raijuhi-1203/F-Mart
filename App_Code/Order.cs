using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class Order
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public Order()
    {
        
    }

    public String GetReturnNoItems(String customerid)
    {
        con.Close();
        con.Open();
        String cart_item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_order where customer_id=@customer_id AND order_status=@order_status";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@order_status", "Cancelled");
            cart_item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (cart_item_no);
    }


   
    // Get Cart No Guest End


    // Get Cart No Guest

    public String GetCartNoItems_guest(String guestid)
    {
        con.Close();
        con.Open();
        String cart_item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_cart where cart_guest_id=@cart_guest_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cart_guest_id", guestid);
            cart_item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (cart_item_no);
    }

    // Get Cart No Guest End


    // Get Cart No


    public String GetCartNoItems(String customerid)
    {
        con.Close();
        con.Open();
        String cart_item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_cart where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cart_item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (cart_item_no);
    }

    // Get Cart No End



    // Get Wishlist No


    public String GetWishlistNoItems(String customerid)
    {
        con.Close();
        con.Open();
        String wishlist_item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_wishlist where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            wishlist_item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (wishlist_item_no);
    }

    // Get Wishlist No End


    // Get Order exist

    public void Update_Stock2(string order_id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select product_price_id from ecommerce_order where order_id=@order_id";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@order_id", order_id);
        SqlDataReader reader = cmd.ExecuteReader();
        int count = reader.FieldCount;
        //List<string> list = new List<string>();
        List<List<String>> list = new List<List<String>>();
        while (reader.Read())
        {
            var rec = new List<string>();
            for (int i = 0; i <= reader.FieldCount - 1; i++) //The mathematical formula for reading the next fields must be <=
            {
                rec.Add(reader.GetString(i));
            }
            list.Add(rec);
        }

        foreach (var stringList in list)
        {
            foreach (string aString in stringList)
            {
                string price_id = aString;
                string stock = getstock(price_id);
                //string stock = string.Empty;
                string qty = getqty(price_id, order_id);
                //string qty = string.Empty;

                double a, b, c;
                a = Convert.ToDouble(stock);
                b = Convert.ToDouble(qty);

                if (a > 0)
                {
                    c = a - b;

                    con.Close();
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandText = "update ecommerce_product_price set product_stock=@product_stock where id=@id";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@product_stock", c.ToString());
                    cmd2.Parameters.AddWithValue("@id", price_id);
                    cmd2.ExecuteReader();
                    con.Close();
                }


            }
        }



        con.Close();
    }

    private string getqty(string product_price_id, string order_id)
    {
        string s = string.Empty;
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select product_qty from ecommerce_order where product_price_id=@product_price_id and order_id=@order_id";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@order_id", order_id);
        cmd.Parameters.AddWithValue("@product_price_id", product_price_id);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            s = reader[0].ToString();

        }
        con.Close();
        return s;
    }

    private string getstock(string id)
    {
        string s = string.Empty;
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select product_stock from ecommerce_product_price where id=@id";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            s = reader[0].ToString();

        }
        con.Close();
        return s;
    }


    public String GetOrderexist(String customerid)
    {
        con.Close();
        con.Open();
        String cart_item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_order where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cart_item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (cart_item_no);
    }

    public String GetUploadOrderexist(String customerid)
    {
        con.Close();
        con.Open();
        String cart_item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from upload_order_list where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cart_item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (cart_item_no);
    }

    public String GetOtherItemexist(string order_id)
    {
        con.Close();
        con.Open();
        String cart_item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_order where order_id=@order_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cart_item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (cart_item_no);
    }




    // Get Wishlist Item have or no


    public String GetWishlistItemStatus(String customerid,string productid,string priceid)
    {
        con.Close();
        con.Open();
        String status = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_wishlist where customer_id=@customer_id AND product_id=@product_id AND product_price_id=@product_price_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@product_id",productid);
            cmd.Parameters.AddWithValue("@product_price_id",priceid);
            status = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (status);
    }

    // Get Wishlist Item have or no End




    // Cart no Generate

    public SqlDataReader Generate_Cart_No()
    {
       
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Top 1 Max(cart_no) as cart_no FROM ecommerce_cart Group BY cart_no ORDER BY cart_no DESC";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Cart no Generate End


    // Get Order Info

    public SqlDataReader Get_Order_info(string suborderid)
    {
    
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ecommerce_order where id=@id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", suborderid);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }


    public SqlDataReader Get_Upload_Order_info(string order_id)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM upload_order_list where order_id=@order_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", order_id);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }






    // Get Order Info

    public SqlDataReader Get_Order_info_by_Order_id(string orderid)
    {
      
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ecommerce_order where order_id=@order_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Order Info End


    // Order Id Generate

    public SqlDataReader Generate_Order_id()
    {
       
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Top 1 Max(order_id_temp) as order_id_temp FROM ecommerce_order Group BY order_id_temp ORDER BY order_id_temp DESC";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Order Id Generate End


   

    // Subscription Id Generate End


    // Sub Order Id Generate

    public SqlDataReader Generate_Sub_Order_id()
    {
       
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Top 1 Max(sub_order_id_temp) as sub_order_id_temp FROM ecommerce_order Group BY sub_order_id_temp ORDER BY sub_order_id_temp DESC";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Sub Order Id Generate End


    // Wishlist no Generate

    public SqlDataReader Generate_Wishlist_No()
    {
      
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Top 1 Max(wishlist_no) as wishlist_no FROM ecommerce_wishlist Group BY wishlist_no ORDER BY wishlist_no DESC";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Wishlist no Generate End


    //========================================================= Guest Order =========================================================//


    // Insert Data into Cart Guest

    public int Insert_Cart_product_Guest(string cart_no, string cart_date, string cart_qty, string guest_id, string product_id, string priceid)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_cart(cart_no,cart_date,cart_qty,cart_guest_id,product_id,product_price_id) values (@cart_no,@cart_date,@cart_qty,@cart_guest_id,@product_id,@product_price_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@cart_no", cart_no);
            cmd.Parameters.AddWithValue("@cart_date", cart_date);
            cmd.Parameters.AddWithValue("@cart_qty", cart_qty);
            cmd.Parameters.AddWithValue("@cart_guest_id", guest_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@product_price_id", priceid);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Insert Data into Order Guest

    public int Insert_Order_product_Guest(int sub_order_id_temp, string sub_order_id, int cart_no, string guest_id, string product_id, string product_name, string product_hsn_sac, int product_qty, string product_unit, string product_unit_value, string product_GST_type, string product_tax_type, decimal product_GST_percentage, decimal product_GST_rate, decimal product_CGST_percentage, decimal product_CGST_rate, decimal product_SGST_percentage, decimal product_SGST_rate, decimal product_market_price, decimal product_sell_price, decimal product_discount_percentage, decimal product_discount_price, decimal product_with_gst_Price, decimal product_final_sell_price, int product_shipping_charge, decimal total_amount_of_product, string total_market_price,string super_point, string product_price_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_order(sub_order_id_temp,sub_order_id,cart_no,guest_id,product_id,product_name,product_hsn_sac,product_qty,product_unit,product_unit_value,product_GST_type,product_tax_type,product_GST_percentage,product_GST_rate,product_CGST_percentage,product_CGST_rate,product_SGST_percentage,product_SGST_rate,product_market_price,product_sell_price,product_discount_percentage,product_discount_price,product_with_gst_Price,product_final_sell_price,product_shipping_charge,total_amount_of_product,total_market_price,super_point,product_price_id) values (@sub_order_id_temp,@sub_order_id,@cart_no,@guest_id,@product_id,@product_name,@product_hsn_sac,@product_qty,@product_unit,@product_unit_value,@product_GST_type,@product_tax_type,@product_GST_percentage,@product_GST_rate,@product_CGST_percentage,@product_CGST_rate,@product_SGST_percentage,@product_SGST_rate,@product_market_price,@product_sell_price,@product_discount_percentage,@product_discount_price,@product_with_gst_Price,@product_final_sell_price,@product_shipping_charge,@total_amount_of_product,@total_market_price,@super_point,@product_price_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@sub_order_id_temp", sub_order_id_temp);
            cmd.Parameters.AddWithValue("@sub_order_id", sub_order_id);

            cmd.Parameters.AddWithValue("@cart_no", cart_no);
            cmd.Parameters.AddWithValue("@guest_id", guest_id);

            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_hsn_sac", product_hsn_sac);
            cmd.Parameters.AddWithValue("@product_qty", product_qty);

            cmd.Parameters.AddWithValue("@product_unit", product_unit);
            cmd.Parameters.AddWithValue("@product_unit_value", product_unit_value);

            cmd.Parameters.AddWithValue("@product_GST_type", product_GST_type);
            cmd.Parameters.AddWithValue("@product_tax_type", product_tax_type);

            cmd.Parameters.AddWithValue("@product_GST_percentage", product_GST_percentage);
            cmd.Parameters.AddWithValue("@product_GST_rate", product_GST_rate);

            cmd.Parameters.AddWithValue("@product_CGST_percentage", product_CGST_percentage);
            cmd.Parameters.AddWithValue("@product_CGST_rate", product_CGST_rate);

            cmd.Parameters.AddWithValue("@product_SGST_percentage", product_SGST_percentage);
            cmd.Parameters.AddWithValue("@product_SGST_rate", product_SGST_rate);

            cmd.Parameters.AddWithValue("@product_market_price", product_market_price);
            cmd.Parameters.AddWithValue("@product_sell_price", product_sell_price);
            cmd.Parameters.AddWithValue("@product_discount_percentage", product_discount_percentage);
            cmd.Parameters.AddWithValue("@product_discount_price", product_discount_price);
            cmd.Parameters.AddWithValue("@product_with_gst_Price", product_with_gst_Price);
            cmd.Parameters.AddWithValue("@product_final_sell_price", product_final_sell_price);

            cmd.Parameters.AddWithValue("@product_shipping_charge", product_shipping_charge);
            cmd.Parameters.AddWithValue("@total_amount_of_product", total_amount_of_product);

            cmd.Parameters.AddWithValue("@total_market_price", total_market_price);
            cmd.Parameters.AddWithValue("@super_point", super_point);

            cmd.Parameters.AddWithValue("@product_price_id", product_price_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }
   

    //======================================================================= Customer Order =============================================================//


    // Insert Data into Cart Customer

    public int Insert_Cart_product(string cart_no, string cart_date, string cart_qty, string customer_id, string product_id, string priceid)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_cart(cart_no,cart_date,cart_qty,customer_id,product_id,product_price_id) values (@cart_no,@cart_date,@cart_qty,@customer_id,@product_id,@product_price_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@cart_no", SqlDbType.NVarChar).Value = cart_no;
            cmd.Parameters.AddWithValue("@cart_date", SqlDbType.NVarChar).Value = cart_date;
            cmd.Parameters.AddWithValue("@cart_qty", SqlDbType.NVarChar).Value = cart_qty;
            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@product_price_id", priceid);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }
    
    // Insert Data into Order Customer

    public int Insert_Order_product(int sub_order_id_temp, string sub_order_id, int cart_no, string customer_id, string product_id, string product_name, string product_hsn_sac, int product_qty, string product_unit, string product_unit_value, string product_GST_type, string product_tax_type, decimal product_GST_percentage, decimal product_GST_rate, decimal product_CGST_percentage, decimal product_CGST_rate, decimal product_SGST_percentage, decimal product_SGST_rate, decimal product_market_price, decimal product_sell_price, decimal product_discount_percentage, decimal product_discount_price, decimal product_with_gst_Price, decimal product_final_sell_price, int product_shipping_charge, decimal total_amount_of_product, string total_market_price,string super_point, string product_price_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_order(sub_order_id_temp,sub_order_id,cart_no,customer_id,product_id,product_name,product_hsn_sac,product_qty,product_unit,product_unit_value,product_GST_type,product_tax_type,product_GST_percentage,product_GST_rate,product_CGST_percentage,product_CGST_rate,product_SGST_percentage,product_SGST_rate,product_market_price,product_sell_price,product_discount_percentage,product_discount_price,product_with_gst_Price,product_final_sell_price,product_shipping_charge,total_amount_of_product,total_market_price,super_point,product_price_id) values (@sub_order_id_temp,@sub_order_id,@cart_no,@customer_id,@product_id,@product_name,@product_hsn_sac,@product_qty,@product_unit,@product_unit_value,@product_GST_type,@product_tax_type,@product_GST_percentage,@product_GST_rate,@product_CGST_percentage,@product_CGST_rate,@product_SGST_percentage,@product_SGST_rate,@product_market_price,@product_sell_price,@product_discount_percentage,@product_discount_price,@product_with_gst_Price,@product_final_sell_price,@product_shipping_charge,@total_amount_of_product,@total_market_price,@super_point,@product_price_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@sub_order_id_temp", sub_order_id_temp);
            cmd.Parameters.AddWithValue("@sub_order_id", sub_order_id);

            cmd.Parameters.AddWithValue("@cart_no", cart_no);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);

            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_hsn_sac", product_hsn_sac);
            cmd.Parameters.AddWithValue("@product_qty", product_qty);

            cmd.Parameters.AddWithValue("@product_unit", product_unit);
            cmd.Parameters.AddWithValue("@product_unit_value", product_unit_value);

            cmd.Parameters.AddWithValue("@product_GST_type", product_GST_type);
            cmd.Parameters.AddWithValue("@product_tax_type", product_tax_type);

            cmd.Parameters.AddWithValue("@product_GST_percentage", product_GST_percentage);
            cmd.Parameters.AddWithValue("@product_GST_rate", product_GST_rate);

            cmd.Parameters.AddWithValue("@product_CGST_percentage", product_CGST_percentage);
            cmd.Parameters.AddWithValue("@product_CGST_rate", product_CGST_rate);

            cmd.Parameters.AddWithValue("@product_SGST_percentage", product_SGST_percentage);
            cmd.Parameters.AddWithValue("@product_SGST_rate", product_SGST_rate);


            cmd.Parameters.AddWithValue("@product_market_price", product_market_price);
            cmd.Parameters.AddWithValue("@product_sell_price", product_sell_price);
            cmd.Parameters.AddWithValue("@product_discount_percentage", product_discount_percentage);
            cmd.Parameters.AddWithValue("@product_discount_price", product_discount_price);
            cmd.Parameters.AddWithValue("@product_with_gst_Price", product_with_gst_Price);
            cmd.Parameters.AddWithValue("@product_final_sell_price", product_final_sell_price);

            cmd.Parameters.AddWithValue("@product_shipping_charge", product_shipping_charge);
            cmd.Parameters.AddWithValue("@total_amount_of_product", total_amount_of_product);

            cmd.Parameters.AddWithValue("@total_market_price", total_market_price);
            cmd.Parameters.AddWithValue("@super_point", super_point);


            cmd.Parameters.AddWithValue("@product_price_id", product_price_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Sub_order_Qty(string product_qty, string product_GST_rate, string product_CGST_rate, string product_SGST_rate, string product_discount_price, string product_final_sell_price, string total_amount_of_product, string product_market_price, string total_market_price, string sub_order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set product_qty=@product_qty,product_GST_rate=@product_GST_rate,product_CGST_rate=@product_CGST_rate,product_SGST_rate=@product_SGST_rate,product_discount_price=@product_discount_price,product_final_sell_price=@product_final_sell_price, total_amount_of_product=@total_amount_of_product,product_market_price=@product_market_price,total_market_price=@total_market_price where id=@id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_qty", product_qty);
            cmd.Parameters.AddWithValue("@product_GST_rate", product_GST_rate);
            cmd.Parameters.AddWithValue("@product_CGST_rate", product_CGST_rate);
            cmd.Parameters.AddWithValue("@product_SGST_rate", product_SGST_rate);
            cmd.Parameters.AddWithValue("@product_discount_price", product_discount_price);
            cmd.Parameters.AddWithValue("@product_final_sell_price", product_final_sell_price);
            cmd.Parameters.AddWithValue("@total_amount_of_product", total_amount_of_product);

            cmd.Parameters.AddWithValue("@product_market_price", product_market_price);
            cmd.Parameters.AddWithValue("@total_market_price", total_market_price);

            cmd.Parameters.AddWithValue("@id", sub_order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Total Amount of cart Guest items

    public String GetTotalAmountCart_Guest(String guestid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(total_amount_of_product),0) from ecommerce_order where guest_id=@guest_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@guest_id", guestid);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

   
    // Total Amount of shipping charge Guest items

    public String GetTotalAmountShipping_Guest(String guestid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(product_shipping_charge),0) from ecommerce_order where guest_id=@guest_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@guest_id", guestid);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

   
    // Total Amount of cart Customer items

    public String GetTotalAmountCart(String customerid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(total_amount_of_product),0) from ecommerce_order where customer_id=@customer_id AND order_status IS NULL";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

    // Total Amount of cart Customer items End

    public String GetTotalAmountShipping(String customerid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(product_shipping_charge),0) from ecommerce_order where customer_id=@customer_id AND order_status IS NULL";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }


    // Total Amount of cart Customer order

    public String GetTotalAmount_Order(String suborderid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(total_amount_of_product),0) from ecommerce_order where sub_order_id=@sub_order_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@sub_order_id", suborderid);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

    // Total Amount of cart Customer order End


    public String GetTotalAmountShipping_Order(String suborderid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(product_shipping_charge),0) from ecommerce_order where sub_order_id=@sub_order_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@sub_order_id", suborderid);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }


    // Insert Data into Wishlist

    public int Insert_Wishlist(string wishlist_no, string wishlist_date, string wishlist_qty, string customer_id, string product_id,string product_price_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_wishlist(wishlist_no,wishlist_date,wishlist_qty,customer_id,product_id,product_price_id) values (@wishlist_no,@wishlist_date,@wishlist_qty,@customer_id,@product_id,@product_price_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@wishlist_no", wishlist_no);
            cmd.Parameters.AddWithValue("@wishlist_date", wishlist_date);
            cmd.Parameters.AddWithValue("@wishlist_qty", wishlist_qty);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@product_price_id", product_price_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Update Order table Cash on delivery Customer

    public int Update_Order_COD_Customer(string order_id_temp,string order_id,string order_date,string order_time,string customer_name,string customer_mobileno,string customer_email,string billing_address_line1,string billing_address_line2,string billing_city_name,string billing_state_name,string billing_pincode,string billing_landmark,string shipping_address_line1,string shipping_address_line2,string shipping_state_name,string shipping_city_name, string shipping_pincode,string shipping_landmark,string total_order_amount,string payment_mode,string order_shipping_status,string order_status,string customer_id,string coupan_value,string coupan_code,string product_shipping_charge, string wallet_payment)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set order_id_temp=@order_id_temp,order_id=@order_id,order_date=@order_date,order_time=@order_time,customer_name=@customer_name,customer_mobileno=@customer_mobileno,customer_email=@customer_email,billing_address_line1=@billing_address_line1,billing_address_line2=@billing_address_line2,billing_city_name=@billing_city_name,billing_state_name=@billing_state_name,billing_pincode=@billing_pincode,billing_landmark=@billing_landmark,shipping_address_line1=@shipping_address_line1,shipping_address_line2=@shipping_address_line2,shipping_state_name=@shipping_state_name,shipping_pincode=@shipping_pincode,shipping_landmark=@shipping_landmark,total_order_amount=@total_order_amount,payment_mode=@payment_mode,order_shipping_status=@order_shipping_status,order_status=@order_status,coupan_value=@coupan_value,coupan_code=@coupan_code,product_shipping_charge=@product_shipping_charge,wallet_payment=@wallet_payment where customer_id=@customer_id AND order_status IS NULL";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_id_temp", order_id_temp);
            cmd.Parameters.AddWithValue("@order_id", order_id);

            cmd.Parameters.AddWithValue("@order_date", order_date);
            cmd.Parameters.AddWithValue("@order_time", order_time);

            cmd.Parameters.AddWithValue("@customer_name", customer_name);
            cmd.Parameters.AddWithValue("@customer_mobileno", customer_mobileno);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);

            cmd.Parameters.AddWithValue("@billing_address_line1", billing_address_line1);
            cmd.Parameters.AddWithValue("@billing_address_line2", billing_address_line2);
            cmd.Parameters.AddWithValue("@billing_city_name", billing_city_name);
            cmd.Parameters.AddWithValue("@billing_state_name", billing_state_name);
            cmd.Parameters.AddWithValue("@billing_pincode", billing_pincode);
            cmd.Parameters.AddWithValue("@billing_landmark", billing_landmark);

            cmd.Parameters.AddWithValue("@shipping_address_line1", shipping_address_line1);
            cmd.Parameters.AddWithValue("@shipping_address_line2", shipping_address_line2);
            cmd.Parameters.AddWithValue("@shipping_city_name", shipping_city_name);
            cmd.Parameters.AddWithValue("@shipping_state_name", shipping_state_name);
            cmd.Parameters.AddWithValue("@shipping_pincode", shipping_pincode);
            cmd.Parameters.AddWithValue("@shipping_landmark", shipping_landmark);

            cmd.Parameters.AddWithValue("@total_order_amount", total_order_amount);
            cmd.Parameters.AddWithValue("@payment_mode", payment_mode);
            cmd.Parameters.AddWithValue("@order_shipping_status", order_shipping_status);
            cmd.Parameters.AddWithValue("@order_status", order_status);

            cmd.Parameters.AddWithValue("@coupan_value", coupan_value);
            cmd.Parameters.AddWithValue("@coupan_code", coupan_code);

            cmd.Parameters.AddWithValue("@product_shipping_charge", product_shipping_charge);
            cmd.Parameters.AddWithValue("@wallet_payment", wallet_payment);

            cmd.Parameters.AddWithValue("@customer_id", customer_id);
           
            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Update Order table Cash on delivery Guest

    public int Update_Order_COD_Guest(string order_id_temp, string order_id, string order_date, string order_time, string customer_name, string customer_mobileno, string customer_email, string billing_address_line1, string billing_address_line2, string billing_city_name, string billing_state_name, string billing_pincode, string billing_landmark, string shipping_address_line1, string shipping_address_line2,string shipping_city_name, string shipping_state_name, string shipping_pincode, string shipping_landmark, string total_order_amount, string payment_mode, string order_shipping_status, string order_status, string guest_id,string coupan_value,string coupan_code)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set order_id_temp=@order_id_temp,order_id=@order_id,order_date=@order_date,order_time=@order_time,customer_name=@customer_name,customer_mobileno=@customer_mobileno,customer_email=@customer_email,billing_address_line1=@billing_address_line1,billing_address_line2=@billing_address_line2,billing_city_name=@billing_city_name,billing_state_name=@billing_state_name,billing_pincode=@billing_pincode,billing_landmark=@billing_landmark,shipping_address_line1=@shipping_address_line1,shipping_address_line2=@shipping_address_line2,shipping_state_name=@shipping_state_name,shipping_pincode=@shipping_pincode,shipping_landmark=@shipping_landmark,total_order_amount=@total_order_amount,payment_mode=@payment_mode,order_shipping_status=@order_shipping_status,order_status=@order_status,coupan_value=@coupan_value,coupan_code=@coupan_code where guest_id=@guest_id AND order_status IS NULL";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_id_temp", order_id_temp);
            cmd.Parameters.AddWithValue("@order_id", order_id);

            cmd.Parameters.AddWithValue("@order_date", order_date);
            cmd.Parameters.AddWithValue("@order_time", order_time);

            cmd.Parameters.AddWithValue("@customer_name", customer_name);
            cmd.Parameters.AddWithValue("@customer_mobileno", customer_mobileno);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);

            cmd.Parameters.AddWithValue("@billing_address_line1", billing_address_line1);
            cmd.Parameters.AddWithValue("@billing_address_line2", billing_address_line2);
            cmd.Parameters.AddWithValue("@billing_city_name", billing_city_name);
            cmd.Parameters.AddWithValue("@billing_state_name", billing_state_name);
            cmd.Parameters.AddWithValue("@billing_pincode", billing_pincode);
            cmd.Parameters.AddWithValue("@billing_landmark", billing_landmark);

            cmd.Parameters.AddWithValue("@shipping_address_line1", shipping_address_line1);
            cmd.Parameters.AddWithValue("@shipping_address_line2", shipping_address_line2);
            cmd.Parameters.AddWithValue("@shipping_city_name", shipping_city_name);
            cmd.Parameters.AddWithValue("@shipping_state_name", shipping_state_name);
            cmd.Parameters.AddWithValue("@shipping_pincode", shipping_pincode);
            cmd.Parameters.AddWithValue("@shipping_landmark", shipping_landmark);

            cmd.Parameters.AddWithValue("@total_order_amount", total_order_amount);
            cmd.Parameters.AddWithValue("@payment_mode", payment_mode);
            cmd.Parameters.AddWithValue("@order_shipping_status", order_shipping_status);
            cmd.Parameters.AddWithValue("@order_status", order_status);

            cmd.Parameters.AddWithValue("@coupan_value", coupan_value);
            cmd.Parameters.AddWithValue("@coupan_code", coupan_code);

            cmd.Parameters.AddWithValue("@guest_id", guest_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Update Order table Online Customer

    public int Update_Order_Online_Customer(string order_id_temp, string order_id, string order_date, string order_time, string customer_name, string customer_mobileno, string customer_email, string billing_address_line1, string billing_address_line2, string billing_city_name, string billing_state_name, string billing_pincode, string billing_landmark, string shipping_address_line1, string shipping_address_line2, string shipping_state_name, string shipping_city_name, string shipping_pincode, string shipping_landmark, string total_order_amount, string payment_mode, string order_shipping_status, string order_status, string customer_id,string transaction_id, string bank_transaction_id, string transaction_status,string transaction_gatway_name,string transaction_payment_mode, string coupan_value, string coupan_code,string product_shipping_charge,string wallet_payment)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set order_id_temp=@order_id_temp,order_id=@order_id,order_date=@order_date,order_time=@order_time,customer_name=@customer_name,customer_mobileno=@customer_mobileno,customer_email=@customer_email,billing_address_line1=@billing_address_line1,billing_address_line2=@billing_address_line2,billing_city_name=@billing_city_name,billing_state_name=@billing_state_name,billing_pincode=@billing_pincode,billing_landmark=@billing_landmark,shipping_address_line1=@shipping_address_line1,shipping_address_line2=@shipping_address_line2,shipping_state_name=@shipping_state_name,shipping_pincode=@shipping_pincode,shipping_landmark=@shipping_landmark,total_order_amount=@total_order_amount,payment_mode=@payment_mode,order_shipping_status=@order_shipping_status,order_status=@order_status,transaction_id=@transaction_id,bank_transaction_id=@bank_transaction_id,transaction_status=@transaction_status,transaction_gatway_name=@transaction_gatway_name,transaction_payment_mode=@transaction_payment_mode,coupan_value=@coupan_value,coupan_code=@coupan_code,product_shipping_charge=@product_shipping_charge,wallet_payment=@wallet_payment where customer_id=@customer_id AND order_status IS NULL";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_id_temp", order_id_temp);
            cmd.Parameters.AddWithValue("@order_id", order_id);

            cmd.Parameters.AddWithValue("@order_date", order_date);
            cmd.Parameters.AddWithValue("@order_time", order_time);

            cmd.Parameters.AddWithValue("@customer_name", customer_name);
            cmd.Parameters.AddWithValue("@customer_mobileno", customer_mobileno);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);

            cmd.Parameters.AddWithValue("@billing_address_line1", billing_address_line1);
            cmd.Parameters.AddWithValue("@billing_address_line2", billing_address_line2);
            cmd.Parameters.AddWithValue("@billing_city_name", billing_city_name);
            cmd.Parameters.AddWithValue("@billing_state_name", billing_state_name);
            cmd.Parameters.AddWithValue("@billing_pincode", billing_pincode);
            cmd.Parameters.AddWithValue("@billing_landmark", billing_landmark);

            cmd.Parameters.AddWithValue("@shipping_address_line1", shipping_address_line1);
            cmd.Parameters.AddWithValue("@shipping_address_line2", shipping_address_line2);
            cmd.Parameters.AddWithValue("@shipping_city_name", shipping_city_name);
            cmd.Parameters.AddWithValue("@shipping_state_name", shipping_state_name);
            cmd.Parameters.AddWithValue("@shipping_pincode", shipping_pincode);
            cmd.Parameters.AddWithValue("@shipping_landmark", shipping_landmark);

            cmd.Parameters.AddWithValue("@total_order_amount", total_order_amount);
            cmd.Parameters.AddWithValue("@payment_mode", payment_mode);
            cmd.Parameters.AddWithValue("@order_shipping_status", order_shipping_status);
            cmd.Parameters.AddWithValue("@order_status", order_status);

            cmd.Parameters.AddWithValue("@transaction_id", transaction_id);
            cmd.Parameters.AddWithValue("@bank_transaction_id", bank_transaction_id);
            cmd.Parameters.AddWithValue("@transaction_status", transaction_status);
            cmd.Parameters.AddWithValue("@transaction_gatway_name", transaction_gatway_name);
            cmd.Parameters.AddWithValue("@transaction_payment_mode", transaction_payment_mode);

            cmd.Parameters.AddWithValue("@coupan_value", coupan_value);
            cmd.Parameters.AddWithValue("@coupan_code", coupan_code);

            cmd.Parameters.AddWithValue("@product_shipping_charge", product_shipping_charge);
            cmd.Parameters.AddWithValue("@wallet_payment", wallet_payment);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Order_Online_Customer_Success(string new_payment_mode, string order_status, string transaction_id, string bank_transaction_id, string transaction_status, string transaction_gatway_name, string transaction_payment_mode, string customer_id, string curr_order_date, string odr_status, string payment_mode)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set payment_mode=@new_payment_mode, order_status=@order_status,transaction_id=@transaction_id,bank_transaction_id=@bank_transaction_id,transaction_status=@transaction_status,transaction_gatway_name=@transaction_gatway_name,transaction_payment_mode=@transaction_payment_mode where customer_id=@customer_id AND order_date=@curr_order_date AND order_status=@odr_status AND payment_mode=@payment_mode";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@new_payment_mode", new_payment_mode);
            cmd.Parameters.AddWithValue("@order_status", order_status);
            cmd.Parameters.AddWithValue("@transaction_id", transaction_id);
            cmd.Parameters.AddWithValue("@bank_transaction_id", bank_transaction_id);
            cmd.Parameters.AddWithValue("@transaction_status", transaction_status);
            cmd.Parameters.AddWithValue("@transaction_gatway_name", transaction_gatway_name);
            cmd.Parameters.AddWithValue("@transaction_payment_mode", transaction_payment_mode);

            cmd.Parameters.AddWithValue("@odr_status", odr_status);
            cmd.Parameters.AddWithValue("@curr_order_date", curr_order_date);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@payment_mode", payment_mode);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Order table Online Guest

    public int Update_Order_Online_Guest(string order_id_temp, string order_id, string order_date, string order_time, string customer_name, string customer_mobileno, string customer_email, string billing_address_line1, string billing_address_line2, string billing_city_name, string billing_state_name, string billing_pincode, string billing_landmark, string shipping_address_line1, string shipping_address_line2, string shipping_city_name, string shipping_state_name, string shipping_pincode, string shipping_landmark, string total_order_amount, string payment_mode, string order_shipping_status, string order_status, string guest_id, string payment_order_id, string transaction_id, string payment_id, string coupan_value, string coupan_code)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set order_id_temp=@order_id_temp,order_id=@order_id,order_date=@order_date,order_time=@order_time,customer_name=@customer_name,customer_mobileno=@customer_mobileno,customer_email=@customer_email,billing_address_line1=@billing_address_line1,billing_address_line2=@billing_address_line2,billing_city_name=@billing_city_name,billing_state_name=@billing_state_name,billing_pincode=@billing_pincode,billing_landmark=@billing_landmark,shipping_address_line1=@shipping_address_line1,shipping_address_line2=@shipping_address_line2,shipping_state_name=@shipping_state_name,shipping_pincode=@shipping_pincode,shipping_landmark=@shipping_landmark,total_order_amount=@total_order_amount,payment_mode=@payment_mode,order_shipping_status=@order_shipping_status,order_status=@order_status,payment_order_id=@payment_order_id,transaction_id=@transaction_id,payment_id=@payment_id,coupan_value=@coupan_value,coupan_code=@coupan_code where guest_id=@guest_id AND order_status IS NULL";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_id_temp", order_id_temp);
            cmd.Parameters.AddWithValue("@order_id", order_id);

            cmd.Parameters.AddWithValue("@order_date", order_date);
            cmd.Parameters.AddWithValue("@order_time", order_time);

            cmd.Parameters.AddWithValue("@customer_name", customer_name);
            cmd.Parameters.AddWithValue("@customer_mobileno", customer_mobileno);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);

            cmd.Parameters.AddWithValue("@billing_address_line1", billing_address_line1);
            cmd.Parameters.AddWithValue("@billing_address_line2", billing_address_line2);
            cmd.Parameters.AddWithValue("@billing_city_name", billing_city_name);
            cmd.Parameters.AddWithValue("@billing_state_name", billing_state_name);
            cmd.Parameters.AddWithValue("@billing_pincode", billing_pincode);
            cmd.Parameters.AddWithValue("@billing_landmark", billing_landmark);

            cmd.Parameters.AddWithValue("@shipping_address_line1", shipping_address_line1);
            cmd.Parameters.AddWithValue("@shipping_address_line2", shipping_address_line2);
            cmd.Parameters.AddWithValue("@shipping_city_name", shipping_city_name);
            cmd.Parameters.AddWithValue("@shipping_state_name", shipping_state_name);
            cmd.Parameters.AddWithValue("@shipping_pincode", shipping_pincode);
            cmd.Parameters.AddWithValue("@shipping_landmark", shipping_landmark);

            cmd.Parameters.AddWithValue("@total_order_amount", total_order_amount);
            cmd.Parameters.AddWithValue("@payment_mode", payment_mode);
            cmd.Parameters.AddWithValue("@order_shipping_status", order_shipping_status);
            cmd.Parameters.AddWithValue("@order_status", order_status);

            cmd.Parameters.AddWithValue("@payment_order_id", payment_order_id);
            cmd.Parameters.AddWithValue("@transaction_id", transaction_id);
            cmd.Parameters.AddWithValue("@payment_id", payment_id);

            cmd.Parameters.AddWithValue("@coupan_value", coupan_value);
            cmd.Parameters.AddWithValue("@coupan_code", coupan_code);

            cmd.Parameters.AddWithValue("@guest_id", guest_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Update Product Stock

    public int Update_Stock(string id, string stock)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product_price Set product_stock=@product_stock where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_stock", stock);
            cmd.Parameters.AddWithValue("@id", id);
           
            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Update order for return

    public int Update_Order_for_return(string suborderid, string reason, string comment,string return_date, string return_time,string order_status,string refund_mode)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set order_return_reason=@order_return_reason,order_return_comment=@order_return_comment,order_cancel_date=@order_cancel_date,order_cancel_time=@order_cancel_time,order_status=@order_status,refund_mode=@refund_mode where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_return_reason",reason);
            cmd.Parameters.AddWithValue("@order_return_comment",SqlDbType.NVarChar).Value= comment;
            cmd.Parameters.AddWithValue("@order_cancel_date", return_date);
            cmd.Parameters.AddWithValue("@order_cancel_time", return_time);
            cmd.Parameters.AddWithValue("@order_status", order_status);
            cmd.Parameters.AddWithValue("@refund_mode", refund_mode);
            cmd.Parameters.AddWithValue("@id", suborderid);


            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Total Amount of Customer order

    public String GetTotalAmountOrder(String orderid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(total_amount_of_product),0) from ecommerce_order where order_id=@order_id AND order_status!=@order_status";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            cmd.Parameters.AddWithValue("@order_status", "Cancelled");
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }


    public String GetTotalAmount_Of_Order(String orderid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(total_amount_of_product),0) from ecommerce_order where order_id=@order_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }



    public String GetTotalAmountSubOrder(string sub_order_id)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(total_amount_of_product),0) from ecommerce_order where sub_order_id=@sub_order_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@sub_order_id", sub_order_id);
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

    // Total Amount of shipping charge Customer order

    public String GetTotalAmountShippingOrder(String orderid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(product_shipping_charge,0) from ecommerce_order where order_id=@order_id AND order_status!=@order_status";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            cmd.Parameters.AddWithValue("@order_status", "Cancelled");
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

    // Total Amount of discount Customer order

    public String GetTotalAmountDiscountOrder(String orderid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(product_discount_price),0) as product_discount_price from ecommerce_order where order_id=@order_id AND order_status!=@order_status";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            cmd.Parameters.AddWithValue("@order_status", "Cancelled");
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

    // Total Amount of discount Customer order

    public String GetTotalAmountGSTOrder(String orderid)
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ISNULL(Sum(product_GST_rate),0) from ecommerce_order where order_id=@order_id AND order_status!=@order_status";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            cmd.Parameters.AddWithValue("@order_status", "Cancelled");
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }

    // Update Order Status

    public int Update_Order_status_Normal_OrderID(string order_id, string status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set order_status=@order_status  where order_id=@order_id AND order_status!=@status";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", status);
            cmd.Parameters.AddWithValue("@status", "Cancelled");

            cmd.Parameters.AddWithValue("@order_id", order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Order_status_Normal(string sub_order_id, string status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set order_status=@order_status  where id=@id AND order_status!=@status";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", status);
            cmd.Parameters.AddWithValue("@status", "Cancelled");

            cmd.Parameters.AddWithValue("@id", sub_order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Update Order Status Deliver

    public int Update_Order_status_Deliver_OrderID(string order_id, string status,string deliverdate,string delivertime)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set order_status=@order_status,order_delivery_date=@order_delivery_date,order_delivery_time=@order_delivery_time where order_id=@order_id AND order_status!=@status";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", status);
            cmd.Parameters.AddWithValue("@order_delivery_date", deliverdate);
            cmd.Parameters.AddWithValue("@order_delivery_time", delivertime);
            cmd.Parameters.AddWithValue("@status", "Cancelled");
            cmd.Parameters.AddWithValue("@order_id", order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Order_status_Deliver(string sub_order_id, string status, string deliverdate, string delivertime)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set order_status=@order_status,order_delivery_date=@order_delivery_date,order_delivery_time=@order_delivery_time where id=@id AND order_status!=@status";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", status);
            cmd.Parameters.AddWithValue("@order_delivery_date", deliverdate);
            cmd.Parameters.AddWithValue("@order_delivery_time", delivertime);
            cmd.Parameters.AddWithValue("@status", "Cancelled");
            cmd.Parameters.AddWithValue("@id", sub_order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Order Status cancel

    public int Update_Order_status_Cancel_OrderID(string order_id, string status, string canceldate, string canceltime)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set order_status=@order_status,order_cancel_date=@order_cancel_date,order_cancel_time=@order_cancel_time where order_id=@order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", status);
            cmd.Parameters.AddWithValue("@order_cancel_date", canceldate);
            cmd.Parameters.AddWithValue("@order_cancel_time", canceltime);

            cmd.Parameters.AddWithValue("@order_id", order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Order_status_Cancel(string sub_order_id, string status, string canceldate, string canceltime)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set order_status=@order_status,order_cancel_date=@order_cancel_date,order_cancel_time=@order_cancel_time where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", status);
            cmd.Parameters.AddWithValue("@order_cancel_date", canceldate);
            cmd.Parameters.AddWithValue("@order_cancel_time", canceltime);

            cmd.Parameters.AddWithValue("@id", sub_order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Get not of items in order

    public String GetNoOfItemsOrder(String orderid)
    {
        con.Close();
        con.Open();
        String item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_order where order_id=@order_id AND order_status!=@order_status";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            cmd.Parameters.AddWithValue("@order_status", "Cancelled");
            item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (item_no);
    }

    public String GetNoOfItemsOrder_cancel(String orderid)
    {
        con.Close();
        con.Open();
        String item_no = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Count(id) from ecommerce_order where order_id=@order_id AND order_status=@order_status";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@order_id", orderid);
            cmd.Parameters.AddWithValue("@order_status", "Cancelled");
            item_no = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (item_no);
    }

    // Convert Session Guest cart to Customer

    public int Convert_Guest_Cart_Item_To_Customer(string guestid, string customerid)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_cart Set customer_id=@customer_id where cart_guest_id=@cart_guest_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@cart_guest_id", guestid);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

   
    public int Convert_Guest_Order_Item_To_Customer(string guestid, string customerid)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set customer_id=@customer_id where guest_id=@guest_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@guest_id", guestid);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

        // if price update

    public int Update_Order_price(string sub_order_id, string product_GST_type, string product_tax_type,string product_GST_percentage,string product_GST_rate,string product_CGST_percentage,string product_CGST_rate,string product_SGST_percentage,string product_SGST_rate,string product_market_price,string product_sell_price,string product_discount_percentage,string product_discount_price,string product_with_gst_Price,string product_final_sell_price,string total_amount_of_product,string super_point)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set product_GST_type=@product_GST_type,product_tax_type=@product_tax_type,product_GST_percentage=@product_GST_percentage,product_GST_rate=@product_GST_rate,product_CGST_percentage=@product_CGST_percentage,product_SGST_percentage=@product_SGST_percentage,product_market_price=@product_market_price,product_sell_price=@product_sell_price,product_discount_percentage=@product_discount_percentage,product_discount_price=@product_discount_price,product_with_gst_Price=@product_with_gst_Price,product_final_sell_price=@product_final_sell_price,total_amount_of_product=@total_amount_of_product,super_point=@super_point where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_GST_type", product_GST_type);
            cmd.Parameters.AddWithValue("@product_tax_type", product_tax_type);
            cmd.Parameters.AddWithValue("@product_GST_percentage", product_GST_percentage);
            cmd.Parameters.AddWithValue("@product_GST_rate", product_GST_rate);
            cmd.Parameters.AddWithValue("@product_CGST_percentage", product_CGST_percentage);
            cmd.Parameters.AddWithValue("@product_CGST_rate", product_CGST_rate);
            cmd.Parameters.AddWithValue("@product_SGST_percentage", product_SGST_percentage);
            cmd.Parameters.AddWithValue("@product_SGST_rate", product_SGST_rate);
            cmd.Parameters.AddWithValue("@product_market_price", product_market_price);
            cmd.Parameters.AddWithValue("@product_sell_price", product_sell_price);
            cmd.Parameters.AddWithValue("@product_discount_percentage", product_discount_percentage);
            cmd.Parameters.AddWithValue("@product_discount_price", product_discount_price);
            cmd.Parameters.AddWithValue("@product_with_gst_Price", product_with_gst_Price);
            cmd.Parameters.AddWithValue("@product_final_sell_price", product_final_sell_price);
            cmd.Parameters.AddWithValue("@total_amount_of_product", total_amount_of_product);
            cmd.Parameters.AddWithValue("@super_point", super_point);

            cmd.Parameters.AddWithValue("@id", sub_order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Get Qty of Same product if item already added in cart 

    public SqlDataReader Get_Qty_Sub_Order_product_Guest(string cart_no,string cart_guest_id,string product_id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "SELECT cart_qty FROM ecommerce_cart where cart_no=@cart_no AND cart_guest_id=@cart_guest_id AND product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@cart_no", cart_no);
            cmd.Parameters.AddWithValue("@cart_guest_id", cart_guest_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            reader = cmd.ExecuteReader();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }
   
    // Get Qty of Same product if item already added in cart 

    public SqlDataReader Get_Qty_Sub_Order_product_Customer(string cart_no, string customer_id, string product_id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "SELECT cart_qty FROM ecommerce_cart where cart_no=@cart_no AND customer_id=@customer_id AND product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@cart_no", cart_no);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            reader = cmd.ExecuteReader();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Get Qty of Same product if item already added in cart  End

    public int Update_Cart_Qty_Guest(string cart_qty, string cart_no, string cart_guest_id, string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_cart Set cart_qty=@cart_qty where cart_no=@cart_no AND cart_guest_id=@cart_guest_id AND product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@cart_qty", cart_qty);

            cmd.Parameters.AddWithValue("@cart_no", cart_no);
            cmd.Parameters.AddWithValue("@cart_guest_id", cart_guest_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Cart_Qty_Customer(string cart_qty, string cart_no, string customer_id, string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_cart Set cart_qty=@cart_qty where cart_no=@cart_no AND customer_id=@customer_id AND product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@cart_qty", cart_qty);

            cmd.Parameters.AddWithValue("@cart_no", cart_no);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    public int Update_Sub_order_Qty(string product_qty,string product_GST_rate,string product_CGST_rate,string product_SGST_rate,string product_discount_price,string product_final_sell_price,  string total_amount_of_product, string sub_order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set product_qty=@product_qty,product_GST_rate=@product_GST_rate,product_CGST_rate=@product_CGST_rate,product_SGST_rate=@product_SGST_rate,product_discount_price=@product_discount_price,product_final_sell_price=@product_final_sell_price, total_amount_of_product=@total_amount_of_product where sub_order_id=@sub_order_id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_qty", product_qty);
            cmd.Parameters.AddWithValue("@product_GST_rate", product_GST_rate);
            cmd.Parameters.AddWithValue("@product_CGST_rate", product_CGST_rate);
            cmd.Parameters.AddWithValue("@product_SGST_rate", product_SGST_rate);
            cmd.Parameters.AddWithValue("@product_discount_price", product_discount_price);
            cmd.Parameters.AddWithValue("@product_final_sell_price", product_final_sell_price);
            cmd.Parameters.AddWithValue("@total_amount_of_product", total_amount_of_product);

            cmd.Parameters.AddWithValue("@sub_order_id", sub_order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public String Get_free_delievry()
    {
        con.Close();
        con.Open();
        String total_amount = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT free_delievry from ecommerce_free_delievry";
            cmd.CommandType = CommandType.Text;
            total_amount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (total_amount);
    }


    public String GetOrderSection(string orderno)
    {
        con.Close();
        con.Open();
        String order_section = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT order_section from [ecom_arshit_food].[ecommerce_order] where order_id='"+orderno+"'";
            cmd.CommandType = CommandType.Text;
            order_section = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (order_section);
    }

    public int Update_Order_Offline_Store(string order_id_temp,string order_id,string order_date,string order_time,string customer_name,string customer_mobileno,string total_order_amount,string payment_mode,string order_shipping_status,string order_status,string customer_id,string coupan_value,string coupan_code,string product_shipping_charge,string guest_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set order_id_temp=@order_id_temp,order_id=@order_id,order_date=@order_date,order_time=@order_time,customer_name=@customer_name,customer_mobileno=@customer_mobileno,customer_id=@customer_id,total_order_amount=@total_order_amount,payment_mode=@payment_mode,order_shipping_status=@order_shipping_status,order_status=@order_status,coupan_value=@coupan_value,coupan_code=@coupan_code,product_shipping_charge=@product_shipping_charge where guest_id=@guest_id AND order_status IS NULL";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_id_temp", order_id_temp);
            cmd.Parameters.AddWithValue("@order_id", order_id);

            cmd.Parameters.AddWithValue("@order_date", order_date);
            cmd.Parameters.AddWithValue("@order_time", order_time);

            cmd.Parameters.AddWithValue("@customer_name", customer_name);
            cmd.Parameters.AddWithValue("@customer_mobileno", customer_mobileno);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);

            cmd.Parameters.AddWithValue("@total_order_amount", total_order_amount);
            cmd.Parameters.AddWithValue("@payment_mode", payment_mode);
            cmd.Parameters.AddWithValue("@order_shipping_status", order_shipping_status);
            cmd.Parameters.AddWithValue("@order_status", order_status);

            cmd.Parameters.AddWithValue("@coupan_value", coupan_value);
            cmd.Parameters.AddWithValue("@coupan_code", coupan_code);

            cmd.Parameters.AddWithValue("@product_shipping_charge", product_shipping_charge);

          
            cmd.Parameters.AddWithValue("@guest_id", guest_id);


            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Total Amount of Order If Single Item Cancelled

    public int Update_Total_Order_Amount(string total_order_amount, string order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set total_order_amount=@total_order_amount Where order_id=@order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@total_order_amount", SqlDbType.NVarChar).Value= total_order_amount;
            cmd.Parameters.AddWithValue("@order_id", SqlDbType.NVarChar).Value = order_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Invoice_Status(string invoide_status, string order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_gst_invoice Set invoide_status=@invoide_status Where order_id=@order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@invoide_status", SqlDbType.NVarChar).Value = invoide_status;
            cmd.Parameters.AddWithValue("@order_id", SqlDbType.NVarChar).Value = order_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Add Invoice No

    public int Add_Invoice_No(string auto_id, string invoice_no,string order_id,string invoice_date,string invoice_time,string fy_year_from,string fy_year_to,string invoide_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into ecommerce_gst_invoice(auto_id,invoice_no,order_id,invoice_date,invoice_time,fy_year_from,fy_year_to,invoide_status) values (@auto_id,@invoice_no,@order_id,@invoice_date,@invoice_time,@fy_year_from,@fy_year_to,@invoide_status)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@auto_id", SqlDbType.NVarChar).Value = auto_id;
            cmd.Parameters.AddWithValue("@invoice_no", SqlDbType.NVarChar).Value = invoice_no;
            cmd.Parameters.AddWithValue("@order_id", SqlDbType.NVarChar).Value = order_id;
            cmd.Parameters.AddWithValue("@invoice_date", SqlDbType.NVarChar).Value = invoice_date;
            cmd.Parameters.AddWithValue("@invoice_time", SqlDbType.NVarChar).Value = invoice_time;
            cmd.Parameters.AddWithValue("@fy_year_from", SqlDbType.NVarChar).Value = fy_year_from;
            cmd.Parameters.AddWithValue("@fy_year_to", SqlDbType.NVarChar).Value = fy_year_to;
            cmd.Parameters.AddWithValue("@invoide_status", SqlDbType.NVarChar).Value = invoide_status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Order_for_Cancel_All(string order_id, string reason, string comment, string return_date, string return_time, string order_status,string refund_mode)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_order Set order_return_reason=@order_return_reason,order_return_comment=@order_return_comment,order_cancel_date=@order_cancel_date,order_cancel_time=@order_cancel_time,order_status=@order_status,refund_mode=@refund_mode where order_id=@order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_return_reason", reason);
            cmd.Parameters.AddWithValue("@order_return_comment", SqlDbType.NVarChar).Value = comment;
            cmd.Parameters.AddWithValue("@order_cancel_date", return_date);
            cmd.Parameters.AddWithValue("@order_cancel_time", return_time);
            cmd.Parameters.AddWithValue("@order_status", order_status);
            cmd.Parameters.AddWithValue("@refund_mode", refund_mode);

            cmd.Parameters.AddWithValue("@order_id", order_id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Upload Order List

    public int Upload_Order_List(string order_id_temp, string order_id, string order_date, string order_time, string customer_id, string customer_name, string customer_mobileno, string customer_email,string billing_address_line1,string billing_address_line2,string billing_city_id,string billing_city_name,string billing_state_id,string billing_state_name,string billing_pincode,string billing_landmark,string order_list_photo,string payment_mode,string order_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into upload_order_list(order_id_temp,order_id,order_date,order_time,customer_id,customer_name,customer_mobileno,customer_email,billing_address_line1,billing_address_line2,billing_city_id,billing_city_name,billing_state_id,billing_state_name,billing_pincode,billing_landmark,order_list_photo,payment_mode,order_status) values (@order_id_temp,@order_id,@order_date,@order_time,@customer_id,@customer_name,@customer_mobileno,@customer_email,@billing_address_line1,@billing_address_line2,@billing_city_id,@billing_city_name,@billing_state_id,@billing_state_name,@billing_pincode,@billing_landmark,@order_list_photo,@payment_mode,@order_status)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_id_temp", SqlDbType.NVarChar).Value = order_id_temp;
            cmd.Parameters.AddWithValue("@order_id", SqlDbType.NVarChar).Value = order_id;
            cmd.Parameters.AddWithValue("@order_date", SqlDbType.NVarChar).Value = order_date;
            cmd.Parameters.AddWithValue("@order_time", SqlDbType.NVarChar).Value = order_time;
            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@customer_name", SqlDbType.NVarChar).Value = customer_name;
            cmd.Parameters.AddWithValue("@customer_mobileno", SqlDbType.NVarChar).Value = customer_mobileno;
            cmd.Parameters.AddWithValue("@customer_email", SqlDbType.NVarChar).Value = customer_email;
            cmd.Parameters.AddWithValue("@billing_address_line1", SqlDbType.NVarChar).Value = billing_address_line1;
            cmd.Parameters.AddWithValue("@billing_address_line2", SqlDbType.NVarChar).Value = billing_address_line2;
            cmd.Parameters.AddWithValue("@billing_city_id", SqlDbType.NVarChar).Value = billing_city_id;
            cmd.Parameters.AddWithValue("@billing_city_name", SqlDbType.NVarChar).Value = billing_city_name;
            cmd.Parameters.AddWithValue("@billing_state_id", SqlDbType.NVarChar).Value = billing_state_id;
            cmd.Parameters.AddWithValue("@billing_state_name", SqlDbType.NVarChar).Value = billing_state_name;
            cmd.Parameters.AddWithValue("@billing_pincode", SqlDbType.NVarChar).Value = billing_pincode;
            cmd.Parameters.AddWithValue("@billing_landmark", SqlDbType.NVarChar).Value = billing_landmark;
            cmd.Parameters.AddWithValue("@order_list_photo", SqlDbType.NVarChar).Value = order_list_photo;
            cmd.Parameters.AddWithValue("@payment_mode", SqlDbType.NVarChar).Value = payment_mode;
            cmd.Parameters.AddWithValue("@order_status", SqlDbType.NVarChar).Value = order_status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Upload_Order_List_Status(string order_status, string order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update upload_order_list Set order_status=@order_status where order_id=@order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", SqlDbType.NVarChar).Value= order_status;
            cmd.Parameters.AddWithValue("@order_id", SqlDbType.NVarChar).Value = order_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Upload_Order_Status_By_Sub_Order_id(string order_status, string sub_order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set order_status=@order_status where sub_order_id=@sub_order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@order_status", SqlDbType.NVarChar).Value = order_status;
            cmd.Parameters.AddWithValue("@sub_order_id", SqlDbType.NVarChar).Value = sub_order_id;

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