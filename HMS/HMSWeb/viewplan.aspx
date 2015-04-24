<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewplan.aspx.cs" Inherits="viewplan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <style>
        .paletteComponent {
            float: left;
            padding-left: 30px;
        }

        #palette {
            min-width: 400px;
            min-height: 80px;
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
                <h3 class="page-title">View Plan</h3>
                <ul class="breadcrumb">
                    <li>
                        <a href="home.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li>
                        <a href="#">Plan</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">View</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <!-- END PAGE HEADER-->

        <asp:PlaceHolder ID="planBuilderPlaceHolder" runat="server">
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
                                    <input id="btnAddRoomToCanvas" class="btn-primary" type="button" value="Add to Plan" />                                    
                                </div>
                            </div>

                            <!--START PLAN BUILDER-->
                            <!--START PALLETTE-->
                            <asp:PlaceHolder ID="palettePlaceHolder" runat="server">
                                <div class="widget palette">
                                    <div class="widget-title">
                                        <h4><i class="icon-reorder"></i>Pallete (Click on the component to add to canvas)</h4>
                                        <span class="tools">
                                            <a href="javascript:;" class="icon-chevron-down"></a>
                                            <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                                    </div>

                                    <div class="widget-body" style="min-height: 80px">
                                        <label class="noComponentsMessage" style="display:none; font-size:20px; text-align:center; padding-top:20px">No custom components added yet...!!</label>
                                        <asp:Repeater ID="componentRepeater" runat="server">
                                            <ItemTemplate>
                                                <div class="paletteComponent" style='<%# "background-image:url("+Eval("Image")+");background-repeat:no-repeat;background-size:contain;width:70px;height:70px;" %>'' componentid='<%# Eval("ComponentID") %>'></div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </asp:PlaceHolder>
                            <!--END PALLETTE-->

                            <!--START CANVAS-->
                            <asp:Repeater ID="planCanvasRepeater" runat="server">
                                <ItemTemplate>
                                    <div id="canvas" style='<%# Eval("PlanStyle") %>'>
                                </ItemTemplate>
                            </asp:Repeater>

                            <asp:Repeater ID="roomComponentRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="room" roomid='<%# Eval("RoomID") %>' style='<%# Eval("PlanComponentStyle") %>'></div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <asp:Repeater ID="otherComponentRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="otherComponent" componentid='<%# Eval("ComponentID") %>' style='<%# Eval("PlanComponentStyle") %>'></div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <!--END CANVAS-->
                        </div>
                        <!-- END PLAN BUILDER-->

                        <div class="form-actions">
                            <asp:LinkButton ID="btnUpdate" CssClass="btn btn-inverse" runat="server" OnClientClick="savePlanData()" OnClick="btnUpdate_Click"><i class="icon-refresh icon-white"></i>Update</asp:LinkButton>
                            <span></span>
                            <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
            </div>
            <asp:TextBox ID="txtPlanData" CssClass="txtPlanData" style="display:none" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtRoomComponentData" CssClass="txtRoomComponentData" style="display:none" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtOtherComponentData" CssClass="txtOtherComponentData" style="display:none" runat="server"></asp:TextBox>
            <!-- END PAGE CONTAINER-->
    </asp:PlaceHolder>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery.ui.rotatable.min.js"></script>
    <link type="text/css" rel="stylesheet" href="css/jquery.ui.rotatable.css" />

    <%--Manage plan components on document load--%>
    <script type="text/javascript">
        $(document).ready(function () {
            <%--Making canvas resizable--%>
            $('#canvas').resizable();

            <%--Making plan components draggable, resizable, and rotatable--%>
            $("#canvas>.room, .otherComponent").each(function () {
                $(this).draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
            });

            <%--Palette has no custom components---%>
            var items = $('div.paletteComponent').length;
            if (items == 0) {
                $('.noComponentsMessage').show();
            }
        });
    </script>

    <%--Add rooms to canvas--%>
    <script type="text/javascript">
        $('#btnAddRoomToCanvas').click(function () {
            var x = document.getElementById("roomList");

            if (x.length != 0) {
                $("<div class='room' style= 'width: 70px; height: 70px; background-color: gray; position:absolute; top:0; left:0'></div>").prependTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" }).attr("roomid", $("#roomList").val());
                x.remove(x.selectedIndex);

                <%--Disable AddRoomTOCanvas button if no rooms--%>
                if (x.length == 0) {
                    $('#btnAddRoomToCanvas').attr("disabled", true);
                }
            }
        });
    </script>

    <%--Add other components to canvas--%>
    <script type="text/javascript">
        $('.paletteComponent').click(function () {
            $(this).clone()
                .prependTo('#canvas')
                .draggable({ containment: "#canvas" })
                .resizable({ containment: "#canvas" })
                .rotatable({ containment: "#canvas" })
                .removeClass('paletteComponent')
                .addClass('otherComponent')
                .css({ "position": "absolute", "top": "0", "left": "0" });;
        });
    </script>

    <%--Grabbing css of plan and plan components--%>
    <script type="text/javascript">
        var canvasData = ""
        var roomComponentData = "";
        var otherComponentData = "";

        function savePlanData() {
            <%--Save Plan details--%>
            canvasData = $('#canvas').attr('style');
            $('.txtPlanData').val(canvasData);

            <%--Save PlanComponent details--%>
            $("#canvas>.room").each(function () {
                roomComponentData += $(this).attr('roomid') + "&" + $(this).attr('style') + "#";
            });
            $('.txtRoomComponentData').val(roomComponentData);

            <%--Save PlanComponent details--%>
            $("#canvas>.otherComponent").each(function () {
                otherComponentData += $(this).attr('componentid') + "&" + $(this).attr('style') + "#";
            });
            $('.txtOtherComponentData').val(otherComponentData);
        }
    </script>
</asp:Content>