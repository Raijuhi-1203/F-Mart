<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="seller-menu-category.aspx.cs" Inherits="auth_seller_menu_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

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


     <div class="alert" id="alert_container"></div>
      <br />
     <a href="add-seller" class="btn btn-success"><i class="fa fa-plus"></i>&nbsp;Add Resturant Seller</a>

    <div class="row"></div>
    <br />

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">
                           Choose Restaurant Menu Category
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Menu Category<span style="color: red">&nbsp;*</span></label>
                                    <div class="body-box table-responsive" style="overflow-y: auto; overflow-x: auto; height: auto">
                                        <asp:CheckBoxList ID="chk_category" runat="server" RepeatLayout="Table" CssClass="mycheckbox" RepeatDirection="Horizontal" Font-Size="Larger" RepeatColumns="3" CellSpacing="10"></asp:CheckBoxList>
                                    </div>
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

