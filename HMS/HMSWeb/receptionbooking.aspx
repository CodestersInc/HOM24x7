<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="receptionbooking.aspx.cs" Inherits="receptionbooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <style type="text/css">
        .dvRoom {
            height: 30px;
            width: 100%;
            border: 1px solid #000000;
        }

        .dvBooking {
            height: 25px;
            width: 100%;
            border: 1px solid #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

    <asp:Repeater ID="rptrRooms" runat="server" OnItemDataBound="rptrRooms_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID="hdnRoomID" Value='<%# Eval("RoomID") %>' runat="server" />
            <div class="dvRoom">
                <asp:Repeater ID="rptrBookings" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnRoomID" Value='<%# Eval("BookingID") %>' runat="server" />
                        <div class="dvBooking" runat="server" id="dvBooking">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>

