<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="product-shop.aspx.cs" Inherits="auth_product_shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Product Shop
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Shop Name<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_shop_name" runat="server" class="form-control" placeholder="Bhala Kirana"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Select Product(s)<span style="color: red">&nbsp;*</span> </label>
                                    <div class="body-box table-responsive" style="overflow-y: auto; overflow-x: auto; height: auto">
                                        <asp:CheckBoxList ID="chkproduct" runat="server" RepeatLayout="Table" CssClass="mycheckbox" RepeatDirection="Horizontal" Font-Size="Larger" RepeatColumns="3" CellSpacing="10"></asp:CheckBoxList>
                                    </div>
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
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Shop List</a>
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
                                            <th>Shop Name</th>
                                            <th>Product(s)</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <%# Eval("shop_name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("product_name") %>
                                                    </td>
                                                    <td>
                                                        <a class="link-success" href="edit-product-shop.aspx?ref=<%# Eval("shop_name") %>" title="Edit"><i class="fa fa-edit"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>
                                                </tr>

                                                 <%-- Edit Modal--%>


                                                <div class="modal fade" id="edit<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Edit Product Shop</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lbl_edit_row_id" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Shop Name<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_shop_name" runat="server" class="form-control" placeholder="" Text='<%# Eval("shop_name") %>'></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Product(s)<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txt_edit_product_item" runat="server" class="form-control" placeholder="" Text='<%# Eval("product_name") %>'></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                                                <asp:LinkButton ID="btnUpdate" CommandName="btnUpdate" runat="server" class="btn btn-success" Text="Save Change"></asp:LinkButton>
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


    <br />

      <script>
        $(document).ready(function () {
            $('#example1').DataTable({
               
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false


            });
        });
        $(document).ready(function () {
            $('#example2').DataTable();
        });

      </script>

</asp:Content>

