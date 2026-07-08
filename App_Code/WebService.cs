using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class WebService : System.Web.Services.WebService
{

    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    
    public WebService()
    {

    }

     [WebMethod]
    public String login(string PASSWORD, string mobileno)
    {
        
        string output = string.Empty;
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT * FROM  ecommerce_customer where customer_mobileno = '" + mobileno + "' and customer_password = '" + Encrypted(PASSWORD) + "' and customer_status='Active'";
                #endregion 
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                output = JsonConvert.SerializeObject(dt);
                con.Close();
            }

        }
        catch (Exception ex)
        {
            string text = "My text that I want to display";

        }
        return output;
    }

	[WebMethod]
    public string get_cart_qty(string cart_guest_id,string customer_id)
    {
        string output = string.Empty;
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT count(*) carttotal from ecommerce_cart where (customer_id='"+customer_id+"' or cart_guest_id='"+cart_guest_id+"')";
                #endregion 
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                JavaScriptSerializer js = new JavaScriptSerializer();
                output = JsonConvert.SerializeObject(dt);
            }
        }
        catch (Exception ex)
        {
            string text = ex.ToString();

        }
        return output;

    }
	
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_category()
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  ecommerce_category";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_wishlist(string customer_id, string cart_guest_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT  (select case when count(*) > 0 then max(cart_qty) else 0 end from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id=a.product_id) as cart_qty,max(b.[id]) as id,MAX(a.[product_id]) as product_id,MAX(a.[product_full_name]) as product_full_name,MAX(a.[product_description]) as product_description,MAX(a.[product_parent_category_id]) as product_parent_category_id,MAX(a.[product_parent_category_name]) as product_parent_category_name,MAX(a.[product_sub_category_id]) as product_sub_category_id,MAX(a.[product_sub_category_name]) as product_sub_category_name,MAX(a.[product_full_description]) as product_full_description,MAX(a.[publish_status]) as publish_status,MAX(a.[country_of_origin]) as country_of_origin,MAX(a.[verticle_id]) as verticle_id,MAX(a.[verticle_name]) as verticle_name,MAX(b.[product_unit]) as product_unit,MAX(b.[product_unit_value]) as product_unit_value,MAX(b.[product_GST_type]) as product_GST_type,MAX(b.[product_tax_type]) as product_tax_type,MAX(b.[product_GST_percentage]) as product_GST_percentage,MAX(b.[product_GST_rate]) as product_GST_rate,MAX(b.[product_CGST_percentage]) as product_CGST_percentage,MAX(b.[product_CGST_rate]) as product_CGST_rate,MAX(b.[product_SGST_percentage]) as product_SGST_percentage,MAX(b.[product_SGST_rate]) as product_SGST_rate,MAX(b.[product_IGST_percentage]) as product_IGST_percentage,MAX(b.[product_IGST_rate]) as product_IGST_rate,MAX(b.[product_market_price]) as product_market_price,MAX(b.[product_sell_price]) as product_sell_price,MAX(b.[product_discount_percentage]) as product_discount_percentage,MAX(b.[product_discount_price]) as product_discount_price,MAX(b.[product_with_gst_Price]) as product_with_gst_Price,MAX(b.[product_final_sell_price]) as product_final_sell_price,MAX(b.[product_shipping_charge]) as product_shipping_charge,MAX(b.[product_stock]) as product_stock,MAX(d.photo_path) as photo_path FROM [ecommerce_product] a inner join [ecommerce_product_price] as b on a.product_id=b.product_id inner join ecommerce_product_photos as d on b.product_id=d.product_id where a.publish_status='Yes' and a.product_id=(select product_id from ecommerce_wishlist where customer_id='" + customer_id + "') group by a.[product_id],b.[product_final_sell_price] order by b.[product_final_sell_price] ASC";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }
	
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_TopSlider()
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  ecommerce_slider";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_Banner()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  ecommerce_banner";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_TopDeals(string customer_id, string cart_guest_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT top 10 (select case when count(*) > 0 then max(cart_qty) else 0 end from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id=a.product_id) as cart_qty,max(b.[id]) as id,MAX(a.[product_id]) as product_id,MAX(a.[product_full_name]) as product_full_name,MAX(a.[product_description]) as product_description,MAX(a.[product_parent_category_id]) as product_parent_category_id,MAX(a.[product_parent_category_name]) as product_parent_category_name,MAX(a.[product_sub_category_id]) as product_sub_category_id,MAX(a.[product_sub_category_name]) as product_sub_category_name,MAX(a.[product_full_description]) as product_full_description,MAX(a.[publish_status]) as publish_status,MAX(a.[country_of_origin]) as country_of_origin,MAX(a.[verticle_id]) as verticle_id,MAX(a.[verticle_name]) as verticle_name,MAX(b.[product_unit]) as product_unit,MAX(b.[product_unit_value]) as product_unit_value,MAX(b.[product_GST_type]) as product_GST_type,MAX(b.[product_tax_type]) as product_tax_type,MAX(b.[product_GST_percentage]) as product_GST_percentage,MAX(b.[product_GST_rate]) as product_GST_rate,MAX(b.[product_CGST_percentage]) as product_CGST_percentage,MAX(b.[product_CGST_rate]) as product_CGST_rate,MAX(b.[product_SGST_percentage]) as product_SGST_percentage,MAX(b.[product_SGST_rate]) as product_SGST_rate,MAX(b.[product_IGST_percentage]) as product_IGST_percentage,MAX(b.[product_IGST_rate]) as product_IGST_rate,MAX(b.[product_market_price]) as product_market_price,MAX(b.[product_sell_price]) as product_sell_price,MAX(b.[product_discount_percentage]) as product_discount_percentage,MAX(b.[product_discount_price]) as product_discount_price,MAX(b.[product_with_gst_Price]) as product_with_gst_Price,MAX(b.[product_final_sell_price]) as product_final_sell_price,MAX(b.[product_shipping_charge]) as product_shipping_charge,MAX(b.[product_stock]) as product_stock,MAX(d.photo_path) as photo_path FROM [ecommerce_product] a inner join [ecommerce_product_price] as b on a.product_id=b.product_id inner join ecommerce_product_photos as d on b.product_id=d.product_id where a.publish_status='Yes' and a.top_deal='True' and b.product_stock > 0 group by a.[product_id],b.[product_final_sell_price] order by b.[product_final_sell_price] ASC";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

	[WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_product_top(string customer_id, string cart_guest_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT top 12 (select case when count(*) > 0 then max(cart_qty) else 0 end from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id=a.product_id) as cart_qty,max(b.[id]) as id,MAX(a.[product_id]) as product_id,MAX(a.[product_full_name]) as product_full_name,MAX(a.[product_description]) as product_description,MAX(a.[product_parent_category_id]) as product_parent_category_id,MAX(a.[product_parent_category_name]) as product_parent_category_name,MAX(a.[product_sub_category_id]) as product_sub_category_id,MAX(a.[product_sub_category_name]) as product_sub_category_name,MAX(a.[product_full_description]) as product_full_description,MAX(a.[publish_status]) as publish_status,MAX(a.[country_of_origin]) as country_of_origin,MAX(a.[verticle_id]) as verticle_id,MAX(a.[verticle_name]) as verticle_name,MAX(b.[product_unit]) as product_unit,MAX(b.[product_unit_value]) as product_unit_value,MAX(b.[product_GST_type]) as product_GST_type,MAX(b.[product_tax_type]) as product_tax_type,MAX(b.[product_GST_percentage]) as product_GST_percentage,MAX(b.[product_GST_rate]) as product_GST_rate,MAX(b.[product_CGST_percentage]) as product_CGST_percentage,MAX(b.[product_CGST_rate]) as product_CGST_rate,MAX(b.[product_SGST_percentage]) as product_SGST_percentage,MAX(b.[product_SGST_rate]) as product_SGST_rate,MAX(b.[product_IGST_percentage]) as product_IGST_percentage,MAX(b.[product_IGST_rate]) as product_IGST_rate,MAX(b.[product_market_price]) as product_market_price,MAX(b.[product_sell_price]) as product_sell_price,MAX(b.[product_discount_percentage]) as product_discount_percentage,MAX(b.[product_discount_price]) as product_discount_price,MAX(b.[product_with_gst_Price]) as product_with_gst_Price,MAX(b.[product_final_sell_price]) as product_final_sell_price,MAX(b.[product_shipping_charge]) as product_shipping_charge,MAX(b.[product_stock]) as product_stock,MAX(d.photo_path) as photo_path FROM [ecommerce_product] a inner join [ecommerce_product_price] as b on a.product_id=b.product_id inner join ecommerce_product_photos as d on b.product_id=d.product_id where a.publish_status='Yes' and b.product_stock > 0 group by a.[product_id],b.[product_final_sell_price] order by b.[product_final_sell_price] ASC";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }
	
	[WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_searchproducts(string customer_id, string cart_guest_id, string pnm)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT (select case when count(*) > 0 then max(cart_qty) else 0 end from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id=a.product_id) as cart_qty,max(b.[id]) as id,MAX(a.[product_id]) as product_id,MAX(a.[product_full_name]) as product_full_name,MAX(a.[product_description]) as product_description,MAX(a.[product_parent_category_id]) as product_parent_category_id,MAX(a.[product_parent_category_name]) as product_parent_category_name,MAX(a.[product_sub_category_id]) as product_sub_category_id,MAX(a.[product_sub_category_name]) as product_sub_category_name,MAX(a.[product_full_description]) as product_full_description,MAX(a.[publish_status]) as publish_status,MAX(a.[country_of_origin]) as country_of_origin,MAX(a.[verticle_id]) as verticle_id,MAX(a.[verticle_name]) as verticle_name,MAX(b.[product_unit]) as product_unit,MAX(b.[product_unit_value]) as product_unit_value,MAX(b.[product_GST_type]) as product_GST_type,MAX(b.[product_tax_type]) as product_tax_type,MAX(b.[product_GST_percentage]) as product_GST_percentage,MAX(b.[product_GST_rate]) as product_GST_rate,MAX(b.[product_CGST_percentage]) as product_CGST_percentage,MAX(b.[product_CGST_rate]) as product_CGST_rate,MAX(b.[product_SGST_percentage]) as product_SGST_percentage,MAX(b.[product_SGST_rate]) as product_SGST_rate,MAX(b.[product_IGST_percentage]) as product_IGST_percentage,MAX(b.[product_IGST_rate]) as product_IGST_rate,MAX(b.[product_market_price]) as product_market_price,MAX(b.[product_sell_price]) as product_sell_price,MAX(b.[product_discount_percentage]) as product_discount_percentage,MAX(b.[product_discount_price]) as product_discount_price,MAX(b.[product_with_gst_Price]) as product_with_gst_Price,MAX(b.[product_final_sell_price]) as product_final_sell_price,MAX(b.[product_shipping_charge]) as product_shipping_charge,MAX(b.[product_stock]) as product_stock,MAX(d.photo_path) as photo_path FROM [ecommerce_product] a inner join [ecommerce_product_price] as b on a.product_id=b.product_id inner join ecommerce_product_photos as d on b.product_id=d.product_id where a.publish_status='Yes' and b.product_stock > 0 and a.product_full_name like N'%" + pnm + "%' group by a.[product_id],b.[product_final_sell_price] order by b.[product_final_sell_price] ASC";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }
	
	[WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_product(string customer_id, string cart_guest_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT (select case when count(*) > 0 then max(cart_qty) else 0 end from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id=a.product_id) as cart_qty,max(b.[id]) as id,MAX(a.[product_id]) as product_id,MAX(a.[product_full_name]) as product_full_name,MAX(a.[product_description]) as product_description,MAX(a.[product_parent_category_id]) as product_parent_category_id,MAX(a.[product_parent_category_name]) as product_parent_category_name,MAX(a.[product_sub_category_id]) as product_sub_category_id,MAX(a.[product_sub_category_name]) as product_sub_category_name,MAX(a.[product_full_description]) as product_full_description,MAX(a.[publish_status]) as publish_status,MAX(a.[country_of_origin]) as country_of_origin,MAX(a.[verticle_id]) as verticle_id,MAX(a.[verticle_name]) as verticle_name,MAX(b.[product_unit]) as product_unit,MAX(b.[product_unit_value]) as product_unit_value,MAX(b.[product_GST_type]) as product_GST_type,MAX(b.[product_tax_type]) as product_tax_type,MAX(b.[product_GST_percentage]) as product_GST_percentage,MAX(b.[product_GST_rate]) as product_GST_rate,MAX(b.[product_CGST_percentage]) as product_CGST_percentage,MAX(b.[product_CGST_rate]) as product_CGST_rate,MAX(b.[product_SGST_percentage]) as product_SGST_percentage,MAX(b.[product_SGST_rate]) as product_SGST_rate,MAX(b.[product_IGST_percentage]) as product_IGST_percentage,MAX(b.[product_IGST_rate]) as product_IGST_rate,MAX(b.[product_market_price]) as product_market_price,MAX(b.[product_sell_price]) as product_sell_price,MAX(b.[product_discount_percentage]) as product_discount_percentage,MAX(b.[product_discount_price]) as product_discount_price,MAX(b.[product_with_gst_Price]) as product_with_gst_Price,MAX(b.[product_final_sell_price]) as product_final_sell_price,MAX(b.[product_shipping_charge]) as product_shipping_charge,MAX(b.[product_stock]) as product_stock,MAX(d.photo_path) as photo_path FROM [ecommerce_product] a inner join [ecommerce_product_price] as b on a.product_id=b.product_id inner join ecommerce_product_photos as d on b.product_id=d.product_id where a.publish_status='Yes' and b.product_stock > 0 group by a.[product_id],b.[product_final_sell_price] order by b.[product_final_sell_price] ASC";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }
	
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_featured(string customer_id, string cart_guest_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT top 10 (select case when count(*) > 0 then max(cart_qty) else 0 end from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id=a.product_id) as cart_qty,max(b.[id]) as id,MAX(a.[product_id]) as product_id,MAX(a.[product_full_name]) as product_full_name,MAX(a.[product_description]) as product_description,MAX(a.[product_parent_category_id]) as product_parent_category_id,MAX(a.[product_parent_category_name]) as product_parent_category_name,MAX(a.[product_sub_category_id]) as product_sub_category_id,MAX(a.[product_sub_category_name]) as product_sub_category_name,MAX(a.[product_full_description]) as product_full_description,MAX(a.[publish_status]) as publish_status,MAX(a.[country_of_origin]) as country_of_origin,MAX(a.[verticle_id]) as verticle_id,MAX(a.[verticle_name]) as verticle_name,MAX(b.[product_unit]) as product_unit,MAX(b.[product_unit_value]) as product_unit_value,MAX(b.[product_GST_type]) as product_GST_type,MAX(b.[product_tax_type]) as product_tax_type,MAX(b.[product_GST_percentage]) as product_GST_percentage,MAX(b.[product_GST_rate]) as product_GST_rate,MAX(b.[product_CGST_percentage]) as product_CGST_percentage,MAX(b.[product_CGST_rate]) as product_CGST_rate,MAX(b.[product_SGST_percentage]) as product_SGST_percentage,MAX(b.[product_SGST_rate]) as product_SGST_rate,MAX(b.[product_IGST_percentage]) as product_IGST_percentage,MAX(b.[product_IGST_rate]) as product_IGST_rate,MAX(b.[product_market_price]) as product_market_price,MAX(b.[product_sell_price]) as product_sell_price,MAX(b.[product_discount_percentage]) as product_discount_percentage,MAX(b.[product_discount_price]) as product_discount_price,MAX(b.[product_with_gst_Price]) as product_with_gst_Price,MAX(b.[product_final_sell_price]) as product_final_sell_price,MAX(b.[product_shipping_charge]) as product_shipping_charge,MAX(b.[product_stock]) as product_stock,MAX(d.photo_path) as photo_path FROM [ecommerce_product] a inner join [ecommerce_product_price] as b on a.product_id=b.product_id inner join ecommerce_product_photos as d on b.product_id=d.product_id where a.publish_status='Yes' and a.featured='True' and b.product_stock > 0 group by a.[product_id],b.[product_final_sell_price] order by b.[product_final_sell_price] ASC";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    public string Encrypted(string clearText)
    {
        try
        {
            string EncryptionKey = "digitalbull@@1234";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }

    }

    public string Decrypted(string cipherText)
    {
        try
        {
            string EncryptionKey = "digitalbull@@1234";
            cipherText = cipherText.Replace(' ', '+');
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {

                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {

                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Decode" + ex.Message);
        }

    }

    [WebMethod]
    public String register_user(string name, string mobile, string password)
    {
        string output = string.Empty;

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO ecommerce_customer(customer_mobileno,customer_name,customer_password,customer_date,customer_time,customer_id,customer_temp_id,customer_status) VALUES (@customer_mobileno, @customer_name, @customer_password,CAST(GETDATE()AS Date),CONVERT(VARCHAR(8),GETDATE(),108),@customer_id,@customer_temp_id,@customer_status)"))
            {
                cmd.Parameters.AddWithValue("@customer_mobileno", mobile);
                cmd.Parameters.AddWithValue("@customer_name", name);
                cmd.Parameters.AddWithValue("@customer_temp_id", gettempuserid());
                cmd.Parameters.AddWithValue("@customer_id", getuserid());
                cmd.Parameters.AddWithValue("@customer_password", Encrypted(password));
                cmd.Parameters.AddWithValue("@customer_status", "Active");
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

                SqlCommand cmdd = new SqlCommand();
                #region SQl select command
                cmdd.CommandText = @"SELECT * FROM  ecommerce_customer where customer_mobileno = '" + mobile + "'";
                #endregion
                cmdd.CommandType = CommandType.Text;
                cmdd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmdd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                output = JsonConvert.SerializeObject(dt);
                con.Close();
            }

        }
        return output;
    }

    [WebMethod]
    public String update_user(string name, string mobile, string gender, string mail, string dob)
    {
        string output = string.Empty;

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("update ecommerce_customer set customer_name=@customer_name,customer_dob=@customer_dob,customer_email=@customer_email,customer_gender=@customer_gender where customer_mobileno='" + mobile + "'"))
            {
                cmd.Parameters.AddWithValue("@customer_name", name);
                cmd.Parameters.AddWithValue("@customer_gender", gender);
                cmd.Parameters.AddWithValue("@customer_email", mail);
                cmd.Parameters.AddWithValue("@customer_dob", dob);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();

                SqlCommand cmdd = new SqlCommand();
                #region SQl select command
                cmdd.CommandText = @"SELECT * FROM  ecommerce_customer where customer_mobileno = '" + mobile + "'";
                #endregion
                cmdd.CommandType = CommandType.Text;
                cmdd.Connection = con;

                SqlDataReader rdr = cmdd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                output = JsonConvert.SerializeObject(dt);
                con.Close();
            }

        }
        return output;
    }

    [WebMethod]
    public void update_picture(string filenm, string b64string, string custid)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            string path = uploadphoto(b64string, filenm);

            using (SqlCommand cmd = new SqlCommand("update ecommerce_customer set customer_profilephoto=@customer_profilephoto where customer_id='" + custid + "'"))
            {
                cmd.Parameters.AddWithValue("@customer_profilephoto", path);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }

        }
    }

    private string uploadphoto(string b64string, string filenm)
    {

        string length = b64string;
        byte[] mydata = Convert.FromBase64String(length);

        string filePath = "/auth/upload/auth/profile-photo/" + filenm;
        WriteToFile(Server.MapPath(filePath), ref mydata);
        return filePath;
    }

    public void WriteToFile(string filepath, ref byte[] Buffer)
    {
        try
        {
            FileStream newFile = new FileStream(filepath, FileMode.OpenOrCreate);
            newFile.Write(Buffer, 0, Buffer.Length);
            newFile.Close();
        }
        catch (Exception ex)
        {
        }
    }

    [WebMethod]
    public void update_password(string custid, string password, string newpass)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("update ecommerce_customer set customer_password=@customer_password where customer_id='" + custid + "' and customer_password='" + Encrypted(password) + "'"))
            {
                cmd.Parameters.AddWithValue("@customer_password", Encrypted(newpass));
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }

        }

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_catwiseproduct(string category_id, string customer_id, string cart_guest_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT (select case when count(*) > 0 then max(cart_qty) else 0 end from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id=a.product_id) as cart_qty,max(b.[id]) as id,MAX(a.[product_id]) as product_id,MAX(a.[product_full_name]) as product_full_name,MAX(a.[product_description]) as product_description,MAX(a.[product_parent_category_id]) as product_parent_category_id,MAX(a.[product_parent_category_name]) as product_parent_category_name,MAX(a.[product_sub_category_id]) as product_sub_category_id,MAX(a.[product_sub_category_name]) as product_sub_category_name,MAX(a.[product_full_description]) as product_full_description,MAX(a.[publish_status]) as publish_status,MAX(a.[country_of_origin]) as country_of_origin,MAX(a.[verticle_id]) as verticle_id,MAX(a.[verticle_name]) as verticle_name,MAX(b.[product_unit]) as product_unit,MAX(b.[product_unit_value]) as product_unit_value,MAX(b.[product_GST_type]) as product_GST_type,MAX(b.[product_tax_type]) as product_tax_type,MAX(b.[product_GST_percentage]) as product_GST_percentage,MAX(b.[product_GST_rate]) as product_GST_rate,MAX(b.[product_CGST_percentage]) as product_CGST_percentage,MAX(b.[product_CGST_rate]) as product_CGST_rate,MAX(b.[product_SGST_percentage]) as product_SGST_percentage,MAX(b.[product_SGST_rate]) as product_SGST_rate,MAX(b.[product_IGST_percentage]) as product_IGST_percentage,MAX(b.[product_IGST_rate]) as product_IGST_rate,MAX(b.[product_market_price]) as product_market_price,MAX(b.[product_sell_price]) as product_sell_price,MAX(b.[product_discount_percentage]) as product_discount_percentage,MAX(b.[product_discount_price]) as product_discount_price,MAX(b.[product_with_gst_Price]) as product_with_gst_Price,MAX(b.[product_final_sell_price]) as product_final_sell_price,MAX(b.[product_shipping_charge]) as product_shipping_charge,MAX(b.[product_stock]) as product_stock,MAX(d.photo_path) as photo_path FROM [ecommerce_product] a inner join [ecommerce_product_price] as b on a.product_id=b.product_id inner join ecommerce_product_photos as d on b.product_id=d.product_id where a.product_parent_category_id='" + category_id + "' and a.publish_status='Yes' and b.product_stock > 0 group by a.[product_id],b.[product_final_sell_price] order by b.[product_final_sell_price] ASC";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    public string getuserid()
    {
        string id = "";
        try
        {


            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT MAX(customer_temp_id) as customer_temp_id FROM ecommerce_customer";
                #endregion
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int i = 1;
                while (rdr.Read())
                {
                    string tempidplus = rdr["customer_temp_id"].ToString();
                    string tempid = Convert.ToString(Convert.ToInt32(tempidplus) + 1);
                    id = DateTime.Now.Year + "0" + DateTime.Now.Month + Convert.ToString(tempid);
                }
            }

        }
        catch (Exception ex)
        {
            string text = "My text that I want to display";

        }
        return id;
    }

    public string gettempuserid()
    {
        string id = "";
        try
        {


            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT MAX(customer_temp_id) as customer_temp_id FROM ecommerce_customer";
                #endregion
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int i = 1;
                while (rdr.Read())
                {
                    string tempidplus = rdr["customer_temp_id"].ToString();
                    string tempid = Convert.ToString(Convert.ToInt32(tempidplus) + 1);
                    id = Convert.ToString(tempid);
                }
            }

        }
        catch (Exception ex)
        {
            string text = "My text that I want to display";

        }
        return id;
    }

    [WebMethod]
    public string otp_generate_mobile(string mob)
    {
        string otp = otp_generate();
        string output = string.Empty;

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT * FROM  ecommerce_customer where customer_mobileno = '" + mob + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                rdr.Close();
                using (SqlCommand cmd2 = new SqlCommand("update ecommerce_customer set otp=@otp,mobileno_verified='YES' where customer_mobileno='" + mob + "'"))
                {
                    cmd2.Parameters.AddWithValue("@otp", otp);
                    cmd2.Connection = con;
                    SqlDataReader reader = cmd2.ExecuteReader();
                    reader.Close();
                }


                SqlCommand cmd3 = new SqlCommand();
                #region SQl select command
                cmd3.CommandText = @"SELECT otp FROM  ecommerce_customer where customer_mobileno = '" + mob + "'";
                #endregion //SessionId
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                SqlDataReader rdr1 = cmd3.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                output = JsonConvert.SerializeObject(dt);
                con.Close();
            }

        }

        return output;
    }

    [WebMethod]
    public string mobile_verified(string mob, string otp)
    {
        string output = string.Empty;

        using (SqlConnection con = new SqlConnection(cs))
        {

            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT * FROM  ecommerce_customer where customer_mobileno = '" + mob + "' and otp='" + otp + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            output = JsonConvert.SerializeObject(dt);
            con.Close();

        }
        return output;
    }

    private string otp_generate()
    {
        Random generator = new Random();
        int r = generator.Next(1, 1000000);
        string s = r.ToString().PadLeft(6, '0');
        return s;
    }

    [WebMethod]
    public void forget_password(string password, string custid)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("update ecommerce_customer set customer_password=@customer_password where customer_id='" + custid + "'"))
            {
                cmd.Parameters.AddWithValue("@customer_password", Encrypted(password));
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }

        }

    }

    //public string getcartno()
    //{
    //    string id = "";
    //    try
    //    {
    //        

    //        using (SqlConnection con = new SqlConnection(cs))
    //        {
    //            SqlCommand cmd = new SqlCommand();
    //            #region SQl select command
    //            cmd.CommandText = @"SELECT MAX(cart_no) as cart_no FROM ecommerce_cart";
    //            #endregion
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Connection = con;
    //            con.Open();
    //            SqlDataReader rdr = cmd.ExecuteReader();
    //            int i = 1;
    //            while (rdr.Read())
    //            {
    //                string tempidplus = rdr["cart_no"].ToString();
    //                string tempid = Convert.ToString(Convert.ToInt32(tempidplus) + 1);
    //                id = Convert.ToString(tempid);
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        string text = "My text that I want to display";

    //    }
    //    return id;
    //}

    [WebMethod]
    public void addtocart(string cart_qty, string customer_id, string cart_guest_id, string product_id, string product_price_id)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            if (customer_id != "")
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ecommerce_cart(product_sellername,cart_no,cart_date,cart_qty,customer_id,cart_guest_id,product_id,product_price_id,store_location) VALUES (@product_sellername,@cart_no,CAST(GETDATE()AS Date),@cart_qty,@customer_id,@cart_guest_id,@product_id,@product_price_id,@store_location)"))
                {
                    cmd.Parameters.AddWithValue("@cart_no", getidno("cart_no", "ecommerce_cart"));
                    cmd.Parameters.AddWithValue("@cart_qty", cart_qty);
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@cart_guest_id", cart_guest_id);
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                    cmd.Parameters.AddWithValue("@product_price_id", product_price_id);
                    cmd.Parameters.AddWithValue("@store_location", "APP");

                    double qty = Convert.ToDouble(cart_qty);
                    double mrp = Convert.ToDouble(get_price(product_price_id));
                    double total = qty * mrp;
                    cmd.Parameters.AddWithValue("@product_sellername", total.ToString());
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ecommerce_cart(product_sellername,cart_no,cart_date,cart_qty,customer_id,cart_guest_id,product_id,product_price_id,store_location) VALUES (@product_sellername,@cart_no,CAST(GETDATE()AS Date),@cart_qty,@customer_id,@cart_guest_id,@product_id,@product_price_id,@store_location)"))
                {
                    cmd.Parameters.AddWithValue("@cart_no", getidno("cart_no", "ecommerce_cart"));
                    cmd.Parameters.AddWithValue("@cart_qty", cart_qty);
                    cmd.Parameters.AddWithValue("@customer_id", "0");
                    cmd.Parameters.AddWithValue("@cart_guest_id", cart_guest_id);
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                    cmd.Parameters.AddWithValue("@product_price_id", product_price_id);
                    cmd.Parameters.AddWithValue("@store_location", "APP");

                    double qty = Convert.ToDouble(cart_qty);
                    double mrp = Convert.ToDouble(get_price(product_price_id));
                    double total = qty * mrp;
                    cmd.Parameters.AddWithValue("@product_sellername", total.ToString());

                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                }
            }
        }
    }

    private double get_price(string product_price_id)
    {
        double a = 0.0;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select product_sell_price from ecommerce_product_price where id='" + product_price_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                a = Convert.ToDouble(rdr["product_sell_price"].ToString());
            }

        }
            return a;
    }

    [WebMethod]
    public void removetocart(string customer_id, string cart_guest_id, string product_id, string product_price_id)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            if (cart_guest_id == "")
            {
                using (SqlCommand cmd = new SqlCommand("delete from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id='" + product_id + "' and product_price_id='" + product_price_id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                }
            }
            else if (cart_guest_id != "")
            {
                using (SqlCommand cmd = new SqlCommand("delete from ecommerce_cart where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id='" + product_id + "' and product_price_id='" + product_price_id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                }
            }

        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_cartproduct(string customer_id, string cart_guest_id)
    {


        if (customer_id != "")
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"select a.*,b.country_of_origin,c.product_shipping_charge,b.product_full_description,b.product_id,b.product_full_name,b.product_description,b.product_parent_category_id,b.product_parent_category_name,b.product_sub_category_id,b.product_sub_category_name,b.publish_status,b.verticle_id,b.verticle_name,ISNULL(c.product_final_sell_price,'0.00') as product_final_sell_price,c.product_unit,c.product_unit_value,c.product_market_price,c.product_GST_type,c.product_tax_type,c.product_GST_percentage,c.product_GST_rate,c.product_CGST_percentage,c.product_CGST_rate,c.product_SGST_percentage,c.product_SGST_rate,c.product_IGST_percentage,c.product_IGST_rate,c.id,c.product_market_price,c.product_sell_price,c.product_discount_percentage,c.product_discount_price,c.product_with_gst_Price,isnull(c.product_stock,'0') as product_stock,d.photo_path as photo_path from ecommerce_cart a left join ecommerce_product as b on a.product_id=b.product_id left join ecommerce_product_price as c on a.product_price_id=c.id left join ecommerce_product_photos as d on b.product_id=d.product_id where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "')";
                #endregion
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJSON = JsonConvert.SerializeObject(dt);

                return strJSON;

            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"select a.*,b.country_of_origin,c.product_shipping_charge,b.product_full_description,b.product_id,b.product_full_name,b.product_description,b.product_parent_category_id,b.product_parent_category_name,b.product_sub_category_id,b.product_sub_category_name,b.publish_status,b.verticle_id,b.verticle_name,ISNULL(c.product_final_sell_price,'0.00') as product_final_sell_price,c.product_unit,c.product_unit_value,c.product_market_price,c.product_GST_type,c.product_tax_type,c.product_GST_percentage,c.product_GST_rate,c.product_CGST_percentage,c.product_CGST_rate,c.product_SGST_percentage,c.product_SGST_rate,c.product_IGST_percentage,c.product_IGST_rate,c.id,c.product_market_price,c.product_sell_price,c.product_discount_percentage,c.product_discount_price,c.product_with_gst_Price,isnull(c.product_stock,'0') as product_stock,d.photo_path as photo_path from ecommerce_cart a left join ecommerce_product as b on a.product_id=b.product_id left join ecommerce_product_price as c on a.product_price_id=c.id left join ecommerce_product_photos as d on b.product_id=d.product_id where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "')";
                #endregion
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJSON = JsonConvert.SerializeObject(dt);

                return strJSON;
            }
        }
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_order_cart_no(string customer_id, string guest_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select (select isnull(count(*),0) from ecommerce_cart where customer_id='" + customer_id + "' or cart_guest_id='" + guest_id + "')as cartotal,(select isnull(count(*),0) from ecommerce_order where customer_id='" + customer_id + "' group by order_id)as ordertotal";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;

        }


    }


    [WebMethod]
    public void addtocart_changeqty(string cart_qty, string customer_id, string cart_guest_id, string product_id, string product_price_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            double qty = Convert.ToDouble(cart_qty);
            double mrp = Convert.ToDouble(get_price(product_price_id));
            double total = qty * mrp;
            
            if (customer_id != "")
            {
                using (SqlCommand cmd = new SqlCommand("update ecommerce_cart set cart_qty='" + cart_qty + "',product_sellername='"+ total.ToString() + "' where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id='" + product_id + "' and product_price_id='" + product_price_id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("update ecommerce_cart set cart_qty='" + cart_qty + "',product_sellername='"+ total.ToString() + "' where (customer_id='" + customer_id + "' or cart_guest_id='" + cart_guest_id + "') and product_id='" + product_id + "' and product_price_id='" + product_price_id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                }
            }
        }
    }

    //public string getwishlistno()
    //{
    //    string id = "";
    //    try
    //    {
    //        

    //        using (SqlConnection con = new SqlConnection(cs))
    //        {
    //            SqlCommand cmd = new SqlCommand();
    //            #region SQl select command
    //            cmd.CommandText = @"SELECT MAX(wishlist_no) as wishlist_no FROM ecommerce_wishlist";
    //            #endregion
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Connection = con;
    //            con.Open();
    //            SqlDataReader rdr = cmd.ExecuteReader();
    //            int i = 1;
    //            while (rdr.Read())
    //            {
    //                string tempidplus = rdr["wishlist_no"].ToString();
    //                string tempid = Convert.ToString(Convert.ToInt32(tempidplus) + 1);
    //                id = Convert.ToString(tempid);
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        string text = "My text that I want to display";

    //    }
    //    return id;
    //}

    [WebMethod]
    public void addtowishlist(string wishlist_qty, string customer_id, string product_id, string product_price_id)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO ecommerce_wishlist(wishlist_no,wishlist_date,wishlist_qty,customer_id,product_id,product_price_id) VALUES (@wishlist_no,CAST(GETDATE()AS Date),'1',@customer_id,@product_id,@product_price_id)"))
            {
                cmd.Parameters.AddWithValue("@wishlist_no", getidno("wishlist_no", "ecommerce_wishlist"));
                cmd.Parameters.AddWithValue("@wishlist_qty", wishlist_qty);
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.Parameters.AddWithValue("@product_id", product_id);
                cmd.Parameters.AddWithValue("@product_price_id", product_price_id);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

            }
        }
    }

    [WebMethod]
    public void removetowishlist(string customer_id, string product_id, string product_price_id)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("delete from ecommerce_cart where customer_id='" + customer_id + "' and product_id='" + product_id + "' and product_price_id='" + product_price_id + "'"))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

            }

        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_wishlistproduct(string customer_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select a.*,b.country_of_origin,c.product_shipping_charge,b.product_full_description,b.product_id,b.product_full_name,b.product_description,b.product_parent_category_id,b.product_parent_category_name,b.product_sub_category_id,b.product_sub_category_name,b.publish_status,b.verticle_id,b.verticle_name,ISNULL(c.product_final_sell_price,'0.00') as product_final_sell_price,c.product_unit,c.product_unit_value,c.product_market_price,c.product_GST_type,c.product_tax_type,c.product_GST_percentage,c.product_GST_rate,c.product_CGST_percentage,c.product_CGST_rate,c.product_SGST_percentage,c.product_SGST_rate,c.product_IGST_percentage,c.product_IGST_rate,c.product_temp_price,c.product_market_price,c.product_sell_price,c.product_discount_percentage,c.product_discount_price,c.product_with_gst_Price,isnull(c.product_stock,'0') as product_stock,d.photo_path from ecommerce_wishlist a left join ecommerce_product as b on a.product_id=b.product_id left join ecommerce_product_price as c on a.product_price_id=c.id left join ecommerce_product_photos as d on b.product_id=d.product_id where customer_id='" + customer_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    public void addreview(string review_star, string customer_id, string product_id, string reviewer_message, string reviwer_name)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO product_rating_review(reviwer_id,review_date,reviwer_name,reviewer_message,review_star,product_id,review_status) VALUES (@reviwer_id,CAST(GETDATE()AS Date),@reviwer_name,@reviewer_message,@review_star,@product_id,'Active')"))
            {
                cmd.Parameters.AddWithValue("@reviwer_id", customer_id);
                cmd.Parameters.AddWithValue("@reviwer_name", reviwer_name);
                cmd.Parameters.AddWithValue("@review_star", review_star);
                cmd.Parameters.AddWithValue("@product_id", product_id);
                cmd.Parameters.AddWithValue("@reviewer_message", reviewer_message);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

            }
        }
    }

    public string getidno(string column, string tablenm)
    {
        string id = "";
        try
        {


            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT MAX(" + column + ") as " + column + " FROM " + tablenm + "";
                #endregion
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int i = 1;
                while (rdr.Read())
                {
                    string tempidplus = rdr["" + column + ""].ToString();
                    if (tempidplus == "")
                    {
                        tempidplus = "0";
                        string tempid = Convert.ToString(Convert.ToInt32(tempidplus) + 1);
                        id = Convert.ToString(tempid);
                    }
                    else
                    {
                        string tempid = Convert.ToString(Convert.ToInt32(tempidplus) + 1);
                        id = Convert.ToString(tempid);
                    }


                }
            }

        }
        catch (Exception ex)
        {
            string text = "My text that I want to display";

        }
        return id;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_rating_review(string product_id)
    {



        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  product_rating_review where product_id='" + product_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_product_unit(string product_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT product_unit,product_unit_value  FROM  ecommerce_product_price where product_id='" + product_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_allorder(string customer_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select (select isnull(sum(total_amount_of_product),0) from ecommerce_order where order_id=a.order_id and order_status!='Cancelled')total,MAX(a.product_shipping_charge) as product_shipping_charge,MAX(a.product_photo) as product_photo,MAX(a.total_amount_of_product) as total_amount_of_product,MAX(a.product_unit_value) as product_unit_value,MAX(a.product_unit) as product_unit,MAX(a.product_qty) as product_qty,MAX(a.product_name) as product_name,MAX(a.product_id) as product_id,MAX(a.billing_landmark) as billing_landmark,MAX(a.billing_pincode) as billing_pincode,MAX(a.billing_state_name) as billing_state_name,MAX(a.billing_city_name) as billing_city_name,MAX(a.billing_address_line2) as billing_address_line2,MAX(a.billing_address_line1) as billing_address_line1,MAX(a.guest_id) as guest_id,MAX(a.customer_email) as customer_email,MAX(a.customer_mobileno) as customer_mobileno,MAX(a.customer_name) as customer_name,MAX(a.order_time) as order_time,MAX(a.order_date) as order_date,MAX(a.sub_order_id) as sub_order_id,MAX(a.sub_order_id_temp) as sub_order_id_temp,MAX(a.order_id_temp) as order_id_temp,MAX(a.order_id) as order_id,MAX(a.total_order_amount) AS total_order_amount,MAX(a.coupan_value) as coupan_value,MAX(a.coupan_code) as coupan_code,MAX(a.payment_mode)as payment_mode,MAX(a.order_delivery_date) as order_delivery_date,MAX(a.order_delivery_time)as order_delivery_time,MAX(a.order_status) as order_status,MAX(a.customer_id) as customer_id from ecommerce_order a where a.customer_id='" + customer_id + "' group by order_id";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_timeslot()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select * from timeslot";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_order_product(string customer_id, string order_id)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select (select sum(total_amount_of_product) from ecommerce_order where customer_id='" + customer_id + "' and order_id='" + order_id + "' and order_status!='Cancelled')total,* from ecommerce_order  where customer_id='" + customer_id + "' and order_id='" + order_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_allorderstatus(string customer_id, string status)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select MAX(order_id) as order_id,MAX(total_order_amount) AS total_order_amount,MAX(coupan_value) as coupan_value,MAX(coupan_code) as coupan_code,MAX(payment_mode)as payment_mode,MAX(order_delivery_date) as order_delivery_date,MAX(order_delivery_time)as order_delivery_time,MAX(order_status) as order_status,MAX(customer_id) as customer_id from ecommerce_order  where customer_id='" + customer_id + "' and order_status='" + status + "' group by order_id";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    public void addaddress(string customer_id, string address_customer_name, string address_customer_mobileno, string address_customer_email, string address_line_1, string address_line_2, string address_city_id, string address_city_name, string address_state_id, string address_state_name, string address_pincode, string address_default)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO ecommerce_customer_address(customer_id,address_customer_name,address_customer_mobileno,address_customer_email,address_line_1,address_line_2,address_city_id,address_city_name,address_state_id,address_state_name,address_pincode,address_default) VALUES (@customer_id,@address_customer_name,@address_customer_mobileno,@address_customer_email,@address_line_1,@address_line_2,@address_city_id,@address_city_name,@address_state_id,@address_state_name,@address_pincode,@address_default)"))
            {
                cmd.Parameters.AddWithValue("@address_customer_name", address_customer_name);
                cmd.Parameters.AddWithValue("@address_customer_mobileno", address_customer_mobileno);
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.Parameters.AddWithValue("@address_customer_email", address_customer_email);
                cmd.Parameters.AddWithValue("@address_line_1", address_line_1);
                cmd.Parameters.AddWithValue("@address_line_2", address_line_2);
                cmd.Parameters.AddWithValue("@address_city_id", address_city_id);
                cmd.Parameters.AddWithValue("@address_city_name", address_city_name);
                cmd.Parameters.AddWithValue("@address_state_id", address_state_id);
                cmd.Parameters.AddWithValue("@address_state_name", address_state_name);
                cmd.Parameters.AddWithValue("@address_pincode", address_pincode);
                cmd.Parameters.AddWithValue("@address_default", address_default);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

            }
            if (address_default == "Yes")
            {
                string id = GetIDDefaultAddress(customer_id);

                using (SqlCommand cmd = new SqlCommand("update ecommerce_customer_address set address_default='No' where customer_id='" + customer_id + "' and id!='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                }
            }
        }
    }

    private string GetIDDefaultAddress(string customer_id)
    {
        string id = String.Empty;


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT id from ecommerce_customer_address where customer_id='" + customer_id + "' and address_default='Yes'";
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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string get_address(string customer_id)
    {
        using (SqlConnection connection = new SqlConnection(cs))
        {
            string Query = "SELECT * from ecommerce_customer_address where customer_id='" + customer_id + "'";
            SqlCommand command = new SqlCommand(Query, connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string get_city(string state_id)
    {
        using (SqlConnection connection = new SqlConnection
        (cs))
        {
            string Query = "SELECT * from ecommerce_city where state_id='" + state_id + "'";
            SqlCommand command = new SqlCommand(Query, connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string get_state()
    {
        using (SqlConnection connection = new SqlConnection
        (cs))
        {
            string Query = "SELECT * from ecommerce_state";
            SqlCommand command = new SqlCommand(Query, connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string get_area()
    //{
    //    using (SqlConnection connection = new SqlConnection
    //    (cs))
    //    {
    //        string Query = "SELECT * from ecommerce_customer_address where customer_id='" + customer_id + "'";
    //        SqlCommand command = new SqlCommand(Query, connection);
    //        command.CommandType = CommandType.Text;
    //        connection.Open();
    //        SqlDataReader reader = command.ExecuteReader();

    //        DataTable dt = new DataTable();
    //        dt.Load(reader);

    //        JavaScriptSerializer js = new JavaScriptSerializer();
    //        string strJSON = JsonConvert.SerializeObject(dt);

    //        return strJSON;
    //    }
    //}

    [WebMethod]
    public void delete_address(string customer_id, string id)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("delete from ecommerce_customer_address where customer_id='" + customer_id + "' and id='" + id + "'"))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

            }

        }
    }

    [WebMethod]
    public void makedefault_address(string customer_id, string id, string status)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("update ecommerce_customer_address set address_default='" + status + "' where customer_id='" + customer_id + "' and id='" + id + "'"))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

            }

            if (status == "Yes")
            {
                using (SqlCommand cmd = new SqlCommand("update ecommerce_customer_address set address_default='No' where customer_id='" + customer_id + "' and id!='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                }
            }
        }
    }

    [WebMethod]
    public void update_address(string id, string customer_id, string address_customer_name, string address_customer_mobileno, string address_customer_email, string address_line_1, string address_line_2, string address_city_id, string address_city_name, string address_state_id, string address_state_name, string address_pincode, string address_default)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("update ecommerce_customer_address set address_default='" + address_default + "',address_customer_name='" + address_customer_name + "',address_customer_mobileno='" + address_customer_mobileno + "',address_line_1='" + address_line_1 + "',address_line_2='" + address_line_2 + "',address_city_id='" + address_city_id + "',address_city_name='" + address_city_name + "',address_state_id='" + address_state_id + "',address_state_name='" + address_state_name + "',address_pincode='" + address_pincode + "',address_default='" + address_default + "' where customer_id='" + customer_id + "' and id='" + id + "'"))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();
            }

            if (address_default == "Yes")
            {
                using (SqlCommand cmd = new SqlCommand("update ecommerce_customer_address set address_default='No' where customer_id='" + customer_id + "' and id!='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                }
            }
        }
    }


    [WebMethod]
    public void addorder(string guest_id, string payment_mode, string items, string address, string total_order_amount,string customer_id)
    {
        string order_id_temp = getorder_id_temp();
        string order_id = "ODR" + order_id_temp;

        var add = JsonConvert.DeserializeObject<List<Address>>(address);
        var product = JsonConvert.DeserializeObject<List<ProductModel>>(items);

        string address_customer_name=string.Empty;string address_customer_mobileno = string.Empty;
        string address_customer_email = string.Empty; string address_line_1 = string.Empty;
        string address_line_2 = string.Empty; string address_city_id = string.Empty; string address_city_name = string.Empty;
        string address_state_id = string.Empty; string address_state_name = string.Empty; string address_pincode = string.Empty;
        string address_landmark = string.Empty; string address_default;

        foreach (Address ad in add)
        {
            if (ad.address_default == "Yes")
            {
                address_customer_name = ad.address_customer_name;
                address_customer_mobileno = ad.address_customer_mobileno;
                address_customer_email = ad.address_customer_email;
                address_line_1 = ad.address_line_1;
                address_line_2 = ad.address_line_2;
                address_city_id = ad.address_city_id;
                address_city_name = ad.address_city_name;
                address_state_id = ad.address_state_id;
                address_state_name = ad.address_state_name;
                address_pincode = ad.address_pincode;
                address_landmark = ad.address_landmark;
            }
        }

        foreach (ProductModel p in product)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                double total_amount_of_product;
                double cartqty = Convert.ToDouble(p.cart_qty);
                double price = Convert.ToDouble(p.product_final_sell_price);
                total_amount_of_product = cartqty * price;

                SqlCommand cmd = new SqlCommand();
                #region SQl select command

                cmd.CommandText = @"insert into ecommerce_order (guest_id,order_id_temp,order_id,cart_no,order_date,order_time,customer_id,customer_name,customer_mobileno,customer_email,billing_address_line1,billing_address_line2,billing_city_id,billing_city_name,billing_state_id,billing_state_name,billing_pincode,billing_landmark,product_id,product_price_id,product_name,product_hsn_sac,product_qty,product_unit,product_unit_value,product_currecny,product_GST_type,product_tax_type,product_GST_percentage,product_GST_rate,product_CGST_percentage,product_CGST_rate,product_SGST_percentage,product_SGST_rate,product_IGST_percentage,product_IGST_rate,product_market_price,product_sell_price,product_discount_percentage,product_discount_price,product_with_gst_Price,product_final_sell_price,total_market_price,product_shipping_charge,total_amount_of_product,total_order_amount,product_photo,payment_mode,order_status,order_section,coupan_value) values (@guest_id,@order_id_temp,@order_id,@cart_no,@order_date,@order_time,@customer_id,@customer_name,@customer_mobileno,@customer_email,@billing_address_line1,@billing_address_line2,@billing_city_id,@billing_city_name,@billing_state_id,@billing_state_name,@billing_pincode,@billing_landmark,@product_id,@product_price_id,@product_name,@product_hsn_sac,@product_qty,@product_unit,@product_unit_value,@product_currecny,@product_GST_type,@product_tax_type,@product_GST_percentage,@product_GST_rate,@product_CGST_percentage,@product_CGST_rate,@product_SGST_percentage,@product_SGST_rate,@product_IGST_percentage,@product_IGST_rate,@product_market_price,@product_sell_price,@product_discount_percentage,@product_discount_price,@product_with_gst_Price,@product_final_sell_price,@total_market_price,@product_shipping_charge,@total_amount_of_product,@total_order_amount,@product_photo,@payment_mode,@order_status,@order_section,@coupan_value)";

                #endregion
                cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@coupan_value", "0.00");
				cmd.Parameters.AddWithValue("@order_section", "Grocery");
                cmd.Parameters.AddWithValue("@guest_id", guest_id);
                cmd.Parameters.AddWithValue("@order_id_temp", order_id_temp);
                cmd.Parameters.AddWithValue("@order_id", order_id);
                cmd.Parameters.AddWithValue("@cart_no", "0");
                cmd.Parameters.AddWithValue("@order_date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@order_time", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.Parameters.AddWithValue("@customer_name", address_customer_name);
                cmd.Parameters.AddWithValue("@customer_mobileno", address_customer_mobileno);
                cmd.Parameters.AddWithValue("@customer_email", address_customer_email);
                cmd.Parameters.AddWithValue("@billing_address_line1", address_line_1);
                cmd.Parameters.AddWithValue("@billing_address_line2", address_line_2);
                cmd.Parameters.AddWithValue("@billing_city_id", "0");
                cmd.Parameters.AddWithValue("@billing_city_name", address_city_name);
                cmd.Parameters.AddWithValue("@billing_state_id", "0");
                cmd.Parameters.AddWithValue("@billing_state_name", address_state_name);
                cmd.Parameters.AddWithValue("@billing_pincode", address_pincode);
                cmd.Parameters.AddWithValue("@billing_landmark", address_city_name);
                cmd.Parameters.AddWithValue("@product_id", p.product_id);
                cmd.Parameters.AddWithValue("@product_price_id", p.product_price_id);
                cmd.Parameters.AddWithValue("@product_name", p.product_full_name);
                cmd.Parameters.AddWithValue("@product_hsn_sac", "0");
                cmd.Parameters.AddWithValue("@product_qty", p.cart_qty);
                cmd.Parameters.AddWithValue("@product_unit", p.product_unit);
                cmd.Parameters.AddWithValue("@product_unit_value", p.product_unit_value);
                cmd.Parameters.AddWithValue("@product_currecny", "0");
                cmd.Parameters.AddWithValue("@product_GST_type", p.product_GST_type);
                cmd.Parameters.AddWithValue("@product_tax_type", p.product_tax_type);
                cmd.Parameters.AddWithValue("@product_GST_percentage", p.product_GST_percentage);
                cmd.Parameters.AddWithValue("@product_GST_rate", p.product_GST_rate);
                cmd.Parameters.AddWithValue("@product_CGST_percentage", p.product_CGST_percentage);
                cmd.Parameters.AddWithValue("@product_CGST_rate", p.product_CGST_rate);
                cmd.Parameters.AddWithValue("@product_SGST_percentage", p.product_SGST_percentage);
                cmd.Parameters.AddWithValue("@product_SGST_rate", p.product_SGST_rate);

                if (p.product_IGST_percentage == null)
                {
                    cmd.Parameters.AddWithValue("@product_IGST_percentage", "0.00");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@product_IGST_percentage", p.product_IGST_percentage);
                }

                if (p.product_IGST_rate == null)
                {
                    cmd.Parameters.AddWithValue("@product_IGST_rate", "0.00");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@product_IGST_rate", p.product_IGST_rate);
                }

                
                cmd.Parameters.AddWithValue("@product_market_price", p.product_market_price);
                cmd.Parameters.AddWithValue("@product_sell_price", p.product_sell_price);
                cmd.Parameters.AddWithValue("@product_discount_percentage", p.product_discount_percentage);
                cmd.Parameters.AddWithValue("@product_discount_price", p.product_discount_price);
                cmd.Parameters.AddWithValue("@product_with_gst_Price", p.product_with_gst_Price);
                cmd.Parameters.AddWithValue("@product_final_sell_price", p.product_final_sell_price);
                cmd.Parameters.AddWithValue("@total_market_price", p.product_market_price);
                cmd.Parameters.AddWithValue("@product_shipping_charge", p.product_shipping_charge);
                cmd.Parameters.AddWithValue("@total_amount_of_product", total_amount_of_product.ToString());
                cmd.Parameters.AddWithValue("@total_order_amount", total_order_amount);
                cmd.Parameters.AddWithValue("@product_photo", p.photo_path);
                cmd.Parameters.AddWithValue("@payment_mode", payment_mode);
                cmd.Parameters.AddWithValue("@order_status", "Processing");
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                con.Close();

            }

            removetocart(customer_id, guest_id,p.product_id, p.product_price_id);

        }
    }

    private string getorder_id_temp()
    {
        string order_id_temp = string.Empty;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command

            cmd.CommandText = @"select isnull(max(order_id_temp),0)order_id_temp from ecommerce_order";

            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                order_id_temp = rdr["order_id_temp"].ToString();
                int a = Convert.ToInt32(order_id_temp);
                a = a + 1;
                order_id_temp = a.ToString();
            }
            rdr.Close();
            con.Close();

            return order_id_temp;
        }
    }


    [WebMethod]
    public void Cancel_order_Product(string order_return_comment, string customer_id, string order_return_reason, string product_id, string order_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("update ecommerce_order set order_status='Cancelled',order_return_reason='"+ order_return_reason + "',order_return_comment='" + order_return_comment + "' where customer_id='" + customer_id + "' and product_id='" + product_id + "' and order_id='" + order_id + "'"))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();
            }
        }
    }

    [WebMethod]
    public void Cancel_Allorder(string order_return_comment, string customer_id, string order_return_reason,string order_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("update ecommerce_order set order_status='Cancelled',order_return_reason='" + order_return_reason + "',order_return_comment='" + order_return_comment + "' where customer_id='" + customer_id + "' and order_id='" + order_id + "'"))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();
            }
        }
    }


    //------------------------------- Delivery boy ---------------------------//

    [WebMethod]
    public String login_deliveryboy(string PASSWORD, string mobileno)
    {

        string output = string.Empty;
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT * FROM  ecommerce_delivery_boy where delivery_boy_mobileno = '" + mobileno + "' and delivery_boy_password = '" + Encrypted(PASSWORD) + "' and delivery_boy_status='Active'";
                #endregion 
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                output = JsonConvert.SerializeObject(dt);
                con.Close();
            }

        }
        catch (Exception ex)
        {
            string text = "My text that I want to display";

        }
        return output;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_order_list(string delivery_boy_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select MAX(product_shipping_charge) as product_shipping_charge,MAX(product_photo) as product_photo,MAX(total_amount_of_product) as total_amount_of_product,MAX(product_unit_value) as product_unit_value,MAX(product_unit) as product_unit,MAX(product_qty) as product_qty,MAX(product_name) as product_name,MAX(product_id) as product_id,MAX(billing_landmark) as billing_landmark,MAX(billing_pincode) as billing_pincode,MAX(billing_state_name) as billing_state_name,MAX(billing_city_name) as billing_city_name,MAX(billing_address_line2) as billing_address_line2,MAX(billing_address_line1) as billing_address_line1,MAX(guest_id) as guest_id,MAX(customer_email) as customer_email,MAX(customer_mobileno) as customer_mobileno,MAX(customer_name) as customer_name,MAX(order_time) as order_time,MAX(order_date) as order_date,MAX(sub_order_id) as sub_order_id,MAX(sub_order_id_temp) as sub_order_id_temp,MAX(order_id_temp) as order_id_temp,MAX(order_id) as order_id,MAX(total_order_amount) AS total_order_amount,MAX(coupan_value) as coupan_value,MAX(coupan_code) as coupan_code,MAX(payment_mode)as payment_mode,MAX(order_delivery_date) as order_delivery_date,MAX(order_delivery_time)as order_delivery_time,MAX(order_status) as order_status,MAX(customer_id) as customer_id from ecommerce_order  where delivery_boy_id='" + delivery_boy_id + "' and order_status!='Delivered' and order_status!='Cancelled' group by order_id";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_order_rpt(string delivery_boy_id,string dtt)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            if (dtt == "All") 
            {
                cmd.CommandText = @"select MAX(product_shipping_charge) as product_shipping_charge,MAX(product_photo) as product_photo,MAX(total_amount_of_product) as total_amount_of_product,MAX(product_unit_value) as product_unit_value,MAX(product_unit) as product_unit,MAX(product_qty) as product_qty,MAX(product_name) as product_name,MAX(product_id) as product_id,MAX(billing_landmark) as billing_landmark,MAX(billing_pincode) as billing_pincode,MAX(billing_state_name) as billing_state_name,MAX(billing_city_name) as billing_city_name,MAX(billing_address_line2) as billing_address_line2,MAX(billing_address_line1) as billing_address_line1,MAX(guest_id) as guest_id,MAX(customer_email) as customer_email,MAX(customer_mobileno) as customer_mobileno,MAX(customer_name) as customer_name,MAX(order_time) as order_time,MAX(order_date) as order_date,MAX(sub_order_id) as sub_order_id,MAX(sub_order_id_temp) as sub_order_id_temp,MAX(order_id_temp) as order_id_temp,MAX(order_id) as order_id,MAX(total_order_amount) AS total_order_amount,MAX(coupan_value) as coupan_value,MAX(coupan_code) as coupan_code,MAX(payment_mode)as payment_mode,MAX(order_delivery_date) as order_delivery_date,MAX(order_delivery_time)as order_delivery_time,MAX(order_status) as order_status,MAX(customer_id) as customer_id from ecommerce_order  where delivery_boy_id='" + delivery_boy_id + "' and order_status='Delivered' group by order_id";
            }
            else if (dtt == "Today")
            {
                cmd.CommandText = @"select MAX(product_shipping_charge) as product_shipping_charge,MAX(product_photo) as product_photo,MAX(total_amount_of_product) as total_amount_of_product,MAX(product_unit_value) as product_unit_value,MAX(product_unit) as product_unit,MAX(product_qty) as product_qty,MAX(product_name) as product_name,MAX(product_id) as product_id,MAX(billing_landmark) as billing_landmark,MAX(billing_pincode) as billing_pincode,MAX(billing_state_name) as billing_state_name,MAX(billing_city_name) as billing_city_name,MAX(billing_address_line2) as billing_address_line2,MAX(billing_address_line1) as billing_address_line1,MAX(guest_id) as guest_id,MAX(customer_email) as customer_email,MAX(customer_mobileno) as customer_mobileno,MAX(customer_name) as customer_name,MAX(order_time) as order_time,MAX(order_date) as order_date,MAX(sub_order_id) as sub_order_id,MAX(sub_order_id_temp) as sub_order_id_temp,MAX(order_id_temp) as order_id_temp,MAX(order_id) as order_id,MAX(total_order_amount) AS total_order_amount,MAX(coupan_value) as coupan_value,MAX(coupan_code) as coupan_code,MAX(payment_mode)as payment_mode,MAX(order_delivery_date) as order_delivery_date,MAX(order_delivery_time)as order_delivery_time,MAX(order_status) as order_status,MAX(customer_id) as customer_id from ecommerce_order  where delivery_boy_id='" + delivery_boy_id + "' and order_delivery_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and order_status='Delivered' group by order_id";
            }
            else if (dtt == "Weekly")
            {
                cmd.CommandText = @"select MAX(product_shipping_charge) as product_shipping_charge,MAX(product_photo) as product_photo,MAX(total_amount_of_product) as total_amount_of_product,MAX(product_unit_value) as product_unit_value,MAX(product_unit) as product_unit,MAX(product_qty) as product_qty,MAX(product_name) as product_name,MAX(product_id) as product_id,MAX(billing_landmark) as billing_landmark,MAX(billing_pincode) as billing_pincode,MAX(billing_state_name) as billing_state_name,MAX(billing_city_name) as billing_city_name,MAX(billing_address_line2) as billing_address_line2,MAX(billing_address_line1) as billing_address_line1,MAX(guest_id) as guest_id,MAX(customer_email) as customer_email,MAX(customer_mobileno) as customer_mobileno,MAX(customer_name) as customer_name,MAX(order_time) as order_time,MAX(order_date) as order_date,MAX(sub_order_id) as sub_order_id,MAX(sub_order_id_temp) as sub_order_id_temp,MAX(order_id_temp) as order_id_temp,MAX(order_id) as order_id,MAX(total_order_amount) AS total_order_amount,MAX(coupan_value) as coupan_value,MAX(coupan_code) as coupan_code,MAX(payment_mode)as payment_mode,MAX(order_delivery_date) as order_delivery_date,MAX(order_delivery_time)as order_delivery_time,MAX(order_status) as order_status,MAX(customer_id) as customer_id from ecommerce_order  where delivery_boy_id='" + delivery_boy_id + "' and order_delivery_date BETWEEN GETDATE()-7 AND GETDATE() and order_status='Delivered' group by order_id";
            }
            else 
            {
                cmd.CommandText = @"select MAX(product_shipping_charge) as product_shipping_charge,MAX(product_photo) as product_photo,MAX(total_amount_of_product) as total_amount_of_product,MAX(product_unit_value) as product_unit_value,MAX(product_unit) as product_unit,MAX(product_qty) as product_qty,MAX(product_name) as product_name,MAX(product_id) as product_id,MAX(billing_landmark) as billing_landmark,MAX(billing_pincode) as billing_pincode,MAX(billing_state_name) as billing_state_name,MAX(billing_city_name) as billing_city_name,MAX(billing_address_line2) as billing_address_line2,MAX(billing_address_line1) as billing_address_line1,MAX(guest_id) as guest_id,MAX(customer_email) as customer_email,MAX(customer_mobileno) as customer_mobileno,MAX(customer_name) as customer_name,MAX(order_time) as order_time,MAX(order_date) as order_date,MAX(sub_order_id) as sub_order_id,MAX(sub_order_id_temp) as sub_order_id_temp,MAX(order_id_temp) as order_id_temp,MAX(order_id) as order_id,MAX(total_order_amount) AS total_order_amount,MAX(coupan_value) as coupan_value,MAX(coupan_code) as coupan_code,MAX(payment_mode)as payment_mode,MAX(order_delivery_date) as order_delivery_date,MAX(order_delivery_time)as order_delivery_time,MAX(order_status) as order_status,MAX(customer_id) as customer_id from ecommerce_order  where delivery_boy_id='" + delivery_boy_id + "' and order_delivery_date='" + dtt + "' and order_status='Delivered' group by order_id";
            }
            
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    public void change_order_status(string order_status, string shipping_address_line1, string shipping_address_line2, string shipping_city_id, string shipping_city_name,string shipping_state_id,string shipping_state_name,string shipping_pincode, string order_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {

            if(order_status== "Delivered")
            {
                using (SqlCommand cmd = new SqlCommand("update ecommerce_order set order_status='Delivered',shipping_address_line1='" + shipping_address_line1 + "',shipping_address_line2='" + shipping_address_line2 + "',shipping_city_id='" + shipping_city_id + "',shipping_city_name='" + shipping_city_name + "',shipping_state_id='" + shipping_state_id + "',shipping_state_name='" + shipping_state_name + "',shipping_pincode='" + shipping_pincode + "',order_delivery_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "',order_delivery_time='" + DateTime.Now.ToString("HH:MM:ss") + "' where order_id='" + order_id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                    Order oder = new Order();
                    oder.Update_Stock2(order_id);
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("update ecommerce_order set order_status='Cancelled',shipping_address_line1='" + shipping_address_line1 + "',shipping_address_line2='" + shipping_address_line2 + "',shipping_city_id='" + shipping_city_id + "',shipping_city_name='" + shipping_city_name + "',shipping_state_id='" + shipping_state_id + "',shipping_state_name='" + shipping_state_name + "',shipping_pincode='" + shipping_pincode + "',order_cancel_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "',order_cancel_time='" + DateTime.Now.ToString("HH:MM:ss") + "' where order_id='" + order_id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                }
            }
            
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_privacy()
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  ecommerce_privacy";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_term()
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  ecommerce_terms_condition";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_return()
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  ecommerce_return_privacy";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }
}
