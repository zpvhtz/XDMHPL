using Services.Database;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BUS
{
    public class KhachHangBUS
    {
        private QLCuocDTEntities db = new QLCuocDTEntities();


        public List<KhachhangModel>ListKhachhang()
        {
            return db.KhachHangs.Select(model => new KhachhangModel
            {
                MaKH = model.MaKH,
                TenKH = model.TenKH,
                Diachi = model.DiaChi,
                Nghenghiep = model.NgheNghiep,
                CMND = model.CMND,
                Email = model.Email,
                Status = model.Status == true ? "Không khoá" : "Khoá"
            }).ToList();
        }
        public int GetMaKH()
        {
            KhachHang khachhang = db.KhachHangs.OrderByDescending(kh => kh.MaKH).FirstOrDefault();
            if (khachhang == null)
            {
                return 1;
            }
            else
            {
                return khachhang.MaKH + 1;
            }
        }

        public string AddKhachHang(int makh, string tenkh, string cmnd, string diachi)
        {
            KhachHang khachhang = new KhachHang();
            //Kiểm tra
            khachhang = db.KhachHangs.Where(kh => kh.MaKH == makh).SingleOrDefault();
            if (khachhang != null)
            {
                return "Trùng mã khách hàng";
            }
            //Thêm
            khachhang = new KhachHang();
            khachhang.MaKH = makh;
            khachhang.TenKH = tenkh;
            khachhang.CMND = cmnd;
            khachhang.DiaChi = diachi;
            khachhang.Status = true;
            db.KhachHangs.Add(khachhang);
            db.SaveChanges();
            return "Thêm thành công";
        }

        public bool CheckExistKH(int makh)
        {
            KhachHang khachhang = new KhachHang();
            khachhang = db.KhachHangs.Where(kh => kh.MaKH == makh).SingleOrDefault();
            if (khachhang != null)
                return false;
            return true;
        }
        public bool suaKH(KhachHang entity)
        {
            var res = db.KhachHangs.Find(entity.MaKH);
            res.MaKH = entity.MaKH;
            res.TenKH = entity.TenKH;
            res.CMND = entity.CMND;
            res.NgheNghiep = entity.NgheNghiep;
            res.DiaChi = entity.DiaChi;
            res.Email = entity.Email;
            res.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public List<KhachhangModel> SearchKhachhang(string search)
        {
            return db.KhachHangs.Where(model => model.MaKH.ToString().Contains(search) ||
                                                   model.TenKH.ToString().Contains(search) ||
                                                   model.DiaChi.ToString().Contains(search) ||
                                                   model.CMND.ToString().Contains(search) ||
                                                   model.NgheNghiep.Contains(search) ||
                                                   model.Email.ToString().Contains(search))
                                      .Select(model => new KhachhangModel
                                      {
                                         MaKH = model.MaKH,
                                         TenKH = model.TenKH,
                                         CMND = model.CMND,
                                         Nghenghiep = model.NgheNghiep,
                                         Diachi = model.DiaChi,
                                         Email = model.Email,
                                         Status = model.Status == true ? "Không khoá" : "Khoá"
                                      })
                                       .ToList();
        }
    }
}
