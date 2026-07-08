<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="add-product-price.aspx.cs" Inherits="auth_add_product_price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function Dropdown() {
            Rs. ("#<%=this.dblgstpercentage.ClientID%>").selectpicker();
            Rs. ("#<%=this.dblgsttype.ClientID%>").selectpicker();
            Rs. ("#<%=this.dbltaxtype.ClientID%>").selectpicker();
            Rs. ("#<%=this.dblunit.ClientID%>").selectpicker();
        }
    </script>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Product Price and Unit
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Unit<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dblunit" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Unit Value<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtunitvalue" runat="server" class="form-control" Text="" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                            <asp:UpdatePanel ID="connect" runat="server">
                                <ContentTemplate>

                                     <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">GST %<span style="color: red">&nbsp;*</span> </label>
                                            <asp:DropDownList ID="dblgstpercentage" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                     <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Shop Price<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txt_shop_price"  runat="server" class="form-control" Text="0" placeholder="" ></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Market Price<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txtmarketprice" AutoPostBack="true" runat="server" class="form-control" Text="0" placeholder="" OnTextChanged="txtmarketprice_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Your Price<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txtsellprice" AutoPostBack="true" runat="server" class="form-control" Text="0" placeholder="" OnTextChanged="txtsellprice_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Discount %<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txtdiscountpercentage" AutoPostBack="true" runat="server" class="form-control" Text="0" placeholder="" OnTextChanged="txtdiscountpercentage_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Dis. Value<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txtdisvalue" ReadOnly="true" MaxLength="5" runat="server" class="form-control" Text="0" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2" hidden>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">GST Type<span style="color: red">&nbsp;*</span></label>
                                            <asp:DropDownList ID="dblgsttype" class="form-control" runat="server">
                                                <asp:ListItem>CGST+SGST</asp:ListItem>
                                                <asp:ListItem>IGST</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-2" hidden>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Tax Type<span style="color: red">&nbsp;*</span></label>
                                            <asp:DropDownList ID="dbltaxtype" AutoPostBack="true" class="form-control"  runat="server" OnSelectedIndexChanged="dbltaxtype_SelectedIndexChanged">
                                                <asp:ListItem>Inclusive</asp:ListItem>
                                                <asp:ListItem>Exclusive</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="col-md-2" hidden>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Final Price<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txtfinalprice" ReadOnly="true" runat="server" class="form-control" Text="0" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-2" hidden>
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Shipping Charge (If Free Set Value 0)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtshippingcharge" runat="server" class="form-control" Text="0" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Stock<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtstock" runat="server" class="form-control" Text="50" placeholder=""></asp:TextBox>
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

    <div id="confirm" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Confirm</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                </div>
                <div class="modal-body">

                    <h4>Product price & stock details has been saved. Want to add another varient? Click Yes </h4>
                </div>
                <div class="modal-footer">
                     <button type="button" class="btn btn-default" data-dismiss="modal">Yes</button>

                    <button type="button" id="btnno" runat="server" class="btn btn-danger waves-effect" onserverclick="btnno_ServerClick">No</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

