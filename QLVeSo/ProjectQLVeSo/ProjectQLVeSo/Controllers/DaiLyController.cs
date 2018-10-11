using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectQLVeSo.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectQLVeSo.Controllers
{
    public class DaiLyController : Controller
    {
        private readonly QLVeSoContext context;
        public DaiLyController(QLVeSoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<DaiLy> list = context.DaiLy.ToList();
            return View(list);
        }

        public IActionResult Search(string txtSearch)
        {
            List<DaiLy> list = context.DaiLy.Where(dl => dl.Ten.Contains(txtSearch)).ToList();
            return View("Index", list);
        }

        public IActionResult Create(string macreate, string tencreate, string diachicreate, string dienthoaicreate)
        {
            DaiLy daily = new DaiLy();
            daily.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            daily.MaDaiLy = macreate;
            daily.Ten = tencreate;
            daily.DiaChi = diachicreate;
            daily.DienThoai = dienthoaicreate;
            daily.TinhTrang = "Không khoá";
            context.DaiLy.Add(daily);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ThongTin(string iddaily)
        {
            List<DangKy> list = context.DangKy.Where(dk => dk.IdDaiLy.ToString() == iddaily)
                                              .Include(dk => dk.IdDaiLyNavigation)
                                              .Include(dk => dk.IdLoaiVeSoNavigation)
                                              .OrderByDescending(dk => dk.NgayDangKy)
                                              .ToList();
            return PartialView("ThongTinVeSoPartialView", list);
        }
    }
}