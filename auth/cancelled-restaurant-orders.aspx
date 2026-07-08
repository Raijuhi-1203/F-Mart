<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="cancelled-restaurant-orders.aspx.cs" Inherits="auth_cancelled_restaurant_orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

      <div class="alert" id="alert_container"></div>

    <div class="row"></div>
    <br />

    <div id="accordion-container">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Cancelled Restaurant Orders</a>
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
                                            <th>Reason</th>
                                            <th>Comment</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbindorderdata" runat="server" OnItemCommand="rptbindorderdata_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <a href="order-details.aspx?ref=<%# Eval("order_id") %>" target="_blank">
                                                            <%# Eval("order_id") %>
                                                        </a>
                                                    </td>

                                                     <td>
                                                        <%# Eval("id") %>
                                                    </td>
                                                    <td>
                                                        <%#   DateTime.ParseExact(Eval("order_cancel_date").ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("MMMM, dd, yyyy", System.Globalization.CultureInfo.InvariantCulture)  %> <%# Eval("order_cancel_time") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("customer_name") %>
                                                    </td>
                                                   
                                                    <td>
                                                        ₹ <%# Eval("total_amount_of_product") %>
                                                    </td>

                                                    <td>
                                                        <%# Eval("order_return_reason") %>
                                                    </td>

                                                     <td>
                                                        <%# Eval("order_return_comment") %>
                                                    </td>

                                                    <td>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete" hidden><i class="fa fa-trash"></i></a>
                                                    </td>

                                                </tr>

                                                <%-- Delete Modal--%>

                                                <div class="modal fade" id="Del<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lblrowsuborderid" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <center>
                                                                             <label style="font-size:25px;">Are you sure you want to delete?</label>
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
            });
        });
        Rs. (document).ready(function () {
            Rs. ('#example2').DataTable();
        });
    </script>


</asp:Content>

