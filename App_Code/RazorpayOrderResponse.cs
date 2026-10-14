using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class RazorpayOrderResponse
{
    public bool success { get; set; }
    public string order_id { get; set; }
    public long amount { get; set; }
    public string currency { get; set; }
    public string key_id { get; set; }
    public string message { get; set; }

    public RazorpayOrderResponse() { }
}