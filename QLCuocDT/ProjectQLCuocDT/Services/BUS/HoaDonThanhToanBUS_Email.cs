using Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services.BUS
{
    public partial class HoaDonThanhToanBUS
    {
        public async Task<string> ActivationMail()
        {
            //int month = DateTime.Now.Month;
            //int year = DateTime.Now.Year;

            //List<HoaDonThanhToan> listhoadonthanhtoan = db.HoaDonThanhToans.Where(hd => hd.ThanhToan == false && hd.NgayHD.Month < month && hd.NgayHD.Year <= year).ToList();

            //foreach (var item in listhoadonthanhtoan)
            //{
            //    KhachHang khachhang = new KhachHang();
            //    khachhang = db.KhachHangs.Where(kh => kh.MaKH == item.MaKH).SingleOrDefault();

            //    string thongbao = "Khách hàng vui lòng liên hệ và thanh toán hoá đơn cho thuê bao " + item.Sim.SoSim + " trong vòng 3 ngày trước khi bị khoá \n";

            //    var client = new SmtpClient
            //    {
            //        Host = "smtp.gmail.com",
            //        Port = 587,
            //        EnableSsl = true,
            //        UseDefaultCredentials = false,
            //        Credentials = new NetworkCredential("snkrxemail@gmail.com", "1234@abcd")
            //    };

            //    using (var message = new MailMessage("snkrxemail@gmail.com", taikhoan.Email)
            //    {
            //        Subject = "Email kích hoạt tài khoản",
            //        Body = thongbao,
            //        Priority = MailPriority.High,
            //        BodyEncoding = Encoding.UTF8
            //    })
            //    {
            //        await client.SendMailAsync(message);
            //    }
            //}
            return "Đã gửi email";
        }
    }
}
