<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Login</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Login</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


    <!-- Login Section -->
    <section id="login" class="login section">

      <div class="container" data-aos="fade-up" data-aos-delay="100">

        <div class="row justify-content-center">
          <div class="col-lg-8 col-md-10">
            <div class="auth-container" data-aos="fade-in" data-aos-delay="200">

              <!-- Login Form -->
              <div class="auth-form login-form active">
                <div class="form-header">
                  <h3>Welcome Back</h3>
                  <p>Sign in to your account</p>
                </div>

                <div class="auth-form-content">
                  <div class="input-group mb-3">
                    <span class="input-icon">
                      <i class="bi bi-envelope"></i>
                    </span>
                    <asp:TextBox ID="email" runat="server" type="email" class="form-control" placeholder="Email address" required="" autocomplete="email"></asp:TextBox>
                  </div>

                  <div class="input-group mb-3">
                    <span class="input-icon">
                      <i class="bi bi-lock"></i>
                    </span>
                    <asp:TextBox ID="password" runat="server" type="password" class="form-control" placeholder="Password" required="" autocomplete="current-password"></asp:TextBox>
                    <span class="password-toggle">
                      <i class="bi bi-eye"></i>
                    </span>
                  </div>

                  <%--<div class="form-options mb-4">
                    <div class="remember-me">
                      <input type="checkbox" id="rememberLogin">
                      <label for="rememberLogin">Remember me</label>
                    </div>
                    <a href="#" class="forgot-password">Forgot password?</a>
                  </div>--%>

                  <button type="submit" id="btnlogin" runat="server" onserverclick="btnlogin_ServerClick" class="auth-btn primary-btn mb-3">
                    Sign In
                    <i class="bi bi-arrow-right"></i>
                  </button>

                  <div class="divider">
                    <span>or</span>
                  </div>

                  <button type="button" class="auth-btn social-btn">
                    <i class="bi bi-google"></i>
                    Continue with Google
                  </button>

                  <div class="switch-form">
                    <span>Don't have an account?</span>
                    <button type="button" class="switch-btn" data-target="register" id="btnregister" runat="server" onserverclick="btnregister_ServerClick">Create account</button>
                  </div>
                </div>
              </div>

             

            </div>
          </div>
        </div>

      </div>

    </section><!-- /Login Section -->

    </asp:Content>