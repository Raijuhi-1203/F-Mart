<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="paytm-gatway.aspx.cs" Inherits="auth_paytm_gatway" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">


      <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Paytm API Keys
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Merchant Key<span style="color: red">&nbsp;*</span> </label>
                                    <asp:textbox id="txt_merchant_key" runat="server" class="form-control" placeholder=""></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">MID<span style="color: red">&nbsp;*</span> </label>
                                    <asp:textbox id="txt_mid" runat="server" class="form-control" placeholder=""></asp:textbox>
                                </div>
                            </div>


                        </div>

                          <div class="panel-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Save Change</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

