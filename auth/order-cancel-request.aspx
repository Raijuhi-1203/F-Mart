<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="order-cancel-request.aspx.cs" Inherits="auth_order_cancel_request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="alert" id="alert_container"></div>

    <div class="row"></div>
    <br />

    <div id="accordion-container">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Cancel Request</a>
                    </h4>
                </div>

                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />
                            <div class="body-box table-responsive">
                                <table id="example1" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>Order No</th>
                                            <th>SubOrder No</th>
                                            <th>Date</th>
                                            <th>Customer</th>
                                            <th>Amount</th>
                                            <th>Refund Mode</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbindorderdata" runat="server">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>

                                                        <a href="order-details.aspx?ref=<%# Eval("order_id") %>" target="_blank">
                                                            <%# Eval("order_id") %>
                                                        </a>
                                                    </td>

                                                    <td>
                                                        <a href="order-details.aspx?ref=<%# Eval("order_id") %>" target="_blank">
                                                            <%# Eval("id") %>
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <%#   DateTime.ParseExact(Eval("order_cancel_date").ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("MMMM, dd, yyyy", System.Globalization.CultureInfo.InvariantCulture)  %> <%# Eval("order_cancel_time") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("customer_name") %>
                                                    </td>

                                                    <td>₹ <%# Eval("total_amount_of_product") %>
                                                    </td>

                                                     <td>
                                                        <%# Eval("refund_mode") %>
                                                    </td>

                                                    <td>
                                                        <a class="btn btn-primary" href="order-details.aspx?ref=<%# Eval("order_id") %>" target="_blank" title="View Order Details"><i class="fa fa-eye"></i></a>
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
            Rs. ('#example2').DataTable();
        });
    </script>




</asp:Content>

