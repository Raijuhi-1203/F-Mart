<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="order-details.aspx.cs" Inherits="auth_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

      <br />
    <a href="all-orders" class="btn btn-success" runat="server"><i class="fa fa-list"></i>&nbsp;Back To Order List</a>

    <%--<a id="printinvoicelink" href="" class="btn btn-danger" target="_blank" runat="server"><i class="fa fa-print"></i>&nbsp;Print Invoice</a>--%>

    <a id="printinvoiceformartlink" href="" class="btn btn-info" target="_blank" runat="server"><i class="fa fa-print"></i>&nbsp;A4 Print Invoice </a>


    <div class="row"></div>
    <br />

    <asp:Label ID="lbl_auto_id" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lbl_invoice_no" hidden runat="server" Text=""></asp:Label>

    <asp:Label ID="lbl_customer_id" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lbl_refund_mode" hidden runat="server" Text=""></asp:Label>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1" style="text-decoration: none">Order details</a>
                    </h4>
                </div>

                <div id="collapse1" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label style="font-weight: bold">Order ID:</label>
                                    <asp:Label ID="lblorderno" runat="server" class="" Style="border: 1px solid #ffffff;"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputPassword1" style="font-weight: bold">Place on:</label>
                                    <asp:Label ID="lblorderplacedate" runat="server" class="" Style="border: 1px solid #ffffff;"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputPassword1" style="font-weight: bold">Schedule Time:</label>
                                    <asp:Label ID="lbl_schedule_time" runat="server" class="" Style="border: 1px solid #ffffff;"></asp:Label>
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

                            <div class="col-md-6" hidden>
                                <div class="form-group">
                                    <h3 style="font-weight: bold">Shipping address</h3>
                                    <br />

                                    <asp:Label ID="lblshippingname" Font-Bold="true" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lblshippingaddress" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lblshippingcitystatepincode" runat="server" Style="border: 1px solid #ffffff;"></asp:Label>, 
                                    <asp:Label ID="lblshippingcountry" runat="server" Text="India" Style="border: 1px solid #ffffff;"></asp:Label>
                                    <br />
                                    <b>Landmark:</b>
                                    <asp:Label ID="lblshippinglandmark" runat="server" Text="India" Style="border: 1px solid #ffffff;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblshippingmobileno" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lblshippingemail" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6" id="bank_details_div" runat="server">
                                <div class="form-group">
                                    <h3 style="font-weight: bold">Bank Account Details</h3>
                                    <br />

                                    <asp:Label ID="lbl_bank_name" Font-Bold="true" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lbl_bank_account_holder_name" runat="server" Style="border: 1px solid #ffffff;"></asp:Label><br />
                                    <asp:Label ID="lbl_bank_account_number" runat="server" Style="border: 1px solid #ffffff;"></asp:Label>
                                    <asp:Label ID="lbl_bank_ifsc" runat="server" Text="" Style="border: 1px solid #ffffff;"></asp:Label>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Order items</a>
                    </h4>
                </div>

                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputPassword1" style="font-weight: 600">Order Status</label>
                                    <asp:DropDownList ID="dblchangeorderstatus" class="form-control" runat="server">
                                        <asp:ListItem>Processing</asp:ListItem>
                                        <asp:ListItem>Confirm</asp:ListItem>
                                        <asp:ListItem>Dispatched</asp:ListItem>
                                        <asp:ListItem>Delivered</asp:ListItem>
                                        <asp:ListItem>Cancelled</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <button type="button" id="btnorderstatusupdate" runat="server" class="btn btn-success" style="margin-top: 22px" onserverclick="btnorderstatusupdate_ServerClick">Save Change</button>
                            </div>

                            <asp:Label ID="lblorderitemname" hidden runat="server"></asp:Label>
                            <div class="row"></div>
                            <br />

                            <div class="col-md-12 col-lg-12 col-sm-12">

                                <div class="body-box table-responsive">
                                    <table id="" class="table table-bordered table-striped">

                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Sub Order id</th>
                                                <th>Item</th>
                                                <th>MRP</th>
                                                <th>Dis %</th>
                                                <th>Price</th>
                                                <th>Qty</th>
                                                <th>Amount</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>

                                        <tbody id="Tbody1" runat="server">

                                            <asp:Repeater ID="rptbinddataprice" runat="server" OnItemDataBound="rptbinddataprice_ItemDataBound" OnItemCommand="rptbinddataprice_ItemCommand">
                                                <ItemTemplate>

                                                    <asp:Label ID="lblproductid" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>

                                                    <tr>

                                                        <td>
                                                            <img id="productphoto" runat="server" src='' style="height: 60px; width: auto" />
                                                        </td>
                                                        <td>
                                                            <%# Eval("id") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("product_name") %><br />
                                                            <b>HSN/SAC</b>  <%# Eval("product_hsn_sac") %>
                                                        </td>
                                                        <td>
                                                            <%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("product_market_price").ToString()), 2, MidpointRounding.AwayFromZero))  %>
                                                        </td>
                                                        <td>
                                                            <%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("product_discount_percentage").ToString()), 2, MidpointRounding.AwayFromZero))  %>
                                                        </td>

                                                        <td>
                                                            <%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("product_final_sell_price").ToString()), 2, MidpointRounding.AwayFromZero))  %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("product_qty") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_total_amount_of_product" runat="server" Text='<%# Convert.ToString(Math.Round(Convert.ToDouble(Eval("total_amount_of_product").ToString()), 2, MidpointRounding.AwayFromZero))  %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%# Eval("order_status") %>
                                                        </td>
                                                        <td>
                                                            <a class="link-danger" href="#" data-toggle="modal" data-target="#status<%#  Eval("id") %>" title="Change Order Status"><i class="fa fa-exchange-alt"></i></a>
                                                        </td>

                                                    </tr>

                                                    <%-- Status Modal--%>

                                                    <div class="modal fade" id="status<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                    <h4 class="modal-title" id="myModalLabel2">Change Order Status</h4>
                                                                </div>

                                                                <div class="panel-body">

                                                                    <asp:Label ID="lblsuborderid" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                                    <asp:Label ID="lblorderstatus" hidden runat="server" Text='<%# Eval("order_status") %>'></asp:Label>
                                                                    <asp:Label ID="lblorderitemname" hidden runat="server" Text='<%# Eval("product_name") %>'></asp:Label>

                                                                    <asp:Label ID="lbl_refund_mode" hidden runat="server" Text='<%# Eval("refund_mode") %>'></asp:Label>

                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <b>Sub Order No: </b>
                                                                            <asp:Label ID="lblsuborderno" runat="server" Style="border: 1px solid #ffffff;" Text='<%# Eval("sub_order_id") %>'></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <label for="exampleInputPassword1">Order Status</label>
                                                                            <asp:DropDownList ID="dblorderstatus" class="form-control" runat="server">
                                                                                <asp:ListItem>Processing</asp:ListItem>
                                                                                <asp:ListItem>Confirm</asp:ListItem>
                                                                                <asp:ListItem>Dispatched</asp:ListItem>
                                                                                <asp:ListItem>Delivered</asp:ListItem>
                                                                                <asp:ListItem>Cancelled</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                                                    <asp:LinkButton ID="lnkdelete" CommandName="btnstatuschangesuborder" runat="server" class="btn btn-success" Text="Save Change"></asp:LinkButton>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


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

