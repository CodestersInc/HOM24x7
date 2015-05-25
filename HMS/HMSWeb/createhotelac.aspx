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
                                    <asp:TextBox ID="txtCompany" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Please enter the name of the registering organization." data-original-title="Suggestions"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtCompany" ID="CompanyRequiredFieldValidator" runat="server" Display="Dynamic" ErrorMessage="Please enter the registering organization" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Contact Person</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the full name of the contact person representing the organization." data-original-title="Suggestions"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtContact" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the full name of the contact person" ValidationGroup="First" Display="Dynamic" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Email Address</label>
                                <div class="controls">
                                    <div class="input-icon left">
                                        <i class="icon-envelope"></i>
                                        <asp:TextBox ID="txtAccountEmail" runat="server" placeholder="Email Address"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtAccountEmail" Display="Dynamic" ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Please enter the Email Adress of the hotel" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="txtAccountEmail" Display="Dynamic" ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid Email address" ValidationGroup="First" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Phone</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtAccountPhone" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a 10 digit number" data-original-title="Instructions"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtAccountPhone" Display="Dynamic" ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Please enter a phone number" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="txtAccountPhone" Display="Dynamic" ID="PhoneRegularExpressionValidator" runat="server" ErrorMessage="Please eneter a valid phone number" ValidationExpression="^[0-1]?[0-1]?[- .]?(\([2-9]\d{2}\)|\d{3})[- .]?\d{3}[- .]?\d{4}$" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Address</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="span4" Rows="3"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Website URL</label>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on">URL</span>
                                        <asp:TextBox ID="txtWebsite" placeholder="Enter website URL" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ControlToValidate="txtWebsite" ID="WebsiteRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid website URL" ValidationExpression="(?i:(http\:\/\/|https\:\/\/)?([a-z0-9][a-z0-9\-]*\.)+[a-z0-9][a-z0-9\-]*$)" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Online Booking Feature</label>
                                <div class="controls">
                                    <asp:CheckBox ID="cbxOnlineBooking" CssClass="success-toggle-button toggle-button" runat="server" />
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Payroll Feature</label>
                                <div class="controls">
                                    <asp:CheckBox ID="cbxPayroll" CssClass="success-toggle-button toggle-button" runat="server" />
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Service Feature</label>
                                <div class="controls">
                                    <asp:CheckBox ID="cbxService" CssClass="success-toggle-button toggle-button" runat="server" />
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
                                        <asp:TextBox ID="txtName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Staff name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtName" ID="StaffNameRequiredFieldValidator" runat="server" ErrorMessage="Please enter the name of the hotel admin" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Email Address</label>
                                    <div class="controls">
                                        <div class="input-icon left">
                                            <i class="icon-envelope"></i>
                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Address"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ID="StaffEmailRequiredFieldValidator" runat="server" ErrorMessage="Please enter the Email Adress of the hotel admin" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtEmail" Display="Dynamic" ID="StaffEmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid Email address" ValidationGroup="First" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Phone</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a 10 digit number" data-original-title="Instructions"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPhone" Display="Dynamic" ID="StaffPhoneRequiredFieldValidator" runat="server" ErrorMessage="Please enter a phone number" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="txtPhone" Display="Dynamic" ID="StaffPhoneRegularExpressionValidator" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^[0-1]?[0-1]?[- .]?(\([2-9]\d{2}\)|\d{3})[- .]?\d{3}[- .]?\d{4}$" ValidationGroup="First"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">User Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a distinct username." data-original-title="Suggestions"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtUsername" ID="UsernameRequiredFieldValidator" runat="server" ErrorMessage="Please enter the Username for the manager" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Password</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a strong password(8-10 characters long)." data-original-title="Suggestions"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Please enter the password" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
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
                                    <label class="control-label">Staff Code</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtStaffCode" runat="server" CssClass="span2 popovers" data-trigger="hover" data-content="Enter the staff code of staff member (to be assigned or already assigned)" data-original-title="Hint"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtStaffCode" ID="StaffCodeRequiredFieldValidator" runat="server" ErrorMessage="Please enter the staff-code" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                <div class="control-group">
                                    <label class="control-label">Date of Birth</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="01-01-2015" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="span6 non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Salary</label>
                                    <div class="controls">
                                        <div class="input-prepend input-append">
                                            <span class="add-on">Rs.</span><asp:TextBox ID="txtSalary" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                            <asp:RequiredFieldValidator ControlToValidate="txtSalary" Display="Dynamic" ID="SalaryRequiredFieldValidator" runat="server" ErrorMessage="Please enter salary of the Staff" ValidationGroup="First"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtSalary" Display="Dynamic" ID="SalaryRegularExpressionValidator" runat="server" ErrorMessage="Please enter a non negative salary" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Bank AC Number</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtBankACNumber" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter bank AC number (if any)" data-original-title="Hint"></asp:TextBox>                                        
                                        <asp:RegularExpressionValidator ControlToValidate="txtBankACNumber" Display="Dynamic" ID="BankACNoRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid AC number" ValidationExpression="[a-zA-Z]{2}[0-9]{2}[a-zA-Z0-9]{4}[0-9]{7}([a-zA-Z0-9]?){0,16}" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" ValidationGroup="First" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
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

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="server">
    <script type="text/javascript" src="assets/bootstrap-toggle-buttons/static/js/jquery.toggle.buttons.js"></script>

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
