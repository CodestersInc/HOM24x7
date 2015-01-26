<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchseason.aspx.cs" Inherits="searchseason" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search Season</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Season</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Search</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <div class="widget-body form">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Search Season</label>
                    <div class="controls">
                        <asp:TextBox ID="txtSeasonName" runat="server" CssClass="span4 tooltips" data-trigger="hover" data-original-title="Enter season name to search for"></asp:TextBox>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-info" OnClick="btnSubmit_Click" runat="server" Text="Search" />
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
                        <h4><i class="icon-reorder"></i>Seasons Record</h4>
                        <span class="tools">
                            <a href="javascript:;" class="icon-chevron-down"></a>
                            <a href="javascript:;" class="icon-remove"></a>
                        </span>
                    </div>
                    <div class="widget-body">

                        <!--START Repeater-->
                        <!--
                            *
                            *
                            * There is a bug that the Header of the table will show up on the page load
                            *
                            *-->
                        <table class="table table-striped table-bordered table-advance table-hover">
                            <tr>
                                <th>Name
                                </th>
                                <th>From Date
                                </th>
                                <th>To Date
                                </th>
                                
                                <th></th>
                            </tr>
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("Name") %>
                                        </td>
                                        <td>
                                            <%# Eval("FromDate") %>
                                        </td>
                                        <td>
                                            <%# Eval("ToDate") %>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewseason.aspx?ID=" + Eval("SeasonID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                                            <asp:LinkButton ID="btnRemove1" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("SeasonID") %>' CssClass="btn"><i class="icon-trash"></i> Remove</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <!--END Repeater-->
                    </div>
                </div>
                <!-- END EXAMPLE TABLE widget-->
            </div>
        </div>
        <!-- END ADVANCED TABLE widget-->
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>
