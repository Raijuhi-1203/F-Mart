<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="order-confirmation.aspx.cs" Inherits="order_confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<!-- Page Title -->
    <div class="page-title light-background">
      <div class="container d-lg-flex justify-content-between align-items-center">
        <h1 class="mb-2 mb-lg-0">Order Confirmation</h1>
        <nav class="breadcrumbs">
          <ol>
            <li><a href="index.aspx">Home</a></li>
            <li class="current">Order Confirmation</li>
          </ol>
        </nav>
      </div>
    </div><!-- End Page Title -->

    <!-- Order Confirmation Section -->
    <section id="order-confirmation" class="order-confirmation section">

      <div class="container" data-aos="fade-up" data-aos-delay="100">

        <div class="order-confirmation-3">
          <div class="row g-0">
            <!-- Left sidebar with order summary -->
            <div class="col-lg-4 sidebar" data-aos="fade-right">
              <div class="sidebar-content">
                <!-- Success animation -->
                <div class="success-animation">
                  <i class="bi bi-check-lg"></i>
                </div>

                <!-- Order number and date -->
                <div class="order-id">
                  <h4 id="order_id" runat="server">Order #ORD-935721</h4>
                  <div class="order-date" id="order_date" runat="server">March 2, 2025</div>
                </div>

                <!-- Order progress stepper -->
                <div class="order-progress">
                  <div class="stepper-container">
                    <div class="stepper-item completed">
                      <div class="stepper-icon">1</div>
                      <div class="stepper-text">Confirmed</div>
                    </div>
                    <div class="stepper-item current">
                      <div class="stepper-icon">2</div>
                      <div class="stepper-text">Processing</div>
                    </div>
                    <div class="stepper-item">
                      <div class="stepper-icon">3</div>
                      <div class="stepper-text">Shipped</div>
                    </div>
                    <div class="stepper-item">
                      <div class="stepper-icon">4</div>
                      <div class="stepper-text">Delivered</div>
                    </div>
                  </div>
                </div>

                <!-- Price summary -->
                <div class="price-summary">
                  <h5>Order Summary</h5>
                  <ul class="summary-list">
                    <li>
                      <span>Subtotal</span>
                      <span id="subtotal" runat="server">$219.97</span>
                    </li>
                    <li>
                      <span>Shipping</span>
                      <span>Rs. 100.0</span>
                    </li>
                   
                    <li class="total">
                      <span>Total</span>
                      <span id="totalamt" runat="server">$238.67</span>
                    </li>
                  </ul>
                </div>

                

                <!-- Customer service -->
                <div class="customer-service">
                  <h5>Need Help?</h5>
                  <a href="contact.aspx" class="help-link">
                    <i class="bi bi-chat-dots"></i>
                    <span>Contact Support</span>
                  </a>
                  <a href="faq.aspx" class="help-link">
                    <i class="bi bi-question-circle"></i>
                    <span>FAQs</span>
                  </a>
                </div>
              </div>
            </div>

            <!-- Main content area -->
            <div class="col-lg-8 main-content" data-aos="fade-in">
              <!-- Thank you message -->
              <div class="thank-you-message">
                <h1>Thanks for your order!</h1>
                <p>We've received your order and will begin processing it right away.
                  We'll send you updates via email as your order progresses.</p>
              </div>

              <!-- Shipping details -->
              <div class="details-card" data-aos="fade-up">
                <div class="card-header" data-toggle="collapse">
                  <h3>
                    <i class="bi bi-geo-alt"></i>
                    Shipping Details
                  </h3>
                  <i class="bi bi-chevron-down toggle-icon"></i>
                </div>
                <div class="card-body">
                  <div class="row g-4">
                    <div class="col-md-6">
                      <div class="detail-group">
                        <label>Ship To</label>
                        <address id="add" runat="server">
                          
                        </address>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="detail-group">
                        <label>Contact</label>
                        <div class="contact-info">
                          <p id="email" runat="server"> michael.t@example.com</p>
                          <p id="phone" runat="server"> (206) 555-1234</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

             
              <!-- Order items -->
              <div class="details-card" data-aos="fade-up" "="">
            <div class=" card-header" data-toggle="collapse">
                <h3>
                  <i class="bi bi-bag-check"></i>
                  Order Items
                </h3>
                <i class="bi bi-chevron-down toggle-icon"></i>
              </div>
              <div class="card-body">

                   <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
     <itemtemplate>

                <div class="item">
                  <div class="item-image">
                    <img src='auth/<%# Eval("product_photo") %>' alt="Product" loading="lazy">
                  </div>
                  <div class="item-details">
                    <h4><%# Eval("product_name") %></h4>
                    <%--<div class="item-meta">
                      <span>Color: Navy Blue</span>
                    </div>--%>
                    <div class="item-price">
                      <span class="quantity"><%# Eval("product_qty") %> ×</span>
                      <span class="price">Rs. <%# Eval("product_market_price") %></span>
                    </div>
                  </div>
                </div>

         </itemtemplate>
                       </asp:Repeater>
                
              </div>
            </div>

            <!-- Action buttons -->
            <div class="action-area" data-aos="fade-up">
              <div class="row g-3">
                <div class="col-md-6">
                  <a href="index.aspx" class="btn btn-back">
                    <i class="bi bi-arrow-left"></i>
                    Return to Shop
                  </a>
                </div>
                <div class="col-md-6">
                  <a href="order.aspx" class="btn btn-account">
                    <span>View in Account</span>
                    <i class="bi bi-arrow-right"></i>
                  </a>
                </div>
              </div>
            </div>

            
          </div>
        </div>
      </div>

      </div>

    </section><!-- /Order Confirmation Section -->


    </asp:Content>