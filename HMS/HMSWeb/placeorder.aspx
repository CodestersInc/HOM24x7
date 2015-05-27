<%@ Page Language="C#" AutoEventWireup="true" CodeFile="placeorder.aspx.cs" Inherits="placeorder" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>HOM24x7 Service Portal</title>

    <!-- Google Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Titillium+Web:400,200,300,700,600' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Roboto+Condensed:400,700,300' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,100' rel='stylesheet' type='text/css' />

    <!-- Bootstrap -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />

    <!-- Font Awesome -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />

    <!-- Custom CSS -->
    <link rel="stylesheet" href="Servicecss/owl.carousel.css" />
    <link rel="stylesheet" href="Servicecss/style.css" />
    <link rel="stylesheet" href="Servicecss/responsive.css" />
</head>

<body>
    <form runat="server">
        <!-- Begin header area -->
        <div class="header-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="user-menu">
                            <ul>
                                <li><a href="#"><i class="fa fa-user"></i>My Account</a></li>
                                <li><a href="login.aspx"><i class="fa fa-user"></i>Logout</a></li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="header-right">
                            <ul class="list-unstyled list-inline">
                                <li class="dropdown dropdown-small">
                                    <a data-toggle="dropdown" data-hover="dropdown" class="dropdown-toggle" href="#"><span class="key">currency :</span><span class="value">INR </span><b class="caret"></b></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">INR</a></li>
                                        <li><a href="#">USD</a></li>
                                        <li><a href="#">GBP</a></li>
                                    </ul>
                                </li>

                                <li class="dropdown dropdown-small">
                                    <a data-toggle="dropdown" data-hover="dropdown" class="dropdown-toggle" href="#"><span class="key">language :</span><span class="value">English </span><b class="caret"></b></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">English</a></li>
                                        <li><a href="#">French</a></li>
                                        <li><a href="#">German</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End header area -->

        <!-- Start site branding area -->
        <div class="site-branding-area">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="logo">
                            <h1><a href="servicehome.aspx">HOM24x7<span> Services  </span></a></h1>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="shopping-item">
                            <a href="cart.aspx">View Cart
                                    <i class="fa fa-shopping-cart"></i>
                                <asp:Label ID="lblProductCount" CssClass="product-count" runat="server" Text="Label"></asp:Label>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End site branding area -->

        <!-- Start mainmenu area -->
        <div class="mainmenu-area">
            <div class="container">
                <div class="row">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li><a href="servicehome.aspx">Home</a></li>
                            <li class="active"><a href="services.aspx">Services</a></li>
                            <li><a href="cart.aspx">Cart</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- End mainmenu area -->


        <div class="product-big-title-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="product-bit-title text-center">
                            <h2>
                                <asp:Label ID="lblServiceName" runat="server" Text="Service Name"></asp:Label>
                            </h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="single-product-area">
            <div class="zigzag-bottom"></div>
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="product-content-right">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="product-images">
                                        <div class="product-main-img">
                                            <asp:Image ID="imgService" ImageUrl="Serviceimg/product-2.jpg" runat="server" AlternateText="" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="product-inner">
                                        <h2 class="product-name">
                                            <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label></h2>
                                        <div class="product-inner-price">
                                            <ins>
                                                <asp:Label ID="lblPrice" runat="server" Text="lblPrice"></asp:Label>  &#8377
                                            </ins>
                                        </div>
                                        <div class="quantity">
                                            <asp:TextBox ID="txtQuantity" Columns="4" CssClass="input-text qty text" Text="1" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        Customer Remarks:
                                        <br />
                                        <asp:TextBox ID="txtCustomerRemarks" TextMode="MultiLine" Text="No comment" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:Button ID="btnAddToCart" CssClass="add_to_cart_button" OnClick="btnAddToCart_Click" runat="server" Text="Add to cart" />
                                        <asp:Button ID="btnOrderNow" CssClass="add_to_cart_button" OnClick="btnOrderNow_Click" runat="server" Text="Order now" />
                                        <div class="product-inner-category">
                                            <br />
                                            <br />
                                            <p>
                                                ServiceType: 
                                                <a href="#">
                                                    <asp:Label ID="lblServiceType" runat="server" Text="Label"></asp:Label>
                                                </a>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Start footer area -->
        <div class="footer-bottom-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="copyright">
                            <p>&copy; 2015 Host of the most. All Rights Reserved.</p>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="footer-card-icon">
                            <i class="fa fa-cc-discover"></i>
                            <i class="fa fa-cc-mastercard"></i>
                            <i class="fa fa-cc-paypal"></i>
                            <i class="fa fa-cc-visa"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End footer area -->

        <!-- Latest jQuery form server -->
        <script src="https://code.jquery.com/jquery.min.js"></script>

        <!-- Bootstrap JS form CDN -->
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

        <!-- jQuery sticky menu -->
        <script src="Servicejs/owl.carousel.min.js"></script>
        <script src="Servicejs/jquery.sticky.js"></script>

        <!-- jQuery easing -->
        <script src="Servicejs/jquery.easing.1.3.min.js"></script>

        <!-- Main Script -->
        <script src="Servicejs/main.js"></script>
    </form>
</body>
</html>
