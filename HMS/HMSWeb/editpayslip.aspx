<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editpayslip.aspx.cs" Inherits="editpayslip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <style>
        .boldText {
            font-size: 15px;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Edit Payslip</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Payslip</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Edit</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Payslip Details</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <table border="1" align="center" style="width: 70%;" class="table table-striped table-bordered table-advance table-hover">
                            <asp:Repeater ID="staffInfoRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <label class="boldText">Staff Code</label></td>
                                        <td>
                                            <asp:Label ID="lblStaffCode" CssClass="bold" runat="server"><%# Eval("StaffCode") %></asp:Label></td>
                                        <td>
                                            <label class="boldText">Name</label></td>
                                        <td>
                                            <asp:Label ID="lblName" CssClass="bold" runat="server"><%# Eval("Name") %></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="boldText">Designation</label></td>
                                        <td>
                                            <asp:Label ID="lblDesignation" CssClass="bold" runat="server"><%# Eval("Designation") %></asp:Label></td>
                                        <td>
                                            <label class="boldText">Bank AC No</label></td>
                                        <td>
                                            <asp:Label ID="lblBankACNo" CssClass="bold" runat="server"><%# Eval("BankACNumber") %></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="boldText">Department</label></td>
                                        <td>
                                            <asp:Label ID="lblDepartment" CssClass="bold" runat="server"><%# Eval("DepartmentName") %></asp:Label></td>
                                        <td>
                                            <label class="boldText">Date of Join</label></td>
                                        <td>
                                            <asp:Label ID="lblDOJ" CssClass="bold" runat="server"><%# Eval("DOJ", "{0:dd-MM-yyyy}") %></asp:Label></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td>
                                    <label class="boldText">From Date</label></td>
                                <td>
                                    <asp:Label ID="lblFromDate" CssClass="bold" runat="server"></asp:Label></td>
                                <td>
                                    <label class="boldText">To Date</label></td>
                                <td>
                                    <asp:Label ID="lblToDate" CssClass="bold" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="boldText">Total Days</label></td>
                                <td>
                                    <asp:Label ID="lblTotalDays" CssClass="bold" runat="server"></asp:Label></td>
                                <td>
                                    <label class="boldText">Days Payable</label></td>
                                <td>
                                    <asp:Label ID="lblDaysPayable" CssClass="bold" runat="server"></asp:Label></td>
                            </tr>
                        </table>

                        <br />

                        <table border="1" align="center" style="width: 70%;" class="table table-striped table-bordered table-advance table-hover">
                            <tr>
                                <th class="boldText" style="text-align: center">Earnings</th>
                                <th class="boldText" style="text-align: center">&#8377</th>
                                <th class="boldText" style="text-align: center">Deduction</th>
                                <th class="boldText" style="text-align: center">&#8377</th>
                            </tr>
                            <tr>
                                <td>BASIC SALARY</td>
                                <td style="text-align: center">
                                    <asp:TextBox ID="txtBasicSalary" Style="text-align: right" CssClass="span6" runat="server"></asp:TextBox></td>
                                <td>PF</td>
                                <td style="text-align: center">
                                    <asp:TextBox ID="txtPF" Style="text-align: right" CssClass="span6" runat="server"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>CONVEYANCE ALLOWANCE</td>
                                <td style="text-align: center">
                                    <asp:TextBox ID="txtConvAllowance" Style="text-align: right" CssClass="span6" runat="server"></asp:TextBox></td>
                                <td>PROFESSIONAL TAX</td>
                                <td style="text-align: center">
                                    <asp:TextBox ID="txtProTax" Style="text-align: right" CssClass="span6" runat="server"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>BONUS/EXGRATIA</td>
                                <td style="text-align: center">
                                    <asp:TextBox ID="txtBonus" Style="text-align: right" CssClass="span6" runat="server"></asp:TextBox></td>
                                <td>INCOME TAX</td>
                                <td style="text-align: center">
                                    <asp:TextBox ID="txtIncomeTax" Style="text-align: right" CssClass="span6" runat="server"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td class="boldText" style="text-align: center">Total Earnings</td>
                                <td class="boldText" style="text-align: center">
                                    <asp:Label ID="lblTotalEarnings" runat="server"></asp:Label></td>
                                <td class="boldText" style="text-align: center">Total Deduction</td>
                                <td class="boldText" style="text-align: center">
                                    <asp:Label ID="lblTotalDeduction" runat="server"></asp:Label></td>
                            </tr>

                            <tfoot>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Label ID="lbl" Style="font-size: 16px; font-weight: bold" runat="server">Net Pay</asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblNetPay" Style="font-size: 16px; font-weight: bold" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tfoot>
                        </table>

                        <br />

                        <div class="form-actions">
                            <asp:LinkButton ID="btnSave" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click">Save</asp:LinkButton>
                            <asp:LinkButton ID="btnUpdate" CssClass="btn btn-inverse" runat="server" Visible="false" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i> Update</asp:LinkButton>
                            <span></span>
                            <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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

