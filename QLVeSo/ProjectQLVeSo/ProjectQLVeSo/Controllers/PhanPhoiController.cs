using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLVeSo.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectQLVeSo.Controllers
{
    public class PhanPhoiController : Controller
    {
        private readonly QLVeSoContext context;
        public PhanPhoiController(QLVeSoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<PhanPhoi> list = context.PhanPhoi.OrderBy(pp => pp.Id)
                                                  .Include(pp => pp.IdDaiLyNavigation)
                                                  .Include(pp => pp.IdLoaiVeSoNavigation)
                                                  .ToList();
            return View(list);
        }

        public IActionResult Search(string txtSearch)
        {
            List<PhanPhoi> list = context.PhanPhoi.Where(pp => pp.Id.ToString().Contains(txtSearch)
                                                            || pp.IdDaiLyNavigation.Ten.Contains(txtSearch)
                                                            || pp.IdLoaiVeSoNavigation.Tinh.Contains(txtSearch))
                                                  .Include(pp => pp.IdDaiLyNavigation)
                                                  .Include(pp => pp.IdLoaiVeSoNavigation)
                                                  .ToList();
            return View("Index", list);
        }

        public IActionResult AdvancedSearch(string id_search, string daily_search, string veso_search, int slgiao_search, int slban_search, DateTime ngaybd_search, DateTime ngaykt_search)
        {
            List<PhanPhoi> list = context.PhanPhoi.Include(pp => pp.IdDaiLyNavigation)
                                                  .Include(pp => pp.IdLoaiVeSoNavigation)
                                                  .ToList();
            if (id_search != null)
            {
                list = list.Where(pp => pp.Id.ToString().Contains(id_search)).ToList();
            }
            if(daily_search != null)
            {
                list = list.Where(pp => pp.IdDaiLyNavigation.Ten.Contains(daily_search)).ToList();
            }
            if(veso_search != null)
            {
                list = list.Where(pp => pp.IdLoaiVeSoNavigation.Tinh.Contains(veso_search)).ToList();
            }
            if(slgiao_search > 0)
            {
                list = list.Where(pp => pp.SoLuongGiao == slgiao_search).ToList();
            }
            if(slban_search > 0)
            {
                list = list.Where(pp => pp.SoLuongBan == slban_search).ToList();
            }
            if(ngaybd_search.Date != DateTime.Parse("1/1/0001"))
            {
                if(ngaykt_search != DateTime.Parse("1/1/0001"))
                {
                    list = list.Where(pp => pp.Ngay.Value >= ngaybd_search && pp.Ngay.Value <= ngaykt_search).ToList();
                }
                else
                {
                    list = list.Where(pp => pp.Ngay.Value >= ngaybd_search).ToList();
                }                
            }
            else
            {
                if(ngaykt_search != DateTime.Parse("1/1/0001"))
                {
                    list = list.Where(pp => pp.Ngay.Value <= ngaykt_search).ToList();
                }
            }
            return View("Index", list);
        }
    }
}