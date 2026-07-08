<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="category.aspx.cs" Inherits="category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Category</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Category</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


    <div class="container">
        <div class="row">

            <div class="col-lg-4 sidebar">

                <div class="widgets-container">

                    <!-- Product Categories Widget -->
                    <div class="product-categories-widget widget-item">

                        <h3 class="widget-title">Categories</h3>

                        <ul class="category-tree list-unstyled mb-0">

                            <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand" OnItemDataBound="rptbinddata_ItemDataBound">
                                <ItemTemplate>

                                    <li class="category-item">
                                        <div class="d-flex justify-content-between align-items-center category-header collapsed">
                                            <asp:LinkButton CommandName="category" ID="cat" runat="server" class="category-link" OnClick="cat_Click"><%# Eval("category_name") %></asp:LinkButton>
                                            <asp:Label ID="catnm" runat="server" Text='<%# Eval("category_id") %>' hidden></asp:Label>
                                        </div>
                                    </li>

                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>

                    </div>
                    <!--/Product Categories Widget -->



                </div>

            </div>

            <div class="col-lg-8">

                <!-- Category Header Section -->
                <section id="category-header" class="category-header section">

                    <div class="container" data-aos="fade-up">

                        <!-- Filter and Sort Options -->
                        <div class="filter-container mb-4" data-aos="fade-up" data-aos-delay="100">
                            <div class="row g-3">

                                <div class="col-12 col-md-6 col-lg-6">
                                    <div class="filter-item search-form">
                                        <label for="productSearch" class="form-label">Search Products</label>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="productSearch" placeholder="Search for products..." aria-label="Search for products"></asp:TextBox>
                                            <button class="btn search-btn" type="button" id="btnsearch" runat="server" onserverclick="btnsearch_ServerClick">
                                                <i class="bi bi-search"></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-12 col-md-6 col-lg-6">
                                    <div class="filter-item">
                                        <label for="priceRange" class="form-label">Price Range</label>
                                        <asp:DropDownList class="form-select" ID="priceRange" data-live-search="true" runat="server" OnSelectedIndexChanged="priceRange_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>All Prices</asp:ListItem>
                                            <asp:ListItem>10000 to 25000</asp:ListItem>
                                            <asp:ListItem>25000 to 50000</asp:ListItem>
                                            <asp:ListItem>50000 to Above</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </section>
                <!-- /Category Header Section -->

                <!-- Category Product List Section -->
                <section id="category-product-list" class="category-product-list section">

                    <div class="container" data-aos="fade-up" data-aos-delay="100">

                        <div class="row g-4">

                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>

                                    <div class="col-6 col-xl-4">

                                        <div class="product-card" data-aos="zoom-in">
                                            <div class="product-image">
                                                <img src='auth/<%# Eval("photo_path") %>' class="main-image img-fluid" alt="Product">
                                                <img src='auth/<%# Eval("photo_path") %>' class="hover-image img-fluid" alt="Product Variant">
                                                <div class="product-overlay">
                                                    <div class="product-actions">

                                                         <asp:Button class="action-btn" CommandName="AddCart" CommandArgument='<%# Eval("product_id") %>' type="button" id="btnremove" runat="server" Text="🛒"></asp:Button>


                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="product-details">
                                                <div class="product-category"><%# Eval("product_parent_category_name") %></div>
                                                <h4 class="product-title" style=""><a href="product-details.aspx?ref=<%# Eval("product_id") %>"><%# Eval("product_full_name") %></a></h4>
                                                <div class="product-meta">
                                                    <div class="product-price">Rs. <%# Eval("product_market_price") %></div>
                                                    <div class="product-rating">
                                                        <i class="bi bi-star-fill"></i>
                                                        4.8 
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>

                            <asp:Panel ID="NoDataPanel" runat="server" Visible="false">
                                <p>No match found! But don’t worry, we’ve got plenty of options to furnish your dream space.</p>
                            </asp:Panel>

                        </div>

                    </div>

                </section>
                <!-- /Category Product List Section -->



            </div>
</asp:Content>
