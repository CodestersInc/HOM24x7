<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createbooking.aspx.cs" Inherits="createbooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Book a room</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Booking</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createstaff.aspx">Create</a><span class="divider-last">&nbsp;</span></li>
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
                        <h4><i class="icon-reorder"></i>Booking Details</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body form">
                        <!-- BEGIN FORM-->
                        <div>
                            <div class="form-horizontal">

                                <asp:PlaceHolder ID="noRoomPlaceHolder" runat="server" Visible="false">
                                    <div class="control-group">
                                        <div class="controls">
                                            <div class="alert">
                                                <label>Please create a room before you can generate any bookings</label>
                                                <a href="createroom.aspx">Create a new room NOW</a>
                                            </div>


                                        </div>
                                    </div>
                                </asp:PlaceHolder>

                                <asp:PlaceHolder ID="createBookingPlaceHolder" runat="server">
                                    <div class="control-group">
                                        <label class="control-label">Room Type</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlRoomType" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1" OnSelectedIndexChanged="ddlRoomType_SelectedIndexChange" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <asp:PlaceHolder ID="FloorPlaceHolder" runat="server" Visible="true">
                                        <div class="control-group">
                                            <label class="control-label">Floor</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlFloor" runat="server" CssClass="span4" data-placeholder="Choose a Category" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged" TabIndex="1" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder ID="RoomPlaceHolder" runat="server" Visible="true">
                                        <div class="control-group">
                                            <label class="control-label">Room</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlRoom" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                    <div class="control-group">
                                        <label class="control-label">Number of persons</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtNoOfPersons" runat="server" TextMode="Number" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the number of person staying in the room." data-original-title="Popover header"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NoOfPersonsRequiredFieldValidator" runat="server" ErrorMessage="Please enter Number of persons staying in the room" ControlToValidate="txtNoOfPersons" ValidationGroup="First" CssClass="alert alert-error" />
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Check in Date</label>
                                        <div class="controls">
                                            <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtCheckInDate" runat="server" CssClass="span6 non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Planned check out Date</label>
                                        <div class="controls">
                                            <div class="input-append date date-picker" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years">
                                                <asp:TextBox ID="txtPlannedCheckoutDate" runat="server" CssClass="span6 non-editable" Text="dd-mm-yyyy"></asp:TextBox>
                                                <span class="add-on"><i class="icon-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Status</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="span4" data-placeholder="Select/update the status of the booking" TabIndex="1">
                                                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                                <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                                <asp:ListItem Value="Advance Paid">Advance Paid</asp:ListItem>
                                                <asp:ListItem Value="CheckedIn">Checked in</asp:ListItem>
                                                <asp:ListItem Value="CheckedOut">Checked out</asp:ListItem>
                                                <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Customer Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter customer name" data-original-title="Hint"></asp:TextBox>
                                            <span></span>
                                            <asp:PlaceHolder ID="customerNameButtonsPlaceHolder" runat="server">
                                                <asp:Button ID="btnCustomerSearch" runat="server" CssClass="btn-link" Text="Search" OnClick="btnCustomerSearch_Click" />
                                                <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" ControlToValidate="txtCustomerName" Display="Dynamic" runat="server" ValidationGroup="First" ErrorMessage="Please enter the customer name" CssClass="alert alert-error" />
                                                <b>OR</b>
                                                <asp:Button ID="btnCustomerCreate" CssClass="btn-link" runat="server" OnClick="btnCustomerCreate_Click" Text="Create a new Customer" />
                                            </asp:PlaceHolder>
                                        </div>
                                    </div>

                                    <!--CUSTOMER CREATE START-->
                                    <asp:PlaceHolder ID="createNewCustomerPlaceHolder" runat="server" Visible="false">
                                        <div class="control-group">
                                            <label class="control-label">Email address</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCustomerEmail" runat="server" CssClass="span4" TextMode="Email"></asp:TextBox>
                                                <asp:RequiredFieldValidator ControlToValidate="txtCustomerEmail" ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Please enter Customer's email address" Display="Dynamic" ValidationGroup="Second" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Phone Number</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCustomerPhone" runat="server" CssClass="span4"></asp:TextBox>
                                                <asp:RegularExpressionValidator ControlToValidate="txtCustomerPhone" Display="Dynamic" ID="PhoneRegularExpressionValidator" runat="server" ErrorMessage="Please enter 10 digit phone number" ValidationExpression="^[0-1]?[0-1]?[- .]?(\([2-9]\d{2}\)|\d{3})[- .]?\d{3}[- .]?\d{4}$" ValidationGroup="First" CssClass="alert alert-error"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Password</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCustomerPassword" runat="server" TextMode="Password" CssClass="span4"></asp:TextBox>
                                                <asp:RequiredFieldValidator ControlToValidate="txtCustomerPassword" ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Please enter Password for the customer to login" Display="Dynamic" ValidationGroup="Second" CssClass="alert alert-error"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>
                                    <!--CUSTOMER CREATE END-->

                                    <!--CUSTOMER SEARCH START-->
                                    <asp:PlaceHolder ID="customerSearchResultPlaceHolder" runat="server" Visible="false">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <tr>
                                                <th>Name</th>
                                                <th>Email</th>
                                                <th>Phone</th>
                                                <th></th>
                                            </tr>
                                            <asp:Repeater ID="CustomerSearchResult" OnItemCommand="CustomerSearchResult_ItemCommand" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%# Eval("Name") %>
                                                        </td>
                                                        <td>
                                                            <a href="mailto:<%# Eval("Email") %>"><%# Eval("Email") %></a>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Phone") %>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:LinkButton ID="btnSelectCustomer" CommandArgument='<%# Eval("CustomerID")%>' CssClass="btn mini purple" runat="server">Select</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                        <br />
                                    </asp:PlaceHolder>
                                    <!--CUSTOMER SEARCH END-->

                                    <div class="control-group">
                                        <label class="control-label">Approver</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlApprover" CssClass="span4 popovers" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Receiver</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlReceiver" runat="server" CssClass="span4 popovers"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Staff Remarks</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtStaffRemarks" TextMode="MultiLine" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the Customer." data-original-title="Popover header"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Customer Remarks</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtCustomerRemarks" TextMode="MultiLine" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the Customer." data-original-title="Popover header"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Room Rates</label>
                                        <div class="controls">
                                            <div class="input-prepend input-append">
                                                <span class="add-on">Rs.</span><asp:TextBox ID="txtRoomRates" CssClass="span6" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                                <asp:RequiredFieldValidator ControlToValidate="txtRoomRates" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter room rate" ValidationGroup="First"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ControlToValidate="txtRoomRates" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a non negative salary" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First"></asp:RegularExpressionValidator><%--CssClass="alert alert-error"--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Paid Amount</label>
                                        <div class="controls">
                                            <div class="input-prepend input-append">
                                                <span class="add-on">Rs.</span><asp:TextBox ID="txtPaidAmount" CssClass="span6" runat="server"></asp:TextBox><span class="add-on">.00</span>
                                                <asp:RequiredFieldValidator ControlToValidate="txtPaidAmount" Display="Dynamic" ID="SalaryRequiredFieldValidator" runat="server" ErrorMessage="Please enter salary of the Staff" ValidationGroup="First"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ControlToValidate="txtPaidAmount" Display="Dynamic" ID="SalaryRegularExpressionValidator" runat="server" ErrorMessage="Please enter a non negative salary" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First"></asp:RegularExpressionValidator><%--CssClass="alert alert-error"--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Payment Mode</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="span4" data-placeholder="Select/update the status of the booking" TabIndex="1">
                                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                <asp:ListItem Value="Card">Card</asp:ListItem>
                                                <asp:ListItem Value="Online Payment">Online Payment</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Cheque Number</label>
                                        <div class="controls">
                                            <div class="input-prepend input-append">
                                                <asp:TextBox ID="txtChequeNumber" CssClass="span6" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ControlToValidate="txtChequeNumber" Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter a non negative numerical value" ValidationExpression="^\d+(\.\d\d)?$" ValidationGroup="First"></asp:RegularExpressionValidator><%--CssClass="alert alert-error"--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Bank Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="span4 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>                                            
                                            <asp:RegularExpressionValidator ID="NameRegularExpressionValidator" runat="server" ValidationGroup="First" ErrorMessage="The name cannot contain any special characters" CssClass="alert alert-error" Display="Dynamic" ControlToValidate="txtBankName" ValidationExpression="^[a-zA-Z''-'\s]{1,90}$" />
                                        </div>
                                    </div>


                                    <div class="form-actions">
                                        <asp:Button ID="btnSubmit" ValidationGroup="First" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <span></span>
                                        <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </asp:PlaceHolder>
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
    <script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/date.js"></script>
    <script type="text/javascript" src="assets/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="assets/bootstrap-toggle-buttons/static/js/jquery.toggle.yesno-buttons.js"></script>

    <script>
        $(".date-picker").datepicker();

        var handleToggleButtons = function () {
            if (!jQuery().toggleButtons) {
                return;
            }
            $('.success-toggle-button').toggleButtons({
                style: {
                    enabled: "success",
                    disabled: "danger"
                }
            });
        }

        $(".non-editable").keypress(function (e) {
            e.preventDefault();
        });

    </script>
</asp:Content>

