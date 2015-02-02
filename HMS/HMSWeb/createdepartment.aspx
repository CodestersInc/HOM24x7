<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createdepartment.aspx.cs" Inherits="adddepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create a New Department</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Department</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="createdepartment.aspx">Create</a><span class="divider-last">&nbsp;</span>
                    </li>
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
                        <h4><i class="icon-reorder"></i>Add new Department</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <div class="widget-body form">
                            <div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label">Department Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the department name." data-original-title="Popover header"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Manager Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtManagerName" runat="server" CssClass="span6 " Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <asp:PlaceHolder ID="searchResultTable" runat="server" Visible="false">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <tr>
                                                <th>Name
                                                </th>
                                                <th>From Date
                                                </th>
                                                <th>To Date
                                                </th>

                                                <th></th>
                                            </tr>
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%# Eval("Name") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Email") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("DepartmentName") %>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="btnAddAsManager" runat="server" CommandName="Select" CommandArgument='<%#  Eval("StaffID") %>' CssClass="btn">Select as Manager</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                        <!--END Repeater-->

                                    </asp:PlaceHolder>

                                    <div class="form-actions">
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
