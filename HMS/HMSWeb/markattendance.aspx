<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="markattendance.aspx.cs" Inherits="markattendance" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="assets/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Mark Attendance</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Attendance</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="markattendance.aspx">Mark</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Today's Attendance</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <!-- BEGIN FORM-->
                        <div>
                            <div class="form-horizontal">                                
                                <asp:PlaceHolder ID="ddlDepartmentPlaceHolder" runat="server" Visible="false">
                                    <div class="control-group">
                                        <label class="control-label">Department</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True" CssClass="span3" data-placeholder="Choose a Department" TabIndex="1" />
                                        </div>
                                    </div>
                                </asp:PlaceHolder>

                                <asp:Label ID="lblMarked" runat="server" CssClass="alert alert-info" Visible="false"><strong>Note:</strong> Attendance for selected department is already marked for today</asp:Label>

                                <asp:PlaceHolder ID="staffRecordPlaceHolder" runat="server">
                                    <table class="table table-striped table-bordered table-advance table-hover">
                                        <tr>
                                            <th>Staff Code</th>
                                            <th>Name</th>
                                            <th style="text-align: center">Attendance</th>
                                        </tr>

                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("StaffCode") %></td>
                                                    <td><%# Eval("Name") %></td>
                                                    <td style="text-align: center">
                                                        <asp:CheckBox ID="cbxPresence" CssClass="success-toggle-button toggle-button" runat="server" />
                                                        <asp:HiddenField ID="HiddenFieldStaffID" runat="server" Value='<%# Eval("StaffID") %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </asp:PlaceHolder>
                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Attendance" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
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
