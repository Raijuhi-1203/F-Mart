<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="payment-mode.aspx.cs" Inherits="auth_payment_mode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Payment Mode Status</a>
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
                                            <th>Payment Mode</th>
                                            <th>Api key</th>
                                            <th>Secret key</th>
                                            <th>Enable</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:repeater id="rptbindgstdata" runat="server" OnItemCommand="rptbindgstdata_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <%# Eval("payment_mode") %>
                                                    </td>

                                                      <td>
                                                        <%# Eval("api_key") %>
                                                    </td>
                                                      <td>
                                                        <%# Eval("secret_key") %>
                                                    </td>


                                                    <td>
                                                        <%# Eval("mode_status") %>
                                                    </td>
                                                    <td>
                                                       <asp:LinkButton ID="lnkenable" CommandName="btnenable" CommandArgument='<%#  Eval("id") %>' runat="server" class="btn btn-success" title="Enable"><i class="fa fa-check"></i></asp:LinkButton>
                                                       <asp:LinkButton ID="lnkdisable" CommandName="btndisable" CommandArgument='<%#  Eval("id") %>' runat="server" class="btn btn-danger" title="Disable"><i class="fa fa-times"></i></asp:LinkButton>
                                                    </td>
                                                </tr>


                                            </ItemTemplate>
                                        </asp:repeater>

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
                "ordering": false


            });
        });
       

    </script>


</asp:Content>

