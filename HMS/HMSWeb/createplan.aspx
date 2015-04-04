<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createplan.aspx.cs" Inherits="createplan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <style>
        .paletteComponent {
            width: 70px;
            height: 70px;
            float: left;
        }

        #palette {
            min-width: 400px;
            min-height: 80px;
        }

        /*.room {
            width: 50px;
            height: 50px;
            background-color: gray;
            text-align: left;
            vertical-align: middle;
            color: white;
        }*/

        /*#canvas {
            min-height: 400px;
            min-width: 400px;
            padding: 5px;
            border-style: solid;
            border-width: 1px;
            margin: 5px;
        }*/

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

        <asp:PlaceHolder ID="floorNumberPlaceHolder" runat="server">
            <div class="widget-body form">
                <div class="form-horizontal">
                    <div class="control-group">
                        <label class="control-label">Select a Floor</label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlFloor" runat="server" CssClass="span3" data-placeholder="Choose a floor" TabIndex="1" />
                            <asp:HiddenField ID="floorHiddenField" runat="server" />
                            <span></span>
                            <asp:Button ID="createPlan" CssClass="btn btn-info" runat="server" Text="Create Plan" OnClick="createPlan_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="planBuilderPlaceHolder" runat="server" Visible="false">
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
                                    <select id="roomList" class="span3">
                                        <asp:Repeater ID="selectionRepeater" runat="server">
                                            <ItemTemplate>
                                                <option value='<%# Eval("RoomID") %>'><%# Eval("RoomNumber") %></option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                    <b>OR</b>
                                    <a href="createroom.aspx"><b>Create a new room</b></a>
                                </div>
                                <br />
                                <div class="controls">
                                    <input id="btnAddToCanvas" class="btn-primary" type="button" value="Add to Plan" />
                                </div>
                            </div>

                            <!--START PLAN BUILDER-->
                            <!--START PALLETTE-->
                            <!-- BEGIN EXAMPLE TABLE widget-->
                            <asp:PlaceHolder ID="palettePlaceHolder" runat="server" Visible="false">
                                <div class="widget" style="padding-left: 5px">
                                    <div class="widget-title">
                                        <h4><i class="icon-reorder"></i>Pallete</h4>
                                        <span class="tools">
                                            <a href="javascript:;" class="icon-chevron-down"></a>
                                            <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                                    </div>
                                    <div id="room">ROOM</div>

                                    <div class="widget-body" style="min-height: 80px">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <div class="paletteComponent" style="vertical-align: middle">
                                                    <asp:Image ID="Image1" ImageUrl='<%# Eval("Image") %>' runat="server" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <!-- END EXAMPLE TABLE widget-->
                            </asp:PlaceHolder>
                            <!--END PALLETTE-->
                            <div id="canvas" style="min-height: 400px; min-width: 400px; padding: 5px; border-style: solid; border-width: 1px; margin: 5px;"></div>
                            <!-- END PLAN BUILDER-->

                            <div class="form-actions">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClientClick="savePlanData()" OnClick="btnSubmit_Click" />
                                <span></span>
                                <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>

                            <asp:TextBox ID="txtPlanData" CssClass="txtPlanData" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtPlanComponentData" CssClass="txtPlanComponentData" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <!-- END SAMPLE FORM widget-->
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </asp:PlaceHolder>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery.ui.rotatable.min.js"></script>
    <link type="text/css" rel="stylesheet" href="css/jquery.ui.rotatable.css" />
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $('#canvas').resizable();
        //    $(this).clone().appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
        //});

        //$('.paletteComponent').click(function () {
        //    $(this).clone().appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
        //});

        $(document).ready(function () {
            $('#canvas').resizable();
        });

        $('#btnAddToCanvas').click(function () {
            var x = document.getElementById("roomList");

            if (x.length != 0) {
                $("<div class='room' style= 'width: 50px; height: 50px; background-color: gray; text-align: left; vertical-align: middle; color: white;'></div>").appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" }).attr("roomid", $("#roomList").val());
                x.remove(x.selectedIndex);
            }
        });

    </script>

    <script type="text/javascript">
        var data = "";
        var canvasData = ""
        function savePlanData() {

            <%--Save PlanComponent details--%>
            $("#canvas>.room").each(function () {
                data += $(this).attr('roomid') + "&" + $(this).attr('style') + "#";
            });
            $('.txtPlanComponentData').val(data);

            <%--Save Plan details--%>
            canvasData = $('#canvas').attr('style');
            $('.txtPlanData').val(canvasData);
        }
    </script>
</asp:Content>
