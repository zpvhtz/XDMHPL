using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLVeSo.Models;

namespace ProjectQLVeSo.Controllers
{
    public class PhanPhoiController : Controller
    {
        private readonly QlVeSoContext context;
        public PhanPhoiController(QlVeSoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<PhanPhoi> list = context.PhanPhoi.OrderBy(pp => pp.Id).ToList();
            return View(list);
        }

        public IActionResult Search(string txtSearch)
        {
            List<PhanPhoi> list = context.PhanPhoi.Where(pp => pp.Id.ToString().Contains(txtSearch)
                                                            || pp.IdDaiLyNavigation.Ten.Contains(txtSearch)
                                                            || pp.IdVeSoNavigation.Tinh.Contains(txtSearch))
                                                  .ToList();
            return View("Index", list);
        }

        public IActionResult AdvancedSearch(string id_search, string daily_search, string veso_search, int slgiao_search, int slban_search, DateTime ngaybd_search, DateTime ngaykt_search)
        {
            List<PhanPhoi> list = new List<PhanPhoi>();
            if(id_search != null)
            {
                list = context.PhanPhoi.Where(pp => pp.Id.ToString().Contains(id_search)).ToList();
            }
            if(daily_search != null)
            {
                list = context.PhanPhoi.Where(pp => pp.IdDaiLyNavigation.Ten.Contains(daily_search)).ToList();
            }
            if(veso_search != null)
            {
                list = context.PhanPhoi.Where(pp => pp.IdVeSoNavigation.Tinh.Contains(veso_search)).ToList();
            }
            if(slgiao_search > 0)
            {
                list = context.PhanPhoi.Where(pp => pp.SoLuongGiao == slgiao_search).ToList();
            }
            if(slban_search > 0)
            {
                list = context.PhanPhoi.Where(pp => pp.SoLuongBan == slban_search).ToList();
            }
            if(ngaybd_search.Date != DateTime.Parse("1/1/0001"))
            {
                if(ngaykt_search != DateTime.Parse("1/1/0001"))
                {
                    list = context.PhanPhoi.Where(pp => pp.Ngay.Value >= ngaybd_search && pp.Ngay.Value <= ngaykt_search).ToList();
                }
                else
                {
                    list = context.PhanPhoi.Where(pp => pp.Ngay.Value >= ngaybd_search).ToList();
                }                
            }
            else
            {
                if(ngaykt_search != DateTime.Parse("1/1/0001"))
                {
                    list = context.PhanPhoi.Where(pp => pp.Ngay.Value <= ngaykt_search).ToList();
                }
            }
            return View("Index", list);
        }
    }
}