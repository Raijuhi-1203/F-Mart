<%@ Page Title="" Language="C#" MasterPageFile="~/auth/other.master" AutoEventWireup="true" CodeFile="order-details-for-restaurant.aspx.cs" Inherits="auth_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <style>
        .table td, .table th {
            padding: 0.3rem !important;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
            font-size: 13px !important;
        }

    </style>



    <div class="alert" id="alert_container"></div>

    <div class="row"></div>
    <br />

    <asp:Label ID="lbl_auto_id" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lbl_seller_id" hidden runat="server" Text=""></asp:Label>

    <asp:Label ID="lbl_customer_id" hidden runat="server" Text=""></asp:Label>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1" style="text-decoration: none">
                            Order details</a>
                    </h4>
                </div>

                <div id="collapse1" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label style="font-weight: bold">Order ID:</label>
                                    <asp:Label ID="lblorderno" runat="server" class="" Style="border: 1px solid #ffffff;"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1" style="font-weight: bold">Place on:</label>
                                    <asp:Label ID="lblorderplacedate" runat="server" class="" Style="border: 1px solid #ffffff;"></asp:Label>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <h3 style="font-weight: bold">Billing address</h3>
                                    <br />
                                    <asp:Label ID="lblbillingname" Font-Bold="true" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lblbillingaddress" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lblbillingcitystatepincode" runat="server" Style="border: 1px solid #ffffff;"></asp:Label>, 
                                    <asp:Label ID="lblbillingcountry" runat="server" Text="India" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <b>Landmark:</b>
                                    <asp:Label ID="lblbillinglandmark" runat="server" Text="India" Style="border: 1px solid #ffffff;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblbillingmobileno" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lblbillingemail" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <h3 style="font-weight: bold">Restaurant</h3>
                                    <br />

                                    <asp:Label ID="lbl_restaurant_name" Font-Bold="true" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lbl_restaurant_address" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lbl_restaurant_pincode" runat="server" Style="border: 1px solid #ffffff;"></asp:Label>, 
                                    <br />
                                    <asp:Label ID="lbl_restaurant_mobile" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">
                            Order items</a>
                    </h4>
                </div>

                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />


                            <asp:Label ID="lblorderitemname" hidden runat="server"></asp:Label>
                            <div class="row"></div>
                            <br />

                            <div class="col-md-12 col-lg-12 col-sm-12">

                                <div class="body-box table-responsive">
                                    <table id="" class="table table-bordered table-striped">

                                        <thead>
                                            <tr>
                                                <th>Item</th>
                                                <th>Qty</th>
                                                <th>Amount</th>
                                            </tr>
                                        </thead>

                                        <tbody id="Tbody1" runat="server">

                                            <asp:Repeater ID="rptbinddataprice" runat="server">
                                                <ItemTemplate>

                                                    <asp:Label ID="lblproductid" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>

                                                    <tr>
                                                        
                                                        <td>
                                                            <%# Eval("product_name") %>
                                                        </td>
                                                       
                                                        <td>
                                                            <%# Eval("product_qty") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_total_amount_of_product" runat="server" Text='<%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("total_amount_of_product").ToString()), 2, MidpointRounding.AwayFromZero))  %>'></asp:Label>
                                                        </td>
                                                       
                                                    </tr>

                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>

                            </div>

                            <div class="col-md-7 col-sm-7 col-lg-7"></div>

                            <div class="col-md-2 col-sm-2 col-xs-2" style="text-align: left">
                                <b>Payment Mode:</b><br />
                                <b>Amount:</b><br />
                                <b>Discount:</b><br />
                                <b>Coupon:</b><br />
                                <b>GST:</b><br />
                                <b>Shipping:</b><br />
                                <b>Grand total:</b><br />
                            </div>

                            <div class="col-md-3 col-sm-3 col-xs-3" style="text-align: right">

                                <asp:Label ID="lblpaymentmethod" runat="server" Text="0"></asp:Label><br />

                                ₹&nbsp;<asp:Label ID="lblsubtotal" runat="server" Text="0"></asp:Label><br />

                                ₹&nbsp;<asp:Label ID="lbltotaldiscount" runat="server" Text="0"></asp:Label><br />

                                ₹&nbsp;<asp:Label ID="lblcoupon" runat="server" Text="0"></asp:Label><br />

                                ₹&nbsp;<asp:Label ID="lbltotalgstamount" runat="server" Text="0"></asp:Label><br />

                                <asp:Label ID="lbltotalshippingamount" runat="server" Text="0"></asp:Label><br />

                                ₹&nbsp;<asp:Label ID="lblgrandtotalamount" runat="server" Text="0"></asp:Label><br />
                            </div>

                        </div>
                    </div>
                </div>
            </div>


        </div>
    </div>

    <script>

        Rs. (document).ready(function () {
            Rs. ('#example1').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false
            });
        });

        Rs. (document).ready(function () {
            Rs. ('#example2').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false
            });
        });

    </script>

</asp:Content>

