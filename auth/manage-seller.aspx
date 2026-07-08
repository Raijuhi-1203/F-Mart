<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="manage-seller.aspx.cs" Inherits="manage_seller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">


      <div class="alert" id="alert_container"></div>
    
    <div id="accordion-container" style="margin-top: 10px">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Restaurant Seller</a>
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
                                            <th>Restaurant</th>
                                            <th>Contact</th>
                                            <th>Address</th>
                                             <th>Area</th>
                                            <th>IsActive?</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbinddata" runat="server" OnItemDataBound="rptbinddata_ItemDataBound" OnItemCommand="rptbinddata_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                   
                                                    <td>
                                                        <%# Eval("seller_name") %><br />
                                                       <b><%# Eval("seller_firm_name") %></b> 
                                                    </td>

                                                    <td>
                                                        <%# Eval("seller_mobileno") %><br />
                                                        <%# Eval("seller_email") %>
                                                    </td>

                                                    <td>
                                                        <%# Eval("seller_address_line_1") %>, <%# Eval("seller_address_line_2") %><br />

                                                        <%# Eval("seller_city_name") %>, <%# Eval("seller_state_name") %>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="lbl_seller_area_id" hidden runat="server" Text='<%# Eval("seller_area_id") %>'></asp:Label>
                                                        <%# Eval("seller_pincode") %><br />
                                                        <b>Area:</b>&nbsp;<asp:Label ID="lbl_area_name" runat="server" Text=""></asp:Label>
                                                    </td>

                                                    <td>
                                                        <%# Eval("seller_status") %><br />
                                                        <a class="link-primary" href="#" data-toggle="modal" data-target="#Enable<%#  Eval("seller_id") %>" title="Active"><i class="fa fa-check"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#disable<%#  Eval("seller_id") %>" title="Deactive"><i class="fa fa-ban"></i></a>
                                                    </td>

                                                    <td>
                                                        <a class="link-info" href="restaurant-items.aspx?ref=<%# Eval("seller_id") %>" title="Items"><i class="fas fa-box"></i></a>
                                                        <a class="link-primary" href="edit-seller.aspx?ref=<%# Eval("seller_id") %>" title="Edit Seller"><i class="fas fa-edit"></i></a>
                                                        
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("seller_id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>

                                                </tr>


                                                <%-- Enable Modal--%>

                                                <div class="modal fade" id="Enable<%# Eval("seller_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirmation</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lblrowenableid" hidden runat="server" Text='<%# Eval("seller_id") %>'></asp:Label>

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

                                                <div class="modal fade" id="disable<%# Eval("seller_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirmation</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lbldisablerowid" hidden runat="server" Text='<%# Eval("seller_id") %>'></asp:Label>

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

                                                <div class="modal fade" id="Del<%# Eval("seller_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">

                                                                <asp:Label ID="lbldeletesellerid" hidden runat="server" Text='<%# Eval("seller_id") %>'></asp:Label>

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

