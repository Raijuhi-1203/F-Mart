<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="delivery-boy-document.aspx.cs" Inherits="auth_delivery_boy_document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Delivery boy document
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Title <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txt_title" onkeypress="return isAlphaKey(event)" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Document<span style="color: red">*</span> </label>
                                    <asp:FileUpload ID="upld_document" class="form-control" runat="server" />
                                </div>
                            </div>


                        </div>

                        <div class="modal-footer">
                            <button type="button" id="btnsaveAndnext" runat="server" class="btn btn-success" onserverclick="btnsaveAndnext_ServerClick">Save</button>
                            <a id="lnk_skip" runat="server" href="" class="btn btn-danger">Skip</a>
                        </div>


                    </div>
                </div>
            </div>

            <div class="panel panel-danger">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3" style="text-decoration: none">Document
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
                                            <th>Title</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbind_document" runat="server" OnItemCommand="rptbind_document_ItemCommand">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <%# Eval("document_name") %>
                                                    </td>

                                                    <td>
                                                        <a class="link-success" target="_blank" href="<%# Eval("document_path") %>" title="View"><i class="fa fa-eye"></i></a>

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
                                                                <asp:Label ID="lbl_rowdeleteid" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

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
            Rs. ('#example2').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
            });
        });

    </script>

</asp:Content>

