<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Cart</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Cart</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Cart Section -->
    <section id="cart" class="cart section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row">
                <div class="col-lg-8" data-aos="fade-up" data-aos-delay="200">
                    <div class="cart-items">

                        <div class="cart-header d-none d-lg-block">
                            <div class="row align-items-center">
                                <div class="col-lg-6">
                                    <h5>Product</h5>
                                </div>
                                <div class="col-lg-2 text-center">
                                    <h5>Price (₹)</h5>
                                </div>
                                <div class="col-lg-2 text-center">
                                    <h5>Quantity</h5>
                                </div>
                                <div class="col-lg-2 text-center">
                                    <h5>Total (₹)</h5>
                                </div>
                            </div>
                        </div>

                        <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                            <itemtemplate>

                                <!-- Cart Item 1 -->
                                <div class="cart-item">
                                    <div class="row align-items-center">
                                        <div class="col-lg-6 col-12 mt-3 mt-lg-0 mb-lg-0 mb-3">
                                            <div class="product-info d-flex align-items-center">
                                                <div class="product-image">
                                                    <img src='auth/<%# Eval("photo_path") %>' alt="Product" class="img-fluid" loading="lazy">
                                                </div>
                                                <div class="product-details">
                                                    <h6 class="product-title"><%# Eval("product_full_name") %></h6>
                                                    
                                                    <asp:Button class="remove-item" CommandName="Remove" CommandArgument='<%# Eval("product_id") %>' type="button" id="btnremove" runat="server" Text="Remove">
                                                       
                                                    </asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-12 mt-3 mt-lg-0 text-center">
                                            <div class="price-tag">
                                                <asp:Label id="mrp" runat="server" class="current-price"><%# Eval("product_market_price") %></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-12 mt-3 mt-lg-0 text-center">
                                            <div class="quantity-selector">
                                                <asp:Button class="quantity-btn decrease" CommandName="Minus" CommandArgument='<%# Eval("product_id") %>' ID="btnminus" runat="server" Text="-"></asp:Button>
                                                <asp:TextBox runat="server" type="number" class="quantity-input" value='<%# Eval("cart_qty") %>' ID="changeqty"></asp:TextBox>
                                                <asp:Button class="quantity-btn increase" CommandName="Add" CommandArgument='<%# Eval("product_id") %>' ID="btnadd" runat="server" Text="+"></asp:Button>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-12 mt-3 mt-lg-0 text-center">
                                            <div class="item-total">
                                                <asp:Label id="total" runat="server"><%# Eval("total") %></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Cart Item -->


                            </itemtemplate>
                        </asp:Repeater>


                        <div class="cart-actions">
                            <div class="row">
                                <%--<div class="col-lg-6 mb-3 mb-lg-0">
                                    <div class="coupon-form">
                                        <div class="input-group">
                                            <input type="text" class="form-control" placeholder="Coupon code">
                                            <button class="btn btn-outline-accent" type="button">Apply Coupon</button>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-lg-6 text-md-end">
                                    <button class="btn btn-outline-heading me-2" id="btnupdatecart" runat="server" onserverclick="btnupdatecart_ServerClick">
                                        <i class="bi bi-arrow-clockwise"></i>Update Cart
                                    </button>
                                    <button class="btn btn-outline-remove" id="btnclearcart" runat="server" onserverclick="btnclearcart_ServerClick">
                                        <i class="bi bi-trash"></i>Clear Cart
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 mt-4 mt-lg-0" data-aos="fade-up" data-aos-delay="300">
                    <div class="cart-summary">
                        <h4 class="summary-title">Order Summary</h4>

                        <div class="summary-item">
                            <span class="summary-label">Subtotal</span>
                            <span class="summary-value" id="subtotal" runat="server">Rs. 269.96</span>
                        </div>

                        <div class="summary-item shipping-item">
                            <span class="summary-label">Shipping</span>
                            <div class="shipping-options">
                                <div class="form-check text-end">
                                    <input class="form-check-input" type="radio" name="shipping" id="standard" checked="">
                                    <label class="form-check-label" for="standard">
                                        Standard Delivery - Rs. 100.00
                                    </label>
                                </div>
                               <%-- <div class="form-check text-end">
                                    <input class="form-check-input" type="radio" name="shipping" id="express">
                                    <label class="form-check-label" for="express">
                                        Express Delivery - Rs. 12.99
                                    </label>
                                </div>
                                <div class="form-check text-end">
                                    <input class="form-check-input" type="radio" name="shipping" id="free">
                                    <label class="form-check-label" for="free">
                                        Free Shipping (Orders over Rs. 300)
                                    </label>
                                </div>--%>
                            </div>
                        </div>

                       <%-- <div class="summary-item">
                            <span class="summary-label">Tax</span>
                            <span class="summary-value">Rs. 27.00</span>
                        </div>

                        <div class="summary-item discount">
                            <span class="summary-label">Discount</span>
                            <span class="summary-value">-Rs. 0.00</span>
                        </div>--%>

                        <div class="summary-total">
                            <span class="summary-label">Total</span>
                            <span class="summary-value" id="totalamt" runat="server">Rs. 301.95</span>
                        </div>

                        <div class="checkout-button">
                            <a href="checkout.aspx" class="btn btn-accent w-100">Proceed to Checkout <i class="bi bi-arrow-right"></i>
                            </a>
                        </div>

                        <div class="continue-shopping">
                            <a href="index.aspx" class="btn btn-link w-100">
                                <i class="bi bi-arrow-left"></i>Continue Shopping
                            </a>
                        </div>

                        <div class="payment-methods">
                            <p class="payment-title">We Accept</p>
                            <div class="payment-icons">
                                <i class="bi bi-credit-card"></i>
                                <i class="bi bi-paypal"></i>
                                <i class="bi bi-wallet2"></i>
                                <i class="bi bi-bank"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </section>
    <!-- /Cart Section -->

</asp:Content>

