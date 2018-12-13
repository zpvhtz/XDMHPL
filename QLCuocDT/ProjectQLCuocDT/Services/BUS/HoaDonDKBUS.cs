using Services.Models;
using Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BUS
{
    public class HoaDonDKBUS
    {
        private QLCuocDTEntities db = new QLCuocDTEntities();

        public List<HoaDonDKModel> GetHoaDonDKs()
        {
            List<HoaDonDKModel> list = db.HoaDonDKs.Select(hd => new HoaDonDKModel
                                            {
                                                MaHD = hd.MaHD,
                                                TenKH = hd.KhachHang.TenKH,
                                                CMND = hd.KhachHang.CMND,
                                                NgayDK = hd.NgayDK,
                                                ChiPhi = hd.ChiPhi,
                                                MaKH = hd.MaKH,
                                                MaSim = hd.MaSim,
                                                DiaChi = hd.KhachHang.DiaChi,
                                                Email = hd.KhachHang.Email
                                            }).ToList();
            return list;
        }

        public int GetMaHoaDon()
        {
            HoaDonDK hoadon = db.HoaDonDKs.OrderByDescending(hd => hd.MaHD).FirstOrDefault();
            if (hoadon == null)
            {
                return 1;
            }
            else
            {
                return hoadon.MaHD + 1;
            }
        }

        public string AddHoaDon(int mahd, int masim, DateTime ngaydk, decimal chiphi, int makh)
        {
            HoaDonDK hoadon = new HoaDonDK();
            //Kiểm tra
            hoadon = db.HoaDonDKs.Where(hd => hd.MaHD == mahd).SingleOrDefault();
            if (hoadon != null)
            {
                return "Trùng mã hóa đơn";
            }
            //Thêm
            hoadon = new HoaDonDK();
            hoadon.MaHD = mahd;
            hoadon.MaSim = masim;
            hoadon.NgayDK = ngaydk;
            hoadon.ChiPhi = chiphi;
            hoadon.MaKH = makh;
            db.HoaDonDKs.Add(hoadon);
            db.SaveChanges();
            return "Thêm thành công";
        }

        public HoaDonDK GetHoaDonDK(string sosim)
        {
            HoaDonDK hoadon = db.HoaDonDKs.Where(hd => hd.Sim.SoSim == sosim).SingleOrDefault();
            return hoadon;
        }
    }
}
