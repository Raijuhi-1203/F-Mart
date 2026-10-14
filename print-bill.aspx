<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print-bill.aspx.cs" Inherits="print_bill" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tax Invoice - The Furniture Mart</title>

    <!-- Favicon -->
    <link href="assets/img/favicon.jpg" rel="icon">

    <!-- Google Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet">

    <!-- Bootstrap Icons -->
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">

    <style>
        /* Base Reset & Typography */
        *, *::before, *::after {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
        }

        body {
            font-family: 'Inter', system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, sans-serif;
            background-color: #f1f5f9;
            color: #334155;
            line-height: 1.5;
            -webkit-font-smoothing: antialiased;
            padding: 24px 16px;
        }

        /* Screen Action Bar (Print & Back) - Hidden in Print */
        .action-bar-container {
            max-width: 820px;
            margin: 0 auto 16px auto;
            display: flex;
            justify-content: space-between;
            align-items: center;
            gap: 12px;
        }

        .btn-action {
            display: inline-flex;
            align-items: center;
            gap: 8px;
            padding: 8px 16px;
            font-size: 13.5px;
            font-weight: 600;
            border-radius: 8px;
            cursor: pointer;
            text-decoration: none;
            transition: all 0.2s ease;
            border: 1px solid transparent;
        }

        .btn-back {
            background: #ffffff;
            color: #475569;
            border-color: #cbd5e1;
        }

        .btn-back:hover {
            background: #f8fafc;
            color: #1e293b;
            border-color: #94a3b8;
        }

        .btn-print {
            background: #0097b2;
            color: #ffffff;
            box-shadow: 0 2px 6px rgba(0, 151, 178, 0.25);
        }

        .btn-print:hover {
            background: #007c93;
            color: #ffffff;
            transform: translateY(-1px);
        }

        /* Main Invoice Paper Card */
        .invoice-card {
            max-width: 820px;
            margin: 0 auto;
            background: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
            border: 1px solid #e2e8f0;
            padding: 36px 40px;
        }

        /* Header Section */
        .invoice-header {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
            padding-bottom: 22px;
            border-bottom: 2px solid #f1f5f9;
            margin-bottom: 24px;
            gap: 20px;
            flex-wrap: wrap;
        }

        .invoice-brand {
            display: flex;
            flex-direction: column;
            gap: 10px;
            align-items: flex-start;
        }

        .invoice-logo {
            width: 145px;
            height: auto;
            object-fit: contain;
            display: block;
        }

        .invoice-type-pill {
            display: inline-block;
            font-size: 11px;
            font-weight: 700;
            letter-spacing: 0.8px;
            text-transform: uppercase;
            color: #0097b2;
            background: #eef9fb;
            padding: 3px 10px;
            border-radius: 20px;
            border: 1px solid #d2f1f6;
        }

        .invoice-meta-group {
            text-align: right;
            display: flex;
            flex-direction: column;
            gap: 6px;
        }

        .meta-item {
            display: flex;
            align-items: baseline;
            justify-content: flex-end;
            gap: 8px;
        }

        .meta-label {
            font-size: 12.5px;
            color: #64748b;
            font-weight: 500;
        }

        .meta-val {
            font-size: 13.5px;
            color: #0f172a;
            font-weight: 700;
            margin: 0;
            white-space: nowrap;
        }

        /* Addresses Grid */
        .invoice-addresses-grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px;
            margin-bottom: 28px;
        }

        .address-box {
            background: #f8fafc;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            padding: 16px 18px;
        }

        .address-box-title {
            font-size: 12px;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            color: #0097b2;
            margin-bottom: 10px;
            display: flex;
            align-items: center;
            gap: 6px;
        }

        .address-box-body p {
            font-size: 13px;
            color: #475569;
            line-height: 1.5;
            margin-bottom: 3px;
        }

        .address-box-body .company-name {
            font-size: 14px;
            font-weight: 700;
            color: #0f172a;
            margin-bottom: 4px;
        }

        /* Product Table */
        .table-responsive {
            width: 100%;
            overflow-x: auto;
            margin-bottom: 24px;
            -webkit-overflow-scrolling: touch;
        }

        .invoice-table {
            width: 100%;
            border-collapse: collapse;
            font-size: 13px;
            min-width: 540px;
        }

        .invoice-table th {
            background: #f8fafc;
            color: #0f172a;
            font-weight: 700;
            font-size: 12px;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            padding: 12px 14px;
            border-top: 1px solid #e2e8f0;
            border-bottom: 2px solid #cbd5e1;
        }

        .invoice-table td {
            padding: 14px 14px;
            border-bottom: 1px solid #e2e8f0;
            color: #334155;
            vertical-align: middle;
        }

        .invoice-table tr:last-child td {
            border-bottom: 1px solid #cbd5e1;
        }

        .text-left { text-align: left; }
        .text-center { text-align: center; }
        .text-right { text-align: right; }
        .font-semibold { font-weight: 600; }
        .font-bold { font-weight: 700; }
        .text-dark { color: #0f172a; }
        .text-muted { color: #94a3b8; }

        /* Summary / Totals */
        .invoice-summary-wrap {
            display: flex;
            justify-content: flex-end;
            margin-bottom: 28px;
        }

        .invoice-summary-card {
            width: 100%;
            max-width: 340px;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            overflow: hidden;
            background: #ffffff;
        }

        .summary-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 10px 16px;
            font-size: 13px;
            border-bottom: 1px solid #f1f5f9;
        }

        .summary-row:last-child {
            border-bottom: none;
        }

        .summary-label {
            color: #64748b;
            font-weight: 500;
        }

        .summary-value {
            color: #0f172a;
            font-weight: 700;
            white-space: nowrap;
        }

        .summary-row.total-row {
            background: #0097b2;
            color: #ffffff;
            padding: 12px 16px;
        }

        .summary-row.total-row .summary-label,
        .summary-row.total-row .summary-value {
            color: #ffffff;
            font-size: 15px;
            font-weight: 700;
        }

        /* Notes Box */
        .invoice-notes-box {
            background: #f8fafc;
            border-left: 3px solid #0097b2;
            border-radius: 4px;
            padding: 12px 16px;
            margin-bottom: 26px;
        }

        .notes-header {
            font-size: 12px;
            font-weight: 700;
            color: #0097b2;
            margin-bottom: 4px;
            display: flex;
            align-items: center;
            gap: 5px;
        }

        .notes-text {
            font-size: 12.5px;
            font-style: italic;
            color: #64748b;
            line-height: 1.4;
        }

        /* In-Flow Footer */
        .invoice-footer {
            border-top: 1px dashed #cbd5e1;
            padding-top: 20px;
            text-align: center;
            color: #64748b;
            font-size: 12px;
        }

        .footer-company {
            font-weight: 700;
            color: #0f172a;
            margin-bottom: 6px;
        }

        .footer-contact {
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 12px;
            flex-wrap: wrap;
            margin-bottom: 6px;
        }

        .footer-contact span {
            display: inline-flex;
            align-items: center;
            gap: 5px;
        }

        .separator {
            color: #cbd5e1;
        }

        .footer-thanks {
            font-size: 11.5px;
            color: #94a3b8;
        }

        /* Responsive Breakpoints for Phones & Small Screens */
        @media (max-width: 640px) {
            body {
                padding: 10px 8px;
            }

            .action-bar-container {
                padding: 0 4px;
                margin-bottom: 12px;
            }

            .invoice-card {
                padding: 20px 16px;
                border-radius: 8px;
            }

            .invoice-header {
                flex-direction: column;
                align-items: stretch;
                gap: 14px;
                margin-bottom: 18px;
                padding-bottom: 16px;
            }

            .invoice-brand {
                flex-direction: row;
                justify-content: space-between;
                align-items: center;
            }

            .invoice-meta-group {
                text-align: left;
                background: #f8fafc;
                border-radius: 6px;
                padding: 10px 12px;
                border: 1px solid #e2e8f0;
            }

            .meta-item {
                justify-content: space-between;
            }

            .invoice-addresses-grid {
                grid-template-columns: 1fr;
                gap: 12px;
                margin-bottom: 20px;
            }

            .address-box {
                padding: 12px 14px;
            }

            .invoice-summary-wrap {
                justify-content: stretch;
            }

            .invoice-summary-card {
                max-width: 100%;
            }

            .footer-contact {
                flex-direction: column;
                gap: 4px;
            }

            .separator {
                display: none;
            }
        }

        /* Print Media Styles */
        @media print {
            .no-print {
                display: none !important;
            }

            html, body {
                background: #ffffff !important;
                padding: 0 !important;
                margin: 0 !important;
                width: 100% !important;
            }

            .invoice-card {
                box-shadow: none !important;
                border: none !important;
                border-radius: 0 !important;
                padding: 0 !important;
                max-width: 100% !important;
                margin: 0 !important;
            }

            .invoice-table tr {
                page-break-inside: avoid;
            }

            .summary-row.total-row {
                background: #0097b2 !important;
                -webkit-print-color-adjust: exact !important;
                print-color-adjust: exact !important;
            }
        }
    </style>
</head>

<body>

    <!-- Screen Action Bar (Back & Print Button) -->
    <div class="no-print action-bar-container">
        <a href="javascript:history.back()" class="btn-action btn-back">
            <i class="bi bi-arrow-left"></i> Back
        </a>
        <button type="button" onclick="window.print()" class="btn-action btn-print">
            <i class="bi bi-printer-fill"></i> Print Invoice
        </button>
    </div>

    <!-- Main Printable Invoice Card -->
    <div class="invoice-card">

        <!-- Invoice Header -->
        <div class="invoice-header">
            <div class="invoice-brand">
                <img src="assets/img/logo.png" alt="The Furniture Mart" class="invoice-logo" />
                <span class="invoice-type-pill">TAX INVOICE</span>
            </div>

            <div class="invoice-meta-group">
                <div class="meta-item">
                    <span class="meta-label">Date:</span>
                    <p class="meta-val" id="date" runat="server"></p>
                </div>
                <div class="meta-item">
                    <span class="meta-label">Invoice #:</span>
                    <p class="meta-val" id="order_id" runat="server"></p>
                </div>
            </div>
        </div>

        <!-- Addresses Grid -->
        <div class="invoice-addresses-grid">
            <div class="address-box">
                <div class="address-box-title">
                    <i class="bi bi-truck"></i> Shipping Address
                </div>
                <div class="address-box-body">
                    <p id="add1" runat="server">Number: 23456789</p>
                    <p id="add2" runat="server">VAT: 23456789</p>
                    <p id="city" runat="server">6622 Abshire Mills</p>
                </div>
            </div>

            <div class="address-box">
                <div class="address-box-title">
                    <i class="bi bi-building"></i> Company Details
                </div>
                <div class="address-box-body">
                    <p class="company-name">The Furniture Mart</p>
                    <p>Address: Bank Rd, VindyaVasini Nagar</p>
                    <p>Gorakhpur, Uttar Pradesh - 273001</p>
                    <p>Phone: 9235501383</p>
                </div>
            </div>
        </div>

        <!-- Product Details Table -->
        <div class="table-responsive">
            <table class="invoice-table">
                <thead>
                    <tr>
                        <th class="text-left" style="width: 5%;">#</th>
                        <th class="text-left" style="width: 45%;">Product details</th>
                        <th class="text-right" style="width: 15%;">Price</th>
                        <th class="text-center" style="width: 10%;">Qty.</th>
                        <th class="text-right" style="width: 12%;">Subtotal</th>
                        <th class="text-right" style="width: 13%;">Total</th>
                    </tr>
                </thead>
                <tbody>

                    <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="text-left text-muted"><%# Container.ItemIndex + 1 %></td>
                                <td class="text-left font-semibold text-dark"><%# Eval("product_name") %></td>
                                <td class="text-right"><%# Eval("product_market_price") %></td>
                                <td class="text-center"><%# Eval("product_qty") %></td>
                                <td class="text-right"><%# Eval("total_amount_of_product") %></td>
                                <td class="text-right font-semibold text-dark"><%# Eval("total_order_amount") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
        </div>

        <!-- Invoice Totals Summary -->
        <div class="invoice-summary-wrap">
            <div class="invoice-summary-card">
                <div class="summary-row">
                    <span class="summary-label">Net Total:</span>
                    <div class="summary-value" id="nettotal" runat="server"></div>
                </div>

                <div class="summary-row">
                    <span class="summary-label">Shipping Amount:</span>
                    <div class="summary-value">100.00</div>
                </div>

                <div class="summary-row total-row">
                    <span class="summary-label font-bold">Total:</span>
                    <div class="summary-value font-bold" id="totalamt" runat="server"></div>
                </div>
            </div>
        </div>

        <!-- Notes -->
        <div class="invoice-notes-box">
            <div class="notes-header">
                <i class="bi bi-info-circle"></i> Notes
            </div>
            <p class="notes-text">
                This is a computer-generated invoice and does not require a signature.
            </p>
        </div>

        <!-- In-Flow Clean Footer -->
        <footer class="invoice-footer">
            <p class="footer-company">The Furniture Mart</p>
            <div class="footer-contact">
                <span><i class="bi bi-envelope"></i> info@thefmart.com</span>
                <span class="separator">|</span>
                <span><i class="bi bi-telephone"></i> +91-9235501383</span>
            </div>
            <p class="footer-thanks">Thank you for your business!</p>
        </footer>

    </div>

</body>

</html>
