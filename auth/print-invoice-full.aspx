<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print-invoice-full.aspx.cs" Inherits="auth_printreceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Print Invoice</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="TheBazaar" name="description" />
    <meta content="TheBazaar" name="author" />

    <link rel="stylesheet" href="assets/bootstrap.min.css" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <style>

        @media print and (color) {
            * {
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
            }

            html, body {
                height: auto;
                margin: 0 !important;
                padding: 0 !important;
                overflow: hidden;
            }
        }

        .txt-right {
            text-align: right;
        }

        .table td, .table th {
            padding: .20rem !important;
            font-size: 12px !important;
        }

        .table-bordered td, .table-bordered th {
            border: 1px solid #000000 !important;
            font-size: 14px;
        }

        section .content-body{
            padding: 10px !important;
        }



    </style>

    <style type="text/css">
        .jqstooltip {
            position: absolute;
            left: 0px;
            top: 0px;
            visibility: hidden;
            background: rgb(0, 0, 0) transparent;
            background-color: rgba(0,0,0,0.6);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000);
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000)";
            color: white;
            font: 10px arial, san serif;
            text-align: left;
            white-space: nowrap;
            padding: 5px;
            border: 1px solid white;
            z-index: 10000;
        }

        .jqsfield {
            color: white;
            font: 10px arial, san serif;
            text-align: left;
        }
    </style>
    <link rel="stylesheet" href="assets/style.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script type="text/javascript">


        $(document).ready(function () {
            var theTotal = 0;
            $(".lblsavedvalue").each(function () {
                theTotal += parseFloat($(this).html());
            });
            $("#lblsaved").html(theTotal);
        });


    </script>



</head>
<body class="pace-done">


    <div class="col-lg-8">
        <section class="box ">
            <div class="hidden-print">
                <header class="panel_header">
                    <h2 class="title pull-left">INVOICE DETAILS</h2>
                    <div class="actions panel_actions pull-right">

                        <a href="all-orders" class="btn btn-purple">Back To Order</a>
                    </div>
                </header>
            </div>
            <div class="content-body">

                <div id="headprint" class="row">

                     <div class="col-md-12 col-sm-21 col-xs-12">
                         <center>
                              <h3 style="font-weight:600">Tax Invoice</h3>
                         </center>
                         </div>

                   <%-- <div class="col-md-4 col-sm-4 col-xs-4 ">
                        <img src="" style="height: 125px; width: auto" class="img-responsive" />
                    </div>--%>
                    <div class="col-md-4 col-sm-4 col-xs-4 "></div>
                    <div class="col-md-4 col-sm-4 col-xs-4 " style="line-height: 1.3;">
                        <center>
                        <h3><b>EasyLifes</b></h3>
                            
                        <span class="text-muted" style="font-size: 12px; color: black">
                           <b style="font-size: 12px">Address:</b>&nbsp;Lorem Ipsum is simply dummy,<br /> Uttar Pradesh 274401
                           
                       <br />
                            <b style="font-size: 12px">Phone:</b>&nbsp;1234567890
                            <br />
                            <b style="font-size: 12px">Email:</b>&nbsp;contact@domain.com
                             
                              <br />
                        </span>
                             </center>
                    </div>
                      <div class="col-md-4 col-sm-4 col-xs-4 "></div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="col-xs-12" style="border:1px dashed #333;width:100%;margin-top: 10px;margin-bottom: 10px;"></div>
                    <asp:Label ID="lblproductid" hidden runat="server" Style="font-size: 12px" Text=""></asp:Label>

                    <div class="col-xs-4 invoice-infoblock">
                        <b style="font-size: 12px">Order ID:</b>&nbsp;<asp:Label ID="lblorderid" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                        <b style="font-size: 12px">Order Date:</b>&nbsp;<asp:Label ID="lblorderplacedate" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />

                       
                        <b style="font-size: 12px">Payment Mode:</b>&nbsp;<asp:Label ID="lbl_payment_mode" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                    </div>
                    <div class="col-xs-4 invoice-infoblock " style="line-height: 15px">
                        <b style="font-size: 12px">Billing Address</b><br />
                        <asp:Label ID="lblbillingname" runat="server" Style="font-size: 12px; font-weight: 600" Text=""></asp:Label><br />
                        <asp:Label ID="lbladdress" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                        <asp:Label ID="lblbillingcitystatepincode" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                        <asp:Label ID="lblbillingmobileno" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                        <asp:Label ID="lblbillingemail" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                    </div>
                    <div class="col-xs-4 invoice-infoblock " style="line-height: 15px">
                        <b style="font-size: 12px">Shipping Address</b><br />
                        <asp:Label ID="lblshippingname" runat="server" Style="font-size: 12px; font-weight: 600" Text=""></asp:Label><br />
                        <asp:Label ID="lblbuyeraddress" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                        <asp:Label ID="lblshippingcitystatepincode" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                        <asp:Label ID="lblshippingmobileno" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                        <asp:Label ID="lblshippingemail" runat="server" Style="font-size: 12px" Text=""></asp:Label><br />
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="table-responsive">
                            <table class="table table-hover  table-bordered invoice-table">
                                <thead>
                                    <tr>

                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">Item(s) Description</h4>
                                        </td>
                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">Qty</h4>
                                        </td>

                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">MRP </h4>
                                        </td>
                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">Rate </h4>
                                        </td>

                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">Dis (Rs)</h4>
                                        </td>
                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">CGST</h4>
                                        </td>
                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">SGST</h4>
                                        </td>
                                        <td class="text-center" style="background-color: #6a6b6d !important">
                                            <h4 style="font-size: 14px; color: #fff !important;">Amount </h4>
                                        </td>
                                    </tr>
                                </thead>

                                <tfoot>

                                    <tr>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center">
                                           
                                        </td>
                                        <td class="text-center">
                                           
                                        </td>
                                    </tr>

                                </tfoot>
                                <tbody id="tlist" runat="server">

                                    <asp:Repeater ID="rptorderproduct" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="padding: 5px !important; font-size: 12px">
                                                    <%# Eval("product_name") %>
                                                    <br />
                                                    <b><%# Eval("product_unit") %>:</b> <%# Eval("product_unit_value") %> 
                                               
                                                </td>

                                                <td style="padding: 5px !important; font-size: 12px" class="text-center">
                                                    <%# Eval("product_qty") %>
                                                </td>

                                                <td style="padding: 5px !important; font-size: 12px">
                                                    <%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("product_market_price").ToString()),2, MidpointRounding.AwayFromZero))  %>
                                                </td>

                                                <td style="padding: 5px !important; font-size: 12px">
                                                    <%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("product_sell_price").ToString()),2, MidpointRounding.AwayFromZero)) %>
                                                </td>

                                                <td style="padding: 5px !important; font-size: 12px">
                                                    <%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("product_discount_price").ToString()),2, MidpointRounding.AwayFromZero)) %>
                                                </td>

                                                <td style="padding: 5px !important; font-size: 12px">
                                                    <%# Eval("product_CGST_rate") %>
                                                </td>

                                                <td style="padding: 5px !important; font-size: 12px">
                                                    <%# Eval("product_SGST_rate") %>
                                                </td>
                                                <td style="padding: 5px !important; font-size: 12px">
                                                    <%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("total_amount_of_product").ToString()),2, MidpointRounding.AwayFromZero)) %>
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                            </table>

                        </div>
                    </div>
                    <div class="col-md-7 col-sm-7 col-xs-7">

                        <b>Terms and Conditions</b><br>
                        <ol>
                            <li>Our responsibility ceases the moment the goods leave our godown.</li>
                            <li>The goods sold as are intended for end user consumption and not for re-sale.</li>
                        </ol>
                    </div>


                    <div class="col-md-5 col-sm-5 col-xs-5" style="text-align: left">
                        <table class="table table-bordered invoice-table">

                            <tbody>

                                <tr>
                                    <td style="font-weight: 600">Amount:</td>
                                    <td class="txt-right">
                                        <label id="lblsubtotal" style="color: #000 !important; margin-bottom: .1px !important" runat="server">0</label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="font-weight: 600">Discount:</td>
                                    <td class="txt-right">
                                        <label id="lbldiscountamount" style="color: #000 !important; margin-bottom: .1px !important" runat="server">0</label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="font-weight: 600">Coupon:</td>
                                    <td class="txt-right">-<label id="lblcoupon" style="color: #000 !important; margin-bottom: .1px !important" runat="server">0</label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="font-weight: 600">Total CGST:</td>
                                    <td class="txt-right">
                                        <label id="lbl_cgst_amount" style="color: #000 !important; margin-bottom: .1px !important" runat="server">0</label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight: 600">Total SGST:</td>
                                    <td class="txt-right">
                                        <label id="lbl_sgst_amount" style="color: #000 !important; margin-bottom: .1px !important" runat="server">0</label></td>
                                </tr>

                                <tr>
                                    <td style="font-weight: 600">Shipping:</td>
                                    <td class="txt-right">
                                        <label id="lblshippingcharge" style="color: #000 !important; margin-bottom: .1px !important" runat="server">0</label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="font-weight: 600">Grand Total:</td>
                                    <td class="txt-right">
                                        <asp:Label ID="lblgrandtotal" runat="server" Style="color: #000 !important; margin-bottom: .1px !important; font-weight: 600" Text="00"></asp:Label></td>
                                </tr>

                              


                            </tbody>

                        </table>
                    </div>


                </div>



                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-6 text-left">

                        <br>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-6 text-right">

                        <br>
                        
                           <span style="font-size:18px;font-weight:600"> Thank You!</span><br />
                          <span style="font-size:15px;font-weight:400"> for shopping with us</span>

                        
                        <div class="hidden-print">
                            <button onclick="myFunction()" class="btn btn-purple btn-md"><i class="fa fa-print"></i>&nbsp; Print </button>
                        </div>
                    </div>
                </div>

            </div>

        </section>
    </div>

    <script>
        function myFunction() {
            window.print();
        }
    </script>



</body>
</html>
