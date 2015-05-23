<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" %>

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
                <h3 class="page-title">Check-out Customer</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Booking</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="createbooking.aspx">Check-out</a><span class="divider-last">&nbsp;</span>
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
                        <h4><i class="icon-reorder"></i>Check-out Details</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div id="printable">
                        <div class="widget-body form">
                            <asp:PlaceHolder ID="checkOutPH" runat="server">
                                <!--Booking Info Table Start-->
                                <table border="1" align="center" style="width: 50%;" class="table table-bordered table-advance table-hover">
                                    <tr>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white" colspan="2">Occupant Details</th>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Name</label></td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Room Number</label></td>
                                        <td>
                                            <asp:Label ID="lblRoomNumber" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Room Type</label></td>
                                        <td>
                                            <asp:Label ID="lblRoomType" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Check In Date</label></td>
                                        <td>
                                            <asp:Label ID="lblCheckInDate" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Check Out Date</label></td>
                                        <td>
                                            <asp:Label ID="lblCheckOutDate" runat="server"><b></asp:Label></td>
                                    </tr>
                                </table>
                                <!--Booking Info Table End-->
                                <br />

                                <!--Room and Service Charges Table Start-->
                                <table border="1" align="center" style="width: 40%;" class="table table-bordered table-advance table-hover">
                                    <tr>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">Room Charges</th>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">&#8377</th>
                                    </tr>

                                    <tr>
                                        <td><b>Basic Room Charges</b></td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblBasicRoomCharge" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td><b>Other Charges</b></td>
                                        <td style="text-align: center">
                                            <asp:TextBox ID="txtOtherCharges" Text="0" Style="text-align: center" CssClass="span6 bold  " runat="server"></asp:TextBox></td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="[0-9]*" ControlToValidate="txtOtherCharges" ValidationGroup="First" runat="server" CssClass="error" ErrorMessage="Enter a numeric value"></asp:RegularExpressionValidator>
                                    </tr>

                                    <tr>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">Service Charges</th>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">&#8377</th>
                                    </tr>

                                    <asp:Repeater ID="serviceRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblServiceName" runat="server"><b><%# Eval("ServiceName") %></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblServiceCharge" runat="server"><b><%# Eval("ServiceCharge") %></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <!--Room and Service Charges Table End-->
                                <br />

                                <table border="1" align="center" style="width: 40%;" class="table table-bordered table-advance table-hover">
                                    <tr>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">Bill Summary</th>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">&#8377</th>
                                    </tr>

                                    <tr>
                                        <td><b>Total Amount</b></td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblTotalAmount" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td><b>Amount Paid (in advance)</b></td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblAdvancePaid" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td><b>Discounted Amount</b></td>
                                        <td style="text-align: center">
                                            <asp:TextBox ID="txtDiscountedAmount" CssClass="bold span6" Style="text-align: center" Text="0" runat="server"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td><b>Payable Amount</b></td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblPayableAmount" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td><b>Payment Mode</b></td>
                                        <td style="text-align: center">
                                            <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="span10" data-placeholder="Select/update the status of the booking" TabIndex="1">
                                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                <asp:ListItem Value="Card">Card</asp:ListItem>
                                                <asp:ListItem Value="Online Payment">Online Payment</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td><b>Payment Details/Comments</b></td>
                                        <td style="text-align: center">
                                            <asp:TextBox ID="txtPaymentDetails" TextMode="MultiLine" runat="server" CssClass="span10 popovers" data-trigger="hover" data-content="Enter payment details" data-original-title="Popover header"></asp:TextBox>
                                        </td>
                                    </tr>

                                </table>
                            </asp:PlaceHolder>
                            <br />

                            <asp:PlaceHolder ID="billSummaryPH" runat="server" Visible="false">
                                <table border="1" align="center" style="width: 50%;" class="table table-bordered table-advance table-hover">
                                    <tr>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white" colspan="2">BILL SUMMARY</th>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Name</label></td>
                                        <td>
                                            <asp:Label ID="bName" CssClass="bold" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Room Number</label></td>
                                        <td>
                                            <asp:Label ID="bRoomNumber" CssClass="bold" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Room Type</label></td>
                                        <td>
                                            <asp:Label ID="bRoomType" CssClass="bold" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Check In Date</label></td>
                                        <td>
                                            <asp:Label ID="bCheckInDate" CssClass="bold" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Check Out Date</label></td>
                                        <td>
                                            <asp:Label ID="bCheckOutDate" CssClass="bold" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">Charges Incurred</th>
                                        <th class="boldText" style="text-align: center; background-color: #30c0cb; color: white">&#8377</th>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Room Charges</label></td>
                                        <td style="text-align: right">
                                            <asp:Label ID="bRoomCharges" CssClass="bold" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Service Charges</label></td>
                                        <td style="text-align: right">
                                            <asp:Label ID="bServiceCharges" CssClass="bold" runat="server"><b></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Total Amount</label></td>
                                        <td style="text-align: right">
                                            <asp:Label ID="bTotalAmount" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Amount Paid (in advance)</label></td>
                                        <td style="text-align: right">
                                            <asp:Label ID="bAmountPaid" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Discounted Amount</label></td>
                                        <td style="text-align: right">
                                            <asp:Label ID="bDiscountedAmount" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <label class="boldText">Payable Amount</label></td>
                                        <td style="text-align: right" class="boldText">
                                            <asp:Label ID="bPayableAmount" CssClass="bold" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:PlaceHolder>
                        </div>
                    </div>

                    <div class="form-actions" style="text-align: center">
                        <asp:LinkButton ID="btnSubmit" CssClass="btn btn-success" runat="server" OnClick="btnSubmit_Click"><i class="icon-box icon-white"></i> Submit</asp:LinkButton>
                        <asp:LinkButton ID="btnEdit" CssClass="btn" runat="server" OnClick="btnEdit_Click" Visible="false"><i class="icon-edit"></i> Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnCheckout" Visible="false" CssClass="btn btn-success" runat="server" OnClick="btnCheckout_Click"><i class="icon-asterisk icon-white"></i> Checkout</asp:LinkButton>
                        <asp:LinkButton ID="btnPrint" CssClass="btn btn-primary" Visible="false" runat="server" OnClientClick="PrintDiv()"><i class="icon-print icon-white"></i> Print</asp:LinkButton>
                        <span></span>
                        <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" PostBackUrl="searchbooking.aspx" />
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
