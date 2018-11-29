<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="jumbotron">
        <h1>ASP.NET</h1>
    </div>--%>
    <div class="row">
        <h3>Thông tin sử dụng</h3>
        <div>
            <asp:TextBox ID="Date" runat="server"></asp:TextBox>
            <script type="text/javascript">
                var picker = new Pikaday(
                    {
                        field: document.getElementById('Date'),
                        firstDay: 1,
                        minDate: new Date('2000-01-01'),
                        maxDate: new Date('2020-12-31'),
                        yearRange: [2000, 2020],
                        numberOfMonths: 3,
                        theme: 'dark-theme'
                    });
            </script>
        </div>
        <br />
        <asp:GridView ID="gvThongTinSuDung" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TGBD" HeaderText="Time Start" />
                <asp:BoundField DataField="TGKT" HeaderText="Time End" />
                <asp:BoundField DataField="SoPhutSD" HeaderText="Minutes" />
                <asp:BoundField DataField="PhiCuocGoi" HeaderText="Price" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
