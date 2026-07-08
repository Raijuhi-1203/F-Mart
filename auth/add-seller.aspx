<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="add-seller.aspx.cs" Inherits="auth_add_seller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <asp:Label ID="lbl_id" hidden runat="server" Text=""></asp:Label>

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
                          
                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Name <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtname" onkeypress="return isAlphaKey(event)" class="form-control" runat="server"></asp:TextBox>
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

                        </div>
                    </div>
                </div>
            </div>


            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Firm Details
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


                                        <div class="col-md-4 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-email-2">Firm Name <span style="color: red">&nbsp;*</span></label>
                                                <asp:TextBox ID="txt_firm_name" onkeypress="return isAlphaKey(event)" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-3 col-sm-12 col-xs-12">
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
                                                <asp:DropDownList ID="dbl_area"  AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                         <div class="col-md-2 col-sm-12 col-xs-12">
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

                                          <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">Document No </label>
                                                <asp:TextBox ID="txt_identitty_no" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">Scan Copy(Identity proof) </label>
                                                <asp:FileUpload ID="upld_scan_copy" class="form-control" runat="server" />
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

                                         <div class="col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">Shop Photo (Width:690px Height:490px)</label>
                                                <asp:FileUpload ID="upld_shop_photo" class="form-control" runat="server" />
                                            </div>
                                        </div>


                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>

                           <div class="modal-footer">
                            <button type="button" id="btnsaveAndnext" runat="server" class="btn btn-success" onserverclick="btnsaveAndnext_ServerClick">Submit & Save</button>
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

