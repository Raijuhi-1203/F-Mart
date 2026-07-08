<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="manage-product-to-section.aspx.cs" Inherits="auth_manage_product_to_section" %>

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

    <a href="add-product-to-section" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;
Add Product To Section
    </a>

    <div class="row"></div>
    <br />



    <label class="btn btn-danger"><i class="fa fa-trash"></i></label>
    <b>Delete product</b>


    <div id="accordion-container" style="margin-top: 10px">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Section's Product</a>
                    </h4>
                </div>

                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />


                            <div class="row">

                                    <div class="col-md-4 col-sm-12 col-xs-12">

                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Choose Section<span style="color: red">&nbsp;*</span> </label>
                                            <asp:DropDownList ID="dblsection" class="selectpicker form-control" AutoPostBack="true" data-live-search="true" runat="server" OnSelectedIndexChanged="dblsection_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                    <button type="button" id="btndelete" runat="server" class="btn btn-danger" style="margin-top: 22px;float:right" onserverclick="btndelete_ServerClick">Delete Selected</button>
                                     </div>

                                </div>
                            <div class="body-box table-responsive">

                                


                                <asp:GridView ID="grdproducts" AutoGenerateColumns="false" ShowHeader="true" ShowFooter="False" DataKeyNames="id" class="table table-bordered table-striped gvv" runat="server" CellPadding="15" AllowPaging="True" PageSize="15" AllowSorting="True" OnPageIndexChanging="grdproducts_PageIndexChanging"  PagerSettings-Position="Bottom" OnRowDataBound="grdproducts_RowDataBound">
                                    <Columns>

                                          <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_delete" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblproductid" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                                                    <asp:Label ID="lblproductname" Font-Bold="true" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>

                                                <asp:Label ID="lblcategoryname" Font-Bold="true" runat="server"></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>

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
                                                                             <label style="font-size:25px;">Are you sure you want to delete this order?</label>
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




                            </div>
                        </div>
                    </div>
                </div>
            </div>



        </div>
    </div>


    <script>

        Rs. (document).ready(function () {
            Rs. (".gvv").prepend(Rs. ("<thead></thead>").append(Rs. (this).find("tr:first"))).dataTable({

                //  dom: 'lBfrtip',
                //buttons: [
                //    'excel', 'pdf', 'print',
                //],

                "lengthMenu": [[10, 20, 40, 50, -1], [10, 20, 40, 50, 100, "All"]] //value:item pair
            });
        });

    </script>




</asp:Content>

