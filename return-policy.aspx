<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="return-policy.aspx.cs" Inherits="return_policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <div class="page-title light-background">
        <div class="container d-lg-flex justify-content-between align-items-center">
            <h1 class="mb-2 mb-lg-0">Return Policy</h1>
            <nav class="breadcrumbs">
                <ol>
                    <li><a href="index.aspx">Home</a></li>
                    <li class="current">Return Policy</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- End Page Title -->


     <section id="about-2" class="about-2 section">

     <div class="container" data-aos="fade-up" data-aos-delay="100">
         <div class="row">
             <div class="col-lg-12">
                 <asp:Label ID="txtreturnpolicy" runat="server" class="about-description"></asp:Label>
             </div>

         </div>
     </div>

 </section>

    </asp:Content>