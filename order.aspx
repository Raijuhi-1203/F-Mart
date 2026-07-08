<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">My Order</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">My Order</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


    <section id="account" class="account section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <!-- Mobile Menu Toggle -->
            <div class="mobile-menu d-lg-none mb-4">
                <button class="mobile-menu-toggle" type="button" data-bs-toggle="collapse" data-bs-target="#profileMenu">
                    <i class="bi bi-grid"></i>
                    <span>Menu</span>
                </button>
            </div>

            <div class="row g-4">

                <!-- Content Area -->
                <div class="col-lg-12">
                    <div class="content-area">
                        <div class="tab-content">

                            <div class="tab-pane fade show active" id="orders">

                                <div class="orders-grid">

                                    <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand" OnItemDataBound="rptbinddata_ItemDataBound">
                                        <ItemTemplate>

                                            <div class="order-card" data-aos="fade-up" data-aos-delay="100">
                                                <div class="order-header">
                                                    <div class="order-id">
                                                        <a href='print-bill.aspx?ref=<%# Eval("order_id") %>' target="_blank"><i class="bi bi-printer"></i></a>
                                                        <span class="label">Order ID:</span>
                                                        <asp:Label class="value" id="order_id" runat="server" Text='<%# Eval("order_id") %>'></asp:Label>
                                                    </div>
                                                    <div class="order-date"><%# Eval("order_date") %></div>
                                                    
                                                </div>
                                                <div class="order-content">
                                                    <%-- <div class="product-grid">
                                                        <img src="assets/img/product/product-1.jpg" alt="Product" loading="lazy">
                                                        <img src="assets/img/product/product-2.jpg" alt="Product" loading="lazy">
                                                        <img src="assets/img/product/product-3.jpg" alt="Product" loading="lazy">
                                                    </div>--%>
                                                    <div class="order-info">
                                                        <div class="info-row">
                                                            <span>Status</span>
                                                            <span class="status processing"><%# Eval("order_status") %></span>
                                                        </div>
                                                        <div class="info-row">
                                                            <span>Items</span>
                                                            <span><%# Eval("total_item") %> items</span>
                                                        </div>
                                                        <div class="info-row">
                                                            <span>Total</span>
                                                            <span class="price">Rs. <%# Eval("total_order_amount") %></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="order-footer">
                                                    <button type="button" class="btn-track" data-bs-toggle="collapse" data-bs-target="#tracking1" aria-expanded="false">Track Order</button>
                                                    <button type="button" class="btn-details" data-bs-toggle="collapse" data-bs-target="#details1" aria-expanded="false">View Details</button>
                                                </div>--%>

                                                <div class="row">

                                                    <div class="col-md-6">
                                                        <!-- Order Tracking -->
                                                        <div class="tracking-info" id="tracking1">
                                                            <div class="tracking-timeline">
                                                                <div class="timeline-item completed">
                                                                    <div class="timeline-icon">
                                                                        <i id="processing" runat="server" class="bi bi-check-circle-fill"></i>
                                                                    </div>
                                                                    <div class="timeline-content">
                                                                        <h5>Processing</h5>
                                                                        <p>Your order is being prepared for shipment</p>
                                                                        <%--<span class="timeline-date">Feb 20, 2025 - 10:30 AM</span>--%>
                                                                    </div>
                                                                </div>

                                                                <div class="timeline-item completed">
                                                                    <div class="timeline-icon">
                                                                        <i id="confirm" runat="server" class="bi bi-box-seam"></i>
                                                                    </div>
                                                                    <div class="timeline-content">
                                                                        <h5>Confirm</h5>
                                                                        <p>Your order has been received and confirmed</p>
                                                                        <%--<span class="timeline-date">Feb 20, 2025 - 2:45 PM</span>--%>
                                                                    </div>
                                                                </div>

                                                                <div class="timeline-item active">
                                                                    <div class="timeline-icon">
                                                                        <i id="dispatch" runat="server" class="bi bi-truck"></i>
                                                                    </div>
                                                                    <div class="timeline-content">
                                                                        <h5>Dispatched</h5>
                                                                        <p>Your items are being packaged for dispatching</p>
                                                                        <%--<span class="timeline-date">Feb 20, 2025 - 4:15 PM</span>--%>
                                                                    </div>
                                                                </div>

                                                                <div class="timeline-item">
                                                                    <div class="timeline-icon">
                                                                        <i id="deliver" runat="server" class="bi bi-house-door"></i>
                                                                    </div>
                                                                    <div class="timeline-content">
                                                                        <h5>Delivered</h5>
                                                                        <p>Expected to ship within 24 hours</p>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">
                                                        <!-- Order Details -->
                                                        <div class="order-details" id="details1">
                                                            <div class="details-content">


                                                                <div class="detail-section">
                                                                    <h5>Items (<%# Eval("total_item") %>)</h5>
                                                                    <div class="order-items">


                                                                        <asp:Repeater ID="ChildRepeater" runat="server">
                                                                            <ItemTemplate>

                                                                                <div class="item">
                                                                                    <img src='auth/<%# Eval("product_photo") %>' alt="Product" loading="lazy">
                                                                                    <div class="item-info">
                                                                                        <h6><%# Eval("product_name") %></h6>
                                                                                        <div class="item-meta">
                                                                                            
                                                                                            <span class="qty">Qty: <%# Eval("product_qty") %></span>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="item-price">Rs. <%# Eval("product_market_price") %></div>
                                                                                </div>

                                                                            </ItemTemplate>
                                                                        </asp:Repeater>


                                                                    </div>
                                                                </div>



                                                                <div class="detail-section">
                                                                    <h5>Shipping Address</h5>
                                                                    <div class="address-info">
                                                                        <p>
                                                                            <%# Eval("billing_address_line1") %>, 
                                                                            <%# Eval("billing_address_line2") %>, 
                                                                            <%# Eval("billing_city_name") %>, 
                                                                            <%# Eval("billing_state_name") %>-
                                                                            <%# Eval("billing_pincode") %>
                                                                        </p>
                                                                        <p class="contact">Contact Details : <%# Eval("customer_mobileno") %></p>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>


                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <asp:Panel ID="NoDataPanel" runat="server" Visible="false">
                                        <p>Your order history is empty! 🛒 Start shopping now to fill it up.</p>
                                    </asp:Panel>

                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>

    </section>

</asp:Content>
