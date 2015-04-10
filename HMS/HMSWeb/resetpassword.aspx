<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="resetpassword.aspx.cs" Inherits="resetpassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Reset Password</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/style_responsive.css" rel="stylesheet" />
    <link href="css/style_default.css" rel="stylesheet" id="style_color" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body id="login-body">
    <form id="form2" runat="server">
        <div class="login-header">
            <!-- BEGIN LOGO -->
            <div id="logo" class="center">
                <img src="img/logo.png" alt="logo" class="center" />
            </div>
            <!-- END LOGO -->
        </div>

        <div id="login">
            <!-- BEGIN RESET PASSWORD FORM -->
            <div id="loginform" class="form-vertical no-padding no-margin">
                <div class="control-wrap">
                    <h4 style="padding-left: 10px">Reset Password</h4>
                    <div class="control-group" style="padding-left: 10px">
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-key"></i></span>
                                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="span4" placeholder="New Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="control-group" style="padding-left: 10px">
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-key"></i></span>
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" CssClass="span4" placeholder="Confirm Password" runat="server"></asp:TextBox>
                            </div>
                            <div class="clearfix space5"></div>
                        </div>
                    </div>
                </div>

                <asp:Button ID="btnSubmit" ValidationGroup="First" runat="server" Text="Submit" CssClass="btn btn-block login-btn" OnClick="btnSubmit_Click" />
            </div>
            <!-- END RESET PASSWORD FORM -->
        </div>

        <asp:PlaceHolder ID="errorMessagePlaceHolder" Visible="false" runat="server">
            <script type="text/javascript">
                alert("Please re-enter the details...!!");
            </script>
        </asp:PlaceHolder>
        <!-- BEGIN COPYRIGHT -->
        <div id="login-copyright">
            2015 &copy; Host of the most.
        </div>
        <!-- END COPYRIGHT -->

        <!-- BEGIN JAVASCRIPTS -->
        <script src="js/jquery-1.8.3.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="js/jquery.blockui.js"></script>
        <script src="js/scripts.js"></script>
        <script>
            jQuery(document).ready(function () {
                App.initLogin();
            });
        </script>
        <!-- END JAVASCRIPTS -->
    </form>
</body>
<!-- END BODY -->
</html>

