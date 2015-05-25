<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchpayslip.aspx.cs" Inherits="searchpayslip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Search Payslip</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Payslip</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="searchpayslip.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4><i class="icon-reorder"></i>Select a range of dates (during which payslips were generated)</h4>
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
                                            <div class="input-append date date-picker" data-date="01-01-2015" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="span6  non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">To Date</label>
                                        <div class="controls">
                                            <div class="input-append date date-picker" data-date="01-01-2015" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="span6 non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:PlaceHolder ID="ddlDepartmentPlaceHolder" runat="server">
                                        <div class="control-group">
                                            <label class="control-label">Department</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="span3" data-placeholder="Choose a Department" TabIndex="1" />
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                    <asp:Label ID="lblNoPayslips" runat="server" CssClass="alert alert-info" Visible="false"><strong>Note:</strong> No payslips found...!!</asp:Label>

                                    <div class="form-actions">
                                        <asp:Button ID="btnSearch" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>
                            <!-- END FORM-->
                        </div>
                    </div>
                    <!-- END SAMPLE FORM widget-->

                    <!-- BEGIN SAMPLE FORM widget-->
                    <asp:PlaceHolder ID="payslipRecordPlaceHolder" runat="server">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="icon-reorder"></i>Payslip Record</h4>
                                <span class="tools">
                                    <a href="javascript:;" class="icon-chevron-down"></a>
                                    <a href="javascript:;" class="icon-remove"></a>
                                </span>
                            </div>
                            <div class="widget-body form">
                                <!-- BEGIN FORM-->
                                <div>
                                    <div class="form-horizontal">
                                        <table id="tableTT" class="table table-striped table-bordered table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th style="text-align: center">Staff Code</th>
                                                    <th style="text-align: center">Name</th>
                                                    <th style="text-align: center">Department</th>
                                                    <th style="text-align: center">Generate Date</th>
                                                    <th style="text-align: center">Net Pay</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="text-align: center"><%# Eval("StaffCode") %></td>
                                                            <td style="text-align: center"><%# Eval("Name") %></td>
                                                            <td style="text-align: center"><%# Eval("DepartmentName") %></td>
                                                            <td style="text-align: center"><%# Eval("GenerateDate", "{0:dd-MM-yyyy}") %></td>
                                                            <td style="text-align: center">&#8377 <%# Eval("NetPay") %></td>
                                                            <td style="text-align: center">
                                                                <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "editpayslip.aspx?ID=" + Eval("PaySlipID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                                                <asp:LinkButton ID="btnView" CssClass="btn mini purple" PostBackUrl='<%# "viewpayslip.aspx?ID=" + Eval("PaySlipID") %>' runat="server"><i class="icon-eye-open"></i> View</asp:LinkButton>
                                                                <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("PaySlipID") %>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <th style="text-align: center">Staff Code</th>
                                                    <th style="text-align: center">Name</th>
                                                    <th style="text-align: center">Department</th>
                                                    <th style="text-align: center">Generate Date</th>
                                                    <th style="text-align: center">Net Pay</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                                <!-- END FORM-->
                            </div>
                        </div>
                    </asp:PlaceHolder>
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

