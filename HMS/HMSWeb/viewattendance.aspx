<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewattendance.aspx.cs" Inherits="viewattendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Attendance</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Attendance</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">View</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4><i class="icon-reorder"></i>Select a range of dates</h4>
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
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="span6  non-editable" Text="dd-mm-yyyy"></asp:TextBox>
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

                                    <asp:PlaceHolder ID="ddlDepartmentPlaceHolder" runat="server" Visible="false">
                                        <div class="control-group">
                                            <label class="control-label">Department</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="span3" data-placeholder="Choose a Department" TabIndex="1" />
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                    <div class="form-actions">
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="View Attendance" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                            <!-- END FORM-->
                        </div>
                    </div>
                    <!-- END SAMPLE FORM widget-->
                    <!-- BEGIN SAMPLE FORM widget-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Attendance Details</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body form">
                            <!-- BEGIN FORM-->
                            <div>
                                <div class="form-horizontal">
                                    <table class="table table-striped table-bordered table-advance table-hover">
                                        <tr>
                                            <th>Date</th>
                                            <th>Staff Code</th>
                                            <th>Name</th>
                                            <th>Department</th>
                                            <th style="text-align:center">Attendance</th>
                                        </tr>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <asp:HiddenField ID="HiddenFieldAttendanceID" Value='<%# Eval("AttendanceID") %>' runat="server" />
                                                    <asp:HiddenField ID="HiddenFieldAttendanceDate" Value='<%# Eval("AttendanceDate") %>' runat="server" />
                                                    <asp:HiddenField ID="HiddenFieldInTime" Value='<%# Eval("InTime") %>' runat="server" />
                                                    <asp:HiddenField ID="HiddenFieldOutTime" Value='<%# Eval("OutTime") %>' runat="server" />
                                                    
                                                    <td><%# Eval("AttendanceDate", "{0:dd-MM-yyyy}") %></td>
                                                    <td><%# Eval("StaffCode") %></td>
                                                    <td><%# Eval("Name") %></td>
                                                    <td><%# Eval("DepartmentName") %></td>
                                                    <td style="text-align:center">
                                                        <asp:CheckBox ID="cbxPresence" Checked='<%# Eval("AttendanceStatus") %>' CssClass="success-toggle-button toggle-button" runat="server" />
                                                        <asp:HiddenField ID="HiddenFieldStaffID" runat="server" Value='<%# Eval("StaffID") %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>

                                    <div class="form-actions">
                                        <asp:LinkButton ID="btnUpdate" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i> Update</asp:LinkButton>
                                        <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
    <script type="text/javascript" src="assets/bootstrap-toggle-buttons/static/js/jquery.toggle.attendance-buttons.js"></script>

    <script>
        var handleToggleButtons = function () {
            if (!jQuery().toggleButtons) {
                return;
            }
            $('.success-toggle-button').toggleButtons({
                style: {
                    enabled: "success",
                    disabled: "danger"
                }
            });
        }
    </script>
</asp:Content>