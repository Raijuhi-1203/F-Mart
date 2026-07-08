<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="add-product-to-section.aspx.cs" Inherits="auth_add_product_to_section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .mycheckbox input[type="checkbox"] {
            margin-right: 5px;
            font-size: 15px;
        }

        .mycheckbox input {
            /*margin-bottom: 12px;*/
            margin-top: 5px;
            margin-left: 10px !important;
            font-size: 15px;
        }

        .mycheckbox label {
            margin-left: 5px !important;
            font-size: 15px;
        }

        td {
            padding-right: 30px;
            padding-top: 10px
        }
    </style>

    <script>

        function Dropdown() {
            Rs. ("#<%=this.dblparentcategory.ClientID%>").selectpicker();
            Rs. ("#<%=this.dblsection.ClientID%>").selectpicker();
        }

    </script>


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Product To Section
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <asp:UpdatePanel ID="connect" runat="server">
                                <ContentTemplate>

                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">
                                               Choose Section
                                            <span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dblsection" AutoPostBack="true"  class="selectpicker form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dblsection_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>



                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">
                                                Choose Product Category
                                            <span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dblparentcategory" AutoPostBack="true" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dblparentcategory_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>


                                    <div class="col-md-12" id="deal_div" runat="server">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">deal date<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txt_deal_date" TextMode="Date" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Select Product<span style="color: red">&nbsp;*</span> </label>
                                            <div class="body-box table-responsive" style="overflow-y: auto; overflow-x: auto; height: auto">
                                                <asp:CheckBoxList ID="chkproduct" runat="server" RepeatLayout="Table" CssClass="mycheckbox" RepeatDirection="Horizontal" Font-Size="Larger" RepeatColumns="3" CellSpacing="10"></asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                        </div>

                    </div>
                </div>
            </div>


        </div>
    </div>





</asp:Content>

