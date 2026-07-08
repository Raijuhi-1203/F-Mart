<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="manage-food-item.aspx.cs" Inherits="auth_manage_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }
    </style>

    <div class="alert" id="alert_container"></div>

    <asp:Label ID="lblproductidtemp" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblproductidplus" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblproductid" hidden runat="server" Text=""></asp:Label>

    <br />
    <a href="add-food-item" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Add Food Item</a>

    <div class="row"></div>
    <br />



    <label class="btn btn-success"><i class="fa fa-edit"></i></label>
    <b>Edit Food Details</b>
    &nbsp;&nbsp;
    <label class="btn btn-primary"><i class="fa fa-exchange-alt"></i></label>
    <b>Change Status of Item</b>
    &nbsp;&nbsp;
  
    <label class="btn btn-danger"><i class="fa fa-trash"></i></label>
    <b>Delete Item</b>


    <div id="accordion-container" style="margin-top: 10px">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Food Item</a>
                    </h4>
                </div>

                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="row">

                                <div class="col-md-6 col-sm-12 col-xs-12">

                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Search<span style="color: red">&nbsp;*</span> </label>
                                        <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                    </div>

                                </div>

                                <div class="col-md-6 col-sm-12 col-xs-12">

                                    <button type="submit" id="btnsearch" runat="server" class="btn btn-success" style="margin-top: 22px" onserverclick="btnsearch_ServerClick">Search</button>

                                    <button type="button" id="btnalldata" runat="server" class="btn btn-primary" style="margin-top: 22px" onserverclick="btnalldata_ServerClick">All Data</button>

                                    <button type="button" id="btndelete" runat="server" class="btn btn-danger" style="margin-top: 22px; float: right" onserverclick="btndelete_ServerClick">Delete Selected</button>


                                </div>

                            </div>


                            <div class="row">
                                <br />
                                <div class="col-md-12">
                                     <div class="table-responsive">
                                    <asp:GridView ID="grdproducts" AutoGenerateColumns="false" ShowHeader="true" ShowFooter="False" DataKeyNames="id" class="table table-bordered table-striped gvv" runat="server" CellPadding="15" OnRowDataBound="grdproducts_RowDataBound" AllowPaging="True" OnPageIndexChanging="grdproducts_PageIndexChanging" PageSize="30" AllowSorting="True" PagerSettings-Position="Bottom" OnRowCreated="grdproducts_RowCreated">
                                        <Columns>

                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_delete" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblproductid" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                                                    <img id="item_photo" runat="server" src='' style="height: 50px; width: auto" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Item">
                                                <ItemTemplate>
                                                    <%# Eval("product_full_name") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Category">
                                                <ItemTemplate>

                                                    <%# Eval("product_parent_category_name") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate>

                                                    <%# Eval("food_type") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Published?">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpublishstatus" Font-Bold="true" runat="server" Text='<%# Eval("publish_status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>

                                                    <a class="link-success" href="edit-food-item.aspx?ref=<%#  Eval("product_id") %>" title="Edit"><i class="fa fa-edit"></i></a>
                                                    <asp:LinkButton runat="server" class="link-primary" ID="link" title="Publish Status" CommandArgument='<%# Eval("product_id") %>' OnClick="link_Click"><i class="fa fa-exchange-alt"></i></asp:LinkButton>
                                                    <asp:LinkButton runat="server" class="link-danger" ID="lnkdel" title="Delete" CommandArgument='<%# Eval("product_id") %>' OnClick="lnkdel_Click"><i class="fa fa-trash"></i></asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerStyle CssClass="pagination-ys" />
                                    </asp:GridView>
                                    <asp:Label ID="msg" runat="server" Text=""></asp:Label>

                                    <%-- Delete Modal--%>

                                    <div class="modal fade" id="Del" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                </div>

                                                <div class="panel-body">

                                                    <asp:Label ID="lbldeleteproductid" hidden runat="server"></asp:Label>
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <center>
                                                                <label style="font-size: 25px;">Are you sure you want to delete this item?</label>
                                                            </center>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                                                    <button id="lnkdelete" runat="server" class="btn btn-danger" onserverclick="lnkdelete_ServerClick">Yes</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <%-- Change Status Modal--%>

                                    <div class="modal fade" id="Status" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="myModalLabel2">Change Status</h4>
                                                </div>

                                                <div class="panel-body">

                                                    <asp:Label ID="lblrowproductid" hidden runat="server"></asp:Label>
                                                    <asp:Label ID="lblstatusvalue" hidden runat="server"></asp:Label>

                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label for="exampleInputPassword1">Published?<span style="color: red">&nbsp;*</span> </label>
                                                            <asp:DropDownList ID="dblavailableforsale" class="form-control" runat="server">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <asp:Button ID="btnchangestatus" class="btn btn-danger" runat="server" Text="Save" OnClick="btnchangestatus_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                         </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </div>



        </div>
    </div>


    <script>

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>


</asp:Content>

