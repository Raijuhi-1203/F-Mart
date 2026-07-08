<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="categories-product.aspx.cs" Inherits="categories_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                                        <asp:Button class="action-btn wishlist-btn" ID="btnwishlist" runat="server" Text="♥" CommandName="Wishlist" CommandArgument='<%# Eval("product_id") %>'></asp:Button>
                                    </div>
                                    <asp:Button class="cart-btn" ID="btncart" runat="server" CommandName="AddCart" CommandArgument='<%# Eval("product_id") %>' Text="Add to Cart"></asp:Button>
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
