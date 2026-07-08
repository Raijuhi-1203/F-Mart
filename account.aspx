<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account.aspx.cs" Inherits="account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Account</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Account</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Account Section -->
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
                <!-- Profile Menu -->
                <div class="col-lg-3">
                    <div class="profile-menu collapse d-lg-block" id="profileMenu">
                        <!-- User Info -->
                        <div class="user-info" data-aos="fade-right">
                            <div class="user-avatar">
                                <img src="assets/img/user.png" alt="Profile" loading="lazy">
                                <span class="status-badge"><i class="bi bi-shield-check"></i></span>
                            </div>
                            <h4 id="username" runat="server"></h4>

                        </div>

                        <!-- Navigation Menu -->
                        <nav class="menu-nav">
                            <ul class="nav flex-column" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-bs-toggle="tab" href="#orders">
                                        <i class="bi bi-box-seam"></i>
                                        <span>My Orders</span>
                                        <span class="badge" id="ordercount" runat="server">3</span>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#wishlist">
                                        <i class="bi bi-heart"></i>
                                        <span>Wishlist</span>
                                        <span class="badge" id="wishlistcount" runat="server">12</span>
                                    </a>
                                </li>

                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#addresses">
                                        <i class="bi bi-geo-alt"></i>
                                        <span>Address</span>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#settings">
                                        <i class="bi bi-gear"></i>
                                        <span>Account Settings</span>
                                    </a>
                                </li>
                            </ul>

                            <div class="menu-footer">
                                <a href="contact.aspx" class="help-link">
                                    <i class="bi bi-question-circle"></i>
                                    <span>Help Center</span>
                                </a>
                                <a href="logout.aspx" class="logout-link">
                                    <i class="bi bi-box-arrow-right"></i>
                                    <span>Log Out</span>
                                </a>
                            </div>
                        </nav>
                    </div>
                </div>

                <!-- Content Area -->
                <div class="col-lg-9">
                    <div class="content-area">
                        <div class="tab-content">
                            <!-- Orders Tab -->
                            <div class="tab-pane fade show active" id="orders">
                                <div class="section-header" data-aos="fade-up">
                                    <h2>My Orders</h2>
                                    <div class="header-actions">
                                        <div class="dropdown">
                                            <button class="filter-btn" data-bs-toggle="dropdown">
                                                <i class="bi bi-funnel"></i>
                                                <span>Filter</span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a class="dropdown-item" href="#">All Orders</a></li>
                                                <li><a class="dropdown-item" href="#">Processing</a></li>
                                                <li><a class="dropdown-item" href="#">Shipped</a></li>
                                                <li><a class="dropdown-item" href="#">Delivered</a></li>
                                                <li><a class="dropdown-item" href="#">Cancelled</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>

                                <div class="orders-grid">

                                    <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand" OnItemDataBound="rptbinddata_ItemDataBound">
                                        <ItemTemplate>

                                            <div class="order-card" data-aos="fade-up" data-aos-delay="100">
                                                <div class="order-header">
                                                    <div class="order-id">
                                                        <span class="label">Order ID:</span>
                                                        <span class="value"><%# Eval("order_id") %></span>
                                                    </div>
                                                    <div class="order-date"><%# Eval("order_date") %></div>
                                                </div>
                                                <div class="order-content">
                                                    
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
                                                <div class="order-footer">
                                                    <button type="button" class="btn-track" data-bs-toggle="collapse" data-bs-target="#tracking1" aria-expanded="false">Track Order</button>
                                                    <button type="button" class="btn-details" data-bs-toggle="collapse" data-bs-target="#details1" aria-expanded="false">View Details</button>
                                                </div>

                                                
                                            </div>


                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <asp:Panel ID="NoDataPanel" runat="server" Visible="false">
                                        <p>Your order history is empty! 🛒 Start shopping now to fill it up.</p>
                                    </asp:Panel>

                                </div>

                            </div>

                            <!-- Wishlist Tab -->
                            <div class="tab-pane fade" id="wishlist">
                                <div class="section-header" data-aos="fade-up">
                                    <h2>My Wishlist</h2>
                                </div>

                                <div class="wishlist-grid">

                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                                        <ItemTemplate>

                                            <div class="wishlist-card" data-aos="fade-up" data-aos-delay="100">
                                                <div class="wishlist-image">
                                                    <img src='auth/<%# Eval("photo_path") %>' alt="Product" loading="lazy">
                                                    <button class="btn-remove" type="button" aria-label="Remove from wishlist">
                                                        <i class="bi bi-trash"></i>
                                                    </button>

                                                </div>
                                                <div class="wishlist-content">
                                                    <h4><%# Eval("product_full_name") %></h4>
                                                    <div class="product-meta">
                                                        <div class="rating">
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-half"></i>
                                                            <span>(4.5)</span>
                                                        </div>
                                                        <div class="price">
                                                            <span class="current">Rs. <%# Eval("product_market_price") %></span>
                                                            <span class="original">Rs. <%# Eval("product_sell_price") %></span>
                                                        </div>
                                                    </div>
                                                    <button type="button" class="btn-add-cart">Add to Cart</button>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <p>Your wishlist is empty!</p>
                                    </asp:Panel>

                                </div>
                            </div>

                            <!-- Addresses Tab -->
                            <div class="tab-pane fade" id="addresses">
                                <div class="section-header" data-aos="fade-up">
                                    <h2>My Address</h2>
                                    <div class="header-actions">
                                        <button type="button" class="btn btn-primary btn-submit" id="btnaddress" runat="server" onserverclick="btnaddress_ServerClick">
                                            <i class="bi bi-plus-lg"></i>
                                            Add New Address
                                        </button>
                                    </div>
                                </div>

                                <div class="addresses-grid">

                                    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" OnItemDataBound="Repeater2_ItemDataBound">
                                        <ItemTemplate>

                                            <!-- Address Card 1 -->
                                            <div class="address-card default" data-aos="fade-up" data-aos-delay="100">
                                                <%--<div class="card-header">
                                                    <h4>Home</h4>
                                                    <span class="default-badge">Default</span>
                                                </div>--%>
                                                <div class="card-body">
                                                    <p class="address-text">
                                                        <%# Eval("address_line_1") %>, 
                                                        <%# Eval("address_line_2") %><br>
                                                        <%# Eval("address_city_name") %>, <%# Eval("address_state_name") %> - <%# Eval("address_pincode") %>
                                                    </p>
                                                    <div class="contact-info">
                                                        <div><i class="bi bi-person"></i><%# Eval("address_customer_name") %></div>
                                                        <div><i class="bi bi-telephone"></i><%# Eval("address_customer_mobileno") %></div>
                                                    </div>
                                                </div>
                                                <div class="card-actions">
                                                    <button type="button" class="btn-edit">
                                                        <i class="bi bi-pencil"></i>Edit
                                                    </button>
                                                    <button type="button" class="btn-remove">
                                                        <i class="bi bi-trash"></i>Remove
                                                    </button>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                                        <p>Your address list is empty!</p>
                                    </asp:Panel>
                                </div>
                            </div>

                            <!-- Settings Tab -->
                            <div class="tab-pane fade" id="settings">
                                <div class="section-header" data-aos="fade-up">
                                    <h2>Account Settings</h2>
                                </div>

                                <div class="settings-content">
                                    <!-- Personal Information -->
                                    <div class="settings-section" data-aos="fade-up">
                                        <h3>Personal Information</h3>
                                        <div class="php-email-form settings-form">
                                            <div class="row g-3">
                                                <div class="col-md-12">
                                                    <label for="firstName" class="form-label">Name</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" id="name" required=""></asp:TextBox>
                                                </div>
                                                
                                                <div class="col-md-6">
                                                    <label for="email" class="form-label">Email</label>
                                                    <asp:TextBox runat="server" type="text"  class="form-control" id="email" required=""></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <label for="phone" class="form-label">Mobile No.</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" id="phone"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-buttons">
                                                <button type="submit" id="btnprofileupdate" runat="server" onserverclick="btnprofileupdate_ServerClick" class="btn-save">Save Changes</button>
                                            </div>

                                            
                                        </div>
                                    </div>

                                   

                                    <!-- Security Settings -->
                                    <div class="settings-section" data-aos="fade-up" data-aos-delay="200">
                                        <h3>Security</h3>
                                        <div class="php-email-form settings-form">
                                            <div class="row g-3">
                                                <div class="col-md-12">
                                                    <label for="currentPassword" class="form-label">Current Password</label>
                                                    <asp:TextBox runat="server" type="password" class="form-control" id="currentPassword" required=""></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <label for="newPassword" class="form-label">New Password</label>
                                                    <asp:TextBox runat="server" type="password" class="form-control" id="newPassword" required=""></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <label for="confirmPassword" class="form-label">Confirm Password</label>
                                                    <asp:TextBox runat="server" type="password" class="form-control" id="confirmPassword" required=""></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-buttons">
                                                <button type="submit" id="btnupdatepassword" runat="server" onserverclick="btnupdatepassword_ServerClick" class="btn-save">Update Password</button>
                                            </div>

                                            
                                        </div>
                                    </div>

                                    <!-- Delete Account -->
                                    <div class="settings-section danger-zone" data-aos="fade-up" data-aos-delay="300">
                                        <h3>Delete Account</h3>
                                        <div class="danger-zone-content">
                                            <p>Once you delete your account, there is no going back. Please be certain.</p>
                                            <button type="button" class="btn-danger" id="btndelete" runat="server" onserverclick="btndelete_ServerClick">Delete Account</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>

    </section>
    <!-- /Account Section -->

</asp:Content>
