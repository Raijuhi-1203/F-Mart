<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="serach-product.aspx.cs" Inherits="serach_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- F-Mart Product Listing Stylesheet -->
    <link href="assets/css/product-listing.css" rel="stylesheet" />

    <!-- Page Title & Breadcrumb Hero -->
    <section class="fmart-listing-hero">
        <div class="container">
            <div class="row align-items-center gy-2">
                <div class="col-md-7 col-12">
                    <nav aria-label="breadcrumb" class="fmart-breadcrumbs">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.aspx"><i class="bi bi-house-door me-1"></i>Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Product List</li>
                        </ol>
                    </nav>
                    <h1 class="fmart-listing-title">Search Results / Product List</h1>
                    <p class="fmart-listing-subtitle" id="fmartHeroSubtitle">Explore high quality, ergonomic and durable furniture crafted for work &amp; living spaces</p>
                </div>
                <div class="col-md-5 col-12 text-md-end">
                    <div class="fmart-trust-badge d-inline-flex align-items-center">
                        <i class="bi bi-shield-check text-primary me-2 fs-5"></i>
                        <span>100% Genuine Quality Furniture</span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- /Page Title Hero -->

    <!-- Main Listing & Results Section -->
    <section class="fmart-results-section">
        <div class="container" data-aos="fade-up" data-aos-delay="50">

            <!-- Compact Search Results Summary & Control Bar -->
            <div class="fmart-toolbar-card d-flex flex-wrap align-items-center justify-content-between gap-3">
                
                <!-- Left: Result Count & Search Query Summary -->
                <div class="d-flex align-items-center flex-wrap gap-2">
                    <p class="fmart-summary-text">
                        Showing <span class="fmart-count-badge" id="fmartResultCount">products</span>
                        <span id="fmartQueryWrapper" class="d-none">for <span class="fmart-query-tag" id="fmartQueryDisplay"></span></span>
                    </p>
                </div>

                <!-- Right: Mobile Filter Button & Sort Dropdown -->
                <div class="fmart-toolbar-controls d-flex align-items-center gap-2">
                    <!-- Filter Button (Opens Offcanvas Drawer) -->
                    <button class="fmart-filter-trigger-btn" type="button" data-bs-toggle="offcanvas" data-bs-target="#fmartFilterDrawer" aria-controls="fmartFilterDrawer">
                        <i class="bi bi-sliders2"></i>
                        <span>Filters</span>
                        <span class="badge bg-primary rounded-pill d-none" id="fmartActiveFilterBadge">0</span>
                    </button>

                    <!-- Sort Dropdown UI -->
                    <div class="fmart-sort-group">
                        <label for="fmartSortSelect" class="fmart-sort-label d-none d-sm-inline"><i class="bi bi-arrow-down-up me-1"></i>Sort by:</label>
                        <select id="fmartSortSelect" class="form-select form-select-sm fmart-sort-select" aria-label="Sort products">
                            <option value="recommended" selected="selected">Recommended</option>
                            <option value="price-asc">Price: Low to High</option>
                            <option value="price-desc">Price: High to Low</option>
                            <option value="newest">Newest Arrivals</option>
                            <option value="name-asc">Product Name (A-Z)</option>
                        </select>
                    </div>
                </div>

            </div>
            <!-- /Summary & Control Bar -->

            <!-- Quick Filter Chips Bar (Instant Frontend Interaction) -->
            <div class="fmart-chips-scroll" id="fmartChipsBar">
                <button type="button" class="fmart-chip active" data-filter="all">All Products</button>
                <button type="button" class="fmart-chip" data-filter="chair">Chairs &amp; Seating</button>
                <button type="button" class="fmart-chip" data-filter="desk">Desks &amp; Tables</button>
                <button type="button" class="fmart-chip" data-filter="sofa">Sofas &amp; Lounge</button>
                <button type="button" class="fmart-chip" data-filter="storage">Storage &amp; Cabinets</button>
                <button type="button" class="fmart-chip" data-filter="under25k">Under Rs. 25,000</button>
                <button type="button" class="fmart-chip" data-filter="toprated">Top Rated (4&#9733;+)</button>
                <button type="button" class="fmart-chip clear-chip d-none" id="fmartClearFilterChip"><i class="bi bi-x-circle"></i> Clear Filter</button>
            </div>
            <!-- /Quick Filter Chips Bar -->

            <!-- Responsive Product Grid -->
            <!-- 4 products desktop (col-lg-3), 2 products tablet (col-md-6), 1 product mobile (col-12) -->
            <div class="row fmart-products-grid" id="fmartProductsGrid">

                <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                    <ItemTemplate>

                        <div class="col-12 col-md-6 col-lg-3 fmart-product-col"
                             data-name='<%# Eval("product_full_name") %>'
                             data-price='<%# Eval("product_market_price") %>'
                             data-discount='<%# Eval("product_discount_percentage") %>'>

                            <div class="fmart-product-card">

                                <!-- Card Media Box with Fixed Aspect Ratio -->
                                <div class="fmart-card-media">

                                    <!-- Discount Badge using existing Eval -->
                                    <div class="fmart-discount-pill">
                                        <%# Eval("product_discount_percentage") %> % OFF
                                    </div>

                                    <!-- Wishlist Heart Button -->
                                    <button type="button" class="fmart-wishlist-btn" title="Save to Wishlist" aria-label="Add to Wishlist" onclick="fmartToggleWishlist(this, '<%# Eval("product_id") %>')">
                                        <i class="bi bi-heart"></i>
                                    </button>

                                    <!-- Product Image with Fixed Aspect Ratio and clean fallback -->
                                    <a href='product-details.aspx?ref=<%# Eval("product_id") %>' class="fmart-media-link" title='<%# Eval("product_full_name") %>'>
                                        <img src='auth/<%# Eval("photo_path") %>'
                                             alt='<%# Eval("product_full_name") %>'
                                             class="fmart-card-img"
                                             loading="lazy"
                                             onerror="this.onerror=null; this.src='assets/img/logo.png'; this.classList.add('img-fallback');" />
                                    </a>

                                    <!-- Delivery Pill Tag -->
                                    <div class="fmart-media-tag">
                                        <i class="bi bi-truck"></i> Free Delivery
                                    </div>

                                </div>
                                <!-- /Card Media Box -->

                                <!-- Card Body (Equal Height Flex Column) -->
                                <div class="fmart-card-body">

                                    <div class="fmart-card-meta">
                                        <span class="fmart-brand-label">F-Mart Furniture</span>
                                        <div class="fmart-rating-wrap" title="4.6 out of 5 stars">
                                            <span class="fmart-rating-score">4.6</span>
                                            <i class="bi bi-star-fill fmart-rating-star"></i>
                                            <span class="fmart-rating-count">(86)</span>
                                        </div>
                                    </div>

                                    <!-- Product Name using existing Eval -->
                                    <h4 class="fmart-card-title">
                                        <a href='product-details.aspx?ref=<%# Eval("product_id") %>' title='<%# Eval("product_full_name") %>'>
                                            <%# Eval("product_full_name") %>
                                        </a>
                                    </h4>

                                    <!-- Feature Highlights -->
                                    <div class="fmart-card-features">
                                        <span class="fmart-feature-item"><i class="bi bi-check2-circle text-success"></i> Ergonomic</span>
                                        <span class="fmart-feature-item"><i class="bi bi-shield-check text-primary"></i> 1 Yr Warranty</span>
                                    </div>

                                    <!-- Price Section using existing Eval -->
                                    <div class="fmart-price-box">
                                        <div class="fmart-price-row">
                                            <span class="fmart-price-symbol">Rs.</span>
                                            <span class="fmart-price-value"><%# Eval("product_market_price") %></span>
                                        </div>
                                        <span class="fmart-tax-info">Inclusive of all taxes</span>
                                    </div>

                                    <!-- Clear Add to Cart Button -->
                                    <a href='product-details.aspx?ref=<%# Eval("product_id") %>' class="fmart-btn-cart">
                                        <i class="bi bi-cart3"></i> Add to Cart
                                    </a>

                                </div>
                                <!-- /Card Body -->

                            </div>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>

                <!-- Clean Empty Results Design using existing NoDataPanel -->
                <asp:Panel ID="NoDataPanel" runat="server" Visible="false">
                    <div class="col-12">
                        <div class="fmart-empty-state-card">
                            <div class="fmart-empty-icon-circle">
                                <i class="bi bi-search"></i>
                            </div>
                            <h3 class="fmart-empty-heading">No Products Found</h3>
                            <p class="fmart-empty-message">
                                We couldn't find any furniture matching your search criteria. Check your spelling or explore our popular furniture categories below.
                            </p>

                            <div class="fmart-suggested-searches">
                                <div class="fmart-suggest-label">
                                    <i class="bi bi-lightbulb me-1"></i> Popular Searches:
                                </div>
                                <div class="fmart-suggestion-links">
                                    <a href="serach-product.aspx?ref=Chair" class="fmart-suggestion-pill">Office Chairs</a>
                                    <a href="serach-product.aspx?ref=Desk" class="fmart-suggestion-pill">Study Desks</a>
                                    <a href="serach-product.aspx?ref=Table" class="fmart-suggestion-pill">Conference Tables</a>
                                    <a href="serach-product.aspx?ref=Sofa" class="fmart-suggestion-pill">Office Sofas</a>
                                    <a href="serach-product.aspx?ref=Storage" class="fmart-suggestion-pill">Storage Cabinets</a>
                                </div>
                            </div>

                            <div class="fmart-empty-actions">
                                <a href="category.aspx" class="fmart-btn-primary-action">
                                    <i class="bi bi-grid"></i> Browse All Categories
                                </a>
                                <a href="index.aspx" class="fmart-btn-secondary-action">
                                    <i class="bi bi-house"></i> Back to Homepage
                                </a>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <!-- /NoDataPanel -->

            </div>
            <!-- /Product Grid -->

            <!-- Optional Pagination-Style UI (Static visual design) -->
            <div class="fmart-pagination-container">
                <div class="fmart-pagination-info">
                    Showing <span class="fw-semibold text-dark" id="fmartPagingInfo">all available</span> items
                </div>
                <nav class="fmart-pagination-nav" aria-label="Product listing pagination">
                    <ul class="pagination pagination-sm mb-0">
                        <li class="page-item disabled">
                            <a class="page-link" href="javascript:void(0);" tabindex="-1" aria-disabled="true"><i class="bi bi-chevron-left me-1"></i>Prev</a>
                        </li>
                        <li class="page-item active" aria-current="page">
                            <a class="page-link" href="javascript:void(0);">1</a>
                        </li>
                        <li class="page-item"><a class="page-link" href="javascript:void(0);">2</a></li>
                        <li class="page-item"><a class="page-link" href="javascript:void(0);">3</a></li>
                        <li class="page-item">
                            <a class="page-link" href="javascript:void(0);">Next<i class="bi bi-chevron-right ms-1"></i></a>
                        </li>
                    </ul>
                </nav>
            </div>
            <!-- /Pagination UI -->

        </div>
    </section>
    <!-- /Main Listing Section -->

    <!-- Static Filter Drawer (Offcanvas UI for Desktop & Mobile) -->
    <div class="offcanvas offcanvas-start fmart-offcanvas" tabindex="-1" id="fmartFilterDrawer" aria-labelledby="fmartFilterDrawerLabel">
        <div class="offcanvas-header fmart-offcanvas-header">
            <h5 class="offcanvas-title fmart-offcanvas-title" id="fmartFilterDrawerLabel">
                <i class="bi bi-sliders text-primary"></i> Filter Products
            </h5>
            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">

            <!-- Category Filter -->
            <div class="fmart-filter-group">
                <div class="fmart-filter-heading">Category</div>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="category" value="chair" /> Office Chairs</span>
                    <span class="badge">Popular</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="category" value="desk" /> Desks &amp; Workstations</span>
                    <span class="badge">New</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="category" value="table" /> Meeting &amp; Dining Tables</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="category" value="sofa" /> Sofas &amp; Couches</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="category" value="storage" /> Storage &amp; Wardrobes</span>
                </label>
            </div>

            <!-- Price Range Filter -->
            <div class="fmart-filter-group">
                <div class="fmart-filter-heading">Price Range (Rs.)</div>
                <div class="fmart-price-inputs mb-2">
                    <input type="number" class="fmart-price-input" id="fmartMinPrice" placeholder="Min (Rs.)" min="0" />
                    <span class="text-muted">-</span>
                    <input type="number" class="fmart-price-input" id="fmartMaxPrice" placeholder="Max (Rs.)" min="0" />
                </div>
                <label class="fmart-filter-option">
                    <span><input type="radio" name="pricePreset" class="form-check-input me-2 fmart-price-preset" value="all" checked="checked" /> All Prices</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="radio" name="pricePreset" class="form-check-input me-2 fmart-price-preset" value="0-10000" /> Under Rs. 10,000</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="radio" name="pricePreset" class="form-check-input me-2 fmart-price-preset" value="10000-25000" /> Rs. 10,000 to Rs. 25,000</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="radio" name="pricePreset" class="form-check-input me-2 fmart-price-preset" value="25000-50000" /> Rs. 25,000 to Rs. 50,000</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="radio" name="pricePreset" class="form-check-input me-2 fmart-price-preset" value="50000-999999" /> Above Rs. 50,000</span>
                </label>
            </div>

            <!-- Customer Rating Filter -->
            <div class="fmart-filter-group">
                <div class="fmart-filter-heading">Customer Rating</div>
                <label class="fmart-filter-option">
                    <span>
                        <input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="rating" value="4" />
                        4&#9733; &amp; Above
                    </span>
                    <span class="text-warning"><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i></span>
                </label>
                <label class="fmart-filter-option">
                    <span>
                        <input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="rating" value="3" />
                        3&#9733; &amp; Above
                    </span>
                    <span class="text-warning"><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i></span>
                </label>
            </div>

            <!-- Material Filter -->
            <div class="fmart-filter-group">
                <div class="fmart-filter-heading">Material</div>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="material" value="wood" /> Solid Wood</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="material" value="metal" /> Premium Metal</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="material" value="mesh" /> Breathable Mesh</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="material" value="leatherette" /> Leatherette</span>
                </label>
            </div>

            <!-- Availability Filter -->
            <div class="fmart-filter-group">
                <div class="fmart-filter-heading">Availability</div>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="availability" value="instock" checked="checked" /> In Stock Only</span>
                </label>
                <label class="fmart-filter-option">
                    <span><input type="checkbox" class="form-check-input me-2 fmart-filter-chk" data-type="availability" value="express" /> Fast Dispatch</span>
                </label>
            </div>

        </div>
        <div class="fmart-offcanvas-footer">
            <button type="button" class="btn btn-primary flex-grow-1" id="fmartApplyFiltersBtn" data-bs-dismiss="offcanvas">Apply Filters</button>
            <button type="button" class="btn btn-outline-secondary" id="fmartResetFiltersBtn">Reset</button>
        </div>
    </div>
    <!-- /Filter Drawer -->

    <!-- Wishlist Toast Notification -->
    <div id="fmartWishlistToast" class="fmart-toast" role="alert" aria-live="assertive" aria-atomic="true">
        <i class="bi bi-check-circle-fill text-success fs-5"></i>
        <span id="fmartToastMessage">Item saved to your Wishlist!</span>
    </div>

    <!-- Client-Side Modern Interactive Enhancement Script -->
    <script>
        (function () {
            // Read URL Query for Search Term
            var urlParams = new URLSearchParams(window.location.search);
            var query = '';
            for (var pair of urlParams.entries()) {
                if (pair[1]) {
                    query = pair[1];
                    break;
                }
            }

            var queryWrapper = document.getElementById('fmartQueryWrapper');
            var queryDisplay = document.getElementById('fmartQueryDisplay');
            var heroSubtitle = document.getElementById('fmartHeroSubtitle');

            if (query && query.trim() !== '') {
                if (queryDisplay) queryDisplay.textContent = query;
                if (queryWrapper) queryWrapper.classList.remove('d-none');
                if (heroSubtitle) heroSubtitle.textContent = 'Showing search results for "' + query + '"';
            }

            // Product Cards Elements
            var grid = document.getElementById('fmartProductsGrid');
            var resultCountElem = document.getElementById('fmartResultCount');
            var pagingInfo = document.getElementById('fmartPagingInfo');

            function getProductCards() {
                if (!grid) return [];
                return Array.from(grid.querySelectorAll('.fmart-product-col'));
            }

            function updateCount() {
                var allCards = getProductCards();
                var visibleCount = allCards.filter(function (c) {
                    return c.style.display !== 'none';
                }).length;

                if (resultCountElem) {
                    resultCountElem.textContent = visibleCount + ' ' + (visibleCount === 1 ? 'product' : 'products');
                }
                if (pagingInfo) {
                    pagingInfo.textContent = visibleCount + ' of ' + allCards.length;
                }
            }

            updateCount();

            // Client-Side Sort Handler
            var sortSelect = document.getElementById('fmartSortSelect');
            if (sortSelect && grid) {
                sortSelect.addEventListener('change', function () {
                    var val = this.value;
                    var cards = getProductCards();

                    cards.sort(function (a, b) {
                        var priceA = parseFloat((a.getAttribute('data-price') || '0').replace(/[^0-9.]/g, '')) || 0;
                        var priceB = parseFloat((b.getAttribute('data-price') || '0').replace(/[^0-9.]/g, '')) || 0;
                        var nameA = (a.getAttribute('data-name') || '').trim().toLowerCase();
                        var nameB = (b.getAttribute('data-name') || '').trim().toLowerCase();
                        var discA = parseFloat((a.getAttribute('data-discount') || '0').replace(/[^0-9.]/g, '')) || 0;
                        var discB = parseFloat((b.getAttribute('data-discount') || '0').replace(/[^0-9.]/g, '')) || 0;

                        if (val === 'price-asc') return priceA - priceB;
                        if (val === 'price-desc') return priceB - priceA;
                        if (val === 'name-asc') return nameA.localeCompare(nameB);
                        if (val === 'newest') return discB - discA; // Highlight trending
                        return 0; // recommended
                    });

                    // Re-append sorted cards
                    cards.forEach(function (card) {
                        grid.appendChild(card);
                    });
                });
            }

            // Quick Filter Chips Handler
            var chipsBar = document.getElementById('fmartChipsBar');
            var clearChip = document.getElementById('fmartClearFilterChip');

            if (chipsBar) {
                chipsBar.addEventListener('click', function (e) {
                    var chip = e.target.closest('.fmart-chip');
                    if (!chip) return;

                    var filterType = chip.getAttribute('data-filter');

                    if (chip.id === 'fmartClearFilterChip' || filterType === 'all') {
                        chipsBar.querySelectorAll('.fmart-chip').forEach(function (c) {
                            c.classList.remove('active');
                        });
                        var allBtn = chipsBar.querySelector('[data-filter="all"]');
                        if (allBtn) allBtn.classList.add('active');
                        if (clearChip) clearChip.classList.add('d-none');

                        // Show all cards
                        getProductCards().forEach(function (c) {
                            c.style.display = '';
                        });
                        updateCount();
                        return;
                    }

                    // Toggle chip active
                    chipsBar.querySelectorAll('.fmart-chip').forEach(function (c) {
                        c.classList.remove('active');
                    });
                    chip.classList.add('active');
                    if (clearChip) clearChip.classList.remove('d-none');

                    var cards = getProductCards();
                    cards.forEach(function (card) {
                        var name = (card.getAttribute('data-name') || '').toLowerCase();
                        var price = parseFloat((card.getAttribute('data-price') || '0').replace(/[^0-9.]/g, '')) || 0;
                        var show = true;

                        if (filterType === 'chair') {
                            show = name.indexOf('chair') !== -1 || name.indexOf('seat') !== -1;
                        } else if (filterType === 'desk') {
                            show = name.indexOf('desk') !== -1 || name.indexOf('table') !== -1;
                        } else if (filterType === 'sofa') {
                            show = name.indexOf('sofa') !== -1 || name.indexOf('couch') !== -1 || name.indexOf('lounge') !== -1;
                        } else if (filterType === 'storage') {
                            show = name.indexOf('storage') !== -1 || name.indexOf('cabinet') !== -1 || name.indexOf('wardrobe') !== -1;
                        } else if (filterType === 'under25k') {
                            show = price <= 25000;
                        } else if (filterType === 'toprated') {
                            show = true; // all items are top rated curated
                        }

                        card.style.display = show ? '' : 'none';
                    });

                    updateCount();
                });
            }

            // Drawer Filter Apply Button
            var applyBtn = document.getElementById('fmartApplyFiltersBtn');
            var resetBtn = document.getElementById('fmartResetFiltersBtn');
            var activeFilterBadge = document.getElementById('fmartActiveFilterBadge');

            if (applyBtn) {
                applyBtn.addEventListener('click', function () {
                    var selectedCategories = [];
                    document.querySelectorAll('.fmart-filter-chk[data-type="category"]:checked').forEach(function (chk) {
                        selectedCategories.push(chk.value.toLowerCase());
                    });

                    var minPrice = parseFloat(document.getElementById('fmartMinPrice').value) || 0;
                    var maxPrice = parseFloat(document.getElementById('fmartMaxPrice').value) || 9999999;

                    var pricePreset = document.querySelector('input[name="pricePreset"]:checked');
                    if (pricePreset && pricePreset.value !== 'all') {
                        var parts = pricePreset.value.split('-');
                        minPrice = parseFloat(parts[0]) || minPrice;
                        maxPrice = parseFloat(parts[1]) || maxPrice;
                    }

                    var cards = getProductCards();
                    var activeCount = 0;
                    if (selectedCategories.length > 0) activeCount += selectedCategories.length;
                    if (pricePreset && pricePreset.value !== 'all') activeCount++;

                    if (activeFilterBadge) {
                        if (activeCount > 0) {
                            activeFilterBadge.textContent = activeCount;
                            activeFilterBadge.classList.remove('d-none');
                        } else {
                            activeFilterBadge.classList.add('d-none');
                        }
                    }

                    cards.forEach(function (card) {
                        var name = (card.getAttribute('data-name') || '').toLowerCase();
                        var price = parseFloat((card.getAttribute('data-price') || '0').replace(/[^0-9.]/g, '')) || 0;
                        var matchCat = selectedCategories.length === 0 || selectedCategories.some(function (cat) {
                            return name.indexOf(cat) !== -1;
                        });
                        var matchPrice = price >= minPrice && price <= maxPrice;

                        card.style.display = (matchCat && matchPrice) ? '' : 'none';
                    });

                    updateCount();
                });
            }

            if (resetBtn) {
                resetBtn.addEventListener('click', function () {
                    document.querySelectorAll('.fmart-filter-chk').forEach(function (c) { c.checked = false; });
                    var defaultPreset = document.querySelector('input[name="pricePreset"][value="all"]');
                    if (defaultPreset) defaultPreset.checked = true;
                    document.getElementById('fmartMinPrice').value = '';
                    document.getElementById('fmartMaxPrice').value = '';
                    if (activeFilterBadge) activeFilterBadge.classList.add('d-none');

                    getProductCards().forEach(function (c) { c.style.display = ''; });
                    updateCount();
                });
            }

        })();

        // Wishlist Toggle Feedback
        function fmartToggleWishlist(btn, productId) {
            var icon = btn.querySelector('i');
            var isAdded = btn.classList.toggle('active');
            var toast = document.getElementById('fmartWishlistToast');
            var msg = document.getElementById('fmartToastMessage');

            if (isAdded) {
                icon.classList.remove('bi-heart');
                icon.classList.add('bi-heart-fill');
                if (msg) msg.textContent = 'Product saved to your Wishlist!';
            } else {
                icon.classList.remove('bi-heart-fill');
                icon.classList.add('bi-heart');
                if (msg) msg.textContent = 'Product removed from your Wishlist.';
            }

            if (toast) {
                toast.classList.add('show');
                setTimeout(function () {
                    toast.classList.remove('show');
                }, 2500);
            }
        }
    </script>

</asp:Content>
