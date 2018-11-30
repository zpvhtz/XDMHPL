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
    public partial class HoaDonThanhToanBUS
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

        public List<HoaDonThanhToanModel> FilterHoaDonThanhToan(string filteritem, string filter, DateTime? ngaybdtao, DateTime? ngaykttao, decimal thanhtienmin, decimal thanhtienmax)
        {
            List<HoaDonThanhToanModel> list = new List<HoaDonThanhToanModel>();
            switch(filteritem)
            {
                case "Thành tiền":
                    list = db.HoaDonThanhToans.Where(hd => hd.ThanhTien >= thanhtienmin && hd.ThanhTien <= thanhtienmax)
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
                    break;
                case "Ngày tạo":
                    list = db.HoaDonThanhToans.Where(hd => hd.NgayHD >= ngaybdtao && hd.NgayHD <= ngaykttao)
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
                    break;
                case "Thanh toán":
                    bool thanhtoan = filter == "Chưa thanh toán" ? false : true;
                    list = db.HoaDonThanhToans.Where(hd => hd.ThanhToan == thanhtoan)
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
                    break;
                case "Tình trạng":
                    bool tinhtrang = filter == "Không khoá" ? true : false;
                    list = db.HoaDonThanhToans.Where(hd => hd.Status == tinhtrang)
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
                    break;
            }
            return list;
        }
    }
}
