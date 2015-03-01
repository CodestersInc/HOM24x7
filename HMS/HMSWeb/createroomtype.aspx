<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createroomtype.aspx.cs" Inherits="createroomtype" %>

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
                                        <asp:RequiredFieldValidator ControlToValidate="txtRoomTypeName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please add the room Type" Display="Dynamic" ValidationGroup="First"></asp:RequiredFieldValidator>
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
                                        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                                        <br />
                                        <%--<span class="label label-important">NOTE!</span>
                                        <span>Attached image thumbnail is supported in Latest Firefox, Chrome, Opera, Safari and Internet Explorer 10 only</span>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END FORM-->
                    </div>
                    <!-- END Create Room FORM-->
                </div>
                <!-- END Create Room Type FORM-->

                <!-- BEGIN Create Room Type FORM-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>Season rate for room type</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <!-- BEGIN FORM-->
                        <div>
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
                                <asp:Button ID="btnSubmit" ValidationGroup="First" CssClass="btn btn-success" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-warning" OnClick="btnCancel_Click" runat="server" Text="Cancel" />
                            </div>
                        </div>
                        <!-- END FORM-->
                    </div>
                    <!-- END Create Room FORM-->
                </div>
                <!-- END Create Room Type FORM-->
            </div>
            <!-- END PAGE CONTENT-->
        </div>
        <!-- END PAGE CONTAINER-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/date.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/daterangepicker.js"></script>

    <script>
        $(".date-picker").datepicker();
    </script>
</asp:Content>

