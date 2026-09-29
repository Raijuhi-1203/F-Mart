<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Scoped Styles for Amazon-inspired Order Page -->
    <style>
        /* Base Variables & Container Settings */
        :root {
            --amz-accent: #0097b2;
            --amz-accent-hover: #007d94;
            --amz-accent-soft: rgba(0, 151, 178, 0.08);
            --amz-dark: #0f172a;
            --amz-slate: #334155;
            --amz-muted: #64748b;
            --amz-border: #e2e8f0;
            --amz-card-border: #d5d9d9;
            --amz-card-bg: #ffffff;
            --amz-strip-bg: #f8fafc;
            --amz-success: #16a34a;
            --amz-warning: #ea580c;
            --amz-blue: #0284c7;
        }

        .account.section {
            padding: 40px 0 60px 0;
            background-color: #f8fafc;
            min-height: 80vh;
        }

        /* Outer Area Reset - Prevent Multi-layer Card-in-Card Nesting */
        .account .content-area {
            background: transparent !important;
            border-radius: 0 !important;
            padding: 0 !important;
            box-shadow: none !important;
            border: none !important;
        }

        .orders-grid {
            display: flex;
            flex-direction: column;
            gap: 24px;
            margin-bottom: 30px;
        }

        /* Amazon-Style Order Card */
        .amazon-order-card {
            background: var(--amz-card-bg);
            border: 1px solid var(--amz-card-border);
            border-radius: 12px;
            overflow: hidden;
            box-shadow: 0 2px 10px rgba(15, 23, 42, 0.04);
            transition: all 0.25s ease;
        }

        .amazon-order-card:hover {
            border-color: #94a3b8;
            box-shadow: 0 8px 20px rgba(15, 23, 42, 0.08);
        }

        /* Top Header Strip (Amazon Iconic Style) */
        .order-card-header {
            background-color: var(--amz-strip-bg);
            border-bottom: 1px solid #e2e8f0;
            padding: 14px 22px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            flex-wrap: wrap;
            gap: 16px;
        }

        .header-stats-left {
            display: flex;
            align-items: center;
            flex-wrap: wrap;
            gap: 24px;
        }

        .header-stat {
            display: flex;
            flex-direction: column;
            gap: 2px;
        }

        .header-stat .stat-label {
            font-size: 11px;
            font-weight: 700;
            letter-spacing: 0.6px;
            text-transform: uppercase;
            color: var(--amz-muted);
        }

        .header-stat .stat-val {
            font-size: 13.5px;
            font-weight: 600;
            color: var(--amz-dark);
            line-height: 1.3;
        }

        .header-stat .stat-val.price-val {
            color: var(--amz-accent);
            font-weight: 700;
        }

        .header-stat .stat-val.ship-val {
            display: inline-flex;
            align-items: center;
            gap: 4px;
            color: var(--amz-slate);
        }

        .header-actions-right {
            display: flex;
            align-items: center;
            flex-wrap: wrap;
            gap: 16px;
        }

        .order-id-tag {
            font-size: 12px;
            color: var(--amz-muted);
            display: flex;
            align-items: center;
            gap: 6px;
        }

        .order-id-tag .id-val {
            font-weight: 700;
            color: var(--amz-dark);
            font-size: 13.5px;
        }

        .btn-amazon-invoice {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            padding: 6px 14px;
            background: #ffffff;
            border: 1px solid #cbd5e1;
            border-radius: 8px;
            color: #334155;
            font-size: 12.5px;
            font-weight: 600;
            text-decoration: none;
            transition: all 0.2s ease;
            box-shadow: 0 1px 2px rgba(0,0,0,0.04);
        }

        .btn-amazon-invoice:hover {
            border-color: var(--amz-accent);
            color: var(--amz-accent);
            background: var(--amz-accent-soft);
            transform: translateY(-1px);
        }

        .btn-amazon-invoice i {
            font-size: 14px;
            color: var(--amz-accent);
        }

        /* Order Card Body */
        .order-card-body {
            padding: 22px 24px;
        }

        /* Status & Items Headline Bar */
        .order-status-bar {
            display: flex;
            align-items: center;
            justify-content: space-between;
            flex-wrap: wrap;
            gap: 12px;
            padding-bottom: 16px;
            margin-bottom: 20px;
            border-bottom: 1px solid #f1f5f9;
        }

        .status-badge-wrap {
            display: flex;
            align-items: center;
            gap: 10px;
            flex-wrap: wrap;
        }

        .status-pill {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            padding: 5px 14px;
            border-radius: 50px;
            font-size: 12.5px;
            font-weight: 700;
            text-transform: capitalize;
            background: rgba(0, 151, 178, 0.1);
            color: var(--amz-accent);
            border: 1px solid rgba(0, 151, 178, 0.25);
        }

        .status-pill.status-delivered {
            background: rgba(22, 163, 74, 0.1);
            color: #16a34a;
            border-color: rgba(22, 163, 74, 0.25);
        }

        .status-pill.status-processing {
            background: rgba(234, 88, 12, 0.1);
            color: #ea580c;
            border-color: rgba(234, 88, 12, 0.25);
        }

        .status-pill.status-dispatched {
            background: rgba(2, 132, 199, 0.1);
            color: #0284c7;
            border-color: rgba(2, 132, 199, 0.25);
        }

        .items-count-pill {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            font-size: 12.5px;
            color: var(--amz-muted);
            font-weight: 600;
        }

        /* Section Subheadings */
        .section-subheading {
            font-size: 14px;
            font-weight: 700;
            color: var(--amz-dark);
            margin-bottom: 14px;
            display: flex;
            align-items: center;
            gap: 8px;
        }

        .section-subheading i {
            color: var(--amz-accent);
            font-size: 15px;
        }

        /* Products List (Amazon Flat Style - No Nested Cards) */
        .amazon-products-list {
            display: flex;
            flex-direction: column;
            gap: 12px;
        }

        .amazon-product-row {
            display: flex;
            align-items: center;
            gap: 16px;
            padding: 12px 14px;
            background: #ffffff;
            border: 1px solid #f1f5f9;
            border-radius: 10px;
            transition: background-color 0.2s ease;
        }

        .amazon-product-row:hover {
            background: #fafcfc;
        }

        .product-thumb {
            width: 72px;
            height: 72px;
            border-radius: 8px;
            border: 1px solid #e2e8f0;
            background: #ffffff;
            overflow: hidden;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-shrink: 0;
        }

        .product-thumb img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

        .product-info-wrap {
            flex: 1;
            min-width: 0;
        }

        .product-name-title {
            font-size: 14px;
            font-weight: 600;
            color: var(--amz-dark);
            margin: 0 0 6px 0;
            line-height: 1.4;
            display: -webkit-box;
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
            overflow: hidden;
        }

        .product-meta-row {
            display: flex;
            align-items: center;
            gap: 14px;
            flex-wrap: wrap;
        }

        .product-qty-badge {
            font-size: 12.5px;
            color: var(--amz-muted);
            font-weight: 500;
        }

        .product-qty-badge strong {
            color: var(--amz-dark);
        }

        .product-price-val {
            font-size: 13.5px;
            font-weight: 700;
            color: var(--amz-accent);
        }

        /* Shipping Address Box (Flat, Minimal) */
        .shipping-address-card {
            background: #f8fafc;
            border: 1px solid #e2e8f0;
            border-radius: 10px;
            padding: 14px 16px;
            margin-top: 18px;
        }

        .address-card-header {
            font-size: 13px;
            font-weight: 700;
            color: var(--amz-dark);
            margin-bottom: 6px;
            display: flex;
            align-items: center;
            gap: 6px;
        }

        .address-card-header i {
            color: #ef4444;
            font-size: 14px;
        }

        .address-lines-text {
            font-size: 12.5px;
            color: var(--amz-slate);
            line-height: 1.55;
            margin-bottom: 6px;
        }

        .address-contact-text {
            font-size: 12.5px;
            color: var(--amz-muted);
            margin: 0;
            display: flex;
            align-items: center;
            gap: 6px;
        }

        .address-contact-text strong {
            color: var(--amz-dark);
        }

        /* Package Tracking (Amazon Clean Timeline) */
        .order-tracking-card {
            background: #f8fafc;
            border: 1px solid #e2e8f0;
            border-radius: 10px;
            padding: 18px 20px;
            height: 100%;
        }

        .amazon-timeline-wrap {
            position: relative;
            margin-top: 16px;
            display: flex;
            flex-direction: column;
        }

        .timeline-step-row {
            display: flex;
            align-items: flex-start;
            gap: 16px;
            position: relative;
            padding-bottom: 22px;
        }

        .timeline-step-row:last-child {
            padding-bottom: 0;
        }

        /* Connecting vertical line */
        .timeline-step-row:not(:last-child)::before {
            content: '';
            position: absolute;
            left: 15px;
            top: 32px;
            bottom: 0;
            width: 2px;
            background: #cbd5e1;
            z-index: 1;
        }

        .timeline-step-row.completed:not(:last-child)::before {
            background: #22c55e;
        }

        .timeline-step-node {
            width: 32px;
            height: 32px;
            border-radius: 50%;
            background: #ffffff;
            border: 2px solid #cbd5e1;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-shrink: 0;
            position: relative;
            z-index: 2;
            transition: all 0.3s ease;
        }

        .timeline-step-node i {
            font-size: 14px;
            color: #94a3b8;
        }

        /* Step States */
        .timeline-step-row.completed .timeline-step-node {
            background: #dcfce7;
            border-color: #22c55e;
        }

        .timeline-step-row.completed .timeline-step-node i {
            color: #16a34a;
        }

        .timeline-step-row.active .timeline-step-node {
            background: #e0f2fe;
            border-color: #0284c7;
            box-shadow: 0 0 0 3px rgba(2, 132, 199, 0.18);
        }

        .timeline-step-row.active .timeline-step-node i {
            color: #0284c7;
        }

        .timeline-step-text {
            flex: 1;
            min-width: 0;
            padding-top: 4px;
        }

        .timeline-step-text h6 {
            font-size: 13.5px;
            font-weight: 700;
            color: var(--amz-dark);
            margin: 0 0 2px 0;
            line-height: 1.3;
        }

        .timeline-step-row.active .timeline-step-text h6 {
            color: #0284c7;
        }

        .timeline-step-text p {
            font-size: 11.5px;
            color: var(--amz-muted);
            margin: 0;
            line-height: 1.4;
        }

        .timeline-step-row.active .timeline-step-text h6 {
            color: #0284c7;
        }

        .timeline-step-text p {
            font-size: 11.5px;
            color: var(--amz-muted);
            margin: 0;
            line-height: 1.4;
        }

        /* Empty State */
        .empty-orders-state {
            background: #ffffff;
            border: 1px dashed #cbd5e1;
            border-radius: 16px;
            padding: 60px 20px;
            text-align: center;
            margin: 20px 0;
        }

        .empty-orders-icon {
            width: 76px;
            height: 76px;
            border-radius: 50%;
            background: rgba(0, 151, 178, 0.08);
            color: var(--amz-accent);
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 36px;
            margin: 0 auto 18px auto;
        }

        .empty-orders-state h4 {
            font-size: 1.25rem;
            font-weight: 700;
            color: var(--amz-dark);
            margin-bottom: 8px;
        }

        .empty-orders-state p {
            font-size: 0.92rem;
            color: var(--amz-muted);
            max-width: 440px;
            margin: 0 auto 20px auto;
        }

        .btn-start-shopping {
            display: inline-flex;
            align-items: center;
            gap: 8px;
            padding: 10px 24px;
            background: var(--amz-accent);
            color: #ffffff;
            border-radius: 50px;
            font-weight: 600;
            font-size: 0.9rem;
            text-decoration: none;
            transition: all 0.25s ease;
        }

        .btn-start-shopping:hover {
            background: var(--amz-accent-hover);
            color: #ffffff;
            transform: translateY(-2px);
            box-shadow: 0 4px 12px rgba(0, 151, 178, 0.25);
        }

        /* ==============================================
           MOBILE RESPONSIVE RULES (Full width, No Nested Cards, Small Fonts)
           ============================================== */
        @media (max-width: 767px) {
            .account.section {
                padding: 15px 0 35px 0 !important;
                background-color: #f8fafc;
            }

            /* Full Width Container on Phones */
            .account .container {
                padding-left: 8px !important;
                padding-right: 8px !important;
                max-width: 100% !important;
            }

            .orders-grid {
                gap: 14px;
                margin-bottom: 20px;
            }

            /* Clean Edge-to-Edge feel for Order Card */
            .amazon-order-card {
                border-radius: 8px;
                box-shadow: 0 1px 4px rgba(0, 0, 0, 0.04);
            }

            .order-card-header {
                padding: 10px 12px;
                gap: 10px;
                flex-direction: column;
                align-items: stretch;
            }

            .header-stats-left {
                display: flex;
                justify-content: space-between;
                gap: 12px;
                width: 100%;
            }

            .header-stat .stat-label {
                font-size: 10px;
            }

            .header-stat .stat-val {
                font-size: 12px;
            }

            .header-stat .stat-val.price-val {
                font-size: 12.5px;
            }

            .header-actions-right {
                display: flex;
                justify-content: space-between;
                align-items: center;
                width: 100%;
                padding-top: 8px;
                border-top: 1px dashed #e2e8f0;
                gap: 8px;
            }

            .order-id-tag {
                font-size: 11px;
            }

            .order-id-tag .id-val {
                font-size: 12px;
            }

            .btn-amazon-invoice {
                padding: 4px 10px;
                font-size: 11px;
                border-radius: 6px;
            }

            /* Order Card Body Compact */
            .order-card-body {
                padding: 12px 10px;
            }

            .order-status-bar {
                padding-bottom: 10px;
                margin-bottom: 14px;
                gap: 8px;
            }

            .status-pill {
                padding: 4px 10px;
                font-size: 11px;
            }

            .items-count-pill {
                font-size: 11px;
            }

            .section-subheading {
                font-size: 12.5px;
                margin-bottom: 10px;
            }

            /* Compact Product Rows */
            .amazon-product-row {
                padding: 8px 10px;
                gap: 10px;
                border-radius: 8px;
            }

            .product-thumb {
                width: 58px;
                height: 58px;
                border-radius: 6px;
            }

            .product-name-title {
                font-size: 12.5px;
                margin-bottom: 4px;
                line-height: 1.3;
            }

            .product-meta-row {
                gap: 10px;
            }

            .product-qty-badge {
                font-size: 11.5px;
            }

            .product-price-val {
                font-size: 12px;
            }

            /* Compact Address */
            .shipping-address-card {
                padding: 10px 12px;
                margin-top: 14px;
                border-radius: 8px;
            }

            .address-card-header {
                font-size: 11.5px;
                margin-bottom: 4px;
            }

            .address-lines-text {
                font-size: 11.5px;
                line-height: 1.45;
                margin-bottom: 4px;
            }

            .address-contact-text {
                font-size: 11.5px;
            }

            /* Compact Tracking */
            .order-tracking-card {
                padding: 12px 14px;
                margin-top: 14px;
                border-radius: 8px;
            }

            .amazon-timeline-wrap {
                margin-top: 12px;
            }

            .timeline-step-row {
                gap: 12px;
                padding-bottom: 16px;
            }

            .timeline-step-row:not(:last-child)::before {
                left: 13px;
                top: 28px;
            }

            .timeline-step-node {
                width: 28px;
                height: 28px;
            }

            .timeline-step-node i {
                font-size: 12px;
            }

            .timeline-step-text {
                padding-top: 2px;
            }

            .timeline-step-text h6 {
                font-size: 12px;
                margin-bottom: 2px;
            }

            .timeline-step-text p {
                font-size: 10.5px;
            }

            /* Page Title Compact */
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

        @media (max-width: 380px) {
            .header-stats-left {
                gap: 8px;
            }
            .header-stat .stat-label {
                font-size: 9px;
            }
            .header-stat .stat-val {
                font-size: 11px;
            }
            .product-thumb {
                width: 50px;
                height: 50px;
            }
            .product-name-title {
                font-size: 11.5px;
            }
        }
    </style>

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Your Orders</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Your Orders</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <section id="account" class="account section">
        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row">
                <div class="col-12">
                    <div class="content-area">

                        <div class="orders-grid">

                            <!-- Repeater for Customer Orders -->
                            <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand" OnItemDataBound="rptbinddata_ItemDataBound">
                                <ItemTemplate>

                                    <!-- Amazon Style Unified Order Card (No Nested Cards) -->
                                    <div class="amazon-order-card" data-aos="fade-up" data-aos-delay="100">

                                        <!-- Top Strip Header (Order Placed, Total, Ship To, Order ID & Invoice Link) -->
                                        <div class="order-card-header">
                                            <div class="header-stats-left">
                                                <div class="header-stat">
                                                    <span class="stat-label">Order Placed</span>
                                                    <span class="stat-val"><%# Eval("order_date") %></span>
                                                </div>
                                                <div class="header-stat">
                                                    <span class="stat-label">Total</span>
                                                    <span class="stat-val price-val">Rs. <%# Eval("total_order_amount") %></span>
                                                </div>
                                                <div class="header-stat">
                                                    <span class="stat-label">Ship To</span>
                                                    <span class="stat-val ship-val">
                                                        <%# Eval("billing_city_name") %>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="header-actions-right">
                                                <div class="order-id-tag">
                                                    <span>Order #</span>
                                                    <asp:Label class="id-val" id="order_id" runat="server" Text='<%# Eval("order_id") %>'></asp:Label>
                                                </div>
                                                <a href='print-bill.aspx?ref=<%# Eval("order_id") %>' target="_blank" class="btn-amazon-invoice" title="View or Print Invoice">
                                                    <i class="bi bi-printer"></i>
                                                    <span>Invoice</span>
                                                </a>
                                            </div>
                                        </div>

                                        <!-- Card Main Body -->
                                        <div class="order-card-body">

                                            <!-- Order Status & Items Counter Bar -->
                                            <div class="order-status-bar">
                                                <div class="status-badge-wrap">
                                                    <span class="status-pill status-<%# Eval("order_status").ToString().ToLower().Trim() %>">
                                                        <i class="bi bi-clock-history"></i> <%# Eval("order_status") %>
                                                    </span>
                                                    <span class="items-count-pill">
                                                        <i class="bi bi-box2"></i> <%# Eval("total_item") %> Item(s)
                                                    </span>
                                                </div>
                                            </div>

                                            <!-- Main Content Columns (Products + Address on Left, Tracker on Right) -->
                                            <div class="row g-3 g-lg-4">

                                                <!-- Left Column: Ordered Items List & Shipping Address -->
                                                <div class="col-lg-7">
                                                    
                                                    <h6 class="section-subheading">
                                                        <i class="bi bi-bag-check-fill"></i> Items in this Order
                                                    </h6>

                                                    <!-- Flat Amazon Products List -->
                                                    <div class="amazon-products-list">
                                                        <asp:Repeater ID="ChildRepeater" runat="server">
                                                            <ItemTemplate>
                                                                <div class="amazon-product-row">
                                                                    <div class="product-thumb">
                                                                        <img src='auth/<%# Eval("product_photo") %>' alt='<%# Eval("product_name") %>' onerror="this.onerror=null;this.src='assets/img/product/product-1.jpg';" loading="lazy">
                                                                    </div>
                                                                    <div class="product-info-wrap">
                                                                        <h6 class="product-name-title"><%# Eval("product_name") %></h6>
                                                                        <div class="product-meta-row">
                                                                            <span class="product-qty-badge">Qty: <strong><%# Eval("product_qty") %></strong></span>
                                                                            <span class="product-price-val">Rs. <%# Eval("product_market_price") %></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>

                                                    <!-- Clean Shipping Address Block -->
                                                    <div class="shipping-address-card">
                                                        <div class="address-card-header">
                                                            <i class="bi bi-geo-alt-fill"></i> Delivery Address
                                                        </div>
                                                        <p class="address-lines-text">
                                                            <%# Eval("billing_address_line1") %>, 
                                                            <%# Eval("billing_address_line2") %>, 
                                                            <%# Eval("billing_city_name") %>, 
                                                            <%# Eval("billing_state_name") %> - 
                                                            <%# Eval("billing_pincode") %>
                                                        </p>
                                                        <p class="address-contact-text">
                                                            <i class="bi bi-telephone-fill"></i> Contact: <strong><%# Eval("customer_mobileno") %></strong>
                                                        </p>
                                                    </div>

                                                </div>

                                                <!-- Right Column: Clean Package Tracking Timeline -->
                                                <div class="col-lg-5">
                                                    <div class="order-tracking-card">
                                                        <h6 class="section-subheading">
                                                            <i class="bi bi-truck"></i> Package Tracking
                                                        </h6>

                                                        <div class="amazon-timeline-wrap">

                                                            <!-- Step 1: Processing -->
                                                            <div class="timeline-step-row completed">
                                                                <div class="timeline-step-node">
                                                                    <i id="processing" runat="server" class="bi bi-check-circle-fill"></i>
                                                                </div>
                                                                <div class="timeline-step-text">
                                                                    <h6>Processing</h6>
                                                                    <p>Order received and prepared for shipping</p>
                                                                </div>
                                                            </div>

                                                            <!-- Step 2: Confirmed -->
                                                            <div class="timeline-step-row completed">
                                                                <div class="timeline-step-node">
                                                                    <i id="confirm" runat="server" class="bi bi-box-seam"></i>
                                                                </div>
                                                                <div class="timeline-step-text">
                                                                    <h6>Confirmed</h6>
                                                                    <p>Order verified and packed at facility</p>
                                                                </div>
                                                            </div>

                                                            <!-- Step 3: Dispatched -->
                                                            <div class="timeline-step-row active">
                                                                <div class="timeline-step-node">
                                                                    <i id="dispatch" runat="server" class="bi bi-truck"></i>
                                                                </div>
                                                                <div class="timeline-step-text">
                                                                    <h6>Dispatched</h6>
                                                                    <p>Items in transit with courier partner</p>
                                                                </div>
                                                            </div>

                                                            <!-- Step 4: Delivered -->
                                                            <div class="timeline-step-row">
                                                                <div class="timeline-step-node">
                                                                    <i id="deliver" runat="server" class="bi bi-house-door"></i>
                                                                </div>
                                                                <div class="timeline-step-text">
                                                                    <h6>Delivered</h6>
                                                                    <p>Package delivered to destination address</p>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>

                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>

                            <!-- Modern Empty State if No Orders Found -->
                            <asp:Panel ID="NoDataPanel" runat="server" Visible="false">
                                <div class="empty-orders-state">
                                    <div class="empty-orders-icon">
                                        <i class="bi bi-bag-x"></i>
                                    </div>
                                    <h4>No Orders Found</h4>
                                    <p>Your order history is empty! Browse our premium furniture collection and start creating your dream space.</p>
                                    <a href="index.aspx" class="btn-start-shopping">
                                        <i class="bi bi-cart-plus"></i> Start Shopping
                                    </a>
                                </div>
                            </asp:Panel>

                        </div>

                    </div>
                </div>
            </div>

        </div>
    </section>

</asp:Content>
