<%@ Page Title="" Language="C#" MasterPageFile="~/auth/admin.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="auth_add_about" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

  
    <script src="https://cdn.ckeditor.com/4.6.2/standard/ckeditor.js"></script>
    <script>
        CKEDITOR.replace('editor1');
    </script>


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">About
                        </a>
                    </h4>
                </div>


                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">About<span style="color: red">&nbsp;*</span> </label>
                                    <CKEditor:CKEditorControl ID="txtabout" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                            <button type="button" id="btnupdate" runat="server" class="btn btn-success" onserverclick="btnupdate_ServerClick">Submit & Update</button>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>




</asp:Content>

