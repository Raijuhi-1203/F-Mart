<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="manage-sub-category.aspx.cs" Inherits="auth_manage_sub_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

    
    <asp:Label ID="lblcategoryidtemp" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblcategoryidplus" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblcategoryid" hidden runat="server" Text=""></asp:Label>

       <div class="alert" id="alert_container"></div>
   
    <div class="row"></div>
    <br />


    <label class="btn btn-info"><i class="fa fa-eye"></i></label>
    <b>View Sub Category of Category</b>
    &nbsp;&nbsp;
    <label class="btn btn-success"><i class="fa fa-edit"></i></label>
    <b>Edit Category for update category details</b>
    &nbsp;&nbsp;
    <label class="btn btn-primary"><i class="fa fa-check"></i></label>
    <b>Enable Category if you want to display on website</b>
    &nbsp;&nbsp;<br />
    <br />
    <label class="btn btn-primary"><i class="fa fa-ban"></i></label>
    <b>Disable Category if you don't want to display on website</b>
    &nbsp;&nbsp;
    <label class="btn btn-danger"><i class="fa fa-trash"></i></label>
    <b>Delete Category</b>




    <div id="accordion-container" style="margin-top: 10px">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Category</a>
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
                                            <th>Category</th>
                                            <th>Published?</th>
                                            <th hidden>Point</th>
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
                                                        <%# Eval("category_name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("category_status") %>
                                                    </td>

                                                    <td hidden>
                                                        <asp:UpdatePanel ID="upld_point" runat="server">
                                                            <ContentTemplate>

                                                                <asp:Label ID="lbl_category_id" hidden runat="server" Text='<%# Eval("category_id") %>'></asp:Label>
                                                                <asp:TextBox ID="txt_point" AutoPostBack="true" runat="server" Text='<%# Eval("super_point") %>' style="width: 50px;text-align: center;" OnTextChanged="txt_point_TextChanged"></asp:TextBox>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>

                                                    <td>
                                                         <a class="link-danger" href="sub-category-product.aspx?ref=<%# Eval("category_id") %>" target="_blank" title="Product"><i class="fa fa-eye"></i></a>
                                                        <a class="link-success" href="edit-category.aspx?ref=<%#  Eval("category_id") %>" target="_blank" title="Edit"><i class="fa fa-edit"></i></a>
                                                        <a class="link-primary" href="#" data-toggle="modal" data-target="#Enable<%#  Eval("category_id") %>" title="Enable"><i class="fa fa-check"></i></a>
                                                        <a class="link-primary" href="#" data-toggle="modal" data-target="#disable<%#  Eval("category_id") %>" title="Disable"><i class="fa fa-ban"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("category_id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>

                                                </tr>


                                                <%-- Enable Modal--%>

                                                <div class="modal fade" id="Enable<%# Eval("category_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lblrowenableid" hidden runat="server" Text='<%# Eval("category_id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <center>
                                                                             <label style="font-size:25px;">Are you sure you want to enable?</label>
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

                                                <div class="modal fade" id="disable<%# Eval("category_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lbldisablerowid" hidden runat="server" Text='<%# Eval("category_id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <center>
                                                                             <label style="font-size:25px;">Are you sure you want to disable?</label>
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

                                                <div class="modal fade" id="Del<%# Eval("category_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">

                                                                <asp:Label ID="lbldeletecategoryid" hidden runat="server" Text='<%# Eval("category_id") %>'></asp:Label>

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






                                                    <%-- Add Sub Category Modal--%>

                                                <div class="modal fade" id="AddCategory<%# Eval("category_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Add Sub Category</h4>
                                                            </div>

                                                            <div class="panel-body">

                                                                <asp:Label ID="lblmainsubcategoryid" hidden runat="server" Text='<%# Eval("category_id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <label for="exampleInputPassword1">Category Name<span style="color: red">&nbsp;*</span> </label>
                                                                        <asp:TextBox ID="txttitle" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                                                                <asp:LinkButton ID="LinkButton3" CommandName="btnaddmainsubcategory" runat="server" class="btn btn-danger" Text="Save"></asp:LinkButton>
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

