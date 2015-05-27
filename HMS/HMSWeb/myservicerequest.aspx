<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="myservicerequest.aspx.cs" Inherits="myservicerequest" %>

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
                            <h4><i class="icon-reorder"></i>My Requests</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>

                        <asp:PlaceHolder ID="RequestListPlaceHolder" runat="server">
                            <div class="widget-body">
                                <table class="table table-striped table-bordered table-advance table-hover">
                                    <tr>
                                        <th>Service</th>
                                        <th>Room number</th>
                                        <th>Requested Date/Time</th>
                                        <th>Customer remarks</th>
                                        <th>Unit</th>
                                        <th></th>
                                    </tr>
                                    <asp:Repeater ID="RequestListRepeater" runat="server" OnItemCommand="RequestListRepeater_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a href='viewservice.aspx?ID=<%# Eval("ServiceID") %>'><%# Eval("ServiceName") %></a>
                                                </td>
                                                <td>
                                                    <a href='viewroom.aspx?ID=<%# Eval("RoomID") %>'><%# Eval("RoomNumber") %></a>
                                                </td>
                                                <td>
                                                    <%# Eval("RequestedDate") %></a>
                                                </td>
                                                <td>
                                                    <%# Eval("CustomerRemarks") %></a>
                                                </td>
                                                <td>
                                                    <%# Eval("Unit") %>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:LinkButton ID="btnDone" runat="server" CommandName="Done" CommandArgument='<%#Eval("ServiceRequestID")%>' CssClass="label label-success">Delivered</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </asp:PlaceHolder>

                        <asp:PlaceHolder ID="noServiceRequestsPH" runat="server" Visible="false">
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
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>

