using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Bulsms_gateway
/// </summary>
public class Bulksms_gateway
{
    Master mst = new Master();

    String exp = "";
    public Bulksms_gateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string sendMessage(string phoneNo, string messages)
    {
        try
        {
            string user = "sgs";
            string password = "sfgs@123";
            string senderid = "78787";
            string channel = "Trans";
            string number = "91" + phoneNo;
            string route = "46";

            string sURL;
            string result = "";

            StreamReader objReader;
            sURL = "http://smslogin.pcexpert.in/api/mt/SendSMS?user=" + user + "&password=" + password + "&senderid=" + senderid + "&channel=" + channel + "&DCS=0&flashsms=0&number=" + number + "&text=" + messages + "&route=" + route;
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
                objReader.Close();
            }
            catch (Exception ex)
            {
                result= ex.ToString();
            }

            return result;
        }
        catch (Exception)
        {
            return exp = "";
        }
    }


}