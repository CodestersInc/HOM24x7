<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createfloor.aspx.cs" Inherits="createfloor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create a Floor</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Floor</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createfloor.aspx">Create</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->

        <!-- BEGIN PAGE CONTENT-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN Create Room FORM-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>Create a new floor</h4>
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
                                    <label class="control-label">Floor Number</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtFloorNumber" runat="server" CssClass="span2 popovers" data-trigger="hover" data-content="Enter a floor number" data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtFloorNumber" ID="RoomNamRequiredFieldValidator" runat="server" ErrorMessage="Please enter a floor number" ValidationGroup="First" Display="Dynamic" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="span4" Rows="4"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" ValidationGroup="First" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END Create Room FORM-->
            </div>

        </div>
        <!-- END PAGE CONTENT-->
    </div>
    <!-- END PAGE CONTAINER-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>

