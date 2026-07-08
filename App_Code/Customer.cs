using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for system
/// </summary>
public class Customer
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public Customer()
    {

    }


    // Customer Information

    public SqlDataReader Customer_Info(string customer_id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from ecommerce_customer where customer_id=@customer_id ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customer_id);

            reader = cmd.ExecuteReader();

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }
    
    // Customer Login

    public SqlDataReader Customer_Login(string mobileno)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from ecommerce_customer where customer_mobileno=@customer_mobileno ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_mobileno", mobileno);

            reader = cmd.ExecuteReader();

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

   
    // Check Mobile No Already Registered

    public int Check_Mobile_NO_Registered(string mobileno)
    {
        con.Close();
        con.Open();
        int data = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Count(id) from ecommerce_customer where customer_mobileno=@customer_mobileno";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_mobileno", mobileno);
            data = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (data);
    }

    
    // Customer insert query

    public int Insert_Customer(string tempid, string customer_id, string name, string mobileno, string mobileno_verify, string otp, string date, string time, string status, string password,string customer_email)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_customer(customer_temp_id,customer_id,customer_name,customer_mobileno,mobileno_verified,otp,customer_date,customer_time,customer_status,customer_password,customer_email) values (@customer_temp_id,@customer_id,@customer_name,@customer_mobileno,@mobileno_verified,@otp,@customer_date,@customer_time,@customer_status,@customer_password,@customer_email)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_temp_id", SqlDbType.NVarChar).Value = tempid;
            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@customer_name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@customer_mobileno", SqlDbType.NVarChar).Value = mobileno;
            cmd.Parameters.AddWithValue("@mobileno_verified", SqlDbType.NVarChar).Value = mobileno_verify;
            cmd.Parameters.AddWithValue("@otp", SqlDbType.Int).Value = otp;
            cmd.Parameters.AddWithValue("@customer_date", SqlDbType.NVarChar).Value = date;
            cmd.Parameters.AddWithValue("@customer_time", SqlDbType.NVarChar).Value = time;
            cmd.Parameters.AddWithValue("@customer_status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.AddWithValue("@customer_password", SqlDbType.NVarChar).Value = password;
            cmd.Parameters.AddWithValue("@customer_email", SqlDbType.NVarChar).Value = customer_email;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }
   
    // Customer info Update query

    public int Update_Customer_Info(string name, string mobileno, string email, string gender,string customer_dob, string customer_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer Set customer_name=@customer_name,customer_mobileno=@customer_mobileno,customer_email=@customer_email,customer_gender=@customer_gender,customer_dob=@customer_dob where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@customer_mobileno", SqlDbType.NVarChar).Value = mobileno;
            cmd.Parameters.AddWithValue("@customer_email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.AddWithValue("@customer_gender", SqlDbType.NVarChar).Value = gender;
            cmd.Parameters.AddWithValue("@customer_dob", SqlDbType.NVarChar).Value = customer_dob;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Customer Profile photo Update query

    public int Update_Customer_Photo(string path, string customer_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer Set customer_profilephoto=@customer_profilephoto where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_profilephoto", SqlDbType.NVarChar).Value = path;
            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Customer Profile photo Update query End


    // Customer Change Passsword

    public int Change_Password(string newpassword, string customer_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer Set customer_password=@customer_password where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_password", SqlDbType.NVarChar).Value = newpassword;
            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Change_Password_mobileNo(string newpassword, string customer_mobileno)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer Set customer_password=@customer_password where customer_mobileno=@customer_mobileno";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_password", SqlDbType.NVarChar).Value = newpassword;
            cmd.Parameters.AddWithValue("@customer_mobileno", SqlDbType.NVarChar).Value = customer_mobileno;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    public int Forgot_Password(string newpassword, string customer_mobileno)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer Set customer_password=@customer_password where customer_mobileno=@customer_mobileno";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_password", SqlDbType.NVarChar).Value = newpassword;
            cmd.Parameters.AddWithValue("@customer_mobileno", SqlDbType.NVarChar).Value = customer_mobileno;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }



    // Customer Mobile Varification Update


    public int Mobile_Verification_Update(string mobileno, string otp, string verification_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer Set otp=@otp,mobileno_verified=@mobileno_verified where customer_mobileno=@customer_mobileno";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@otp", SqlDbType.Int).Value = otp;
            cmd.Parameters.AddWithValue("@mobileno_verified", SqlDbType.NVarChar).Value = verification_status;
            cmd.Parameters.AddWithValue("@customer_mobileno", SqlDbType.NVarChar).Value = mobileno;


            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }



    // New Addreess insert query

    public int Insert_New_Address(string customer_id, string address_customer_name, string address_customer_mobileno, string address_customer_email, string address_line_1, string address_line_2, string address_city_id, string address_city_name, string address_state_id, string address_state_name, string address_pincode, string address_landmark,string address_default)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_customer_address(customer_id,address_customer_name,address_customer_mobileno,address_customer_email,address_line_1,address_line_2,address_city_id,address_city_name,address_state_id,address_state_name,address_pincode,address_landmark,address_default) values (@customer_id,@address_customer_name,@address_customer_mobileno,@address_customer_email,@address_line_1,@address_line_2,@address_city_id,@address_city_name,@address_state_id,@address_state_name,@address_pincode,@address_landmark,@address_default)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@address_customer_name", SqlDbType.NVarChar).Value = address_customer_name;
            cmd.Parameters.AddWithValue("@address_customer_mobileno", SqlDbType.NVarChar).Value = address_customer_mobileno;
            cmd.Parameters.AddWithValue("@address_customer_email", SqlDbType.NVarChar).Value = address_customer_email;

            cmd.Parameters.AddWithValue("@address_line_1", SqlDbType.NVarChar).Value = address_line_1;
            cmd.Parameters.AddWithValue("@address_line_2", SqlDbType.NVarChar).Value = address_line_2;
            cmd.Parameters.AddWithValue("@address_city_id", SqlDbType.NVarChar).Value = address_city_id;
            cmd.Parameters.AddWithValue("@address_city_name", SqlDbType.NVarChar).Value = address_city_name;
            cmd.Parameters.AddWithValue("@address_state_id", SqlDbType.NVarChar).Value = address_state_id;
            cmd.Parameters.AddWithValue("@address_state_name", SqlDbType.NVarChar).Value = address_state_name;
            cmd.Parameters.AddWithValue("@address_pincode", SqlDbType.NVarChar).Value = address_pincode;
            cmd.Parameters.AddWithValue("@address_landmark", SqlDbType.NVarChar).Value = address_landmark;
            cmd.Parameters.AddWithValue("@address_default", SqlDbType.NVarChar).Value = address_default;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    public int Update_Default_Address(string address_default, string customer_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer_address Set address_default=@address_default where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@address_default", SqlDbType.NVarChar).Value = address_default;
            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;


            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Make_Default_Address(string address_default, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer_address Set address_default=@address_default where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@address_default", SqlDbType.NVarChar).Value = address_default;
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

    // Update Addreess 

    public int Updtae_Address(string address_customer_name, string address_customer_mobileno, string address_customer_email, string address_line_1, string address_line_2, string address_city_id, string address_city_name, string address_state_id, string address_state_name, string address_pincode, string address_landmark,string address_default, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_customer_address Set address_customer_name=@address_customer_name,address_customer_mobileno=@address_customer_mobileno,address_customer_email=@address_customer_email,address_line_1=@address_line_1,address_line_2=@address_line_2,address_city_id=@address_city_id,address_city_name=@address_city_name,address_state_id=@address_state_id,address_state_name=@address_state_name, address_pincode=@address_pincode,address_landmark=@address_landmark,address_default=@address_default where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@address_customer_name", SqlDbType.NVarChar).Value = address_customer_name;
            cmd.Parameters.AddWithValue("@address_customer_mobileno", SqlDbType.NVarChar).Value = address_customer_mobileno;
            cmd.Parameters.AddWithValue("@address_customer_email", SqlDbType.NVarChar).Value = address_customer_email;

            cmd.Parameters.AddWithValue("@address_line_1", SqlDbType.NVarChar).Value = address_line_1;
            cmd.Parameters.AddWithValue("@address_line_2", SqlDbType.NVarChar).Value = address_line_2;

            cmd.Parameters.AddWithValue("@address_city_id", SqlDbType.NVarChar).Value = address_city_id;
            cmd.Parameters.AddWithValue("@address_city_name", SqlDbType.NVarChar).Value = address_city_name;
            cmd.Parameters.AddWithValue("@address_state_id", SqlDbType.NVarChar).Value = address_state_id;
            cmd.Parameters.AddWithValue("@address_state_name", SqlDbType.NVarChar).Value = address_state_name;

            cmd.Parameters.AddWithValue("@address_pincode", SqlDbType.NVarChar).Value = address_pincode;
            cmd.Parameters.AddWithValue("@address_landmark", SqlDbType.NVarChar).Value = address_landmark;

            cmd.Parameters.AddWithValue("@address_default", SqlDbType.NVarChar).Value = address_default;

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


    public int Update_Address_by_admin(string address_customer_name, string address_customer_mobileno, string address_customer_email, string address_line_1, string address_line_2, string address_pincode, string address_landmark,string address_state_name,string address_city_name, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_customer_address Set address_customer_name=@address_customer_name,address_customer_mobileno=@address_customer_mobileno,address_customer_email=@address_customer_email,address_line_1=@address_line_1,address_line_2=@address_line_2,address_pincode=@address_pincode,address_landmark=@address_landmark,address_state_name=@address_state_name,address_city_name=@address_city_name where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@address_customer_name", SqlDbType.NVarChar).Value = address_customer_name;
            cmd.Parameters.AddWithValue("@address_customer_mobileno", SqlDbType.NVarChar).Value = address_customer_mobileno;
            cmd.Parameters.AddWithValue("@address_customer_email", SqlDbType.NVarChar).Value = address_customer_email;

            cmd.Parameters.AddWithValue("@address_line_1", SqlDbType.NVarChar).Value = address_line_1;
            cmd.Parameters.AddWithValue("@address_line_2", SqlDbType.NVarChar).Value = address_line_2;
            cmd.Parameters.AddWithValue("@address_pincode", SqlDbType.NVarChar).Value = address_pincode;
            cmd.Parameters.AddWithValue("@address_landmark", SqlDbType.NVarChar).Value = address_landmark;

            cmd.Parameters.AddWithValue("@address_state_name", SqlDbType.NVarChar).Value = address_state_name;
            cmd.Parameters.AddWithValue("@address_city_name", SqlDbType.NVarChar).Value = address_city_name;

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


    // Customer Address info

    public SqlDataReader Get_Customer_Address(string customer_id,string id)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from ecommerce_customer_address where customer_id=@customer_id AND id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@id",id);

            reader = cmd.ExecuteReader();

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Customer Address info End

    // Check Mobile No Already Registered

    public int Get_No_of_address(string customerid)
    {
        con.Close();
        con.Open();
        int data = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Count(id) from ecommerce_customer_address where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            data = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (data);
    }

    // Check Mobile No Already Registered End



    // Add Product log

    public int Add_Product_Log(string customer_id, string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_product_log (customer_id,product_id) values (@customer_id,@product_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    public int Get_No_of_Log(string customerid)
    {
        con.Close();
        con.Open();
        int data = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Count(id) from ecommerce_product_log where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            data = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (data);
    }


    // Product Rating Review

    public int Add_Rating_Review(string product_id, string reviwer_name,string reviewer_message,string review_star,string review_date,string review_status,string reviwer_id,string seller_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into product_rating_review(product_id,reviwer_name,reviewer_message,review_star,review_date,review_status,reviwer_id,seller_id) values (@product_id,@reviwer_name,@reviewer_message,@review_star,@review_date,@review_status,@reviwer_id,@seller_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@reviwer_name", SqlDbType.NVarChar).Value = reviwer_name;
            cmd.Parameters.AddWithValue("@reviewer_message", SqlDbType.NVarChar).Value = reviewer_message;
            cmd.Parameters.AddWithValue("@review_star", SqlDbType.NVarChar).Value = review_star;
            cmd.Parameters.AddWithValue("@review_date", SqlDbType.NVarChar).Value = review_date;
            cmd.Parameters.AddWithValue("@review_status", SqlDbType.NVarChar).Value = review_status;
            cmd.Parameters.AddWithValue("@reviwer_id", SqlDbType.NVarChar).Value = reviwer_id;
            cmd.Parameters.AddWithValue("@seller_id", SqlDbType.NVarChar).Value = seller_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Customer Bank Account

    public int Add_Customer_Bank_Account(string customer_id, string bank_name,string bank_ac_holder_name,string bank_ac_no,string bank_ifsc)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_bank_account(customer_id,bank_name,bank_ac_holder_name,bank_ac_no,bank_ifsc) values (@customer_id,@bank_name,@bank_ac_holder_name,@bank_ac_no,@bank_ifsc)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@bank_name", SqlDbType.NVarChar).Value = bank_name;
            cmd.Parameters.AddWithValue("@bank_ac_holder_name", SqlDbType.NVarChar).Value = bank_ac_holder_name;
            cmd.Parameters.AddWithValue("@bank_ac_no", SqlDbType.NVarChar).Value = bank_ac_no;
            cmd.Parameters.AddWithValue("@bank_ifsc", SqlDbType.NVarChar).Value = bank_ifsc;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Customer_Bank_Account(string customer_id, string bank_name, string bank_ac_holder_name, string bank_ac_no, string bank_ifsc)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_bank_account Set bank_name=@bank_name,bank_ac_holder_name=@bank_ac_holder_name,bank_ac_no=@bank_ac_no,bank_ifsc=@bank_ifsc Where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;
          
            cmd.Parameters.AddWithValue("@bank_name", SqlDbType.NVarChar).Value = bank_name;
            cmd.Parameters.AddWithValue("@bank_ac_holder_name", SqlDbType.NVarChar).Value = bank_ac_holder_name;
            cmd.Parameters.AddWithValue("@bank_ac_no", SqlDbType.NVarChar).Value = bank_ac_no;
            cmd.Parameters.AddWithValue("@bank_ifsc", SqlDbType.NVarChar).Value = bank_ifsc;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Save Referral Code

    public int Save_Referral_Code(string refer_by_customer_id, string referral_code,string referral_create_date)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into app_referral (refer_by_customer_id,referral_code,referral_create_date) values (@refer_by_customer_id,@referral_code,@referral_create_date)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@refer_by_customer_id", SqlDbType.NVarChar).Value = refer_by_customer_id;
            cmd.Parameters.AddWithValue("@referral_code", SqlDbType.NVarChar).Value = referral_code;
            cmd.Parameters.AddWithValue("@referral_create_date", SqlDbType.NVarChar).Value = referral_create_date;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Register_Referral_Code(string referral_code, string customer_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_customer Set referral_code=@referral_code Where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@referral_code", SqlDbType.NVarChar).Value = referral_code;
            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;

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