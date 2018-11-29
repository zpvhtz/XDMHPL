using Services.Database;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BUS
{
    public class SimBUS
    {
        private QLCuocDTEntities db = new QLCuocDTEntities();

        public List<SimModel> GetSims()
        {
            return db.Sims.Select(s => new SimModel
                                        {
                                            MaSim = s.MaSim,
                                            SoSim = s.SoSim,
                                            Status = s.Status == true ? "Đang sử dụng" : "Chưa sử dụng"
                                        }).ToList();
        }

        public int GetMaSim()
        {
            Sim sim = db.Sims.OrderByDescending(s => s.MaSim).FirstOrDefault();
            if (sim == null)
            {
                return 1;
            }
            else
            {
                return sim.MaSim + 1;
            }
        }

        public Sim GetSimByMaSim(int masim)
        {
            Sim sim = db.Sims.OrderByDescending(s => s.MaSim == masim).FirstOrDefault();
            return sim;
        }

        public string AddSim(int masim, string sosim, bool tinhtrang)
        {
            Sim sim = new Sim();
            //Kiểm tra
            sim = db.Sims.Where(s => s.MaSim == masim).SingleOrDefault();
            if (sim != null)
            {
                return "Trùng mã sim hãy bấm thêm mới để thêm";
            }
            sim = db.Sims.Where(s => s.SoSim == sosim).SingleOrDefault();
            if (sim != null)
            {
                return "Trùng số sim";
            }
            //Thêm
            sim = new Sim();
            sim.MaSim = masim;
            sim.SoSim = sosim;
            sim.Status = false;
            db.Sims.Add(sim);
            db.SaveChanges();
            return "Thêm thành công";
        }

        public string EditSim(int masim, string sosim, bool tinhtrang)
        {
            Sim sim = new Sim();
            //Kiểm tra
            sim = db.Sims.Where(s => s.SoSim == sosim).SingleOrDefault();
            if (sim != null)
            {
                if(sim.SoSim != sosim)
                    return "Số sim đã tồn tại";
            }
            //Sửa
            sim = db.Sims.Where(s => s.MaSim == masim).SingleOrDefault();
            sim.SoSim = sosim;
            sim.Status = tinhtrang;
            db.SaveChanges();
            return "Sửa thành công";
        }

        public List<Sim> SearchSim(string search)
        {
            List<Sim> listsim = db.Sims.Where(s => s.SoSim.Contains(search)).ToList();
            return listsim;
        }

        public int GetMaSimBySoSim(string sosim)
        {
            Sim sim = db.Sims.Where(s => s.SoSim == sosim).SingleOrDefault();
            return sim.MaSim;
        }

        public List<Sim> GetListSimByStatus(bool status)
        {
            List<Sim> list = db.Sims.Where(s => s.Status == status).ToList();
            return list;
        }

        public void EditStatusSim(int masim, bool status)
        {
            Sim sim = db.Sims.Where(s => s.MaSim == masim).SingleOrDefault();
            if(sim != null)
            {
                sim.Status = status;
                db.SaveChanges();
            }
        }
    }
}
