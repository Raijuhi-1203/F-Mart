<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="restaurant-items.aspx.cs" Inherits="auth_restaurant_items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Restaurant Items</a>
                    </h4>
                </div>

                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="body-box table-responsive">
                                <table id="example1" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>Item</th>
                                            <th>Variant</th>
                                            <th>MRP</th>
                                            <th>Dis %</th>
                                            <th>Price</th>
                                            <th>GST %</th>
                                            <th>Tax Type</th>
                                            <th>Final Price</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="Tbody1" runat="server">

                                        <asp:Repeater ID="rptbinddataprice" runat="server" OnItemCommand="rptbinddataprice_ItemCommand" OnItemDataBound="rptbinddataprice_ItemDataBound">
                                            <ItemTemplate>

                                                <tr>

                                                    <td>
                                                        <asp:Label ID="lbl_product_id" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                                                        <asp:Label ID="lbl_item_name" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_unit_value") %> <%# Eval("product_unit") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_market_price") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_discount_percentage") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_sell_price") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_GST_percentage") %>%
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_GST_type") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_final_sell_price") %>
                                                    </td>

                                                    <td>
                                                        <a class="link-success" href="edit-food-price.aspx?ref=<%# Eval("id") %>" target="_blank" title="Edit Price & Stock"><i class="fa fa-edit"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
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
                                                                <asp:Label ID="lblrowdeleteid" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <center>
                                                                            <label style="font-size: 25px;">Are you sure you want to delete?</label>
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
        $(document).ready(function () {
            $('#example1').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
            });
        });


    </script>


</asp:Content>

