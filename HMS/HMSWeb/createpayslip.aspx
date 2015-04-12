<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createpayslip.aspx.cs" Inherits="createpayslip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create Payslip</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Payroll</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="genratepayslip.aspx">Create Payslip</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN PAGE CONTENT-->
        <asp:PlaceHolder ID="searchResultArea" Visible="true" runat="server">
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
                            <table id="tableTT" class="table table-striped table-bordered table-advance table-hover">
                                <thead>
                                    <tr>
                                        <th style="text-align:center">Staff Code</th>
                                        <th style="text-align:center">Name</th>
                                        <th style="text-align:center">Department Name</th>
                                        <th style="text-align:center">Email</th>
                                        <th style="text-align:center">Phone</th>
                                        <th style="text-align:center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align:center">
                                                    <%# Eval("StaffCode") %>
                                                </td>
                                                <td style="text-align:center">
                                                    <a href='viewstaff.aspx?ID=<%# Eval("StaffID")%>'><%# Eval("Name") %></a>
                                                </td>
                                                <td style="text-align:center">
                                                    <a href='viewdepartment.aspx?ID=<%# Eval("DepartmentID") %>'><%# Eval("DepartmentName") %></a>
                                                </td>
                                                <td style="text-align:center">
                                                    <a href="mailto:<%# Eval("Email") %>"><%# Eval("Email") %></a>
                                                </td>
                                                <td style="text-align:center">
                                                    <%# Eval("Phone") %>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:LinkButton ID="btnGeneratePayslip" CssClass="btn btn-success" PostBackUrl='<%# "generatepayslip.aspx?ID=" + Eval("StaffID") %>' runat="server"><i class="icon-edit"></i> Generate Payslip</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align:center">Staff Code</th>
                                        <th style="text-align:center">Name</th>
                                        <th style="text-align:center">Department Name</th>
                                        <th style="text-align:center">Email</th>
                                        <th style="text-align:center">Phone</th>
                                        <th style="text-align:center">Action</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE widget-->
                </div>
            </div>
            <!-- END ADVANCED TABLE widget-->
        </asp:PlaceHolder>
        <!-- END PAGE CONTENT-->
    </div>
    <!-- END PAGE CONTAINER-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
