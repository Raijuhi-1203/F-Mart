<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Hero Section -->
    <section id="hero" class="hero section">

        <div class="hero-container">
            <div class="hero-content">
                <div class="content-wrapper" data-aos="fade-up" data-aos-delay="100">
                    <h1 class="hero-title">Comfortable Learning, Inspired Minds</h1>
                    <p class="hero-description">Welcome to The Furniture Mart – your one-stop destination for premium school furniture and office furniture.</p>
                    <div class="hero-actions" data-aos="fade-up" data-aos-delay="200">
                        <a href="category.aspx" class="btn-secondary">Browse Categories</a>
                    </div>
                    <div class="features-list" data-aos="fade-up" data-aos-delay="300">
                        <div class="feature-item">
                            <i class="bi bi-truck"></i>
                            <span>Free Shipping</span>
                        </div>
                        <div class="feature-item">
                            <i class="bi bi-award"></i>
                            <span>Quality Guarantee</span>
                        </div>
                        <div class="feature-item">
                            <i class="bi bi-headset"></i>
                            <span>24/7 Support</span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="hero-visuals">
                <div class="product-showcase" data-aos="fade-left" data-aos-delay="200">
                    <div class="product-card featured">
                        <img src="assets/img/product/product-2.jpg" alt="Featured Product" class="img-fluid">
                        <div class="product-badge">Best Seller</div>
                        <div class="product-info">
                            <h4>Brown Recliner Chair</h4>
                            <div class="price">
                                <span class="sale-price">Rs. 29,999</span>
                                <span class="original-price">Rs. 39,999</span>
                            </div>
                        </div>
                    </div>

                    <div class="product-grid">
                        <div class="product-mini" data-aos="zoom-in" data-aos-delay="400">
                            <img src="assets/img/product/product-3.jpg" alt="Product" class="img-fluid">
                            <span class="mini-price">Rs. 89,999</span>
                        </div>
                        <div class="product-mini" data-aos="zoom-in" data-aos-delay="500">
                            <img src="assets/img/product/product-5.jpg" alt="Product" class="img-fluid">
                            <span class="mini-price">Rs. 14,999</span>
                        </div>
                    </div>
                </div>

                <%-- <div class="floating-elements">
                    <div class="floating-icon cart" data-aos="fade-up" data-aos-delay="600">
                        <i class="bi bi-cart3"></i>
                        <span class="notification-dot">3</span>
                    </div>
                    <div class="floating-icon wishlist" data-aos="fade-up" data-aos-delay="700">
                        <i class="bi bi-heart"></i>
                    </div>
                    <div class="floating-icon search" data-aos="fade-up" data-aos-delay="800">
                        <i class="bi bi-search"></i>
                    </div>
                </div>--%>
            </div>
        </div>

    </section>
    <!-- /Hero Section -->

    <!-- Promo Cards Section -->
    <section id="promo-cards" class="promo-cards section">
        <div class="container" data-aos="fade-up" data-aos-delay="100">
            <div class="row gy-4">

                <div class="col-lg-6">
                    <div class="category-featured" data-aos="fade-right" data-aos-delay="200">
                        <div class="category-image">
                            <img src="assets/img/product/product-f-2.png" alt="Women's Collection" class="img-fluid">
                        </div>
                        <div class="category-content">
                            <span class="category-tag">Trending Now</span>
                            <h2>Perfect Space Together!</h2>
                            <p>
                                Looking for school furniture or office furniture?
Reach out to us for bulk orders, customization, and project-based solutions.
                            </p>
                            <a href="new-arrival.aspx" class="btn-shop">Explore More <i class="bi bi-arrow-right"></i></a>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6">

                    <div class="row gy-4">

                        <div class="col-xl-6">
                            <div class="category-card cat-men" data-aos="fade-up" data-aos-delay="300">
                                <div class="category-image">
                                    <img src="assets/img/product/product-m-5.png" alt="Men's Fashion" class="img-fluid">
                                </div>
                                <div class="category-content">
                                    <h4>Office Furniture</h4>
                                    <p>242+ products</p>
                                    <%--<a href="#" class="card-link">Shop Now <i class="bi bi-arrow-right"></i></a>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-6">
                            <div class="category-card cat-kids" data-aos="fade-up" data-aos-delay="400">
                                <div class="category-image">
                                    <img src="assets/img/product/product-8.png" alt="Kid's Fashion" class="img-fluid">
                                </div>
                                <div class="category-content">
                                    <h4>School Furniture</h4>
                                    <p>185+ products</p>
                                    <%--<a href="#" class="card-link">Shop Now <i class="bi bi-arrow-right"></i></a>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-12">
                            <div class="category-card cat-cosmetics" data-aos="fade-up" data-aos-delay="500">
                                <div class="category-image">
                                    <img src="assets/img/product/product-13.jpg" alt="Cosmetics" class="img-fluid">
                                </div>
                                <div class="category-content">
                                    <h4>Mattress</h4>
                                    <p>127+ products</p>
                                    <%--<a href="#" class="card-link">Shop Now <i class="bi bi-arrow-right"></i></a>--%>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>

        </div>
    </section>
    <!-- /Promo Cards Section -->

    <!-- Best Sellers Section -->
    <section id="best-sellers" class="best-sellers section">

        <!-- Section Title -->
        <div class="container section-title" data-aos="fade-up">
            <h2>Best Sellers</h2>
            <p>High-quality materials for durability & comfort</p>
        </div>
        <!-- End Section Title -->

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row g-5">

                <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                    <ItemTemplate>

                        <!-- Product 1 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="product-item">
                                <div class="product-image">
                                    <div class="product-badge"><%# Eval("product_discount_percentage") %> % OFF</div>
                                    <img src='auth/<%# Eval("photo_path") %>' alt="Product" class="img-fluid" loading="lazy">
                                    <div class="product-actions">
                                        <asp:Button class="action-btn wishlist-btn" id="btnwishlist" runat="server" Text="♥" CommandName="Wishlist" CommandArgument='<%# Eval("product_id") %>'></asp:Button>
                                    </div>
                                    <asp:Button class="cart-btn" ID="btncart" runat="server" CommandName="AddCart" CommandArgument='<%# Eval("product_id") %>' Text="Add to Cart"></asp:Button>
                                </div>
                                <div class="product-info">
                                    <div class="product-category">Premium Collection</div>
                                    <asp:Label ID="price_id" runat="server" Text='<%# Eval("product_id") %>' hidden></asp:Label>
                                    <h4 class="product-name"><a href="product-details.aspx?ref=<%# Eval("product_id") %>"><%# Eval("product_full_name") %></a></h4>
                                    <div class="product-rating">
                                        <div class="stars">
                                            <i class="bi bi-star-fill"></i>
                                            <i class="bi bi-star-fill"></i>
                                            <i class="bi bi-star-fill"></i>
                                            <i class="bi bi-star-fill"></i>
                                            <i class="bi bi-star"></i>
                                        </div>
                                        <%--<span class="rating-count">(24)</span>--%>
                                    </div>
                                    <div class="product-price">Rs. <%# Eval("product_market_price") %></div>

                                </div>
                            </div>
                        </div>
                        <!-- End Product 1 -->


                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </div>

    </section>
    <!-- /Best Sellers Section -->

    <!-- Cards Section -->
    <section id="cards" class="cards section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row gy-4">

                <div class="col-lg-4 col-md-6 mb-5 mb-md-0" data-aos="fade-up" data-aos-delay="200">
                    <div class="product-category">
                        <h3 class="category-title">
                            <i class="bi bi-fire"></i>Trending Now
                        </h3>
                        <div class="product-list">

                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <ItemTemplate>

                                    <div class="product-card">
                                        <div class="product-image">
                                            <img src='auth/<%# Eval("photo_path") %>' alt="The Furniture Mart" class="img-fluid">
                                            <%-- <div class="product-badges">
                                                <span class="badge-new">New</span>
                                            </div>--%>
                                        </div>
                                        <div class="product-info">
                                            <h4 class="product-name"><%# Eval("product_full_name") %></h4>
                                            <div class="product-rating">
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-half"></i>
                                                <%--<span>(24)</span>--%>
                                            </div>
                                            <div class="product-price">
                                                <span class="current-price">Rs. <%# Eval("product_market_price") %></span>
                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-md-6 mb-5 mb-md-0" data-aos="fade-up" data-aos-delay="300">
                    <div class="product-category">
                        <h3 class="category-title"><i class="bi bi-award"></i>Best Sellers</h3>
                        <div class="product-list">

                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                                <ItemTemplate>

                                    <div class="product-card">
                                        <div class="product-image">
                                            <img src='auth/<%# Eval("photo_path") %>' alt="The Furniture Mart" class="img-fluid">
                                            <%--<div class="product-badges">
                                                <span class="badge-new">New</span>
                                            </div>--%>
                                            <%--<div class="product-actions">
                                                <button class="action-btn wishlist-btn">
                                                    <i class="bi bi-heart"></i>
                                                </button>
                                            </div>--%>
                                        </div>
                                        <div class="product-info">
                                            <h4 class="product-name"><%# Eval("product_full_name") %></h4>
                                            <div class="product-rating">
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-half"></i>
                                                <%--<span>(24)</span>--%>
                                            </div>
                                            <div class="product-price">
                                                <span class="current-price">Rs. <%# Eval("product_market_price") %></span>
                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-md-6 mb-5 mb-md-0" data-aos="fade-up" data-aos-delay="400">
                    <div class="product-category">
                        <h3 class="category-title">
                            <i class="bi bi-star"></i>Featured Items
                        </h3>
                        <div class="product-list">

                            <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand">
                                <ItemTemplate>

                                    <div class="product-card">
                                        <div class="product-image">
                                            <img src='auth/<%# Eval("photo_path") %>' alt="The Furniture Mart" class="img-fluid">
                                            <%--<div class="product-badges">
                                                <span class="badge-new">New</span>
                                            </div>--%>
                                        </div>
                                        <div class="product-info">
                                            <h4 class="product-name"><%# Eval("product_full_name") %></h4>
                                            <div class="product-rating">
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-fill"></i>
                                                <i class="bi bi-star-half"></i>
                                                <%--<span>(24)</span>--%>
                                            </div>
                                            <div class="product-price">
                                                <span class="current-price">Rs. <%# Eval("product_market_price") %></span>
                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </section>
    <!-- /Cards Section -->

    <!-- Call To Action Section -->
    <section id="call-to-action" class="call-to-action section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row">
                <div class="col-lg-8 mx-auto">
                    <div class="main-content text-center" data-aos="zoom-in" data-aos-delay="200">
                        <div class="offer-badge" data-aos="fade-down" data-aos-delay="250">
                            <span class="limited-time">Limited Time</span>
                            <span class="offer-text">50% OFF</span>
                        </div>

                        <h2 data-aos="fade-up" data-aos-delay="300">Exclusive Flash Sale</h2>

                        <p class="subtitle" data-aos="fade-up" data-aos-delay="350">Don't miss out on our biggest sale of the year. Premium quality products at unbeatable prices for the next 48 hours only.</p>

                        <div class="countdown-wrapper" data-aos="fade-up" data-aos-delay="400">
                            <div class="countdown d-flex justify-content-center" data-count="2025/12/31">
                                <div>
                                    <h3 class="count-days"></h3>
                                    <h4>Days</h4>
                                </div>
                                <div>
                                    <h3 class="count-hours"></h3>
                                    <h4>Hours</h4>
                                </div>
                                <div>
                                    <h3 class="count-minutes"></h3>
                                    <h4>Minutes</h4>
                                </div>
                                <div>
                                    <h3 class="count-seconds"></h3>
                                    <h4>Seconds</h4>
                                </div>
                            </div>
                        </div>

                        <div class="action-buttons" data-aos="fade-up" data-aos-delay="450">
                            <a href="new-arrival.aspx" class="btn-shop-now">Shop Now</a>
                            <a href="bestsellers.aspx" class="btn-view-deals">View All Deals</a>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row featured-products-row" data-aos="fade-up" data-aos-delay="500">


                <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand">
                    <ItemTemplate>

                        <div class="col-lg-3 col-md-6" data-aos="zoom-in" data-aos-delay="100">
                            <div class="product-showcase">
                                <div class="product-image">
                                    <img src='auth/<%# Eval("photo_path") %>' alt="Featured Product" class="img-fluid">
                                    <div class="discount-badge">-<%# Eval("product_discount_percentage") %>%</div>
                                </div>
                                <div class="product-details">
                                    <h6><%# Eval("product_full_name") %></h6>
                                    <div class="price-section">
                                        <span class="original-price">Rs. <%# Eval("product_sell_price") %></span>
                                        <span class="sale-price">Rs. <%# Eval("product_market_price") %></span>
                                    </div>
                                    <div class="rating-stars">
                                        <i class="bi bi-star-fill"></i>
                                        <i class="bi bi-star-fill"></i>
                                        <i class="bi bi-star-fill"></i>
                                        <i class="bi bi-star-fill"></i>
                                        <i class="bi bi-star-fill"></i>
                                        <%--        <span class="rating-count">(324)</span>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End Product Showcase -->


                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </div>

    </section>
    <!-- /Call To Action Section -->

</asp:Content>
