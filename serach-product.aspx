<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="serach-product.aspx.cs" Inherits="serach_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Product List</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Product List</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


    <!-- Best Sellers Section -->
<section id="best-sellers" class="best-sellers section">



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
                                    <button class="action-btn wishlist-btn">
                                        <i class="bi bi-heart"></i>
                                    </button>
                                    <%-- <button class="action-btn compare-btn">
                                    <i class="bi bi-arrow-left-right"></i>
                                </button>
                                <button class="action-btn quickview-btn">
                                    <i class="bi bi-zoom-in"></i>
                                </button>--%>
                                </div>
                                <button class="cart-btn">Add to Cart</button>
                            </div>
                            <div class="product-info">
                                <div class="product-category">Premium Collection</div>
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

                                <%--<div class="color-swatches">
                                <span class="swatch active" style="background-color: #2563eb;"></span>
                                <span class="swatch" style="background-color: #059669;"></span>
                                <span class="swatch" style="background-color: #dc2626;"></span>
                            </div>--%>
                            </div>
                        </div>
                    </div>
                    <!-- End Product 1 -->


                </ItemTemplate>
            </asp:Repeater>


            <asp:Panel ID="NoDataPanel" runat="server" Visible="false">
                <p>No match found! But don’t worry, we’ve got plenty of options to furnish your dream space.</p>
            </asp:Panel>

        </div>

    </div>

</section>
<!-- /Best Sellers Section -->



    </asp:Content>
