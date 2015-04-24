<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="receptionisthome.aspx.cs" Inherits="receptionisthome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <asp:PlaceHolder ID="planBuilderPlaceHolder" runat="server">
            <!-- BEGIN SAMPLE FORM widget-->
            <div class="widget">
                <div class="widget-body form">
                    <!-- BEGIN FORM-->
                    <div>
                        <div class="form-horizontal">
                            <div id="canvas" runat="server">                                
                                <!--START CANVAS-->
                                <%--                            <asp:Repeater ID="planCanvasRepeater" runat="server">
                                <ItemTemplate>
                                    <div id="canvas" style='<%# Eval("PlanStyle") %>'>
                                </ItemTemplate>
                            </asp:Repeater>--%>

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
                            </div>
                            <!--END CANVAS-->
                        </div>
                    </div>
                </div>
                <!-- END SAMPLE FORM widget-->
            </div>
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
            <%--Making plan components draggable, resizable, and rotatable--%>
            $("#canvas>.room, .otherComponent").each(function () {
                $(this).draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
            });            
        });
    </script>
</asp:Content>

