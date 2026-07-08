<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="add-delivery-boy.aspx.cs" Inherits="auth_add_delivery_boy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        .error {
            color: red
        }
    </style>

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

                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Password <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txt_password" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">Photo </label>
                                    <asp:FileUpload ID="upld_photo" class="form-control" runat="server" />
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
                            <button type="button" id="btnsaveAndnext" runat="server" class="btn btn-success" onserverclick="btnsaveAndnext_ServerClick">Save & Next</button>
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

