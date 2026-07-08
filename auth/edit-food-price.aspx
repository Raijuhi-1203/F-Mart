<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="edit-food-price.aspx.cs" Inherits="auth_edit_product_price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script>
        function Dropdown() {
            Rs. ("#<%=this.dblgstpercentage.ClientID%>").selectpicker();
            Rs. ("#<%=this.dblgsttype.ClientID%>").selectpicker();
            Rs. ("#<%=this.dbltaxtype.ClientID%>").selectpicker();
            Rs. ("#<%=this.dblunit.ClientID%>").selectpicker();
        }
    </script>

      <asp:Label ID="lbl_category_id" hidden runat="server" Text=""></asp:Label>
      <asp:Label ID="lbl_product_id" hidden runat="server" Text=""></asp:Label>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Food Price and Unit
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                             <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Restaurant<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dbl_restaurant" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Unit<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dblunit" AppendDataBoundItems="True" class=" form-control"  runat="server">
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
                                            <label for="exampleInputPassword1">Restaurant Price<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txt_restaurant_price"  runat="server" class="form-control" Text="0" placeholder="" ></asp:TextBox>
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
                                            <label for="exampleInputPassword1">Price<span style="color: red">&nbsp;*</span> </label>
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
                                            <asp:TextBox ID="txtdisvalue" ReadOnly="true" runat="server" class="form-control" Text="0" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>



                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">GST %<span style="color: red">&nbsp;*</span> </label>
                                            <asp:DropDownList ID="dblgstpercentage" AutoPostBack="true" AppendDataBoundItems="True" class="form-control"  runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">GST Type<span style="color: red">&nbsp;*</span></label>
                                            <asp:DropDownList ID="dblgsttype" class="form-control" runat="server">
                                                <asp:ListItem>CGST+SGST</asp:ListItem>
                                                <asp:ListItem>IGST</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Tax Type<span style="color: red">&nbsp;*</span></label>
                                            <asp:DropDownList ID="dbltaxtype" AutoPostBack="true" class="form-control"  runat="server" OnSelectedIndexChanged="dbltaxtype_SelectedIndexChanged">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem>Inclusive</asp:ListItem>
                                                <asp:ListItem>Exclusive</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>




                                    <div class="col-md-2">
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

                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Save Change</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>

