<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Checkout</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Checkout</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Checkout Section -->
    <section id="checkout" class="checkout section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row">

                <div class="col-lg-7">
                    <!-- Checkout Form -->
                    <div class="checkout-container" data-aos="fade-up">
                        <div class="checkout-form">
                            <!-- Customer Information -->
                            <div class="checkout-section" id="customer-info">
                                <div class="section-header">
                                    <div class="section-number">1</div>
                                    <h3>Customer Information</h3>
                                </div>
                                <div class="section-content">
                                    <div class="row">
                                        <div class="col-md-6 form-group">
                                            <label for="firstname">First Name</label>
                                            <asp:TextBox runat="server" type="text" name="firstname" class="form-control" ID="firstname" placeholder="Your First Name" required=""></asp:TextBox>
                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label for="lastname">Last Name</label>
                                            <asp:TextBox runat="server" type="text" name="lastname" class="form-control" ID="lastname" placeholder="Your Last Name" required=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="email">Email Address</label>
                                        <asp:TextBox runat="server" type="email" class="form-control" name="email" ID="email" placeholder="Your Email" required=""></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="phone">Phone Number</label>
                                        <asp:TextBox runat="server" type="tel" class="form-control" name="phone" ID="phone" placeholder="Your Phone Number" required=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <!-- Shipping Address -->
                            <div class="checkout-section" id="shipping-address">
                                <div class="section-header">
                                    <div class="section-number">2</div>
                                    <h3>Shipping Address</h3>
                                </div>
                                <div class="section-content">
                                    <div class="form-group">
                                        <label for="address">Street Address</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" name="address" ID="address" placeholder="Street Address" required=""></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="apartment">Apartment, Suite, etc. (optional)</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" name="apartment" ID="apartment" placeholder="Apartment, Suite, Unit, etc."></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 form-group">
                                            <label for="city">City</label>
                                            <asp:TextBox runat="server" type="text" name="city" class="form-control" ID="city" placeholder="City" required=""></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="state">State</label>
                                            <asp:TextBox runat="server" type="text" name="state" class="form-control" ID="state" placeholder="State" required=""></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="zip">Pin Code</label>
                                            <asp:TextBox runat="server" type="text" name="zip" class="form-control" ID="pincode" placeholder="Pin Code" required=""></asp:TextBox>
                                        </div>
                                    </div>


                                </div>
                            </div>
                            
                            <!-- Order Review -->
                            <div class="checkout-section" id="order-review">
                                <div class="section-header">
                                    <div class="section-number">3</div>
                                    <h3>Review &amp; Place Order</h3>
                                </div>
                                <div class="section-content">
                                    <div class="form-check terms-check">
                                        <input class="form-check-input" type="checkbox" id="terms" name="terms" required="">
                                        <label class="form-check-label" for="terms">
                                            I agree to the <a href="#" data-bs-toggle="modal" data-bs-target="#termsModal">Terms and Conditions</a> and <a href="#" data-bs-toggle="modal" data-bs-target="#privacyModal">Privacy Policy</a>
                                        </label>
                                    </div>
                                    <div class="success-message d-none">Your order has been placed successfully! Thank you for your purchase.</div>
                                    <div class="place-order-container">
                                        <button type="submit" class="btn btn-primary place-order-btn" id="btnorder" runat="server" onserverclick="btnorder_ServerClick">
                                            <span class="btn-text">Place Order</span>
                                            <span class="btn-price" runat="server" id="placeorder">Rs. 240.96</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-5">
                    <!-- Order Summary -->
                    <div class="order-summary" data-aos="fade-left" data-aos-delay="200">
                        <div class="order-summary-header">
                            <h3>Order Summary</h3>
                            <span class="item-count" runat="server" id="item_count">2 Items</span>
                        </div>

                        <div class="order-summary-content">
                            <div class="order-items">

                                <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                                    <ItemTemplate>

                                        <div class="order-item">
                                            <div class="order-item-image">
                                                <asp:Label runat="server" ID="product_id" Text='<%# Eval("product_id") %>' hidden></asp:Label>
                                                <asp:Label runat="server" ID="price_id" Text='<%# Eval("product_price_id") %>' hidden></asp:Label>
                                                <img src='auth/<%# Eval("photo_path") %>' alt="Product" class="img-fluid">
                                            </div>
                                            <div class="order-item-details">
                                                <h4><%# Eval("product_full_name") %></h4>
                                                <%--<p class="order-item-variant">Color: Black | Size: M</p>--%>
                                                <div class="order-item-price">
                                                    <span class="quantity"><%# Eval("cart_qty") %> x </span>
                                                    <span class="price">Rs. <%# Eval("product_market_price") %></span>
                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <%--<div class="promo-code">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Promo Code" aria-label="Promo Code">
                    <button class="btn btn-outline-primary" type="button">Apply</button>
                  </div>
                </div>--%>

                            <div class="order-totals">
                                <div class="order-subtotal d-flex justify-content-between">
                                    <span>Subtotal</span>
                                    <span runat="server" id="subtotal">Rs. 209.97</span>
                                </div>
                                <div class="order-shipping d-flex justify-content-between">
                                    <span>Shipping</span>
                                    <span>Rs. 100.00</span>
                                </div>
                                <%-- <div class="order-tax d-flex justify-content-between">
                    <span>Tax</span>
                    <span>$21.00</span>
                  </div>--%>
                                <div class="order-total d-flex justify-content-between">
                                    <span>Total</span>
                                    <span runat="server" id="totalamt">Rs. 240.96</span>
                                </div>
                            </div>

                            <%-- <div class="secure-checkout">
                  <div class="secure-checkout-header">
                    <i class="bi bi-shield-lock"></i>
                    <span>Secure Checkout</span>
                  </div>
                  <div class="payment-icons">
                    <i class="bi bi-credit-card-2-front"></i>
                    <i class="bi bi-credit-card"></i>
                    <i class="bi bi-paypal"></i>
                    <i class="bi bi-apple"></i>
                  </div>
                </div>--%>
                        </div>
                    </div>
                </div>
            </div>

            

        </div>

    </section>
    <!-- /Checkout Section -->


</asp:Content>
