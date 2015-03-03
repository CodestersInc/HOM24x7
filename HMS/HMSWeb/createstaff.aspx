<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createstaff.aspx.cs" Inherits="registrestaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="assets/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Staff Member Registration</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Staff</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createstaff.aspx">Register</a><span class="divider-last">&nbsp;</span></li>
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
                                        <asp:TextBox ID="txtName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ValidationGroup="First" ErrorMessage="Please enter Staff Name" CssClass="alert alert-error" ControlToValidate="txtName" />
                                        <asp:RegularExpressionValidator ID="NameRegularExpressionValidator" runat="server" ValidationGroup="First" ErrorMessage="The name cannot contain any special characters" CssClass="alert alert-error" ControlToValidate="txtName" ValidationExpression="^[a-zA-Z''-'\s]{1,90}$" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Email Address</label>
                                    <div class="controls">
                                        <div class="input-icon left">
                                            <i class="icon-envelope"></i>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="span4" placeholder="Email Address"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Please enter an email address" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid email address" ValidationGroup="First" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Phone</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a 10 digit number" data-original-title="Instructions"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPhone" Display="Dynamic" ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Please enter a phone number" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="txtPhone" Display="Dynamic" ID="PhoneRegularExpressionValidator" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^[0-1]?[0-1]?[- .]?(\([2-9]\d{2}\)|\d{3})[- .]?\d{3}[- .]?\d{4}$" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">User Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a distinct username." data-original-title="Suggestion"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" ErrorMessage="Enter a unique username" ControlToValidate="txtUsername" ValidationGroup="First" CssClass="alert alert-error"/>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Password</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a strong password(8-10 characters long)." data-original-title="Suggestions"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Enter a strong password" ControlToValidate="txtPassword" ValidationGroup="First" CssClass="alert alert-error"/>
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
                        <h4><i class="icon-reorder"></i>Staff Registration</h4>
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
                                    <label class="control-label">Staff Code</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtStaffCode" runat="server" CssClass="span2 popovers" data-trigger="hover" data-content="Enter the staff code of staff member." data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="StaffCodeRequiredFieldValidator" runat="server" ErrorMessage="Please enter Staff Code" ControlToValidate="txtStaffCode" ValidationGroup="First" CssClass="alert alert-error"/>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">User Type</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem Value="Hotel Admin">Hotel Admin</asp:ListItem>
                                            <asp:ListItem Value="Reception Staff">Reception Staff</asp:ListItem>
                                            <asp:ListItem Value="Regular Staff">Regular Staff</asp:ListItem>
                                            <asp:ListItem Value="Managerial Staff">Managerial Staff</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Designation</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the designation of staff member (eg: Cook, Manager, Receptionist,etc.)" data-original-title="Hint"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="DesignationRequiredFieldValidator" runat="server" ValidationGroup="First" ErrorMessage="Please enter a designation" CssClass="alert alert-error" ControlToValidate="txtName" />
                                        <asp:RegularExpressionValidator ID="DesignationRegularExpressionValidator" runat="server" ValidationGroup="First" ErrorMessage="The designation cannot contain any special characters" CssClass="alert alert-error" ControlToValidate="txtName" ValidationExpression="^[a-zA-Z''-'\s]{1,90}$" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Date of Birth</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="span6 non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Salary</label>
                                    <div class="controls">
                                        <div class="input-prepend input-append">
                                            <span class="add-on">Rs.</span><asp:TextBox ID="txtSalary" CssClass="span6" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                            <asp:RequiredFieldValidator ControlToValidate="txtSalary" Display="Dynamic" ID="SalaryRequiredFieldValidator" runat="server" ErrorMessage="Please enter salary of the Staff" ValidationGroup="First"></asp:RequiredFieldValidator> <%--CssClass="alert alert-error"--%><%-- we need to fix the bug for showing the message--%>
                                            <asp:RegularExpressionValidator ControlToValidate="txtSalary" Display="Dynamic" ID="SalaryRegularExpressionValidator" runat="server" ErrorMessage="Please enter a non negative salary" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First"></asp:RegularExpressionValidator><%--CssClass="alert alert-error"--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Is Active</label>
                                    <div class="controls">
                                        <asp:CheckBox ID="cbxIsActive" CssClass="success-toggle-button toggle-button" runat="server" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Department</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1" />
                                        <b>OR</b>
                                        <asp:LinkButton ID="btnNewDepartment" runat="server" CssClass="btn" OnClick="btnNewDepartment_Click">Create New Department</asp:LinkButton>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" ValidationGroup="First" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
    <script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/date.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-toggle-buttons/static/js/jquery.toggle.yesno-buttons.js"></script>

    <script>
        $(".date-picker").datepicker();

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

        $(".non-editable").keypress(function (e) {
            e.preventDefault();
        });

    </script>
</asp:Content>
