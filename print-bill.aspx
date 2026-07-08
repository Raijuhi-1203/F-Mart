<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print-bill.aspx.cs" Inherits="print_bill" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>The Furniture Mart</title>
    <link rel="stylesheet" href="billstyle.css" type="text/css" media="all" />
</head>

<body>
    <div>
        <div class="py-4">

            <div class="px-14 py-6">
                <table class="w-full border-collapse border-spacing-0">
                    <tbody>
                        <tr>
                            <td class="w-full align-top">
                                <div>
                                    <img src="assets/img/logo.png" style="width: 150px; height: auto;" />
                                </div>
                            </td>

                            <td class="align-top">
                                <div class="text-sm">
                                    <table class="border-collapse border-spacing-0">
                                        <tbody>
                                            <tr>
                                                <td class="border-r pr-4">
                                                    <div>
                                                        <p class="whitespace-nowrap text-slate-400 text-right">Date</p>
                                                        <p class="whitespace-nowrap font-bold text-main text-right" id="date" runat="server"></p>
                                                    </div>
                                                </td>
                                                <td class="pl-4">
                                                    <div>
                                                        <p class="whitespace-nowrap text-slate-400 text-right">Invoice #</p>
                                                        <p class="whitespace-nowrap font-bold text-main text-right" id="order_id" runat="server"></p>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="bg-slate-100 px-14 py-6 text-sm">
                <table class="w-full border-collapse border-spacing-0">
                    <tbody>
                        <tr>
                            <td class="w-1/2 align-top">
                                <div class="text-sm text-neutral-600">
                                    <p class="font-bold">Shipping Address</p>
                                    <p id="add1" runat="server">Number: 23456789</p>
                                    <p id="add2" runat="server">VAT: 23456789</p>
                                    <p id="city" runat="server">6622 Abshire Mills</p>

                                </div>
                            </td>
                            <td class="w-1/2 align-top text-right">
                                <div class="text-sm text-neutral-600">
                                    <p class="font-bold">Company Details</p>
                                    <p>The Furniture Mart</p>
                                    <p>Address: Bank Rd, VindyaVasini Nagar</p>
                                    <p>Gorakhpur, Uttar Pradesh - 273001</p>
                                    <p>Phone: 9235501383</p>

                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="px-14 py-10 text-sm text-neutral-700">
                <table class="w-full border-collapse border-spacing-0">
                    <thead>
                        <tr>
                            
                            <td class="border-b-2 border-main pb-3 pl-2 font-bold text-main">Product details</td>
                            <td class="border-b-2 border-main pb-3 pl-2 text-right font-bold text-main">Price</td>
                            <td class="border-b-2 border-main pb-3 pl-2 text-center font-bold text-main">Qty.</td>
                            <td class="border-b-2 border-main pb-3 pl-2 text-right font-bold text-main">Subtotal</td>
                            <td class="border-b-2 border-main pb-3 pl-2 pr-3 text-right font-bold text-main">Total</td>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                            <ItemTemplate>

                                <tr>
                                    
                                    <td class="border-b py-3 pl-2"><%# Eval("product_name") %></td>
                                    <td class="border-b py-3 pl-2 text-right"><%# Eval("product_market_price") %></td>
                                    <td class="border-b py-3 pl-2 text-center"><%# Eval("product_qty") %></td>
                                    <td class="border-b py-3 pl-2 text-right"><%# Eval("total_amount_of_product") %></td>
                                    <td class="border-b py-3 pl-2 pr-3 text-right"><%# Eval("total_order_amount") %></td>
                                </tr>


                            </ItemTemplate>
                        </asp:Repeater>

                        <tr>
                            <td colspan="7">
                                <table class="w-full border-collapse border-spacing-0">
                                    <tbody>
                                        <tr>
                                            <td class="w-full"></td>
                                            <td>
                                                <table class="w-full border-collapse border-spacing-0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="border-b p-3">
                                                                <div class="whitespace-nowrap text-slate-400">Net Total:</div>
                                                            </td>
                                                            <td class="border-b p-3 text-right">
                                                                <div class="whitespace-nowrap font-bold text-main" id="nettotal" runat="server"></div>
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td class="border-b p-3">
                                                                <div class="whitespace-nowrap text-slate-400">Shipping Amount:</div>
                                                            </td>
                                                            <td class="border-b p-3 text-right">
                                                                <div class="whitespace-nowrap font-bold text-main">100.00</div>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="bg-main p-3">
                                                                <div class="whitespace-nowrap font-bold text-white">Total:</div>
                                                            </td>
                                                            <td class="bg-main p-3 text-right">
                                                                <div class="whitespace-nowrap font-bold text-white" id="totalamt" runat="server"></div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

           <%-- <div class="px-14 text-sm text-neutral-700">
                <p class="text-main font-bold">PAYMENT DETAILS</p>
                <p>Banks of Banks</p>
                <p>Bank/Sort Code: 1234567</p>
                <p>Account Number: 123456678</p>
                <p>Payment Reference: BRA-00335</p>
            </div>--%>

            <div class="px-14 py-10 text-sm text-neutral-700">
                <p class="text-main font-bold">Notes</p>
                <p class="italic">
                    This is a computer-generated invoice and does not require a signature.
                </p>
                </div>

       

                <footer class="fixed bottom-0 left-0 bg-slate-100 w-full text-neutral-600 text-center text-xs py-3">
                    The Furniture Mart
         
                    <span class="text-slate-300 px-2">|</span>
                    info@thefmart.com
         
                    <span class="text-slate-300 px-2">|</span>
                    +91-9235501383
       
                </footer>
            </div>
        </div>
    </div>
</body>

</html>

