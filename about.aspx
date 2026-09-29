<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Scoped Styles for About Page -->
    <style>
        /* Base typography & color accents */
        :root {
            --about-accent: #0097b2;
            --about-accent-soft: rgba(0, 151, 178, 0.08);
            --about-accent-glow: rgba(0, 151, 178, 0.2);
            --about-dark: #0f172a;
            --about-slate: #334155;
            --about-muted: #64748b;
            --about-border: #e2e8f0;
        }

        /* Top Hero Story Section */
        .about-story-section {
            padding: 70px 0 60px 0;
            background: #ffffff;
            position: relative;
            overflow: hidden;
        }

        .about-badge {
            display: inline-flex;
            align-items: center;
            gap: 8px;
            padding: 7px 18px;
            border-radius: 50px;
            background: rgba(0, 151, 178, 0.1);
            color: #0097b2;
            font-size: 0.85rem;
            font-weight: 700;
            letter-spacing: 0.5px;
            text-transform: uppercase;
            margin-bottom: 1.25rem;
            border: 1px solid rgba(0, 151, 178, 0.2);
        }

        .about-main-title {
            font-family: var(--heading-font, 'Montserrat', sans-serif);
            font-size: clamp(1.45rem, 3.2vw, 2.75rem);
            font-weight: 800;
            line-height: 1.2;
            color: #0f172a;
            margin-bottom: 1.25rem;
            letter-spacing: -0.5px;
        }

        .about-main-title span {
            color: #0097b2;
            position: relative;
        }

        .about-lead {
            font-size: 1.075rem;
            line-height: 1.75;
            color: #334155;
            margin-bottom: 1.25rem;
            font-weight: 400;
        }

        .about-lead strong {
            color: #0f172a;
            font-weight: 700;
        }

        .about-body-text {
            font-size: 0.975rem;
            line-height: 1.75;
            color: #64748b;
            margin-bottom: 1.5rem;
        }

        .about-vision-card {
            background: linear-gradient(135deg, #f8fafc 0%, #f0fdfa 100%);
            border-left: 4px solid #0097b2;
            border-radius: 0 16px 16px 0;
            padding: 18px 22px;
            margin-bottom: 1.75rem;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.03);
            border-top: 1px solid rgba(226, 232, 240, 0.8);
            border-right: 1px solid rgba(226, 232, 240, 0.8);
            border-bottom: 1px solid rgba(226, 232, 240, 0.8);
        }

        .about-vision-card h6 {
            font-size: 0.95rem;
            font-weight: 700;
            color: #0f172a;
            margin-bottom: 6px;
            display: flex;
            align-items: center;
            gap: 8px;
        }

        .about-vision-card h6 i {
            color: #0097b2;
            font-size: 1.1rem;
        }

        .about-vision-card p {
            font-size: 0.92rem;
            line-height: 1.65;
            color: #475569;
            margin-bottom: 0;
        }

        .about-highlights {
            display: flex;
            flex-wrap: wrap;
            gap: 12px 20px;
        }

        .about-pill-item {
            display: inline-flex;
            align-items: center;
            gap: 8px;
            padding: 6px 14px;
            background: #ffffff;
            border: 1px solid #e2e8f0;
            border-radius: 50px;
            font-size: 0.85rem;
            font-weight: 600;
            color: #1e293b;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.04);
            transition: all 0.25s ease;
        }

        .about-pill-item i {
            color: #0097b2;
            font-size: 1rem;
        }

        .about-pill-item:hover {
            border-color: #0097b2;
            transform: translateY(-2px);
        }

        /* Right Side Chair Showcase */
        .about-chair-showcase {
            position: relative;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 30px 15px;
            min-height: 480px;
        }

        .chair-glow-backdrop {
            position: absolute;
            width: 380px;
            height: 380px;
            border-radius: 50%;
            background: radial-gradient(circle, rgba(0, 151, 178, 0.16) 0%, rgba(224, 242, 254, 0.5) 60%, transparent 80%);
            z-index: 1;
            filter: blur(15px);
            animation: pulseGlow 6s ease-in-out infinite alternate;
        }

        .about-chair-img {
            position: relative;
            z-index: 2;
            max-width: 100%;
            max-height: 450px;
            object-fit: contain;
            filter: drop-shadow(0 25px 35px rgba(15, 23, 42, 0.18));
            transition: transform 0.6s cubic-bezier(0.2, 0.8, 0.2, 1);
        }

        .about-chair-showcase:hover .about-chair-img {
            transform: scale(1.04) translateY(-8px);
        }

        /* Floating Cards */
        .floating-badge {
            position: absolute;
            z-index: 3;
            background: rgba(255, 255, 255, 0.94);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            padding: 12px 18px;
            border-radius: 16px;
            box-shadow: 0 15px 30px -5px rgba(0, 0, 0, 0.12), 0 8px 10px -6px rgba(0, 0, 0, 0.05);
            border: 1px solid rgba(226, 232, 240, 0.9);
            display: flex;
            align-items: center;
            gap: 12px;
            transition: all 0.3s ease;
        }

        .floating-badge.badge-top {
            top: 20px;
            left: 5px;
            animation: floatTop 4.5s ease-in-out infinite alternate;
        }

        .floating-badge.badge-bottom {
            bottom: 25px;
            right: 5px;
            animation: floatBottom 4.5s ease-in-out infinite alternate 1s;
        }

        .floating-badge-icon {
            width: 44px;
            height: 44px;
            border-radius: 12px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 1.25rem;
            flex-shrink: 0;
        }

        .floating-badge-icon.icon-teal {
            background: rgba(0, 151, 178, 0.12);
            color: #0097b2;
        }

        .floating-badge-icon.icon-gold {
            background: #fef3c7;
            color: #d97706;
        }

        .floating-badge-text strong {
            display: block;
            font-size: 0.925rem;
            color: #0f172a;
            font-weight: 700;
            line-height: 1.2;
        }

        .floating-badge-text span {
            font-size: 0.775rem;
            color: #64748b;
        }

        @keyframes floatTop {
            0% { transform: translateY(0px); }
            100% { transform: translateY(-10px); }
        }

        @keyframes floatBottom {
            0% { transform: translateY(0px); }
            100% { transform: translateY(10px); }
        }

        @keyframes pulseGlow {
            0% { transform: scale(0.95); opacity: 0.7; }
            100% { transform: scale(1.08); opacity: 1; }
        }

        /* Quality You Can Trust Row (Features Row) */
        .features-section-wrap {
            padding: 60px 0 70px 0;
            background: #fafcfc;
            border-top: 1px solid #f1f5f9;
        }

        .features-intro-header {
            margin-bottom: 45px;
        }

        .features-intro-header h3 {
            font-family: var(--heading-font, 'Montserrat', sans-serif);
            font-size: clamp(1.25rem, 2.5vw, 2.1rem);
            font-weight: 800;
            color: #0f172a;
            margin-bottom: 8px;
        }

        .features-intro-header p {
            color: #64748b;
            font-size: 0.95rem;
        }

        .trust-feature-card {
            background: #ffffff;
            border: 1px solid #e2e8f0;
            border-radius: 18px;
            padding: 32px 28px;
            height: 100%;
            display: flex;
            flex-direction: column;
            position: relative;
            overflow: hidden;
            transition: all 0.4s cubic-bezier(0.165, 0.84, 0.44, 1);
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.03);
        }

        .trust-feature-card::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            height: 4px;
            background: linear-gradient(90deg, #0097b2, #38bdf8);
            transform: scaleX(0);
            transform-origin: left;
            transition: transform 0.4s ease;
        }

        .trust-feature-card:hover {
            transform: translateY(-8px);
            border-color: rgba(0, 151, 178, 0.35);
            box-shadow: 0 20px 30px -10px rgba(0, 151, 178, 0.12), 0 8px 10px -6px rgba(0, 151, 178, 0.04);
        }

        .trust-feature-card:hover::before {
            transform: scaleX(1);
        }

        .trust-feature-icon {
            width: 62px;
            height: 62px;
            border-radius: 16px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 1.75rem;
            margin-bottom: 22px;
            transition: all 0.35s ease;
        }

        .trust-feature-card:nth-child(1) .trust-feature-icon {
            background: rgba(0, 151, 178, 0.1);
            color: #0097b2;
        }

        .trust-feature-card:nth-child(2) .trust-feature-icon {
            background: rgba(245, 158, 11, 0.12);
            color: #d97706;
        }

        .trust-feature-card:nth-child(3) .trust-feature-icon {
            background: rgba(139, 92, 246, 0.12);
            color: #7c3aed;
        }

        .trust-feature-card:hover .trust-feature-icon {
            transform: scale(1.1) rotate(4deg);
        }

        .trust-feature-card h4 {
            font-family: var(--heading-font, 'Montserrat', sans-serif);
            font-size: 1.25rem;
            font-weight: 700;
            color: #0f172a;
            margin-bottom: 12px;
        }

        .trust-feature-card p {
            color: #64748b;
            font-size: 0.95rem;
            line-height: 1.65;
            margin-bottom: 20px;
            flex-grow: 1;
        }

        .trust-feature-tag {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            font-size: 0.8rem;
            font-weight: 600;
            color: #0097b2;
            background: rgba(0, 151, 178, 0.08);
            padding: 5px 12px;
            border-radius: 20px;
            align-self: flex-start;
        }

        /* Workspace Banner */
        .workspace-banner-box {
            position: relative;
            border-radius: 24px;
            overflow: hidden;
            box-shadow: 0 20px 40px -10px rgba(15, 23, 42, 0.15);
            margin-top: 50px;
        }

        .workspace-banner-box img {
            width: 100%;
            height: auto;
            max-height: 440px;
            object-fit: cover;
            display: block;
            transition: transform 0.6s ease;
        }

        .workspace-banner-box:hover img {
            transform: scale(1.02);
        }

        .workspace-banner-overlay {
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            padding: 35px 40px;
            background: linear-gradient(to top, rgba(15, 23, 42, 0.9) 0%, rgba(15, 23, 42, 0.5) 60%, transparent 100%);
            color: #ffffff;
        }

        .workspace-banner-pill {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            padding: 5px 14px;
            background: rgba(255, 255, 255, 0.2);
            backdrop-filter: blur(8px);
            border-radius: 50px;
            font-size: 0.8rem;
            font-weight: 600;
            margin-bottom: 10px;
            color: #e0f2fe;
            border: 1px solid rgba(255, 255, 255, 0.3);
        }

        .workspace-banner-overlay h4 {
            font-size: 1.45rem;
            font-weight: 700;
            color: #ffffff;
            margin-bottom: 4px;
        }

        .workspace-banner-overlay p {
            color: rgba(255, 255, 255, 0.8);
            font-size: 0.925rem;
            margin-bottom: 0;
        }

        /* Stats Modern Section */
        .stats-modern-section {
            padding: 65px 0;
            background: linear-gradient(135deg, #0f172a 0%, #1e293b 100%);
            position: relative;
            overflow: hidden;
        }

        .stats-modern-section::before {
            content: '';
            position: absolute;
            top: -50%;
            right: -20%;
            width: 500px;
            height: 500px;
            background: radial-gradient(circle, rgba(0, 151, 178, 0.18) 0%, transparent 70%);
            border-radius: 50%;
            pointer-events: none;
        }

        .stat-modern-card {
            background: rgba(255, 255, 255, 0.05);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            border: 1px solid rgba(255, 255, 255, 0.1);
            border-radius: 20px;
            padding: 30px 24px;
            height: 100%;
            transition: all 0.35s ease;
            position: relative;
        }

        .stat-modern-card:hover {
            transform: translateY(-6px);
            background: rgba(255, 255, 255, 0.09);
            border-color: rgba(0, 151, 178, 0.5);
            box-shadow: 0 15px 30px rgba(0, 0, 0, 0.25);
        }

        .stat-modern-icon {
            width: 54px;
            height: 54px;
            border-radius: 14px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 1.6rem;
            margin-bottom: 18px;
        }

        .stat-icon-1 { background: rgba(56, 189, 248, 0.18); color: #38bdf8; }
        .stat-icon-2 { background: rgba(52, 211, 153, 0.18); color: #34d399; }
        .stat-icon-3 { background: rgba(167, 139, 250, 0.18); color: #a78bfa; }
        .stat-icon-4 { background: rgba(251, 191, 36, 0.18); color: #fbbf24; }

        .stat-number-wrap {
            display: flex;
            align-items: baseline;
            gap: 2px;
            margin-bottom: 6px;
        }

        .stat-modern-card .purecounter {
            font-family: var(--heading-font, 'Montserrat', sans-serif);
            font-size: 2.6rem;
            font-weight: 800;
            color: #ffffff;
            line-height: 1;
        }

        .stat-modern-card .stat-plus {
            font-size: 1.8rem;
            font-weight: 800;
            color: #38bdf8;
            line-height: 1;
        }

        .stat-modern-card h5 {
            font-size: 1.05rem;
            font-weight: 700;
            color: #f8fafc;
            margin-bottom: 6px;
        }

        .stat-modern-card p {
            font-size: 0.85rem;
            color: #94a3b8;
            line-height: 1.55;
            margin-bottom: 0;
        }

        /* Reviews / Testimonials Section */
        .reviews-modern-section {
            padding: 85px 0 80px 0;
            background: #ffffff;
        }

        .reviews-section-header {
            margin-bottom: 50px;
        }

        .reviews-section-header h2 {
            font-family: var(--heading-font, 'Montserrat', sans-serif);
            font-size: clamp(1.35rem, 3vw, 2.6rem);
            font-weight: 800;
            color: #0f172a;
            margin-top: 10px;
            margin-bottom: 12px;
        }

        .reviews-section-header p {
            color: #64748b;
            font-size: 1rem;
            max-width: 620px;
            margin: 0 auto;
        }

        .about-review-card {
            background: #ffffff;
            border: 1px solid #e2e8f0;
            border-radius: 20px;
            padding: 32px 28px;
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            position: relative;
            transition: all 0.35s cubic-bezier(0.165, 0.84, 0.44, 1);
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.03);
        }

        .about-review-card:hover {
            transform: translateY(-7px);
            border-color: rgba(0, 151, 178, 0.4);
            box-shadow: 0 20px 30px -8px rgba(0, 151, 178, 0.1), 0 8px 10px -6px rgba(0, 0, 0, 0.03);
        }

        .review-card-top {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 18px;
        }

        .review-stars {
            display: flex;
            gap: 4px;
            color: #f59e0b;
            font-size: 0.95rem;
        }

        .review-quote-mark {
            font-size: 2.2rem;
            color: rgba(0, 151, 178, 0.18);
            line-height: 1;
        }

        .about-review-text {
            color: #334155;
            font-size: 0.965rem;
            line-height: 1.7;
            margin-bottom: 24px;
            font-style: normal;
        }

        .review-author-wrap {
            display: flex;
            align-items: center;
            gap: 14px;
            padding-top: 18px;
            border-top: 1px solid #f1f5f9;
            margin-top: auto;
        }

        .review-author-avatar {
            width: 52px;
            height: 52px;
            border-radius: 50%;
            object-fit: cover;
            border: 2px solid rgba(0, 151, 178, 0.25);
            padding: 2px;
            background: #ffffff;
            flex-shrink: 0;
        }

        .review-author-info h6 {
            font-size: 1rem;
            font-weight: 700;
            color: #0f172a;
            margin-bottom: 3px;
            display: flex;
            align-items: center;
            gap: 5px;
        }

        .review-author-info h6 i {
            color: #0097b2;
            font-size: 0.85rem;
        }

        .review-author-role {
            font-size: 0.825rem;
            color: #0097b2;
            font-weight: 600;
            display: block;
        }

        /* ==============================================
           Responsive Typography & Spacing for Tablets & Phones
           (Design preserved 100%, optimized font scaling for mobile)
           ============================================== */
        @media (max-width: 991px) {
            .about-story-section {
                padding: 55px 0 45px 0;
            }
            .about-chair-showcase {
                min-height: 380px;
                margin-top: 20px;
            }
            .about-chair-img {
                max-height: 340px;
            }
            .floating-badge.badge-top {
                top: 5px;
                left: 0;
            }
            .floating-badge.badge-bottom {
                bottom: 5px;
                right: 0;
            }
            .workspace-banner-overlay {
                padding: 24px 28px;
            }
            .workspace-banner-overlay h4 {
                font-size: 1.25rem;
            }
        }

        @media (max-width: 767px) {
            /* Page Header */
            .page-title {
                padding: 18px 0;
            }
            .page-title h1 {
                font-size: 1.5rem !important;
            }
            .page-title .breadcrumbs ol {
                font-size: 0.85rem !important;
            }

            /* Hero Story Section */
            .about-story-section {
                padding: 42px 0 35px 0;
            }
            .about-story-section .row.g-5 {
                --bs-gutter-y: 1.75rem;
            }
            .about-badge {
                font-size: 0.78rem;
                padding: 6px 14px;
                margin-bottom: 1rem;
            }
            .about-main-title {
                font-size: 1.75rem;
                line-height: 1.25;
                margin-bottom: 1rem;
            }
            .about-lead {
                font-size: 0.95rem;
                line-height: 1.65;
                margin-bottom: 1rem;
            }
            .about-body-text {
                font-size: 0.885rem;
                line-height: 1.65;
                margin-bottom: 1.25rem;
            }
            .about-vision-card {
                padding: 14px 16px;
                margin-bottom: 1.25rem;
                border-radius: 0 14px 14px 0;
            }
            .about-vision-card h6 {
                font-size: 0.9rem;
                margin-bottom: 4px;
            }
            .about-vision-card p {
                font-size: 0.84rem;
                line-height: 1.55;
            }
            .about-highlights {
                gap: 8px 12px;
            }
            .about-pill-item {
                font-size: 0.8rem;
                padding: 5px 12px;
            }

            /* Chair Showcase & Floating Badges */
            .about-chair-showcase {
                min-height: 320px;
                padding: 20px 10px;
                margin-top: 10px;
            }
            .chair-glow-backdrop {
                width: 280px;
                height: 280px;
                max-width: 80vw;
            }
            .about-chair-img {
                max-height: 280px;
            }
            .floating-badge {
                padding: 8px 12px;
                border-radius: 14px;
            }
            .floating-badge-icon {
                width: 36px;
                height: 36px;
                font-size: 1rem;
                border-radius: 10px;
            }
            .floating-badge-text strong {
                font-size: 0.82rem;
            }
            .floating-badge-text span {
                font-size: 0.7rem;
            }

            /* Features Section */
            .features-section-wrap {
                padding: 45px 0 50px 0;
            }
            .features-intro-header {
                margin-bottom: 30px;
            }
            .features-intro-header h3 {
                font-size: 1.45rem;
                margin-bottom: 6px;
            }
            .features-intro-header p {
                font-size: 0.88rem;
                line-height: 1.55;
            }
            .trust-feature-card {
                padding: 24px 20px;
                border-radius: 16px;
            }
            .trust-feature-icon {
                width: 52px;
                height: 52px;
                font-size: 1.5rem;
                margin-bottom: 16px;
                border-radius: 14px;
            }
            .trust-feature-card h4 {
                font-size: 1.15rem;
                margin-bottom: 8px;
            }
            .trust-feature-card p {
                font-size: 0.875rem;
                line-height: 1.6;
                margin-bottom: 16px;
            }
            .trust-feature-tag {
                font-size: 0.76rem;
                padding: 4px 11px;
            }
            .workspace-banner-box {
                margin-top: 30px;
                border-radius: 18px;
            }
            .workspace-banner-overlay {
                padding: 20px 22px;
            }
            .workspace-banner-pill {
                font-size: 0.74rem;
                padding: 4px 12px;
                margin-bottom: 8px;
            }
            .workspace-banner-overlay h4 {
                font-size: 1.15rem;
                margin-bottom: 4px;
            }
            .workspace-banner-overlay p {
                font-size: 0.82rem;
            }

            /* Stats Section */
            .stats-modern-section {
                padding: 45px 0;
            }
            .stat-modern-card {
                padding: 22px 18px;
                border-radius: 16px;
            }
            .stat-modern-icon {
                width: 46px;
                height: 46px;
                font-size: 1.35rem;
                margin-bottom: 14px;
                border-radius: 12px;
            }
            .stat-modern-card .purecounter {
                font-size: 2rem;
            }
            .stat-modern-card .stat-plus {
                font-size: 1.45rem;
            }
            .stat-modern-card h5 {
                font-size: 0.95rem;
                margin-bottom: 4px;
            }
            .stat-modern-card p {
                font-size: 0.8rem;
                line-height: 1.5;
            }

            /* Reviews Section */
            .reviews-modern-section {
                padding: 50px 0 50px 0;
            }
            .reviews-section-header {
                margin-bottom: 30px;
            }
            .reviews-section-header h2 {
                font-size: 1.55rem;
                margin-top: 8px;
                margin-bottom: 8px;
            }
            .reviews-section-header p {
                font-size: 0.88rem;
                line-height: 1.55;
            }
            .about-review-card {
                padding: 24px 20px;
                border-radius: 16px;
            }
            .about-review-text {
                font-size: 0.885rem;
                line-height: 1.62;
                margin-bottom: 18px;
            }
            .review-quote-mark {
                font-size: 1.8rem;
            }
            .review-stars {
                font-size: 0.88rem;
            }
            .review-author-wrap {
                padding-top: 14px;
                gap: 12px;
            }
            .review-author-avatar {
                width: 46px;
                height: 46px;
            }
            .review-author-info h6 {
                font-size: 0.925rem;
            }
            .review-author-role {
                font-size: 0.775rem;
            }
        }

        @media (max-width: 576px) {
            /* Compact mobile screen optimization */
            .page-title {
                padding: 15px 0;
            }
            .page-title h1 {
                font-size: 1.35rem !important;
            }
            .page-title .breadcrumbs ol {
                font-size: 0.8rem !important;
            }

            .about-story-section {
                padding: 35px 0 30px 0;
            }
            .about-badge {
                font-size: 0.75rem;
                padding: 5px 12px;
                margin-bottom: 0.85rem;
                gap: 6px;
            }
            .about-main-title {
                font-size: 1.45rem;
                line-height: 1.25;
                margin-bottom: 0.85rem;
                letter-spacing: -0.3px;
            }
            .about-lead {
                font-size: 0.9rem;
                line-height: 1.6;
                margin-bottom: 0.85rem;
            }
            .about-body-text {
                font-size: 0.85rem;
                line-height: 1.6;
                margin-bottom: 1rem;
            }
            .about-vision-card {
                padding: 12px 14px;
                margin-bottom: 1rem;
                border-radius: 0 12px 12px 0;
            }
            .about-vision-card h6 {
                font-size: 0.865rem;
                margin-bottom: 4px;
            }
            .about-vision-card p {
                font-size: 0.8rem;
                line-height: 1.5;
            }
            .about-highlights {
                gap: 6px 8px;
            }
            .about-pill-item {
                font-size: 0.75rem;
                padding: 4px 10px;
                gap: 5px;
            }

            /* Chair Showcase on Small Phones */
            .about-chair-showcase {
                min-height: 270px;
                padding: 15px 5px;
                margin-top: 5px;
            }
            .chair-glow-backdrop {
                width: 240px;
                height: 240px;
            }
            .about-chair-img {
                max-height: 240px;
            }
            .floating-badge {
                padding: 6px 10px;
                border-radius: 12px;
                gap: 8px;
            }
            .floating-badge-icon {
                width: 32px;
                height: 32px;
                font-size: 0.9rem;
                border-radius: 8px;
            }
            .floating-badge-text strong {
                font-size: 0.75rem;
            }
            .floating-badge-text span {
                font-size: 0.65rem;
            }

            /* Features */
            .features-section-wrap {
                padding: 35px 0 40px 0;
            }
            .features-intro-header {
                margin-bottom: 22px;
            }
            .features-intro-header h3 {
                font-size: 1.25rem;
                margin-bottom: 5px;
            }
            .features-intro-header p {
                font-size: 0.825rem;
            }
            .trust-feature-card {
                padding: 20px 16px;
                border-radius: 14px;
            }
            .trust-feature-icon {
                width: 44px;
                height: 44px;
                font-size: 1.3rem;
                margin-bottom: 12px;
                border-radius: 12px;
            }
            .trust-feature-card h4 {
                font-size: 1.05rem;
                margin-bottom: 6px;
            }
            .trust-feature-card p {
                font-size: 0.835rem;
                line-height: 1.55;
                margin-bottom: 12px;
            }
            .trust-feature-tag {
                font-size: 0.72rem;
                padding: 3px 9px;
            }
            .workspace-banner-box {
                margin-top: 20px;
                border-radius: 14px;
            }
            .workspace-banner-overlay {
                padding: 14px 14px;
            }
            .workspace-banner-pill {
                font-size: 0.68rem;
                padding: 3px 8px;
                margin-bottom: 5px;
            }
            .workspace-banner-overlay h4 {
                font-size: 0.96rem;
                line-height: 1.3;
                margin-bottom: 3px;
            }

            /* Stats */
            .stats-modern-section {
                padding: 35px 0;
            }
            .stat-modern-card {
                padding: 18px 15px;
                border-radius: 14px;
            }
            .stat-modern-icon {
                width: 40px;
                height: 40px;
                font-size: 1.2rem;
                margin-bottom: 10px;
                border-radius: 10px;
            }
            .stat-modern-card .purecounter {
                font-size: 1.75rem;
            }
            .stat-modern-card .stat-plus {
                font-size: 1.25rem;
            }
            .stat-modern-card h5 {
                font-size: 0.88rem;
                margin-bottom: 3px;
            }
            .stat-modern-card p {
                font-size: 0.76rem;
                line-height: 1.45;
            }

            /* Reviews */
            .reviews-modern-section {
                padding: 40px 0 40px 0;
            }
            .reviews-section-header {
                margin-bottom: 22px;
            }
            .reviews-section-header h2 {
                font-size: 1.325rem;
                margin-top: 6px;
                margin-bottom: 6px;
            }
            .reviews-section-header p {
                font-size: 0.825rem;
                line-height: 1.5;
            }
            .about-review-card {
                padding: 18px 15px;
                border-radius: 14px;
            }
            .about-review-text {
                font-size: 0.835rem;
                line-height: 1.55;
                margin-bottom: 14px;
            }
            .review-quote-mark {
                font-size: 1.5rem;
            }
            .review-stars {
                font-size: 0.78rem;
                gap: 3px;
            }
            .review-author-wrap {
                padding-top: 12px;
                gap: 10px;
            }
            .review-author-avatar {
                width: 40px;
                height: 40px;
            }
            .review-author-info h6 {
                font-size: 0.865rem;
                margin-bottom: 2px;
            }
            .review-author-role {
                font-size: 0.72rem;
            }
        }

        @media (max-width: 380px) {
            /* Extra small screens (iPhone SE, small Androids) */
            .about-main-title {
                font-size: 1.3rem;
            }
            .features-intro-header h3 {
                font-size: 1.15rem;
            }
            .reviews-section-header h2 {
                font-size: 1.2rem;
            }
            .stat-modern-card .purecounter {
                font-size: 1.55rem;
            }
            .stat-modern-card .stat-plus {
                font-size: 1.15rem;
            }
            .chair-glow-backdrop {
                width: 200px;
                height: 200px;
            }
            .about-chair-img {
                max-height: 210px;
            }
            .floating-badge {
                padding: 4px 8px;
            }
            .floating-badge-icon {
                width: 28px;
                height: 28px;
                font-size: 0.8rem;
            }
            .floating-badge-text strong {
                font-size: 0.7rem;
            }
            .floating-badge-text span {
                font-size: 0.6rem;
            }
        }
    </style>

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container flex flex-col lg:flex-row lg:justify-between lg:items-center gap-2 sm:gap-3">
            <h1 class="mb-0 text-2xl sm:text-3xl">About</h1>
            <nav class="breadcrumbs">
                <ol class="flex flex-wrap items-center gap-2 mb-0">
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">About</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


    <!-- ==============================================
         1. About Story Section (Content Left + Chair Right)
         ============================================== -->
    <section id="about-2" class="about-story-section">
        <div class="container" data-aos="fade-up" data-aos-delay="100">
            <div class="row align-items-center g-5">

                <!-- Left Column: Content -->
                <div class="col-lg-6" data-aos="fade-right" data-aos-delay="150">
                    <span class="about-badge"><i class="bi bi-info-circle-fill"></i> About Us</span>
                    <h2 class="about-main-title">Wide Range of <span>Furniture</span></h2>
                    
                    <p class="about-lead">
                        Welcome to <strong>F-Mart</strong>, your one-stop destination for premium office furniture, school furniture, and high-quality mattresses. With a passion for excellence and innovation, we aim to transform your spaces into comfortable, stylish, and productive environments.
                    </p>

                    <p class="about-body-text">
                        At F-Mart, we believe that furniture is more than just a utility - it's about creating spaces where ideas grow, students learn better, and professionals perform at their best. Whether you're designing a modern office, setting up a school classroom, or upgrading your home comfort with the perfect mattress, we have everything you need under one roof.
                    </p>

                    <!-- Vision & Mission Box -->
                    <div class="about-vision-card">
                        <h6><i class="bi bi-compass-fill"></i> Our Vision & Mission</h6>
                        <p>To be the leading furniture destination, delivering innovative designs and quality craftsmanship that inspire better learning, working, and living spaces.</p>
                    </div>

                    <!-- Highlight Badges -->
                    <div class="about-highlights">
                        <span class="about-pill-item"><i class="bi bi-check-circle-fill"></i> Ergonomic Excellence</span>
                        <span class="about-pill-item"><i class="bi bi-check-circle-fill"></i> Institutional Bulk Orders</span>
                        <span class="about-pill-item"><i class="bi bi-check-circle-fill"></i> 100% Quality Assured</span>
                    </div>
                </div>

                <!-- Right Column: Chair Showcase Image -->
                <div class="col-lg-6" data-aos="fade-left" data-aos-delay="200">
                    <div class="about-chair-showcase">
                        <!-- Glow Effect Circle -->
                        <div class="chair-glow-backdrop"></div>

                        <!-- Top Floating Badge -->
                        <div class="floating-badge badge-top">
                            <div class="floating-badge-icon icon-teal">
                                <i class="bi bi-patch-check-fill"></i>
                            </div>
                            <div class="floating-badge-text">
                                <strong>100% Premium</strong>
                                <span>Quality Crafted</span>
                            </div>
                        </div>

                        <!-- Main Chair Image -->
                        <img src="assets/img/luxury-chair.png" alt="F-Mart Luxury Designer Chair" class="about-chair-img">

                        <!-- Bottom Floating Badge -->
                        <div class="floating-badge badge-bottom">
                            <div class="floating-badge-icon icon-gold">
                                <i class="bi bi-star-fill"></i>
                            </div>
                            <div class="floating-badge-text">
                                <strong>4.9 / 5 Rating</strong>
                                <span>5,000+ Happy Clients</span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <!-- /About Story Section -->


    <!-- ==============================================
         2. "Quality You Can Trust" Features Row
         ============================================== -->
    <section class="features-section-wrap">
        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <!-- Section Header -->
            <div class="features-intro-header text-center">
                <span class="about-badge"><i class="bi bi-shield-check"></i> Built For Durability</span>
                <h3>Quality, Customization & Comfort</h3>
                <p>Engineered for the demands of schools, corporate offices, and cozy homes.</p>
            </div>

            <!-- 1 Row of 3 Modern Cards -->
            <div class="row g-4">

                <!-- Feature 1: Quality You Can Trust -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="150">
                    <div class="trust-feature-card">
                        <div class="trust-feature-icon">
                            <i class="bi bi-shield-check"></i>
                        </div>
                        <h4>Quality You Can Trust</h4>
                        <p>We use premium materials to ensure durability, comfort, and style.</p>
                        <div class="trust-feature-tag">
                            <i class="bi bi-check-lg"></i> Certified Materials
                        </div>
                    </div>
                </div>

                <!-- Feature 2: Customized Solutions -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="250">
                    <div class="trust-feature-card">
                        <div class="trust-feature-icon">
                            <i class="bi bi-sliders2-vertical"></i>
                        </div>
                        <h4>Customized Solutions</h4>
                        <p>Tailored designs to suit schools, colleges, offices, and institutions.</p>
                        <div class="trust-feature-tag">
                            <i class="bi bi-check-lg"></i> Tailored Design
                        </div>
                    </div>
                </div>

                <!-- Feature 3: Premium Mattress Collection -->
                <div class="col-lg-4 col-md-12" data-aos="fade-up" data-aos-delay="350">
                    <div class="trust-feature-card">
                        <div class="trust-feature-icon">
                            <i class="bi bi-moon-stars-fill"></i>
                        </div>
                        <h4>Premium Mattress Collection</h4>
                        <p>Comfortable, supportive, and long-lasting mattresses for a healthier lifestyle.</p>
                        <div class="trust-feature-tag">
                            <i class="bi bi-check-lg"></i> Orthopedic Sleep
                        </div>
                    </div>
                </div>

            </div>

            <!-- State-of-the-Art Workspace Showcase Banner -->
            <div class="workspace-banner-box" data-aos="zoom-in" data-aos-delay="200">
                <img src="assets/img/about/about-wide-1.jpg" alt="F-Mart State-of-the-art Showroom and Facility" class="img-fluid">
                <div class="workspace-banner-overlay">
                    <span class="workspace-banner-pill"><i class="bi bi-buildings-fill"></i> Modern Workspaces & Facilities</span>
                    <h4>Inspiring Collaborative Learning & High-Productivity Offices</h4>
                    <p class="d-none d-md-block">Delivering turnkey corporate installations and smart classroom setups across India.</p>
                </div>
            </div>

        </div>
    </section>
    <!-- /Features Section -->


    <!-- ==============================================
         3. Happy Clients / Stats Section (Modern Dark Gradient)
         ============================================== -->
    <section id="stats" class="stats-modern-section">
        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row g-4">

                <!-- Stat 1: Happy Clients -->
                <div class="col-xl-3 col-md-6" data-aos="fade-up" data-aos-delay="150">
                    <div class="stat-modern-card">
                        <div class="stat-modern-icon stat-icon-1">
                            <i class="bi bi-emoji-smile-fill"></i>
                        </div>
                        <div class="stat-number-wrap">
                            <span data-purecounter-start="0" data-purecounter-end="5000" data-purecounter-duration="1" class="purecounter">5000</span>
                            <span class="stat-plus">+</span>
                        </div>
                        <h5>Happy Clients</h5>
                        <p>Serving satisfied customers across homes, schools & offices.</p>
                    </div>
                </div>

                <!-- Stat 2: Total Varieties -->
                <div class="col-xl-3 col-md-6" data-aos="fade-up" data-aos-delay="250">
                    <div class="stat-modern-card">
                        <div class="stat-modern-icon stat-icon-2">
                            <i class="bi bi-grid-3x3-gap-fill"></i>
                        </div>
                        <div class="stat-number-wrap">
                            <span data-purecounter-start="0" data-purecounter-end="1200" data-purecounter-duration="1" class="purecounter">1200</span>
                            <span class="stat-plus">+</span>
                        </div>
                        <h5>Total Varieties</h5>
                        <p>Wide range of furniture options for every space & style.</p>
                    </div>
                </div>

                <!-- Stat 3: Total Products -->
                <div class="col-xl-3 col-md-6" data-aos="fade-up" data-aos-delay="350">
                    <div class="stat-modern-card">
                        <div class="stat-modern-icon stat-icon-3">
                            <i class="bi bi-box-seam-fill"></i>
                        </div>
                        <div class="stat-number-wrap">
                            <span data-purecounter-start="0" data-purecounter-end="3500" data-purecounter-duration="1" class="purecounter">3500</span>
                            <span class="stat-plus">+</span>
                        </div>
                        <h5>Total Products</h5>
                        <p>From ergonomic chairs to cozy mattresses - all under one roof.</p>
                    </div>
                </div>

                <!-- Stat 4: Total Brands -->
                <div class="col-xl-3 col-md-6" data-aos="fade-up" data-aos-delay="450">
                    <div class="stat-modern-card">
                        <div class="stat-modern-icon stat-icon-4">
                            <i class="bi bi-award-fill"></i>
                        </div>
                        <div class="stat-number-wrap">
                            <span data-purecounter-start="0" data-purecounter-end="25" data-purecounter-duration="1" class="purecounter">25</span>
                            <span class="stat-plus">+</span>
                        </div>
                        <h5>Total Brands</h5>
                        <p>Trusted brands delivering quality, durability & comfort.</p>
                    </div>
                </div>

            </div>

        </div>
    </section>
    <!-- /Stats Section -->


    <!-- ==============================================
         4. Testimonials / Reviews Section (All 6 Reviews)
         ============================================== -->
    <section id="testimonials" class="reviews-modern-section">
        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <!-- Section Title -->
            <div class="reviews-section-header text-center" data-aos="fade-up">
                <span class="about-badge"><i class="bi bi-chat-quote-fill"></i> Client Reviews</span>
                <h2>What Our Clients Say</h2>
                <p>Real feedback from principals, corporate leaders, administrators, and consultants who trust F-Mart.</p>
            </div>

            <!-- Review Cards Grid -->
            <div class="row g-4">

                <!-- Review 1: Mrs. Ritu Sharma -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="150">
                    <div class="about-review-card">
                        <div class="review-card-top">
                            <div class="review-stars">
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                            </div>
                            <i class="bi bi-quote review-quote-mark"></i>
                        </div>
                        <p class="about-review-text">
                            "The Furniture Mart has completely transformed our classrooms! The desks and chairs are not only comfortable and ergonomic but also beautifully designed."
                        </p>
                        <div class="review-author-wrap">
                            <img src="assets/img/person/person-f-1.webp" alt="Mrs. Ritu Sharma" class="review-author-avatar">
                            <div class="review-author-info">
                                <h6>Mrs. Ritu Sharma <i class="bi bi-patch-check-fill" title="Verified Client"></i></h6>
                                <span class="review-author-role">Principal</span>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Review 2: Mr. Arvind Mishra -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="200">
                    <div class="about-review-card">
                        <div class="review-card-top">
                            <div class="review-stars">
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                            </div>
                            <i class="bi bi-quote review-quote-mark"></i>
                        </div>
                        <p class="about-review-text">
                            "We ordered customized classroom furniture and laboratory setups from The Furniture Mart, and we are extremely happy with the quality and durability."
                        </p>
                        <div class="review-author-wrap">
                            <img src="assets/img/person/person-m-5.webp" alt="Mr. Arvind Mishra" class="review-author-avatar">
                            <div class="review-author-info">
                                <h6>Mr. Arvind Mishra <i class="bi bi-patch-check-fill" title="Verified Client"></i></h6>
                                <span class="review-author-role">School Administrator</span>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Review 3: Mr. Rajat Khanna -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="250">
                    <div class="about-review-card">
                        <div class="review-card-top">
                            <div class="review-stars">
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                            </div>
                            <i class="bi bi-quote review-quote-mark"></i>
                        </div>
                        <p class="about-review-text">
                            "Our office needed a complete makeover, and The Furniture Mart exceeded our expectations! From executive desks to ergonomic chairs and conference tables."
                        </p>
                        <div class="review-author-wrap">
                            <img src="assets/img/person/person-m-7.webp" alt="Mr. Rajat Khanna" class="review-author-avatar">
                            <div class="review-author-info">
                                <h6>Mr. Rajat Khanna <i class="bi bi-patch-check-fill" title="Verified Client"></i></h6>
                                <span class="review-author-role">CEO</span>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Review 4: Ms. Priya Verma -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="300">
                    <div class="about-review-card">
                        <div class="review-card-top">
                            <div class="review-stars">
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                            </div>
                            <i class="bi bi-quote review-quote-mark"></i>
                        </div>
                        <p class="about-review-text">
                            "We were looking for high-quality, space-saving furniture for our new office, and The Furniture Mart delivered exactly what we needed."
                        </p>
                        <div class="review-author-wrap">
                            <img src="assets/img/person/person-f-7.webp" alt="Ms. Priya Verma" class="review-author-avatar">
                            <div class="review-author-info">
                                <h6>Ms. Priya Verma <i class="bi bi-patch-check-fill" title="Verified Client"></i></h6>
                                <span class="review-author-role">HR Manager</span>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Review 5: Mr. Sandeep Gupta -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="350">
                    <div class="about-review-card">
                        <div class="review-card-top">
                            <div class="review-stars">
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                            </div>
                            <i class="bi bi-quote review-quote-mark"></i>
                        </div>
                        <p class="about-review-text">
                            "We approached The Furniture Mart for both our school and corporate office furniture requirements, and they handled everything flawlessly."
                        </p>
                        <div class="review-author-wrap">
                            <img src="assets/img/person/person-m-8.webp" alt="Mr. Sandeep Gupta" class="review-author-avatar">
                            <div class="review-author-info">
                                <h6>Mr. Sandeep Gupta <i class="bi bi-patch-check-fill" title="Verified Client"></i></h6>
                                <span class="review-author-role">Business Owner</span>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Review 6: Mrs. Neha Kapoor -->
                <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="400">
                    <div class="about-review-card">
                        <div class="review-card-top">
                            <div class="review-stars">
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                                <i class="bi bi-star-fill"></i>
                            </div>
                            <i class="bi bi-quote review-quote-mark"></i>
                        </div>
                        <p class="about-review-text">
                            "This is our third bulk order with The Furniture Mart, and every time they have impressed us with their quality, designs, and customer support."
                        </p>
                        <div class="review-author-wrap">
                            <img src="assets/img/person/person-f-8.webp" alt="Mrs. Neha Kapoor" class="review-author-avatar">
                            <div class="review-author-info">
                                <h6>Mrs. Neha Kapoor <i class="bi bi-patch-check-fill" title="Verified Client"></i></h6>
                                <span class="review-author-role">Interior Consultant</span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </section>
    <!-- /Reviews Section -->

</asp:Content>
