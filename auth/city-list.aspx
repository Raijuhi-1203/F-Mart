<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="city-list.aspx.cs" Inherits="auth_city_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">


     <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">City List</a>
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
                                            <th>City</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rpt_data" runat="server" OnItemCommand="rpt_data_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <%# Eval("district_name") %>
                                                    </td>
                                                   
                                                    <td>
                                                        <a class="link-success" href="pincode-list.aspx?ref=<%#  Eval("district_name") %>" title="View Pincode"><i class="fa fa-eye"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("district_id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>
                                                </tr>

                                                <%-- Delete Modal--%>


                                                <div class="modal fade" id="Del<%# Eval("district_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lbl_district_id" hidden runat="server" Text='<%# Eval("district_id") %>'></asp:Label>
                                                                <asp:Label ID="lbl_district_name" hidden runat="server" Text='<%# Eval("district_name") %>'></asp:Label>

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
                "ordering": false,
            });
        });
        Rs. (document).ready(function () {
            Rs. ('#example2').DataTable();
        });

    </script>


</asp:Content>

