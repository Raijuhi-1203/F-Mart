<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="edit-food-item.aspx.cs" Inherits="auth_edit_product" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>

        function Dropdown() {
            Rs. ("#<%=this.dblparentcategory.ClientID%>").selectpicker();
        }

    </script>

      <br />
    <a href="manage-food-item" class="btn btn-primary" runat="server"><i class="fa fa-plus"></i>&nbsp;Manage Food item</a>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Edit Product Information
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                             <div class="col-md-5">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Item Name<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtproductname" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                           
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">
                                        Category
                                              <span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblparentcategory" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Description </label>
                                    <asp:TextBox ID="txtdescription" TextMode="MultiLine" class="textarea" runat="server"></asp:TextBox>
                                </div>
                            </div>
                         
                              <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Food Type<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dbl_food_type" class="form-control" runat="server">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Veg</asp:ListItem>
                                        <asp:ListItem>Non-Veg</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Want to publish?<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dbl_publish" class="form-control" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnupdateinformation" runat="server" class="btn btn-success" onserverclick="btnupdateinformation_ServerClick">Save Changes</button>
                        </div>

                    </div>
                </div>
            </div>

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Price Information</a>
                    </h4>
                </div>

                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />


                            <a id="add_price_btn" href="" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Add Price</a>

                            <div class="row"></div>
                            <br />


                            <div class="body-box table-responsive">
                                <table id="example1" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>Restaurant</th>
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

                                        <asp:Repeater ID="rptbinddataprice" runat="server" OnItemCommand="rptbinddataprice_ItemCommand">
                                            <ItemTemplate>

                                                <tr>

                                                     <td>
                                                        <%# Eval("price_seller_name") %>
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


            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3" style="text-decoration: none">Update Photos
                        </a>
                    </h4>
                </div>
                <div id="collapse3" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="body-box table-responsive">
                                <table id="example2" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbindphotos" runat="server" OnItemCommand="rptbindphotos_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <img src='<%# Eval("photo_path") %>' style="height: 80px; width: auto" />
                                                    </td>

                                                    <td>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Delphoto<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>

                                                </tr>

                                                <%-- Delete Modal--%>

                                                <div class="modal fade" id="Delphoto<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lblphotorowdeleteid" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

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

                            <div class="row"></div>
                            <br />

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Photos (Recommended Size Width:1000px Height: 1000px)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:FileUpload ID="uploadphoto" AllowMultiple="true" class="form-control" runat="server" />
                                </div>
                            </div>

                        </div>

                        <div class="modal-footer">
                            <button type="button" id="btnupdatephotos" runat="server" class="btn btn-success" onserverclick="btnupdatephotos_ServerClick">Save & Update</button>
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
            });
        });


        Rs. (document).ready(function () {
            Rs. ('#example2').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
            });
        });

        Rs. (document).ready(function () {
            Rs. ('#example3').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
            });
        });

    </script>


</asp:Content>

