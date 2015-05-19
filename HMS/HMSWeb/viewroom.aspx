<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewroom.aspx.cs" Inherits="viewroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create a Room</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Room</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Create a new room</h4>
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
                                    <label class="control-label">Room Number</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtRoomNumber" runat="server" CssClass="span2 popovers" data-trigger="hover" data-content="Enter a room number" data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtRoomNumber" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please add the room number" Display="Dynamic" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Room Type</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlRoomType" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Floor</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlFloor" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Status</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem>Booked</asp:ListItem>
                                            <asp:ListItem>Empty</asp:ListItem>
                                            <asp:ListItem>Occupied</asp:ListItem>
                                            <asp:ListItem>Under Maintenance</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:LinkButton ID="btnUpdate" ValidationGroup="First" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
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