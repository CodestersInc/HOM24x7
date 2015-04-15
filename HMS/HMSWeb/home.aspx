<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
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
    </asp:PlaceHolder>
    <!-- END OVERVIEW STATISTIC BARS-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
