<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createcomponent.aspx.cs" Inherits="createcomponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="assets/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create a Component</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Component</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createseason.aspx">Create</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>New Component Configuration</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <div id="hacRegister">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label">Component Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtComponentName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the name of season" data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtComponentName" ID="NameRequiredFieldValidator" ValidationGroup="First" runat="server" ErrorMessage="Please give a Name to the component" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Is Room</label>
                                    <div class="controls">
                                        <asp:CheckBox ID="cbxIsRoom" CssClass="success-toggle-button toggle-button" runat="server" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="span4" Rows="4"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Image</label>
                                    <div class="controls">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:RequiredFieldValidator ControlToValidate="FileUpload1" ID="FileUploadRequiredFieldValidator" runat="server" ErrorMessage="Please add an image file to be displayed on the plan" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                        <br />
                                        <br />                                        
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" OnClick="btnSubmit_Click" runat="server" Text="Submit" ValidationGroup="First" />
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" OnClick="btnCancel_Click" runat="server" Text="Cancel" />
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
    <script type="text/javascript" src="assets/bootstrap-toggle-buttons/static/js/jquery.toggle.yesno-buttons.js"></script>

    <script>
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

