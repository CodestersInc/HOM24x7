<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchservicetype.aspx.cs" Inherits="searchservicetype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search a Service Type</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Service Type</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="searchservicetype.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <div class="widget-body form">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Type of Service</label>
                    <div class="controls">
                        <asp:TextBox ID="txtName" runat="server" CssClass="span3  tooltips" data-trigger="hover" data-original-title="Enter Service Type to search for."></asp:TextBox>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:PlaceHolder ID="searchResultArea" Visible="false" runat="server">
            <!-- BEGIN ADVANCED TABLE widget-->
            <div class="row-fluid">
                <div class="span12">
                    <!-- BEGIN EXAMPLE TABLE widget-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Component Record</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <table class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <th style="text-align:center">Name</th>
                                    <th style="text-align:center">Photo</th>
                                    <th style="text-align:center">Description</th>
                                    <th></th>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>                                            
                                            <td style="vertical-align: middle; text-align:center">
                                                <a href='viewservicetype.aspx?ID=<%# Eval("ServiceTypeID") %>'><%# Eval("Name") %></a>
                                            </td>
                                            <td style="text-align: center">
                                                <img src='<%# Eval("Image") %>' style="max-height: 100px; max-width: 150px;" />
                                            </td>
                                            <td style="vertical-align: middle; text-align:center">
                                                <%# Eval("Description") %>
                                            </td>
                                            <td style="vertical-align: middle; text-align:center">
                                                <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewservicetype.aspx?ID=" + Eval("ServiceTypeID") %>' runat="server"><i class="icon-edit"></i>Edit</asp:LinkButton>
                                                <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#Eval("ServiceTypeID")%>' CssClass="btn mini purple"><i class="icon-trash"></i>Remove</asp:LinkButton>
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
        </asp:PlaceHolder>
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>

