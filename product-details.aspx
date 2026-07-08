<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="product-details.aspx.cs" Inherits="product_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Product Details</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Product Details</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


    <!-- Product Details Section -->
    <section id="product-details" class="product-details section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row g-4">
                <!-- Product Gallery -->
                <div class="col-lg-7" data-aos="zoom-in" data-aos-delay="150">
                    <div class="product-gallery">
                        <div class="main-showcase">
                            <div class="image-zoom-container">
                                <%-- <asp:Image id="product_img" runat="server" src="assets/img/product/product-details-6.jpg" alt="Product Main" class="img-fluid main-product-image drift-zoom" id="main-product-image" data-zoom="assets/img/product/product-details-6.webp">--%>
                                <asp:Image ID="product_img" runat="server" class="img-fluid main-product-image drift-zoom" />

                            </div>
                        </div>

                        <div class="thumbnail-grid">

                            <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                                <ItemTemplate>

                                    <div class="thumbnail-wrapper thumbnail-item active" data-image='auth/<%# Eval("photo_path") %>'>
                                        <img class="img-fluid" src='auth/<%# Eval("photo_path") %>' >
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                </div>

                <!-- Product Details -->
                <div class="col-lg-5" data-aos="fade-left" data-aos-delay="200">
                    <div class="product-details">
                        <div class="product-badge-container">
                            <span class="badge-category" id="category" runat="server">Audio Equipment</span>

                        </div>

                        <h1 class="product-name" id="product_name" runat="server">Mauris tempus cursus magna vel scelerisque nisl consectetur</h1>

                        <div class="pricing-section">
                            <div class="price-display">
                                <span class="sale-price" id="sell_price" runat="server">$189.99</span>
                                <span class="regular-price" id="shop_price" runat="server">$239.99</span>
                            </div>
                            <div class="savings-info">
                                <span class="save-amount" id="discount_price" runat="server">Save $50.00</span>
                                <span class="discount-percent" id="discount_percentage" runat="server">(21% off)</span>
                            </div>
                        </div>

                        <div class="product-description">
                            <asp:Label ID="description" runat="server">Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.</asp:Label>
                        </div>

                        <%--<div class="availability-status">
                            <div class="stock-indicator">
                                <i class="bi bi-check-circle-fill"></i>
                                <span class="stock-text">Available</span>
                            </div>
                            <div class="quantity-left">Only 18 items remaining</div>
                        </div>--%>

                        <%--<div class="variant-section">
                            <div class="color-selection">
                                <label class="variant-label">Available Colors:</label>
                                <div class="color-grid">
                                    <div class="color-chip active" data-color="Midnight Black" style="background: linear-gradient(135deg, #1a1a1a, #000);">
                                        <span class="selection-check"><i class="bi bi-check"></i></span>
                                    </div>
                                    <div class="color-chip" data-color="Pearl White" style="background: linear-gradient(135deg, #f8f9fa, #e9ecef);">
                                        <span class="selection-check"><i class="bi bi-check"></i></span>
                                    </div>
                                    <div class="color-chip" data-color="Ocean Blue" style="background: linear-gradient(135deg, #0066cc, #004499);">
                                        <span class="selection-check"><i class="bi bi-check"></i></span>
                                    </div>
                                    <div class="color-chip" data-color="Forest Green" style="background: linear-gradient(135deg, #28a745, #155724);">
                                        <span class="selection-check"><i class="bi bi-check"></i></span>
                                    </div>
                                </div>
                                <div class="selected-variant">Selected: <span>Midnight Black</span></div>
                            </div>
                        </div>--%>


                        <div class="purchase-section">
                            <div class="quantity-control">
                                <label class="control-label">Quantity:</label>
                                <div class="quantity-input-group">
                                    <div class="quantity-selector">
                                        <button class="quantity-btn decrease" type="button" id="minus" runat="server" onserverclick="minus_ServerClick">
                                            <i class="bi bi-dash"></i>
                                        </button>
                                        <asp:TextBox ID="changeqty" runat="server" type="number" class="quantity-input">1</asp:TextBox>
                                        <button class="quantity-btn increase" type="button" id="plus" runat="server" onserverclick="plus_ServerClick">
                                            <i class="bi bi-plus"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>

                            <div class="action-buttons">
                                <button class="btn primary-action" ID="btncart" runat="server" onserverclick="btncart_ServerClick">
                                    <i class="bi bi-bag-plus"></i>
                                    Add to Cart
                 
                                </button>
                                <button class="btn secondary-action" ID="btncart2" runat="server" onserverclick="btncart2_ServerClick">
                                    <i class="bi bi-lightning"></i>
                                    Buy Now
                 
                                </button>
                                <button class="btn icon-action" title="Add to Wishlist" id="btnwishlist" runat="server" onserverclick="btnwishlist_ServerClick">
                                    <i class="bi bi-heart"></i>
                                </button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <!-- Information Tabs -->
            <div class="row mt-5" data-aos="fade-up" data-aos-delay="300">
                <div class="col-12">
                    <div class="info-tabs-container">
                        <nav class="tabs-navigation nav">
                            <button class="nav-link active" data-bs-toggle="tab" data-bs-target="#ecommerce-product-details-5-overview" type="button">Overview</button>
                            <%--<button class="nav-link" data-bs-toggle="tab" data-bs-target="#ecommerce-product-details-5-customer-reviews" type="button">Reviews (127)</button>--%>
                        </nav>

                        <div class="tab-content">
                            <!-- Overview Tab -->
                            <div class="tab-pane fade show active" id="ecommerce-product-details-5-overview">
                                <div class="overview-content">
                                    <div class="row g-4">
                                        <div class="col-lg-12">
                                            <div class="content-section">
                                                <h3>Product Overview</h3>
                                                <asp:Label ID="descp" runat="server">Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.</asp:Label>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>


                            <%--<div class="tab-pane fade" id="ecommerce-product-details-5-customer-reviews">
                                <div class="reviews-content">
                                    <div class="reviews-header">
                                        <div class="rating-overview">
                                            <div class="average-score">
                                                <div class="score-display">4.6</div>
                                                <div class="score-stars">
                                                    <i class="bi bi-star-fill"></i>
                                                    <i class="bi bi-star-fill"></i>
                                                    <i class="bi bi-star-fill"></i>
                                                    <i class="bi bi-star-fill"></i>
                                                    <i class="bi bi-star-half"></i>
                                                </div>
                                                <div class="total-reviews">127 customer reviews</div>
                                            </div>

                                            <div class="rating-distribution">
                                                <div class="rating-row">
                                                    <span class="stars-label">5★</span>
                                                    <div class="progress-container">
                                                        <div class="progress-fill" style="width: 68%;"></div>
                                                    </div>
                                                    <span class="count-label">86</span>
                                                </div>
                                                <div class="rating-row">
                                                    <span class="stars-label">4★</span>
                                                    <div class="progress-container">
                                                        <div class="progress-fill" style="width: 22%;"></div>
                                                    </div>
                                                    <span class="count-label">28</span>
                                                </div>
                                                <div class="rating-row">
                                                    <span class="stars-label">3★</span>
                                                    <div class="progress-container">
                                                        <div class="progress-fill" style="width: 6%;"></div>
                                                    </div>
                                                    <span class="count-label">8</span>
                                                </div>
                                                <div class="rating-row">
                                                    <span class="stars-label">2★</span>
                                                    <div class="progress-container">
                                                        <div class="progress-fill" style="width: 3%;"></div>
                                                    </div>
                                                    <span class="count-label">4</span>
                                                </div>
                                                <div class="rating-row">
                                                    <span class="stars-label">1★</span>
                                                    <div class="progress-container">
                                                        <div class="progress-fill" style="width: 1%;"></div>
                                                    </div>
                                                    <span class="count-label">1</span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="write-review-cta">
                                            <h4>Share Your Experience</h4>
                                            <p>Help others make informed decisions</p>
                                            <button class="btn review-btn">Write Review</button>
                                        </div>
                                    </div>

                                    <div class="customer-reviews-list">
                                        <div class="review-card">
                                            <div class="reviewer-profile">
                                                <img src="assets/img/person/person-f-3.webp" alt="Customer" class="profile-pic">
                                                <div class="profile-details">
                                                    <div class="customer-name">Sarah Martinez</div>
                                                    <div class="review-meta">
                                                        <div class="review-stars">
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                        </div>
                                                        <span class="review-date">March 28, 2024</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <h5 class="review-headline">Outstanding audio quality and comfort</h5>
                                            <div class="review-text">
                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam. Eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.</p>
                                            </div>
                                            <div class="review-actions">
                                                <button class="action-btn"><i class="bi bi-hand-thumbs-up"></i>Helpful (12)</button>
                                                <button class="action-btn"><i class="bi bi-chat-dots"></i>Reply</button>
                                            </div>
                                        </div>

                                        <div class="review-card">
                                            <div class="reviewer-profile">
                                                <img src="assets/img/person/person-m-5.webp" alt="Customer" class="profile-pic">
                                                <div class="profile-details">
                                                    <div class="customer-name">David Chen</div>
                                                    <div class="review-meta">
                                                        <div class="review-stars">
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star"></i>
                                                        </div>
                                                        <span class="review-date">March 15, 2024</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <h5 class="review-headline">Great value, minor connectivity issues</h5>
                                            <div class="review-text">
                                                <p>Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Overall satisfied with the purchase.</p>
                                            </div>
                                            <div class="review-actions">
                                                <button class="action-btn"><i class="bi bi-hand-thumbs-up"></i>Helpful (8)</button>
                                                <button class="action-btn"><i class="bi bi-chat-dots"></i>Reply</button>
                                            </div>
                                        </div>

                                        <div class="review-card">
                                            <div class="reviewer-profile">
                                                <img src="assets/img/person/person-f-7.webp" alt="Customer" class="profile-pic">
                                                <div class="profile-details">
                                                    <div class="customer-name">Emily Rodriguez</div>
                                                    <div class="review-meta">
                                                        <div class="review-stars">
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                            <i class="bi bi-star-fill"></i>
                                                        </div>
                                                        <span class="review-date">February 22, 2024</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <h5 class="review-headline">Perfect for work-from-home setup</h5>
                                            <div class="review-text">
                                                <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.</p>
                                            </div>
                                            <div class="review-actions">
                                                <button class="action-btn"><i class="bi bi-hand-thumbs-up"></i>Helpful (15)</button>
                                                <button class="action-btn"><i class="bi bi-chat-dots"></i>Reply</button>
                                            </div>
                                        </div>

                                        <div class="load-more-section">
                                            <button class="btn load-more-reviews">Show More Reviews</button>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
    <!-- /Product Details Section -->


</asp:Content>
