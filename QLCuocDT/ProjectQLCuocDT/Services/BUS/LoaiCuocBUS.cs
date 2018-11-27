using Services.Database;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BUS
{
    public class LoaiCuocBUS
    {
        private QLCuocDTEntities db = new QLCuocDTEntities();
        
        public List<LoaiCuocModel> GetLoaiCuocs()
        {
            return db.LoaiCuocs.Select(lc => new LoaiCuocModel
                                            {
                                                STT = lc.STT,
                                                MaLoaiCuoc = lc.MaLoaiCuoc,
                                                TG_BatDau = lc.TG_BatDau,
                                                TG_KetThuc = lc.TG_KetThuc,
                                                NgayApdung = lc.NgayApdung,
                                                GiaCuoc = lc.GiaCuoc,
                                                Status = lc.Status == true ? "Không khoá" : "Khoá"
                                            }).ToList();
        }

        public int GetSTT()
        {
            LoaiCuoc loaicuoc = db.LoaiCuocs.OrderByDescending(lc => lc.STT).FirstOrDefault();
            int stt = loaicuoc.STT;
            return stt++;
        }

        public string AddLoaiCuoc(int stt, string maloaicuoc, TimeSpan tgbd, TimeSpan tgkt, DateTime ngayapdung, decimal giacuoc)
        {
            LoaiCuoc loaicuoc = new LoaiCuoc();
            //Kiểm tra
            loaicuoc = db.LoaiCuocs.Where(lc => lc.MaLoaiCuoc == maloaicuoc).SingleOrDefault();
            if(loaicuoc != null)
            {
                return "Trùng mã loại cước";
            }
            //Thêm
            loaicuoc = new LoaiCuoc();
            loaicuoc.STT = stt;
            loaicuoc.MaLoaiCuoc = maloaicuoc;
            loaicuoc.TG_BatDau = tgbd;
            loaicuoc.TG_KetThuc = tgkt;
            loaicuoc.NgayApdung = ngayapdung;
            loaicuoc.GiaCuoc = giacuoc;
            loaicuoc.Status = true;
            db.LoaiCuocs.Add(loaicuoc);
            db.SaveChanges();
            return "Thêm thành công";
        }

        public string EditLoaiCuoc(string maloaicuoc, TimeSpan tgbd, TimeSpan tgkt, DateTime ngayapdung, decimal giacuoc, bool tinhtrang)
        {
            LoaiCuoc loaicuoc = db.LoaiCuocs.Where(lc => lc.MaLoaiCuoc == maloaicuoc).SingleOrDefault();
            loaicuoc.TG_BatDau = tgbd;
            loaicuoc.TG_KetThuc = tgkt;
            loaicuoc.NgayApdung = ngayapdung;
            loaicuoc.GiaCuoc = giacuoc;
            loaicuoc.Status = tinhtrang;
            db.SaveChanges();
            return "Sửa thành công";
        }

        public List<LoaiCuoc> SearchLoaiCuoc(string search)
        {
            List<LoaiCuoc> list = db.LoaiCuocs.Where(lc => lc.MaLoaiCuoc.Contains(search) ||
                                                           lc.GiaCuoc.ToString().Contains(search))
                                              .ToList();
            return list;
        }
    }
}
