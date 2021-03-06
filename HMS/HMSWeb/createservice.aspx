﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createservice.aspx.cs" Inherits="createservice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create a Service</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Service</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createservice.aspx">Create</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>New Service Configuration</h4>
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
                                    <label class="control-label">Service Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="span3 popovers" data-trigger="hover" data-content="Enter the Service name" data-original-title="Hint"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtName" ID="ServiceNameRequiredFieldValidator" runat="server" ErrorMessage="Please enter the name of the new Service" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Department</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="span3" data-placeholder="Choose a Category" TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Rate</label>
                                    <div class="controls">
                                        <div class="input-prepend input-append">
                                            <span class="add-on">Rs.</span><asp:TextBox ID="txtRate" CssClass="span8" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                            <asp:RequiredFieldValidator ControlToValidate="txtRate" Display="Dynamic" ID="RateRequiredFieldValidator" runat="server" ErrorMessage="Please enter Rate of the Service" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtRate" Display="Dynamic" ID="RateRegularExpressionValidator" runat="server" ErrorMessage="Please enter a non negative Rate" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Image</label>
                                    <div class="controls">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:RequiredFieldValidator ControlToValidate="FileUpload1" ID="FileUploadRequiredFieldValidator" runat="server" ErrorMessage="Please add an image file to be displayed on the plan" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                        <br />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Service Type</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="span3" data-placeholder="Choose a Type of Service" TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" ValidationGroup="First" CssClass="btn btn-success" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" />
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
