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
            return stt + 1;
        }

        public string GetMaMoiNhat()
        {
            LoaiCuoc loaicuoc = db.LoaiCuocs.OrderByDescending(lc => lc.MaLoaiCuoc.Substring(3)).FirstOrDefault();
            string maloaicuoc = loaicuoc.MaLoaiCuoc;
            int mamoinhat = int.Parse(maloaicuoc.Substring(maloaicuoc.IndexOf('-') + 1));
            mamoinhat += 1;
            maloaicuoc = "LC-" + mamoinhat.ToString();
            return maloaicuoc;
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

        public List<LoaiCuocModel> FilterLoaiCuoc(string filteritem, string filter, DateTime? ngaybdapdung, DateTime? ngayktapdung, decimal giacuocmin, decimal giacuocmax)
        {
            List<LoaiCuocModel> list = new List<LoaiCuocModel>();
            switch(filteritem)
            {
                case "Ngày áp dụng":
                    list = db.LoaiCuocs.Where(lc => lc.NgayApdung >= ngaybdapdung && lc.NgayApdung <= ngayktapdung)
                                       .Select(lc => new LoaiCuocModel
                                       {
                                           STT = lc.STT,
                                           MaLoaiCuoc = lc.MaLoaiCuoc,
                                           TG_BatDau = lc.TG_BatDau,
                                           TG_KetThuc = lc.TG_KetThuc,
                                           NgayApdung = lc.NgayApdung,
                                           GiaCuoc = lc.GiaCuoc,
                                           Status = lc.Status == true ? "Không khoá" : "Khoá"
                                       }).ToList();
                    break;
                case "Giá cước":
                    list = db.LoaiCuocs.Where(lc => lc.GiaCuoc >= giacuocmin && lc.GiaCuoc <= giacuocmax)
                                       .Select(lc => new LoaiCuocModel
                                       {
                                           STT = lc.STT,
                                           MaLoaiCuoc = lc.MaLoaiCuoc,
                                           TG_BatDau = lc.TG_BatDau,
                                           TG_KetThuc = lc.TG_KetThuc,
                                           NgayApdung = lc.NgayApdung,
                                           GiaCuoc = lc.GiaCuoc,
                                           Status = lc.Status == true ? "Không khoá" : "Khoá"
                                       }).ToList();
                    break;
                case "Tình trạng":
                    bool tinhtrang = filter == "Không khoá" ? true : false;
                    list = db.LoaiCuocs.Where(lc => lc.Status == tinhtrang)
                                       .Select(lc => new LoaiCuocModel
                                       {
                                           STT = lc.STT,
                                           MaLoaiCuoc = lc.MaLoaiCuoc,
                                           TG_BatDau = lc.TG_BatDau,
                                           TG_KetThuc = lc.TG_KetThuc,
                                           NgayApdung = lc.NgayApdung,
                                           GiaCuoc = lc.GiaCuoc,
                                           Status = lc.Status == true ? "Không khoá" : "Khoá"
                                       }).ToList();
                    break;
            }
            return list;
        }
    }
}
