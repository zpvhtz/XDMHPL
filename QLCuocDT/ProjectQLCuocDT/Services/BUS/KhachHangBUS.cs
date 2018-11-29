using Services.Database;
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
    }
}
