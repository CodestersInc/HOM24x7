<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login page</title>
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
        <asp:PlaceHolder ID="errorMessagePlaceHolder" runat="server">
        <script type="text/javascript">
            alert("Invalid username or password...!!");
        </script>
            </asp:PlaceHolder>
        <!-- BEGIN LOGIN -->
        <div id="login">
            <!-- BEGIN LOGIN FORM -->
            <div id="loginform" class="form-vertical no-padding no-margin">
                <div class="lock">
                    <i class="icon-lock"></i>
                </div>
                <div class="control-wrap">
                    <h4>User Login</h4>
                    <div class="control-group">
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-user"></i></span>
                                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-key"></i></span>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                            <div class="mtop10">
                                <div class="block-hint pull-left small">
                                    <asp:CheckBox ID="cbxRemember" runat="server" />
                                    Remember Me
                                </div>
                                <div class="block-hint pull-right">
                                    <a href="javascript:;" class="" id="forget-password">Forgot Password?</a>
                                </div>
                            </div>
                            <div class="clearfix space5"></div>
                        </div>
                    </div>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-block login-btn" OnClick="btnLogin_Click" />
            </div>
            <!-- END LOGIN FORM -->
            <!-- BEGIN FORGOT PASSWORD FORM -->
            <div id="forgotform" class="form-vertical no-padding no-margin hide">
                <p class="center">Enter your e-mail address below to reset your password.</p>
                <div class="control-group">
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-envelope"></i></span>
                            <asp:TextBox ID="txtEmail" CssClass="input-email" runat="server" placeHolder="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="space20"></div>
                </div>
                <asp:Button ID="btnSubmitEmail" CssClass="btn btn-block login-btn" runat="server" Text="Submit" OnClick="forgotPassword"/>
            </div>
            <!-- END FORGOT PASSWORD FORM -->
        </div>
        <!-- END LOGIN -->
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
