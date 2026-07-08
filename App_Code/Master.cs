using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Web.UI.WebControls;

public class Master
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    Encrypt enc = new Encrypt();
    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public Master()
    {

    }

    public int Insert_Enquiry(string name, string mobileno, string email, string message, string date, string create_time)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_enquiry(enquiry_name,enquiry_email,enquiry_contact,enquiry_message,enquiry_create_date,enquiry_status) values (@enquiry_name,@enquiry_email,@enquiry_contact,@enquiry_message,@enquiry_create_date,@enquiry_status) ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@enquiry_name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@enquiry_email", email);
            cmd.Parameters.AddWithValue("@enquiry_contact", mobileno);
            cmd.Parameters.AddWithValue("@enquiry_message", SqlDbType.NVarChar).Value = message;
            cmd.Parameters.AddWithValue("@enquiry_create_date", date);
            cmd.Parameters.AddWithValue("@enquiry_status", create_time);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public void PopulateCheckbox(CheckBoxList chk, string value_field, string text_field, string query)
    {
        DataSet ds = new DataSet();
        string cmdstr = query;
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);
        chk.DataSource = ds;
        chk.DataTextField = text_field;
        chk.DataValueField = value_field;
        chk.DataBind();
        con.Close();
    }

    public String Get_Shipping_charge()
    {

        String shipping = "";
        try
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT shipping_charge from ecommerce_shipping ";
            cmd.CommandType = CommandType.Text;

            shipping = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (shipping);
    }

    public SqlDataReader Get_Coupon_Info(String coupan_code)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from ecommerce_coupan where coupan_code=@coupan_code";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@coupan_code", coupan_code);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    public DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    cmd.Dispose();
                }
            }
            con.Close();
            return dt;


        }
    }

    public SqlDataReader Delete_Operation(string query)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    public int Count_data(string query)
    {
        con.Close();
        con.Open();
        int data = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            data = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (data);
    }

    public SqlDataReader Select_Operation(string query)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    public void BindDropDown(DropDownList dbl_list, string valueField, string textField, string query)
    {
        dbl_list.Items.Clear();
        dbl_list.Items.Add(new ListItem("Please Select", ""));
        dbl_list.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = query;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_list.DataSource = cmd.ExecuteReader();
            dbl_list.DataTextField = textField;
            dbl_list.DataValueField = valueField;
            dbl_list.DataBind();
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

    public void PopulateGridview(string query, GridView grd_list)
    {
        DataTable dtbl = new DataTable();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.Connection = con;
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        //  cmd.Parameters.AddWithValue("@search", txt_search.Text.Trim());
        sqlDa.Fill(dtbl);
        if (dtbl.Rows.Count > 0)
        {
            grd_list.DataSource = dtbl;
            grd_list.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            grd_list.DataSource = dtbl;
            grd_list.DataBind();

            grd_list.Rows[0].Cells.Clear();
            grd_list.Rows[0].Cells.Add(new TableCell());
            grd_list.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            grd_list.Rows[0].Cells[0].Text = "No Data Found ..!";
            grd_list.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

        con.Close();

    }

    public void Bind_Checkbox(CheckBoxList chklist, string valueField, string textField, string query)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(query, con);
        adp.Fill(ds);
        chklist.DataSource = ds;
        chklist.DataTextField = textField;
        chklist.DataValueField = valueField;
        chklist.DataBind();
        con.Close();
    }

    public int Insert_Enquiry(string name, string mobileno, string email, string message, string date)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_enquiry(enquiry_name,enquiry_email,enquiry_contact,enquiry_message,enquiry_create_date) values (@enquiry_name,@enquiry_email,@enquiry_contact,@enquiry_message,@enquiry_create_date) ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@enquiry_name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@enquiry_email", email);
            cmd.Parameters.AddWithValue("@enquiry_contact", mobileno);
            cmd.Parameters.AddWithValue("@enquiry_message", SqlDbType.NVarChar).Value = message;
            cmd.Parameters.AddWithValue("@enquiry_create_date", date);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Wallet_Credit_Debit(string customer_id, string transaction_id, string transaction_amount, string transaction_date, string transaction_time, string transaction_type, string transaction_payment_mode, string transaction_status, string transaction_by)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into customer_wallet_transaction(customer_id,transaction_id,transaction_amount,transaction_date,transaction_time,transaction_type,transaction_payment_mode,transaction_status,transaction_by) values (@customer_id,@transaction_id,@transaction_amount,@transaction_date,@transaction_time,@transaction_type,@transaction_payment_mode,@transaction_status,@transaction_by)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@transaction_id", SqlDbType.NVarChar).Value = transaction_id;
            cmd.Parameters.AddWithValue("@transaction_amount", SqlDbType.NVarChar).Value = transaction_amount;
            cmd.Parameters.AddWithValue("@transaction_date", SqlDbType.NVarChar).Value = transaction_date;
            cmd.Parameters.AddWithValue("@transaction_time", SqlDbType.NVarChar).Value = transaction_time;
            cmd.Parameters.AddWithValue("@transaction_type", SqlDbType.NVarChar).Value = transaction_type;
            cmd.Parameters.AddWithValue("@transaction_payment_mode", SqlDbType.NVarChar).Value = transaction_payment_mode;
            cmd.Parameters.AddWithValue("@transaction_status", SqlDbType.NVarChar).Value = transaction_status;
            cmd.Parameters.AddWithValue("@transaction_by", SqlDbType.NVarChar).Value = transaction_by;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Referal_Point(string customer_id, string transaction_id, string transaction_amount, string transaction_date, string transaction_time, string transaction_type, string transaction_payment_mode, string transaction_status, string transaction_by, string delivery_date)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into customer_wallet_transaction(customer_id,transaction_id,transaction_amount,transaction_date,transaction_time,transaction_type,transaction_payment_mode,transaction_status,transaction_by,delivery_date) values (@customer_id,@transaction_id,@transaction_amount,@transaction_date,@transaction_time,@transaction_type,@transaction_payment_mode,@transaction_status,@transaction_by,@delivery_date)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@transaction_id", SqlDbType.NVarChar).Value = transaction_id;
            cmd.Parameters.AddWithValue("@transaction_amount", SqlDbType.NVarChar).Value = transaction_amount;
            cmd.Parameters.AddWithValue("@transaction_date", SqlDbType.NVarChar).Value = transaction_date;
            cmd.Parameters.AddWithValue("@transaction_time", SqlDbType.NVarChar).Value = transaction_time;
            cmd.Parameters.AddWithValue("@transaction_type", SqlDbType.NVarChar).Value = transaction_type;
            cmd.Parameters.AddWithValue("@transaction_payment_mode", SqlDbType.NVarChar).Value = transaction_payment_mode;
            cmd.Parameters.AddWithValue("@transaction_status", SqlDbType.NVarChar).Value = transaction_status;
            cmd.Parameters.AddWithValue("@transaction_by", SqlDbType.NVarChar).Value = transaction_by;
            cmd.Parameters.AddWithValue("@delivery_date", SqlDbType.NVarChar).Value = delivery_date;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public SqlDataReader GetTotalAmount(string order_date)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            // cmd.CommandText = "SELECT sum(a.total_amount_of_product) as total_order_amount FROM ecommerce_order a where a.order_section='Restaurant' AND a.order_date = '" + order_date + "' and a.order_status!='Cancelled' group by a.order_id";
            cmd.CommandText = "SELECT (sum(a.total_amount_of_product)-sum(a.product_discount_price)) as total_order_amount,sum(b.original_price) as original_price FROM ecommerce_order a left join ecommerce_product_price as b on b.id=a.product_price_id where a.order_section='Restaurant' AND a.order_date = '" + order_date + "' and a.order_status!='Cancelled'";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    public int Add_Enquiry(string enquiry_name, string enquiry_contact, string enquiry_email, string enquiry_message, string enquiry_create_date, string enquiry_status)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_enquiry(enquiry_name,enquiry_contact,enquiry_email,enquiry_message,enquiry_create_date,enquiry_status) values (@enquiry_name,@enquiry_contact,@enquiry_email,@enquiry_message,@enquiry_create_date,@enquiry_status)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@enquiry_name", SqlDbType.NVarChar).Value = enquiry_name;
            cmd.Parameters.AddWithValue("@enquiry_contact", SqlDbType.NVarChar).Value = enquiry_contact;
            cmd.Parameters.AddWithValue("@enquiry_email", SqlDbType.NVarChar).Value = enquiry_email;
            cmd.Parameters.AddWithValue("@enquiry_message", SqlDbType.NVarChar).Value = enquiry_message;
            cmd.Parameters.AddWithValue("@enquiry_create_date", SqlDbType.NVarChar).Value = enquiry_create_date;
            cmd.Parameters.AddWithValue("@enquiry_status", SqlDbType.NVarChar).Value = enquiry_status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Address(string customer_id, string address_customer_name, string address_customer_email, string address_customer_mobileno, string address_line_1, string address_line_2, string address_state_name, string address_city_name, string address_pincode)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_customer_address(customer_id,address_customer_name, address_customer_email, address_customer_mobileno, address_line_1, address_line_2, address_state_name, address_city_name,address_pincode) values (@customer_id,@address_customer_name, @address_customer_email, @address_customer_mobileno, @address_line_1, @address_line_2, @address_state_name, @address_city_name,@address_pincode)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@address_customer_name", SqlDbType.NVarChar).Value = address_customer_name;
            cmd.Parameters.AddWithValue("@address_customer_email", SqlDbType.NVarChar).Value = address_customer_email;
            cmd.Parameters.AddWithValue("@address_customer_mobileno", SqlDbType.NVarChar).Value = address_customer_mobileno;
            cmd.Parameters.AddWithValue("@address_line_1", SqlDbType.NVarChar).Value = address_line_1;
            cmd.Parameters.AddWithValue("@address_line_2", SqlDbType.NVarChar).Value = address_line_2;
            cmd.Parameters.AddWithValue("@address_state_name", SqlDbType.NVarChar).Value = address_state_name;
            cmd.Parameters.AddWithValue("@address_city_name", SqlDbType.NVarChar).Value = address_city_name;
            cmd.Parameters.AddWithValue("@address_pincode", SqlDbType.NVarChar).Value = address_pincode;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Profile(string customer_id, string customer_name, string customer_email, string customer_mobileno)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ecommerce_customer set customer_name=@customer_name, customer_email=@customer_email, customer_mobileno=@customer_mobileno where customer_id=@customer_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@customer_name", SqlDbType.NVarChar).Value = customer_name;
            cmd.Parameters.AddWithValue("@customer_email", SqlDbType.NVarChar).Value = customer_email;
            cmd.Parameters.AddWithValue("@customer_mobileno", SqlDbType.NVarChar).Value = customer_mobileno;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Update_Password(string customer_id, string customer_password, string new_password, string confirm_new_password)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "select * from ecommerce_customer where customer_password=@customer_password and customer_id=@customer_id";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd1.Parameters.AddWithValue("@customer_password", SqlDbType.NVarChar).Value = enc.Encrypted(customer_password);

            SqlDataReader sdr = cmd1.ExecuteReader();
            if (sdr.Read())
            {
                sdr.Close();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update ecommerce_customer set customer_password=@customer_password where customer_id=@customer_id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
                cmd.Parameters.AddWithValue("@customer_password", SqlDbType.NVarChar).Value = customer_password;

                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {

            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Delete_Account(string customer_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "delete from ecommerce_customer where customer_id=@customer_id";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;

            RowsAffected = cmd1.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Order(string customer_id, string customer_name, string customer_email, string customer_mobileno, string billing_address_line1, string billing_address_line2, string billing_state_name, string billing_city_name, string billing_pincode, string product_id, string product_price_id, string total_order_amount, string order_id, string order_id_temp)
    {
        
        int RowsAffected = 0;

        con.Close();
        con.Open();
        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = con;
        cmd1.CommandText = "select d.*,a.*,b.*,c.*,(CAST(d.cart_qty as float) * CAST(b.product_sell_price as float)) as total from ecommerce_cart d left join ecommerce_product as a on d.product_id=a.product_id left join ecommerce_product_price as b on d.product_id=b.product_id left join ecommerce_product_photos as c on d.product_id=c.product_id where d.product_id='" + product_id + "' and d.product_price_id='" + product_price_id + "'";
        cmd1.CommandType = CommandType.Text;
        SqlDataReader reader1 = cmd1.ExecuteReader();
        if (reader1.Read())
        {
            

            double total_amount_of_product;
            double cartqty = Convert.ToDouble(reader1["cart_qty"].ToString());
            double price = Convert.ToDouble(reader1["product_sell_price"].ToString());
            total_amount_of_product = cartqty * price;

            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = @"insert into ecommerce_order(guest_id,order_id_temp,order_id,cart_no,order_date,order_time,customer_id,customer_name,customer_mobileno,customer_email,billing_address_line1,billing_address_line2,billing_city_id,billing_city_name,billing_state_id,billing_state_name,billing_pincode,billing_landmark,product_id,product_price_id,product_name,product_hsn_sac,product_qty,product_unit,product_unit_value,product_currecny,product_GST_type,product_tax_type,product_GST_percentage,product_GST_rate,product_CGST_percentage,product_CGST_rate,product_SGST_percentage,product_SGST_rate,product_IGST_percentage,product_IGST_rate,product_market_price,product_sell_price,product_discount_percentage,product_discount_price,product_with_gst_Price,product_final_sell_price,total_market_price,product_shipping_charge,total_amount_of_product,total_order_amount,product_photo,payment_mode,order_status,order_section,coupan_value) values (@guest_id,@order_id_temp,@order_id,@cart_no,@order_date,@order_time,@customer_id,@customer_name,@customer_mobileno,@customer_email,@billing_address_line1,@billing_address_line2,@billing_city_id,@billing_city_name,@billing_state_id,@billing_state_name,@billing_pincode,@billing_landmark,@product_id,@product_price_id,@product_name,@product_hsn_sac,@product_qty,@product_unit,@product_unit_value,@product_currecny,@product_GST_type,@product_tax_type,@product_GST_percentage,@product_GST_rate,@product_CGST_percentage,@product_CGST_rate,@product_SGST_percentage,@product_SGST_rate,@product_IGST_percentage,@product_IGST_rate,@product_market_price,@product_sell_price,@product_discount_percentage,@product_discount_price,@product_with_gst_Price,@product_final_sell_price,@total_market_price,@product_shipping_charge,@total_amount_of_product,@total_order_amount,@product_photo,@payment_mode,@order_status,@order_section,@coupan_value)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@coupan_value", 0.0);
            cmd.Parameters.AddWithValue("@order_section", "Grocery");
            cmd.Parameters.AddWithValue("@guest_id", " ");
            cmd.Parameters.AddWithValue("@order_id_temp", Convert.ToInt32(order_id_temp));
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@cart_no", "0");
            cmd.Parameters.AddWithValue("@order_date", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@order_time", DateTime.Now.ToString("HH:mm:ss"));
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@customer_name", customer_name);
            cmd.Parameters.AddWithValue("@customer_mobileno", customer_mobileno);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);
            cmd.Parameters.AddWithValue("@billing_address_line1", billing_address_line1);
            cmd.Parameters.AddWithValue("@billing_address_line2", billing_address_line2);
            cmd.Parameters.AddWithValue("@billing_city_id", "0");
            cmd.Parameters.AddWithValue("@billing_city_name", billing_city_name);
            cmd.Parameters.AddWithValue("@billing_state_id", "0");
            cmd.Parameters.AddWithValue("@billing_state_name", billing_state_name);
            cmd.Parameters.AddWithValue("@billing_pincode", billing_pincode);
            cmd.Parameters.AddWithValue("@billing_landmark", billing_city_name);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@product_price_id", product_price_id);
            cmd.Parameters.AddWithValue("@product_name", reader1["product_full_name"].ToString());
            cmd.Parameters.AddWithValue("@product_hsn_sac", "0");
            cmd.Parameters.AddWithValue("@product_qty", Convert.ToInt32(cartqty));
            cmd.Parameters.AddWithValue("@product_unit", reader1["product_unit"].ToString());
            cmd.Parameters.AddWithValue("@product_unit_value", reader1["product_unit_value"].ToString());
            cmd.Parameters.AddWithValue("@product_currecny", "0");
            cmd.Parameters.AddWithValue("@product_GST_type", reader1["product_GST_type"].ToString());
            cmd.Parameters.AddWithValue("@product_tax_type", reader1["product_tax_type"].ToString());
            cmd.Parameters.AddWithValue("@product_GST_percentage", Convert.ToDouble(reader1["product_GST_percentage"].ToString()));
            cmd.Parameters.AddWithValue("@product_GST_rate", Convert.ToDouble(reader1["product_GST_rate"].ToString()));
            cmd.Parameters.AddWithValue("@product_CGST_percentage", Convert.ToDouble(reader1["product_CGST_percentage"].ToString()));
            cmd.Parameters.AddWithValue("@product_CGST_rate", Convert.ToDouble(reader1["product_CGST_rate"].ToString()));
            cmd.Parameters.AddWithValue("@product_SGST_percentage", Convert.ToDouble(reader1["product_SGST_percentage"].ToString()));
            cmd.Parameters.AddWithValue("@product_SGST_rate", Convert.ToDouble(reader1["product_SGST_rate"].ToString()));
            string igst = reader1["product_IGST_percentage"].ToString();
            if (reader1["product_IGST_percentage"].ToString() == "")
            {
                cmd.Parameters.AddWithValue("@product_IGST_percentage", 0.0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@product_IGST_percentage", Convert.ToDouble(reader1["product_IGST_percentage"].ToString()));
            }

            if (reader1["product_IGST_rate"].ToString() == "")
            {
                cmd.Parameters.AddWithValue("@product_IGST_rate", 0.00);
            }
            else
            {
                cmd.Parameters.AddWithValue("@product_IGST_rate", Convert.ToDouble(reader1["product_IGST_rate"].ToString()));
            }

            cmd.Parameters.AddWithValue("@product_market_price", Convert.ToDouble(reader1["product_market_price"].ToString()));
            cmd.Parameters.AddWithValue("@product_sell_price", Convert.ToDouble(reader1["product_sell_price"].ToString()));
            cmd.Parameters.AddWithValue("@product_discount_percentage", Convert.ToDouble(reader1["product_discount_percentage"].ToString()));
            cmd.Parameters.AddWithValue("@product_discount_price", Convert.ToDouble(reader1["product_discount_price"].ToString()));
            cmd.Parameters.AddWithValue("@product_with_gst_Price", Convert.ToDouble(reader1["product_with_gst_Price"].ToString()));
            cmd.Parameters.AddWithValue("@product_final_sell_price", Convert.ToDouble(reader1["product_final_sell_price"].ToString()));
            cmd.Parameters.AddWithValue("@total_market_price", Convert.ToDouble(reader1["product_market_price"].ToString()));
            cmd.Parameters.AddWithValue("@product_shipping_charge", Convert.ToInt32(reader1["product_shipping_charge"].ToString()));
            cmd.Parameters.AddWithValue("@total_amount_of_product", total_amount_of_product);
            cmd.Parameters.AddWithValue("@total_order_amount", total_order_amount);
            cmd.Parameters.AddWithValue("@product_photo", reader1["photo_path"].ToString());
            cmd.Parameters.AddWithValue("@payment_mode", "Cash on Delivery");
            cmd.Parameters.AddWithValue("@order_status", "Processing");

            reader1.Close();
            con.Close();

            con.Open();
            RowsAffected = cmd.ExecuteNonQuery();

        }

        return (RowsAffected);
    }

    

}