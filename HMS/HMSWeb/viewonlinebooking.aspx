<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewonlinebooking.aspx.cs" Inherits="viewonlinebooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">View Online Booking</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Booking</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Online Booking</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <asp:PlaceHolder ID="searchResultArea" runat="server">
            <!-- BEGIN ADVANCED TABLE widget-->
            <div class="row-fluid">
                <div class="span12">
                    <!-- BEGIN EXAMPLE TABLE widget-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Online Booking Requests</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <asp:PlaceHolder ID="noOnlineBookingPH" runat="server" Visible="false">
                                <div class="control-group">
                                    <div class="controls">
                                        <div class="alert">
                                            <label>No pending online booking requests.</label>
                                        </div>
                                    </div>
                                </div>
                            </asp:PlaceHolder>

                            <asp:PlaceHolder ID="resultPH" runat="server">
                                <table id="tableTT" class="table table-striped table-bordered table-advance table-hover">
                                    <thead>
                                        <tr>
                                            <th style="text-align: center">Customer Name</th>
                                            <th style="text-align: center">Email</th>
                                            <th style="text-align: center">Phone</th>
                                            <th style="text-align: center">Room Type</th>
                                            <th style="text-align: center">Check-in Date</th>
                                            <th style="text-align: center">Planned Check-out Date</th>
                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <%# Eval("Name") %>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%# Eval("Email") %>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%# Eval("Phone") %>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%#Eval("RoomTypeName")%></a>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%# Eval("CheckInDate", "{0:dd-MM-yyyy}") %>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%# Eval("PlannedCheckOutDate", "{0:dd-MM-yyyy}") %>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <asp:LinkButton ID="btnConvert" CssClass="btn btn-success" CommandName="Convert" CommandArgument='<%#  Eval("OnlineBookingID") %>' runat="server"><i class="icon-angle-right"></i> Convert</asp:LinkButton>
                                                        <asp:LinkButton ID="btnRemove" CssClass="btn mini purple" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("OnlineBookingID") %>'><i class="icon-trash"></i> Remove</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th style="text-align: center">Customer Name</th>
                                            <th style="text-align: center">Email</th>
                                            <th style="text-align: center">Phone</th>
                                            <th style="text-align: center">Room Type</th>
                                            <th style="text-align: center">Check-in Date</th>
                                            <th style="text-align: center">Planned Check-out Date</th>
                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE widget-->
                </div>
            </div>
        </asp:PlaceHolder>
        <!-- END ADVANCED TABLE widget-->
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
