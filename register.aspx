<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @media (max-width: 576px) {

            .registration-form-wrapper {
                padding: 25px 15px !important;
                margin: 0 10px;
            }

            .form-header h2 {
                font-size: 26px;
            }

            .form-header p {
                font-size: 14px;
            }

            .registration-form-wrapper .col-lg-8 {
                width: 100%;
            }

            .row.mb-3 {
                margin-left: 0;
                margin-right: 0;
            }

                .row.mb-3 > .col-md-6 {
                    width: 100%;
                    padding-left: 0;
                    padding-right: 0;
                    margin-bottom: 15px;
                }

            .form-control {
                font-size: 15px;
            }

            .form-check {
                font-size: 13px;
                line-height: 1.5;
            }

            .btn-register {
                width: 100%;
            }

            .social-buttons .btn-social {
                width: 100%;
            }
        }
    </style>

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Register</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Register</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


    <section id="register" class="register section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row justify-content-center">
                <div class="col-lg-10">
                    <div class="registration-form-wrapper">
                        <div class="form-header text-center">
                            <h2>Create Your Account</h2>
                            <p>Create your account and start shopping with us</p>
                        </div>

                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <div>
                                    <div class="form-floating mb-3">
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="fullName" name="fullName" placeholder="Full Name" required="" autocomplete="name"></asp:TextBox>
                                        <label for="fullName">Full Name</label>
                                    </div>

                                    <div class="form-floating mb-3">
                                        <asp:TextBox runat="server" type="email" class="form-control" ID="email" name="email" placeholder="Email Address" required="" autocomplete="email"></asp:TextBox>
                                        <label for="email">Email Address</label>
                                    </div>

                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <div class="form-floating">
                                                <asp:TextBox runat="server" type="password" class="form-control" ID="password" name="password" placeholder="Password" required="" minlength="8" autocomplete="new-password"></asp:TextBox>
                                                <label for="password">Password</label>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-floating">
                                                <asp:TextBox runat="server" type="password" class="form-control" ID="confirmPassword" name="confirmPassword" placeholder="Confirm Password" required="" minlength="8" autocomplete="new-password"></asp:TextBox>
                                                <label for="confirmPassword">Confirm Password</label>
                                            </div>
                                        </div>
                                    </div>



                                    <div class="form-check mb-4">
                                        <input class="form-check-input" type="checkbox" id="termsCheck" name="termsCheck" required="">
                                        <label class="form-check-label" for="termsCheck">
                                            I agree to the <a href="#">Terms of Service</a> and <a href="#">Privacy Policy</a>
                                        </label>
                                    </div>

                                    <div class="form-check mb-4">
                                        <input class="form-check-input" type="checkbox" id="marketingCheck" name="marketingCheck">
                                        <label class="form-check-label" for="marketingCheck">
                                            I would like to receive marketing communications about products, services, and promotions
                     
                                        </label>
                                    </div>

                                    <div class="d-grid mb-4">
                                        <button id="btnregister" runat="server" onserverclick="btnregister_ServerClick" type="submit" class="btn btn-register">Create Account</button>
                                    </div>

                                    <div class="login-link text-center">
                                        <p>Already have an account? <a href="login.aspx">Sign in</a></p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="social-login">
                            <div class="row">
                                <div class="col-lg-8 mx-auto">
                                    <div class="divider">
                                        <span>or sign up with</span>
                                    </div>
                                    <div class="social-buttons">
                                        <center>
                                            <a href="#" class="btn btn-social">
                                                <i class="bi bi-google"></i>
                                                <span>Google</span>
                                            </a>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="decorative-elements">
                            <div class="circle circle-1"></div>
                            <div class="circle circle-2"></div>
                            <div class="circle circle-3"></div>
                            <div class="square square-1"></div>
                            <div class="square square-2"></div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </section>
    <!-- /Register Section -->


</asp:Content>
