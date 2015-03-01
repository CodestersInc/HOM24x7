<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewstaff.aspx.cs" Inherits="viewstaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="assets/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
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
                                    <label class="control-label">Staff Code</label>
                                    <div class="controls">

                                        <asp:TextBox ID="txtStaffCode" runat="server" CssClass="span2 popovers" data-trigger="hover" data-content="Enter the staff code of staff member." data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtStaffCode" ID="StaffCodeRequiredFieldValidator" runat="server" ErrorMessage="Please enter Staff Code"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtName" ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Please enter Staff Name" />
                                        <asp:RegularExpressionValidator ControlToValidate="txtName" ID="NameRegularExpressionValidator" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Email Address</label>
                                    <div class="controls">
                                        <div class="input-icon left">
                                            <i class="icon-envelope"></i>
                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Address" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Please Enter Email Address of the staff" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtEmail" ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter valid email addres" ValidationExpression="^(?('')(''.+?''@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$" />
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Phone</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a 10 digit number" data-original-title="Instructions"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPhone" ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Please Enter 10 Digit Phone number" />
                                        <asp:RegularExpressionValidator ControlToValidate="txtPhone" ID="PhoneRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid Phone number" ValidationExpression="^[0-9]?[0-9]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">User Type</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem Value="Hotel Admin">Hotel Admin</asp:ListItem>
                                            <asp:ListItem Value="Regular Staff">Reception Staff</asp:ListItem>
                                            <asp:ListItem Value="Regular Staff">Regular Staff</asp:ListItem>
                                            <asp:ListItem Value="Managerial Staff">Managerial Staff</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Designation</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the designation of staff member (eg: Cook, Manager, Receptionist,etc.)" data-original-title="Hint"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtDesignation" ID="DesignationRequiredFieldValidator" runat="server" ErrorMessage="Please enter Designation of the staff" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Date of Birth</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="span6 txtDOB" Text="dd-mm-yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtDOB" ID="DOBRequiredFieldValidator" runat="server" ErrorMessage="Please enter Date of birth of the employee"></asp:RequiredFieldValidator>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Date of Join</label>
                                    <div class="controls">
                                        <asp:RequiredFieldValidator ControlToValidate="txtDOJ" ID="DOJRequiredFieldValidator" runat="server" ErrorMessage="Please enter Date of joining">
                                            <asp:TextBox ID="txtDOJ" Enabled="false" runat="server" CssClass="span2"></asp:TextBox>
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Salary</label>
                                    <div class="controls">
                                        <div class="input-prepend input-append">
                                            <span class="add-on">Rs.</span>
                                            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                            <asp:RequiredFieldValidator ControlToValidate="txtSalary" ID="SalaryRequiredFieldValidator" runat="server" ErrorMessage="Please enter salary" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtSalary" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter salary with numeric values only" ValidationExpression="^\d+(\.\d\d)?$" />
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
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:LinkButton ID="btnUpdate" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
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

<asp:Content ID="sdfsfs" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="server">
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

        $(".txtDOB").keypress(function (e) {
            e.preventDefault();
        });

    </script>
</asp:Content>
