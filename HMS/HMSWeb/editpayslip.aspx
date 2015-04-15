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
                        <center><h3>PAYSLIP FOR THE MONTH "________________________"</h3></center>
                        <!-- BEGIN FORM -->
                        <div>
                            <div class="form-horizontal">
                                <table border="1" align="center" style="width: 70%;" class="table table-striped table-bordered table-advance table-hover">
                                    <asp:Repeater ID="staffInfoRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <label class="boldText">Staff Code</label></td>
                                                <td>
                                                    <asp:Label ID="lblStaffCode" runat="server"><b><%# Eval("StaffCode") %></asp:Label></td>
                                                <td>
                                                    <label class="boldText">Name</label></td>
                                                <td>
                                                    <asp:Label ID="lblName" runat="server"><b><%# Eval("Name") %></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="boldText">Designation</label></td>
                                                <td>
                                                    <asp:Label ID="lblDesignation" runat="server"><b><%# Eval("Designation") %></asp:Label></td>
                                                <td>
                                                    <label class="boldText">Bank AC No</label></td>
                                                <td>
                                                    <asp:Label ID="lblBankACNo" runat="server"><b><%# Eval("BankACNumber") %></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="boldText">Department</label></td>
                                                <td>
                                                    <asp:Label ID="lblDepartment" runat="server"><b><%# Eval("DepartmentName") %></asp:Label></td>
                                                <td>
                                                    <label class="boldText">Date of Join</label></td>
                                                <td>
                                                    <asp:Label ID="lblDOJ" runat="server"><b><%# Eval("DOJ", "{0:dd-MM-yyyy}") %></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="boldText">Working Days</label></td>
                                                <td>
                                                    <asp:Label ID="lblWorkingDays" runat="server"><b>30</asp:Label></td>
                                                <td>
                                                    <label class="boldText">Days Payable</label></td>
                                                <td>
                                                    <asp:Label ID="lblDaysPayable" runat="server"><b>30</asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>

                                <br />

                                <table border="1" align="center" style="width: 70%;" class="table table-striped table-bordered table-advance table-hover">
                                    <tr>
                                        <th class="boldText" style="text-align: center">Earnings</th>
                                        <th class="boldText" style="text-align: center">&#8377</th>
                                        <th class="boldText" style="text-align: center">Deduction</th>
                                        <th class="boldText" style="text-align: center">&#8377</th>
                                    </tr>
                                    <asp:Repeater ID="payrollInfoRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>BASIC SALARY</td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtBasicSalary" Style="text-align: right" Text='<%# Eval("Salary") %>' CssClass="span6" runat="server"></asp:TextBox></td>
                                                <asp:Label ID="lblStaffCode" runat="server"><b></asp:Label></td>
                                                <td>PF</td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtPF" CssClass="span6" runat="server"></asp:TextBox></td>
                                            </tr>

                                            <tr>
                                                <td>CONVEYANCE ALLOWANCE</td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtConvAllowance" CssClass="span6" runat="server"></asp:TextBox></td>
                                                <td>PROFESSIONAL TAX</td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtProTax" CssClass="span6" runat="server"></asp:TextBox></td>
                                            </tr>

                                            <tr>
                                                <td>BONUS/EXGRATIA</td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtBonus" CssClass="span6" runat="server"></asp:TextBox></td>
                                                <td>INCOME TAX</td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtIncomeTax" CssClass="span6" runat="server"></asp:TextBox></td>
                                            </tr>

                                            <tr>
                                                <td class="boldText">Total Earnings</td>
                                                <td class="boldText">
                                                    <asp:Label ID="lblTotalEarnings" runat="server"></asp:Label></td>
                                                <td class="boldText">Total Deduction</td>
                                                <td class="boldText">
                                                    <asp:Label ID="lblTotalDeduction" runat="server"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPayableSalary" Style="font-size: 15px; font-weight: bold" runat="server" Text="Label">Total Pay</asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>

                                <br />

                                <div class="form-actions">
                                    <asp:Button ID="btnGenerate" ValidationGroup="First" CssClass="btn btn-success" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
                                    <span></span>
                                    <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- END FORM -->
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

