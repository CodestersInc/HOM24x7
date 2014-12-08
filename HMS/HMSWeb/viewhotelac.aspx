<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewhotelac.aspx.cs" Inherits="viewhotelac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Phone</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="span5"></asp:TextBox>
                                    <span class="help-inline"></span>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Address</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtAddress" CssClass="span6" Rows="3" TextMode="MultiLine" runat="server"></asp:TextBox>
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
                                <div class="controls">
                                    <div class="checkbox line">
                                        <label class="checker">
                                            <asp:CheckBox ID="cbxFeatures" runat="server" />
                                            Available
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:LinkButton ID="btnUpdate" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
                                <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="Reset" />
                                <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" />
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

