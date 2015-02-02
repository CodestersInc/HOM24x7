﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createroomtype.aspx.cs" Inherits="createroomtype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link href="assets/bootstrap/css/bootstrap-fileupload.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create a Room Type</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Room Type</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createroomtype.aspx">Create</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->

        <!-- BEGIN PAGE CONTENT-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN Create Room Type FORM-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>Create a new room type</h4>
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
                                    <label class="control-label">Room Type</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtRoomTypeName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter a room type" data-original-title="Hint"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="span5" Rows="4"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Photo</label>
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
                                </div>

                                <div>
                                    <!-- START SEASON MAPPING -->
                                    <!--START Repeater-->
                                    <table class="table table-striped table-bordered table-advance table-hover">
                                        <tr>
                                            <th>Season</th>
                                            <th>Rate</th>
                                            <th>Agent Discount</th>
                                            <th>Max Discount</th>
                                            <th>Website Rate</th>
                                        </tr>
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField ID="HiddenFieldSeasonID" Value='<%# Eval("SeasonID") %>' runat="server" />
                                                        <b><%# Eval("Name") %></b>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAgentDiscount" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxDiscount" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtWebsiteRate" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                    <!--END Repeater-->
                                    <!-- END SEASON MAPPING -->
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" OnClick="btnCancel_Click" runat="server" Text="Cancel" />
                                </div>

                            </div>
                        </div>
                        <!-- END FORM-->
                    </div>
                    <!-- END Create Room FORM-->
                </div>
            </div>
            <!-- END PAGE CONTENT-->
        </div>
        <!-- END PAGE CONTAINER-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <script type="text/javascript" src="assets/bootstrap/js/bootstrap-fileupload.js"></script>
</asp:Content>

