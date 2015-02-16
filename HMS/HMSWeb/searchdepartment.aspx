<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchdepartment.aspx.cs" Inherits="searchdepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search Department</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Department</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="departmentsearch.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <div class="widget-body form">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Department Name</label>
                    <div class="controls">
                        <asp:TextBox ID="txtName" runat="server" CssClass="span4 tooltips" data-trigger="hover" data-original-title="Enter department name to search for."></asp:TextBox>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:PlaceHolder ID="searchResultArea" Visible="false" runat="server">
            <!-- BEGIN ADVANCED TABLE widget-->
            <div class="row-fluid">
                <div class="span12">
                    <!-- BEGIN EXAMPLE TABLE widget-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Department Record</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <table class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <th>Department
                                    </th>
                                    <th>Manager
                                    </th>
                                    <th></th>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Eval("Department") %>
                                            </td>
                                            <td>
                                                <%# Eval("Manager") %>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="btnEdit1" CssClass="btn mini purple" PostBackUrl='<%# "viewdepartment.aspx?ID=" + Eval("DepartmentID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                                <asp:LinkButton ID="btnRemove1" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("DepartmentID") %>' CssClass="btn"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE widget-->
                </div>
            </div>

            <!-- END ADVANCED TABLE widget-->
        </asp:PlaceHolder>
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
