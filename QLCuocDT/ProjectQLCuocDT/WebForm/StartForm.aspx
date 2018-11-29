<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartForm.aspx.cs" Inherits="StartFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="panel panel-primary">
                <div class="panel-heading text-center">
                    <h3>Tra cứu thông tin cuộc gọi</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-11">
                            <div class="input-group">
                                <span class="input-group-addon">Số điện thoại</span>
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtPhoneNumber"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button runat="server" CssClass="btn btn-primary" OnClick="btnCheckPhoneNumber_Click" ID="btnCheckPhoneNumber" Text="Tra" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-center text-danger">
                            <asp:Label runat="server" ID="lblNotify" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
