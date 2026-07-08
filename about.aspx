<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">About</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">About</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->

    <!-- About 2 Section -->
    <section id="about-2" class="about-2 section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <span class="section-badge"><i class="bi bi-info-circle"></i>About Us</span>
            <div class="row">
                <div class="col-lg-6">
                    <h2 class="about-title">Wide Range of Furniture</h2>
                    <p class="about-description">Welcome to F-Mart, your one-stop destination for premium office furniture, school furniture, and high-quality mattresses. With a passion for excellence and innovation, we aim to transform your spaces into comfortable, stylish, and productive environments.</p>
                </div>
                <div class="col-lg-6">
                    <p class="about-text">At F-Mart, we believe that furniture is more than just a utility — it’s about creating spaces where ideas grow, students learn better, and professionals perform at their best. Whether you’re designing a modern office, setting up a school classroom, or upgrading your home comfort with the perfect mattress, we have everything you need under one roof.</p>
                    <p class="about-text">To be the leading furniture destination, delivering innovative designs and quality craftsmanship that inspire better learning, working, and living spaces.</p>
                </div>
            </div>

            <div class="row features-boxes gy-4 mt-3">
                <div class="col-lg-4" data-aos="fade-up" data-aos-delay="200">
                    <div class="feature-box">
                        <div class="icon-box">
                            <i class="bi bi-bullseye"></i>
                        </div>
                        <h3><a href="#" class="stretched-link">Quality You Can Trust</a></h3>
                        <p>We use premium materials to ensure durability, comfort, and style.</p>
                    </div>
                </div>

                <div class="col-lg-4" data-aos="fade-up" data-aos-delay="300">
                    <div class="feature-box">
                        <div class="icon-box">
                            <i class="bi bi-person-check"></i>
                        </div>
                        <h3><a href="#" class="stretched-link">Customized Solutions</a></h3>
                        <p>Tailored designs to suit schools, colleges, offices, and institutions.</p>
                    </div>
                </div>

                <div class="col-lg-4" data-aos="fade-up" data-aos-delay="400">
                    <div class="feature-box">
                        <div class="icon-box">
                            <i class="bi bi-clipboard-data"></i>
                        </div>
                        <h3><a href="#" class="stretched-link">Premium Mattress Collection</a></h3>
                        <p>Comfortable, supportive, and long-lasting mattresses for a healthier lifestyle.</p>
                    </div>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-lg-12" data-aos="zoom-in" data-aos-delay="200">
                    <div class="video-box">
                        <img src="assets/img/about/about-wide-1.jpg" class="img-fluid" alt="Video Thumbnail">
                        <%--<a href="https://www.youtube.com/watch?v=Y7f98aduVJ8" class="glightbox pulsating-play-btn"></a>--%>
                    </div>
                </div>
            </div>

        </div>

    </section>
    <!-- /About 2 Section -->

    <!-- Stats Section -->
    <section id="stats" class="stats section light-background">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

            <div class="row gy-4">

                <div class="col-lg-3 col-md-6">
                    <div class="stats-item">
                        <i class="bi bi-emoji-smile"></i>
                        <span data-purecounter-start="0" data-purecounter-end="5000" data-purecounter-duration="1" class="purecounter"></span>
                        <p><strong>Happy Clients</strong> <span>Serving satisfied customers across homes, schools & offices.</span></p>
                    </div>
                </div>
                <!-- End Stats Item -->

                <div class="col-lg-3 col-md-6">
                    <div class="stats-item">
                        <i class="bi bi-journal-richtext"></i>
                        <span data-purecounter-start="0" data-purecounter-end="1200" data-purecounter-duration="1" class="purecounter"></span>
                        <p><strong>Total Varieties</strong> <span>Wide range of furniture options for every space & style.</span></p>
                    </div>
                </div>
                <!-- End Stats Item -->

                <div class="col-lg-3 col-md-6">
                    <div class="stats-item">
                        <i class="bi bi-headset"></i>
                        <span data-purecounter-start="0" data-purecounter-end="3500" data-purecounter-duration="1" class="purecounter"></span>
                        <p><strong>Total Products</strong> <span>From ergonomic chairs to cozy mattresses — all under one roof.</span></p>
                    </div>
                </div>
                <!-- End Stats Item -->

                <div class="col-lg-3 col-md-6">
                    <div class="stats-item">
                        <i class="bi bi-people"></i>
                        <span data-purecounter-start="0" data-purecounter-end="25" data-purecounter-duration="1" class="purecounter"></span>
                        <p><strong>Total Brands</strong> <span>Trusted brands delivering quality, durability & comfort.</span></p>
                    </div>
                </div>
                <!-- End Stats Item -->

            </div>

        </div>

    </section>
    <!-- /Stats Section -->

    <!-- Testimonials Section -->
    <section id="testimonials" class="testimonials section">

        <div class="container">

            <div class="testimonial-masonry">

                <div class="testimonial-item highlight" data-aos="fade-up">
                    <div class="testimonial-content">
                        <div class="quote-pattern">
                            <i class="bi bi-quote"></i>
                        </div>
                        <p>The Furniture Mart has completely transformed our classrooms! The desks and chairs are not only comfortable and ergonomic but also beautifully designed.</p>
                        <div class="client-info">
                            <div class="client-image">
                                <img src="assets/img/person/woman.png" alt="Client">
                            </div>
                            <div class="client-details">
                                <h3>Mrs. Ritu Sharma</h3>
                                <span class="position">Principal</span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="testimonial-item highlight" data-aos="fade-up" data-aos-delay="100">
                    <div class="testimonial-content">
                        <div class="quote-pattern">
                            <i class="bi bi-quote"></i>
                        </div>
                        <p>We ordered customized classroom furniture and laboratory setups from The Furniture Mart, and we are extremely happy with the quality and durability.</p>
                        <div class="client-info">
                            <div class="client-image">
                                <img src="assets/img/person/man.png" alt="Client">
                            </div>
                            <div class="client-details">
                                <h3>Mr. Arvind Mishra</h3>
                                <span class="position">School Administrator</span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="testimonial-item highlight" data-aos="fade-up" data-aos-delay="200">
                    <div class="testimonial-content">
                        <div class="quote-pattern">
                            <i class="bi bi-quote"></i>
                        </div>
                        <p>Our office needed a complete makeover, and The Furniture Mart exceeded our expectations! From executive desks to ergonomic chairs and conference tables.</p>
                        <div class="client-info">
                            <div class="client-image">
                                <img src="assets/img/person/man.png" alt="Client">
                            </div>
                            <div class="client-details">
                                <h3>Mr. Rajat Khanna</h3>
                                <span class="position">CEO</span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="testimonial-item highlight" data-aos="fade-up" data-aos-delay="300">
                    <div class="testimonial-content">
                        <div class="quote-pattern">
                            <i class="bi bi-quote"></i>
                        </div>
                        <p>We were looking for high-quality, space-saving furniture for our new office, and The Furniture Mart delivered exactly what we needed.</p>
                        <div class="client-info">
                            <div class="client-image">
                                <img src="assets/img/person/woman.png" alt="Client">
                            </div>
                            <div class="client-details">
                                <h3>Ms. Priya Verma</h3>
                                <span class="position">HR Manager</span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="testimonial-item highlight" data-aos="fade-up" data-aos-delay="400">
                    <div class="testimonial-content">
                        <div class="quote-pattern">
                            <i class="bi bi-quote"></i>
                        </div>
                        <p>We approached The Furniture Mart for both our school and corporate office furniture requirements, and they handled everything flawlessly.</p>
                        <div class="client-info">
                            <div class="client-image">
                                <img src="assets/img/person/man.png" alt="Client">
                            </div>
                            <div class="client-details">
                                <h3>Mr. Sandeep Gupta</h3>
                                <span class="position">Business Owner</span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="testimonial-item highlight" data-aos="fade-up" data-aos-delay="500">
                    <div class="testimonial-content">
                        <div class="quote-pattern">
                            <i class="bi bi-quote"></i>
                        </div>
                        <p>This is our third bulk order with The Furniture Mart, and every time they have impressed us with their quality, designs, and customer support.</p>
                        <div class="client-info">
                            <div class="client-image">
                                <img src="assets/img/person/woman.png" alt="Client">
                            </div>
                            <div class="client-details">
                                <h3>Mrs. Neha Kapoor</h3>
                                <span class="position">Interior Consultant</span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </section>
    <!-- /Testimonials Section -->


</asp:Content>
