﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewdepartment.aspx.cs" Inherits="viewdepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Department</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Department</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Department Details</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <div class="widget-body form">
                            <div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label">Department Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtDepartmentName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the department name." data-original-title="Popover header"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtDepartmentName" ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Please Enter the Name of Department" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <asp:PlaceHolder ID="managerNamePlaceHolder" runat="server">
                                        <div class="control-group">
                                            <label class="control-label">Manager Name</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtManagerName" runat="server" CssClass="span4" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder ID="managerChoicePlaceHolder" runat="server" Visible="false">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <tr>
                                                <th>Name</th>
                                                <th>Email</th>
                                                <th>Department</th>
                                                <th></th>
                                            </tr>
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%# Eval("Name") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Email") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("DepartmentName") %>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:LinkButton ID="btnAddAsManager" runat="server" CommandName="Select" CommandArgument='<%#  Eval("StaffID") %>' CssClass="btn">Select as Manager</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <!--END Repeater-->
                                        </table>
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder ID="newManagerPlaceHolder" runat="server">
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
                                                                        <asp:RequiredFieldValidator ControlToValidate="txtName" ID="StaffNameRequiredFieldValidator" runat="server" ErrorMessage="Please enter the name of the NEW Manager" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Email Address</label>
                                                                    <div class="controls">
                                                                        <div class="input-icon left">
                                                                            <i class="icon-envelope"></i>
                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="span4" placeholder="Email Address"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Please enter the Email Adress of the NEW Manager" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid Email address" ValidationGroup="First" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="alert alert-error"></asp:RegularExpressionValidator>
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
                                                                    <label class="control-label">Username</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a distinct username." data-original-title="Suggestion"></asp:TextBox>
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
                                                                        <asp:RequiredFieldValidator ControlToValidate="txtStaffCode" ID="StaffCodeRequiredFieldValidator" runat="server" ErrorMessage="Please enter the staff-code" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">User Type</label>
                                                                    <div class="controls">
                                                                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1">
                                                                            <asp:ListItem Value="Managerial Staff">Managerial Staff</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Designation</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the designation of staff member (eg: Cook, Manager, Receptionist,etc.)" data-original-title="Hint"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ControlToValidate="txtDesignation" ID="DesignationRequiredFieldValidator" runat="server" ErrorMessage="Please enter a Designation for the new manager" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
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
                                                                            <asp:RequiredFieldValidator ControlToValidate="txtSalary" Display="Dynamic" ID="SalaryRequiredFieldValidator" runat="server" ErrorMessage="Please enter salary of the Staff" ValidationGroup="First"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ControlToValidate="txtSalary" Display="Dynamic" ID="SalaryRegularExpressionValidator" runat="server" ErrorMessage="Please enter a non negative salary" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First"></asp:RegularExpressionValidator>
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

                                                                <div class="control-group">
                                                                    <label class="control-label">Is Active</label>
                                                                    <div class="controls">
                                                                        <asp:CheckBox ID="cbxIsActive" CssClass="success-toggle-button toggle-button" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- END SAMPLE FORM widget-->
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                    <div class="form-actions">
                                        <asp:LinkButton ValidationGroup="First" ID="btnUpdate" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
                                        <asp:Button ID="btnCancel" CssClass="btn" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                        <asp:LinkButton ID="btnNewManager" runat="server" CssClass="btn show-right" OnClick="btnNewManager_Click">Create New Manager</asp:LinkButton>
                                    </div>
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
