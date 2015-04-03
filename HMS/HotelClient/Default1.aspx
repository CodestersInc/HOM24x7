<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="Default1" %>

<!DOCTYPE HTML>
<html>
<head>
    <title>Hotel Booking</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css'>
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="js/jquery.min.js"></script>
    <!---strat-date-piker---->
    <link rel="stylesheet" href="css/jquery-ui.css" />
    <script src="js/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker,#datepicker1").datepicker();
        });
    </script>
    <!---/End-date-piker---->
    <link type="text/css" rel="stylesheet" href="css/JFGrid.css" />
    <link type="text/css" rel="stylesheet" href="css/JFFormStyle-1.css" />
    <script type="text/javascript" src="js/JFCore.js"></script>
    <script type="text/javascript" src="js/JFForms.js"></script>
    <!-- Set here the key for your domain in order to hide the watermark on the web server -->
    <script type="text/javascript">
        (function () {
            JC.init({
                domainKey: ''
            });
        })();
    </script>
    <!--nav-->
    <script>
        $(function () {
            var pull = $('#pull');
            menu = $('nav ul');
            menuHeight = menu.height();

            $(pull).on('click', function (e) {
                e.preventDefault();
                menu.slideToggle();
            });

            $(window).resize(function () {
                var w = $(window).width();
                if (w > 320 && menu.is(':hidden')) {
                    menu.removeAttr('style');
                }
            });
        });
    </script>
    <style>

        .online_reservation {
            margin-top:0;
        }
    </style>
</head>
<body>
    <div class="main_bg">
        <div class="wrap">
            <div class="online_reservation">
                <div class="b_room">
                    <div class="booking_room">
                        <h4>book a room online</h4>
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry</p>
                    </div>
                    <div class="reservation">
                        <ul>
                            <li class="span1_of_1">
                                <h5>type of room:</h5>
                                <!----------start section_room----------->
                                <div class="section_room">
                                    <select id="country" onchange="change_country(this.value)" class="frm-field required">
                                        <option value="null">Select a type of room</option>
                                        <option value="null">Suite room</option>
                                        <option value="AX">Single room</option>
                                        <option value="AX">Double room</option>
                                    </select>
                                </div>
                            </li>
                            <li class="span1_of_1 left">
                                <h5>check-in-date:</h5>
                                <div class="book_date">
                                    <form>
                                        <input class="date" id="datepicker" type="text" value="DD/MM/YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD/MM/YY';}">
                                    </form>

                                </div>
                            </li>
                            <li class="span1_of_1 left">
                                <h5>check-out-date:</h5>
                                <div class="book_date">
                                    <form>
                                        <input class="date" id="datepicker1" type="text" value="DD/MM/YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD/MM/YY';}">
                                    </form>
                                </div>
                            </li>
                            <li class="span1_of_2 left">
                                <h5>Adults:</h5>
                                <!----------start section_room----------->
                                <div class="section_room">
                                    <select id="country" onchange="change_country(this.value)" class="frm-field required">
                                        <option value="null">1</option>
                                        <option value="null">2</option>
                                        <option value="AX">3</option>
                                        <option value="AX">4</option>
                                    </select>
                                </div>
                            </li>
                            <li class="span1_of_3">
                                <div class="date_btn">
                                    <form>
                                        <input type="submit" value="book now" />
                                    </form>
                                </div>
                            </li>
                            <div class="clear"></div>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
            
        </div>
    </div>
</body>
</html>
