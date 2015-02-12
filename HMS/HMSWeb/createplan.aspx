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

        .palleteComponent{
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
            min-height: 500px;
            min-width: 800px;
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

    <div>
    </div>


    <div id="planbuilder">
        <div id="pallete">
            <div class="draggableA palleteComponent"></div>
            <div class="draggableB palleteComponent"></div>
        </div>
        <div id="canvas">
        </div>
    </div>
    <input type="button" value="Save" onclick="save()" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <script src="js/jquery-1.11.2.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery.ui.rotatable.min.js"></script>
    <link type="text/css" rel="stylesheet" href="css/jquery.ui.rotatable.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#canvas').resizable();
            $(this).clone().appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
        });

        $('.draggableB').click(function () {
            $(this).clone().appendTo('#canvas').draggable({ containment: "#canvas" }).resizable({ containment: "#canvas" }).rotatable({ containment: "#canvas" });
        });
        });

        function save() {
            $("#canvas>.palleteComponent").each(function () {
                alert($(this).attr('style'));
                //$(this).attr('style', $(this).attr('style') + 'asdasd;');
            })
        }
    </script>
</asp:Content>