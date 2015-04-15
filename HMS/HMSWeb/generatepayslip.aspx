<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="generatepayslip.aspx.cs" Inherits="generatepayslip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Generate Payslip</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Payslip</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="generatepayslip.aspx">Generate</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->

        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12">
                    <!-- BEGIN SAMPLE FORM widget-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Select dates for payroll generation</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body form">
                            <!-- BEGIN FORM-->
                            <div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label">From Date</label>
                                        <div class="controls">
                                            <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="span6 non-editable fromDate" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">To Date</label>
                                        <div class="controls">
                                            <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="span6 non-editable toDate" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions">
                                        <asp:Button ID="btnGenerate" CssClass="btn btn-success" runat="server" Text="Generate" OnClientClick="validateDates()" OnClick="btnGenerate_Click" />
                                    </div>
                                </div>
                            </div>
                            <!-- END FORM-->
                        </div>
                    </div>
                    <!-- END SAMPLE FORM widget-->
                </div>
            </div>
            <!-- END PAGE CONTENT-->
        </asp:PlaceHolder>
    </div>
    <!-- END PAGE CONTAINER-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">    
</asp:Content>
