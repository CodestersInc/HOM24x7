<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewhotelac.aspx.cs" Inherits="viewhotelac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="assets/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Hotel Account</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Accounts</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="viewhotelac.aspx">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Hotel Account Details</h4>
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
                                    <asp:RequiredFieldValidator ControlToValidate="txtCompany" ID="CompanyRequiredFieldValidator" runat="server" Display="Dynamic" ErrorMessage="Please enter the registering organization" ValidationGroup="First"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Contact Person</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the full name of the contact person representing the organization." data-original-title="Suggestions"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtContact" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the full name of the contact person" ValidationGroup="First" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Email Address</label>
                                <div class="controls">
                                    <div class="input-icon left">
                                        <i class="icon-envelope"></i>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="span4" placeholder="Email Address"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Please enter the Email Adress of the hotel" ValidationGroup="First"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" Display="Dynamic" ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid Email address" ValidationGroup="First" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Phone</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="span4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPhone" Display="Dynamic" ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Please enter a phone number" ValidationGroup="First"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="txtPhone" Display="Dynamic" ID="PhoneRegularExpressionValidator" runat="server" ErrorMessage="Please eneter a valid phone number" ValidationExpression="^[0-1]?[0-1]?[- .]?(\([2-9]\d{2}\)|\d{3})[- .]?\d{3}[- .]?\d{4}$" ValidationGroup="First"></asp:RegularExpressionValidator>
                                    <span class="help-inline"></span>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Address</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtAddress" CssClass="span4" Rows="3" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Website URL</label>
                                <div class="controls">
                                    <div class="input-prepend">                                        
                                        <span class="add-on">URL</span>
                                        <asp:TextBox ID="txtWebsite" placeholder="Enter website URL" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ControlToValidate="txtWebsite" ID="WebsiteRegularExpressionValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid website URL" ValidationExpression="/((?:https?\:\/\/|www\.)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*)/i" ValidationGroup="First"></asp:RegularExpressionValidator>
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

                            <div class="form-actions">
                                <asp:LinkButton ID="btnUpdate" ValidationGroup="First" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>                                
                                <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
    <script type="text/javascript" src="assets/bootstrap-toggle-buttons/static/js/jquery.toggle.buttons.js"></script>

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
    </script>
</asp:Content>
