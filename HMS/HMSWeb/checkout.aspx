<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

    <!-- BEGIN SAMPLE FORM widget-->
    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-reorder"></i>Checkout Details</h4>
            <span class="tools">
                <a href="javascript:;" class="icon-chevron-down"></a>
                <a href="javascript:;" class="icon-remove"></a>
            </span>
        </div>
        <div id="printable">
            <div class="widget-body form">
                <table border="1" align="center" style="width: 70%;" class="table table-bordered table-advance table-hover">
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
                            <asp:Label ID="lblRoomNember" runat="server"><b></asp:Label></td>
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

                    <tr>
                        <td>
                            <label class="boldText">Days Of Stay</label></td>
                        <td>
                            <asp:Label ID="lblDaysOfStay" CssClass="bold" runat="server"></asp:Label></td>
                    </tr>
                </table>

                <br />

                <table border="1" align="center" style="width: 70%;" class="table table-bordered table-advance table-hover">
                    <tr>
                        <th class="boldText" style="text-align: center">Room Charge</th>
                        <th class="boldText" style="text-align: center">&#8377</th>
                        <th class="boldText" style="text-align: center">Service Charge</th>
                        <th class="boldText" style="text-align: center">&#8377</th>
                    </tr>
                    <tr>
                        <td>Basic Room Charge</td>
                        <td style="text-align: center">
                            <asp:Label ID="lblBasicRoomCharge" runat="server"></asp:Label></td>
                        <td>Service Charge</td>
                        <td style="text-align: center">
                            <asp:Label ID="lblServiceCharge" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td>Total Room Charge</td>
                        <td style="text-align: center">
                            <asp:Label ID="lblTotalRoomCharge" runat="server"></asp:Label></td>
                        <td>Total Service Charge</td>
                        <td style="text-align: center">
                            <asp:Label ID="lblTotalServiceCharge" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td class="boldText" style="text-align: center"></td>
                        <td class="boldText" style="text-align: center"></td>
                        <td class="boldText" style="text-align: center">Amount</td>
                        <td class="boldText" style="text-align: center">
                            <asp:Label ID="lblAmount" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td class="boldText" style="text-align: center"></td>
                        <td class="boldText" style="text-align: center"></td>
                        <td class="boldText" style="text-align: center">Discount</td>
                        <td class="boldText" style="text-align: center">
                            <asp:Label ID="lblDiscount" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td class="boldText" style="text-align: center"></td>
                        <td class="boldText" style="text-align: center"></td>
                        <td class="boldText" style="text-align: center">Total Amount</td>
                        <td class="boldText" style="text-align: center">
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></td>
                    </tr>

                </table>
            </div>
        </div>

        <div class="form-actions" style="text-align: center">
            <asp:LinkButton ID="btnPrint" CssClass="btn btn-primary" runat="server" OnClientClick="PrintDiv()"><i class="icon-print icon-white"></i> Print</asp:LinkButton>
            <span></span>
            <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" PostBackUrl="searchpayslip.aspx" />
        </div>
    </div>
    <!-- END SAMPLE FORM widget-->

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
