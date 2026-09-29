<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account.aspx.cs" Inherits="account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- F-Mart Customer Account Dashboard Stylesheet (Clean Myntra-Inspired Theme) -->
    <link href="assets/css/account.css" rel="stylesheet" />

    <div class="fm-account-page">
        <div class="container py-2">

            <!-- Breadcrumbs -->
            <nav aria-label="breadcrumb" class="my-2">
                <ol class="breadcrumb mb-0" style="font-size: 0.8rem;">
                    <li class="breadcrumb-item"><a href="index.aspx" class="text-muted"><i class="bi bi-house me-1"></i>Home</a></li>
                    <li class="breadcrumb-item active text-dark fw-semibold" aria-current="page">My Account</li>
                </ol>
            </nav>

            <!-- Top Profile Header Card (Myntra-Inspired Clean Light Theme) -->
            <div class="fm-profile-header-card">
                <div class="fm-header-user-row">
                    <div class="fm-user-identity">
                        <div class="fm-avatar-circle">
                            <i class="bi bi-person-fill"></i>
                        </div>
                        <div class="fm-user-meta">
                            <div class="fm-welcome-label">F-Mart Customer</div>
                            <!-- Dynamic username from backend -->
                            <h4 id="username" runat="server" class="fm-user-name">Khushi Digitalbull</h4>
                            <span class="fm-verified-badge"><i class="bi bi-patch-check-fill"></i> Verified Customer</span>
                        </div>
                    </div>

                    <a href="#settings" class="fm-edit-profile-btn" onclick="fmGoToTab('settings'); return false;">
                        <i class="bi bi-pencil-square"></i>
                        <span class="d-none d-sm-inline">Edit Profile</span>
                    </a>
                </div>

                <!-- 4 Quick Action Tiles (Myntra App Style) -->
                <div class="fm-quick-tiles-grid">
                    <!-- Orders Tile -->
                    <a href="#orders" class="fm-tile-btn" onclick="fmGoToTab('orders'); return false;">
                        <span class="fm-tile-count" id="ordercount" runat="server">0</span>
                        <i class="bi bi-box-seam fm-tile-icon orders"></i>
                        <span class="fm-tile-label">Orders</span>
                    </a>

                    <!-- Wishlist Tile -->
                    <a href="#wishlist" class="fm-tile-btn" onclick="fmGoToTab('wishlist'); return false;">
                        <span class="fm-tile-count" id="wishlistcount" runat="server">0</span>
                        <i class="bi bi-heart fm-tile-icon wishlist"></i>
                        <span class="fm-tile-label">Wishlist</span>
                    </a>

                    <!-- Addresses Tile -->
                    <a href="#addresses" class="fm-tile-btn" onclick="fmGoToTab('addresses'); return false;">
                        <i class="bi bi-geo-alt fm-tile-icon address"></i>
                        <span class="fm-tile-label">Addresses</span>
                    </a>

                    <!-- Settings Tile -->
                    <a href="#settings" class="fm-tile-btn" onclick="fmGoToTab('settings'); return false;">
                        <i class="bi bi-gear fm-tile-icon settings"></i>
                        <span class="fm-tile-label">Settings</span>
                    </a>
                </div>
            </div>
            <!-- /Profile Header Card -->

            <!-- Mobile Horizontal Tab Pills Bar (Myntra/Flipkart Style) -->
            <div class="fm-nav-scroll-wrap" id="fmMobileTabBar">
                <a href="#profile" class="fm-tab-pill active" onclick="fmGoToTab('profile'); return false;">
                    <i class="bi bi-person"></i> Overview
                </a>
                <a href="#orders" class="fm-tab-pill" onclick="fmGoToTab('orders'); return false;">
                    <i class="bi bi-box-seam"></i> My Orders
                </a>
                <a href="#wishlist" class="fm-tab-pill" onclick="fmGoToTab('wishlist'); return false;">
                    <i class="bi bi-heart"></i> Wishlist
                </a>
                <a href="#addresses" class="fm-tab-pill" onclick="fmGoToTab('addresses'); return false;">
                    <i class="bi bi-geo-alt"></i> Addresses
                </a>
                <a href="#settings" class="fm-tab-pill" onclick="fmGoToTab('settings'); return false;">
                    <i class="bi bi-gear"></i> Settings
                </a>
            </div>

            <!-- Main Layout: Desktop Sidebar + Content Area -->
            <div class="row g-3">

                <!-- Left Sidebar (Visible on Desktop) -->
                <div class="col-lg-3 d-none d-lg-block">
                    <div class="fm-desktop-sidebar">
                        <nav class="fm-desktop-nav">
                            <a href="#profile" class="nav-link active" onclick="fmGoToTab('profile'); return false;">
                                <i class="bi bi-person-circle"></i>
                                <span>Overview</span>
                            </a>
                            <a href="#orders" class="nav-link" onclick="fmGoToTab('orders'); return false;">
                                <i class="bi bi-box-seam"></i>
                                <span>My Orders</span>
                            </a>
                            <a href="#wishlist" class="nav-link" onclick="fmGoToTab('wishlist'); return false;">
                                <i class="bi bi-heart"></i>
                                <span>My Wishlist</span>
                            </a>
                            <a href="#addresses" class="nav-link" onclick="fmGoToTab('addresses'); return false;">
                                <i class="bi bi-geo-alt"></i>
                                <span>Saved Addresses</span>
                            </a>
                            <a href="#settings" class="nav-link" onclick="fmGoToTab('settings'); return false;">
                                <i class="bi bi-gear"></i>
                                <span>Account Settings</span>
                            </a>

                            <div class="fm-sidebar-divider"></div>

                            <a href="contact.aspx" class="fm-desktop-footer-link">
                                <i class="bi bi-question-circle"></i>
                                <span>Help &amp; Support</span>
                            </a>
                            <a href="logout.aspx" class="fm-desktop-footer-link logout">
                                <i class="bi bi-box-arrow-right"></i>
                                <span>Log Out</span>
                            </a>
                        </nav>
                    </div>
                </div>

                <!-- Right / Main Content Area -->
                <div class="col-lg-9 col-12">
                    <div class="tab-content" id="accountTabContent">

                        <!-- ==========================================
                             Tab 1: Overview - Myntra Grouped Menu List
                             ========================================== -->
                        <div class="tab-pane fade show active" id="profile" role="tabpanel">

                            <!-- Group 1: Orders & Purchases -->
                            <div class="fm-menu-group">
                                <div class="fm-menu-group-title">Orders &amp; Shopping</div>
                                <div class="fm-menu-list">
                                    <a href="#orders" class="fm-menu-row" onclick="fmGoToTab('orders'); return false;">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box orders">
                                                <i class="bi bi-box-seam"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading">My Orders</div>
                                                <div class="fm-menu-sub">Track current orders, view past purchases &amp; invoices</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>
                                </div>
                            </div>

                            <!-- Group 2: Collections & Saved -->
                            <div class="fm-menu-group">
                                <div class="fm-menu-group-title">Collections &amp; Saved</div>
                                <div class="fm-menu-list">
                                    <a href="#wishlist" class="fm-menu-row" onclick="fmGoToTab('wishlist'); return false;">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box wishlist">
                                                <i class="bi bi-heart"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading">My Wishlist</div>
                                                <div class="fm-menu-sub">Your favorite furniture items saved for later</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>

                                    <a href="#addresses" class="fm-menu-row" onclick="fmGoToTab('addresses'); return false;">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box address">
                                                <i class="bi bi-geo-alt"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading">Saved Addresses</div>
                                                <div class="fm-menu-sub">Manage home, office and delivery locations</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>
                                </div>
                            </div>

                            <!-- Group 3: Account & Security -->
                            <div class="fm-menu-group">
                                <div class="fm-menu-group-title">Account &amp; Security</div>
                                <div class="fm-menu-list">
                                    <a href="#settings" class="fm-menu-row" onclick="fmGoToTab('settings'); return false;">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box profile">
                                                <i class="bi bi-person"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading">Profile Information</div>
                                                <div class="fm-menu-sub">Update full name, email address and mobile number</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>

                                    <a href="#settings" class="fm-menu-row" onclick="fmGoToTab('settings'); return false;">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box security">
                                                <i class="bi bi-shield-lock"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading">Password &amp; Security</div>
                                                <div class="fm-menu-sub">Change account password and credentials</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>
                                </div>
                            </div>

                            <!-- Group 4: Support & Logout -->
                            <div class="fm-menu-group">
                                <div class="fm-menu-group-title">Help &amp; Legal</div>
                                <div class="fm-menu-list">
                                    <a href="contact.aspx" class="fm-menu-row">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box help">
                                                <i class="bi bi-question-circle"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading">Help Center &amp; Contact Us</div>
                                                <div class="fm-menu-sub">Customer care, returns, shipping inquiries</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>

                                    <a href="tos.aspx" class="fm-menu-row">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box terms">
                                                <i class="bi bi-file-earmark-text"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading">Terms &amp; Policies</div>
                                                <div class="fm-menu-sub">Privacy policy, terms of service and warranties</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>

                                    <a href="logout.aspx" class="fm-menu-row">
                                        <div class="fm-menu-left">
                                            <div class="fm-menu-icon-box logout">
                                                <i class="bi bi-box-arrow-right"></i>
                                            </div>
                                            <div class="fm-menu-text-wrap">
                                                <div class="fm-menu-heading text-danger">Log Out</div>
                                                <div class="fm-menu-sub">Sign out from this device safely</div>
                                            </div>
                                        </div>
                                        <div class="fm-menu-right">
                                            <i class="bi bi-chevron-right"></i>
                                        </div>
                                    </a>
                                </div>
                            </div>

                        </div>
                        <!-- /Tab 1: Overview -->

                        <!-- ==========================================
                             Tab 2: My Orders (Clean Ecommerce Design)
                             ========================================== -->
                        <div class="tab-pane fade" id="orders" role="tabpanel">

                            <div class="fm-content-card">
                                <div class="fm-card-heading-bar">
                                    <h3><i class="bi bi-box-seam text-primary"></i> My Orders</h3>
                                    <a href="index.aspx" class="fm-btn-sm-outline">
                                        <i class="bi bi-shop"></i> Browse Catalog
                                    </a>
                                </div>

                                <div class="orders-list">

                                    <asp:Repeater ID="rptbinddata" runat="server"
                                        OnItemCommand="rptbinddata_ItemCommand"
                                        OnItemDataBound="rptbinddata_ItemDataBound">
                                        <ItemTemplate>

                                            <div class="fm-order-card">
                                                <div class="fm-order-top">
                                                    <span class="fm-order-id-label">Order #<%# Eval("order_id") %></span>
                                                    <span class="fm-order-date-text"><i class="bi bi-calendar3 me-1"></i><%# Eval("order_date") %></span>
                                                </div>

                                                <div class="fm-order-main-info">
                                                    <div class="fm-order-price-box">
                                                        <span class="amount">Rs. <%# Eval("total_order_amount") %></span>
                                                        <span class="items-count"><%# Eval("total_item") %> Items Purchased</span>
                                                    </div>
                                                    <span class="fm-status-pill">
                                                        <i class="bi bi-clock-history"></i> <%# Eval("order_status") %>
                                                    </span>
                                                </div>

                                                <!-- Compact 4-Step Order Progress Line -->
                                                <div class="fm-order-mini-stepper">
                                                    <ul class="fm-stepper-track">
                                                        <li class="fm-step-node completed">
                                                            <div class="fm-node-dot"><i class="bi bi-check-lg"></i></div>
                                                            <span class="fm-node-text">Placed</span>
                                                        </li>
                                                        <li class='fm-step-node <%# Convert.ToString(Eval("order_status")).ToLower().Contains("process") || Convert.ToString(Eval("order_status")).ToLower().Contains("ship") || Convert.ToString(Eval("order_status")).ToLower().Contains("deliver") ? "completed" : "active" %>'>
                                                            <div class="fm-node-dot"><i class="bi bi-gear-fill"></i></div>
                                                            <span class="fm-node-text">Processing</span>
                                                        </li>
                                                        <li class='fm-step-node <%# Convert.ToString(Eval("order_status")).ToLower().Contains("ship") || Convert.ToString(Eval("order_status")).ToLower().Contains("deliver") ? "completed" : "" %>'>
                                                            <div class="fm-node-dot"><i class="bi bi-truck"></i></div>
                                                            <span class="fm-node-text">Shipped</span>
                                                        </li>
                                                        <li class='fm-step-node <%# Convert.ToString(Eval("order_status")).ToLower().Contains("deliver") ? "completed" : "" %>'>
                                                            <div class="fm-node-dot"><i class="bi bi-check-circle-fill"></i></div>
                                                            <span class="fm-node-text">Delivered</span>
                                                        </li>
                                                    </ul>
                                                </div>

                                                <div class="fm-order-actions-row">
                                                    <a href="order.aspx" class="fm-btn-sm-outline">
                                                        <i class="bi bi-eye"></i> Details
                                                    </a>
                                                    <a href="order.aspx" class="fm-btn-sm-primary">
                                                        <i class="bi bi-geo-alt"></i> Track Order
                                                    </a>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <!-- Clean Empty Orders State using existing NoDataPanel -->
                                    <asp:Panel ID="NoDataPanel" runat="server" Visible="false">
                                        <div class="fm-empty-box">
                                            <div class="fm-empty-icon">
                                                <i class="bi bi-box-seam"></i>
                                            </div>
                                            <h4 class="fm-empty-title">No Orders Placed Yet</h4>
                                            <p class="fm-empty-sub">Explore our furniture collections and place your first order.</p>
                                            <a href="index.aspx" class="fm-btn-submit">
                                                <i class="bi bi-shop me-1"></i> Start Shopping
                                            </a>
                                        </div>
                                    </asp:Panel>

                                </div>
                            </div>

                        </div>
                        <!-- /Tab 2: My Orders -->

                        <!-- ==========================================
                             Tab 3: Wishlist (2-Col Mobile Grid)
                             ========================================== -->
                        <div class="tab-pane fade" id="wishlist" role="tabpanel">

                            <div class="fm-content-card">
                                <div class="fm-card-heading-bar">
                                    <h3><i class="bi bi-heart text-danger"></i> My Wishlist</h3>
                                    <a href="serach-product.aspx" class="fm-btn-sm-outline">
                                        <i class="bi bi-search"></i> Discover More
                                    </a>
                                </div>

                                <div class="fm-wish-grid">

                                    <asp:Repeater ID="Repeater1" runat="server"
                                        OnItemCommand="Repeater1_ItemCommand"
                                        OnItemDataBound="Repeater1_ItemDataBound">
                                        <ItemTemplate>

                                            <div class="fm-wish-card">
                                                <div class="fm-wish-img-box">
                                                    <a href='product-details.aspx?ref=<%# Eval("product_id") %>'>
                                                        <img src='auth/<%# Eval("photo_path") %>'
                                                             alt='<%# Eval("product_full_name") %>'
                                                             loading="lazy"
                                                             onerror="this.onerror=null; this.src='assets/img/logo.png';" />
                                                    </a>
                                                    <a href="wishlist.aspx" class="fm-wish-del-icon" title="Remove" aria-label="Remove item">
                                                        <i class="bi bi-trash"></i>
                                                    </a>
                                                </div>

                                                <div class="fm-wish-details">
                                                    <h5 class="fm-wish-name">
                                                        <a href='product-details.aspx?ref=<%# Eval("product_id") %>' title='<%# Eval("product_full_name") %>'>
                                                            <%# Eval("product_full_name") %>
                                                        </a>
                                                    </h5>

                                                    <div class="fm-wish-prices">
                                                        <span class="fm-wish-current">Rs. <%# Eval("product_market_price") %></span>
                                                        <span class="fm-wish-old">Rs. <%# Eval("product_sell_price") %></span>
                                                    </div>

                                                    <a href='product-details.aspx?ref=<%# Eval("product_id") %>' class="fm-wish-add-btn">
                                                        <i class="bi bi-cart3"></i> Add to Cart
                                                    </a>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>

                                </div>

                                <!-- Clean Empty Wishlist State using existing Panel1 -->
                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <div class="fm-empty-box">
                                        <div class="fm-empty-icon" style="background: #fee2e2; color: #e11d48;">
                                            <i class="bi bi-heart"></i>
                                        </div>
                                        <h4 class="fm-empty-title">Your Wishlist is Empty</h4>
                                        <p class="fm-empty-sub">Tap the heart on any furniture piece to save it for later.</p>
                                        <a href="index.aspx" class="fm-btn-submit">
                                            <i class="bi bi-compass me-1"></i> Explore Furniture
                                        </a>
                                    </div>
                                </asp:Panel>

                            </div>

                        </div>
                        <!-- /Tab 3: Wishlist -->

                        <!-- ==========================================
                             Tab 4: Saved Addresses
                             ========================================== -->
                        <div class="tab-pane fade" id="addresses" role="tabpanel">

                            <div class="fm-content-card">
                                <div class="fm-card-heading-bar">
                                    <h3><i class="bi bi-geo-alt text-success"></i> Saved Addresses</h3>
                                    <button type="button" class="fm-btn-sm-primary" id="btnaddress" runat="server" onserverclick="btnaddress_ServerClick">
                                        <i class="bi bi-plus-lg me-1"></i> Add Address
                                    </button>
                                </div>

                                <div class="fm-addr-grid">

                                    <asp:Repeater ID="Repeater2" runat="server"
                                        OnItemCommand="Repeater2_ItemCommand"
                                        OnItemDataBound="Repeater2_ItemDataBound">
                                        <ItemTemplate>

                                            <div class="fm-addr-item">
                                                <div class="fm-addr-top">
                                                    <span class="fm-addr-recipient"><%# Eval("address_customer_name") %></span>
                                                    <span class="fm-addr-tag">Delivery</span>
                                                </div>

                                                <div class="fm-addr-text">
                                                    <%# Eval("address_line_1") %>, <%# Eval("address_line_2") %><br />
                                                    <strong><%# Eval("address_city_name") %>, <%# Eval("address_state_name") %> - <%# Eval("address_pincode") %></strong>
                                                </div>

                                                <div class="fm-addr-phone">
                                                    <i class="bi bi-telephone text-primary"></i>
                                                    <span><%# Eval("address_customer_mobileno") %></span>
                                                </div>

                                                <div class="fm-addr-actions">
                                                    <a href="add-address.aspx" class="fm-btn-sm-outline flex-grow-1 text-center justify-content-center">
                                                        <i class="bi bi-pencil-square"></i> Edit
                                                    </a>
                                                    <a href="javascript:void(0);" onclick="alert('To delete this address, please contact support or add a new address.');" class="fm-btn-sm-outline text-danger">
                                                        <i class="bi bi-trash"></i>
                                                    </a>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>

                                </div>

                                <!-- Clean Empty Address State using existing Panel2 -->
                                <asp:Panel ID="Panel2" runat="server" Visible="false">
                                    <div class="fm-empty-box">
                                        <div class="fm-empty-icon" style="background: #dcfce7; color: #16a34a;">
                                            <i class="bi bi-geo-alt"></i>
                                        </div>
                                        <h4 class="fm-empty-title">No Saved Addresses</h4>
                                        <p class="fm-empty-sub">Add your primary delivery address for fast checkout.</p>
                                        <a href="add-address.aspx" class="fm-btn-submit">
                                            <i class="bi bi-plus-circle me-1"></i> Add Delivery Address
                                        </a>
                                    </div>
                                </asp:Panel>

                            </div>

                        </div>
                        <!-- /Tab 4: Saved Addresses -->

                        <!-- ==========================================
                             Tab 5: Account Settings
                             ========================================== -->
                        <div class="tab-pane fade" id="settings" role="tabpanel">

                            <!-- Personal Information Card -->
                            <div class="fm-content-card">
                                <div class="fm-card-heading-bar">
                                    <h3><i class="bi bi-person text-primary"></i> Personal Information</h3>
                                </div>

                                <div class="row g-2 mb-3">
                                    <div class="col-12">
                                        <label for="name" class="fm-input-label">Full Name</label>
                                        <asp:TextBox runat="server" type="text" class="fm-text-input" id="name" required="" placeholder="Full name"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <label for="email" class="fm-input-label">Email Address</label>
                                        <asp:TextBox runat="server" type="text" class="fm-text-input" id="email" required="" placeholder="Email address"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <label for="phone" class="fm-input-label">Mobile Number</label>
                                        <asp:TextBox runat="server" type="text" class="fm-text-input" id="phone" placeholder="Mobile number"></asp:TextBox>
                                    </div>
                                </div>

                                <button type="submit" id="btnprofileupdate" runat="server" onserverclick="btnprofileupdate_ServerClick" class="fm-btn-submit">
                                    <i class="bi bi-check2 me-1"></i> Save Changes
                                </button>
                            </div>

                            <!-- Security Card -->
                            <div class="fm-content-card">
                                <div class="fm-card-heading-bar">
                                    <h3><i class="bi bi-shield-lock text-primary"></i> Password &amp; Security</h3>
                                </div>

                                <div class="row g-2 mb-3">
                                    <div class="col-12">
                                        <label for="currentPassword" class="fm-input-label">Current Password</label>
                                        <div class="fm-pwd-wrap">
                                            <asp:TextBox runat="server" type="password" class="fm-text-input" id="currentPassword" required="" placeholder="Current password"></asp:TextBox>
                                            <button type="button" class="fm-pwd-eye" onclick="fmTogglePwd('currentPassword', this)" aria-label="Toggle password">
                                                <i class="bi bi-eye"></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <label for="newPassword" class="fm-input-label">New Password</label>
                                        <div class="fm-pwd-wrap">
                                            <asp:TextBox runat="server" type="password" class="fm-text-input" id="newPassword" required="" placeholder="New password"></asp:TextBox>
                                            <button type="button" class="fm-pwd-eye" onclick="fmTogglePwd('newPassword', this)" aria-label="Toggle password">
                                                <i class="bi bi-eye"></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <label for="confirmPassword" class="fm-input-label">Confirm Password</label>
                                        <div class="fm-pwd-wrap">
                                            <asp:TextBox runat="server" type="password" class="fm-text-input" id="confirmPassword" required="" placeholder="Confirm password"></asp:TextBox>
                                            <button type="button" class="fm-pwd-eye" onclick="fmTogglePwd('confirmPassword', this)" aria-label="Toggle password">
                                                <i class="bi bi-eye"></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>

                                <button type="submit" id="btnupdatepassword" runat="server" onserverclick="btnupdatepassword_ServerClick" class="fm-btn-submit">
                                    <i class="bi bi-shield-check me-1"></i> Update Password
                                </button>
                            </div>

                            <!-- Danger Zone -->
                            <div class="fm-danger-box">
                                <h5 class="fw-bold text-danger mb-1"><i class="bi bi-exclamation-triangle me-1"></i> Delete Account</h5>
                                <p class="small text-muted mb-3">Permanently remove your account and order history from F-Mart.</p>
                                <button type="button" class="fm-btn-delete" id="btndelete" runat="server" onserverclick="btndelete_ServerClick" onclick="return confirm('Are you sure you want to permanently delete your account?');">
                                    <i class="bi bi-trash3 me-1"></i> Delete Account
                                </button>
                            </div>

                        </div>
                        <!-- /Tab 5: Account Settings -->

                    </div>
                </div>
                <!-- /Main Content -->

            </div>
        </div>
    </div>

    <!-- Client-Side Modern Tab Switching & Micro-Interactions -->
    <script>
        function fmGoToTab(tabId) {
            // Activate Tab Pane
            var panes = document.querySelectorAll('#accountTabContent .tab-pane');
            panes.forEach(function (p) {
                p.classList.remove('show', 'active');
            });
            var targetPane = document.getElementById(tabId);
            if (targetPane) {
                targetPane.classList.add('show', 'active');
            }

            // Sync Mobile Pills
            var mobilePills = document.querySelectorAll('#fmMobileTabBar .fm-tab-pill');
            mobilePills.forEach(function (pill) {
                if (pill.getAttribute('href') === '#' + tabId) {
                    pill.classList.add('active');
                    pill.scrollIntoView({ behavior: 'smooth', inline: 'center', block: 'nearest' });
                } else {
                    pill.classList.remove('active');
                }
            });

            // Sync Desktop Sidebar
            var desktopLinks = document.querySelectorAll('.fm-desktop-nav .nav-link');
            desktopLinks.forEach(function (link) {
                if (link.getAttribute('href') === '#' + tabId) {
                    link.classList.add('active');
                } else {
                    link.classList.remove('active');
                }
            });

            // Update URL hash
            window.location.hash = tabId;

            // Smooth scroll on mobile if viewing sub-tabs
            if (window.innerWidth < 992 && tabId !== 'profile') {
                var contentElem = document.getElementById('accountTabContent');
                if (contentElem) {
                    var yOffset = -70;
                    var y = contentElem.getBoundingClientRect().top + window.pageYOffset + yOffset;
                    window.scrollTo({ top: y, behavior: 'smooth' });
                }
            }
        }

        // Handle URL hash on initial load
        document.addEventListener('DOMContentLoaded', function () {
            var hash = window.location.hash.replace('#', '');
            if (hash && document.getElementById(hash)) {
                fmGoToTab(hash);
            }
        });

        // Password visibility toggle
        function fmTogglePwd(inputId, btn) {
            var inp = document.getElementById(inputId) || document.querySelector('[id$="' + inputId + '"]');
            if (!inp) return;
            var icon = btn.querySelector('i');
            if (inp.type === 'password') {
                inp.type = 'text';
                if (icon) {
                    icon.classList.remove('bi-eye');
                    icon.classList.add('bi-eye-slash');
                }
            } else {
                inp.type = 'password';
                if (icon) {
                    icon.classList.remove('bi-eye-slash');
                    icon.classList.add('bi-eye');
                }
            }
        }
    </script>

</asp:Content>