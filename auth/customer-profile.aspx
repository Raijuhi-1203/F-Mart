<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="customer-profile.aspx.cs" Inherits="auth_customer_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        th, td {
            padding: 5px;
            text-align: left;
        }
    </style>

    <style>
        label {
            font-size: 13px;
            font-weight: 600 !important;
        }
    </style>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Customer Information
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12">

                                <table style="width: 100%">
                                    <tr>

                                        <th>Name</th>
                                        <td>
                                            <asp:Label ID="lbl_customer_name" runat="server" placeholder=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <th>Email</th>
                                        <td>
                                            <asp:Label ID="lbl_email" runat="server" placeholder=""></asp:Label></td>
                                        <th>Mobile No</th>
                                        <td>
                                            <asp:Label ID="lbl_mobileno" runat="server" placeholder=""></asp:Label></td>

                                        <th>Gender</th>
                                        <td>
                                            <asp:Label ID="lbl_gender" runat="server" placeholder=""></asp:Label></td>
                                    </tr>

                                    <tr>

                                        <th>Bank Name</th>
                                        <td>
                                            <asp:Label ID="lbl_bank_name" runat="server" placeholder=""></asp:Label>
                                        </td>

                                         <th>Account Holder</th>
                                        <td>
                                            <asp:Label ID="lbl_bank_account_holder" runat="server" placeholder=""></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>

                                        <th>Account Number</th>
                                        <td>
                                            <asp:Label ID="lbl_bank_ac_number" runat="server" placeholder=""></asp:Label>
                                        </td>

                                         <th>IFSC</th>
                                        <td>
                                            <asp:Label ID="lbl_bank_ifsc" runat="server" placeholder=""></asp:Label>
                                        </td>
                                    </tr>

                                </table>

                                <br />

                                <h3>Address</h3>
                                <br />

                                <div class="body-box table-responsive">
                                    <table class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>Address</th>
                                                <th>Mobile No</th>
                                                <th>Email</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                            </tr>
                                        </tfoot>
                                        <tbody id="tlist" runat="server">

                                            <asp:Repeater ID="rpt_customer_address" runat="server" OnItemCommand="rpt_customer_address_ItemCommand" OnItemDataBound="rpt_customer_address_ItemDataBound">
                                                <ItemTemplate>

                                                    <tr>
                                                        <td>
                                                            <%# Eval("address_line_1") %>, <%# Eval("address_line_2") %>
                                                            <br />
                                                            <%# Eval("address_city_name") %>, <%# Eval("address_state_name") %>-<%# Eval("address_pincode") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("address_customer_mobileno") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("address_customer_email") %>
                                                        </td>
                                                      
                                                    </tr>


                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>

                               
                            </div>

                           <%-- <div class="col-md-2">

                                <table style="width: 100%">
                                    <tr>

                                        <th style="border: 1px solid white;">
                                            <img id="photo" runat="server" style="height: 150px !important; width: auto; border-radius: 50%" alt="Photo" /></th>
                                    </tr>
                                </table>

                            </div>--%>

                            <div class="col-md-12">
                                <br />

                                <h3>All Orders</h3>
                                <br />

                                <div class="body-box ">
                                    <table id="example1" class="table table-bordered table-responsive table-striped">
                                        <thead>
                                            <tr>
                                                <th>OrderID</th>
                                                <th>Place Date</th>
                                                <th>Payment</th>
                                                <th>Amount</th>
                                                <th>No of Items</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                            </tr>
                                        </tfoot>
                                        <tbody id="Tbody1" runat="server">

                                            <asp:Repeater ID="rptbindorderdata" runat="server" OnItemCommand="rptbindorderdata_ItemCommand" OnItemDataBound="rptbindorderdata_ItemDataBound">
                                                <ItemTemplate>

                                                    <asp:Label ID="lblorderid" hidden runat="server" Text='<%# Eval("order_id") %>'></asp:Label>
                                                    <asp:Label ID="lbl_customer_mobileno" hidden runat="server" Text='<%# Eval("customer_mobileno") %>'></asp:Label>

                                                    <tr>
                                                        <td>
                                                            <a href="order-details.aspx?ref=<%# Eval("order_id") %>" target="_blank">
                                                                <%# Eval("order_id") %>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <%# Eval("order_date").ToString()  %> <%# Eval("order_delivery_time") %>
                                                        </td>

                                                        <td>
                                                            <%# Eval("payment_mode") %>
                                                        </td>
                                                        <td>₹ <%# Eval("total_order_amount") %>
                                                        </td>

                                                        <td>
                                                            <asp:Label ID="lblnoofitems" runat="server" Text="0"></asp:Label>
                                                        </td>

                                                        <td>
                                                            <%# Eval("order_status") %>
                                                        </td>

                                                        <td>
                                                            <a class="link-primary" href="order-details.aspx?ref=<%# Eval("order_id") %>" target="_blank" title="View Order Details"><i class="fa fa-eye"></i></a>
                                                            <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("order_id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                        </td>

                                                    </tr>

                                                    <%-- Delete Modal--%>

                                                    <div class="modal fade" id="Del<%# Eval("order_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                    <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                                </div>

                                                                <div class="panel-body">
                                                                    <asp:Label ID="lblroworderid" hidden runat="server" Text='<%# Eval("order_id") %>'></asp:Label>

                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <center>
                                                                             <label style="font-size:25px;">Are you sure you want to delete this order?</label>
                                                                        </center>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                                                                    <asp:LinkButton ID="lnkdelete" CommandName="btndelete" runat="server" class="btn btn-danger" Text="Yes"></asp:LinkButton>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>

                                <br />

                                <h3>Most Ordered Product</h3>
                                <br />

                                <div class="body-box ">
                                    <table id="most_ordered" class="table table-bordered table-responsive table-striped">
                                        <thead>
                                            <tr>
                                                <th>Product</th>
                                                <th>Counter</th>
                                                <th>Qty</th>
                                                <th>Amount</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                            </tr>
                                        </tfoot>
                                        <tbody id="Tbody3" runat="server">

                                            <asp:Repeater ID="rpt_data" runat="server" OnItemDataBound="rpt_data_ItemDataBound">
                                                <ItemTemplate>

                                                    <asp:Label ID="lbl_product_id" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>

                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_product" runat="server" Text=""></asp:Label>
                                                            (<%# Eval("product_unit") %>:
                                                            <asp:Label ID="lbl_product_unit_value" runat="server" Text='<%# Eval("product_unit_value") %> '></asp:Label>)
                                                        </td>
                                                        <td>
                                                            <%# Eval("item_count") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_qty" hidden runat="server" Text='<%# Eval("product_qty") %> '></asp:Label>
                                                            <asp:Label ID="lbl_final_qty" runat="server" Text=""></asp:Label>
                                                            <%# Eval("product_unit") %>
                                                        
                                                        </td>

                                                        <td>
                                                            <%# Eval("total_sell_amount") %>
                                                        </td>
                                                    </tr>

                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>


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
            Rs. ('#rating').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false
            });
        });

        Rs. (document).ready(function () {
            Rs. ('#most_ordered').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false
            });
        });

        Rs. (document).ready(function () {
            Rs. ('.table-resp').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false
            });
        });

        Rs. (document).ready(function () {
            Rs. ('#example2').DataTable();
        });
    </script>




</asp:Content>

