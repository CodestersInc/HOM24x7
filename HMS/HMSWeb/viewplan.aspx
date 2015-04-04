<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewplan.aspx.cs" Inherits="viewplan" %>

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
                    <li><a href="viewplan.aspx">View</a><span class="divider-last">&nbsp;</span></li>
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
                                    <input id="btnAddOtherComponentToCanvas" class="btn-primary" type="button" value="Add other component" />
                                </div>
                            </div>

                            <!--START PLAN BUILDER-->
                            <!--START PALLETTE-->
                            <asp:PlaceHolder ID="palettePlaceHolder" runat="server">
                                <div class="widget palette" style="padding-left: 5px; display: none">
                                    <div class="widget-title">
                                        <h4><i class="icon-reorder"></i>Pallete (Click on the component to add to canvas)</h4>
                                        <span class="tools">
                                            <a href="javascript:;" class="icon-chevron-down"></a>
                                            <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                                    </div>

                                    <div class="widget-body" style="min-height: 80px">
                                        <asp:Repeater ID="componentRepeater" runat="server">
                                            <ItemTemplate>
                                                <div class="paletteComponent" style='<%# "background-image:url("+Eval("Image")+");background-repeat:no-repeat;background-size:contain;width:70px;height:70px;" %>'' componentid='<%# Eval("ComponentID") %>'>
                                                    <%--<asp:Image ID="Image1" ImageUrl='<%# Eval("Image") %>' runat="server" />--%>
                                                </div>
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
                            <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" />
                        </div>
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
            </div>
            <asp:TextBox ID="txtPlanData" CssClass="txtPlanData" style="display:none" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtRoomComponentData" CssClass="txtRoomComponentData" style="display:none" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtOtherComponentData" CssClass="txtOtherComponentData" style="display:none" runat="server"></asp:TextBox>
            <!-- END PAGE CONTAINER-->
    </div>
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

            <%--Hide AddRoomTOCanvas button if no rooms--%>
            var x = document.getElementById("roomList");
            if (x.length == 0) {
                $('#btnAddRoomToCanvas').hide();
            }
        });
    </script>

    <%--Add rooms to canvas--%>
    <script type="text/javascript">
        $('#btnAddRoomToCanvas').click(function () {
            var x = document.getElementById("roomList");

            if (x.length != 0) {
                $("<div class='room' style= 'width: 50px; height: 50px; background-color: gray; text-align: left; vertical-align: middle; color: white;'></div>").prependTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" }).attr("roomid", $("#roomList").val());
                x.remove(x.selectedIndex);
                if (x.length == 0)
                    $('#btnAddRoomToCanvas').hide();
            }
        });
    </script>

    <%--Add other components to canvas--%>
    <script type="text/javascript">
        $('#btnAddOtherComponentToCanvas').click(function () {
            $('.palette').show();
            $('#btnAddOtherComponentToCanvas').hide();
        });

        $('.paletteComponent').click(function () {
            $(this).clone().prependTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" }).addClass('otherComponent').removeClass('paletteComponent');            
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
