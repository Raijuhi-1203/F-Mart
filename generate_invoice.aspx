<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generate_invoice.aspx.cs" Inherits="generate_invoice" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>F-MART | Invoice</title>

    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700&display=swap" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet">

    <style>
        :root {
            --primary: #009bb5;
            --orange: #f58b49;
            --dark: #075e6b;
            --text: #202833;
            --muted: #6b7280;
            --border: #e8edf0;
            --light: #f7fafb;
        }

        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Poppins', sans-serif;
            color: var(--text);
            background: #f5f7f8;
            font-size: 13px;
        }

        .topbar {
            background: var(--orange);
            color: white;
            padding: 9px 0;
            font-size: 11px;
        }

        .topbar-inner,
        .header-inner,
        .nav-inner,
        .container,
        .footer-inner {
            width: min(1120px, 92%);
            margin: auto;
        }

        .topbar-inner {
            display: flex;
            justify-content: space-between;
            gap: 12px;
        }

        .header {
            background: white;
            padding: 17px 0;
        }

        .header-inner {
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 20px;
        }

        .logo {
            display: inline-block;
            border: 2px solid var(--orange);
            background: var(--dark);
            color: white;
            padding: 5px 9px;
            font-family: Georgia, serif;
            font-style: italic;
            font-size: 23px;
            font-weight: bold;
            line-height: 1.1;
            white-space: nowrap;
        }

            .logo small {
                display: block;
                font-family: 'Poppins', sans-serif;
                font-style: normal;
                font-size: 7px;
                font-weight: 400;
                text-align: center;
                border-top: 1px solid var(--orange);
                padding-top: 3px;
            }

        .header-actions {
            display: flex;
            gap: 20px;
            color: #46505b;
            font-size: 17px;
        }

        .nav {
            background: var(--primary);
            color: white;
        }

        .nav-inner {
            display: flex;
            gap: 27px;
            padding: 12px 0;
            overflow-x: auto;
            white-space: nowrap;
            font-size: 11px;
        }

        .breadcrumb {
            background: #f0f2f3;
            padding: 15px 0;
        }

        .breadcrumb-inner {
            display: flex;
            justify-content: space-between;
            align-items: center;
            gap: 12px;
        }

        .breadcrumb h2 {
            font-size: 19px;
            color: #151b22;
        }

        .breadcrumb span {
            color: var(--muted);
            font-size: 11px;
        }

        .container {
            padding: 30px 0 55px;
        }

        .page-heading {
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 22px;
            gap: 15px;
        }

            .page-heading h3 {
                font-size: 21px;
            }

            .page-heading p {
                color: var(--muted);
                font-size: 11px;
                margin-top: 4px;
            }

        .actions {
            display: flex;
            gap: 9px;
            flex-wrap: wrap;
        }

        .btn {
            border: 0;
            border-radius: 5px;
            padding: 11px 16px;
            font-family: inherit;
            font-size: 11px;
            font-weight: 600;
            cursor: pointer;
        }

        .btn-primary {
            background: var(--primary);
            color: white;
        }

        .btn-outline {
            background: white;
            border: 1px solid var(--border);
            color: #303944;
        }

        .invoice {
            background: white;
            border: 1px solid #edf0f2;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 5px 22px rgba(0, 0, 0, .035);
        }

        .invoice-banner {
            background: var(--dark);
            color: white;
            padding: 26px 30px;
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 20px;
        }

            .invoice-banner .logo {
                margin-bottom: 13px;
            }

            .invoice-banner p {
                font-size: 10px;
                line-height: 1.8;
                color: #d9f1f4;
            }

        .invoice-label {
            text-align: right;
        }

            .invoice-label h1 {
                font-size: 29px;
                letter-spacing: 2px;
            }

            .invoice-label p {
                font-size: 12px;
            }

        .invoice-body {
            padding: 28px 30px;
        }

        .info-grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 30px;
            margin-bottom: 30px;
        }

        .section-title {
            font-size: 13px;
            font-weight: 600;
            padding-bottom: 12px;
            margin-bottom: 14px;
            border-bottom: 1px solid var(--border);
        }

        .info-block p {
            line-height: 2;
            color: #525c67;
            overflow-wrap: anywhere;
        }

        .info-block strong {
            color: #202833;
            font-weight: 500;
        }

        .status {
            display: inline-block;
            background: #e5f7ed;
            color: #16804a;
            border-radius: 4px;
            padding: 5px 10px;
            font-size: 10px;
            font-weight: 600;
        }

        .table-wrap {
            width: 100%;
            overflow-x: auto;
            margin-bottom: 24px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            min-width: 570px;
        }

        thead {
            background: #f0f8fa;
        }

        th {
            font-size: 11px;
            font-weight: 600;
            text-align: left;
            color: #36434c;
            padding: 14px 12px;
        }

        td {
            padding: 17px 12px;
            border-bottom: 1px solid var(--border);
            font-size: 11px;
            vertical-align: middle;
        }

            th:last-child,
            td:last-child {
                text-align: right;
            }

            td.center,
            th.center {
                text-align: center;
            }

        .product {
            display: flex;
            align-items: center;
            gap: 12px;
            min-width: 190px;
        }

        .product-img {
            width: 52px;
            height: 52px;
            border-radius: 6px;
            background: #f5f7f8;
            display: flex;
            align-items: center;
            justify-content: center;
            color: #8a9299;
            font-size: 21px;
            flex-shrink: 0;
        }

        .product-name {
            font-weight: 600;
            color: #1d2730;
        }

        .product-sku {
            color: var(--muted);
            font-size: 10px;
            margin-top: 5px;
        }

        .totals {
            width: min(350px, 100%);
            margin-left: auto;
        }

        .total-row {
            display: flex;
            justify-content: space-between;
            gap: 20px;
            padding: 9px 0;
            color: #58616b;
            font-size: 12px;
        }

            .total-row.grand-total {
                margin-top: 6px;
                padding: 15px 0;
                border-top: 1px solid var(--border);
                color: #121920;
                font-size: 16px;
                font-weight: 700;
            }

        .amount-words {
            background: #f6fafb;
            border: 1px solid #e8f0f2;
            border-radius: 6px;
            padding: 14px;
            margin-top: 18px;
            line-height: 1.9;
            font-size: 11px;
        }

        .payment-note {
            margin-top: 28px;
            padding-top: 20px;
            border-top: 1px dashed #dce2e5;
            display: flex;
            justify-content: space-between;
            gap: 25px;
        }

            .payment-note p {
                color: var(--muted);
                line-height: 1.9;
                font-size: 10px;
            }

            .payment-note strong {
                color: #27323a;
            }

        .thank-you {
            text-align: center;
            background: #f2fafb;
            color: var(--dark);
            padding: 18px;
            font-size: 12px;
            font-weight: 600;
        }

        .footer {
            background: #005e6b;
            color: white;
            padding: 45px 0 0;
        }

        .footer-inner {
            display: grid;
            grid-template-columns: 1.5fr .7fr .7fr 1.3fr;
            gap: 35px;
            padding-bottom: 35px;
        }

        .footer h4 {
            font-size: 13px;
            margin-bottom: 16px;
        }

        .footer p,
        .footer li {
            font-size: 10px;
            color: #d0e6e9;
            line-height: 2;
        }

        .footer ul {
            list-style: none;
        }

        .copyright {
            border-top: 1px solid rgba(255,255,255,.12);
            padding: 17px 0;
            text-align: center;
            font-size: 10px;
            color: #d0e6e9;
        }

        @media (max-width: 700px) {
            .topbar-inner span:last-child {
                display: none;
            }

            .header-inner {
                flex-wrap: wrap;
            }

            .nav-inner {
                gap: 20px;
            }

            .page-heading {
                align-items: flex-start;
                flex-direction: column;
            }

            .invoice-banner {
                padding: 22px 18px;
            }

            .invoice-label h1 {
                font-size: 22px;
            }

            .invoice-body {
                padding: 22px 16px;
            }

            .info-grid {
                grid-template-columns: 1fr;
                gap: 22px;
            }

            .payment-note {
                flex-direction: column;
            }

            .footer-inner {
                grid-template-columns: 1fr 1fr;
                gap: 25px;
            }
        }

        @media (max-width: 400px) {
            .invoice-banner {
                align-items: flex-start;
                flex-direction: column;
            }

            .invoice-label {
                text-align: left;
            }

            .footer-inner {
                grid-template-columns: 1fr;
            }
        }

        @media print {
            @page {
                size: A4;
                margin: 12mm;
            }

            body {
                background: white;
                font-size: 10px;
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
            }

            .topbar, .header, .nav, .breadcrumb, .footer,
            .page-heading .actions {
                display: none !important;
            }

            .container {
                width: 100%;
                padding: 0;
            }

            .page-heading {
                margin-bottom: 12px;
            }

            .invoice {
                box-shadow: none;
                border: 1px solid #ddd;
            }

            .invoice-banner {
                padding: 18px;
            }

            .invoice-body {
                padding: 20px;
            }

            .info-grid, .table-wrap, .totals, .payment-note {
                break-inside: avoid;
            }

            .btn {
                display: none;
            }
        }
    </style>

</head>

<body>

    <main class="container">

        <div class="page-heading">
            <div>
                <h3>Order Invoice</h3>
                <p>Thank you for shopping with F-MART Furniture.</p>
            </div>

            <div class="actions">
                <button class="btn btn-outline" onclick="window.location.href='index.aspx';">
                    <i class="fa-solid fa-arrow-left"></i> Back To Home
                </button>
                <button class="btn btn-outline" onclick="window.print()">
                    <i class="fa-solid fa-print"></i> Print Invoice
                </button>

            </div>
        </div>

        <section class="invoice">

            <div class="invoice-banner">
                <div>
                    <div>
                        <img src="assets/img/logo.png" style="width: 100px;" />
                    </div>
                    <p>
                        Furniture Mart<br>
                        Bank Road, Vindhyavasini Nagar,<br>
                        Gorakhpur, Uttar Pradesh - 273001<br>
                        Phone: +91-92355 01383<br />
                        GSTIN: 09BOBPS4739C1ZU
                    </p>
                </div>

                <div class="invoice-label">
                    <h1>INVOICE</h1>
                    <p>Invoice Date: <strong runat="server" id="dt">10 Oct 2026</strong></p>
                    <p>Order ID: <strong runat="server" id="ordid">ORD-00125</strong></p>
                    <br>
                    <span class="status">PAYMENT DONE</span>
                </div>
            </div>

            <div class="invoice-body">

                <div class="info-grid">

                    <div class="info-block">
                        <div class="section-title">
                            <i class="fa-regular fa-user"></i>&nbsp; BILL TO
                        </div>
                        <p><strong id="sname" runat="server">Juhi Rai</strong></p>
                        <p id="smail" runat="server">Email: juhi.digitalbull@gmail.com</p>
                        <p id="smob" runat="server">Phone: 09236426001</p>
                    </div>

                    <div class="info-block">
                        <div class="section-title">
                            <i class="fa-solid fa-location-dot"></i>&nbsp; SHIPPING ADDRESS
                        </div>
                        <p><strong id="name" runat="server">Juhi Rai</strong></p>
                        <p id="add" runat="server">3rd Floor, Mobile Plaza</p>
                        <p id="add2" runat="server">Khowa Mandi Gali, Golghar</p>
                        <p id="add3" runat="server">Gorakhpur, Uttar Pradesh - 273010</p>
                    </div>

                </div>

                <div class="section-title">
                    <i class="fa-solid fa-box"></i>&nbsp; ORDER ITEMS
                </div>

                <div class="table-wrap">
                    <table>
                        <thead>
                            <tr>
                                <th>Product</th>
                                <th class="center">Price</th>
                                <th class="center">Qty</th>
                                <th class="center">Shipping</th>
                                <th>Amount</th>
                            </tr>
                        </thead>

                        <tbody>

                            <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand" OnItemDataBound="rptbinddata_ItemDataBound">
                                <ItemTemplate>

                                    <tr>
                                        <td>
                                            <div class="product">
                                                <div class="product-img">
                                                    <i class="fa-solid fa-chair"></i>
                                                </div>
                                                <div>
                                                    <div class="product-name">
                                                        <%# Eval("product_name") %>
                                                    </div>
                                                    
                                                </div>
                                            </div>
                                        </td>
                                        <td class="center">₹ <%# Eval("product_sell_price") %></td>
                                        <td class="center"><%# Eval("product_unit_value") %> <%# Eval("product_unit") %></td>
                                        <td class="center">₹ <%# Eval("product_shipping_charge") %></td>
                                        <td>₹ <%# Eval("product_final_sell_price") %></td>
                                    </tr>

                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>
                </div>

                <div class="totals">
                    <div class="total-row">
                        <span>Subtotal</span>
                        <span id="subtotal" runat="server">₹7,850.00</span>
                    </div>

                    <div class="total-row">
                        <span>Shipping Charges</span>
                        <span id="shipping" runat="server">₹100.00</span>
                    </div>

                    <div class="total-row">
                        <span>Tax / GST  (18%)</span>
                        <span id="gst" runat="server">₹ 0.00</span>
                    </div>

                    <div class="total-row grand-total">
                        <span>Grand Total</span>
                        <span id="gtotal" runat="server">₹7,950.00</span>
                    </div>
                </div>



                <div class="payment-note">
                    <div>
                        <strong>Payment Information</strong>
                        <p>Payment Method: Online / Cash on Delivery</p>
                        <p>Transaction ID: To be updated</p>
                        <p>Payment Status: Pending</p>
                    </div>

                    <div>
                        <strong>Terms &amp; Conditions</strong>
                        <p>1. Please retain this invoice for your records.</p>
                        <p>2. Product warranty is subject to manufacturer terms.</p>
                        <p>3. Contact our support team for order-related queries.</p>
                    </div>
                </div>

            </div>

            <div class="thank-you">
                Thank you for choosing F-MART! We appreciate your business.
            </div>

        </section>

    </main>


</body>
</html>
