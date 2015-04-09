<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewservicetype.aspx.cs" Inherits="viewservicetype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Service Type</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Service Type</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="viewservicetype.aspx">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Type of Service</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <div id="hacRegister">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label">Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtServiceTypeName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the name of season" data-original-title="Popover header"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtServiceTypeName" ID="NameRequiredFieldValidator" ValidationGroup="First" runat="server" ErrorMessage="Please give a Name to the component" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="span4" Rows="4"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Photo</label>
                                    <div class="controls">
                                        <div>
                                            <asp:Image ID="Image1" runat="server" style="max-width:280px; max-height: 150px" />
                                        </div>                                        
                                        <asp:FileUpload CssClass="fileupload-new" ID="FileUpload1" runat="server" />
                                        <br />
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:LinkButton ID="btnUpdate" ValidationGroup="First" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>

