<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="coupon.aspx.cs" Inherits="auth_coupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

     <label class="btn btn-success"><i class="fa fa-edit"></i></label>
    <b>Edit Coupon</b>
    &nbsp;&nbsp;

     <label class="btn btn-danger"><i class="fa fa-trash"></i></label>
    <b>Delete Coupon</b>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Coupon
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Coupon Code<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtcouponcode" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Coupon Value (In Rs.)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtcouponvalue" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Min. Order (In Rs.)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_minimum_order" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Max. Discount (In Rs.)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_max_discount" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Expiry date<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_date" TextMode="Date" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Short description<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_short_description" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="submit" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                        </div>

                    </div>
                </div>
            </div>


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Coupon List</a>
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
                                            <th>Code</th>
                                            <th>Coupon Value</th>
                                            <th>Expiry</th>
                                            <th>Min. Order</th>
                                             <th>Max. Discount</th>
                                            <th>Description</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbindgstdata" runat="server" OnItemCommand="rptbindgstdata_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <%# Eval("coupan_code") %>
                                                    </td>
                                                     <td>
                                                        <%# Eval("coupan_value") %>
                                                    </td>
                                                     <td>
                                                        <%# Eval("coupan_expiry_date") %>
                                                    </td>

                                                       <td>
                                                        <%# Eval("coupan_min_order") %>
                                                    </td>
                                                       <td>
                                                        <%# Eval("coupan_max_discount") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("coupan_description") %>
                                                    </td>

                                                    <td>
                                                        <a class="btn btn-success" href="#" data-toggle="modal" data-target="#edit<%#  Eval("id") %>" title="Delete"><i class="fa fa-edit"></i></a>

                                                        <a class="btn btn-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>
                                                </tr>


                                                  <%-- Edit Modal--%>


                                                <div class="modal fade" id="edit<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Update Coupon</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lbl_edit_row_id" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

                                                                <div class="col-md-3">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Coupon Code<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_couponcode" runat="server" class="form-control" Text='<%# Eval("coupan_code") %>' placeholder=""></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-3">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Coupon Value (In Rs.)<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_couponvalue" runat="server" class="form-control" Text='<%# Eval("coupan_value") %>' placeholder=""></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-3">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Min. Order (In Rs.)<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_minimum_order" runat="server" class="form-control" Text='<%# Eval("coupan_min_order") %>' placeholder=""></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-3">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Max. Discount (In Rs.)<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_max_discount" runat="server" class="form-control" Text='<%# Eval("coupan_max_discount") %>' placeholder=""></asp:TextBox>
                                                                    </div>
                                                                </div>



                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Expiry date<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_date" TextMode="Date" runat="server" class="form-control" Text='<%# Eval("coupan_expiry_date") %>' placeholder=""></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Short description<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_short_description" runat="server" class="form-control" Text='<%# Eval("coupan_description") %>' placeholder=""></asp:TextBox>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                <asp:LinkButton ID="lnksavechange" CommandName="btnsavechange" runat="server" class="btn btn-danger" Text="Save Change"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


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

                "ordering": false

            });
        });
        Rs. (document).ready(function () {
            Rs. ('#example2').DataTable();
        });

    </script>


</asp:Content>

