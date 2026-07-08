<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="edit-pincode-area.aspx.cs" Inherits="auth_edit_pincode_area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

     <div class="alert" id="alert_container"></div>

   
    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Edit Pincode & Area
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <asp:UpdatePanel ID="upldpin" runat="server">
                                <ContentTemplate>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">State<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dblstate" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">City<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dblcity" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                                    
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Pincode<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtpincode" MaxLength="6" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                              <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Area<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_area" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <button type="submit" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Save Change</button>
                        </div>

                    </div>
                </div>
            </div>


            </div>
        </div>
    <br />


</asp:Content>

