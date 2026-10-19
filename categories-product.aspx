<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="categories-product.aspx.cs" Inherits="categories_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Minimal Myntra / Amazon Style Styling -->
    <style>
        .cat-prod-wrapper {
            background-color: #ffffff;
            min-height: 80vh;
            padding-bottom: 50px;
        }

        /* Minimal Breadcrumbs like Myntra */
        .myntra-breadcrumb-bar {
            padding: 14px 0 12px 0;
            border-bottom: 1px solid #f0f0f2;
            margin-bottom: 24px;
        }

        .myntra-breadcrumbs {
            font-size: 12.5px;
            color: #878b94;
            display: flex;
            align-items: center;
            gap: 8px;
        }

        .myntra-breadcrumbs a {
            color: #282c3f;
            text-decoration: none;
            font-weight: 500;
        }

        .myntra-breadcrumbs a:hover {
            color: #0097b2;
        }

        .myntra-breadcrumbs .divider {
            color: #d4d5d9;
            font-size: 11px;
        }

        .myntra-breadcrumbs .current {
            color: #535766;
            font-weight: 600;
        }

        /* Product Title 2-Line Clamping for Uniform Card Heights */
        .best-sellers .product-name {
            font-size: 0.9rem;
            font-weight: 600;
            line-height: 1.35;
            height: 2.7em;
            white-space: normal;
            overflow: hidden;
            display: -webkit-box;
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
        }

        /* Responsive Polish for Phone / Mobile Touchscreens */
        @media (max-width: 575.98px) {
            .myntra-breadcrumb-bar {
                padding: 10px 0;
                margin-bottom: 16px;
            }

            .best-sellers .cart-btn {
                opacity: 1 !important;
                transform: translateY(0) !important;
                font-size: 0.7rem !important;
                padding: 4px 8px !important;
                border-radius: 6px !important;
                bottom: 6px !important;
                right: 6px !important;
            }

            .best-sellers .product-name {
                font-size: 0.82rem !important;
                height: 2.6em !important;
            }

            .best-sellers .product-price .sale-price {
                font-size: 0.95rem !important;
            }
        }
    </style>

    <div class="cat-prod-wrapper">

        <!-- Simple Myntra Breadcrumbs -->
        <div class="myntra-breadcrumb-bar">
            <div class="container">
                <nav class="myntra-breadcrumbs">
                    <a href="index.aspx">Home</a>
                    <span class="divider">/</span>
                    <a href="category.aspx">Categories</a>
                    <span class="divider">/</span>
                    <span class="current">Products</span>
                </nav>
            </div>
        </div>

        <div class="container">

            <!-- Product Repeater Section (Same as Category & Index page) -->
            <section id="best-sellers" class="best-sellers section p-0">

                <div class="row g-3 g-md-4">

                    <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                        <ItemTemplate>

                            <div class="col-6 col-lg-3 col-md-4">
                                <div class="product-item">
                                    <div class="product-image">
                                        <a href='product-details.aspx?ref=<%# Eval("product_id") %>' class="product-img-link" title='<%# Eval("product_full_name") %>'>
                                            <img src='auth/<%# Eval("photo_path") %>' alt='<%# Eval("product_full_name") %>' class="img-fluid" loading="lazy">
                                        </a>

                                        <!-- Rating Pill Badge -->
                                        <div class="rating-pill">
                                            <span class="rating-score">4.6</span>
                                            <span class="rating-star">&#9733;</span>
                                            <span class="rating-count">(2,450)</span>
                                        </div>

                                        <!-- Wishlist Floating Button -->
                                        <div class="product-actions">
                                            <asp:LinkButton class="action-btn wishlist-btn" ID="btnwishlist"
                                                runat="server" CommandName="Wishlist"
                                                CommandArgument='<%# Eval("product_id") %>' ToolTip="Add to Wishlist">
                                                <i class="bi bi-heart"></i>
                                            </asp:LinkButton>
                                        </div>

                                        <!-- Add to Cart Floating Button -->
                                        <asp:Button class="cart-btn" ID="btncart" runat="server" CommandName="AddCart"
                                            CommandArgument='<%# Eval("product_id") %>' Text="Add to Cart"></asp:Button>
                                    </div>

                                    <div class="product-info">
                                        <asp:Label ID="price_id" runat="server" Text='<%# Eval("product_id") %>' hidden>
                                        </asp:Label>

                                        <h4 class="product-name">
                                            <a href='product-details.aspx?ref=<%# Eval("product_id") %>' title='<%# Eval("product_full_name") %>'>
                                                <%# Eval("product_full_name") %>
                                            </a>
                                        </h4>

                                        <div class="product-price">
                                            <%# Convert.ToString(Eval("product_market_price")) != "" && Convert.ToString(Eval("product_market_price")) != Convert.ToString(Eval("product_sell_price"))
                                                ? "<span class=\"original-price\">&#8377;" + Eval("product_market_price") + "</span>" 
                                                : "" %>
                                            <span class="sale-price">&#8377;<%# Eval("product_sell_price") %></span>
                                        </div>

                                        <%-- <div class="bank-offer">
                                            &#8377;<%# Eval("product_sell_price") %> with Bank offer
                                        </div> --%>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- Empty State Panel -->
                    <asp:Panel ID="NoDataPanel" runat="server" Visible="false" class="col-12">
                        <div class="text-center py-5">
                            <i class="bi bi-bag-x text-muted" style="font-size: 3rem;"></i>
                            <h5 class="fw-bold text-dark mt-3 mb-1">No Matching Products Found</h5>
                            <p class="text-muted small mb-3">No products available in this category currently.</p>
                            <a href="category.aspx" class="btn btn-outline-secondary btn-sm px-3">Browse All Categories</a>
                        </div>
                    </asp:Panel>

                </div>

            </section>
            <!-- /Product Repeater Section -->

        </div>

    </div>

</asp:Content>

