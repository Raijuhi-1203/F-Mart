<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="slider.aspx.cs" Inherits="auth_slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Slider
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />
                           
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Choose photos (500px Width X 270px Height)<span style="color: red">&nbsp;*</span></label>
                                    <asp:FileUpload ID="upldphoto" AllowMultiple="true" class="form-control" runat="server" />
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">
                                        Link
                                            <span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dbl_category" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>

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
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Manage Slider 
                        </a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">


                            <div class="col-md-12">

                                <div class="table-responsive">
                                    <table id="example2" class="table table-bordered table-striped table-class">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                 <th>Link</th>
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
                                                            <img src='<%# Eval("slider_photo") %>' style="height: 50px; width: auto" />
                                                        </td>

                                                        <td>
                                                            <asp:Label ID="lbl_slider_link" hidden runat="server" Text='<%#  Eval("slider_link") %>'></asp:Label>
                                                             <asp:Label ID="lbl_link_name" runat="server" ></asp:Label>
                                                        </td>

                                                        <td>
                                                            <a class="link-success" href="#" data-toggle="modal" data-target="#link<%#  Eval("id") %>" title="Edit"><i class="fa fa-edit"></i></a>

                                                            <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                        </td>

                                                    </tr>

                                                    
                                                    <%-- Edit Modal--%>

                                                    <div class="modal fade" id="link<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title">Update Link</h5>
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>

                                                                </div>

                                                                <div class="modal-body">
                                                                    <asp:Label ID="lbl_edit_id" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                                    <div class="row">
                                                                        <div class="col-md-12">
                                                                            <div class="form-group">
                                                                                <label for="exampleInputPassword1">
                                                                                    Link
                                            <span style="color: red">&nbsp;*</span>
                                                                                </label>
                                                                                <asp:DropDownList ID="dbl_edit_category" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                                                                </asp:DropDownList>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                    <asp:LinkButton ID="lnkupdate" CommandName="btnupdate" runat="server" class="btn btn-danger" Text="Save Change"></asp:LinkButton>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>



                                                    <%-- Delete Modal--%>

                                                    <div class="modal fade" id="Del<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title">Confirm Delete</h5>
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>

                                                                </div>

                                                                <div class="modal-body">
                                                                    <asp:Label ID="lblrowdeleteid" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <br />
                                                                            <center>
                                                                             <label style="font-size:20px;">Are you sure you want to delete?</label>
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

