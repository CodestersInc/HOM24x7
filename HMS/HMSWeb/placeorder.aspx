<%@ Page Language="C#" AutoEventWireup="true" CodeFile="placeorder.aspx.cs" Inherits="placeorder" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>eElectronics - HTML eCommerce Template</title>

    <!-- Google Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Titillium+Web:400,200,300,700,600' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Roboto+Condensed:400,700,300' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,100' rel='stylesheet' type='text/css'>

    <!-- Bootstrap -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css">

    <!-- Font Awesome -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">

    <!-- Custom CSS -->
    <link rel="stylesheet" href="Servicecss/owl.carousel.css">
    <link rel="stylesheet" href="Servicecss/style.css">
    <link rel="stylesheet" href="Servicecss/responsive.css">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form runat="server">
        <div class="header-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="user-menu">
                            <ul>
                                <li><a href="#"><i class="fa fa-user"></i>My Account</a></li>
                                <li><a href="#"><i class="fa fa-heart"></i>Wishlist</a></li>
                                <li><a href="cart.aspx"><i class="fa fa-user"></i>My Cart</a></li>
                                <li><a href="checkout.html"><i class="fa fa-user"></i>Checkout</a></li>
                                <li><a href="#"><i class="fa fa-user"></i>Login</a></li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="header-right">
                            <ul class="list-unstyled list-inline">
                                <li class="dropdown dropdown-small">
                                    <a data-toggle="dropdown" data-hover="dropdown" class="dropdown-toggle" href="#"><span class="key">currency :</span><span class="value">USD </span><b class="caret"></b></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">USD</a></li>
                                        <li><a href="#">INR</a></li>
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

        <div class="site-branding-area">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="logo">
                            <h1><a href="index.html">e<span>Electronics</span></a></h1>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="shopping-item">
                            <a href="cart.aspx">Cart - <asp:Label ID="lblCartTotal" CssClass="cart-amunt" runat="server" Text="Label"></asp:Label> <i class="fa fa-shopping-cart"></i>
                                <asp:Label ID="lblProductCount" CssClass="product-count" runat="server" Text="Label"></asp:Label>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End site branding area -->

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
                            <li><a href="services.aspx">Services</a></li>
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
                                                <asp:Label ID="lblPrice" runat="server" Text="lblPrice"></asp:Label>
                                            </ins>
                                        </div>
                                        <div class="quantity">
                                            <asp:TextBox ID="txtQuantity" Columns="4" CssClass="input-text qty text" Text="1" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        Customer Remarks:
                                        <br />
                                        <asp:TextBox ID="txtCustomerRemarks" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:Button ID="btnAddToCart" CssClass="add_to_cart_button" OnClick="btnAddToCart_Click" runat="server" Text="Add to cart" />
                                        <asp:Button ID="btnOrderNow" CssClass="add_to_cart_button" OnClick="btnOrderNow_Click" runat="server" Text="Order now" />
                                        <div class="product-inner-category">
                                            <br />
                                            <br />
                                            <p>
                                                ServiceType: <a href="">
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
        <div class="footer-bottom-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="copyright">
                            <p>&copy; 2015 eElectronics. All Rights Reserved. Coded with <i class="fa fa-heart"></i>by <a href="http://wpexpand.com" target="_blank">WP Expand</a></p>
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
