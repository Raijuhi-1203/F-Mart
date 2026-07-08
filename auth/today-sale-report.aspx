<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/auth/admin.master" CodeFile="today-sale-report.aspx.cs" Inherits="auth_today_sale_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <div class="alert" id="alert_container"></div>
    
    <br />

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Sellerwise Sale Report 
                        </a>
                    </h4>
                </div>
                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">

                            <div class="col-md-3" id="date_to" runat="server">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Date<span style="color: red">&nbsp;*</span> </label>
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
                                                <th>Date</th>
                                                <th>Seller Name</th>
                                                <th>Total Amount</th>
                                                <th>Seller Amount</th>
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
                                                             <asp:Label ID="lbl_orderdate" runat="server" Text='<%# Eval("order_date") %>'></asp:Label>
                                                           <%-- <%#   DateTime.ParseExact(Eval("order_date").ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("MMMM, dd, yyyy", System.Globalization.CultureInfo.InvariantCulture)  %> --%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("product_sellername") %>
                                                        </td>
                                                        
                                                        <td>₹ <%# Eval("total_order_amount") %>
                                                        </td>
                                                        <td>₹ <%# Eval("original_price") %>
                                                        </td>

                                                    </tr>

                                                    

                                                </ItemTemplate>
                                            </asp:Repeater>

                                            <tr>
                                                <td style="font-weight:bold;color:red;">Total</td>
                                                <td></td>
                                                <td style="font-weight:bold;color:red;"><asp:Label ID="lbltotal" runat="server" class="" Style="border: 1px solid #ffffff;"></asp:Label></td>
                                                <td style="font-weight:bold;color:red;"><asp:Label ID="lblselleramount" runat="server" class="" Style="border: 1px solid #ffffff;"></asp:Label></td>
                                            </tr>

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
        $(document).ready(function () {
            $('#example1').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],

                "ordering": false

            });
        });
        $(document).ready(function () {
            $('#example2').DataTable();
        });
    </script>



</asp:Content>
