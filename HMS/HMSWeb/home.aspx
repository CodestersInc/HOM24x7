<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN THEME CUSTOMIZER-->
    <div id="theme-change" class="hidden-phone">
        <i class="icon-cogs"></i>
        <span class="settings">
            <span class="text">Theme:</span>
            <span class="colors">
                <span class="color-default" data-style="default"></span>
                <span class="color-gray" data-style="gray"></span>
                <span class="color-purple" data-style="purple"></span>
                <span class="color-navy-blue" data-style="navy-blue"></span>
            </span>
        </span>
    </div>
    <!-- END THEME CUSTOMIZER-->

    <div style="text-align:center">
        <h2><b>Home Page</b></h2>
        <asp:Image ID="Image1" ImageUrl="~/img/logo-cropped.png" runat="server"/>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
