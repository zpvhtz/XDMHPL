<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartForm.aspx.cs" Inherits="StartFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Assets/css/Custom.css" rel="stylesheet"/>
</head>
<body class="main-background main-content">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-3">

                </div>
                <div class="col-lg-6">
                    <div class="panel panel-primary transparent-all full-rounded-form">
                        <div class="panel-heading text-center rounded-header">
                            <h3>THÔNG TIN CUỘC GỌI</h3>
                        </div>
                        <div class="panel-body center-content transparent-content rounded-form">
                            <div class="form-group">
                                <label for="labelPhoneNumber" class="white-header">SỐ ĐIỆN THOẠI</label>
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtPhoneNumber"></asp:TextBox>
                            </div>
                            <asp:Button runat="server" CssClass="btn btn-primary button-red" OnClick="btnCheckPhoneNumber_Click" ID="Button1" Text="Tìm kiếm" />
                            <br /><br />
                            <div class="row">
                                <div class="text-center text-danger">
                                    <asp:Label runat="server" ID="lblNotify" class="notification-paragraph" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">

                </div>
            </div>
        </div>
    </form>
</body>
</html>
