<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchroomtype.aspx.cs" Inherits="searchroomtype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Search a Room Type</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Room Type</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="searchroomtype.aspx">Search</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <div class="widget-body form">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Room Type Name</label>
                    <div class="controls">
                        <asp:TextBox ID="txtRoomTypeName" runat="server" CssClass="span6  tooltips" data-trigger="hover" data-original-title="Enter Room Type name to search for."></asp:TextBox>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>

        <table class="table table-striped table-bordered">
            <tr>
                <th>Room Type</th>
                <th></th>
            </tr>
            
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("Name")%></td>
                        <td>
                            <asp:LinkButton ID="btnEdit" CssClass="btn mini purple" PostBackUrl='<%# "viewroomtype.aspx?ID=" + Eval("RoomTypeID") %>' runat="server"><i class="icon-edit"></i> Edit</asp:LinkButton>
                            <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%#  Eval("RoomTypeID") %>' CssClass="btn mini purple"><i class="icon-trash"></i> Remove</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
</asp:Content>

