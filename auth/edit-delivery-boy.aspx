<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="edit-delivery-boy.aspx.cs" Inherits="auth_edit_delivery_boy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .error {
            color: red
        }
    </style>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Basic Details
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Name <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txt_name" onkeypress="return isAlphaKey(event)" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Mobile No <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txt_mobileno" TextMode="Phone" MaxLength="10" onkeypress="return isNumberKey(event)" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Email </label>
                                    <asp:TextBox ID="txt_email" TextMode="Email" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revEmail" Display="Dynamic"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w{2,4}([-.]\w{2,4})*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w{2,4}([-.]\w{2,4})*)*" CssClass="error" ControlToValidate="txt_email"
                                        runat="server"
                                        ErrorMessage="Invalid Email."></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-2 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Gender <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="dbl_gender" class="form-control" runat="server">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-2 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Status <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="dbl_status" class="form-control" runat="server">
                                        <asp:ListItem>Active</asp:ListItem>
                                        <asp:ListItem>Deactive</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Address Details
                        </a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="row">

                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">Address<span style="color: red">&nbsp;*</span></label>
                                                <asp:TextBox ID="txt_address_line_1" TextMode="MultiLine" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-4 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">
                                                    State<span style="color: red">&nbsp;*</span>
                                                </label>
                                                <asp:DropDownList ID="dbl_state" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dbl_state_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-4 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">
                                                    City<span style="color: red">&nbsp;*</span>
                                                </label>
                                                <asp:DropDownList ID="dbl_city" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>


                                        <div class="col-md-4 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">Pincode <span style="color: red">&nbsp;*</span> </label>
                                                <asp:TextBox ID="txt_pincode" MaxLength="6" onkeypress="return isNumberKey(event)" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>

                        <div class="modal-footer">
                            <button type="button" id="btnbasicupdate" runat="server" class="btn btn-success" onserverclick="btnbasicupdate_ServerClick">Save Change</button>
                        </div>

                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3" style="text-decoration: none">Update Photo
                        </a>
                    </h4>
                </div>
                <div id="collapse3" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Photo </label>
                                    <asp:FileUpload ID="upld_photo" class="form-control" runat="server" />
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-12 col-xs-12">

                                <img id="delivery_boy_photo" runat="server" style="height:120px; width:120px;border-radius:50%" />

                           </div>


                        </div>

                        <div class="modal-footer">
                            <button type="button" id="btnupdatephoto" runat="server" class="btn btn-success" onserverclick="btnupdatephoto_ServerClick">Save Change</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse4" style="text-decoration: none">Document List
                        </a>
                    </h4>
                </div>
                <div id="collapse4" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12 col-sm-12 col-xs-12">

                                <a href="delivery-boy-document.aspx?ref=<%= Request.QueryString[0] %>&type=edit" target="_blank" class="btn btn-success"><i class="fa fa-plus"></i>&nbsp;Add Document</a>
                                <br /><br />
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="body-box table-responsive">
                                    <table class="table table-bordered table-striped data-table-resp">
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
    </div>

     <script>

         Rs. (document).ready(function () {
             Rs. ('.data-table-resp').DataTable({
                 dom: 'lBfrtip',
                 buttons: [
                     'excel', 'pdf', 'print',
                 ],
                 "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
             });


            
         });

    </script>

    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>


</asp:Content>

