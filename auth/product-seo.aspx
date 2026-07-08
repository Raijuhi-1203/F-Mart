<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="product-seo.aspx.cs" Inherits="auth_product_seo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <br />
    <a href="manage-product" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Manage Product</a>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Product SEO
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Meta title<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_meta_title" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Meta Description<span style="color: red">&nbsp;*</span> </label>
                                     <asp:TextBox ID="txt_meta_description" TextMode="MultiLine"  runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Meta Keyword<span style="color: red">&nbsp;*</span> </label>
                                     <asp:TextBox ID="txt_meta_keyword" TextMode="MultiLine" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                        </div>

                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Save & Next</button>
                            <button type="button" id="btnskip" runat="server" class="btn btn-danger" onserverclick="btnskip_ServerClick">Skip for now</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>

