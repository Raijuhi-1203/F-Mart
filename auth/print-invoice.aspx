<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print-invoice.aspx.cs" Inherits="bill_receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Print Invoice</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="CodesGesture" name="description" />
    <meta content="CodesGesture" name="CodesGesture" />
    <link rel="shortcut icon" href="" title="Favicon" />
    <link rel="stylesheet" href="assets/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <style type="text/css" media="print">
        @page {
            size: 58mm 100mm
        }
        /* output size */
        body.receipt .sheet {
            width: 58mm;
            height: auto;
            padding: 0px !important
        }
        /* sheet size */
        @media print {
            body.receipt {
                width: 58mm;
                padding: 0px !important
            }
        }
        /* fix for Chrome */


        @media print {
            html, body {
                /* For print 1 page if 1 page  */
                margin: 0 !important;
                padding: 0 !important;
                overflow: hidden;
            }
        }


        @media print and (color) {
            * {
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
            }
        }

        /*page[size="A4"] {
            background: white;
            width: 21cm;
            height: 29.7cm;
            display: block;
            box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);
        }*/

        @media print {
            /*body, page[size="A4"] {
                margin: 10px 0;
                box-shadow: 0;
            }*/
        }


        @media print {
            html, body {
                /* For print 1 page if 1 page  */
                /*height: 100vh;
                margin: 0 !important;
                padding: 0 !important;
                overflow: hidden;*/
            }
        }


        @media print {
            a[href]:after {
                content: none !important;
            }
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

        .table > thead:first-child > tr:first-child > td {
            border-top: .2px solid !important;
        }
    </style>
    <link rel="stylesheet" href="assets/style.css" />


    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet">
</head>
<body class="pace-done sheet " style="-webkit-print-color-adjust: exact;">

    <form id="form1" runat="server">
        <div>

            <section class="box ">
                <div class="hidden-print">
                    <header class="panel_header">
                        <h2 class="title pull-left">Bill Receipt</h2>
                        <div class="actions panel_actions pull-right">

                            <a href="all-orders" class="btn btn-danger btn-md pull-right" style="margin-top: 10px; color: #fff !important"><i class="fa fa-list" style="color: #fff !important"></i>&nbsp;Back To Order</a>
                            <button onclick="myFunction()" class="btn btn-success btn-md pull-right" style="margin-top: 10px; color: #fff"><i class="fa fa-print" style="color: #fff !important"></i>&nbsp; Print Bill</button>
                        </div>
                    </header>
                </div>
                <div class="content-body sheet" style="padding: 0px !important">

                    <div id="headprint" class="row">

                        <page>
                                    <center>
                                          <b style="font-size:7px;">Invoice</b><br />
                                    </center>
                                
                                     <div class="col-xs-12" >
                                      <center>

                                     <p style="font-size:12px;background-color: #ffffff;border: 1px solid #ffffff;line-height:1.5em">
                       
                                         <b>Firm Name</b><br />
                                          info@domain.in<br />
                                        </p>

                                          <p style="line-height:0 !important;margin:0 !important;">
                                          <span style="width:50%">
     <b style="font-size: 8px">Order ID:</b>&nbsp;<asp:Label ID="lblorderid" runat="server" Style="font-size: 8px" Text=""></asp:Label>
</span>

                                            <span style="width:50%">
                        <b style="font-size: 8px">Invoice Date:</b>&nbsp;<asp:Label ID="lblorderplacedate" runat="server" Style="font-size: 8px" Text=""></asp:Label>
                                       </span>
                                         </p>

                                          <%--  <span style="width:100%">
                          <b style="font-size: 8px">Schedule time:</b>&nbsp;<asp:Label ID="lbl_shedule_time" runat="server" Style="font-size: 8px" Text=""></asp:Label>
                                               </span>--%>

                                           <span style="width:100%">
                          <b style="font-size: 8px">Payment Mode:</b>&nbsp;<asp:Label ID="lbl_payment_mode" runat="server" Style="font-size: 8px" Text=""></asp:Label>
                                               </span>

 <p style="line-height:.8 !important;margin:0 !important;">
                                            <span style="width:100%">
                                         <b style="font-size: 8px">Billing Address:</b>
                                               
                                              <br />
                                                <asp:Label ID="lblbillingname" runat="server" Style="font-size: 8px; font-weight: 600" Text=""></asp:Label><br />
                        <asp:Label ID="lbladdress" runat="server" Style="font-size: 8px" Text=""></asp:Label><br />
                        <asp:Label ID="lblbillingcitystatepincode" runat="server" Style="font-size: 8px" Text=""></asp:Label><br />
                        <asp:Label ID="lblbillingmobileno" runat="server" Style="font-size: 8px" Text=""></asp:Label>
                                   </span>
     </p>


                                      </center>

                                       </div>



                               <div class="col-lg-12 col-xs-12" style="margin-top:10px">

                                    <table class="table">
                                        <thead>
                                            <tr>

                                                <td class="text-center" style="padding:1px !important;line-height:.6em;">
                                                    <span style="color: #000 !important;font-size:8px;font-weight: 600">Items</span>
                                                </td>
                                                 <td class="text-center" style="padding:1px !important;line-height:.6em;">
                                                    <span style="color: #000 !important;font-size:8px;font-weight: 600">HSN</span>
                                                </td>

                                                  <td class="text-center" style="padding:1px !important;line-height:.6em">
                                                    <span style="color: #000 !important;font-size:8px;font-weight: 600">Qty</span>
                                                </td>

                                        <td class="text-center" style="padding:1px !important;line-height:.6em">
                                            <span style="color: #000 !important;font-size:8px;font-weight: 600">Rate </span>
                                        </td>

                                       
                                        <td class="text-center" style="padding:1px !important;line-height:.6em">
                                            <span style="color: #000 !important;font-size:8px;font-weight: 600">GST %</span>
                                        </td>
                                      
                                        <td class="text-center" style="padding:1px !important;line-height:.6em">
                                            <span style="color: #000 !important;font-size:8px;font-weight: 600">Amount </span>
                                        </td>

                                            </tr>
                                        </thead>

                                        <tfoot>
                                            <tr>
                                            </tr>
                                        </tfoot>
                                        <tbody id="Tbody1" runat="server">

                                            <asp:Repeater ID="rptorderproduct" runat="server">
                                                <ItemTemplate>

                                                    <tr>
                                                 <td class="text-center" style="font-size:8px;padding:1px !important;font-weight: 600">
                                                    <%# Eval("product_name") %> <%# Eval("product_unit_value") %> <%# Eval("product_unit") %>
                                               
                                                </td>

                                                         <td class="text-center" style="font-size:8px;padding:1px !important;font-weight: 600">
                                                    <%# Eval("product_hsn_sac") %> 
                                               
                                                </td>

                                                <td class="text-center" style="font-size:8px;padding:1px !important;font-weight: 600">
                                                    <%# Eval("product_qty") %>
                                                </td>

                                                
                                                <td class="text-center" style="font-size:8px;padding:1px !important;font-weight: 600">
                                                    <%# Eval("product_sell_price") %>
                                                </td>
                                             

                                                <td class="text-center" style="font-size:8px;padding:1px !important;font-weight: 600">
                                                    <%# Eval("product_GST_percentage") %>
                                                </td>

                                              
                                                <td class="text-center" style="font-size:8px;padding:1px !important;font-weight: 600">
                                                    <%# Eval("total_amount_of_product") %>
                                                </td>

                                                    </tr>

                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>


                                   <table class="table ">

                             <tbody>

                                 <tr>
                                     <td style="padding:1px !important;line-height:.6em"><span style="color: #000 !important;font-size:8px;font-weight: 600">Sub Total:</span></td>
                                     <td style="padding:1px !important;line-height:.6em"><label id="lblsubtotal" style="font-size:8px;padding:1px !important" runat="server">0</label></td>
                                 </tr>
                                 <tr>
                                     <td style="padding:1px !important;line-height:.6em"><span style="color: #000 !important;font-size:8px;font-weight: 600">Shipping:</span></td>
                                     <td style="padding:1px !important;line-height:.6em"><label id="lblshippingcharge" style="color: #000 !important;font-size:8px;padding:1px !important" runat="server">0</label></td>
                                 </tr>
                                 <tr>
                                     <td style="padding:1px !important;line-height:.6em"><span style="color: #000 !important;font-size:8px;font-weight: 600">Discount:</span></td>
                                     <td style="padding:1px !important;line-height:.6em"><label id="lbldiscountamount" style="color: #000 !important;font-size:8px;padding:1px !important" runat="server">0</label></td>
                                 </tr>
                                 <tr>
                                     <td style="padding:1px !important;line-height:.6em"><span style="color: #000 !important;font-size:8px;font-weight: 600">Coupon:</span></td>
                                     <td style="padding:1px !important;line-height:.6em"><label id="lblcoupon" style="color: #000 !important;font-size:8px;padding:1px !important" runat="server">0</label></td>
                                 </tr>
                                 <tr>
                                     <td style="padding:1px !important;line-height:.6em"><span style="color: #000 !important;font-size:8px;font-weight: 600">GST:</span></td>
                                     <td style="padding:1px !important;line-height:.6em"><asp:Label id="lblgstamount" style="color: #000 !important;font-size:8px;padding:1px !important;font-weight: 600" runat="server"  Text="00"></asp:Label></td>
                                 </tr>
                                  <tr>
                                     <td style="padding:1px !important;line-height:.6em"><span style="color: #000 !important;font-size:8px;font-weight: 600">Grand Total:</span></td>
                                     <td style="padding:1px !important;line-height:.6em"><asp:Label ID="lblgrandtotal" runat="server" Style="color: #000 !important;font-size:8px;padding:1px !important;font-weight: 600" Text="00"></asp:Label></td>
                                 </tr>

                               

                             </tbody>

                         </table>






                                      <table class="table  table-hover invoice-table">
                                          <tbody>
                            <tr>
                                   <td style="padding:1px !important;line-height:.6em">
                                       <span style="color: #000 !important;font-size:8px;font-weight: 600">Total Qty:</span>
                                   </td>
                                <td style="padding:1px !important;line-height:.6em">
                                       <asp:Label ID="lbl_total_qty" runat="server" Style="color: #000 !important;margin-bottom: .1px !important;font-size:8px;padding:1px !important;font-weight: 600" Text="00"></asp:Label><br />

                                   </td>

                                 </tr>

                                 <tr>

                                 <td style="padding:1px !important;line-height:.6em">
                                       <span style="color: #000 !important;font-size:8px">Total Items:</span>
                                   </td>
                                 <td style="padding:1px !important;line-height:.6em"> 

                                     <asp:Label ID="lbl_total_items" runat="server" Style="color: #000 !important;margin-bottom: .1px !important;font-size:8px;padding:1px !important;font-weight: 600" Text="00"></asp:Label>

                                 </td>

                            </tr>
                                              </tbody>
                           </table>

                              

                                </div>

                                <br /> 

                                 <div class="col-xs-12" >
                                     <p style="font-family: 'Montserrat', sans-serif;font-size:7px;text-align:center;    line-height: 1.5;">

                                         <b>Thanks for shopping with us.</b><br />
                                         Visit again for more delights.
                                         <br />

                                         Note: This is computer generated invoice & does not require signature.
                                     </p>

                                    
                                     </div>

                            </page>

                    </div>
                </div>
            </section>


        </div>

    </form>

    <script>
        function myFunction() {
            window.print();
        }
    </script>
</body>
</html>
