<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createplan.aspx.cs" Inherits="createplan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <style>
        .draggableA {
            width: 70px;
            background-color: blue;
            margin: 5px;
        }

        .draggableB {
            width: 70px;
            background-color: chocolate;
            margin: 5px;
        }

        .palleteComponent {
            width: 70px;
            float: left;
            min-height: 70px;
            margin: 5px;
        }

        .draggableA, .draggableB {
            float: left;
            min-height: 70px;
            color: white;
        }

        #pallete {
            padding: 5px;
            border-style: solid;
            border-width: 1px;
            min-width: 800px;
            min-height: 80px;
            margin: 5px;
        }

        #canvas {
            min-height: 400px;
            min-width: 400px;
            padding: 5px;
            border-style: solid;
            border-width: 1px;
            margin: 5px;
        }

        #planbuilder {
            border-style: solid;
            border-width: 1px;
            padding: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Create New Plan</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Plan</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="createplan.aspx">Create</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN SAMPLE FORM widget-->
        <div class="widget">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Add Room</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body form">
                <!-- BEGIN FORM-->
                <div>
                    <div class="form-horizontal">

                        <div class="control-group">
                            <label class="control-label">Room Number</label>
                            <div class="controls">
                                <asp:TextBox ID="txtRoomNumber" runat="server" CssClass="span6 popovers" data-trigger="hover" data-content="Enter the full name of staff member." data-original-title="Popover header"></asp:TextBox>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">Floor Number</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlFloorNumber" runat="server" CssClass="span2" data-placeholder="Choose a floor" TabIndex="1" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">Room Type</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlRoomType" runat="server" CssClass="span2" data-placeholder="Choose a floor" TabIndex="1" />
                            </div>
                        </div>

                        <div class="control-group">
                                    <label class="control-label">Status</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="span4" data-placeholder="Choose a Category" TabIndex="1">
                                            <asp:ListItem>Select...</asp:ListItem>
                                            <asp:ListItem>Empty</asp:ListItem>
                                            <asp:ListItem>Occupied</asp:ListItem>
                                            <asp:ListItem>Under Maintenance</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                        <div class="form-actions">
                                    <asp:Button ID="btnCreateRoom" CssClass="btn btn-success" runat="server" Text="Add to Plan" OnClick="btnCreateRoom_Click" />
                                </div>

                        <!--START PLAN BUILDER-->
                        <div id="planbuilder">
                            <div id="pallete">
                                <div class="draggableA palleteComponent"></div>
                                <div class="draggableB palleteComponent"></div>
                            </div>
                            <div id="canvas">
                            </div>
                        </div>

                        <div class="form-actions">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
            </div>
            <!-- END PAGE CONTAINER-->
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <%--<script src="js/jquery-1.11.2.js"></script>--%>
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery.ui.rotatable.min.js"></script>
    <link type="text/css" rel="stylesheet" href="css/jquery.ui.rotatable.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#canvas').resizable();
            $(this).clone().appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
        });

        $('.draggableA').click(function () {
            $(this).clone().appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
        });

        $('.draggableB').click(function () {
            $(this).clone().appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
        });

        function save() {
            $("#canvas>.palleteComponent").each(function () {
                alert($(this).attr('style'));
            })
        }
    </script>
</asp:Content>
