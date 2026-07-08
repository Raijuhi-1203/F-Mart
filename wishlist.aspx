<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wishlist.aspx.cs" Inherits="wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Wishlist</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.html">Home</a></li>
                    <li class="current">Wishlist</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Cart Section -->
    <section id="cart" class="cart section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row">
                <div class="col-lg-12" data-aos="fade-up" data-aos-delay="200">
                    <div class="cart-items">
                        <div class="cart-header d-none d-lg-block">
                            <div class="row align-items-center">
                                <div class="col-lg-6">
                                    <h5>Product</h5>
                                </div>
                                <div class="col-lg-3 text-center">
                                    <h5>Price(Rs.)</h5>
                                </div>
                                <div class="col-lg-3 text-center">
                                    <h5>Quantity</h5>
                                </div>

                            </div>
                        </div>

                        <!-- Cart Item 1 -->
                        <div class="cart-item">
                            <div class="row align-items-center">

                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>

                                        <div class="col-lg-6 col-12 mt-3 mt-lg-0 mb-lg-0 mb-3">
                                            <div class="product-info d-flex align-items-center">
                                                <div class="product-image">
                                                    <img src='auth/<%# Eval("photo_path") %>' alt="Product" class="img-fluid" loading="lazy">
                                                </div>
                                                <div class="product-details">
                                                    <h6 class="product-title"><%# Eval("product_full_name") %></h6>
                                                    
                                                     <asp:Button class="remove-item" CommandName="Remove" CommandArgument='<%# Eval("product_id") %>' type="button" id="btnremove" runat="server" Text="Remove"></asp:Button>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-12 mt-3 mt-lg-0 text-center">
                                            <div class="price-tag">
                                                <span class="current-price" style="color:red;"><%# Eval("product_market_price") %></span>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-12 mt-3 mt-lg-0 text-center">
                                            <div class="quantity-selector">
                                                <asp:Label runat="server" ID="qty" type="number" class="quantity-input"><%# Eval("wishlist_qty") %></asp:Label>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>

                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <p>Your wishlist is empty!</p>
                                </asp:Panel>

                            </div>
                        </div>
                        <!-- End Cart Item -->

                    </div>
                </div>


            </div>

        </div>

    </section>
    <!-- /Cart Section -->


</asp:Content>
