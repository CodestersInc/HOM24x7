﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createseason.aspx.cs" Inherits="createseason" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create a Season</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Season</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createseason.aspx">Create</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->

        <!-- BEGIN PAGE CONTENT-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN SAMPLE FORM widget-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>New Season Configuration</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <div id="hacRegister">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label">Season Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtSeasonName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the name of season" data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtSeasonName" ID="SeasonNameRequiredFieldValidator" runat="server" ErrorMessage="Please enter the name of the new Season" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                    <div class="control-group">
                                        <label class="control-label">From Date</label>
                                        <div class="controls">
                                            <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="span6 non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">To Date</label>
                                        <div class="controls">
                                            <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="span6 non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                <!-- BEGIN Create Room Type FORM-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>Room type rate for season</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <!-- BEGIN FORM-->
                        <div>
                            <div>
                                <!-- START SEASON MAPPING -->
                                <!--START Repeater-->
                                <table class="table table-striped table-bordered table-advance table-hover">
                                    <tr>
                                        <th>Room type</th>
                                        <th style="text-align:center">Rate</th>
                                        <th style="text-align:center">Agent Discount</th>
                                        <th style="text-align:center">Max Discount</th>
                                        <th style="text-align:center">Website Rate</th>
                                    </tr>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td >
                                                    <asp:HiddenField ID="HiddenFieldSeasonID" Value='<%# Eval("RoomTypeID") %>' runat="server" />
                                                    <b><%# Eval("Name") %></b>
                                                </td>
                                                <td style="text-align:center">
                                                    <asp:TextBox ID="txtRate" CssClass="span12" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="text-align:center">
                                                    <asp:TextBox ID="txtAgentDiscount" CssClass="span12" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="text-align:center">
                                                    <asp:TextBox ID="txtMaxDiscount" CssClass="span12" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="text-align:center">
                                                    <asp:TextBox ID="txtWebsiteRate" CssClass="span12" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <!--END Repeater-->
                                <!-- END SEASON MAPPING -->
                            </div>


                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" ValidationGroup="First" CssClass="btn btn-success" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" OnClick="btnCancel_Click" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
            </div>
        </div>
        <!-- END PAGE CONTENT-->
    </div>
    <!-- END PAGE CONTAINER-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
