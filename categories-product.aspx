<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="categories-product.aspx.cs" Inherits="categories_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Best Sellers Section -->
    <section id="best-sellers" class="best-sellers section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row g-5">

                <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                    <ItemTemplate>

                        <!-- Product 1 -->
                        <div class="col-6 col-lg-3 col-md-6">
                            <div class="product-item">
                                <div class="product-image">
                                    <a href='product-details.aspx?ref=<%# Eval("product_id") %>' class="product-img-link" title='<%# Eval("product_full_name") %>'>
                                        <img src='auth/<%# Eval("photo_path") %>' alt='<%# Eval("product_full_name") %>' class="img-fluid" loading="lazy"></a>

                                    <!-- Rating Pill Badge (Bottom-Left like Flipkart) -->
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

                                    <div class="bank-offer">
                                        &#8377;<%# Eval("product_sell_price") %> with Bank offer
                                    </div>
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
