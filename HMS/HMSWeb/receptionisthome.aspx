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
    <!-- BEGIN PAGE CONTAINER-->
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

    <!--START HIDDEN / POP-UP DIV -->
    <div id="pop-up">
        <h5><b>Room Information</b></h5>
        <p>
            <label id="ppRoomNo" style="font-size:12px"></label>
            <label id="ppRoomType" style="font-size:12px"></label>
            <label id="ppRoomStatus" style="font-size:12px"></label>
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
            var url = "http://localhost:49306/createbooking.aspx?RID="+$(this).attr('roomid');
            $(location).attr('href', url);
        });
    </script>

</asp:Content>

