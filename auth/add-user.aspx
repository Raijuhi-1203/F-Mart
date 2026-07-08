<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="add-user.aspx.cs" Inherits="auth_add_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add User
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />


                          
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Name<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Email<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtemail" TextMode="Email" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Mobile No<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtmobileno" MaxLength="10" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Pincode<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtpincode" MaxLength="6" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                               <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Role<span style="color: red">&nbsp;*</span></label>
                                    <asp:DropDownList ID="dblrole" class="selectpicker form-control" data-live-search="true" runat="server">
                                        <asp:ListItem>Admin</asp:ListItem>
                                        <asp:ListItem>Vendor</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                           
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Password<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

