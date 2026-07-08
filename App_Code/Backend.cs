using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Backend
/// </summary>
public class Backend
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public Backend()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // Manage City

    public int Add_City(string state_id, string district_name)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into ecommerce_city(state_id,district_name) values (@state_id,@district_name)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@state_id", SqlDbType.NVarChar).Value = state_id;

            cmd.Parameters.AddWithValue("@district_name", SqlDbType.NVarChar).Value = district_name;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_City(string state_id, string district_name, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_city Set state_id=@state_id,district_name=@district_name Where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@state_id", SqlDbType.NVarChar).Value = state_id;
            cmd.Parameters.AddWithValue("@district_name", SqlDbType.NVarChar).Value = district_name;
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



    public int Edit_City_Name(string district_name, string city_name)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_city Set district_name=@district_name Where district_name=@city_name";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@district_name", SqlDbType.NVarChar).Value = district_name;
            cmd.Parameters.AddWithValue("@city_name", SqlDbType.NVarChar).Value = city_name;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // Free Shipping

    public int Add_Free_Shipping(string free_delievry)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_free_delievry(free_delievry) values (@free_delievry)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@free_delievry", free_delievry);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Free_Shipping(string free_delievry)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_free_delievry Set free_delievry=@free_delievry";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@free_delievry", free_delievry);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Offer_Banner(string banner_path, string banner_link, string banner_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_banner(banner_path,banner_link,banner_status) values (@banner_path,@banner_link,@banner_status)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@banner_path", SqlDbType.NVarChar).Value = banner_path;
            cmd.Parameters.AddWithValue("@banner_link", SqlDbType.NVarChar).Value = banner_link;
            cmd.Parameters.AddWithValue("@banner_status", SqlDbType.NVarChar).Value = banner_status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Shipping Charge

    public int Add_Shipping_Charge(string shipping_charge,string restaurant_shipping_charge)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_shipping(shipping_charge,restaurant_shipping_charge) values (@shipping_charge,@restaurant_shipping_charge)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@shipping_charge", shipping_charge);
            cmd.Parameters.AddWithValue("@restaurant_shipping_charge", restaurant_shipping_charge);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Shipping_Charge(string shipping_charge,string restaurant_shipping_charge)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_shipping Set shipping_charge=@shipping_charge,restaurant_shipping_charge=@restaurant_shipping_charge";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@shipping_charge", shipping_charge);
            cmd.Parameters.AddWithValue("@restaurant_shipping_charge", restaurant_shipping_charge);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Minimum Order

    public int Add_Minimum_Order(string minimum_order)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_minimum_order(minimum_order) values (@minimum_order)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@minimum_order", minimum_order);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Minimum_Order(string minimum_order)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_minimum_order Set minimum_order=@minimum_order";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@minimum_order", minimum_order);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // GST

    public int Add_GST(string gst_percentage)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into ecommerce_gst(gst_value) values (@gst_value)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@gst_value", gst_percentage);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_GST(string gst_percentage)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_gst Set  gst_value=@gst_value";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@gst_value", gst_percentage);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Add Custom Section

    public int Add_Custom_Section(string section_name, string section_description,string section_priority,string section_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_custom_section(section_name,section_description,section_priority,section_status) values (@section_name,@section_description,@section_priority,@section_status)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@section_name", SqlDbType.NVarChar).Value = section_name;
            cmd.Parameters.AddWithValue("@section_description", SqlDbType.NVarChar).Value = section_description;
            cmd.Parameters.AddWithValue("@section_priority", SqlDbType.NVarChar).Value = section_priority;
            cmd.Parameters.AddWithValue("@section_status", SqlDbType.NVarChar).Value = section_status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Custom Section

    public int Update_Custom_Section(string section_name, string section_description,string section_priority,string section_status,  string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_custom_section Set section_name=@section_name,section_description=@section_description,section_priority=@section_priority,section_status=@section_status  where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@section_name", SqlDbType.NVarChar).Value = section_name;
            cmd.Parameters.AddWithValue("@section_description", SqlDbType.NVarChar).Value = section_description;
            cmd.Parameters.AddWithValue("@section_priority", SqlDbType.NVarChar).Value = section_priority;
            cmd.Parameters.AddWithValue("@section_status", SqlDbType.NVarChar).Value = section_status;

            cmd.Parameters.AddWithValue("@id",id);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Add Product To Custom Section

    public int Add_Product_To_Custom_Section(string section_id, string product_id,string seller_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_section_product(section_id,product_id,seller_id) values (@section_id,@product_id,@seller_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@section_id", SqlDbType.NVarChar).Value = section_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
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

    public int Add_Slider(string slider_photo,string slider_link,string slider_mode)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_slider(slider_photo,slider_link,slider_mode) values (@slider_photo,@slider_link,@slider_mode)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@slider_photo", SqlDbType.NVarChar).Value = slider_photo;
            cmd.Parameters.AddWithValue("@slider_link", SqlDbType.NVarChar).Value = slider_link;
            cmd.Parameters.AddWithValue("@slider_mode", SqlDbType.NVarChar).Value = slider_mode;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Product_To_Deal_Section(string section_id, string product_id,string seller_id, string deal_date)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_section_product(section_id,product_id,seller_id,deal_date) values (@section_id,@product_id,@seller_id,@deal_date)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@section_id", SqlDbType.NVarChar).Value = section_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@deal_date", SqlDbType.NVarChar).Value = deal_date;
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

    public int Update_Product_postion_no(string product_id, string product_postion_no)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set product_postion_no=@product_postion_no  where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_postion_no", product_postion_no);
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

    // About

    public int Add_about(string about_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_about(about_information) values (@about_information)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@about_information", SqlDbType.NVarChar).Value = about_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_about(string about_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_about Set about_information=@about_information";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@about_information", SqlDbType.NVarChar).Value = about_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Terms & Conditions

    public int Add_Terms_Condition(string terms_condition_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_terms_condition(terms_condition_information) values (@terms_condition_information)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@terms_condition_information", SqlDbType.NVarChar).Value = terms_condition_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Terms_Condition(string terms_condition_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_terms_condition Set  terms_condition_information=@terms_condition_information";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@terms_condition_information", SqlDbType.NVarChar).Value = terms_condition_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Privacy Policy

    public int Add_privacy_policy(string privacy_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_privacy(privacy_information) values (@privacy_information)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@privacy_information", SqlDbType.NVarChar).Value = privacy_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_privacy_policy(string privacy_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_privacy Set  privacy_information=@privacy_information";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@privacy_information", SqlDbType.NVarChar).Value = privacy_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Cancel Policy

    public int Add_Return_Policy(string return_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_return_privacy(return_information) values (@return_information)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@return_information", SqlDbType.NVarChar).Value = return_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Return_policy(string return_information)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_return_privacy Set  return_information=@return_information";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@return_information", SqlDbType.NVarChar).Value = return_information;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Faq

    public int Add_Faq(string faq_question, string faq_description)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_faq(faq_question,faq_description) values (@faq_question,@faq_description)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@faq_question", SqlDbType.NVarChar).Value = faq_question;
            cmd.Parameters.AddWithValue("@faq_description", SqlDbType.NVarChar).Value = faq_description;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Faq(string faq_question, string faq_description, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_faq Set faq_question=@faq_question,faq_description=@faq_description where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@faq_question", SqlDbType.NVarChar).Value = faq_question;
            cmd.Parameters.AddWithValue("@faq_description", SqlDbType.NVarChar).Value = faq_description;

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

    // Unit

    public int Add_Unit(string unit_name)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_unit(unit_name) values (@unit_name)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@unit_name", SqlDbType.NVarChar).Value = unit_name;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Unit(string unit_name, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_unit Set unit_name=@unit_name where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@unit_name", SqlDbType.NVarChar).Value = unit_name;
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

    // Add Product

    public int Add_Product(string product_temp_id, string product_id, string product_full_name, string product_description, string product_hsnORsac, string product_parent_category_id, string product_parent_category_name, string product_sub_category_id, string product_sub_category_name, string product_full_description, string publish_status, string product_postion_no, string country_of_origin,string verticle_id,string verticle_name,string product_brand_name,string product_barcode,string product_seller_id, string product_seller_name,string product_sku,string super_point,string product_type)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_product(product_temp_id,product_id,product_full_name,product_description,product_hsnORsac,product_parent_category_id,product_parent_category_name,product_sub_category_id,product_sub_category_name,product_full_description,publish_status,product_postion_no,country_of_origin,verticle_id,verticle_name,product_brand_name,product_barcode,product_seller_id,product_seller_name,product_sku,super_point,product_type) values (@product_temp_id,@product_id,@product_full_name,@product_description,@product_hsnORsac,@product_parent_category_id,@product_parent_category_name,@product_sub_category_id,@product_sub_category_name,@product_full_description,@publish_status,@product_postion_no,@country_of_origin,@verticle_id,@verticle_name,@product_brand_name,@product_barcode,@product_seller_id,@product_seller_name,@product_sku,@super_point,@product_type)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_temp_id", SqlDbType.NVarChar).Value = product_temp_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@product_full_name", SqlDbType.NVarChar).Value = product_full_name;
            cmd.Parameters.AddWithValue("@product_description", SqlDbType.NVarChar).Value = product_description;
            cmd.Parameters.AddWithValue("@product_hsnORsac", SqlDbType.NVarChar).Value = product_hsnORsac;
            cmd.Parameters.AddWithValue("@product_parent_category_id", SqlDbType.NVarChar).Value = product_parent_category_id;
            cmd.Parameters.AddWithValue("@product_parent_category_name", SqlDbType.NVarChar).Value = product_parent_category_name;
            cmd.Parameters.AddWithValue("@product_sub_category_id", SqlDbType.NVarChar).Value = product_sub_category_id;
            cmd.Parameters.AddWithValue("@product_sub_category_name", SqlDbType.NVarChar).Value = product_sub_category_name;
            cmd.Parameters.AddWithValue("@product_full_description", SqlDbType.NVarChar).Value = product_full_description;
            cmd.Parameters.AddWithValue("@publish_status", SqlDbType.NVarChar).Value = publish_status;
            cmd.Parameters.AddWithValue("@product_postion_no", SqlDbType.NVarChar).Value = product_postion_no;
            cmd.Parameters.AddWithValue("@country_of_origin", SqlDbType.NVarChar).Value = country_of_origin;

            cmd.Parameters.AddWithValue("@verticle_id", SqlDbType.NVarChar).Value = verticle_id;
            cmd.Parameters.AddWithValue("@verticle_name", SqlDbType.NVarChar).Value = verticle_name;
            cmd.Parameters.AddWithValue("@product_brand_name", SqlDbType.NVarChar).Value = product_brand_name;
            cmd.Parameters.AddWithValue("@product_barcode", SqlDbType.NVarChar).Value = product_barcode;

            cmd.Parameters.AddWithValue("@product_seller_id", SqlDbType.NVarChar).Value = product_seller_id;
            cmd.Parameters.AddWithValue("@product_seller_name", SqlDbType.NVarChar).Value = product_seller_name;

            cmd.Parameters.AddWithValue("@product_sku", SqlDbType.NVarChar).Value = product_sku;
            cmd.Parameters.AddWithValue("@super_point", SqlDbType.NVarChar).Value = super_point;
            cmd.Parameters.AddWithValue("@product_type", SqlDbType.NVarChar).Value = product_type;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }
   
    // Edit Product

    public int Edit_Product(string product_full_name, string product_description, string product_hsnORsac, string country_of_origin, string product_full_description, string publish_status, string product_brand_name,string product_barcode, string product_sku,string super_point, string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set product_full_name=@product_full_name,product_description=@product_description,product_hsnORsac=@product_hsnORsac,country_of_origin=@country_of_origin,product_full_description=@product_full_description,publish_status=@publish_status,product_brand_name=@product_brand_name,product_barcode=@product_barcode,product_sku=@product_sku,super_point=@super_point where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_full_name", SqlDbType.NVarChar).Value = product_full_name;
            cmd.Parameters.AddWithValue("@product_description", SqlDbType.NVarChar).Value = product_description;
            cmd.Parameters.AddWithValue("@product_hsnORsac", SqlDbType.NVarChar).Value = product_hsnORsac;
            cmd.Parameters.AddWithValue("@country_of_origin", SqlDbType.NVarChar).Value = country_of_origin;
            cmd.Parameters.AddWithValue("@product_full_description", SqlDbType.NVarChar).Value = product_full_description;
            cmd.Parameters.AddWithValue("@publish_status", SqlDbType.NVarChar).Value = publish_status;
            cmd.Parameters.AddWithValue("@product_barcode", SqlDbType.NVarChar).Value = product_barcode;
            cmd.Parameters.AddWithValue("@product_brand_name", SqlDbType.NVarChar).Value = product_brand_name;

            cmd.Parameters.AddWithValue("@product_sku", SqlDbType.NVarChar).Value = product_sku;
            cmd.Parameters.AddWithValue("@super_point", SqlDbType.NVarChar).Value = super_point;

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

    // Add Product Price

    public int Add_Product_Price(string product_id, string product_unit, string product_unit_value, string product_GST_type, string product_GST_percentage, string product_GST_rate, string product_CGST_percentage, string product_CGST_rate, string product_SGST_percentage, string product_SGST_rate, string product_market_price, string product_sell_price, string product_discount_percentage, string product_discount_price, string product_with_gst_Price, string product_final_sell_price, string product_shipping_charge, string product_stock, string product_tax_type,string original_price)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_product_price(product_id,product_unit,product_unit_value,product_GST_type,product_GST_percentage,product_GST_rate,product_CGST_percentage,product_CGST_rate,product_SGST_percentage,product_SGST_rate,product_market_price,product_sell_price,product_discount_percentage,product_discount_price,product_with_gst_Price,product_final_sell_price,product_shipping_charge,product_stock,product_tax_type,original_price) values (@product_id,@product_unit,@product_unit_value,@product_GST_type,@product_GST_percentage,@product_GST_rate,@product_CGST_percentage,@product_CGST_rate,@product_SGST_percentage,@product_SGST_rate,@product_market_price,@product_sell_price,@product_discount_percentage,@product_discount_price,@product_with_gst_Price,@product_final_sell_price,@product_shipping_charge,@product_stock,@product_tax_type,@original_price)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@product_unit", SqlDbType.NVarChar).Value = product_unit;
            cmd.Parameters.AddWithValue("@product_unit_value", SqlDbType.NVarChar).Value = product_unit_value;

            cmd.Parameters.AddWithValue("@product_GST_type", SqlDbType.NVarChar).Value = product_GST_type;
            cmd.Parameters.AddWithValue("@product_GST_percentage", SqlDbType.NVarChar).Value = product_GST_percentage;
            cmd.Parameters.AddWithValue("@product_GST_rate", SqlDbType.NVarChar).Value = product_GST_rate;

            cmd.Parameters.AddWithValue("@product_CGST_percentage", SqlDbType.NVarChar).Value = product_CGST_percentage;
            cmd.Parameters.AddWithValue("@product_CGST_rate", SqlDbType.NVarChar).Value = product_CGST_rate;
            cmd.Parameters.AddWithValue("@product_SGST_percentage", SqlDbType.NVarChar).Value = product_SGST_percentage;

            cmd.Parameters.AddWithValue("@product_SGST_rate", SqlDbType.NVarChar).Value = product_SGST_rate;
            cmd.Parameters.AddWithValue("@product_market_price", SqlDbType.NVarChar).Value = product_market_price;
            cmd.Parameters.AddWithValue("@product_sell_price", SqlDbType.NVarChar).Value = product_sell_price;

            cmd.Parameters.AddWithValue("@product_discount_percentage", SqlDbType.NVarChar).Value = product_discount_percentage;
            cmd.Parameters.AddWithValue("@product_discount_price", SqlDbType.NVarChar).Value = product_discount_price;
            cmd.Parameters.AddWithValue("@product_with_gst_Price", SqlDbType.NVarChar).Value = product_with_gst_Price;

            cmd.Parameters.AddWithValue("@product_final_sell_price", SqlDbType.NVarChar).Value = product_final_sell_price;
            cmd.Parameters.AddWithValue("@product_shipping_charge", SqlDbType.NVarChar).Value = product_shipping_charge;
            cmd.Parameters.AddWithValue("@product_stock", SqlDbType.NVarChar).Value = product_stock;

            cmd.Parameters.AddWithValue("@product_tax_type", SqlDbType.NVarChar).Value = product_tax_type;
            cmd.Parameters.AddWithValue("@original_price", SqlDbType.NVarChar).Value = original_price;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            return (RowsAffected);
        }
        return (RowsAffected);
    }

    public int Edit_Product_Price(string product_unit, string product_unit_value, string product_GST_type, string product_GST_percentage, string product_GST_rate, string product_CGST_percentage, string product_CGST_rate, string product_SGST_percentage, string product_SGST_rate, string product_market_price, string product_sell_price, string product_discount_percentage, string product_discount_price, string product_with_gst_Price, string product_final_sell_price, string product_stock, string product_tax_type,string original_price, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product_price Set product_unit=@product_unit,product_unit_value=@product_unit_value,product_GST_type=@product_GST_type,product_GST_percentage=@product_GST_percentage,product_GST_rate=@product_GST_rate,product_CGST_percentage=@product_CGST_percentage,product_CGST_rate=@product_CGST_rate,product_SGST_percentage=@product_SGST_percentage,product_SGST_rate=@product_SGST_rate,product_market_price=@product_market_price,product_sell_price=@product_sell_price,product_discount_percentage=@product_discount_percentage,product_discount_price=@product_discount_price,product_with_gst_Price=@product_with_gst_Price,product_final_sell_price=@product_final_sell_price,product_stock=@product_stock,product_tax_type=@product_tax_type,original_price=@original_price  where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_unit", SqlDbType.NVarChar).Value = product_unit;
            cmd.Parameters.AddWithValue("@product_unit_value", SqlDbType.NVarChar).Value = product_unit_value;

            cmd.Parameters.AddWithValue("@product_GST_type", SqlDbType.NVarChar).Value = product_GST_type;
            cmd.Parameters.AddWithValue("@product_GST_percentage", SqlDbType.NVarChar).Value = product_GST_percentage;
            cmd.Parameters.AddWithValue("@product_GST_rate", SqlDbType.NVarChar).Value = product_GST_rate;

            cmd.Parameters.AddWithValue("@product_CGST_percentage", SqlDbType.NVarChar).Value = product_CGST_percentage;
            cmd.Parameters.AddWithValue("@product_CGST_rate", SqlDbType.NVarChar).Value = product_CGST_rate;
            cmd.Parameters.AddWithValue("@product_SGST_percentage", SqlDbType.NVarChar).Value = product_SGST_percentage;

            cmd.Parameters.AddWithValue("@product_SGST_rate", SqlDbType.NVarChar).Value = product_SGST_rate;
            cmd.Parameters.AddWithValue("@product_market_price", SqlDbType.NVarChar).Value = product_market_price;
            cmd.Parameters.AddWithValue("@product_sell_price", SqlDbType.NVarChar).Value = product_sell_price;

            cmd.Parameters.AddWithValue("@product_discount_percentage", SqlDbType.NVarChar).Value = product_discount_percentage;
            cmd.Parameters.AddWithValue("@product_discount_price", SqlDbType.NVarChar).Value = product_discount_price;
            cmd.Parameters.AddWithValue("@product_with_gst_Price", SqlDbType.NVarChar).Value = product_with_gst_Price;

            cmd.Parameters.AddWithValue("@product_final_sell_price", SqlDbType.NVarChar).Value = product_final_sell_price;
            cmd.Parameters.AddWithValue("@product_stock", SqlDbType.NVarChar).Value = product_stock;

            cmd.Parameters.AddWithValue("@product_tax_type", SqlDbType.NVarChar).Value = product_tax_type;
            cmd.Parameters.AddWithValue("@original_price", SqlDbType.NVarChar).Value = original_price;

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


    // Update Product Attribute/Variation

    public int Update_Product_Variation(string attribute_title_1, string attribute_title_2,string attribute_title_3,string attribute_value_1,string attribute_value_2,string attribute_value_3,string variants_id,string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set attribute_title_1=@attribute_title_1,attribute_title_2=@attribute_title_2,attribute_title_3=@attribute_title_3,attribute_value_1=@attribute_value_1,attribute_value_2=@attribute_value_2,attribute_value_3=@attribute_value_3,variants_id=@variants_id where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@attribute_title_1", SqlDbType.NVarChar).Value = attribute_title_1;
            cmd.Parameters.AddWithValue("@attribute_title_2", SqlDbType.NVarChar).Value = attribute_title_2;
            cmd.Parameters.AddWithValue("@attribute_title_3", SqlDbType.NVarChar).Value = attribute_title_3;

            cmd.Parameters.AddWithValue("@attribute_value_1", SqlDbType.NVarChar).Value = attribute_value_1;
            cmd.Parameters.AddWithValue("@attribute_value_2", SqlDbType.NVarChar).Value = attribute_value_2;
            cmd.Parameters.AddWithValue("@attribute_value_3", SqlDbType.NVarChar).Value = attribute_value_3;
            cmd.Parameters.AddWithValue("@variants_id", SqlDbType.NVarChar).Value = variants_id;

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


    // Product Variaion

    public int Add_Product_Variation(string variation_id, string category_id, string attributes_id, string product_id,string attributes_value,string product_sell_price,string product_discount_percentage,string product_discount_price,string product_with_gst_Price,string product_final_sell_price,string product_stock,string variation_type)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into product_variations(variation_id,category_id,attributes_id,product_id,attributes_value,product_sell_price,product_discount_percentage,product_discount_price,product_with_gst_Price,product_final_sell_price,product_stock,variation_type) values (@variation_id,@category_id,@attributes_id,@product_id,@attributes_value,@product_sell_price,@product_discount_percentage,@product_discount_price,@product_with_gst_Price,@product_final_sell_price,@product_stock,@variation_type)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@variation_id", SqlDbType.NVarChar).Value = variation_id;
            cmd.Parameters.AddWithValue("@category_id", SqlDbType.NVarChar).Value = category_id;
            cmd.Parameters.AddWithValue("@attributes_id", SqlDbType.NVarChar).Value = attributes_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@attributes_value", SqlDbType.NVarChar).Value = attributes_value;

            cmd.Parameters.AddWithValue("@product_sell_price", SqlDbType.NVarChar).Value = product_sell_price;
            cmd.Parameters.AddWithValue("@product_discount_percentage", SqlDbType.NVarChar).Value = product_discount_percentage;
            cmd.Parameters.AddWithValue("@product_discount_price", SqlDbType.NVarChar).Value = product_discount_price;
            cmd.Parameters.AddWithValue("@product_with_gst_Price", SqlDbType.NVarChar).Value = product_with_gst_Price;
            cmd.Parameters.AddWithValue("@product_final_sell_price", SqlDbType.NVarChar).Value = product_final_sell_price;
            cmd.Parameters.AddWithValue("@product_stock", SqlDbType.NVarChar).Value = product_stock;
            cmd.Parameters.AddWithValue("@variation_type", SqlDbType.NVarChar).Value = variation_type;
         
            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Combination

    public int product_combination(string combination_title, string combination_id, string product_id, string display_order, string seller_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into product_combination(combination_title,combination_id,product_id,display_order,seller_id) values (@combination_title,@combination_id,@product_id,@display_order,@seller_id)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@combination_title", SqlDbType.NVarChar).Value = combination_title;
            cmd.Parameters.AddWithValue("@combination_id", SqlDbType.NVarChar).Value = combination_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@display_order", SqlDbType.NVarChar).Value = display_order;
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

    public int Update_product_combination(string id, string combination_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update product_combination Set combination_id=@combination_id where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@combination_id", SqlDbType.NVarChar).Value = combination_id;
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

    // Add Product Photo

    public int Add_Product_Photo(string product_id, string photo_path)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_product_photos(product_id,photo_path) values (@product_id,@photo_path)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@photo_path", SqlDbType.NVarChar).Value = photo_path;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Product Category

    public int Edit_Product_Category(string product_parent_category_id, string product_parent_category_name, string product_sub_category_id, string product_sub_category_name,string verticle_id,string verticle_name, string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set product_parent_category_id=@product_parent_category_id,product_parent_category_name=@product_parent_category_name,product_sub_category_id=@product_sub_category_id,product_sub_category_name=@product_sub_category_name,verticle_id=@verticle_id,verticle_name=@verticle_name where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_parent_category_id", SqlDbType.NVarChar).Value = product_parent_category_id;
            cmd.Parameters.AddWithValue("@product_parent_category_name", SqlDbType.NVarChar).Value = product_parent_category_name;
            cmd.Parameters.AddWithValue("@product_sub_category_id", SqlDbType.NVarChar).Value = product_sub_category_id;
            cmd.Parameters.AddWithValue("@product_sub_category_name", SqlDbType.NVarChar).Value = product_sub_category_name;

            cmd.Parameters.AddWithValue("@verticle_id", SqlDbType.NVarChar).Value = verticle_id;
            cmd.Parameters.AddWithValue("@verticle_name", SqlDbType.NVarChar).Value = verticle_name;

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


    // Category > Sub Category > Verticle

    public int Add_Verticle(string category_id, string sub_category_id,string verticle_name,string verticle_status,string display_order,string verticle_title)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_verticle(category_id,sub_category_id,verticle_name,verticle_status,display_order,verticle_title) values (@category_id,@sub_category_id,@verticle_name,@verticle_status,@display_order,@verticle_title)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@category_id", SqlDbType.NVarChar).Value = category_id;
            cmd.Parameters.AddWithValue("@sub_category_id", SqlDbType.NVarChar).Value = sub_category_id;
            cmd.Parameters.AddWithValue("@verticle_name", SqlDbType.NVarChar).Value = verticle_name;
            cmd.Parameters.AddWithValue("@verticle_status", SqlDbType.NVarChar).Value = verticle_status;
            cmd.Parameters.AddWithValue("@display_order", SqlDbType.NVarChar).Value = display_order;
            cmd.Parameters.AddWithValue("@verticle_title", SqlDbType.NVarChar).Value = verticle_title;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Verticle(string category_id, string sub_category_id, string verticle_name, string verticle_status,string verticle_title, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_verticle Set category_id=@category_id,sub_category_id=@sub_category_id,verticle_name=@verticle_name,verticle_status=@verticle_status,verticle_title=@verticle_title where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@category_id", SqlDbType.NVarChar).Value = category_id;
            cmd.Parameters.AddWithValue("@sub_category_id", SqlDbType.NVarChar).Value = sub_category_id;
            cmd.Parameters.AddWithValue("@verticle_name", SqlDbType.NVarChar).Value = verticle_name;
            cmd.Parameters.AddWithValue("@verticle_status", SqlDbType.NVarChar).Value = verticle_status;
            cmd.Parameters.AddWithValue("@verticle_title", SqlDbType.NVarChar).Value = verticle_title;

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

    public int Edit_Verticle_Status(string verticle_status, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_verticle Set verticle_status=@verticle_status where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@verticle_status", SqlDbType.NVarChar).Value = verticle_status;
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


    // Brand

    public int Add_Brand(string brand_name,string display_order)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_brand(brand_name,display_order) values (@brand_name,@display_order)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@brand_name", SqlDbType.NVarChar).Value = brand_name;
            cmd.Parameters.AddWithValue("@display_order", SqlDbType.NVarChar).Value = display_order;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Brand(string brand_name, string display_order,string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_brand Set  brand_name=@brand_name,display_order=@display_order  where id=@id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@brand_name", SqlDbType.NVarChar).Value = brand_name;
            cmd.Parameters.AddWithValue("@display_order", SqlDbType.NVarChar).Value = display_order;

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

    // Update product SEO

    public int Edit_Product_Seo(string meta_title, string meta_description,string meta_keyword,string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set meta_title=@meta_title,meta_description=@meta_description,meta_keyword=@meta_keyword where product_id=@product_id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@meta_title", SqlDbType.NVarChar).Value = meta_title;
            cmd.Parameters.AddWithValue("@meta_description", SqlDbType.NVarChar).Value = meta_description;
            cmd.Parameters.AddWithValue("@meta_keyword", SqlDbType.NVarChar).Value = meta_keyword;

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

    public int Edit_Category(string main_category_id, string category_name, string category_status,string category_orderno,string category_title, string category_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_category set main_category_id=@main_category_id,category_name=@category_name,category_status=@category_status,category_orderno=@category_orderno,category_title=@category_title where category_id=@category_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@main_category_id", SqlDbType.NVarChar).Value = main_category_id;
            cmd.Parameters.AddWithValue("@category_name", SqlDbType.NVarChar).Value = category_name;
            cmd.Parameters.AddWithValue("@category_status", SqlDbType.NVarChar).Value = category_status;
            cmd.Parameters.AddWithValue("@category_orderno", SqlDbType.NVarChar).Value = category_orderno;
            cmd.Parameters.AddWithValue("@category_title", SqlDbType.NVarChar).Value = category_title;

            cmd.Parameters.AddWithValue("@category_id", SqlDbType.NVarChar).Value = category_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Product_Main_Category_name(string product_parent_category_name, string product_parent_category_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set  product_parent_category_name=@product_parent_category_name  where product_parent_category_id=@product_parent_category_id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_parent_category_name", SqlDbType.NVarChar).Value = product_parent_category_name;
            cmd.Parameters.AddWithValue("@product_parent_category_id", SqlDbType.NVarChar).Value = product_parent_category_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Product_Sub_Category_name(string product_sub_category_name, string product_sub_category_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set product_sub_category_name=@product_sub_category_name  where product_sub_category_id=@product_sub_category_id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_sub_category_name", SqlDbType.NVarChar).Value = product_sub_category_name;
            cmd.Parameters.AddWithValue("@product_sub_category_id", SqlDbType.NVarChar).Value = product_sub_category_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Edit_Product_vertical_name(string verticle_name, string verticle_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set verticle_name=@verticle_name  where verticle_id=@verticle_id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@verticle_name", SqlDbType.NVarChar).Value = verticle_name;
            cmd.Parameters.AddWithValue("@verticle_id", SqlDbType.NVarChar).Value = verticle_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }



    // Coupon 


    public int Add_Coupon(string coupan_code, string coupan_value, string coupan_expiry_date, string coupan_description, string coupan_min_order, string coupan_max_discount)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_coupan(coupan_code,coupan_value,coupan_expiry_date,coupan_description,coupan_min_order,coupan_max_discount) values (@coupan_code,@coupan_value,@coupan_expiry_date,@coupan_description,@coupan_min_order,@coupan_max_discount)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@coupan_code", SqlDbType.NVarChar).Value = coupan_code;
            cmd.Parameters.AddWithValue("@coupan_value", SqlDbType.NVarChar).Value = coupan_value;
            cmd.Parameters.AddWithValue("@coupan_expiry_date", SqlDbType.NVarChar).Value = coupan_expiry_date;
            cmd.Parameters.AddWithValue("@coupan_description", SqlDbType.NVarChar).Value = coupan_description;
            cmd.Parameters.AddWithValue("@coupan_min_order", SqlDbType.NVarChar).Value = coupan_min_order;
            cmd.Parameters.AddWithValue("@coupan_max_discount", SqlDbType.NVarChar).Value = coupan_max_discount;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    public int Edit_Coupon(string coupan_code, string coupan_value, string coupan_expiry_date, string coupan_description, string coupan_min_order, string coupan_max_discount, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_coupan Set  coupan_code=@coupan_code,coupan_value=@coupan_value,coupan_expiry_date=@coupan_expiry_date,coupan_description=@coupan_description,coupan_min_order=@coupan_min_order,coupan_max_discount=@coupan_max_discount where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@coupan_code", SqlDbType.NVarChar).Value = coupan_code;
            cmd.Parameters.AddWithValue("@coupan_value", SqlDbType.NVarChar).Value = coupan_value;
            cmd.Parameters.AddWithValue("@coupan_expiry_date", SqlDbType.NVarChar).Value = coupan_expiry_date;
            cmd.Parameters.AddWithValue("@coupan_description", SqlDbType.NVarChar).Value = coupan_description;

            cmd.Parameters.AddWithValue("@coupan_min_order", SqlDbType.NVarChar).Value = coupan_min_order;
            cmd.Parameters.AddWithValue("@coupan_max_discount", SqlDbType.NVarChar).Value = coupan_max_discount;

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
    // Payment Mode

    public int Update_Payment_Mode_Status(string mode_status, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_payment_mode Set mode_status=@mode_status where id=@id ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@mode_status", mode_status);
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

    public int Update_Payment_Api(string api_key, string secret_key,string mode_status, string payment_mode)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_payment_mode Set api_key=@api_key,secret_key=@secret_key,mode_status=@mode_status where payment_mode=@payment_mode ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@api_key", SqlDbType.NVarChar).Value= api_key;
            cmd.Parameters.AddWithValue("@secret_key", SqlDbType.NVarChar).Value = secret_key;
            cmd.Parameters.AddWithValue("@mode_status", SqlDbType.NVarChar).Value = mode_status;
            cmd.Parameters.AddWithValue("@payment_mode", SqlDbType.NVarChar).Value = payment_mode;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // SMS

    public int Add_SMS_Api(string sms_firm, string sms_user_name, string sms_hash, string sms_sender)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_sms(sms_firm,sms_user_name,sms_hash,sms_sender) values (@sms_firm,@sms_user_name,@sms_hash,@sms_sender)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@sms_firm", SqlDbType.NVarChar).Value = sms_firm;
            cmd.Parameters.AddWithValue("@sms_user_name", SqlDbType.NVarChar).Value = sms_user_name;
            cmd.Parameters.AddWithValue("@sms_hash", SqlDbType.NVarChar).Value = sms_hash;
            cmd.Parameters.AddWithValue("@sms_sender", SqlDbType.NVarChar).Value = sms_sender;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_SMS_Api(string sms_user_name, string sms_hash, string sms_sender)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_sms Set sms_user_name=@sms_user_name,sms_hash=@sms_hash,sms_sender=@sms_sender ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@sms_user_name", SqlDbType.NVarChar).Value = sms_user_name;
            cmd.Parameters.AddWithValue("@sms_hash", SqlDbType.NVarChar).Value = sms_hash;
            cmd.Parameters.AddWithValue("@sms_sender", SqlDbType.NVarChar).Value = sms_sender;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Firm Social

    public int Add_Social_Firm(string firm_fb_link, string firm_tw_link, string firm_insta_link,string firm_yt_link,string firm_linkedin_link)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_firm_details(firm_fb_link,firm_tw_link,firm_insta_link,firm_yt_link,firm_linkedin_link) values (@firm_fb_link,@firm_tw_link,@firm_insta_link,@firm_yt_link,@firm_linkedin_link)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@firm_fb_link", SqlDbType.NVarChar).Value = firm_fb_link;
            cmd.Parameters.AddWithValue("@firm_tw_link", SqlDbType.NVarChar).Value = firm_tw_link;
            cmd.Parameters.AddWithValue("@firm_insta_link", SqlDbType.NVarChar).Value = firm_insta_link;
            cmd.Parameters.AddWithValue("@firm_yt_link", SqlDbType.NVarChar).Value = firm_yt_link;
            cmd.Parameters.AddWithValue("@firm_linkedin_link", SqlDbType.NVarChar).Value = firm_linkedin_link;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Social_Firm(string firm_fb_link, string firm_tw_link, string firm_insta_link, string firm_yt_link, string firm_linkedin_link)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_firm_details Set  firm_fb_link=@firm_fb_link,firm_tw_link=@firm_tw_link,firm_insta_link=@firm_insta_link,firm_yt_link=@firm_yt_link,firm_linkedin_link=@firm_linkedin_link";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@firm_fb_link", SqlDbType.NVarChar).Value = firm_fb_link;
            cmd.Parameters.AddWithValue("@firm_tw_link", SqlDbType.NVarChar).Value = firm_tw_link;
            cmd.Parameters.AddWithValue("@firm_insta_link", SqlDbType.NVarChar).Value = firm_insta_link;
            cmd.Parameters.AddWithValue("@firm_yt_link", SqlDbType.NVarChar).Value = firm_yt_link;
            cmd.Parameters.AddWithValue("@firm_linkedin_link", SqlDbType.NVarChar).Value = firm_linkedin_link;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Google Integration

    public int Add_Google_inetration(string integration_title, string integration_path,string tracking_code)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_integration(integration_title,integration_path,tracking_code) values (@integration_title,@integration_path,@tracking_code)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@integration_title", SqlDbType.NVarChar).Value = integration_title;
            cmd.Parameters.AddWithValue("@integration_path", SqlDbType.NVarChar).Value = integration_path;
            cmd.Parameters.AddWithValue("@tracking_code", SqlDbType.NVarChar).Value = tracking_code;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Google_inetration(string tracking_code, string integration_title)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_integration Set tracking_code=@tracking_code where integration_title=@integration_title";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@tracking_code", SqlDbType.NVarChar).Value = tracking_code;
            cmd.Parameters.AddWithValue("@integration_title", SqlDbType.NVarChar).Value = integration_title;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Slider_Link(string slider_link, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_slider Set slider_link=@slider_link where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@slider_link", SqlDbType.NVarChar).Value = slider_link;
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

    // Pincode

    public int Add_Pincode(string state_name, string city_name, string pincode, string area)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_pincode(state_name,city_name,pincode,area) values (@state_name,@city_name,@pincode,@area)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@state_name", SqlDbType.NVarChar).Value = state_name;
            cmd.Parameters.AddWithValue("@city_name", SqlDbType.NVarChar).Value = city_name;
            cmd.Parameters.AddWithValue("@pincode", SqlDbType.NVarChar).Value = pincode;
            cmd.Parameters.AddWithValue("@area", SqlDbType.NVarChar).Value = area;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    public int Edit_Pincode_Area(string state_name, string city_name, string pincode, string area, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_pincode Set state_name=@state_name,city_name=@city_name,pincode=@pincode,area=@area where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@state_name", SqlDbType.NVarChar).Value = state_name;
            cmd.Parameters.AddWithValue("@city_name", SqlDbType.NVarChar).Value = city_name;
            cmd.Parameters.AddWithValue("@pincode", SqlDbType.NVarChar).Value = pincode;
            cmd.Parameters.AddWithValue("@area", SqlDbType.NVarChar).Value = area;
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


    public int Edit_Pincode_City_name(string new_city_name, string old_city_name)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_pincode Set city_name=@new_city_name where city_name=@old_city_name";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@new_city_name", SqlDbType.NVarChar).Value = new_city_name;
            cmd.Parameters.AddWithValue("@old_city_name", SqlDbType.NVarChar).Value = old_city_name;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }


    // In Between Banner

    public int Add_Between_Banner(string banner_option, string photo_path, string photo_link,string link_title)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into in_between_banner(banner_option,photo_path,photo_link,link_title) values (@banner_option,@photo_path,@photo_link,@link_title)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@banner_option", SqlDbType.NVarChar).Value = banner_option;
            cmd.Parameters.AddWithValue("@photo_path", SqlDbType.NVarChar).Value = photo_path;
            cmd.Parameters.AddWithValue("@photo_link", SqlDbType.NVarChar).Value = photo_link;
            cmd.Parameters.AddWithValue("@link_title", SqlDbType.NVarChar).Value = link_title;


            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Categort SuperPoint

    public int Update_Category_Point(string super_point,string category_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_category Set super_point=@super_point Where category_id=@category_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@super_point", SqlDbType.NVarChar).Value= super_point;
            cmd.Parameters.AddWithValue("@category_id", SqlDbType.NVarChar).Value = category_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Update Point

    public int Update_Product_Point(string super_point, string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set super_point=@super_point Where product_id=@product_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@super_point", SqlDbType.NVarChar).Value = super_point;
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

    // Food Item

    // Add Food Item

    public int Add_Food_Item(string product_temp_id, string product_id, string product_full_name, string product_description, string product_parent_category_id, string product_parent_category_name,string product_full_description, string publish_status,string product_type,string food_type)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_product(product_temp_id,product_id,product_full_name,product_description,product_parent_category_id,product_parent_category_name,product_full_description,publish_status,product_type,food_type) values (@product_temp_id,@product_id,@product_full_name,@product_description,@product_parent_category_id,@product_parent_category_name,@product_full_description,@publish_status,@product_type,@food_type)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_temp_id", SqlDbType.NVarChar).Value = product_temp_id;
            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@product_full_name", SqlDbType.NVarChar).Value = product_full_name;
            cmd.Parameters.AddWithValue("@product_description", SqlDbType.NVarChar).Value = product_description;
            cmd.Parameters.AddWithValue("@product_parent_category_id", SqlDbType.NVarChar).Value = product_parent_category_id;
            cmd.Parameters.AddWithValue("@product_parent_category_name", SqlDbType.NVarChar).Value = product_parent_category_name;
            cmd.Parameters.AddWithValue("@product_full_description", SqlDbType.NVarChar).Value = product_full_description;
            cmd.Parameters.AddWithValue("@publish_status", SqlDbType.NVarChar).Value = publish_status;
            cmd.Parameters.AddWithValue("@product_type", SqlDbType.NVarChar).Value = product_type;
            cmd.Parameters.AddWithValue("@food_type", SqlDbType.NVarChar).Value = food_type;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Edit Food Item

    public int Edit_Food_Item(string product_full_name, string product_description, string product_parent_category_id, string product_parent_category_name, string product_full_description, string publish_status, string product_type, string food_type, string product_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product Set product_full_name=@product_full_name,product_description=@product_description,product_parent_category_id=@product_parent_category_id,product_parent_category_name=@product_parent_category_name,product_full_description=@product_full_description,publish_status=@publish_status,product_type=@product_type,food_type=@food_type Where product_id=@product_id";
            cmd.CommandType = CommandType.Text;
           
            cmd.Parameters.AddWithValue("@product_full_name", SqlDbType.NVarChar).Value = product_full_name;
            cmd.Parameters.AddWithValue("@product_description", SqlDbType.NVarChar).Value = product_description;
            cmd.Parameters.AddWithValue("@product_parent_category_id", SqlDbType.NVarChar).Value = product_parent_category_id;
            cmd.Parameters.AddWithValue("@product_parent_category_name", SqlDbType.NVarChar).Value = product_parent_category_name;
            cmd.Parameters.AddWithValue("@product_full_description", SqlDbType.NVarChar).Value = product_full_description;
            cmd.Parameters.AddWithValue("@publish_status", SqlDbType.NVarChar).Value = publish_status;
            cmd.Parameters.AddWithValue("@product_type", SqlDbType.NVarChar).Value = product_type;
            cmd.Parameters.AddWithValue("@food_type", SqlDbType.NVarChar).Value = food_type;

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

    // Add Food Price By Restaurant

    public int Add_Food_Price(string product_id, string product_unit, string product_unit_value, string product_GST_type, string product_GST_percentage, string product_GST_rate, string product_CGST_percentage, string product_CGST_rate, string product_SGST_percentage, string product_SGST_rate, string product_market_price, string product_sell_price, string product_discount_percentage, string product_discount_price, string product_with_gst_Price, string product_final_sell_price, string product_shipping_charge, string product_stock, string product_tax_type,string price_seller_id,string price_seller_name,string original_price)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_product_price(product_id,product_unit,product_unit_value,product_GST_type,product_GST_percentage,product_GST_rate,product_CGST_percentage,product_CGST_rate,product_SGST_percentage,product_SGST_rate,product_market_price,product_sell_price,product_discount_percentage,product_discount_price,product_with_gst_Price,product_final_sell_price,product_shipping_charge,product_stock,product_tax_type,price_seller_id,price_seller_name,original_price) values (@product_id,@product_unit,@product_unit_value,@product_GST_type,@product_GST_percentage,@product_GST_rate,@product_CGST_percentage,@product_CGST_rate,@product_SGST_percentage,@product_SGST_rate,@product_market_price,@product_sell_price,@product_discount_percentage,@product_discount_price,@product_with_gst_Price,@product_final_sell_price,@product_shipping_charge,@product_stock,@product_tax_type,@price_seller_id,@price_seller_name,@original_price)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_id", SqlDbType.NVarChar).Value = product_id;
            cmd.Parameters.AddWithValue("@product_unit", SqlDbType.NVarChar).Value = product_unit;
            cmd.Parameters.AddWithValue("@product_unit_value", SqlDbType.NVarChar).Value = product_unit_value;

            cmd.Parameters.AddWithValue("@product_GST_type", SqlDbType.NVarChar).Value = product_GST_type;
            cmd.Parameters.AddWithValue("@product_GST_percentage", SqlDbType.NVarChar).Value = product_GST_percentage;
            cmd.Parameters.AddWithValue("@product_GST_rate", SqlDbType.NVarChar).Value = product_GST_rate;

            cmd.Parameters.AddWithValue("@product_CGST_percentage", SqlDbType.NVarChar).Value = product_CGST_percentage;
            cmd.Parameters.AddWithValue("@product_CGST_rate", SqlDbType.NVarChar).Value = product_CGST_rate;
            cmd.Parameters.AddWithValue("@product_SGST_percentage", SqlDbType.NVarChar).Value = product_SGST_percentage;

            cmd.Parameters.AddWithValue("@product_SGST_rate", SqlDbType.NVarChar).Value = product_SGST_rate;
            cmd.Parameters.AddWithValue("@product_market_price", SqlDbType.NVarChar).Value = product_market_price;
            cmd.Parameters.AddWithValue("@product_sell_price", SqlDbType.NVarChar).Value = product_sell_price;

            cmd.Parameters.AddWithValue("@product_discount_percentage", SqlDbType.NVarChar).Value = product_discount_percentage;
            cmd.Parameters.AddWithValue("@product_discount_price", SqlDbType.NVarChar).Value = product_discount_price;
            cmd.Parameters.AddWithValue("@product_with_gst_Price", SqlDbType.NVarChar).Value = product_with_gst_Price;

            cmd.Parameters.AddWithValue("@product_final_sell_price", SqlDbType.NVarChar).Value = product_final_sell_price;
            cmd.Parameters.AddWithValue("@product_shipping_charge", SqlDbType.NVarChar).Value = product_shipping_charge;
            cmd.Parameters.AddWithValue("@product_stock", SqlDbType.NVarChar).Value = product_stock;

            cmd.Parameters.AddWithValue("@product_tax_type", SqlDbType.NVarChar).Value = product_tax_type;
            cmd.Parameters.AddWithValue("@price_seller_id", SqlDbType.NVarChar).Value = price_seller_id;
            cmd.Parameters.AddWithValue("@price_seller_name", SqlDbType.NVarChar).Value = price_seller_name;
            cmd.Parameters.AddWithValue("@original_price", SqlDbType.NVarChar).Value = original_price;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            return (RowsAffected);
        }
        return (RowsAffected);
    }

    public int Edit_Food_Price(string product_unit, string product_unit_value, string product_GST_type, string product_GST_percentage, string product_GST_rate, string product_CGST_percentage, string product_CGST_rate, string product_SGST_percentage, string product_SGST_rate, string product_market_price, string product_sell_price, string product_discount_percentage, string product_discount_price, string product_with_gst_Price, string product_final_sell_price, string product_stock, string product_tax_type,string price_seller_id,string price_seller_name,string original_price, string id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_product_price Set product_unit=@product_unit,product_unit_value=@product_unit_value,product_GST_type=@product_GST_type,product_GST_percentage=@product_GST_percentage,product_GST_rate=@product_GST_rate,product_CGST_percentage=@product_CGST_percentage,product_CGST_rate=@product_CGST_rate,product_SGST_percentage=@product_SGST_percentage,product_SGST_rate=@product_SGST_rate,product_market_price=@product_market_price,product_sell_price=@product_sell_price,product_discount_percentage=@product_discount_percentage,product_discount_price=@product_discount_price,product_with_gst_Price=@product_with_gst_Price,product_final_sell_price=@product_final_sell_price,product_stock=@product_stock,product_tax_type=@product_tax_type,price_seller_id=@price_seller_id,price_seller_name=@price_seller_name,original_price=@original_price  where id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@product_unit", SqlDbType.NVarChar).Value = product_unit;
            cmd.Parameters.AddWithValue("@product_unit_value", SqlDbType.NVarChar).Value = product_unit_value;

            cmd.Parameters.AddWithValue("@product_GST_type", SqlDbType.NVarChar).Value = product_GST_type;
            cmd.Parameters.AddWithValue("@product_GST_percentage", SqlDbType.NVarChar).Value = product_GST_percentage;
            cmd.Parameters.AddWithValue("@product_GST_rate", SqlDbType.NVarChar).Value = product_GST_rate;

            cmd.Parameters.AddWithValue("@product_CGST_percentage", SqlDbType.NVarChar).Value = product_CGST_percentage;
            cmd.Parameters.AddWithValue("@product_CGST_rate", SqlDbType.NVarChar).Value = product_CGST_rate;
            cmd.Parameters.AddWithValue("@product_SGST_percentage", SqlDbType.NVarChar).Value = product_SGST_percentage;

            cmd.Parameters.AddWithValue("@product_SGST_rate", SqlDbType.NVarChar).Value = product_SGST_rate;
            cmd.Parameters.AddWithValue("@product_market_price", SqlDbType.NVarChar).Value = product_market_price;
            cmd.Parameters.AddWithValue("@product_sell_price", SqlDbType.NVarChar).Value = product_sell_price;

            cmd.Parameters.AddWithValue("@product_discount_percentage", SqlDbType.NVarChar).Value = product_discount_percentage;
            cmd.Parameters.AddWithValue("@product_discount_price", SqlDbType.NVarChar).Value = product_discount_price;
            cmd.Parameters.AddWithValue("@product_with_gst_Price", SqlDbType.NVarChar).Value = product_with_gst_Price;

            cmd.Parameters.AddWithValue("@product_final_sell_price", SqlDbType.NVarChar).Value = product_final_sell_price;
            cmd.Parameters.AddWithValue("@product_stock", SqlDbType.NVarChar).Value = product_stock;

            cmd.Parameters.AddWithValue("@product_tax_type", SqlDbType.NVarChar).Value = product_tax_type;

            cmd.Parameters.AddWithValue("@price_seller_id", SqlDbType.NVarChar).Value = price_seller_id;
            cmd.Parameters.AddWithValue("@price_seller_name", SqlDbType.NVarChar).Value = price_seller_name;
            cmd.Parameters.AddWithValue("@original_price", SqlDbType.NVarChar).Value = original_price;

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


    // Seller Reg.


    public int Seller_Registration(string seller_id, string seller_name, string seller_mobileno, string seller_password, string seller_date, string seller_time, string seller_paid_amount, string seller_due_amount, string seller_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_seller(seller_id,seller_name,seller_mobileno,seller_password,seller_date,seller_time,seller_paid_amount,seller_due_amount,seller_status) values (@seller_id,@seller_name,@seller_mobileno,@seller_password,@seller_date,@seller_time,@seller_paid_amount,@seller_due_amount,@seller_status)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@seller_id", SqlDbType.NVarChar).Value = seller_id;
            cmd.Parameters.AddWithValue("@seller_name", SqlDbType.NVarChar).Value = seller_name;
            cmd.Parameters.AddWithValue("@seller_mobileno", SqlDbType.NVarChar).Value = seller_mobileno;
            cmd.Parameters.AddWithValue("@seller_password", SqlDbType.NVarChar).Value = seller_password;

            cmd.Parameters.AddWithValue("@seller_date", SqlDbType.NVarChar).Value = seller_date;
            cmd.Parameters.AddWithValue("@seller_time", SqlDbType.NVarChar).Value = seller_time;
            cmd.Parameters.AddWithValue("@seller_paid_amount", SqlDbType.NVarChar).Value = seller_paid_amount;
            cmd.Parameters.AddWithValue("@seller_due_amount", SqlDbType.NVarChar).Value = seller_due_amount;

            cmd.Parameters.AddWithValue("@seller_status", SqlDbType.NVarChar).Value = seller_status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }



    public int Update_Seller_Registration(string seller_firm_name, string seller_address_line_1, string seller_state_id, string seller_state_name, string seller_city_id, string seller_city_name, string seller_pincode,string seller_area_id, string seller_gst, string seller_gst_state_code, string seller_gst_state,string opening_time,string closing_time, string seller_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_seller Set  seller_firm_name=@seller_firm_name,seller_address_line_1=@seller_address_line_1,seller_state_id=@seller_state_id,seller_state_name=@seller_state_name,seller_city_id=@seller_city_id,seller_city_name=@seller_city_name,seller_pincode=@seller_pincode,seller_area_id=@seller_area_id,seller_gst=@seller_gst,seller_gst_state_code=@seller_gst_state_code,seller_gst_state=@seller_gst_state,opening_time=@opening_time,closing_time=@closing_time where seller_id=@seller_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@seller_firm_name", SqlDbType.NVarChar).Value = seller_firm_name;
            cmd.Parameters.AddWithValue("@seller_address_line_1", SqlDbType.NVarChar).Value = seller_address_line_1;
            cmd.Parameters.AddWithValue("@seller_state_id", SqlDbType.NVarChar).Value = seller_state_id;
            cmd.Parameters.AddWithValue("@seller_state_name", SqlDbType.NVarChar).Value = seller_state_name;
            cmd.Parameters.AddWithValue("@seller_city_id", SqlDbType.NVarChar).Value = seller_city_id;
            cmd.Parameters.AddWithValue("@seller_city_name", SqlDbType.NVarChar).Value = seller_city_name;
            cmd.Parameters.AddWithValue("@seller_pincode", SqlDbType.NVarChar).Value = seller_pincode;
            cmd.Parameters.AddWithValue("@seller_area_id", SqlDbType.NVarChar).Value = seller_area_id;

            cmd.Parameters.AddWithValue("@seller_gst", SqlDbType.NVarChar).Value = seller_gst;

            cmd.Parameters.AddWithValue("@seller_gst_state_code", SqlDbType.NVarChar).Value = seller_gst_state_code;
            cmd.Parameters.AddWithValue("@seller_gst_state", SqlDbType.NVarChar).Value = seller_gst_state;
            
            cmd.Parameters.AddWithValue("@opening_time", SqlDbType.NVarChar).Value = opening_time;
            cmd.Parameters.AddWithValue("@closing_time", SqlDbType.NVarChar).Value = closing_time;

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


    public int Add_Seller_Document(string seller_id, string document_name, string document_path, string document_section,string document_no)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_seller_document(seller_id,document_name,document_path,document_section,document_no) values (@seller_id,@document_name,@document_path,@document_section,@document_no)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@seller_id", SqlDbType.NVarChar).Value = seller_id;
            cmd.Parameters.AddWithValue("@document_name", SqlDbType.NVarChar).Value = document_name;
            cmd.Parameters.AddWithValue("@document_path", SqlDbType.NVarChar).Value = document_path;

            cmd.Parameters.AddWithValue("@document_section", SqlDbType.NVarChar).Value = document_section;
            cmd.Parameters.AddWithValue("@document_no", SqlDbType.NVarChar).Value = document_no;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }



    public int Update_Seller_Profile(string seller_name, string seller_mobileno, string seller_firm_name, string seller_address_line_1, string seller_state_id, string seller_state_name, string seller_city_id, string seller_city_name, string seller_pincode,string seller_area_id, string seller_gst_state_code, string seller_gst_state,string seller_gst,string opening_time,string closing_time, string seller_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_seller Set seller_name=@seller_name,seller_mobileno=@seller_mobileno, seller_firm_name=@seller_firm_name,seller_address_line_1=@seller_address_line_1,seller_state_id=@seller_state_id,seller_state_name=@seller_state_name,seller_city_id=@seller_city_id,seller_city_name=@seller_city_name,seller_pincode=@seller_pincode,seller_area_id=@seller_area_id, seller_gst_state_code=@seller_gst_state_code,seller_gst_state=@seller_gst_state,seller_gst=@seller_gst,opening_time=@opening_time,closing_time=@closing_time where seller_id=@seller_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@seller_name", SqlDbType.NVarChar).Value = seller_name;
            cmd.Parameters.AddWithValue("@seller_mobileno", SqlDbType.NVarChar).Value = seller_mobileno;
            cmd.Parameters.AddWithValue("@seller_firm_name", SqlDbType.NVarChar).Value = seller_firm_name;
            cmd.Parameters.AddWithValue("@seller_address_line_1", SqlDbType.NVarChar).Value = seller_address_line_1;
            cmd.Parameters.AddWithValue("@seller_state_id", SqlDbType.NVarChar).Value = seller_state_id;
            cmd.Parameters.AddWithValue("@seller_state_name", SqlDbType.NVarChar).Value = seller_state_name;
            cmd.Parameters.AddWithValue("@seller_city_id", SqlDbType.NVarChar).Value = seller_city_id;
            cmd.Parameters.AddWithValue("@seller_city_name", SqlDbType.NVarChar).Value = seller_city_name;
            cmd.Parameters.AddWithValue("@seller_pincode", SqlDbType.NVarChar).Value = seller_pincode;
            cmd.Parameters.AddWithValue("@seller_area_id", SqlDbType.NVarChar).Value = seller_area_id;

            cmd.Parameters.AddWithValue("@seller_gst_state_code", SqlDbType.NVarChar).Value = seller_gst_state_code;
            cmd.Parameters.AddWithValue("@seller_gst_state", SqlDbType.NVarChar).Value = seller_gst_state;

            cmd.Parameters.AddWithValue("@seller_gst", SqlDbType.NVarChar).Value = seller_gst;
            cmd.Parameters.AddWithValue("@opening_time", SqlDbType.NVarChar).Value = opening_time;
            cmd.Parameters.AddWithValue("@closing_time", SqlDbType.NVarChar).Value = closing_time;

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

    public int Update_Seller_Photo(string seller_photo, string seller_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_seller Set seller_photo=@seller_photo  where seller_id=@seller_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@seller_photo", SqlDbType.NVarChar).Value = seller_photo;
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

    public int Update_Seller_Status(string seller_status, string seller_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_seller Set seller_status=@seller_status where seller_id=@seller_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@seller_status", SqlDbType.NVarChar).Value = seller_status;
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

    // Restaurant Menu Category

    public int Add_Restaurant_Menu_Category(string seller_id, string category_id,string category_name)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into ecommerce_seller_category(seller_id,category_id,category_name) values (@seller_id,@category_id,@category_name)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@seller_id", SqlDbType.NVarChar).Value = seller_id;
            cmd.Parameters.AddWithValue("@category_id", SqlDbType.NVarChar).Value = category_id;
            cmd.Parameters.AddWithValue("@category_name", SqlDbType.NVarChar).Value = category_name;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Customer_Status(string customer_status,string customer_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_customer Set customer_status=@customer_status Where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_status", SqlDbType.NVarChar).Value = customer_status;
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