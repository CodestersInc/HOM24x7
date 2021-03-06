﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchhotelac.aspx.cs" Inherits="hacsearch" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search Account</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Accounts</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="searchhotelac.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4><i class="icon-reorder"></i>Account Record</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <table id="tableTT" class="table table-striped table-bordered table-advance table-hover">
                                <thead>
                                    <tr>
                                        <th>Company</th>
                                        <th>Contact Person</th>
                                        <th>Email</th>
                                        <th>Phone</th>
                                        <th>Website</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a href='viewhotelac.aspx?ID=<%# Eval("AccountID") %>'><%# Eval("Company") %></a>
                                                </td>
                                                <td>
                                                    <%# Eval("ContactPerson") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Email") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Phone") %>
                                                </td>
                                                <td>
                                                    <a href='http://<%# Eval("Website") %>'><%# Eval("Website") %></a>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewhotelac.aspx?ID=" + Eval("AccountID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                                    <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("AccountID") %>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
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
