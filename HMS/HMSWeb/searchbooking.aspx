<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchbooking.aspx.cs" Inherits="searchbooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search a Booking</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Booking</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="searchbooking.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4><i class="icon-reorder"></i>Bookings Record</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <table id="tableTT" class="table table-striped table-bordered table-advance table-hover">
                                <thead>
                                    <tr>
                                        <th style="text-align: center">Room Number</th>
                                        <th style="text-align: center">Customer Name</th>
                                        <th style="text-align: center">Email</th>
                                        <th style="text-align: center">Phone</th>
                                        <th style="text-align: center">Check-in Date</th>
                                        <th style="text-align: center">Check-out Date</th>
                                        <th style="text-align: center">Status</th>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <a href='viewroom.aspx?ID=<%# Eval("RoomID")%>'><%#Eval("RoomNumber")%></a>
                                                </td>
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
                                                    <%# Eval("CheckInDate", "{0:dd-MM-yyyy}") %>
                                                </td>
                                                <td style="text-align: center">
                                                    <%# Eval("CheckOutDate", "{0:dd-MM-yyyy}") %>
                                                </td>
                                                <td style="text-align: center">
                                                    <%# Eval("Status") %>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewbooking.aspx?ID=" + Eval("BookingID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                                    <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("BookingID") %>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">Room Number</th>
                                        <th style="text-align: center">Customer Name</th>
                                        <th style="text-align: center">Email</th>
                                        <th style="text-align: center">Phone</th>
                                        <th style="text-align: center">Check-in Date</th>
                                        <th style="text-align: center">Check-out Date</th>
                                        <th style="text-align: center">Status</th>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </tfoot>
                            </table>
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

