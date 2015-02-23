<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewcomponent.aspx.cs" Inherits="viewcomponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
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
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Is Room</label>
                                    <div class="controls">
                                        <asp:RadioButton ID="radioYes" runat="server" GroupName="IsRoom" />
                                        <span style="position: relative; top: 4px">Yes</span>
                                        <asp:RadioButton ID="radioNo" runat="server" GroupName="IsRoom" />
                                        <span style="position: relative; top: 4px">No</span>
                                    </div>
                                </div>




                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the name of season" data-original-title="Popover header"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="controls">
                                    <%--                                        <div class="fileupload fileupload-new" data-provides="fileupload">
                                            <input type="hidden">
                                            <div class="fileupload-new thumbnail" style="width: 200px; height: 150px;">
                                                <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />
                                            </div>
                                            <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 200px; max-height: 150px; line-height: 20px;"></div>
                                            <div>                                                
                                                <span class="btn btn-file"><span class="fileupload-new">select image</span>
                                                    <span class="fileupload-exists">Change</span>
                                                    <input class="default" type="file"></span>
                                                <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">Remove</a>
                                            </div>
                                        </div>--%>
                                    <div class="fileupload-new thumbnail" style="max-width: 200px; max-height: 150px;">
                                        <asp:Image ID="Image1" runat="server" />
                                    </div>
                                    <br />
                                    <br />
                                    <asp:FileUpload CssClass="fileupload-new" ID="FileUpload1" runat="server" /><br />
                                    <br />
                                    <span class="label label-important">NOTE!</span>
                                    <span>Attached image thumbnail is supported in Latest Firefox, Chrome, Opera, Safari and Internet Explorer 10 only
                                    </span>
                                </div>


                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
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
</asp:Content>

