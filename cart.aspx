<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Scoped Styles for Amazon-inspired Cart Page -->
    <style>
        :root {
            --amz-accent: #0097b2;
            --amz-accent-hover: #007d94;
            --amz-accent-soft: rgba(0, 151, 178, 0.08);
            --amz-btn-yellow: #ffd814;
            --amz-btn-yellow-hover: #f7ca00;
            --amz-dark: #0f172a;
            --amz-slate: #334155;
            --amz-muted: #64748b;
            --amz-border: #e2e8f0;
            --amz-card-border: #d5d9d9;
            --amz-card-bg: #ffffff;
            --amz-green: #007600;
            --amz-red: #b12704;
        }

        .cart.section {
            padding: 30px 0 60px 0;
            background-color: #f8fafc;
            min-height: 80vh;
        }

        /* Amazon Main Shopping Cart Container */
        .amazon-cart-card {
            background: #ffffff;
            border: 1px solid var(--amz-card-border);
            border-radius: 12px;
            padding: 24px;
            box-shadow: 0 2px 10px rgba(15, 23, 42, 0.04);
            margin-bottom: 24px;
        }

        /* Cart Main Header */
        .amazon-cart-header {
            padding-bottom: 16px;
            border-bottom: 1px solid #e2e8f0;
            margin-bottom: 8px;
        }

        .cart-header-top {
            display: flex;
            justify-content: space-between;
            align-items: flex-end;
            flex-wrap: wrap;
            gap: 10px;
        }

        .amazon-cart-title {
            font-size: 1.55rem;
            font-weight: 800;
            color: var(--amz-dark);
            margin: 0;
            letter-spacing: -0.3px;
        }

        .price-header-tag {
            font-size: 13px;
            font-weight: 600;
            color: var(--amz-muted);
            text-transform: uppercase;
            letter-spacing: 0.5px;
        }

        .cart-header-sub {
            display: flex;
            align-items: center;
            gap: 8px;
            margin-top: 6px;
            font-size: 12.5px;
            color: var(--amz-muted);
        }

        .cart-header-sub i {
            color: #16a34a;
        }

        /* Amazon Cart Items List */
        .amazon-cart-list {
            display: flex;
            flex-direction: column;
        }

        .amazon-cart-item {
            padding: 20px 0;
            border-bottom: 1px solid #f1f5f9;
            transition: background-color 0.2s ease;
        }

        .amazon-cart-item:last-child {
            border-bottom: none;
            padding-bottom: 8px;
        }

        /* Top Row of Item: Image + Title + Price */
        .item-top-row {
            display: flex;
            gap: 18px;
            align-items: flex-start;
        }

        /* Product Image Box */
        .item-image-box {
            width: 105px;
            height: 105px;
            border-radius: 8px;
            border: 1px solid #e2e8f0;
            background: #ffffff;
            overflow: hidden;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-shrink: 0;
            padding: 6px;
        }

        .item-image-box img {
            max-width: 100%;
            max-height: 100%;
            object-fit: contain;
            transition: transform 0.3s ease;
        }

        .amazon-cart-item:hover .item-image-box img {
            transform: scale(1.04);
        }

        /* Product Info Center */
        .item-details-box {
            flex: 1;
            min-width: 0;
        }

        .item-product-name {
            font-size: 15.5px;
            font-weight: 600;
            color: var(--amz-dark);
            margin: 0 0 6px 0;
            line-height: 1.35;
        }

        .stock-badge-row {
            display: flex;
            align-items: center;
            gap: 14px;
            flex-wrap: wrap;
            margin-bottom: 8px;
        }

        .stock-in-text {
            font-size: 12.5px;
            font-weight: 700;
            color: var(--amz-green);
            display: inline-flex;
            align-items: center;
            gap: 4px;
        }

        .shipping-eligibility-text {
            font-size: 12px;
            color: var(--amz-muted);
            display: inline-flex;
            align-items: center;
            gap: 4px;
        }

        .shipping-eligibility-text i {
            color: var(--amz-accent);
        }

        /* Item Price Column (Right Side) */
        .item-price-box {
            text-align: right;
            flex-shrink: 0;
            min-width: 100px;
        }

        .item-total-price {
            font-size: 1.15rem;
            font-weight: 800;
            color: var(--amz-dark);
            line-height: 1.2;
        }

        .item-unit-price {
            font-size: 12px;
            color: var(--amz-muted);
            margin-top: 4px;
        }

        /* Amazon Controls Bar (Qty + Delete + Cart ID) - ALWAYS 1 ROW */
        .item-actions-controls {
            display: flex;
            align-items: center;
            gap: 12px;
            flex-wrap: nowrap !important;
            white-space: nowrap !important;
            margin-top: 12px;
            margin-left: 123px; /* Aligns underneath details text on desktop */
        }

        /* Stepper Quantity Pill */
        .amazon-qty-pill {
            display: inline-flex;
            align-items: center;
            background: #f8fafc;
            border: 1px solid #cbd5e1;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 1px 2px rgba(0,0,0,0.04);
            flex-shrink: 0;
        }

        .qty-step-btn {
            background: none;
            border: none;
            width: 30px;
            height: 30px;
            display: flex;
            align-items: center;
            justify-content: center;
            color: var(--amz-slate);
            font-weight: 700;
            font-size: 14px;
            cursor: pointer;
            transition: all 0.2s ease;
            outline: none;
            padding: 0;
            line-height: 1;
        }

        .qty-step-btn:hover {
            background-color: rgba(0, 151, 178, 0.1);
            color: var(--amz-accent);
        }

        .qty-step-btn:active {
            background-color: rgba(0, 151, 178, 0.2);
        }

        .qty-input-box {
            width: 36px;
            height: 30px;
            text-align: center;
            border: none;
            border-left: 1px solid #e2e8f0;
            border-right: 1px solid #e2e8f0;
            font-size: 13px;
            font-weight: 700;
            color: var(--amz-dark);
            background: #ffffff;
            outline: none;
            padding: 0;
        }

        .qty-input-box::-webkit-inner-spin-button,
        .qty-input-box::-webkit-outer-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        .action-divider {
            color: #cbd5e1;
            font-size: 14px;
            flex-shrink: 0;
            user-select: none;
        }

        /* Remove Action Link */
        .amazon-remove-btn {
            color: #007185;
            font-size: 12.5px;
            font-weight: 600;
            text-decoration: none;
            display: inline-flex;
            align-items: center;
            gap: 4px;
            transition: color 0.2s ease;
            background: none;
            border: none;
            padding: 0;
            cursor: pointer;
            flex-shrink: 0;
            white-space: nowrap;
        }

        .amazon-remove-btn:hover {
            color: #c40000;
            text-decoration: underline;
        }

        .cart-ref-tag {
            font-size: 11px;
            color: var(--amz-muted);
            background: #f1f5f9;
            padding: 3px 8px;
            border-radius: 4px;
            flex-shrink: 0;
            white-space: nowrap;
        }

        /* Cart Footer Actions Bar (Update & Clear) */
        .amazon-cart-footer {
            display: flex;
            justify-content: space-between;
            align-items: center;
            flex-wrap: wrap;
            gap: 16px;
            padding-top: 20px;
            margin-top: 14px;
            border-top: 1px solid #e2e8f0;
        }

        .cart-actions-group {
            display: flex;
            align-items: center;
            gap: 10px;
            flex-wrap: wrap;
        }

        .btn-amazon-secondary {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            padding: 7px 16px;
            background: #ffffff;
            border: 1px solid #cbd5e1;
            border-radius: 8px;
            color: #334155;
            font-size: 12.5px;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.2s ease;
            box-shadow: 0 1px 2px rgba(0,0,0,0.04);
        }

        .btn-amazon-secondary:hover {
            border-color: var(--amz-accent);
            color: var(--amz-accent);
            background: var(--amz-accent-soft);
        }

        .btn-amazon-secondary.btn-danger-soft:hover {
            border-color: #ef4444;
            color: #dc2626;
            background: #fef2f2;
        }

        /* Right Summary Box (Amazon Sticky Proceed-to-Buy Card) */
        .amazon-summary-card {
            background: #ffffff;
            border: 1px solid var(--amz-card-border);
            border-radius: 12px;
            padding: 22px;
            box-shadow: 0 2px 10px rgba(15, 23, 42, 0.04);
            position: sticky;
            top: 90px;
        }

        .free-delivery-badge-box {
            display: flex;
            align-items: flex-start;
            gap: 8px;
            padding: 10px 12px;
            background: #f0fdf4;
            border: 1px solid #bbf7d0;
            border-radius: 8px;
            font-size: 12px;
            color: #166534;
            line-height: 1.45;
            margin-bottom: 18px;
        }

        .free-delivery-badge-box i {
            font-size: 15px;
            color: #16a34a;
            flex-shrink: 0;
            margin-top: 1px;
        }

        .summary-headline-wrap {
            margin-bottom: 16px;
        }

        .summary-headline-label {
            font-size: 1.05rem;
            font-weight: 700;
            color: var(--amz-dark);
            margin-bottom: 4px;
        }

        /* Amazon Checkout Button (High Contrast & Clear) */
        .btn-amazon-proceed {
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
            width: 100%;
            padding: 12px 18px;
            background: var(--amz-accent);
            color: #ffffff;
            border: 1px solid var(--amz-accent);
            border-radius: 50px;
            font-size: 14.5px;
            font-weight: 700;
            text-decoration: none;
            box-shadow: 0 2px 6px rgba(0, 151, 178, 0.2);
            transition: all 0.25s ease;
            margin-bottom: 18px;
        }

        .btn-amazon-proceed:hover {
            background: var(--amz-accent-hover);
            color: #ffffff;
            transform: translateY(-1px);
            box-shadow: 0 4px 12px rgba(0, 151, 178, 0.3);
        }

        /* Breakdown Table Inside Summary */
        .summary-rows-wrap {
            border-top: 1px solid #f1f5f9;
            padding-top: 14px;
            margin-bottom: 16px;
        }

        .summary-calc-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 10px;
            font-size: 13.5px;
            color: var(--amz-slate);
        }

        .summary-calc-row .row-label {
            color: var(--amz-muted);
        }

        .summary-calc-row .row-val {
            font-weight: 600;
            color: var(--amz-dark);
        }

        .summary-calc-row.total-row {
            border-top: 1px dashed #e2e8f0;
            padding-top: 12px;
            margin-top: 6px;
            font-size: 16px;
            font-weight: 800;
        }

        .summary-calc-row.total-row .row-val {
            color: var(--amz-accent);
            font-size: 1.15rem;
            font-weight: 800;
        }

        .btn-amazon-continue {
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 6px;
            width: 100%;
            padding: 9px 14px;
            background: #ffffff;
            border: 1px solid #cbd5e1;
            border-radius: 50px;
            color: #334155;
            font-size: 13px;
            font-weight: 600;
            text-decoration: none;
            transition: all 0.2s ease;
            margin-bottom: 18px;
        }

        .btn-amazon-continue:hover {
            border-color: var(--amz-accent);
            color: var(--amz-accent);
            background: var(--amz-accent-soft);
        }

        /* Trust & Security Notes */
        .amazon-trust-box {
            background: #f8fafc;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            padding: 12px;
            text-align: center;
        }

        .trust-text {
            font-size: 11.5px;
            color: var(--amz-muted);
            margin-bottom: 8px;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 6px;
        }

        .trust-text i {
            color: #16a34a;
            font-size: 13px;
        }

        .payment-icons-strip {
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 14px;
            color: #94a3b8;
            font-size: 18px;
        }

        /* ==============================================
           MOBILE RESPONSIVE RULES (1 Single Row Guaranteed on 320px)
           ============================================== */
        @media (max-width: 767px) {
            .cart.section {
                padding: 15px 0 35px 0 !important;
            }

            .cart .container {
                padding-left: 8px !important;
                padding-right: 8px !important;
                max-width: 100% !important;
            }

            .amazon-cart-card {
                padding: 12px 10px;
                border-radius: 8px;
                margin-bottom: 14px;
            }

            .amazon-cart-title {
                font-size: 1.25rem;
            }

            .price-header-tag {
                display: none;
            }

            .item-top-row {
                gap: 10px;
            }

            /* Compact Image on Mobile */
            .item-image-box {
                width: 68px;
                height: 68px;
                padding: 4px;
                border-radius: 6px;
            }

            .item-product-name {
                font-size: 13px;
                margin-bottom: 4px;
                line-height: 1.3;
                display: -webkit-box;
                -webkit-line-clamp: 2;
                -webkit-box-orient: vertical;
                overflow: hidden;
            }

            .stock-badge-row {
                gap: 8px;
                margin-bottom: 4px;
            }

            .stock-in-text {
                font-size: 11px;
            }

            .shipping-eligibility-text {
                font-size: 10.5px;
            }

            .item-price-box {
                text-align: right;
                min-width: auto;
            }

            .item-total-price {
                font-size: 13px;
                font-weight: 800;
            }

            .item-unit-price {
                font-size: 10.5px;
                margin-top: 2px;
            }

            /* Controls on Mobile - FULL WIDTH ROW, NEVER WRAP */
            .item-actions-controls {
                margin-left: 0 !important;
                width: 100% !important;
                display: flex !important;
                align-items: center !important;
                flex-wrap: nowrap !important;
                white-space: nowrap !important;
                gap: 8px;
                margin-top: 10px;
                padding-top: 8px;
                border-top: 1px dashed #f1f5f9;
            }

            .qty-step-btn {
                width: 24px;
                height: 24px;
                font-size: 12px;
            }

            .qty-input-box {
                width: 28px;
                height: 24px;
                font-size: 12px;
            }

            .action-divider {
                font-size: 12px;
                color: #e2e8f0;
            }

            .amazon-remove-btn {
                font-size: 11.5px;
            }

            .cart-ref-tag {
                font-size: 10.5px;
                padding: 2px 6px;
            }

            .amazon-cart-footer {
                padding-top: 14px;
                gap: 10px;
                flex-direction: column;
                align-items: stretch;
            }

            .cart-actions-group {
                justify-content: space-between;
                width: 100%;
            }

            .btn-amazon-secondary {
                padding: 6px 12px;
                font-size: 11.5px;
                flex: 1;
                justify-content: center;
            }

            .amazon-summary-card {
                padding: 16px 14px;
                border-radius: 8px;
                position: static;
            }

            .btn-amazon-proceed {
                padding: 10px 14px;
                font-size: 13.5px;
            }

            .summary-calc-row {
                font-size: 12.5px;
            }

            .summary-calc-row.total-row {
                font-size: 14px;
            }

            .summary-calc-row.total-row .row-val {
                font-size: 1rem;
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

        /* STRICT 320px BREAKPOINT RULES: Compact and Guaranteed 1 Single Row */
        @media (max-width: 380px) {
            .amazon-cart-card {
                padding: 10px 8px;
            }

            .item-top-row {
                gap: 8px;
            }

            .item-image-box {
                width: 56px;
                height: 56px;
                padding: 2px;
            }

            .item-product-name {
                font-size: 12px;
            }

            .item-total-price {
                font-size: 12px;
            }

            .item-unit-price {
                font-size: 9.5px;
            }

            .item-actions-controls {
                gap: 6px;
                margin-top: 8px;
                padding-top: 6px;
                flex-wrap: nowrap !important;
                white-space: nowrap !important;
            }

            .qty-step-btn {
                width: 22px;
                height: 22px;
                font-size: 11px;
            }

            .qty-input-box {
                width: 24px;
                height: 22px;
                font-size: 11px;
            }

            .action-divider {
                font-size: 11px;
            }

            .amazon-remove-btn {
                font-size: 11px;
            }

            .cart-ref-tag {
                font-size: 9.5px;
                padding: 1px 5px;
            }
        }
    </style>

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Shopping Cart</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Shopping Cart</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- Cart Section -->
    <section id="cart" class="cart section">
        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row g-3 g-lg-4">

                <!-- Left Column: Amazon Style Shopping Cart Items List -->
                <div class="col-lg-8" data-aos="fade-up" data-aos-delay="150">
                    <div class="amazon-cart-card">

                        <!-- Cart Card Header -->
                        <div class="amazon-cart-header">
                            <div class="cart-header-top">
                                <h2 class="amazon-cart-title">Shopping Cart</h2>
                                <span class="price-header-tag">Price</span>
                            </div>
                            <div class="cart-header-sub">
                                <i class="bi bi-shield-check"></i>
                                <span>Verified Items from F-Mart Authentic Collection</span>
                            </div>
                        </div>

                        <!-- Repeater for Cart Products -->
                        <div class="amazon-cart-list">
                            <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                                <ItemTemplate>

                                    <!-- Single Amazon Cart Item Row -->
                                    <div class="amazon-cart-item">
                                        
                                        <!-- Top Row: Image + Details + Price -->
                                        <div class="item-top-row">

                                            <!-- Product Image Box -->
                                            <div class="item-image-box">
                                                <img src='auth/<%# Eval("photo_path") %>' alt='<%# Eval("product_full_name") %>' onerror="this.onerror=null;this.src='assets/img/product/product-1.jpg';" loading="lazy">
                                            </div>

                                            <!-- Product Details Center -->
                                            <div class="item-details-box">
                                                <h4 class="item-product-name"><%# Eval("product_full_name") %></h4>

                                                <div class="stock-badge-row">
                                                    <span class="stock-in-text">
                                                        <i class="bi bi-check-circle-fill"></i> In Stock
                                                    </span>
                                                    <span class="shipping-eligibility-text">
                                                        <i class="bi bi-truck"></i> Standard Delivery
                                                    </span>
                                                </div>
                                            </div>

                                            <!-- Item Price Column (Right Side) -->
                                            <div class="item-price-box">
                                                <div class="item-total-price">
                                                    Rs. <asp:Label ID="total" runat="server"><%# Eval("total") %></asp:Label>
                                                </div>
                                                <div class="item-unit-price">
                                                    Unit: Rs. <asp:Label ID="mrp" runat="server"><%# Eval("product_market_price") %></asp:Label>
                                                </div>
                                            </div>

                                        </div>

                                        <!-- Amazon Style Quantity Stepper & Actions (ALWAYS 1 SINGLE ROW) -->
                                        <div class="item-actions-controls">
                                            <div class="amazon-qty-pill">
                                                <asp:Button class="qty-step-btn decrease" CommandName="Minus" CommandArgument='<%# Eval("product_id") %>' ID="btnminus" runat="server" Text="-"></asp:Button>
                                                <asp:TextBox runat="server" type="number" class="qty-input-box" value='<%# Eval("cart_qty") %>' ID="changeqty"></asp:TextBox>
                                                <asp:Button class="qty-step-btn increase" CommandName="Add" CommandArgument='<%# Eval("product_id") %>' ID="btnadd" runat="server" Text="+"></asp:Button>
                                            </div>

                                            <span class="action-divider">|</span>

                                            <asp:LinkButton
                                                ID="btnremove"
                                                runat="server"
                                                CssClass="amazon-remove-btn"
                                                CommandName="Remove"
                                                CommandArgument='<%# Eval("cart_id") %>'>
                                                <i class="bi bi-trash3"></i> Delete
                                            </asp:LinkButton>

                                            <span class="action-divider">|</span>

                                            <span class="cart-ref-tag">Cart #<%# Eval("cart_id") %></span>
                                        </div>

                                    </div>
                                    <!-- End Single Cart Item -->

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <!-- Cart Bottom Footer Actions (Update & Clear Buttons) -->
                        <div class="amazon-cart-footer">
                            <div class="cart-actions-group">
                                <button class="btn-amazon-secondary" id="btnupdatecart" runat="server" onserverclick="btnupdatecart_ServerClick">
                                    <i class="bi bi-arrow-clockwise"></i> Update Cart
                                </button>
                                <button class="btn-amazon-secondary btn-danger-soft" id="btnclearcart" runat="server" onserverclick="btnclearcart_ServerClick">
                                    <i class="bi bi-trash"></i> Clear All Items
                                </button>
                            </div>
                        </div>

                    </div>
                </div>

                <!-- Right Column: Amazon Sticky Checkout & Order Summary Box -->
                <div class="col-lg-4" data-aos="fade-up" data-aos-delay="250">
                    <div class="amazon-summary-card">

                        <!-- Free Delivery Status Banner -->
                        <div class="free-delivery-badge-box">
                            <i class="bi bi-check-circle-fill"></i>
                            <span>Part of your order qualifies for verified <strong>FREE/Standard Delivery</strong> in India.</span>
                        </div>

                        <!-- Subtotal Headline -->
                        <div class="summary-headline-wrap">
                            <div class="summary-headline-label">Ready to Order?</div>
                        </div>

                        <!-- Primary Amazon Style Proceed to Checkout CTA -->
                        <a href="checkout.aspx" class="btn-amazon-proceed">
                            Proceed to Checkout <i class="bi bi-arrow-right"></i>
                        </a>

                        <!-- Calculation Breakdown Table -->
                        <div class="summary-rows-wrap">
                            <div class="summary-calc-row">
                                <span class="row-label">Items Subtotal:</span>
                                <span class="row-val"><span class="summary-value" id="subtotal" runat="server">Rs. 0.00</span></span>
                            </div>

                            <div class="summary-calc-row">
                                <span class="row-label">Delivery Fee:</span>
                                <span class="row-val text-success">
                                    <input class="form-check-input d-none" type="radio" name="shipping" id="standard" checked="" />
                                    Rs. 100.00
                                </span>
                            </div>

                            <div class="summary-calc-row total-row">
                                <span class="row-label">Order Total:</span>
                                <span class="row-val"><span class="summary-value" id="totalamt" runat="server">Rs. 0.00</span></span>
                            </div>
                        </div>

                        <!-- Continue Shopping Button -->
                        <a href="index.aspx" class="btn-amazon-continue">
                            <i class="bi bi-arrow-left"></i> Continue Shopping
                        </a>

                        <!-- Amazon Trust & Security Badges -->
                        <div class="amazon-trust-box">
                            <div class="trust-text">
                                <i class="bi bi-shield-check"></i> 100% Safe & Secure Payments
                            </div>
                            <div class="payment-icons-strip">
                                <i class="bi bi-credit-card-2-front" title="Credit / Debit Card"></i>
                                <i class="bi bi-wallet2" title="UPI & Netbanking"></i>
                                <i class="bi bi-bank" title="Bank Transfer"></i>
                                <i class="bi bi-shield-lock" title="SSL Encrypted"></i>
                            </div>
                        </div>

                    </div>
                </div>

            </div>

        </div>
    </section>
    <!-- /Cart Section -->

</asp:Content>
