<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="change-password.aspx.cs" Inherits="changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

      <div class="alert" id="alert_container"></div>

      <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-danger">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Change Password
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />
                          
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Current Password<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtcurrentpassword" TextMode="Password" runat="server" class="form-control " placeholder="**********"></asp:TextBox>
                                </div>
                            </div>

                         
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">New Password<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password" class="form-control" placeholder="**********"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <br />
                                    <button type="submit" id="btnsave" class="btn btn-danger btn-addon m-b-sm  btn-lg pull-right" runat="server" onserverclick="btnsave_ServerClick">Submit & Change</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

