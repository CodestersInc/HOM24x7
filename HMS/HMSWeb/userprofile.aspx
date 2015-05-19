<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="userprofile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">User Profile</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">My Profile</a> <span class="divider-last">&nbsp;</span>
                    </li>
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
                        <h4><i class="icon-reorder"></i>User Information</h4>
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
                                        <asp:TextBox ID="txtName" Enabled="false" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ValidationGroup="First" ErrorMessage="Please enter Staff Name" Display="Dynamic" CssClass="alert alert-error" ControlToValidate="txtName" />
                                        <asp:RegularExpressionValidator ID="NameRegularExpressionValidator" runat="server" ValidationGroup="First" ErrorMessage="The name cannot contain any special characters" CssClass="alert alert-error" Display="Dynamic" ControlToValidate="txtName" ValidationExpression="^[a-zA-Z''-'\s]{1,90}$" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Email Address</label>
                                    <div class="controls">
                                        <div class="input-icon left">
                                            <i class="icon-envelope"></i>
                                            <asp:TextBox ID="txtEmail" Enabled="false" runat="server" CssClass="span4" placeholder="Email Address"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Please enter an email address" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid email address" ValidationGroup="First" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Phone</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPhone" Enabled="false" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a 10 digit number" data-original-title="Instructions"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPhone" Display="Dynamic" ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Please enter a phone number" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="txtPhone" Display="Dynamic" ID="PhoneRegularExpressionValidator" runat="server" ErrorMessage="Please enter 10 digit valid phone number" ValidationExpression="^[0-1]?[0-1]?[- .]?(\([2-9]\d{2}\)|\d{3})[- .]?\d{3}[- .]?\d{4}$" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <asp:PlaceHolder ID="pwdPH" runat="server">
                                    <div class="control-group">
                                        <label class="control-label">Password</label>
                                        <div class="controls">
                                            <asp:Button ID="btnchangepwd" CssClass="btn btn-success" runat="server" Text="Change Password" OnClick="btnchangepwd_Click" />
                                        </div>
                                    </div>
                                </asp:PlaceHolder>

                                <asp:PlaceHolder ID="changePwdPH" runat="server" Visible="false">
                                    <div class="control-group">
                                        <label class="control-label">Current Password</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtCurrentPwd" TextMode="Password" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter current password" data-original-title="Suggestions"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Enter a strong password" ControlToValidate="txtCurrentPwd" ValidationGroup="First" CssClass="alert alert-error" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">New Password</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtNewPwd" TextMode="Password" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a strong password (8-10 characters long)." data-original-title="Suggestions"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a strong password" ControlToValidate="txtNewPwd" ValidationGroup="First" CssClass="alert alert-error" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Confirm Password</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtConfirmPwd" TextMode="Password" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Confirm new password" data-original-title="Suggestions"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtConfirmPwd" ControlToCompare="txtNewPwd" runat="server" ErrorMessage="Passwords Mismatch...!!" ValidationGroup="First" CssClass="alert alert-error"></asp:CompareValidator>
                                        </div>
                                    </div>
                                </asp:PlaceHolder>

                                <div class="form-actions">
                                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-info" runat="server" OnClick="btnEdit_Click"><i class="icon-edit icon-white"></i> Edit</asp:LinkButton>
                                    <asp:LinkButton ID="btnUpdate" Visible="false" ValidationGroup="First" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i> Update</asp:LinkButton>
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
</asp:Content>
