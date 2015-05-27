<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onlineBooking.aspx.cs" Inherits="onlinebooking" %>

<!DOCTYPE HTML>
<html>
<head>
    <title>Hotel Booking</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css'>
    <link href="clientcss/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="clientjs/jquery.min.js"></script>

    <!---Start Date Picker---->
    <link rel="stylesheet" href="clientcss/jquery-ui.css" />
    <script src="clientjs/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>
    <!---End Date Picker---->

    <link type="text/css" rel="stylesheet" href="clientcss/JFGrid.css" />
    <link type="text/css" rel="stylesheet" href="clientcss/JFFormStyle-1.css" />
    <script type="text/javascript" src="clientjs/JFCore.js"></script>
    <script type="text/javascript" src="clientjs/JFForms.js"></script>

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
            margin-top: 0;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="b_room">
            <div class="booking_room">
                <h4>book a room online</h4>
                <p>Book a room of your choice by filling in the reservation related information here.</p>
            </div>
            <div class="reservation">
                <ul>
                    <li class="span1_of_1 left">
                        <h5 style="padding-top: 5px;">Name:</h5>
                        <div>
                            <asp:TextBox ID="txtName" Style="height: 27px; width: 26px; font-size:16px" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtName" ValidationGroup="First" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="span1_of_1 left">
                        <h5 style="padding-top: 5px;">Email:</h5>
                        <div class="">
                            <asp:TextBox ID="txtEmail" Style="height: 27px; width: 26px; font-size:16px" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEmail" ValidationGroup="First" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="span1_of_1 left">
                        <h5 style="padding-top: 5px;">Phone:</h5>
                        <div class="">
                            <asp:TextBox ID="txtPhone" Style="height: 27px; width: 26px; font-size:16px" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtPhone" ValidationGroup="First" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="span1_of_1 left">
                        <h5 style="padding-top: 5px;">No. Of Persons:</h5>
                        <div class="">
                            <asp:TextBox ID="txtNumberOfPerson" Style="height: 27px; width: 26px; font-size:16px" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNumberOfPerson" ValidationGroup="First" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="span1_of_1 left">
                        <h5>type of room:</h5>
                        <div class="section_room">
                            <asp:DropDownList ID="ddlRoomType" runat="server"></asp:DropDownList>
                        </div>
                    </li>
                    <li class="span1_of_1 left">
                        <h5>check-in-date:</h5>
                        <div class="book_date">
                            <asp:TextBox ID="txtCheckInDate" CssClass="date datepicker" Text="DD-MM-YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD-MM-YY';}" runat="server"></asp:TextBox>
                        </div>
                    </li>
                    <li class="span1_of_1 left">
                        <h5>check-out-date:</h5>
                        <div class="book_date">
                            <asp:TextBox CssClass="date datepicker" ID="txtCheckOutDate" value="DD-MM-YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD-MM-YY';}" runat="server"></asp:TextBox>
                        </div>
                    </li>
                    <li class="span1_of_1 left">
                        <div class="date_btn" style="padding-left:10px;">                            
                            <asp:Button ID="btnSubmit" Style="height: 36px; font-size: 18px; color:white; background-color:deepskyblue" ValidationGroup="First" runat="server" Text="Book now" OnClick="btnSubmit_Click" />
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>