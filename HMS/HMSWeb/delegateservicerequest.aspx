<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="delegateservicerequest.aspx.cs" Inherits="delegaterequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" Runat="Server">
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
                        <div class="widget-body">


                            <table class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <th>Service</th>
                                    <th>Room number</th>
                                    <th>Requested Date/Time</th>
                                    <th>Customer remarks</th>
                                    <th>AssignedID</th>
                                    <th>Unit</th>
                                    <th></th>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <a href="viewservice.aspx"><%# Eval("Name") %></a>
                                            </td>
                                            <td>
                                                <a href="viewroom.aspx"><%# Eval("RoomNumber") %></a>
                                            </td>
                                            <td>
                                                <%# Eval("RequestedDate") %></a>
                                            </td>
                                            <td>
                                                <%# Eval("CustomerRemarks") %></a>
                                            </td>
                                            <td>
                                                <a href="mailto:<%# Eval("Email") %>"><%# Eval("Email") %></a>
                                            </td>
                                            <td>
                                                <%# Eval("Unit") %>
                                            </td>
                                            <td style="text-align:center">
                                                <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewstaff.aspx?ID=" + Eval("StaffID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                                <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#Eval("StaffID")%>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE widget-->
                </div>
            </div>

            <!-- END ADVANCED TABLE widget-->
        </asp:PlaceHolder>
    </div>
    <!-- END PAGE CONTAINER -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" Runat="Server">
</asp:Content>

