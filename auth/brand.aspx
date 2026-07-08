<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="brand.aspx.cs" Inherits="auth_brand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Brand
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="row">

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Brand<span style="color: red">&nbsp;*</span> </label>
                                        <asp:TextBox ID="txt_brand" runat="server" class="form-control" placeholder=""></asp:TextBox>
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
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Brand List
                        </a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">

                                    <div class="body-box">
                                        <table id="example1" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Brand</th>
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
                                                                <%# Eval("brand_name") %>
                                                            </td>

                                                            <td>
                                                                <a class="btn btn-success" href="#" data-toggle="modal" data-target="#edit<%#  Eval("id") %>" title="Edit"><i class="fa fa-edit"></i></a>
                                                                <a class="btn btn-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                            </td>
                                                        </tr>

                                                        <%-- Edit Modal--%>


                                                        <div class="modal fade" id="edit<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                            <div class="modal-dialog">
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                        <h5 class="modal-title" id="myModalLabel2">Edit Brand</h5>

                                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                    </div>

                                                                    <div class="modal-body">
                                                                        <asp:Label ID="lbl_edit_row_id" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="form-group">
                                                                                    <label for="exampleInputPassword1">Brand<span style="color: red">&nbsp;*</span> </label>
                                                                                    <asp:TextBox ID="txt_edit_brand" runat="server" class="form-control" Text='<%# Eval("brand_name") %>'></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="modal-footer">
                                                                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                                                        <asp:LinkButton ID="LinkButton1" CommandName="btneditbrand" runat="server" class="btn btn-success" Text="Save Change"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>



                                                        <%-- Delete Modal--%>


                                                        <div class="modal fade" id="Del<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                            <div class="modal-dialog">
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                        <h5 class="modal-title" id="myModalLabel2">Confirm Delete</h5>

                                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                    </div>

                                                                    <div class="modal-body">
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


        </div>
    </div>



    <br />
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

