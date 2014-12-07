<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewseason.aspx.cs" Inherits="viewseason" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Season</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="hahome.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Season</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="viewseason.aspx">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Season Details</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <div>
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label">Season Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">From Date</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass=" m-ctrl-medium date-picker" size="16" Text="12-02-2012"></asp:TextBox>
                                            <%--<input class=" m-ctrl-medium date-picker" size="16" type="text" value="12-02-2012" />--%>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">To Date</label>
                                    <div class="controls">
                                        <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                            <asp:TextBox ID="txtToDate" runat="server" CssClass=" m-ctrl-medium date-picker" size="16" Text="12-02-2012"></asp:TextBox>
                                            <%--<input class=" m-ctrl-medium date-picker" size="16" type="text" value="12-02-2012" />--%>
                                            <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSave" CssClass="btn btn-inverse" runat="server" Text="Update" />
                                    <asp:LinkButton ID="lbtnSave" CssClass="btn btn-inverse" runat="server" OnClick="lbtnSave_Click"><i class="icon-refresh icon-white"></i> Update</asp:LinkButton>
                                    <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="Reset" />
                                    <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" />
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

