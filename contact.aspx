<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Contact</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Contact</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Contact 2 Section -->
    <section id="contact-2" class="contact-2 section">

      <div class="container" data-aos="fade-up" data-aos-delay="100">

        <!-- Contact Info Boxes -->
        <div class="row gy-4 mb-5">
          <div class="col-lg-4" data-aos="fade-up" data-aos-delay="100">
            <div class="contact-info-box">
              <div class="icon-box">
                <i class="bi bi-geo-alt"></i>
              </div>
              <div class="info-content">
                <h4>Our Address</h4>
                <p>Bank Rd, VindyaVasini Nagar, Gorakhpur, Uttar Pradesh 273001</p>
              </div>
            </div>
          </div>

          <div class="col-lg-4" data-aos="fade-up" data-aos-delay="200">
            <div class="contact-info-box">
              <div class="icon-box">
                <i class="bi bi-phone"></i>
              </div>
              <div class="info-content">
                <h4>Contact Number</h4>
                <p>+91-92355 01383</p>
                
              </div>
            </div>
          </div>

          <div class="col-lg-4" data-aos="fade-up" data-aos-delay="300">
            <div class="contact-info-box">
              <div class="icon-box">
                <i class="bi bi-headset"></i>
              </div>
              <div class="info-content">
                <h4>Hours of Operation</h4>
                <p>Monday - Saturday: 9 AM - 7 PM</p>
                <p>Sunday: 9 AM - 4 PM</p>
              </div>
            </div>
          </div>
        </div>

      </div>

      <!-- Google Maps (Full Width) -->
      <div class="map-section" data-aos="fade-up" data-aos-delay="200">
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3562.8104565498725!2d83.36526507408757!3d26.750424067048524!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3991446f840dcc13%3A0x90d1d4276643dac9!2sFurniture%20Mart!5e0!3m2!1sen!2sin!4v1757156744629!5m2!1sen!2sin" width="100%" height="500" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
      </div>

      <!-- Contact Form Section (Overlapping) -->
      <div class="container form-container-overlap">
        <div class="row justify-content-center" data-aos="fade-up" data-aos-delay="300">
          <div class="col-lg-10">
            <div class="contact-form-wrapper">
              <h2 class="text-center mb-4">Get in Touch</h2>

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
                        <asp:TextBox runat="server" ID="message" class="form-control" name="message" placeholder="Write Message..." style="height: 180px" required=""></asp:TextBox>
                      </div>
                    </div>
                  </div>
                    

                  <div class="col-12 text-center">
                    <button type="submit" id="btnsend" runat="server" class="btn btn-primary btn-submit" onserverclick="btnsend_ServerClick">SEND MESSAGE</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </section><!-- /Contact 2 Section -->


</asp:Content>

