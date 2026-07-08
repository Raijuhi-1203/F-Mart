<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="customer.aspx.cs" Inherits="auth_customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        .table td, .table th {
            padding: 0.3rem !important;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
            font-size: 13px !important;
        }

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

    <div class="row"></div>
    <br />
     <asp:Label ID="lbl_query" hidden runat="server" Text=""></asp:Label>
    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Customers</a>
                    </h4>
                </div>

                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Search<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_search" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <button type="submit" id="btnsearch" runat="server" style="margin-top: 30px" class="btn btn-success" onserverclick="btnsearch_ServerClick"><i class="fas fa-search"></i></button>
                                <button type="button" id="btnalldata" runat="server" style="margin-top: 30px" class="btn btn-primary" onserverclick="btnalldata_ServerClick">All Data</button>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12 mt-4">
                                <div class="body-box table-responsive">

                                    <asp:GridView ID="grd_data" AutoGenerateColumns="false" ShowHeader="true" ShowFooter="False" class="table table-bordered table-striped " runat="server" CellPadding="12" AllowPaging="True" OnPageIndexChanging="grd_data_PageIndexChanging" OnRowDataBound="grd_data_RowDataBound" PageSize="30" AllowSorting="True" PagerSettings-Position="Bottom">
                                        <Columns>

                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>

                                                    <%# Eval("customer_date")  %> <%# Eval("customer_time") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>

                                                    <%# Eval("customer_name") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Mobile no">
                                                <ItemTemplate>

                                                    <%# Eval("customer_mobileno") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>

                                                    <%# Eval("customer_email") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>

                                                    <%# Eval("customer_status") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Password">
                                                <ItemTemplate>

                                                    <asp:Label ID="lbl_customer_password" hidden runat="server" Text='<%# Eval("customer_password") %>'></asp:Label>
                                                    <asp:Label ID="lbl_password" runat="server" Text=""></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>

                                                    <a class="link-primary" href="customer-profile.aspx?ref=<%#  Eval("customer_id") %>" title="Customer Product"><i class="fa fa-eye"></i></a>
                                                    <asp:LinkButton runat="server" class="link-primary" ID="lnkStatus" title="Update Status" CommandArgument='<%# Eval("customer_id") %>' OnClick="lnkStatus_Click"><i class="fa fa-exchange-alt"></i></asp:LinkButton>

                                                    <asp:LinkButton runat="server" class="link-danger" ID="lnkdel" title="Delete" CommandArgument='<%# Eval("customer_id") %>' OnClick="lnkdel_Click"><i class="fa fa-trash-alt"></i></asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerStyle CssClass="pagination-ys" />
                                    </asp:GridView>

                                    <%-- Delete Modal--%>

                                    <div class="modal fade" id="Del" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="myModalLabel2">Confirm Delete</h5>

                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                </div>

                                                <div class="modal-body">
                                                    <asp:Label ID="lbl_delete_row_id" hidden runat="server"></asp:Label>
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <center>
                                                                <label style="font-size: 25px;">Are you sure you want to delete ?</label>
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


                                      <%-- Status Modal--%>

                                    <div class="modal fade" id="status" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="myModalLabel2">Update Status</h5>

                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                </div>

                                                <div class="modal-body">
                                                    <asp:Label ID="lbl_edit_customer_id" hidden runat="server"></asp:Label>
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label for="exampleInputPassword1">Status<span style="color: red">&nbsp;*</span> </label>
                                                            <asp:DropDownList ID="dblstatus" class="form-control" runat="server">
                                                                <asp:ListItem>Active</asp:ListItem>
                                                                <asp:ListItem>Block</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <button id="btnUpdateStatus" runat="server" class="btn btn-danger" onserverclick="btnUpdateStatus_ServerClick">Save Change</button>
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

  


</asp:Content>

