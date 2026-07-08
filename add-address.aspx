<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add-address.aspx.cs" Inherits="add_address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Address</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Address</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Contact 2 Section -->
    <section id="contact-2" class="contact-2 section">

      <!-- Contact Form Section (Overlapping) -->
      <div class="container">
        <div class="row justify-content-center" data-aos="fade-up" data-aos-delay="300">
          <div class="col-lg-10">
            <div class="contact-form-wrapper">
              <h2 class="text-center mb-4">Add Address</h2>

              <div class="php-email-form">
                <div class="row g-3">
                  <div class="col-md-6">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-person"></i>
                        <asp:TextBox runat="server" ID="name" type="text" class="form-control" name="name" placeholder="First Name" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>

                  <div class="col-md-6">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-envelope"></i>
                        <asp:TextBox runat="server" ID="email" type="email" class="form-control" name="email" placeholder="Email Address" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>

                  <div class="col-md-12">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-text-left"></i>
                        <asp:TextBox runat="server" ID="phone" type="text" class="form-control" name="subject" placeholder="Mobile No." required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>

                  <div class="col-12">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-chat-dots message-icon"></i>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="address1" class="form-control" name="address" placeholder="Address Line 1" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>
                    

                  <div class="col-12">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-chat-dots message-icon"></i>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="address2" class="form-control" name="address" placeholder="Address Line 2" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>
                    
                  <div class="col-md-6">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-text-left"></i>
                        <asp:TextBox runat="server" ID="state" type="text" class="form-control" name="subject" placeholder="State Name" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>

                    
                  <div class="col-md-6">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-text-left"></i>
                        <asp:TextBox runat="server" ID="city" type="text" class="form-control" name="subject" placeholder="City Name" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>

                    
                  <div class="col-md-6">
                    <div class="form-group">
                      <div class="input-with-icon">
                        <i class="bi bi-text-left"></i>
                        <asp:TextBox runat="server" ID="pincode" type="text" class="form-control" name="subject" placeholder="Pincode" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>


                  <div class="col-12 text-center">
                    <button type="submit" id="btnsend" runat="server" class="btn btn-primary btn-submit" onserverclick="btnsend_ServerClick">Submit</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </section><!-- /Contact 2 Section -->


</asp:Content>

