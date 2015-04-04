<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewplan.aspx.cs" Inherits="viewplan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
    <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
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
                                    <input id="btnAddToCanvas" class="btn-primary" type="button" value="Add to Plan" />
                                </div>
                            </div>

                            <!--START PLAN BUILDER-->
                            <asp:Repeater ID="planCanvasRepeater" runat="server">
                                <ItemTemplate>
                                    <div id="canvas" style='<%# Eval("PlanStyle") %>'>
                                </ItemTemplate>
                            </asp:Repeater>

                            <asp:Repeater ID="planComponentRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="room" roomid='<%# Eval("RoomID") %>' style='<%# Eval("PlanComponentStyle") %>'></div>
                                </ItemTemplate>
                            </asp:Repeater>
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
            <asp:TextBox ID="txtPlanData" CssClass="txtPlanData" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPlanComponentData" CssClass="txtPlanComponentData" runat="server"></asp:TextBox>
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
        $(document).ready(function () {
            $('#canvas').resizable();
            $("#canvas>.room").each(function () {
                $(this).draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
            });
        });
    </script>

    <script type="text/javascript">
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
