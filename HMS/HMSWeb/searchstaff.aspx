<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchstaff.aspx.cs" Inherits="searchstaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search Staff</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Staff</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Search</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <div class="widget-body form">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Staff Name</label>
                    <div class="controls">
                        <asp:TextBox ID="txtName" runat="server" CssClass="span6  tooltips" data-trigger="hover" data-original-title="Enter staff name to search for."></asp:TextBox>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- BEGIN ADVANCED TABLE widget-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN EXAMPLE TABLE widget-->
                <div class="widget">
                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>Staff Record</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body">
                        <%--                        <!--START GridView-->
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%# Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <%# Eval("DepartmentName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%# Eval("Email") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                                    <ItemTemplate>
                                        <%# Eval("Phone") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewstaff.aspx?ID=" + Eval("StaffID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                        <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("StaffID") %>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <!--END GridView-->--%>

                        <asp:PlaceHolder ID="searchResultArea" Visible="false" runat="server">
                            <table class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <th>Staff Code</th>
                                    <th>Name</th>
                                    <th>Department Name</th>
                                    <th>Email</th>
                                    <th>Phone</th>
                                    <th></th>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Eval("StaffCode") %>
                                            </td>
                                            <td>
                                                <%# Eval("Name") %>
                                            </td>
                                            <td>
                                                <%# Eval("DepartmentName") %>
                                            </td>
                                            <td>
                                                <%# Eval("Email") %>
                                            </td>
                                            <td>
                                                <%# Eval("Phone") %>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewstaff.aspx?ID=" + Eval("StaffID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                                <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#Eval("StaffID")%>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <!--END Repeater-->
                        </asp:PlaceHolder>

                    </div>
                </div>
                <!-- END EXAMPLE TABLE widget-->
            </div>
        </div>

        <!-- END ADVANCED TABLE widget-->
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>

