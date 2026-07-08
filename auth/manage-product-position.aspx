<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="manage-product-position.aspx.cs" Inherits="auth_manage_product_position" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <script>

        function Dropdown() {
            Rs. ("#<%=this.dblparentcategory.ClientID%>").selectpicker();
             Rs. ("#<%=this.dblsubcategory.ClientID%>").selectpicker();
        }

    </script>
      
    <div id="accordion-container" style="margin-top: 10px">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Position</a>
                    </h4>
                </div>

                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />
                            <asp:UpdatePanel ID="connect" runat="server">
                                <ContentTemplate>
                                    <center>
                                    <asp:Label ID="lbl_success" Font-Bold="true" style="color:#0c8f3f;font-size:medium" runat="server" Text=""></asp:Label>
<br /><br />
                                    </center>

                                    <div class="row">


                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="exampleInputPassword1">
                                                    Parent Category
                                      <span style="color: red">&nbsp;*</span>
                                                </label>
                                                <asp:DropDownList ID="dblparentcategory" AutoPostBack="true" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dblparentcategory_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="exampleInputPassword1">
                                                    Sub Category
                                                </label>
                                                <asp:DropDownList ID="dblsubcategory" AutoPostBack="true" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dblsubcategory_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                        </div>




                                    </div>

                                    <div class="row">
                                        <br />
                                        <div class="col-md-12">


                                            <div class="table-responsive">

                                                <asp:GridView ID="grdproducts" AutoGenerateColumns="false" ShowHeader="true" ShowFooter="False" DataKeyNames="id" class="table table-bordered table-striped gvv" runat="server" CellPadding="15" OnRowDataBound="grdproducts_RowDataBound">

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Photo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblproductid" hidden runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                                                                <img id="item_photo" runat="server" src='' style="height: 80px; width: auto" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Item">
                                                            <ItemTemplate>
                                                                <%# Eval("product_full_name") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Position No">
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="txt_position_no" Width="60px" Style="border-color: #860808;" AutoPostBack="true" class="form-control" placeholder="" Text='<%# Eval("product_postion_no") %>' runat="server" OnTextChanged="txt_position_no_TextChanged"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                    <PagerStyle CssClass="pagination-ys" />
                                                </asp:GridView>






                                            </div>

                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

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

