<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="edit-seller.aspx.cs" Inherits="seller_edit_seller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="alert" id="alert_container"></div>
    <br />
    <a href="seller-menu-category.aspx?ref=<%=Request.QueryString[0] %>" class="btn btn-success"><i class="fa fa-plus"></i>&nbsp;Your Menu Category</a>

    <div class="row"></div>
    <br />
    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Edit basic details
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
                                    <asp:TextBox ID="txtname" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Mobile No <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtmobileno" TextMode="Phone" MaxLength="10" onkeypress="return isNumberKey(event)" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Email </label>
                                    <asp:TextBox ID="txt_email" TextMode="Email" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revEmail" Display="Dynamic"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w{2,4}([-.]\w{2,4})*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w{2,4}([-.]\w{2,4})*)*" CssClass="error" ControlToValidate="txt_email"
                                        runat="server"
                                        ErrorMessage="Invalid Email."></asp:RegularExpressionValidator>

                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Firm Name <span style="color: red">&nbsp;*</span></label>
                                    <asp:TextBox ID="txt_firm_name" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        GST State <span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dbl_gst_state" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">GST No </label>
                                    <asp:TextBox ID="txt_gst" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Address<span style="color: red">&nbsp;*</span></label>
                                    <asp:TextBox ID="txt_address_line_1" TextMode="MultiLine" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label for="singin-password-2">
                                                State<span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dbl_state" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dbl_state_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label for="singin-password-2">
                                                City<span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dbl_city" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dbl_city_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label for="singin-password-2">
                                                Pincode<span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dbl_pincode" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dbl_pincode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label for="singin-password-2">
                                                Area<span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dbl_area" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="col-md-2 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label for="singin-password-2">Opening Time <span style="color: red">&nbsp;*</span></label>
                                            <asp:TextBox ID="txt_opening_time" TextMode="Time" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label for="singin-password-2">Closing Time <span style="color: red">&nbsp;*</span></label>
                                            <asp:TextBox ID="txt_closing_time" TextMode="Time" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                        <div class="panel-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Save Change</button>
                        </div>

                    </div>
                </div>
            </div>


            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Document
                        </a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Document Option 
                                    </label>
                                    <asp:DropDownList ID="dbl_options" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>GST No</asp:ListItem>
                                        <asp:ListItem>Trade license</asp:ListItem>
                                        <asp:ListItem>Aadhar Card</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Document No </label>
                                    <asp:TextBox ID="txt_identitty_no" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Scan Copy(Identity proof) </label>
                                    <asp:FileUpload ID="upld_scan_copy" class="form-control" runat="server" />
                                </div>
                            </div>


                            <div class="col-md-12" style="margin-top: 20px">

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
                                                            <%#  Eval("document_name") %>
                                                        </td>

                                                        <td>
                                                            <a class="btn btn-success" href="<%#  Eval("document_path") %>" title="View"><i class="fa fa-eye"></i></a>

                                                            <a class="btn btn-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
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

                        <div class="panel-footer">
                            <button type="button" id="btnsavedocument" runat="server" class="btn btn-success" onserverclick="btnsavedocument_ServerClick">Save Change</button>
                        </div>


                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3" style="text-decoration: none">Shop Photo
                        </a>
                    </h4>
                </div>
                <div id="collapse3" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">

                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Photo (Width:690px Height:490px)</label>
                                    <asp:FileUpload ID="upld_photo" class="form-control" runat="server" />
                                </div>
                            </div>


                        </div>

                        <div class="panel-footer">
                            <button type="button" id="btn_upload_photo" runat="server" class="btn btn-success" onserverclick="btn_upload_photo_ServerClick">Save Change</button>
                        </div>

                    </div>
                </div>
            </div>



        </div>
    </div>


    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>

</asp:Content>

