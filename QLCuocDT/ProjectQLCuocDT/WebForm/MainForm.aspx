<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainForm.aspx.cs" Inherits="testCalender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Assets/css/pikaday.css" rel="stylesheet" />
    <link href="Assets/css/site.css" rel="stylesheet" />
    <link href="Assets/css/theme.css" rel="stylesheet" />
    <link href="Assets/css/triangle.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Assets/js/pikaday.js"></script>
    <link href="Assets/css/Custom.css" rel="stylesheet"/>
</head>
<body class="main-background main-content">
    <form id="form1" runat="server">
        <div class="container">
            <div class="list-group">
                <div class="list-group-item remove-border transparent-background">
                    <div class="panel panel-primary half-rounded-form transparent-all">
                        <div class="panel-heading text-center rounded-header">
                            <h3><asp:Label runat="server" ID="lblnameCustomer"></asp:Label></h3>
                        </div>
                        <div class="panel-body black-background">
                            <div class="row text-center">
                                <div class="col-xs-5 col-md-6">
                                    <div class="form-group">
                                        <label for="label-sophut">Từ ngày</label>
                                        <asp:TextBox ID="FromDate" CssClass="form-control fix-input-margin" placeholder="Từ ngày" runat="server"></asp:TextBox>
                                        <script type="text/javascript">
                                            var pickerFrom = new Pikaday(
                                                {
                                                    field: document.getElementById('FromDate'),
                                                    firstDay: 1,
                                                    format: 'D/M/YYYY',
                                                    minDate: new Date('2000-01-01'),
                                                    maxDate: new Date('2020-12-31'),
                                                    yearRange: [2000, 2020],
                                                    numberOfMonths: 1,
                                                    theme: 'dark-theme',
                                                    toString(date, format) {
                                                        // you should do formatting based on the passed format,
                                                        // but we will just return 'D/M/YYYY' for simplicity
                                                        const day = date.getDate();
                                                        const month = date.getMonth() + 1;
                                                        const year = date.getFullYear();
                                                        return `${day}/${month}/${year}`;
                                                    },
                                                    parse(dateString, format) {
                                                        // dateString is the result of `toString` method
                                                        const parts = dateString.split('/');
                                                        const day = parseInt(parts[0], 10);
                                                        const month = parseInt(parts[1], 10) - 1;
                                                        const year = parseInt(parts[2], 10);
                                                        return new Date(year, month, day);
                                                    }
                                                });
                                        </script>
                                    </div>
                                </div>
                                <div class="col-xs-5 col-md-6">
                                    <div class="form-group">
                                        <label for="label-sophut">Đến ngày</label>
                                    <asp:TextBox ID="ToDate" CssClass="form-control fix-input-margin" placeholder="Đến ngày" runat="server"></asp:TextBox>
                                    <script type="text/javascript">
                                        var pickerTo = new Pikaday(
                                            {
                                                field: document.getElementById('ToDate'),
                                                firstDay: 1,
                                                format: 'D/M/YYYY',
                                                minDate: new Date('2000-01-01'),
                                                maxDate: new Date('2020-12-31'),
                                                yearRange: [2000, 2020],
                                                numberOfMonths: 1,
                                                theme: 'dark-theme',
                                                toString(date, format) {
                                                    // you should do formatting based on the passed format,
                                                    // but we will just return 'D/M/YYYY' for simplicity
                                                    const day = date.getDate();
                                                    const month = date.getMonth() + 1;
                                                    const year = date.getFullYear();
                                                    return `${day}/${month}/${year}`;
                                                },
                                                parse(dateString, format) {
                                                    // dateString is the result of `toString` method
                                                    const parts = dateString.split('/');
                                                    const day = parseInt(parts[0], 10);
                                                    const month = parseInt(parts[1], 10) - 1;
                                                    const year = parseInt(parts[2], 10);
                                                    return new Date(year, month, day);
                                                }
                                            });
                                    </script>
                                        </div>
                                </div>
                                <div class="col-xs-2  col-md-12">
                                    <asp:Button CssClass="btn btn-primary button-red button-small" runat="server" ID="Button1" OnClick="btnSearch_Click" Text="Tìm kiếm" Font-Size="Large" />
                                </div>
                            </div>
                            <%--<br />--%>
                            <%--<div class="row">
                                <div class="col-md-10">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="font-size: medium">Lọc:     </span>
                                        <asp:DropDownList runat="server" CssClass="dropdown form-control" ID="ddMonth" OnSelectedIndexChanged="ddMonth_SelectedIndexChanged">
                                            <asp:ListItem Text="1 tháng gần đây nhất" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="3 tháng gần đây nhất" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-2">
                                    <asp:Button CssClass="btn btn-primary button-red" runat="server" ID="btnSearchByMonth" OnClick="btnSearchByMonth_Click" Text="Tìm" Font-Size="Large" />
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-center text-danger notification-paragraph">
                            <asp:Label runat="server" ID="lblNotify" Text=""></asp:Label>
                        </div>
                    </div>
                    <asp:GridView CssClass="table table-bordered table-header table-border table-background" ID="gvThongTinSuDung" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TG_BatDau" HeaderText="Thời gian bắt đầu" />
                            <asp:BoundField DataField="TG_KetThuc" HeaderText="Thời gian kết thúc" />
                            <asp:BoundField DataField="SoPhutSD" HeaderText="Số phút sử dụng" />
                            <asp:BoundField DataField="PhiCuocGoi" HeaderText="Phí" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="list-group-item remove-border transparent-background" id="frmTong">
                    <div class="panel panel-default normal-border black-background">
                        <div class="panel-body remove-padding">
                            <div class="row align-items-center h-100">
                                <div class="panel-heading text-center normal-header normal-padding-header">
                                    <%--<h3><asp:Label runat="server" ID="Label1" Text="Tổng"></asp:Label></h3>--%>
                                    <h4>THỐNG KÊ</h4>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-4 text-center">
                                        <div class="form-group">
                                            <label for="label-sophut">Số phút</label>            
                                            <asp:TextBox CssClass="form-control" runat="server" ID="totalMinutes"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2"></div>
                                    <div class="col-md-4 text-center">
                                        <div class="form-group">
                                            <label for="label-tongtien">Tổng tiền</label>            
                                            <asp:TextBox CssClass="form-control" runat="server" ID="totalPrice"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        let frm = document.getElementById("frmTong");
        frm.style.display = "none";

        let rowcount = $("#gvThongTinSuDung tr").length;
        if (rowcount > 1)
            frm.style.display = "block";
    });

    $("#Button1").click(function () {
        let frm = document.getElementById("frmTong");
        frm.style.display = "block";
    });
</script>