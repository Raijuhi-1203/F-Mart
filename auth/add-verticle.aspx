<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="add-verticle.aspx.cs" Inherits="auth_add_verticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <script>
        function Dropdown() {
            Rs. ("#<%=this.dblparentcategory.ClientID%>").selectpicker();
            Rs. ("#<%=this.dblsubcategory.ClientID%>").selectpicker();
            Rs. ("#<%=this.dblsubcategory.ClientID%>").selectpicker();
        }
    </script>


    <div class="alert" id="alert_container"></div>
    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">
                            Add Verticle
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <asp:UpdatePanel ID="connect" runat="server">
                                <ContentTemplate>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">
                                                Category
                                      <span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dblparentcategory" AutoPostBack="true" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dblparentcategory_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">
                                                Sub Category<span style="color: red">&nbsp;*</span>
                                            </label>
                                            <asp:DropDownList ID="dblsubcategory" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                    </div>


                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Title<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txt_title" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Verticle Name<span style="color: red">&nbsp;*</span> </label>
                                            <asp:TextBox ID="txt_verticle" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>


                                    
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Published?<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dblstatus" class="form-control" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
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

