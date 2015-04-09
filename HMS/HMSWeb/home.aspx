<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN THEME CUSTOMIZER-->
    <div id="theme-change" class="hidden-phone">
        <i class="icon-cogs"></i>
        <span class="settings">
            <span class="text">Theme:</span>
            <span class="colors">
                <span class="color-default" data-style="default"></span>
                <span class="color-gray" data-style="gray"></span>
                <span class="color-purple" data-style="purple"></span>
                <span class="color-navy-blue" data-style="navy-blue"></span>
            </span>
        </span>
    </div>
    <!-- END THEME CUSTOMIZER-->

    <div style="text-align: center; padding-top:20px">
        <h2><b>Home Page</b></h2>
    </div>

    <!-- BEGIN OVERVIEW STATISTIC BARS-->
    <asp:PlaceHolder ID="statisticsPlaceHolder" runat="server" Visible="false">
        <div class="row-fluid circle-state-overview" style="padding:150px 0px 0px 280px">
            <div class="span2 responsive clearfix" data-tablet="span3" data-desktop="span2">
                <div class="circle-wrap">
                    <div class="stats-circle turquoise-color">
                        <i class="icon-user"></i>
                    </div>
                    <p>
                        <strong>
                            <asp:Label ID="lblStaffMembers" runat="server"></asp:Label>
                        </strong>
                        Staff Members
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
        </div>
    </asp:PlaceHolder>
    <!-- END OVERVIEW STATISTIC BARS-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
