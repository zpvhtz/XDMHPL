using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectQLVeSo.Models;

namespace ProjectQLVeSo.Controllers
{
    public class GiaiController : Controller
    {
        private readonly QLVeSoContext context;
        public GiaiController(QLVeSoContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string thongbao)
        {
            if (thongbao != null)
                ViewBag.ThongBao = thongbao;
            List<Giai> list = context.Giai.OrderByDescending(g => g.TenGiai).ToList();
            return View(list);
        }

        public IActionResult Create(string macreate, string tencreate, int soluongcreate, float giaithuongcreate)
        {
            string thongbao = "";
            Giai giai;
            giai = context.Giai.Where(g => g.MaGiai == macreate).SingleOrDefault();
            if(giai == null)
            {
                thongbao = "Mã giải bị trùng";
            }
            else
            {
                giai = new Giai();
                giai.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
                giai.MaGiai = macreate;
                giai.TenGiai = tencreate;
                giai.SoLuong = soluongcreate;
                giai.GiaiThuong = giaithuongcreate;
                context.Giai.Add(giai);
                context.SaveChanges();
                thongbao = "Thêm thành công";
            }
            return RedirectToAction("Index", "Giai", new { thongbao = thongbao });
        }

        public IActionResult Edit(string maedit, string tenedit, int soluongedit, float giaithuongedit)
        {
            Giai giai = context.Giai.Where(g => g.MaGiai == maedit).SingleOrDefault();
            giai.TenGiai = tenedit;
            giai.SoLuong = soluongedit;
            giai.GiaiThuong = giaithuongedit;
            string thongbao = "Sửa thành công";
            return RedirectToAction("Index", "Giai", new { thongbao = thongbao });
        }
    }
}