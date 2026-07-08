<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="manage-delivery-boy.aspx.cs" Inherits="auth_manage_delivery_boy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container" style="margin-top: 10px">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Delivery Boy</a>
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
                                            <th>#</th>
                                            <th>Name</th>
                                            <th>Contact</th>
                                            <th>Address</th>
                                            <th>Password</th>
                                            <th>Status</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand" OnItemDataBound="rptbinddata_ItemDataBound">
                                            <ItemTemplate>

                                                <tr>
                                                     <td>
                                                        <%# Eval("delivery_boy_date") %>-<%# Eval("delivery_boy_time") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("delivery_boy_name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("delivery_boy_mobileno") %><br />
                                                        <%# Eval("delivery_boy_email") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("delivery_boy_address_line_1") %>

                                                        <%# Eval("delivery_boy_city_name") %>, <%# Eval("delivery_boy_state_name") %>

                                                    </td>

                                                    <td>
                                                          <asp:Label ID="lbl_delivery_boy_password" hidden runat="server" Text='<%# Eval("delivery_boy_password") %>'></asp:Label>
                                                    <asp:Label ID="lbl_password" runat="server" Text=""></asp:Label>

                                                    </td>

                                                    <td>
                                                        <%# Eval("delivery_boy_status") %>
                                                    </td>

                                                    <td>
                                                        <%--<a class="link-success" href="assign-order-to-delivery-boy.aspx?ref=<%# Eval("delivery_boy_id") %>" title="Assign Orders"><i class="fas fa-plus"></i></a>--%>

                                                        <a class="link-primary" href="#" data-toggle="modal" data-target="#Enable<%#  Eval("delivery_boy_id") %>" title="Active"><i class="fa fa-check"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#disable<%#  Eval("delivery_boy_id") %>" title="Deactive"><i class="fa fa-ban"></i></a>

                                                        <a class="link-primary" href="edit-delivery-boy.aspx?ref=<%# Eval("delivery_boy_id") %>" title="Edit Delivery Boy"><i class="fas fa-edit"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("delivery_boy_id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>

                                                </tr>


                                                <%-- Enable Modal--%>

                                                <div class="modal fade" id="Enable<%# Eval("delivery_boy_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirmation</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lblrowenableid" hidden runat="server" Text='<%# Eval("delivery_boy_id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <center>
                                                                             <label style="font-size:25px;">Are you sure you want to activate?</label>
                                                                        </center>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                                                                <asp:LinkButton ID="LinkButton1" CommandName="btnenable" runat="server" class="btn btn-danger" Text="Yes"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>



                                                <%-- Disable Modal--%>

                                                <div class="modal fade" id="disable<%# Eval("delivery_boy_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirmation</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lbldisablerowid" hidden runat="server" Text='<%# Eval("delivery_boy_id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <center>
                                                                             <label style="font-size:25px;">Are you sure you want to deactivate?</label>
                                                                        </center>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                                                                <asp:LinkButton ID="LinkButton2" CommandName="btndisable" runat="server" class="btn btn-danger" Text="Yes"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>



                                                <%-- Delete Modal--%>

                                                <div class="modal fade" id="Del<%# Eval("delivery_boy_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">

                                                                <asp:Label ID="lbldeletedelivery_boy_id" hidden runat="server" Text='<%# Eval("delivery_boy_id") %>'></asp:Label>

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

