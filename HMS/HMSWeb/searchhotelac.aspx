<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchhotelac.aspx.cs" Inherits="hacsearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search Account</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Accounts</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="searchhotelac.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <div class="widget-body form">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Account Name</label>
                    <div class="controls">
                        <asp:TextBox ID="txtName" runat="server" CssClass="span6  tooltips" data-trigger="hover" data-original-title="Enter account to search for."></asp:TextBox>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Search" OnClick="btnSubmit_Click" />
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
                        <h4><i class="icon-reorder"></i>Account Record</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body">
                        <%--                        <table class="table table-striped table-bordered" id="sample_1">
                            <thead>
                                <tr>
                                    <th>Username</th>
                                    <th class="hidden-phone">Email</th>
                                    <th class="hidden-phone">Points</th>
                                    <th class="hidden-phone">Joined</th>
                                    <th class="hidden-phone"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>shuxer</td>
                                    <td class="hidden-phone"><a href="mailto:shuxer@gmail.com">shuxer@gmail.com</a></td>
                                    <td class="hidden-phone">120</td>
                                    <td class="center hidden-phone">12 Jan 2012</td>
                                    <td class="hidden-phone"><span class="label label-success">Approved</span></td>
                                </tr>
                                <tr class="odd gradeX">
                                    <td>looper</td>
                                    <td class="hidden-phone"><a href="mailto:looper90@gmail.com">looper90@gmail.com</a></td>
                                    <td class="hidden-phone">120</td>
                                    <td class="center hidden-phone">12.12.2011</td>
                                    <td class="hidden-phone"><span class="label label-warning">Suspended</span></td>
                                </tr>
                            </tbody>
                        </table>--%>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="Company">
                                    <ItemTemplate>
                                        <%# Eval("Company") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Person">
                                    <ItemTemplate>
                                        <%# Eval("ContactPerson") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <a href='<%# Eval("Email") %>'><%# Eval("Email") %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                                    <ItemTemplate>
                                        <%# Eval("Phone") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wesite">
                                    <ItemTemplate>
                                        <%# Eval("Website") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <a href='<%# "viewhotelac.aspx?ID=" + Eval("AccountID") %>'>View Details</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE widget-->
            </div>
        </div>

        <!-- END ADVANCED TABLE widget-->
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>

