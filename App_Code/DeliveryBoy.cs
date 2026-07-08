using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DeliveryBoy
/// </summary>
public class DeliveryBoy
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public DeliveryBoy()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //============================================================ Delivery Boy ===============================================================//


    public int Add_Delivery_Boy(string delivery_boy_id, string delivery_boy_name, string delivery_boy_email, string delivery_boy_mobileno, string delivery_boy_gender, string delivery_boy_address_line_1, string delivery_boy_address_line_2, string delivery_boy_state_id, string delivery_boy_state_name, string delivery_boy_city_id, string delivery_boy_city_name, string delivery_boy_pincode, string delivery_boy_password, string delivery_boy_photo, string delivery_boy_date, string delivery_boy_time, string delivery_boy_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_delivery_boy(delivery_boy_id,delivery_boy_name,delivery_boy_email,delivery_boy_mobileno,delivery_boy_gender,delivery_boy_address_line_1,delivery_boy_address_line_2,delivery_boy_state_id,delivery_boy_state_name,delivery_boy_city_id,delivery_boy_city_name,delivery_boy_pincode,delivery_boy_password,delivery_boy_photo,delivery_boy_date,delivery_boy_time,delivery_boy_status) values (@delivery_boy_id,@delivery_boy_name,@delivery_boy_email,@delivery_boy_mobileno,@delivery_boy_gender,@delivery_boy_address_line_1,@delivery_boy_address_line_2,@delivery_boy_state_id,@delivery_boy_state_name,@delivery_boy_city_id,@delivery_boy_city_name,@delivery_boy_pincode,@delivery_boy_password,@delivery_boy_photo,@delivery_boy_date,@delivery_boy_time,@delivery_boy_status)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@delivery_boy_id", SqlDbType.NVarChar).Value = delivery_boy_id;
            cmd.Parameters.AddWithValue("@delivery_boy_name", SqlDbType.NVarChar).Value = delivery_boy_name;
            cmd.Parameters.AddWithValue("@delivery_boy_email", SqlDbType.NVarChar).Value = delivery_boy_email;

            cmd.Parameters.AddWithValue("@delivery_boy_mobileno", SqlDbType.NVarChar).Value = delivery_boy_mobileno;
            cmd.Parameters.AddWithValue("@delivery_boy_gender", SqlDbType.NVarChar).Value = delivery_boy_gender;
            cmd.Parameters.AddWithValue("@delivery_boy_address_line_1", SqlDbType.NVarChar).Value = delivery_boy_address_line_1;

            cmd.Parameters.AddWithValue("@delivery_boy_address_line_2", SqlDbType.NVarChar).Value = delivery_boy_address_line_2;
            cmd.Parameters.AddWithValue("@delivery_boy_state_id", SqlDbType.NVarChar).Value = delivery_boy_state_id;
            cmd.Parameters.AddWithValue("@delivery_boy_state_name", SqlDbType.NVarChar).Value = delivery_boy_state_name;

            cmd.Parameters.AddWithValue("@delivery_boy_city_id", SqlDbType.NVarChar).Value = delivery_boy_city_id;
            cmd.Parameters.AddWithValue("@delivery_boy_city_name", SqlDbType.NVarChar).Value = delivery_boy_city_name;
            cmd.Parameters.AddWithValue("@delivery_boy_pincode", SqlDbType.NVarChar).Value = delivery_boy_pincode;

            cmd.Parameters.AddWithValue("@delivery_boy_password", SqlDbType.NVarChar).Value = delivery_boy_password;
            cmd.Parameters.AddWithValue("@delivery_boy_photo", SqlDbType.NVarChar).Value = delivery_boy_photo;
            cmd.Parameters.AddWithValue("@delivery_boy_date", SqlDbType.NVarChar).Value = delivery_boy_date;

            cmd.Parameters.AddWithValue("@delivery_boy_time", SqlDbType.NVarChar).Value = delivery_boy_time;
            cmd.Parameters.AddWithValue("@delivery_boy_status", SqlDbType.NVarChar).Value = delivery_boy_status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

    public int Edit_Delivery_Boy(string delivery_boy_name, string delivery_boy_email, string delivery_boy_mobileno, string delivery_boy_gender, string delivery_boy_address_line_1, string delivery_boy_address_line_2, string delivery_boy_state_id, string delivery_boy_state_name, string delivery_boy_city_id, string delivery_boy_city_name, string delivery_boy_pincode, string delivery_boy_status, string delivery_boy_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_delivery_boy  Set delivery_boy_name=@delivery_boy_name,delivery_boy_email=@delivery_boy_email,delivery_boy_mobileno=@delivery_boy_mobileno,delivery_boy_gender=@delivery_boy_gender,delivery_boy_address_line_1=@delivery_boy_address_line_1,delivery_boy_address_line_2=@delivery_boy_address_line_2,delivery_boy_state_id=@delivery_boy_state_id,delivery_boy_state_name=@delivery_boy_state_name,delivery_boy_city_id=@delivery_boy_city_id,delivery_boy_city_name=@delivery_boy_city_name,delivery_boy_pincode=@delivery_boy_pincode,delivery_boy_status=@delivery_boy_status where delivery_boy_id=@delivery_boy_id";
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.AddWithValue("@delivery_boy_name", SqlDbType.NVarChar).Value = delivery_boy_name;
            cmd.Parameters.AddWithValue("@delivery_boy_email", SqlDbType.NVarChar).Value = delivery_boy_email;

            cmd.Parameters.AddWithValue("@delivery_boy_mobileno", SqlDbType.NVarChar).Value = delivery_boy_mobileno;
            cmd.Parameters.AddWithValue("@delivery_boy_gender", SqlDbType.NVarChar).Value = delivery_boy_gender;
            cmd.Parameters.AddWithValue("@delivery_boy_address_line_1", SqlDbType.NVarChar).Value = delivery_boy_address_line_1;

            cmd.Parameters.AddWithValue("@delivery_boy_address_line_2", SqlDbType.NVarChar).Value = delivery_boy_address_line_2;
            cmd.Parameters.AddWithValue("@delivery_boy_state_id", SqlDbType.NVarChar).Value = delivery_boy_state_id;
            cmd.Parameters.AddWithValue("@delivery_boy_state_name", SqlDbType.NVarChar).Value = delivery_boy_state_name;

            cmd.Parameters.AddWithValue("@delivery_boy_city_id", SqlDbType.NVarChar).Value = delivery_boy_city_id;
            cmd.Parameters.AddWithValue("@delivery_boy_city_name", SqlDbType.NVarChar).Value = delivery_boy_city_name;
            cmd.Parameters.AddWithValue("@delivery_boy_pincode", SqlDbType.NVarChar).Value = delivery_boy_pincode;

            cmd.Parameters.AddWithValue("@delivery_boy_status", SqlDbType.NVarChar).Value = delivery_boy_status;
            cmd.Parameters.AddWithValue("@delivery_boy_id", SqlDbType.NVarChar).Value = delivery_boy_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

    public int Update_delivery_boy_photo(string delivery_boy_photo, string delivery_boy_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_delivery_boy Set delivery_boy_photo=@delivery_boy_photo where delivery_boy_id=@delivery_boy_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@delivery_boy_photo", SqlDbType.NVarChar).Value = delivery_boy_photo;
            cmd.Parameters.AddWithValue("@delivery_boy_id", SqlDbType.NVarChar).Value = delivery_boy_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

    public int Update_delivery_boy_Status(string delivery_boy_status, string delivery_boy_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_delivery_boy Set delivery_boy_status=@delivery_boy_status where delivery_boy_id=@delivery_boy_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@delivery_boy_status", SqlDbType.NVarChar).Value = delivery_boy_status;
            cmd.Parameters.AddWithValue("@delivery_boy_id", SqlDbType.NVarChar).Value = delivery_boy_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }


    public int Add_delivery_boy_document(string delivery_boy_id, string document_name, string document_path)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into delivery_boy_document(delivery_boy_id,document_name,document_path) values (@delivery_boy_id,@document_name,@document_path)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@delivery_boy_id", SqlDbType.NVarChar).Value = delivery_boy_id;
            cmd.Parameters.AddWithValue("@document_name", SqlDbType.NVarChar).Value = document_name;
            cmd.Parameters.AddWithValue("@document_path", SqlDbType.NVarChar).Value = document_path;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

    public int Add_delivery_boy_serviced_pincode(string delivery_boy_id, string serviced_state_id, string serviced_state_name, string serviced_city_id, string serviced_city_name, string serviced_pincode)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into delivery_boy_serviced_pincode(delivery_boy_id,serviced_state_id,serviced_state_name,serviced_city_id,serviced_city_name,serviced_pincode) values (@delivery_boy_id,@serviced_state_id,@serviced_state_name,@serviced_city_id,@serviced_city_name,@serviced_pincode)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@delivery_boy_id", SqlDbType.NVarChar).Value = delivery_boy_id;
            cmd.Parameters.AddWithValue("@serviced_state_id", SqlDbType.NVarChar).Value = serviced_state_id;
            cmd.Parameters.AddWithValue("@serviced_state_name", SqlDbType.NVarChar).Value = serviced_state_name;

            cmd.Parameters.AddWithValue("@serviced_city_id", SqlDbType.NVarChar).Value = serviced_city_id;
            cmd.Parameters.AddWithValue("@serviced_city_name", SqlDbType.NVarChar).Value = serviced_city_name;
            cmd.Parameters.AddWithValue("@serviced_pincode", SqlDbType.NVarChar).Value = serviced_pincode;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }



    // Assign Order To Delivery Boy

    public int Assign_Order_To_Delivery_Boy(string assigned_delivery_boy_id, string assigned_date, string order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set assigned_delivery_boy_id=@assigned_delivery_boy_id,assigned_date=@assigned_date where order_id=@order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@assigned_delivery_boy_id", SqlDbType.NVarChar).Value = assigned_delivery_boy_id;
            cmd.Parameters.AddWithValue("@assigned_date", SqlDbType.NVarChar).Value = assigned_date;

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

    public int UnAssign_Order_To_Delivery_Boy(string assigned_delivery_boy_id, string assigned_date, string order_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_order Set assigned_date=@assigned_date where assigned_delivery_boy_id=@assigned_delivery_boy_id AND order_id=@order_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@assigned_date", SqlDbType.NVarChar).Value = assigned_date;
            cmd.Parameters.AddWithValue("@assigned_delivery_boy_id", SqlDbType.NVarChar).Value = assigned_delivery_boy_id;

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


}