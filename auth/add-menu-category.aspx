<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="add-menu-category.aspx.cs" Inherits="auth_add_menu_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

    
    <asp:Label ID="lblcategoryidtemp" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblcategoryidplus" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblcategoryid" hidden runat="server" Text=""></asp:Label>
     <br />
    <a href="manage-menu-category" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Manage Restaurent Category</a>
   
    <br />
    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Restaurent Category
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                           <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Title<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_title" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Category Name<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txt_category_name" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="col-md-6" >
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Photo (Recommended Size Width:300px Height:300px)<span style="color: red">&nbsp;*</span> </label>
                                    <asp:FileUpload ID="uploadphoto" class="form-control" runat="server" />
                                </div>
                            </div>


                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Published?<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dblstatus" class="form-control" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>



                                    <asp:Label ID="lbl_error" ForeColor="Red" runat="server" Text=""></asp:Label>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Position No </label>
                                            <asp:TextBox ID="txt_position_no" AutoPostBack="true" runat="server" class="form-control" placeholder="" OnTextChanged="txt_position_no_TextChanged"></asp:TextBox>
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

