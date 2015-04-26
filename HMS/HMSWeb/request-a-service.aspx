<%@ Page Language="C#" AutoEventWireup="true" CodeFile="request-a-service.aspx.cs" Inherits="request_a_service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Request a service</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Blue Water Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="service-css/bootstrap.css" rel='stylesheet' type='text/css' />
    <link href="service-css/style.css" rel='stylesheet' type='text/css' />
    <script src="service-js/jquery-1.11.0.min.js"></script>
    <link href='http://fonts.googleapis.com/css?family=Exo:100,200,300,400,500,600,700,800,900,100italic,200italic,300italic,400italic,500italic,600italic,700italic,800italic,900italic' rel='stylesheet' type='text/css' />
    <!---- start-smoth-scrolling---->
    <script type="text/javascript" src="service-js/move-top.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
            });
        });
    </script>
    <!--start-smoth-scrolling-->

</head>
<body>
    <form runat="server">
        <!--start-list-->
        <div class="list">
            <div class="container">
                <div class="list-main">
                    <h3>SERVICES LIST</h3>
                </div>
                <div class="list-top">
                    <asp:Repeater OnItemDataBound="ServiceTypeRepeater_ItemDataBound" ID="ServiceTypeRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-md-3 list-left">
                                <img src='<%#Eval("Image") %>' alt="" />
                                <h4><%#Eval("Name") %></h4>
                                <ul style="list-style-type: none;">
                                    <asp:Repeater ID="ServiceRepeater" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="ServiceLinkButton" CommandArgument='<%#Eval("ServiceID") %>' OnClick="ServiceLinkButton_Click" runat="server"><img src='<%# Eval("Image") %>' alt=""><br /><%#Eval("Name") %></asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <!--end-list-->
    </form>
</body>
</html>
