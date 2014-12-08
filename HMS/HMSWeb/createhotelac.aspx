<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createhotelac.aspx.cs" Inherits="hacregister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="assets/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Hotel Account Registration</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Accounts</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createhotelac.aspx">Register</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Account Details</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <div class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label">Comapny</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtCompany" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Please enter the name of the registering organization." data-original-title="Suggestions"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Contact Person</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the full name of the contact person representing the organization." data-original-title="Suggestions"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Email Address</label>
                                <div class="controls">
                                    <div class="input-icon left">
                                        <i class="icon-envelope"></i>
                                        <asp:TextBox ID="txtAccountEmail" runat="server" placeholder="Email Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Phone</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtAccountPhone" runat="server" CssClass="span5"></asp:TextBox>
                                    <span class="help-inline">10 Digit Number</span>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Address</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="span6" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Website URL</label>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on">@</span>
                                        <asp:TextBox ID="txtWebsite" placeholder="Enter website URL" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Features</label>
                                <div class="danger-toggle-button">
                                    <asp:CheckBox ID="cbxFeatures" runat="server" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
                <!-- BEGIN SAMPLE FORM widget-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>Personal Details</h4>
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
                                    <label class="control-label">User Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter a distinct username." data-original-title="Suggestions"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Password</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter a strong password(8-10 characters long)." data-original-title="Suggestions"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
                <!-- BEGIN SAMPLE FORM widget-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>Professional Details</h4>
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
                                    <label class="control-label">Date of Birth</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass=" m-ctrl-medium date-picker" Text="dd-mm-yyyy"></asp:TextBox>--%>
                                            <%--<input class=" m-ctrl-medium date-picker" size="16" type="text" value="12-02-2012" />--%>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Salary</label>
                                    <div class="controls">
                                        <div class="input-prepend input-append">
                                            <span class="add-on">Rs.</span><asp:TextBox ID="txtSalary" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                        </div>
                                    </div>
                                </div>

                                <%--                                <div class="control-group">
                                    <label class="control-label">Salary Frequency</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlSalaryFrequency" runat="server" CssClass="span6" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem>Select...</asp:ListItem>
                                            <asp:ListItem Value="Monthly">Monthly</asp:ListItem>
                                            <asp:ListItem Value="Weekly">Weekly</asp:ListItem>
                                            <asp:ListItem Value="Hourly">Hourly</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>--%>

                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="server">
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
