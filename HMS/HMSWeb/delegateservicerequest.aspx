<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="delegateservicerequest.aspx.cs" Inherits="delegaterequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Delegate Request</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Service Request</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="delegateservicerequest.aspx">Delegate Request</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>

        <asp:PlaceHolder ID="searchResultArea" Visible="true" runat="server">
            <!-- BEGIN ADVANCED TABLE widget-->
            <div class="row-fluid">
                <div class="span12">
                    <!-- BEGIN EXAMPLE TABLE widget-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Pending Service Requests</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>

                        <asp:PlaceHolder ID="RequestListPlaceHolder" runat="server">
                            <div class="widget-body">
                                <table id="tableTT" class="table table-striped table-bordered table-advance table-hover">
                                    <thead>
                                        <tr>
                                            <th style="text-align: center">Service</th>
                                            <th style="text-align: center">Room number</th>
                                            <th style="text-align: center">Requested Date/Time</th>
                                            <th style="text-align: center">Customer remarks</th>
                                            <th style="text-align: center">Unit</th>
                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RequestListRepeater" runat="server" OnItemCommand="RequestListRepeater_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <a href='viewservice.aspx?ID=<%# Eval("ServiceID") %>'><%# Eval("ServiceName") %></a>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <a href='viewroom.aspx?ID=<%# Eval("RoomID") %>'><%# Eval("RoomNumber") %></a>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%# Eval("RequestedDate") %></a>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%# Eval("CustomerRemarks") %></a>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%# Eval("Unit") %>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <asp:LinkButton ID="btnDelegate" runat="server" CommandName="Delegate" CommandArgument='<%#Eval("ServiceRequestID")%>' CssClass="btn mini purple">Delegate <i class="icon-arrow-right"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("ServiceRequestID") %>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th style="text-align: center">Service</th>
                                            <th style="text-align: center">Room number</th>
                                            <th style="text-align: center">Requested Date/Time</th>
                                            <th style="text-align: center">Customer remarks</th>
                                            <th style="text-align: center">Unit</th>
                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </asp:PlaceHolder>
                        
                        <asp:PlaceHolder ID="noRequestsPlaceHolder" runat="server" Visible="false">
                            <div class="control-group">
                                <div class="controls">
                                    <div class="alert">
                                        <label>No pending service requests.</label>
                                    </div>
                                </div>
                            </div>
                        </asp:PlaceHolder>
                    </div>
                    <!-- END EXAMPLE TABLE widget-->
                </div>
            </div>
            <!-- END ADVANCED TABLE widget-->
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="StaffListPlaceHolder" Visible="false" runat="server">
            <table class="table table-striped table-bordered table-advance table-hover">
                <tr>
                    <th>Staff code</th>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Department</th>
                    <th></th>
                </tr>
                <asp:Repeater ID="StaffListRepeater" runat="server" OnItemCommand="StaffListRepeater_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("StaffCode") %>
                            </td>

                            <td>
                                <a href='viewstaff.aspx?ID=<%# Eval("StaffID") %>'><%# Eval("Name") %></a>
                            </td>
                            <td>
                                <%# Eval("Email") %>
                            </td>
                            <td>
                                <a href='viewstaff.aspx?ID=<%# Eval("DepartmentID") %>'><%# Eval("DepartmentName") %>
                            </td>
                            <td style="text-align: center">
                                <asp:LinkButton ID="btnAsign" runat="server" CommandName="Assign" CommandArgument='<%#  Eval("StaffID")%>' CssClass="btn">Assign</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <!--END Repeater-->
            </table>
        </asp:PlaceHolder>
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>

