<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <!--Converse.js CSS and js start-->
    <%--<link rel="shortcut icon" type="image/ico" href="conversejs/css/images/favicon.ico"/>--%>
    <%--<link type="text/css" rel="stylesheet" media="screen" href="conversejs/components/bootstrap/dist/css/bootstrap.min.css" />--%>
    <%--<link type="text/css" rel="stylesheet" media="screen" href="conversejs/components/fontawesome/css/font-awesome.min.css" />--%>
    <%--<link type="text/css" rel="stylesheet" media="screen" href="conversejs/css/theme.css" />--%>
    <link type="text/css" rel="stylesheet" media="screen" href="conversejs/css/converse.min.css" />
    <%--<script type="text/javascript" src="analytics.js"></script>--%>

    <noscript><p><img src="//stats.opkode.com/piwik.php?idsite=1" style="border:0;" alt="" /></p></noscript>
    <%-- Only for development: <script data-main="main" src="components/requirejs/require.js"></script> --%>
    <![if gte IE 9]>
        <script src="conversejs/builds/converse.website.min.js"></script>
    <![endif]>
    <%--[if lt IE 9]>
        <script src="builds/converse.website-no-otr.min.js"></script>
    <![endif]--%>
    <!--Converse.js CSS and js END-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <div style="text-align: center; padding-top: 20px">
        <h2><b>Home Page</b></h2>
    </div>

    <!-- BEGIN OVERVIEW STATISTIC BARS-->
    <asp:PlaceHolder ID="statisticsPlaceHolder" runat="server" Visible="false">
        <div id="page" class="dashboard">
            <!--BEGIN NOTIFICATION-->
            <div class="alert alert-info" style="text-align: center">
                <button data-dismiss="alert" class="close">×</button>
                Welcome to <strong>
                    <asp:Label ID="lblHotelName" runat="server"></asp:Label></strong>.!
            </div>
            <br />
            <br />
            <!--END NOTIFICATION-->
            <div class="row-fluid circle-state-overview">

                <div class="span2 responsive clearfix" data-tablet="span3" data-desktop="span2">
                    <div class="circle-wrap">
                        <div class="stats-circle gray-color">
                            <i class="icon-bookmark"></i>
                        </div>
                        <p>
                            <strong>
                                <asp:Label ID="lblBookings" runat="server"></asp:Label>
                            </strong>
                            Bookings
                        </p>
                    </div>
                </div>

                <div class="span2 responsive clearfix" data-tablet="span3" data-desktop="span2">
                    <div class="circle-wrap">
                        <div class="stats-circle purple-color">
                            <i class="icon-user"></i>
                        </div>
                        <p>
                            <strong>
                                <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                            </strong>
                            Customers
                        </p>
                    </div>
                </div>

                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-wrap">
                        <div class="stats-circle red-color">
                            <i class="icon-columns"></i>
                        </div>
                        <p>
                            <strong>
                                <asp:Label ID="lblDepartments" runat="server"></asp:Label>
                            </strong>
                            Departments
                        </p>
                    </div>
                </div>

                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-wrap">
                        <div class="stats-circle green-color">
                            <i class="icon-key"></i>
                        </div>
                        <p>
                            <strong>
                                <asp:Label ID="lblRooms" runat="server"></asp:Label>
                            </strong>
                            Rooms
                        </p>
                    </div>
                </div>

                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-wrap">
                        <div class="stats-circle purple-color">
                            <i class="icon-ambulance"></i>
                        </div>
                        <p>
                            <strong>
                                <asp:Label ID="lblServices" runat="server"></asp:Label>
                            </strong>
                            Services
                        </p>
                    </div>
                </div>

                <div class="span2 responsive clearfix" data-tablet="span3" data-desktop="span2">
                    <div class="circle-wrap">
                        <div class="stats-circle turquoise-color">
                            <i class="icon-bolt"></i>
                        </div>
                        <p>
                            <strong>
                                <asp:Label ID="lblStaffMembers" runat="server"></asp:Label>
                            </strong>
                            Staff Members
                        </p>
                    </div>
                </div>

                <div class="span2 responsive clearfix" data-tablet="span3" data-desktop="span2">
                </div>
            </div>
        </div>
    </asp:PlaceHolder>

    <!-- END OVERVIEW STATISTIC BARS-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
        <!-- converse.js script start-->
    <script>
        require(['converse'], function (converse) {
            //(function () {
            //    /* XXX: This function initializes jquery.easing for the https://conversejs.org
            //    * website. This code is only useful in the context of the converse.js
            //    * website and converse.js itself is NOT dependent on it.
            //    */
            //    var $ = converse.env.jQuery;
            //    $(window).scroll(function () {
            //        if ($(".navbar").offset().top > 50) {
            //            $(".navbar-fixed-top").addClass("top-nav-collapse");
            //        } else {
            //            $(".navbar-fixed-top").removeClass("top-nav-collapse");
            //        }
            //    });
            //    //jQuery for page scrolling feature - requires jQuery Easing plugin
            //    $('.page-scroll a').bind('click', function (event) {
            //        var $anchor = $(this);
            //        $('html, body').stop().animate({
            //            scrollTop: $($anchor.attr('href')).offset().top
            //        }, 700, 'easeInOutExpo');
            //        event.preventDefault();
            //    });
            //})();
            converse.initialize({
                // the default BOSH manager for converse js
                bosh_service_url: 'http://codester.cloudapp.net:5280/http-bind',
                i18n: locales['en'], // Refer to ./locale/locales.js to see which locales are supported
                keepalive: true,
                message_carbons: true,
                play_sounds: true,
                roster_groups: true,
                show_controlbox_by_default: true,
                xhr_user_search: false
            });
        });
    </script>
    <!-- converse.js script end-->
</asp:Content>
