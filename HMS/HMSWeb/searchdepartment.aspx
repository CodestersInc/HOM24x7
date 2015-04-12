﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchdepartment.aspx.cs" Inherits="searchdepartment" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search Department</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Department</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="searchdepartment.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4><i class="icon-reorder"></i>Department Record</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <table id="tableTT" class="table table-striped table-bordered table-advance table-hover">
                                <thead>
                                    <tr>
                                        <th style="text-align:center">Department</th>
                                        <th style="text-align:center">Manager</th>
                                        <th style="text-align:center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align:center">
                                                    <a href='viewdepartment.aspx?ID=<%# Eval("DepartmentID") %>'><%# Eval("Department") %></a>
                                                </td>
                                                <td style="text-align:center">
                                                    <a href="viewstaff.aspx?ID= <%# Eval("StaffID") %>"><%# Eval("Manager") %></a>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:LinkButton ID="btnEdit1" CssClass="btn mini purple" PostBackUrl='<%# "viewdepartment.aspx?ID=" + Eval("DepartmentID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                                    <asp:LinkButton ID="btnRemove1" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("DepartmentID") %>' CssClass="btn"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align:center">Department</th>
                                        <th style="text-align:center">Manager</th>
                                        <th style="text-align:center">Action</th>
                                    </tr>
                                </tfoot>
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

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
