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
                    <li><a href="genratepayslip.aspx">Genrate Payslip</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN PAGE CONTENT-->
        <asp:PlaceHolder ID="searchResultArea" Visible="true" runat="server">

        </asp:PlaceHolder>
        <!-- END PAGE CONTENT-->
    </div>
    <!-- END PAGE CONTAINER-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
