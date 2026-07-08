using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RestaurantOrder
/// </summary>
public class RestaurantOrder
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public RestaurantOrder()
    {
        //
        // TODO: Add constructor logic here
        //
    }

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

    public SqlDataReader Get_cust_mobileno(string customer_id)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select customer_mobileno from ecommerce_customer where customer_id=@customer_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }


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

            cmd.Parameters.AddWithValue("@total_order_amount", SqlDbType.NVarChar).Value = total_order_amount;
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


    public int Update_Order_status_Deliver_OrderID(string order_id, string status, string deliverdate, string delivertime)
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




}