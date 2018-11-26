using Services.Database;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BUS
{
    public class CuocGoiBUS
    {
        private QLCuocDTEntities db = new QLCuocDTEntities();

        public List<CuocGoiModel> GetCuocGois()
        {
            return db.CuocGois.Select(cg => new CuocGoiModel
                                            {
                                                MaCuocGoi = cg.MaCuocGoi,
                                                MaSim = cg.MaSim,
                                                TG_BatDau = cg.TG_BatDau,
                                                TG_KetThuc = cg.TG_KetThuc,
                                                SoPhutSD = cg.SoPhutSD,
                                                trangthai = cg.trangthai == true ? "Không khoá" : "Khoá"
                                            }).ToList();
        }

        public int GetMaCuocGoi()
        {
            CuocGoi cuocgoi = db.CuocGois.OrderByDescending(cg => cg.MaCuocGoi).FirstOrDefault();
            if(cuocgoi == null)
            {
                return 1;
            }
            else
            {
                return cuocgoi.MaCuocGoi + 1;
            }
        }

        public void AddCuocGoi(int macuocgoi, int masim, DateTime tgbd, DateTime tgkt, int sophutsd)
        {
            CuocGoi cuocgoi = new CuocGoi();
            cuocgoi.MaCuocGoi = macuocgoi;
            cuocgoi.MaSim = masim;
            cuocgoi.TG_BatDau = tgbd;
            cuocgoi.TG_KetThuc = tgkt;
            cuocgoi.SoPhutSD = sophutsd;
            cuocgoi.trangthai = true;
            db.CuocGois.Add(cuocgoi);
            db.SaveChanges();
        }

        public string EditCuocGoi(int macuocgoi, bool tinhtrang)
        {
            CuocGoi cuocgoi = db.CuocGois.Where(cg => cg.MaCuocGoi == macuocgoi).SingleOrDefault();
            cuocgoi.trangthai = tinhtrang;
            db.SaveChanges();
            return "Thay đổi thành công";
        }
    }
}
