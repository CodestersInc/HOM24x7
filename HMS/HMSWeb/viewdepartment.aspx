<%@ Page Title="" Language="C#" MasterPageFile="~/HotelAdmin.master" AutoEventWireup="true" CodeFile="viewdepartment.aspx.cs" Inherits="viewdepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Department</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="hahome.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Department</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="viewdepartment.aspx">View</a><span class="divider-last">&nbsp;</span></li>
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
                            <!-- BEGIN FORM-->
                            <div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label">Department Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Department Manager</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtManager" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-actions">
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" />
                                        <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" />
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

