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
                                    <input id="btnAddRoomToCanvas" class="btn-primary" type="button" value="Add room to plan" />
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
                            <div id="canvas" style="min-height: 400px; min-width: 400px; padding: 5px; border-style: solid; border-width: 1px; margin: 5px; border: dashed;"></div>
                            <!--END CANVAS-->
                            <!-- END PLAN BUILDER-->

                            <div class="form-actions">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClientClick="savePlanData()" OnClick="btnSubmit_Click" />
                                <span></span>
                                <asp:Button ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>

                            <asp:TextBox ID="txtPlanData" CssClass="txtPlanData" Style="display: none" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtRoomComponentData" CssClass="txtRoomComponentData" Style="display: none" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtOtherComponentData" CssClass="txtOtherComponentData" Style="display: none" runat="server"></asp:TextBox>
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

    <%--Manage plan components on document load--%>
    <script type="text/javascript">
        $(document).ready(function () {
            <%--Making canvas resizable--%>
            $('#canvas').resizable();

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
            $(this).clone().prependTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" }).removeClass('paletteComponent').addClass('otherComponent');
        });
    </script>

    <%--Grabbing css of plan, plan components and other components--%>
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
