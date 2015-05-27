<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewroomtype.aspx.cs" Inherits="viewroomtype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">View Room Type Details</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Room Type</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">View</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Room Type Details</h4>
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
                                        <asp:RequiredFieldValidator ControlToValidate="txtRoomTypeName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please add the room Type" Display="Dynamic" ValidationGroup="First" CssClass="alert alert-error"></asp:RequiredFieldValidator>
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
                                        <div class="fileupload-new thumbnail" style="max-width: 350px; max-height: 300px;">
                                            <asp:Image ID="Image1" runat="server" />
                                        </div>
                                        <asp:FileUpload CssClass="fileupload-new" ID="FileUpload1" runat="server" /><br />
                                        <br />
                                    </div>
                                </div>

                                <!--START Repeater-->
                                <table class="table table-striped table-bordered table-advance table-hover">
                                    <tr>
                                        <th>Season</th>
                                        <th>Rate</th>
                                        <th>Agent Discount</th>
                                        <th>Max Discount</th>
                                        <th>Website Rate</th>
                                    </tr>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="HiddenFieldSeasonRoomID" Value='<%# Eval("SeasonRoomID") %>' runat="server" />
                                                    <asp:HiddenField ID="HiddenFieldSeasonID" Value='<%# Eval("SeasonID") %>' runat="server" />
                                                    <a href='viewseason.aspx?ID=<%# Eval("SeasonID")%>'><b><%# Eval("Name") %></b></a>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRate" Text='<%# Eval("Rate") %>' runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAgentDiscount" Text='<%# Eval("AgentDiscount") %>' runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMaxDiscount" Text='<%# Eval("MaxDiscount") %>' runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtWebsiteRate" Text='<%# Eval("WebsiteRate") %>' runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <!--END Repeater-->

                                <div class="form-actions">
                                    <asp:LinkButton ID="btnUpdate" ValidationGroup="First" CssClass="btn btn-inverse" runat="server" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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

