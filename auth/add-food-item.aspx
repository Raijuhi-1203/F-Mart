<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="add-food-item.aspx.cs" Inherits="auth_add_product" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function Dropdown() {
            Rs. ("#<%=this.dblparentcategory.ClientID%>").selectpicker();
        }
    </script>

    <asp:Label ID="lblproductidtemp" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblproductidplus" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblproductid" hidden runat="server" Text=""></asp:Label>
     <br />
    <a href="manage-food-item" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Manage Food Item</a>

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Food Item
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-5">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Item Name<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtproductname" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">
                                        Category
                                              <span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblparentcategory" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Description </label>
                                    <asp:TextBox ID="txtdescription" TextMode="MultiLine" class="textarea" runat="server"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Photos (Recommended Size Width:1000px Height: 1000px)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:FileUpload ID="uploadphoto" AllowMultiple="true" class="form-control" runat="server" />
                                </div>
                            </div>

                              <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Food Type<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dbl_food_type" class="form-control" runat="server">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Veg</asp:ListItem>
                                        <asp:ListItem>Non-Veg</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Want to publish?<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dbl_publish" class="form-control" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsaveAndnext" runat="server" class="btn btn-success" onserverclick="btnsaveAndnext_ServerClick">Save & Next</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

