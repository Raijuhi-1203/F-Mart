<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="top-offer-product.aspx.cs" Inherits="auth_top_offer_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">


    <style>
        .mycheckbox input[type="checkbox"] {
            margin-right: 5px;
            font-size: 15px;
        }

        .mycheckbox input {
            /*margin-bottom: 12px;*/
            margin-top: 5px;
            margin-left: 10px !important;
            font-size: 15px;
        }

        .mycheckbox label {
            margin-left: 5px !important;
            font-size: 15px;
        }

        td {
            padding-right: 30px;
            padding-top: 10px
        }
    </style>

    <script>

        function Dropdown() {
            $("#<%=this.dblparentcategory.ClientID%>").selectpicker();
        }

    </script>


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Top Offer
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />


                            <asp:UpdatePanel ID="connect" runat="server">
                                <ContentTemplate>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">
                                                Choose Category
                                            <span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dblparentcategory" AutoPostBack="true" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dblparentcategory_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Select Product<span style="color: red">&nbsp;*</span> </label>
                                            <div class="body-box table-responsive" style="overflow-y: auto; overflow-x: auto; height: auto">
                                                <asp:CheckBoxList ID="chkproduct" runat="server" RepeatLayout="Table" CssClass="mycheckbox" RepeatDirection="Horizontal" Font-Size="Larger" RepeatColumns="3" CellSpacing="10"></asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                        </div>

                    </div>
                </div>
            </div>


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Top Offer Product</a>
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
                                            <th>Product</th>
                                            <th>Category</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbinddata" runat="server" OnItemDataBound="rptbinddata_ItemDataBound">
                                            <ItemTemplate>

                                                <asp:Label ID="lblproductid" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>

                                                <tr>
                                                   
                                                    <td>
                                                        <a href="view-product-details.aspx?ref=<%# Eval("product_id") %>" target="_blank">
                                                            <img id="item_photo" runat="server" src='' style="height: 80px; width: auto" />
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <a href="view-product-details.aspx?ref=<%# Eval("product_id") %>" target="_blank">
                                                            <%# Eval("product_full_name") %>
                                                        </a>
                                                    </td>

                                                    <td>
                                                        <%# Eval("product_parent_category_name") %>&nbsp;<i class="fas fa-chevron-right" style="font-size: 10px"></i>&nbsp;<%# Eval("product_sub_category_name") %> 
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
        $(document).ready(function () {
            $('#example2').DataTable();
        });
    </script>




</asp:Content>

