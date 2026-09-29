<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wishlist.aspx.cs" Inherits="wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Scoped Styles for Clean Simple Wishlist Page -->
    <style>
        :root {
            --wsh-theme: #0097b2;
            --wsh-theme-hover: #007d94;
            --wsh-theme-soft: rgba(0, 151, 178, 0.08);
            --wsh-dark: #0f172a;
            --wsh-slate: #334155;
            --wsh-muted: #64748b;
            --wsh-border: #e2e8f0;
            --wsh-green: #16a34a;
        }

        .wishlist-section-wrap {
            padding: 35px 0 60px 0;
            background-color: #ffffff;
            min-height: 75vh;
        }

        /* Wishlist Table Container */
        .simple-wishlist-box {
            background: #ffffff;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 4px 20px rgba(15, 23, 42, 0.05);
            border: 1px solid var(--wsh-border);
            margin-bottom: 30px;
        }

        /* Top Header Strip (Theme Colored Banner) */
        .wishlist-table-header {
            background: var(--wsh-theme);
            color: #ffffff;
            padding: 14px 20px;
            display: flex;
            align-items: center;
            font-size: 13px;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: 0.6px;
        }

        .col-header-product {
            flex: 2;
            padding-left: 36px; /* Space for remove button */
        }

        .col-header-price {
            flex: 1;
            text-align: center;
        }

        .col-header-stock {
            flex: 1;
            text-align: center;
        }

        .col-header-action {
            flex: 1;
            text-align: right;
            padding-right: 10px;
        }

        /* Wishlist Items List */
        .wishlist-rows-list {
            display: flex;
            flex-direction: column;
        }

        /* Single Wishlist Item Row */
        .simple-wishlist-row {
            display: flex;
            align-items: center;
            padding: 16px 20px;
            border-bottom: 1px solid #f1f5f9;
            transition: background-color 0.2s ease;
        }

        .simple-wishlist-row:last-child {
            border-bottom: none;
        }

        .simple-wishlist-row:hover {
            background-color: #fafcfc;
        }

        /* Product Left Column */
        .row-col-product {
            flex: 2;
            display: flex;
            align-items: center;
            gap: 16px;
            min-width: 0;
        }

        /* Cross / Remove Button */
        .simple-remove-btn {
            background: none;
            border: none;
            width: 28px;
            height: 28px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            color: #94a3b8;
            font-size: 14px;
            cursor: pointer;
            transition: all 0.2s ease;
            text-decoration: none;
            flex-shrink: 0;
            padding: 0;
        }

        .simple-remove-btn:hover {
            background-color: #fef2f2;
            color: #ef4444;
            transform: scale(1.1);
        }

        /* Thumbnail Image */
        .simple-thumb-link {
            width: 70px;
            height: 70px;
            border-radius: 8px;
            border: 1px solid #f1f5f9;
            background: #ffffff;
            display: flex;
            align-items: center;
            justify-content: center;
            overflow: hidden;
            flex-shrink: 0;
            padding: 4px;
        }

        .simple-thumb-link img {
            max-width: 100%;
            max-height: 100%;
            object-fit: contain;
            transition: transform 0.3s ease;
        }

        .simple-wishlist-row:hover .simple-thumb-link img {
            transform: scale(1.06);
        }

        /* Product Info */
        .simple-info-wrap {
            flex: 1;
            min-width: 0;
        }

        .simple-product-name {
            font-size: 14.5px;
            font-weight: 700;
            color: var(--wsh-dark);
            margin: 0 0 4px 0;
            line-height: 1.35;
        }

        .simple-product-name a {
            color: var(--wsh-dark);
            text-decoration: none;
            transition: color 0.2s ease;
        }

        .simple-product-name a:hover {
            color: var(--wsh-theme);
        }

        .simple-product-sub {
            font-size: 12px;
            color: var(--wsh-muted);
            display: flex;
            align-items: center;
            flex-wrap: wrap;
            gap: 4px;
        }

        .sub-sep {
            color: #cbd5e1;
            margin: 0 2px;
        }

        /* Row Details Bar: On desktop spans across columns */
        .row-details-bar {
            flex: 3;
            display: flex;
            align-items: center;
        }

        /* Price Column */
        .row-col-price {
            flex: 1;
            text-align: center;
            font-size: 15px;
            font-weight: 700;
            color: var(--wsh-dark);
        }

        /* Stock Status Column */
        .row-col-stock {
            flex: 1;
            text-align: center;
        }

        .simple-stock-badge {
            font-size: 12px;
            font-weight: 600;
            color: var(--wsh-green);
            display: inline-flex;
            align-items: center;
            gap: 4px;
        }

        /* Action Pill Button Column */
        .row-col-action {
            flex: 1;
            text-align: right;
            padding-right: 10px;
        }

        .simple-pill-btn {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            gap: 6px;
            padding: 8px 20px;
            background: var(--wsh-theme);
            color: #ffffff !important;
            border-radius: 50px;
            font-size: 12.5px;
            font-weight: 600;
            text-decoration: none;
            transition: all 0.25s ease;
            box-shadow: 0 2px 6px rgba(0, 151, 178, 0.2);
            white-space: nowrap;
        }

        .simple-pill-btn:hover {
            background: var(--wsh-theme-hover);
            color: #ffffff !important;
            transform: translateY(-1px);
            box-shadow: 0 4px 12px rgba(0, 151, 178, 0.3);
        }

        /* Bottom Feature Strips (Desktop: 3 in 1 Row) */
        .wishlist-features-row {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 20px;
            padding: 22px 20px;
            background: #f8fafc;
            border: 1px solid #e2e8f0;
            border-radius: 12px;
        }

        .wishlist-feature-item {
            display: flex;
            align-items: center;
            gap: 14px;
        }

        .feature-icon-box {
            width: 44px;
            height: 44px;
            border-radius: 10px;
            background: var(--wsh-theme-soft);
            color: var(--wsh-theme);
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 20px;
            flex-shrink: 0;
        }

        .feature-text-box h6 {
            font-size: 13.5px;
            font-weight: 700;
            color: var(--wsh-dark);
            margin: 0 0 2px 0;
        }

        .feature-desc-full {
            font-size: 12px;
            color: var(--wsh-muted);
            margin: 0;
            line-height: 1.4;
            display: block;
        }

        .feature-desc-short {
            display: none;
        }

        /* Empty Wishlist State */
        .simple-empty-state {
            padding: 60px 20px;
            text-align: center;
        }

        .simple-empty-icon {
            width: 72px;
            height: 72px;
            border-radius: 50%;
            background: var(--wsh-theme-soft);
            color: var(--wsh-theme);
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 32px;
            margin: 0 auto 16px auto;
        }

        .simple-empty-state h4 {
            font-size: 1.25rem;
            font-weight: 700;
            color: var(--wsh-dark);
            margin-bottom: 6px;
        }

        .simple-empty-state p {
            font-size: 0.9rem;
            color: var(--wsh-muted);
            margin-bottom: 18px;
        }

        /* ==============================================
           MOBILE RESPONSIVE (Strict 320px Support)
           ============================================== */
        @media (max-width: 767px) {
            .wishlist-section-wrap {
                padding: 15px 0 35px 0 !important;
            }

            .wishlist-section-wrap .container {
                padding-left: 8px !important;
                padding-right: 8px !important;
                max-width: 100% !important;
            }

            /* Hide table header on mobile */
            .wishlist-table-header {
                display: none;
            }

            .simple-wishlist-box {
                border-radius: 8px;
                margin-bottom: 16px;
            }

            .simple-wishlist-row {
                flex-direction: column;
                align-items: stretch;
                padding: 12px 10px;
                gap: 8px;
            }

            .row-col-product {
                width: 100%;
                gap: 10px;
            }

            .simple-thumb-link {
                width: 56px;
                height: 56px;
            }

            .simple-product-name {
                font-size: 13px;
                line-height: 1.3;
                margin-bottom: 3px;
            }

            .simple-product-sub {
                font-size: 11px;
            }

            /* Row Details Bar on Mobile: Clean 1 Row below Product */
            .row-details-bar {
                display: flex;
                align-items: center;
                justify-content: space-between;
                width: 100%;
                padding-top: 8px;
                border-top: 1px dashed #f1f5f9;
                gap: 6px;
            }

            .row-col-price {
                text-align: left;
                font-size: 13.5px;
                font-weight: 700;
                flex: 0 0 auto;
            }

            .row-col-stock {
                text-align: left;
                flex: 0 0 auto;
            }

            .simple-stock-badge {
                font-size: 11px;
            }

            .row-col-action {
                text-align: right;
                padding-right: 0;
                flex: 0 0 auto;
                margin-left: auto;
            }

            /* NORMAL SIZED PILL BUTTON ON PHONE (NOT FULL WIDTH!) */
            .simple-pill-btn {
                width: auto !important;
                display: inline-flex !important;
                padding: 5px 12px !important;
                font-size: 11.5px !important;
                border-radius: 50px;
                box-shadow: none;
                gap: 4px;
            }

            /* Responsive Bottom Trust Features (3 Columns in 1 Row on Mobile) */
            .wishlist-features-row {
                grid-template-columns: repeat(3, 1fr);
                gap: 6px;
                padding: 12px 6px;
                margin-top: 15px;
                border-radius: 10px;
            }

            .wishlist-feature-item {
                flex-direction: column;
                align-items: center;
                text-align: center;
                gap: 4px;
                padding: 4px 2px;
            }

            .feature-icon-box {
                width: 32px;
                height: 32px;
                border-radius: 8px;
                font-size: 16px;
            }

            .feature-text-box h6 {
                font-size: 10.5px;
                font-weight: 700;
                margin: 0;
                line-height: 1.2;
            }

            .feature-desc-full {
                display: none !important;
            }

            .feature-desc-short {
                display: block !important;
                font-size: 9px;
                color: var(--wsh-muted);
                margin: 1px 0 0 0;
                line-height: 1.2;
            }

            .page-title {
                padding: 15px 0 !important;
            }

            .page-title h1 {
                font-size: 1.35rem !important;
            }

            .page-title .breadcrumbs ol {
                font-size: 0.8rem !important;
            }
        }

        /* 320px STRICT RESPONSIVE CHECK */
        @media (max-width: 380px) {
            .simple-wishlist-row {
                padding: 10px 8px;
                gap: 6px;
            }

            .row-col-product {
                gap: 8px;
            }

            .simple-thumb-link {
                width: 48px;
                height: 48px;
            }

            .simple-remove-btn {
                width: 22px;
                height: 22px;
                font-size: 11px;
            }

            .simple-product-name {
                font-size: 12px;
            }

            .row-details-bar {
                padding-top: 6px;
                gap: 4px;
            }

            .row-col-price {
                font-size: 12px;
            }

            .simple-stock-badge {
                font-size: 10px;
            }

            .simple-pill-btn {
                padding: 4px 10px !important;
                font-size: 11px !important;
            }

            .wishlist-features-row {
                gap: 4px;
                padding: 10px 4px;
            }

            .feature-icon-box {
                width: 28px;
                height: 28px;
                font-size: 14px;
            }

            .feature-text-box h6 {
                font-size: 9.5px;
            }

            .feature-desc-short {
                font-size: 8.5px;
            }
        }
    </style>

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Wishlist</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Wishlist</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Wishlist Section -->
    <section id="wishlist" class="wishlist-section-wrap">
        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row">
                <div class="col-12">

                    <!-- Simple Tabular Wishlist Box -->
                    <div class="simple-wishlist-box">

                        <!-- Table Header Strip (Themed Colored Bar as in Reference Image) -->
                        <div class="wishlist-table-header">
                            <div class="col-header-product">Product</div>
                            <div class="col-header-price">Price</div>
                            <div class="col-header-stock">Stock Status</div>
                            <div class="col-header-action">Action</div>
                        </div>

                        <!-- Wishlist Items Rows -->
                        <div class="wishlist-rows-list">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>

                                    <div class="simple-wishlist-row">

                                        <!-- Product Column (Remove Button + Thumbnail + Name) -->
                                        <div class="row-col-product">
                                            
                                            <!-- Remove (Cross Button as in Reference Image) -->
                                            <asp:LinkButton
                                                ID="btnremove"
                                                runat="server"
                                                CssClass="simple-remove-btn"
                                                CommandName="Remove"
                                                CommandArgument='<%# Eval("product_id") %>'
                                                ToolTip="Remove item">
                                                <i class="bi bi-x-lg"></i>
                                            </asp:LinkButton>

                                            <!-- Thumbnail -->
                                            <a href='product-details.aspx?id=<%# Eval("product_id") %>' class="simple-thumb-link" title="View Details">
                                                <img src='auth/<%# Eval("photo_path") %>' alt='<%# Eval("product_full_name") %>' onerror="this.onerror=null;this.src='assets/img/product/product-1.jpg';" loading="lazy">
                                            </a>

                                            <!-- Info -->
                                            <div class="simple-info-wrap">
                                                <h5 class="simple-product-name">
                                                    <a href='product-details.aspx?id=<%# Eval("product_id") %>'><%# Eval("product_full_name") %></a>
                                                </h5>
                                                <div class="simple-product-sub">
                                                    <span>Product ID: #<%# Eval("product_id") %></span>
                                                    <span class="sub-sep">|</span>
                                                    <span>Qty: <asp:Label runat="server" ID="qty"><%# Eval("wishlist_qty") %></asp:Label></span>
                                                </div>
                                            </div>

                                        </div>

                                        <!-- Row Details Bar (Price, Stock Status, Action Button) -->
                                        <div class="row-details-bar">
                                            <div class="row-col-price">
                                                Rs. <%# Eval("product_market_price") %>
                                            </div>

                                            <div class="row-col-stock">
                                                <span class="simple-stock-badge">
                                                    <i class="bi bi-check2"></i> In Stock
                                                </span>
                                            </div>

                                            <div class="row-col-action">
                                                <a href='product-details.aspx?id=<%# Eval("product_id") %>' class="simple-pill-btn">
                                                    <i class="bi bi-eye"></i> View Product
                                                </a>
                                            </div>
                                        </div>

                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>

                            <!-- Empty State -->
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <div class="simple-empty-state">
                                    <div class="simple-empty-icon">
                                        <i class="bi bi-heart"></i>
                                    </div>
                                    <h4>Your Wishlist is Empty</h4>
                                    <p>You haven't saved any items yet. Explore our furniture collection and shortlist your favorites.</p>
                                    <a href="index.aspx" class="simple-pill-btn">
                                        <i class="bi bi-bag-plus"></i> Explore Products
                                    </a>
                                </div>
                            </asp:Panel>

                        </div>

                    </div>

                    <!-- Bottom Trust Features (Matching Reference Image, Responsive 1 Row on Mobile) -->
                    <div class="wishlist-features-row">
                        <div class="wishlist-feature-item">
                            <div class="feature-icon-box">
                                <i class="bi bi-box-seam"></i>
                            </div>
                            <div class="feature-text-box">
                                <h6>Free Shipping</h6>
                                <p class="feature-desc-full">Fast doorstep delivery across India</p>
                                <p class="feature-desc-short">Fast Delivery</p>
                            </div>
                        </div>

                        <div class="wishlist-feature-item">
                            <div class="feature-icon-box">
                                <i class="bi bi-wallet2"></i>
                            </div>
                            <div class="feature-text-box">
                                <h6>Flexible Payment</h6>
                                <p class="feature-desc-full">Multiple secure online payment options</p>
                                <p class="feature-desc-short">Secure Pay</p>
                            </div>
                        </div>

                        <div class="wishlist-feature-item">
                            <div class="feature-icon-box">
                                <i class="bi bi-headset"></i>
                            </div>
                            <div class="feature-text-box">
                                <h6>24x7 Support</h6>
                                <p class="feature-desc-full">Dedicated support for our clients</p>
                                <p class="feature-desc-short">Always Online</p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </section>

</asp:Content>
