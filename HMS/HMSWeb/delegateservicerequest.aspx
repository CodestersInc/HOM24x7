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
                                                    <%--<asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# ".aspx?ID=" + Eval("ServiceRequestID") %>' runat="server"><i class="icon-edit"></i> Delegate</asp:LinkButton>--%>
                                                    <asp:LinkButton ID="btnDelegate" runat="server" CommandName="Delegate" CommandArgument='<%#Eval("ServiceRequestID")%>' CssClass="btn mini purple">Delegate <i class="icon-arrow-right"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
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

