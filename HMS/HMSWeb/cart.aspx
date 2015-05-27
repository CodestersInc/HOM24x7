<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
    <form id="form1" runat="server">
        <div>
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
                                <li><a href="services.aspx">Services</a></li>
                                <li class="active"><a href="cart.aspx">Cart</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End mainmenu area -->

            <!-- Start Page title area -->
            <div class="product-big-title-area">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="product-bit-title text-center">
                                <h2>Shopping Cart</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Page title area -->

            <!-- Start product area -->
            <div class="single-product-area">
                <div class="zigzag-bottom"></div>
                <div class="container">
                    <div class="row">
                        <div class="col-md-8">
                            <div class="product-content-right">
                                <div class="woocommerce">

                                    <asp:PlaceHolder ID="cartPlaceHolder" runat="server">
                                        <table class="shop_table cart">
                                            <thead>
                                                <tr>
                                                    <th class="product-remove">&nbsp;</th>
                                                    <th class="product-thumbnail">&nbsp;</th>
                                                    <th class="product-name">Product</th>
                                                    <th class="product-price">Price (&#8377)</th>
                                                    <th class="product-quantity">Quantity</th>
                                                    <th class="product-subtotal">Total (&#8377)</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="CartItemRepeater" runat="server" OnItemCommand="CartItemRepeater_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr class="cart_item">
                                                            <td class="product-remove">  
                                                                <asp:HiddenField ID="HIddenFieldServiceID" runat="server" Value='<%# Eval("ServiceID") %>' />                                                              
                                                                <asp:LinkButton ID="btnRemove" CssClass="remove" CommandName="Remove" CommandArgument='<%# Eval("ServiceID") %>' runat="server">X</asp:LinkButton>
                                                            </td>
                                                            <td class="product-thumbnail">
                                                                <img width="145" height="145" alt="poster_1_up" class="shop_thumbnail" src='<%# Eval("Image") %>' />
                                                            </td>
                                                            <td class="product-name">
                                                                <a href='placeorder.aspx?ID=<%# Eval("ProductName") %>'><%# Eval("ProductName") %></a>
                                                            </td>
                                                            <td class="product-price">
                                                                <asp:Label ID="lblProductPrice" CssClass="amount" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                                                            </td>
                                                            <td class="product-quantity">
                                                                <div class="quantity buttons_added">
                                                                    <asp:TextBox ID="txtQuantity" TextMode="Number" CssClass="input-text qty text" Text='<%# Eval("Unit")%>' runat="server"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="product-subtotal">
                                                                <asp:Label ID="lblProductSubtotal" CssClass="amount" Text='<%# Eval("Total") %>' runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                                <tr>
                                                    <td class="actions" colspan="6">                                                        
                                                        <asp:Button ID="btnOrder" runat="server" Text="Order Now" CssClass="checkout-button button alt wc-forward" OnClick="btnOrder_Click" />
                                                        <asp:Button ID="btnConfirmOrder" runat="server" Text="Confirm Order" CssClass="checkout-button button alt wc-forward" Visible="false" OnClick="btnConfirmOrder_Click" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder ID="cartTotalPlaceHolder" Visible="false" runat="server">
                                        <div class="cart-collaterals">
                                            <div class="cart_totals ">
                                                <h2>Cart Totals</h2>

                                                <table>
                                                    <tbody>
                                                        <tr class="cart-subtotal">
                                                            <th>Cart Total (&#8377)</th>
                                                            <td>
                                                                <asp:Label ID="lblTotal" CssClass="amount" runat="server" Text="0 "></asp:Label>
                                                                <span class="amount"></span></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Start product area -->

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
        </div>
    </form>
</body>
</html>
