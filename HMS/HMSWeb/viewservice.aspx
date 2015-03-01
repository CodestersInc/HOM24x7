<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewservice.aspx.cs" Inherits="viewservice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Service</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Service</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="viewservice.aspx">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Service Details</h4>
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
                                        <label class="control-label">Service Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the department name." data-original-title="Popover header"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtName" ID="ServiceNameRequiredFieldValidator" runat="server" ErrorMessage="Please enter the name of the new Service" ValidationGroup="First"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Department Name</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="span6" data-placeholder="Choose a Category" TabIndex="1">
                                                <asp:ListItem>Select...</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Rate</label>
                                        <div class="controls">
                                            <div class="input-prepend input-append">
                                                <span class="add-on">Rs.</span><asp:TextBox ID="txtRate" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                                <asp:RequiredFieldValidator ControlToValidate="txtRate" Display="Dynamic" ID="RateRequiredFieldValidator" runat="server" ErrorMessage="Please enter Rate of the Service" ValidationGroup="First"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtRate" Display="Dynamic" ID="RateRegularExpressionValidator" runat="server" ErrorMessage="Please enter a non negative Rate" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions">
                                        <asp:LinkButton ID="btnUpdate" ValidationGroup="First" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
                                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn" runat="server" Text="Cancel" />
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

