<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="receptionisthome.aspx.cs" Inherits="receptionisthome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
    <style>
        /* HOVER STYLES */
        div#pop-up {
            display: none;
            position: absolute;
            width: 200px;
            padding: 5px;
            background: #009688;
            color: #ffffff;
            font-size: 90%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <div style="text-align: center; padding-top: 20px">
        <h2><b>Home Page</b></h2>
    </div>

    <!-- BEGIN OVERVIEW STATISTIC BARS-->
    <asp:PlaceHolder ID="statisticsPlaceHolder" runat="server">
        <div id="page" class="dashboard">
            <!--BEGIN NOTIFICATION-->
            <div class="alert alert-info" style="text-align: center">
                <button data-dismiss="alert" class="close">×</button>
                Welcome to <strong>
                    <asp:Label ID="lblHotelName" runat="server"></asp:Label></strong>.!
            </div>
            <!--END NOTIFICATION-->
            <br />
            <br />

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

    <asp:PlaceHolder ID="floorNumberPlaceHolder" runat="server">
        <div class="widget-body form">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Select a Floor</label>
                    <div class="controls">
                        <asp:DropDownList ID="ddlFloor" runat="server" CssClass="span3" data-placeholder="Choose a floor" TabIndex="1" />
                        <span></span>
                        <asp:Button ID="viewPlan" CssClass="btn btn-info" runat="server" Text="View Plan" OnClick="viewPlan_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="noFloorPlansPH" runat="server" Visible="false">
        <div class="control-group">
            <div class="controls">
                <div class="alert">
                    <label>No floor plans available...!</label>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>

    <!-- BEGIN PLAN-->
    <asp:PlaceHolder ID="planPlaceHolder" runat="server" Visible="false">
        <div class="container-fluid">
            <asp:PlaceHolder ID="planBuilderPlaceHolder" runat="server">
                <!--START CANVAS-->
                <asp:Repeater ID="planCanvasRepeater" runat="server">
                    <ItemTemplate>
                        <div id="canvas" style='<%# Eval("PlanStyle") %>'>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="roomComponentRepeater" runat="server">
                    <ItemTemplate>
                        <div class="room trigger" roomid='<%# Eval("RoomID") %>' roomnumber="'<%# Eval("RoomNumber") %>'" roomtype="'<%# Eval("RoomType") %>'" roomstatus="'<%# Eval("RoomStatus") %>'" style='<%# Eval("PlanComponentStyle") %>'>
                            <%--<a href='createbooking.aspx?RID=<%# Eval("RoomID") %>' style="color:white;">'<%# Eval("RoomNumber") %>'</a>--%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="otherComponentRepeater" runat="server">
                    <ItemTemplate>
                        <div class="otherComponent" componentid='<%# Eval("ComponentID") %>' style='<%# Eval("PlanComponentStyle") %>'></div>
                    </ItemTemplate>
                </asp:Repeater>
                <!--END CANVAS-->
            </asp:PlaceHolder>
        </div>
    </asp:PlaceHolder>
    <!-- END PLAN-->

    <!--START HIDDEN / POP-UP DIV -->
    <div id="pop-up">
        <h5><b>Room Information</b></h5>
        <p>
            <label id="ppRoomNo" style="font-size: 12px"></label>
            <label id="ppRoomType" style="font-size: 12px"></label>
            <label id="ppRoomStatus" style="font-size: 12px"></label>
        </p>
    </div>
    <!--END HIDDEN / POP-UP DIV -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery.ui.rotatable.min.js"></script>
    <link type="text/css" rel="stylesheet" href="css/jquery.ui.rotatable.css" />

    <%--Manage plan components on document load--%>
    <script type="text/javascript">
        $(document).ready(function () {
            <%--Making canvas resizable--%>
            $('#canvas').resizable();
        });

        $(function () {
            var moveLeft = 20;
            var moveDown = 10;

            $('div.trigger').hover(function (e) {
                $('#ppRoomNo').text("Room Number: " + $(this).attr('roomnumber'));
                $('#ppRoomType').text("Room Type: " + $(this).attr('roomtype'));
                $('#ppRoomStatus').text("Room Status: " + $(this).attr('roomstatus'));
                $('div#pop-up').show();
            }, function () {
                $('div#pop-up').hide();
            });

            $('div.trigger').mousemove(function (e) {
                $("div#pop-up").css('top', e.pageY + moveDown).css('left', e.pageX + moveLeft);
            });
        });

        $('.room').click(function () {
            var url = "http://localhost:49306/createbooking.aspx?RID=" + $(this).attr('roomid');
            $(location).attr('href', url);
        });
    </script>

</asp:Content>

