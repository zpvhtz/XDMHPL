using Services.Database;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BUS
{
    public class HoaDonThanhToanBUS
    {
        private QLCuocDTEntities db = new QLCuocDTEntities();

        public List<HoaDonThanhToanModel> GetHoaDonThanhToans()
        {
            return db.HoaDonThanhToans.Select(hd => new HoaDonThanhToanModel
                                                        {
                                                            MaHD = hd.MaHD,
                                                            TenKH = hd.KhachHang.TenKH,
                                                            SoSim = hd.Sim.SoSim,
                                                            CuocThueBao = hd.CuocThueBao,
                                                            NgayHD = hd.NgayHD,
                                                            ThanhToan = hd.ThanhToan == true ? "Đã thanh toán" : "Chưa thanh toán",
                                                            ThanhTien = hd.ThanhTien,
                                                            TinhTrang = hd.Status == true ? "Không khoá" : "Khoá"
                                                        })
                                       .ToList();
        }

        public string EditHoaDonThanhToan(string mahd, bool thanhtoan, bool tinhtrang)
        {
            HoaDonThanhToan hoadonthanhtoan = db.HoaDonThanhToans.Where(hd => hd.MaHD.ToString().Contains(mahd)).SingleOrDefault();
            hoadonthanhtoan.ThanhToan = thanhtoan;
            hoadonthanhtoan.Status = tinhtrang;
            db.SaveChanges();
            return "Sửa thành công";
        }

        public List<HoaDonThanhToanModel> SearchHoaDonThanhToan(string search)
        {
            return db.HoaDonThanhToans.Where(hd => hd.MaHD.ToString().Contains(search) ||
                                                   hd.MaKH.ToString().Contains(search) ||
                                                   hd.KhachHang.TenKH.Contains(search) ||
                                                   hd.MaSim.ToString().Contains(search) ||
                                                   hd.Sim.SoSim.Contains(search) ||
                                                   hd.ThanhTien.ToString().Contains(search))
                                      .Select(hd => new HoaDonThanhToanModel
                                                    {
                                                        MaHD = hd.MaHD,
                                                        TenKH = hd.KhachHang.TenKH,
                                                        SoSim = hd.Sim.SoSim,
                                                        CuocThueBao = hd.CuocThueBao,
                                                        NgayHD = hd.NgayHD,
                                                        ThanhToan = hd.ThanhToan == true ? "Đã thanh toán" : "Chưa thanh toán",
                                                        ThanhTien = hd.ThanhTien,
                                                        TinhTrang = hd.Status == true ? "Không khoá" : "Khoá"
                                                    })
                                       .ToList();
        }
    }
}
