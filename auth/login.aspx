<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="gesture_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Title -->
    <title>The F-Mart Login</title>

    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta charset="UTF-8" />
    <meta name="description" content="" />
     <meta name="robots" content="nofollow" />
    <meta name="keywords" content="" />
    <meta name="author" content="Digital Bull" />
    <meta name="theme-color" content="#3374de" />
    <link rel="shortcut icon" href="" title="Favicon" />
    <!-- Styles -->

    <link href='http://fonts.googleapis.com/css?family=Lato:100,300,400,700' rel='stylesheet' type='text/css' />
    <link href="assets/plugins/pace-master/themes/blue/pace-theme-flash.css" rel="stylesheet" />
    <link href="assets/plugins/uniform/css/uniform.default.min.css" rel="stylesheet" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href=" https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/line-icons/simple-line-icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/waves/waves.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/switchery/switchery.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/3d-bold-navigation/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/slidepushmenus/css/component.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/product-preview-slider/css/style.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <link href="assets/css/Message.css" rel="stylesheet" type="text/css" />
    <script src="assets/js/Message.js"></script>
    <!-- Theme Styles -->
    <link href="assets/css/modern.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />

    <script src="assets/plugins/3d-bold-navigation/js/modernizr.js"></script>
    
    <style>
        hr {
            border-top: 1px solid #083b3f;
        }

        .page-inner{
            background:unset !important
        }
    </style>

</head>
<body class="page-login">
    <form id="form1" runat="server">
        <main class="page-content" style="background:#058715;">
            <div class="page-inner" >
                <div id="main-wrapper" >
                    <div class="row">
                        <div class="col-md-6 center">
                             <div class="alert" id="alert_container"></div>
                            <div class="panel info-box panel-white" style="border-radius:2rem 2rem 2rem 2rem !important">
                                <div class="login-box">
                                   <br />
                                    <a href="#" target="_blank" class="logo-name text-lg text-center">The F-Mart</a>
                                    <p class="text-center m-t-md">Please login into your account.</p>
                                    <div class="m-t-md">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtemail" class="form-control" placeholder="User Id" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtpassword" TextMode="Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                        </div>
                                        <button type="submit" id="btnlogin" class="btn btn-danger btn-block" runat="server" onserverclick="btnlogin_ServerClick">Login</button>
                                        <br />
                                        <br />
                                    </div>
                                        <p class="text-center m-t-xs text-sm">Developed by <br /><b> DigitalBull</b></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Row -->
                </div>
                <!-- Main Wrapper -->
            </div>
            <!-- Page Inner -->
        </main><!-- Page Content -->


    </form>



    <script src="assets/plugins/jquery-ui/jquery-ui.min.js"></script>
    <%-- <script src="assets/plugins/pace-master/pace.min.js"></script>--%>
    <script src="assets/plugins/jquery-blockui/jquery.blockui.js"></script>

    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <%-- <script src="assets/plugins/switchery/switchery.min.js"></script>--%>
    <script src="assets/plugins/uniform/jquery.uniform.min.js"></script>
    <script src="assets/plugins/classie/classie.js"></script>
    <script src="assets/plugins/waves/waves.min.js"></script>
    <script src="assets/plugins/3d-bold-navigation/js/main.js"></script>
    <%--  <script src="assets/plugins/product-preview-slider/js/jquery.mobile.min.js"></script>
    <script src="assets/plugins/product-preview-slider/js/main.js"></script>--%>

    <script src="assets/js/modern.min.js"></script>

    <script src="assets/js/pages/profile.js"></script>
</body>
</html>
