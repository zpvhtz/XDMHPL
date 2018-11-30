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
                                                PhiCuocGoi = cg.PhiCuocGoi,
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
            cuocgoi.PhiCuocGoi = 0;
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

        public List<CuocGoi> SearchCuocGoi(string search)
        {
            List<CuocGoi> list = db.CuocGois.Where(c => c.MaCuocGoi.ToString().Contains(search) ||
                                                        c.MaSim.ToString().Contains(search) ||
                                                        c.Sim.SoSim.Contains(search))
                                            .ToList();
            return list;
        }

        public List<CuocGoiModel> FilterCuocGoi(string filteritem, string filter, DateTime? tgbdgoi, DateTime? tgktgoi, int sophutmin, int sophutmax, decimal phicuocgoimin, decimal phicuocgoimax)
        {
            List<CuocGoiModel> list = new List<CuocGoiModel>();
            switch(filteritem)
            {
                case "Thời gian gọi":
                    list = db.CuocGois.Where(cg => cg.TG_BatDau >= tgbdgoi && cg.TG_BatDau <= tgktgoi && cg.TG_KetThuc >= tgbdgoi && cg.TG_KetThuc <= tgktgoi)
                                      .Select(cg => new CuocGoiModel
                                      {
                                          MaCuocGoi = cg.MaCuocGoi,
                                          MaSim = cg.MaSim,
                                          TG_BatDau = cg.TG_BatDau,
                                          TG_KetThuc = cg.TG_KetThuc,
                                          SoPhutSD = cg.SoPhutSD,
                                          PhiCuocGoi = cg.PhiCuocGoi,
                                          trangthai = cg.trangthai == true ? "Không khoá" : "Khoá"
                                      }).ToList();
                    break;
                case "Số phút gọi":
                    list = db.CuocGois.Where(cg => cg.SoPhutSD >= sophutmin && cg.SoPhutSD <= sophutmax)
                                      .Select(cg => new CuocGoiModel
                                      {
                                          MaCuocGoi = cg.MaCuocGoi,
                                          MaSim = cg.MaSim,
                                          TG_BatDau = cg.TG_BatDau,
                                          TG_KetThuc = cg.TG_KetThuc,
                                          SoPhutSD = cg.SoPhutSD,
                                          PhiCuocGoi = cg.PhiCuocGoi,
                                          trangthai = cg.trangthai == true ? "Không khoá" : "Khoá"
                                      }).ToList();
                    break;
                case "Phí cuộc gọi":
                    list = db.CuocGois.Where(cg => cg.PhiCuocGoi >= phicuocgoimin && cg.PhiCuocGoi <= phicuocgoimax)
                                      .Select(cg => new CuocGoiModel
                                      {
                                          MaCuocGoi = cg.MaCuocGoi,
                                          MaSim = cg.MaSim,
                                          TG_BatDau = cg.TG_BatDau,
                                          TG_KetThuc = cg.TG_KetThuc,
                                          SoPhutSD = cg.SoPhutSD,
                                          PhiCuocGoi = cg.PhiCuocGoi,
                                          trangthai = cg.trangthai == true ? "Không khoá" : "Khoá"
                                      }).ToList();
                    break;
                case "Tình trạng":
                    bool tinhtrang = filter == "Không khoá" ? true : false;
                    list = db.CuocGois.Where(cg => cg.trangthai == tinhtrang)
                                      .Select(cg => new CuocGoiModel
                                      {
                                          MaCuocGoi = cg.MaCuocGoi,
                                          MaSim = cg.MaSim,
                                          TG_BatDau = cg.TG_BatDau,
                                          TG_KetThuc = cg.TG_KetThuc,
                                          SoPhutSD = cg.SoPhutSD,
                                          PhiCuocGoi = cg.PhiCuocGoi,
                                          trangthai = cg.trangthai == true ? "Không khoá" : "Khoá"
                                      }).ToList();
                    break;
            }
            return list;
        }
    }
}
