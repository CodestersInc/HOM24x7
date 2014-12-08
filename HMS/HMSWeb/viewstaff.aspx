<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewstaff.aspx.cs" Inherits="viewstaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="assets/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Staff Details</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Staff</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="viewstaff.aspx">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Staff Details</h4>
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
                                    <label class="control-label">Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Email Address</label>
                                    <div class="controls">
                                        <div class="input-icon left">
                                            <i class="icon-envelope"></i>
                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Address"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Phone</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPhone" runat="server" data-mask="(999) 999-9999" CssClass="span5"></asp:TextBox>
                                        <span class="help-inline">(999) 999-9999</span>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Designation</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="span6" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem>Select...</asp:ListItem>
                                            <asp:ListItem Value="MaintainanceStaff">Maintainance Staff</asp:ListItem>
                                            <asp:ListItem Value="DepartmentManager">Department Manager</asp:ListItem>
                                            <asp:ListItem Value="Housekeeping">House keeping</asp:ListItem>
                                            <asp:ListItem Value="AdminStaff">Administration Staff</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Date of Birth</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass=" m-ctrl-medium date-picker" size="16" Text="12-02-2012"></asp:TextBox>
                                            <%--<input class=" m-ctrl-medium date-picker" size="16" type="text" value="12-02-2012" />--%>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Date of Join</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtDOJ" Enabled="false" runat="server" CssClass=" m-ctrl-medium date-picker" size="16" Text="12-02-2012"></asp:TextBox>
                                            <%--<input class=" m-ctrl-medium date-picker" size="16" type="text" value="12-02-2012" />--%>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Salary</label>
                                    <div class="controls">
                                        <div class="input-prepend input-append">
                                            <span class="add-on">Rs.</span>
                                            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Salary Frequency</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlSalaryFrequency" runat="server" CssClass="span6" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem>Select...</asp:ListItem>
                                            <asp:ListItem Value="Monthly">Monthly</asp:ListItem>
                                            <asp:ListItem Value="Weekly">Weekly</asp:ListItem>
                                            <asp:ListItem Value="Hourly">Hourly</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Is Active</label>
                                    <div class="controls">
                                        <asp:RadioButton ID="radioYes" runat="server" GroupName="IsActive" />
                                        <span style="position: relative; top: 4px">Yes</span>

                                        <asp:RadioButton ID="radioNo" runat="server" GroupName="IsActive" />
                                        <span style="position: relative; top: 4px">No</span>

                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Department</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="span6" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem>Select...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:LinkButton ID="btnUpdate" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
                                    <%--<button class="btn btn-inverse"><i class="icon-refresh icon-white"></i> Update</button>--%>
                                    <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="Reset" />
                                    <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" />
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

<asp:Content ID="sdfsfs" ContentPlaceHolderID="PlcScripts" runat="server">
    <script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/date.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/daterangepicker.js"></script>

    <script type="text/javascript" src="assets/bootstrap-toggle-buttons/static/js/jquery.toggle.buttons.js"></script>

    <script>
        $(".date-picker").datepicker();

        var handleToggleButtons = function () {
            if (!jQuery().toggleButtons) {
                return;
            }
            $('.basic-toggle-button').toggleButtons();
            $('.text-toggle-button').toggleButtons({
                width: 200,
                label: {
                    enabled: "Lorem Ipsum",
                    disabled: "Dolor Sit"
                }
            });
            $('.danger-toggle-button').toggleButtons({
                style: {
                    // Accepted values ["primary", "danger", "info", "success", "warning"] or nothing
                    enabled: "danger",
                    disabled: "info"
                }
            });
            $('.info-toggle-button').toggleButtons({
                style: {
                    enabled: "info",
                    disabled: ""
                }
            });
            $('.success-toggle-button').toggleButtons({
                style: {
                    enabled: "success",
                    disabled: "danger"
                }
            });
            $('.warning-toggle-button').toggleButtons({
                style: {
                    enabled: "warning",
                    disabled: "success"
                }
            });

            $('.height-toggle-button').toggleButtons({
                height: 100,
                font: {
                    'line-height': '100px',
                    'font-size': '20px',
                    'font-style': 'italic'
                }
            });

            $('.not-animated-toggle-button').toggleButtons({
                animated: false
            });

            $('.transition-value-toggle-button').toggleButtons({
                transitionspeed: 1 // default value: 0.05
            });

        }

    </script>
</asp:Content>
