<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="minimum-order.aspx.cs" Inherits="auth_shipping_charge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Minimum Order Amount 
                        </a>
                    </h4>
                </div>


                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Amount (In Rs.)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_minimum_order_amount" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                            <button type="button" id="btnupdate" runat="server" class="btn btn-success" onserverclick="btnupdate_ServerClick">Save Change</button>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>


</asp:Content>

