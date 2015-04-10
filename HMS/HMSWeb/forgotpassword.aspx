<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotpassword.aspx.cs" Inherits="forgotpassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Forgot Password</title>
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

        <!-- BEGIN LOGIN -->
        <div id="login">
            <!-- BEGIN LOGIN FORM -->
            <div id="loginform" class="form-vertical no-padding no-margin">
                <p class="center">Enter your e-mail address below to reset your password.</p>
                <div class="control-group">
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-envelope"></i></span>
                            <asp:TextBox ID="txtEmail" CssClass="input-email span4" runat="server" placeHolder="Email"></asp:TextBox>                            
                        </div>
                    </div>
                    <asp:Label ID="errorLbl" Style="color: red; font-size:14px" runat="server"></asp:Label>
                    <div class="space20"></div>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-block login-btn" OnClick="btnSubmit_Click" />
            </div>
            <!-- END LOGIN FORM -->
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
