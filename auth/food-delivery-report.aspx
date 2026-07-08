<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="food-delivery-report.aspx.cs" Inherits="auth_delivery_boy_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Food Delivery Report
                        </a>
                    </h4>
                </div>
                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Delivery Boy<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dbl_delivery_boy" AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="dbl_delivery_boy_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-3" id="date_from" runat="server">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Date (From)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_date_from" TextMode="Date" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3" id="date_to" runat="server">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Date (To)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_date_to" TextMode="Date" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3" id="btn_search" runat="server">
                                <button type="submit" id="btnsearch" runat="server" class="btn btn-success" style="margin-top: 22px" onserverclick="btnsearch_ServerClick">Search</button>
                            </div>
                            <div class="col-md-12">

                                <div class="body-box table-responsive">
                                    <table id="example1" class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>Order</th>
                                                <th>Place Date</th>
                                                <th>Delivery Date</th>
                                                <th>Restaurant</th>
                                                <th>Customer</th>
                                                <th>Amount</th>
                                                <th>No of Items</th>
                                                
                                                <th>Status</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                            </tr>
                                        </tfoot>
                                        <tbody id="tlist" runat="server">

                                            <asp:Repeater ID="rptbinddata" runat="server" OnItemDataBound="rptbinddata_ItemDataBound">
                                                <ItemTemplate>

                                                    <asp:Label ID="lblorderid" hidden runat="server" Text='<%# Eval("order_id") %>'></asp:Label>

                                                    <tr>
                                                        <td>
                                                            <a href="order-details.aspx?ref=<%# Eval("order_id") %>" target="_blank">
                                                                <%# Eval("order_id") %>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <%# DateTime.ParseExact(Eval("order_date").ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("MMMM, dd, yyyy", System.Globalization.CultureInfo.InvariantCulture)  %> 
                                                        </td>

                                                         <td>
                                                            <%# DateTime.ParseExact(Eval("order_delivery_date").ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("MMMM, dd, yyyy", System.Globalization.CultureInfo.InvariantCulture)  %> <%# Eval("order_delivery_time") %>
                                                        </td>

                                                          <td>
                                                            <%# Eval("product_sellername") %>
                                                        </td>

                                                        <td>
                                                            <%# Eval("customer_name") %>
                                                        </td>
                                                      
                                                        <td>₹ <%# Eval("total_order_amount") %>
                                                        </td>

                                                        <td>
                                                            <asp:Label ID="lblnoofitems" runat="server" Text="0"></asp:Label>
                                                        </td>
                                                         <td>
                                                            <%# Eval("order_status") %>
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
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],

                "ordering": false

            });
        });
        Rs. (document).ready(function () {
            Rs. ('#example2').DataTable();
        });
    </script>




</asp:Content>

