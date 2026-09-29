<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="product-details.aspx.cs"
    Inherits="product_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Amazon-Style Product Details CSS -->
    <style>
        :root {
            --amz-font: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
            --amz-dark: #0f1111;
            --amz-link: #007185;
            --amz-link-hover: #c7511f;
            --amz-price-red: #cc0c39;
            --amz-gold: #ffa41c;
            --amz-gold-hover: #fa8900;
            --amz-yellow: #ffd814;
            --amz-yellow-hover: #f7ca00;
            --amz-border: #d5d9d9;
            --amz-text-muted: #565959;
            --amz-card-bg: #ffffff;
            --amz-pill-choice: #232f3e;
        }

        body {
            font-family: var(--amz-font);
            color: var(--amz-dark);
            background-color: #ffffff;
        }

        /* Top Breadcrumb Bar */
        .amz-breadcrumb-bar {
            background-color: #fafafa;
            border-bottom: 1px solid #e7e7e7;
            padding: 10px 0;
            font-size: 12px;
            color: var(--amz-text-muted);
        }

        .amz-breadcrumbs a {
            color: var(--amz-text-muted);
            text-decoration: none;
            transition: color 0.2s;
        }

            .amz-breadcrumbs a:hover {
                color: var(--amz-link-hover);
                text-decoration: underline;
            }

        .amz-bc-divider {
            margin: 0 6px;
            color: #888;
        }

        .amz-bc-current {
            color: var(--amz-dark);
            font-weight: 600;
        }

        /* Product Details Container */
        .amz-product-wrapper {
            padding: 20px 0 50px 0;
            background: #fff;
        }

        /* ---------------- LEFT: Gallery Column ---------------- */
        .amz-gallery-col {
            position: relative;
        }

        .amz-gallery-sticky {
            position: sticky;
            top: 20px;
        }

        .amz-main-image-box {
            position: relative;
            background: #ffffff;
            border: 1px solid #e7e7e7;
            border-radius: 8px;
            padding: 16px;
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 380px;
            max-height: 480px;
            overflow: hidden;
            transition: border-color 0.25s;
        }

            .amz-main-image-box:hover {
                border-color: #bbb;
            }

        .amz-main-img {
            max-width: 100%;
            max-height: 440px;
            object-fit: contain;
            transition: transform 0.35s ease;
            cursor: zoom-in;
        }

            .amz-main-img:hover {
                transform: scale(1.04);
            }

        .amz-gallery-share-btn {
            position: absolute;
            top: 14px;
            right: 14px;
            background: #fff;
            border: 1px solid #d5d9d9;
            border-radius: 50%;
            width: 38px;
            height: 38px;
            display: flex;
            align-items: center;
            justify-content: center;
            color: #333;
            cursor: pointer;
            box-shadow: 0 2px 5px rgba(0,0,0,0.08);
            transition: all 0.2s;
            z-index: 5;
        }

            .amz-gallery-share-btn:hover {
                background: #f7fafa;
                border-color: #888;
            }

        .amz-view-hint {
            text-align: center;
            font-size: 12px;
            color: var(--amz-text-muted);
            margin-top: 8px;
            margin-bottom: 12px;
        }

        /* Thumbnails Strip */
        .amz-thumbnails-container {
            display: flex;
            gap: 10px;
            justify-content: center;
            flex-wrap: wrap;
            margin-top: 12px;
        }

        .amz-thumb-wrapper {
            width: 58px;
            height: 58px;
            border: 1px solid var(--amz-border);
            border-radius: 6px;
            padding: 3px;
            cursor: pointer;
            background: #fff;
            display: flex;
            align-items: center;
            justify-content: center;
            transition: all 0.2s ease;
        }

            .amz-thumb-wrapper:hover,
            .amz-thumb-wrapper.active {
                border: 2px solid #e77600;
                box-shadow: 0 0 4px rgba(231, 118, 0, 0.4);
            }

            .amz-thumb-wrapper img {
                max-width: 100%;
                max-height: 100%;
                object-fit: contain;
            }

        /* ---------------- CENTER: Details Column ---------------- */
        .amz-center-col {
            padding: 0 15px;
        }

        .amz-product-title {
            font-size: 20px;
            font-weight: 600;
            line-height: 1.35;
            color: var(--amz-dark);
            margin: 0 0 6px 0;
            letter-spacing: -0.01em;
        }

        .amz-brand-link {
            display: inline-block;
            color: var(--amz-link);
            font-size: 13px;
            text-decoration: none;
            margin-bottom: 8px;
            font-weight: 500;
        }

            .amz-brand-link:hover {
                color: var(--amz-link-hover);
                text-decoration: underline;
            }

        /* Rating & Badge Row */
        .amz-rating-row {
            display: flex;
            align-items: center;
            flex-wrap: wrap;
            gap: 10px;
            font-size: 13px;
            margin-bottom: 8px;
        }

        .amz-stars {
            color: #de7921;
            letter-spacing: 1px;
            font-size: 14px;
        }

        .amz-rating-score {
            font-weight: 600;
            color: var(--amz-dark);
            margin-left: 2px;
        }

        .amz-reviews-link {
            color: var(--amz-link);
            text-decoration: none;
        }

            .amz-reviews-link:hover {
                color: var(--amz-link-hover);
                text-decoration: underline;
            }

        .amz-choice-badge {
            background-color: var(--amz-pill-choice);
            color: #fff;
            font-size: 11px;
            font-weight: 700;
            padding: 3px 8px;
            border-radius: 3px;
            display: inline-flex;
            align-items: center;
            gap: 4px;
        }

            .amz-choice-badge .badge-highlight {
                color: #e77600;
            }

        .amz-past-bought {
            font-size: 12px;
            color: var(--amz-text-muted);
            margin-bottom: 12px;
        }

            .amz-past-bought strong {
                color: var(--amz-dark);
            }

        .amz-divider {
            border: 0;
            border-top: 1px solid #e7e7e7;
            margin: 14px 0;
        }

        /* Pricing Section */
        .amz-price-box {
            margin-bottom: 12px;
        }

        .amz-price-main-line {
            display: flex;
            align-items: baseline;
            gap: 8px;
        }

        .amz-discount-percentage {
            color: var(--amz-price-red);
            font-size: 26px;
            font-weight: 300;
            line-height: 1;
        }

        .amz-sale-price {
            font-size: 28px;
            font-weight: 700;
            color: var(--amz-dark);
            line-height: 1;
        }

        .amz-mrp-line {
            font-size: 13px;
            color: var(--amz-text-muted);
            margin-top: 4px;
        }

        .amz-regular-price {
            text-decoration: line-through;
        }

        .amz-savings-amount {
            color: var(--amz-price-red);
            font-weight: 600;
            margin-left: 6px;
        }

        .amz-tax-notice {
            font-size: 12px;
            color: var(--amz-dark);
            margin-top: 3px;
        }

        .amz-emi-banner {
            font-size: 13px;
            color: var(--amz-dark);
            margin-top: 6px;
        }

            .amz-emi-banner a {
                color: var(--amz-link);
                text-decoration: none;
                font-weight: 500;
            }

                .amz-emi-banner a:hover {
                    color: var(--amz-link-hover);
                    text-decoration: underline;
                }

        /* Offers Section (Cards) */
        .amz-offers-section {
            margin: 14px 0;
        }

        .amz-offers-title {
            font-size: 14px;
            font-weight: 700;
            color: var(--amz-dark);
            display: flex;
            align-items: center;
            gap: 6px;
            margin-bottom: 10px;
        }

            .amz-offers-title i {
                color: #c7511f;
                font-size: 16px;
            }

        .amz-offers-grid {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 10px;
        }

        .amz-offer-card {
            border: 1px solid var(--amz-border);
            border-radius: 8px;
            padding: 10px 12px;
            background: #fff;
            box-shadow: 0 1px 3px rgba(0,0,0,0.04);
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            font-size: 12px;
            min-height: 98px;
        }

        .amz-offer-heading {
            font-weight: 700;
            color: var(--amz-dark);
            margin-bottom: 3px;
        }

        .amz-offer-text {
            color: var(--amz-text-muted);
            line-height: 1.35;
            display: -webkit-box;
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
            overflow: hidden;
        }

        .amz-offer-link {
            color: var(--amz-link);
            font-weight: 600;
            margin-top: 6px;
            text-decoration: none;
            font-size: 11px;
        }

            .amz-offer-link:hover {
                color: var(--amz-link-hover);
                text-decoration: underline;
            }

        /* 6 Amazon Service Icons Strip */
        .amz-services-strip {
            display: flex;
            align-items: flex-start;
            justify-content: space-between;
            text-align: center;
            gap: 8px;
            padding: 10px 0;
            overflow-x: auto;
        }

        .amz-service-item {
            flex: 1;
            min-width: 60px;
            display: flex;
            flex-direction: column;
            align-items: center;
            text-decoration: none;
        }

        .amz-service-icon-box {
            width: 40px;
            height: 40px;
            display: flex;
            align-items: center;
            justify-content: center;
            margin-bottom: 4px;
            color: #007185;
            font-size: 22px;
        }

        .amz-service-label {
            font-size: 11px;
            color: var(--amz-link);
            line-height: 1.25;
            font-weight: 500;
        }

        /* Specifications Table */
        .amz-specs-table {
            width: 100%;
            margin: 10px 0;
            font-size: 13px;
        }

            .amz-specs-table tr td {
                padding: 5px 0;
                vertical-align: top;
            }

        .amz-spec-label {
            font-weight: 600;
            color: var(--amz-dark);
            width: 38%;
        }

        .amz-spec-val {
            color: var(--amz-dark);
            width: 62%;
        }

        /* Description Content */
        .amz-description-box {
            font-size: 13px;
            color: var(--amz-dark);
            line-height: 1.5;
        }

            .amz-description-box h4 {
                font-size: 14px;
                font-weight: 700;
                margin-bottom: 6px;
            }

        /* ---------------- RIGHT: Buy Box Column ---------------- */
        .amz-buybox-card {
            border: 1px solid var(--amz-border);
            border-radius: 8px;
            padding: 16px 18px;
            background: #ffffff;
            box-shadow: 0 1px 3px rgba(0,0,0,0.06);
            position: sticky;
            top: 20px;
        }

        .amz-buybox-price-row {
            font-size: 26px;
            font-weight: 700;
            color: var(--amz-dark);
            margin-bottom: 8px;
        }

        .amz-prime-badge {
            display: inline-flex;
            align-items: center;
            gap: 4px;
            color: #00a8e1;
            font-weight: 800;
            font-size: 14px;
            font-style: italic;
            margin-bottom: 6px;
        }

        .amz-delivery-info {
            font-size: 13px;
            color: var(--amz-dark);
            line-height: 1.4;
            margin-bottom: 10px;
        }

            .amz-delivery-info a {
                color: var(--amz-link);
                text-decoration: none;
            }

                .amz-delivery-info a:hover {
                    color: var(--amz-link-hover);
                    text-decoration: underline;
                }

        .amz-location-row {
            display: flex;
            align-items: center;
            gap: 6px;
            font-size: 12px;
            color: var(--amz-link);
            margin-bottom: 12px;
            cursor: pointer;
        }

            .amz-location-row:hover {
                color: var(--amz-link-hover);
            }

        .amz-stock-status {
            color: #007600;
            font-size: 17px;
            font-weight: 600;
            margin-bottom: 12px;
        }

        /* Quantity Selector */
        .amz-qty-row {
            display: flex;
            align-items: center;
            gap: 10px;
            margin-bottom: 16px;
        }

        .amz-qty-label {
            font-size: 13px;
            font-weight: 600;
            color: var(--amz-dark);
        }

        .amz-qty-control {
            display: inline-flex;
            align-items: center;
            border: 1px solid var(--amz-border);
            border-radius: 6px;
            overflow: hidden;
            background: #f0f2f2;
        }

        .amz-qty-btn {
            width: 32px;
            height: 32px;
            border: 0;
            background: #f0f2f2;
            color: #0f1111;
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            transition: background 0.2s;
            font-size: 14px;
        }

            .amz-qty-btn:hover {
                background: #e3e6e6;
            }

        .amz-qty-input {
            width: 44px;
            height: 32px;
            border: 0;
            border-left: 1px solid var(--amz-border);
            border-right: 1px solid var(--amz-border);
            text-align: center;
            font-size: 14px;
            font-weight: 600;
            background: #fff;
            color: #0f1111;
            outline: none;
        }

        /* Website Theme Action Buttons */
        .amz-btn-cart {
            width: 100%;
            background: var(--accent-color, #0097b2);
            border: 1px solid var(--accent-color, #0097b2);
            border-radius: 25px;
            padding: 11px 16px;
            font-size: 14px;
            font-weight: 600;
            color: #ffffff;
            cursor: pointer;
            box-shadow: 0 4px 12px rgba(0, 151, 178, 0.25);
            transition: all 0.25s ease;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
            margin-bottom: 10px;
        }

            .amz-btn-cart:hover {
                background: color-mix(in srgb, var(--accent-color, #0097b2), #000 15%);
                border-color: color-mix(in srgb, var(--accent-color, #0097b2), #000 15%);
                color: #ffffff;
                box-shadow: 0 6px 18px rgba(0, 151, 178, 0.38);
                transform: translateY(-1px);
            }

        .amz-btn-buynow {
            width: 100%;
            background: #ffffff;
            border: 2px solid var(--accent-color, #0097b2);
            border-radius: 25px;
            padding: 10px 16px;
            font-size: 14px;
            font-weight: 600;
            color: var(--accent-color, #0097b2);
            cursor: pointer;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.04);
            transition: all 0.25s ease;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
            margin-bottom: 12px;
        }

            .amz-btn-buynow:hover {
                background: var(--accent-color, #0097b2);
                border-color: var(--accent-color, #0097b2);
                color: #ffffff;
                box-shadow: 0 6px 18px rgba(0, 151, 178, 0.38);
                transform: translateY(-1px);
            }

        .amz-btn-wishlist {
            width: 100%;
            background: #f0f2f2;
            border: 1px solid var(--amz-border);
            border-radius: 20px;
            padding: 8px 14px;
            font-size: 12px;
            font-weight: 600;
            color: #0f1111;
            cursor: pointer;
            transition: all 0.2s;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 6px;
            margin-bottom: 14px;
        }

            .amz-btn-wishlist:hover {
                background: #e3e6e6;
                border-color: #bbb;
            }

        /* Seller & Meta Rows */
        .amz-meta-table {
            width: 100%;
            font-size: 12px;
            color: var(--amz-text-muted);
            border-top: 1px solid #e7e7e7;
            padding-top: 10px;
            margin-top: 6px;
        }

            .amz-meta-table tr td {
                padding: 3px 0;
            }

        .amz-meta-label {
            width: 42%;
            color: var(--amz-text-muted);
        }

        .amz-meta-val {
            color: var(--amz-link);
            font-weight: 500;
        }

            .amz-meta-val a {
                color: var(--amz-link);
                text-decoration: none;
            }

                .amz-meta-val a:hover {
                    color: var(--amz-link-hover);
                    text-decoration: underline;
                }

        /* Protection Plan Box */
        .amz-protection-box {
            border-top: 1px solid #e7e7e7;
            margin-top: 12px;
            padding-top: 10px;
            font-size: 12px;
        }

        .amz-protection-title {
            font-weight: 700;
            margin-bottom: 6px;
            color: var(--amz-dark);
        }

        .amz-protection-option {
            display: flex;
            align-items: flex-start;
            gap: 8px;
            color: var(--amz-dark);
            cursor: pointer;
        }

            .amz-protection-option input {
                margin-top: 3px;
            }

        /* Bottom Tabs & Details */
        .amz-bottom-details {
            margin-top: 40px;
            padding-top: 25px;
            border-top: 1px solid #e7e7e7;
        }

        .amz-tab-nav {
            border-bottom: 2px solid #e7e7e7;
            margin-bottom: 20px;
        }

            .amz-tab-nav .nav-link {
                font-size: 15px;
                font-weight: 600;
                color: var(--amz-text-muted);
                border: 0;
                border-bottom: 3px solid transparent;
                padding: 10px 18px;
                border-radius: 0;
            }

                .amz-tab-nav .nav-link.active {
                    color: #e77600;
                    border-bottom: 3px solid #e77600;
                    background: transparent;
                }

        /* Responsive Layout Tweaks */
        @media (max-width: 991.98px) {
            .amz-buybox-card {
                position: static;
                margin-top: 20px;
            }

            .amz-offers-grid {
                grid-template-columns: repeat(2, 1fr);
            }
        }

        @media (max-width: 575.98px) {
            .amz-offers-grid {
                grid-template-columns: 1fr;
            }

            .amz-main-image-box {
                min-height: 280px;
            }

            .amz-product-title {
                font-size: 17px;
            }

            .amz-sale-price {
                font-size: 24px;
            }
        }

        /* ================== SIMILAR PRODUCTS SECTION (MATCHING INDEX STYLE) ================== */
        .similar-products-section {
            margin-top: 50px;
            padding-top: 35px;
            border-top: 1px solid #e7e7e7;
        }

        .similar-badge {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            padding: 4px 12px;
            border-radius: 50px;
            background: rgba(0, 151, 178, 0.08);
            color: #0097b2;
            font-size: 0.78rem;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            margin-bottom: 6px;
            border: 1px solid rgba(0, 151, 178, 0.2);
        }

        .similar-title {
            font-size: clamp(1.25rem, 2vw, 1.55rem);
            font-weight: 700;
            color: #111827;
            letter-spacing: -0.3px;
        }

        .similar-subtitle {
            font-size: 0.88rem;
            color: #6b7280;
        }

        .similar-view-all-link {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            font-size: 0.88rem;
            font-weight: 600;
            color: #0097b2;
            text-decoration: none;
            padding: 6px 14px;
            border: 1px solid rgba(0, 151, 178, 0.3);
            border-radius: 8px;
            background: #ffffff;
            transition: all 0.25s ease;
        }

            .similar-view-all-link:hover {
                background: #0097b2;
                color: #ffffff;
                border-color: #0097b2;
                transform: translateX(3px);
            }

        /* 6-Column Desktop & 2-Column Mobile Tuning for Similar Products */
        .similar-products-section .product-image {
            aspect-ratio: 1 / 1;
            border-radius: 12px;
        }

            .similar-products-section .product-image img {
                padding: 8px;
            }

        .similar-products-section .product-info {
            padding: 8px 2px 2px 2px;
        }

        .similar-products-section .product-name {
            font-size: 0.84rem;
            margin-bottom: 2px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .similar-products-section .product-price {
            gap: 4px;
            margin-bottom: 1px;
        }

            .similar-products-section .product-price .sale-price {
                font-size: 0.95rem;
            }

            .similar-products-section .product-price .original-price {
                font-size: 0.78rem;
            }

        .similar-products-section .bank-offer {
            font-size: 0.72rem;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .similar-products-section .rating-pill {
            bottom: 6px;
            left: 6px;
            padding: 1px 6px;
        }

            .similar-products-section .rating-pill .rating-score {
                font-size: 0.72rem;
            }

            .similar-products-section .rating-pill .rating-star {
                font-size: 0.68rem;
            }

            .similar-products-section .rating-pill .rating-count {
                font-size: 0.65rem;
            }

        .similar-products-section .cart-btn {
            font-size: 0.72rem;
            padding: 4px 9px;
            bottom: 6px;
            right: 6px;
        }

        .similar-products-section .wishlist-btn {
            width: 28px;
            height: 28px;
            font-size: 0.8rem;
            top: 6px;
            right: 6px;
        }

        @media (max-width: 575.98px) {
            .similar-products-section .product-name {
                font-size: 0.8rem;
            }

            .similar-products-section .product-price .sale-price {
                font-size: 0.88rem;
            }

            .similar-products-section .product-price .original-price {
                font-size: 0.72rem;
            }
        }
    </style>

    <!-- 1. Breadcrumbs Bar -->
    <div class="amz-breadcrumb-bar">
        <div class="container">
            <nav class="amz-breadcrumbs">
                <a href="index.aspx">Home</a>
                <span class="amz-bc-divider">&rsaquo;</span>
                <a href="category.aspx">
                    <span class="badge-category" id="category" runat="server">Furniture</span>
                </a>
                <span class="amz-bc-divider">&rsaquo;</span>
                <span class="amz-bc-current">Product Details</span>
            </nav>
        </div>
    </div>

    <!-- 2. Main 3-Column Product Section -->
    <section class="amz-product-wrapper">
        <div class="container">
            <div class="row g-4">

                <!-- ================== COLUMN 1: GALLERY ================== -->
                <div class="col-xl-4 col-lg-5 col-md-6 amz-gallery-col">
                    <div class="amz-gallery-sticky">

                        <!-- Main Showcase Box -->
                        <div class="amz-main-image-box">
                            <!-- Share Button -->
                            <button type="button" class="amz-gallery-share-btn" title="Share Product" onclick="navigator.clipboard ? navigator.clipboard.writeText(window.location.href).then(()=>alert('Product Link Copied!')) : alert('Link: ' + window.location.href);">
                                <i class="bi bi-share"></i>
                            </button>

                            <!-- Backend Main Product Image (Kept 100% Intact) -->
                            <asp:Image ID="product_img" runat="server" class="img-fluid amz-main-img" ClientIDMode="Static" alt="Main Product Image" />
                        </div>

                        <div class="amz-view-hint">
                            <i class="bi bi-search me-1"></i>Roll over image to zoom in | Click thumbnail to switch                       
                        </div>

                        <!-- Thumbnails Row (Repeater Kept 100% Intact) -->
                        <div class="amz-thumbnails-container">
                            <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                                <ItemTemplate>
                                    <div class="amz-thumb-wrapper <%# Container.ItemIndex == 0 ? "active" : "" %>" onclick="switchProductThumb('auth/<%# Eval("photo_path") %>', this)">
                                        <img src='auth/<%# Eval("photo_path") %>' alt="Thumbnail Image" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </div>
                </div>

                <!-- ================== COLUMN 2: CENTER DETAILS ================== -->
                <div class="col-xl-5 col-lg-4 col-md-6 amz-center-col">

                    <!-- Title (Kept 100% Intact) -->
                    <h1 class="amz-product-title" id="product_name" runat="server">Mauris tempus cursus magna vel scelerisque nisl consectetur
                    </h1>

                    <!-- Store Link -->
                    <a href="index.aspx" class="amz-brand-link">Visit the Furniture Mart Store</a>

                    <!-- Rating Row -->
                    <div class="amz-rating-row">
                        <span class="amz-stars">&#9733;&#9733;&#9733;&#9733;&#9734;</span>
                        <span class="amz-rating-score">4.2</span>
                        <a href="#customer-reviews" class="amz-reviews-link">(12,773 ratings)</a>
                        <span class="amz-choice-badge">
                            <span class="badge-highlight">Furniture's</span> Choice
                        </span>
                    </div>

                    <div class="amz-past-bought">
                        <strong>1K+ bought</strong> in past month
                   
                    </div>

                    <hr class="amz-divider" />

                    <!-- Price Block (Kept 100% Intact) -->
                    <div class="amz-price-box">
                        <div class="amz-price-main-line">
                            <span class="amz-discount-percentage" id="discount_percentage" runat="server">(21% off)</span>
                            <span class="amz-sale-price" id="sell_price" runat="server">Rs. 189.99</span>
                        </div>
                        <div class="amz-mrp-line">
                            M.R.P.: <span class="amz-regular-price" id="shop_price" runat="server">Rs. 239.99</span>
                            <span class="amz-savings-amount" id="discount_price" runat="server">Save Rs. 50.00</span>
                        </div>
                        <div class="amz-tax-notice">Inclusive of all taxes</div>
                        <%--<div class="amz-emi-banner">
                            <strong>EMI</strong> starts at &#8377;149/month. No Cost EMI available | <a href="javascript:void(0)">EMI options <i class="bi bi-chevron-down"></i></a>
                        </div>--%>
                    </div>

                    <hr class="amz-divider" />

                    <!-- Amazon Style Offers Section -->
                    <%-- <div class="amz-offers-section">
                        <div class="amz-offers-title">
                            <i class="bi bi-percent"></i>Offers
                       
                        </div>
                        <div class="amz-offers-grid">
                            <!-- Card 1: Cashback -->
                            <div class="amz-offer-card">
                                <div>
                                    <div class="amz-offer-heading">Cashback</div>
                                    <div class="amz-offer-text">Upto &#8377;50.00 cashback on UPI payment...</div>
                                </div>
                                <a href="javascript:void(0)" class="amz-offer-link">1 offer &rsaquo;</a>
                            </div>

                            <!-- Card 2: No Cost EMI -->
                            <div class="amz-offer-card">
                                <div>
                                    <div class="amz-offer-heading">No Cost EMI</div>
                                    <div class="amz-offer-text">Upto &#8377;44.30 EMI interest savings on Credit Cards...</div>
                                </div>
                                <a href="javascript:void(0)" class="amz-offer-link">1 offer &rsaquo;</a>
                            </div>

                            <!-- Card 3: Bank Offer -->
                            <div class="amz-offer-card">
                                <div>
                                    <div class="amz-offer-heading">Bank Offer</div>
                                    <div class="amz-offer-text">Upto &#8377;2,500.00 discount on Select Cards...</div>
                                </div>
                                <a href="javascript:void(0)" class="amz-offer-link">41 offers &rsaquo;</a>
                            </div>
                        </div>
                    </div>--%>




                    <!-- Specifications Table -->
                    <table class="amz-specs-table">
                        <tr>
                            <td class="amz-spec-label">Brand</td>
                            <td class="amz-spec-val"><%# Eval("product_brand_name") %></td>
                            <%--<td class="amz-spec-val">Furniture Mart Official</td>--%>
                        </tr>
                        <tr>
                            <td class="amz-spec-label">Material</td>
                            <td class="amz-spec-val">Ergonomic High Density / Breathable Mesh</td>
                        </tr>
                        <tr>
                            <td class="amz-spec-label">Room Type</td>
                            <td class="amz-spec-val">Office, Home Workspace, Study</td>
                        </tr>
                        
                        <tr>
                            <td class="amz-spec-label">Assembly</td>
                            <td class="amz-spec-val">DIY (Toolkit & Manual Included)</td>
                        </tr>
                    </table>

                    <hr class="amz-divider" />

                    <!-- About this item Description (Kept 100% Intact) -->
                    <div class="amz-description-box">
                        <h4>About this item</h4>
                        <asp:Label ID="description" runat="server">
                            Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.
                        </asp:Label>
                    </div>

                </div>


                <!-- ================== COLUMN 3: BUY BOX (STICKY) ================== -->
                <div class="col-xl-3 col-lg-3 col-md-12">
                    <div class="amz-buybox-card">

                        <!-- Buybox Price Mirror -->
                        <div class="amz-buybox-price-row" id="buybox-mirror-price">
                            <!-- Populated automatically from sell_price -->
                        </div>

                        <!-- Prime Tag -->
                        <div class="amz-prime-badge">
                            <i class="bi bi-check2-circle"></i>prime
                       
                        </div>

                        <!-- Delivery Timeline -->
                        <div class="amz-delivery-info">
                            <strong>FREE delivery</strong> <span id="delivery-day-text">Thursday, 18 September</span>. <a href="javascript:void(0)">Details</a>
                            <br />
                            Or fastest delivery <strong>Tomorrow, 5 PM - 9 PM</strong>.
                       
                        </div>

                        <!-- Location Pin -->
                        <div class="amz-location-row" onclick="alert('Location updated successfully!')">
                            <i class="bi bi-geo-alt-fill text-danger"></i>
                            <span>Delivering to your location - <span style="text-decoration: underline;">Update</span></span>
                        </div>

                        <!-- Stock Status -->
                        <div class="amz-stock-status">In stock</div>

                        <!-- Quantity Selector (Server Controls Kept 100% Intact) -->
                        <div class="amz-qty-row">
                            <label class="amz-qty-label">Quantity:</label>
                            <div class="amz-qty-control">
                                <button class="amz-qty-btn" type="button" id="minus" runat="server" onserverclick="minus_ServerClick">
                                    <i class="bi bi-dash"></i>
                                </button>
                                <asp:TextBox ID="changeqty" runat="server" type="number" class="amz-qty-input">1</asp:TextBox>
                                <button class="amz-qty-btn" type="button" id="plus" runat="server" onserverclick="plus_ServerClick">
                                    <i class="bi bi-plus"></i>
                                </button>
                            </div>
                        </div>

                        <!-- Amazon Action Buttons (Server Controls Kept 100% Intact) -->
                        <button class="amz-btn-cart" id="btncart" runat="server" onserverclick="btncart_ServerClick">
                            <i class="bi bi-cart3"></i>Add to cart
                       
                        </button>

                        <button class="amz-btn-buynow" id="btncart2" runat="server" onserverclick="btncart2_ServerClick">
                            <i class="bi bi-lightning-fill"></i>Buy Now
                       
                        </button>

                        <button class="amz-btn-wishlist" title="Add to Wishlist" id="btnwishlist" runat="server" onserverclick="btnwishlist_ServerClick">
                            <i class="bi bi-heart"></i>Add to Wish List
                       
                        </button>

                        <!-- Ships From / Sold By Meta -->
                        <table class="amz-meta-table">
                            <tr>
                                <td class="amz-meta-label">Ships from</td>
                                <td class="amz-meta-val">Furniture Mart</td>
                            </tr>
                            <tr>
                                <td class="amz-meta-label">Sold by</td>
                                <td class="amz-meta-val"><a href="index.aspx">RetailEZ Furniture Pvt Ltd</a></td>
                            </tr>
                            <tr>
                                <td class="amz-meta-label">Payment</td>
                                <td class="amz-meta-val">Secure transaction</td>
                            </tr>
                            <tr>
                                <td class="amz-meta-label">Gift options</td>
                                <td class="amz-meta-val">Available at checkout</td>
                            </tr>
                        </table>

                        

                    </div>
                </div>

            </div>

            <hr class="amz-divider" />
            
            <!-- 6 Amazon Services Icon Strip -->
            <div class="amz-services-strip">
                <div class="amz-service-item">
                    <div class="amz-service-icon-box"><i class="bi bi-cash-stack"></i></div>
                    <span class="amz-service-label">Pay on<br />
                        Delivery</span>
                </div>
                <div class="amz-service-item">
                    <div class="amz-service-icon-box"><i class="bi bi-arrow-repeat"></i></div>
                    <span class="amz-service-label">10 days<br />
                        Replacement</span>
                </div>
                <div class="amz-service-item">
                    <div class="amz-service-icon-box"><i class="bi bi-truck"></i></div>
                    <span class="amz-service-label">Free<br />
                        Delivery</span>
                </div>
                <div class="amz-service-item">
                    <div class="amz-service-icon-box"><i class="bi bi-shield-check"></i></div>
                    <span class="amz-service-label">2 Year<br />
                        Warranty</span>
                </div>
                <div class="amz-service-item">
                    <div class="amz-service-icon-box"><i class="bi bi-award"></i></div>
                    <span class="amz-service-label">Top<br />
                        Brand</span>
                </div>
                <div class="amz-service-item">
                    <div class="amz-service-icon-box"><i class="bi bi-lock"></i></div>
                    <span class="amz-service-label">Secure<br />
                        Transaction</span>
                </div>
            </div>

            <hr class="amz-divider" />


            <!-- ================== BOTTOM TABS / OVERVIEW SECTION ================== -->
            <div class="row amz-bottom-details">
                <div class="col-12">
                    <nav class="nav amz-tab-nav">
                        <button class="nav-link active" data-bs-toggle="tab" data-bs-target="#amz-tab-overview" type="button">Product Overview</button>
                    </nav>

                    <div class="tab-content pt-2">
                        <div class="tab-pane fade show active" id="amz-tab-overview">
                            <div class="p-3">
                                <h5 class="fw-bold mb-2">Product Overview</h5>

                                <asp:Label ID="descp" runat="server" CssClass="text-muted small">
                                Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- ================== SIMILAR PRODUCTS SECTION (MATCHING INDEX STYLE) ================== -->
            <div class="similar-products-section best-sellers" id="similar-products">
                <div class="similar-header-wrap mb-4">
                    <h3 class="similar-title mb-1">Customers Also Viewed</h3>
                    <p class="similar-subtitle text-muted mb-0">
                        Explore similar products you may like
                    </p>
                </div>

                <div class="row g-2 g-md-3">
                    <asp:Repeater ID="rptSimilarProducts" runat="server" OnItemCommand="rptSimilarProducts_ItemCommand">
                        <ItemTemplate>
                            <div class="col-6 col-sm-6 col-md-4 col-lg-2">
                                <div class="product-item">
                                    <div class="product-image">
                                        <a href='product-details.aspx?ref=<%# Eval("product_id") %>' class="product-img-link">
                                            <img src='auth/<%# Eval("photo_path") %>' alt='<%# Eval("product_full_name") %>' class="img-fluid" loading="lazy">
                                        </a>

                                        <!-- Rating Pill Badge (Bottom-Left like Index/Flipkart) -->
                                        <div class="rating-pill">
                                            <span class="rating-score">4.6</span>
                                            <span class="rating-star">&#9733;</span>
                                            <span class="rating-count">(2,450)</span>
                                        </div>

                                        <!-- Wishlist Floating Button -->
                                        <div class="product-actions">
                                            <asp:LinkButton class="action-btn wishlist-btn" ID="btnSimWishlist"
                                                runat="server" CommandName="Wishlist"
                                                CommandArgument='<%# Eval("product_id") %>' ToolTip="Add to Wishlist">
                                                <i class="bi bi-heart"></i>
                                            </asp:LinkButton>
                                        </div>

                                        <!-- Add to Cart Floating Button -->
                                        <asp:Button class="cart-btn" ID="btnSimCart" runat="server" CommandName="AddCart"
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
                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- Fallback if no similar products found -->
                    <asp:Panel ID="pnlNoSimilar" runat="server" Visible="false" class="col-12 text-center py-4">
                        <p class="text-muted">More matching products coming soon!</p>
                    </asp:Panel>
                </div>
            </div>

        </div>
    </section>

    <!-- Interactive Client Script -->
    <script>
        // Switch main image when clicking thumbnails
        function switchProductThumb(photoUrl, el) {
            var mainImg = document.getElementById('<%= product_img.ClientID %>');
            if (mainImg) {
                mainImg.src = photoUrl;
            }
            // Update active state border
            var thumbs = document.querySelectorAll('.amz-thumb-wrapper');
            thumbs.forEach(function (t) { t.classList.remove('active'); });
            if (el) { el.classList.add('active'); }
        }

        // Sync price into the right sticky Buy Box
        document.addEventListener('DOMContentLoaded', function () {
            var centerPrice = document.getElementById('<%= sell_price.ClientID %>');
            var buyBoxPrice = document.getElementById('buybox-mirror-price');
            if (centerPrice && buyBoxPrice) {
                buyBoxPrice.innerText = centerPrice.innerText;
            }

            // Calculate dynamic delivery date (+2 days)
            var deliveryText = document.getElementById('delivery-day-text');
            if (deliveryText) {
                var d = new Date();
                d.setDate(d.getDate() + 2);
                var options = { weekday: 'long', day: 'numeric', month: 'long' };
                deliveryText.innerText = d.toLocaleDateString('en-US', options);
            }
        });
    </script>

</asp:Content>
