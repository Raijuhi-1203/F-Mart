<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="low-stock-product.aspx.cs" Inherits="auth_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">




    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
       
            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Low Stock Product</a>
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
                                            <th>Product</th>
                                <th>Stock</th>
                                <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rpt_low_stock_product" runat="server" >
                                            <ItemTemplate>

                                               <asp:Label ID="lbl_product_id" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                                    <tr>
                                        <td>
                                             <asp:Label ID="lbl_product" runat="server" Text='<%# Eval("product_full_name") %>'></asp:Label> (<%# Eval("product_unit") %>: <%# Eval("product_unit_value") %>)
                                        </td>
                                        <td>
                                            <%# Eval("product_stock") %>
                                        </td>
                                        <td>
                                           <a class="btn btn-success" href="edit-product.aspx?ref=<%#  Eval("product_id") %>" target="_blank" title="Edit"><i class="fa fa-edit"></i></a>
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

