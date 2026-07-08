<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="google-analytics.aspx.cs" Inherits="auth_google_analytics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

      <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">
                            Google Analytics
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Paste Google Analytics Scrupt<span style="color: red">&nbsp;*</span> </label>
                                     <asp:textbox id="txt_tracking_code" TextMode="MultiLine" runat="server" class="form-control" placeholder=""></asp:textbox>
                                </div>
                            </div>

                        </div>

                          <div class="panel-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Install</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

