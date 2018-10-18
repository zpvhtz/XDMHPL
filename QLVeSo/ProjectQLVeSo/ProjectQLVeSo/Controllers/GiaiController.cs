using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Giai> list = context.Giai.OrderBy(g => g.MaGiai).ToList();
            List<KetQuaChung> listkqc = context.KetQuaChung.Include(kqc => kqc.IdLoaiVeSoNavigation).ToList();
            List<LoaiVeSo> listlvs = context.LoaiVeSo.OrderBy(lvs => lvs.Tinh).ToList();
            ViewBag.KetQuaChung = listkqc;
            ViewBag.LoaiVeSo = listlvs;
            return View(list);
        }

        public IActionResult CreateGiai(string macreate, string tencreate, int soluongcreate, float giaithuongcreate)
        {
            string thongbao = "";
            Giai giai;
            giai = context.Giai.Where(g => g.MaGiai == macreate).SingleOrDefault();
            if(giai == null)
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
            else
            {
                thongbao = "Mã giải bị trùng";
            }
            return RedirectToAction("Index", "Giai", new { thongbao = thongbao });
        }

        public IActionResult EditGiai(string maedit, string tenedit, int soluongedit, float giaithuongedit)
        {
            Giai giai = context.Giai.Where(g => g.MaGiai == maedit).SingleOrDefault();
            giai.TenGiai = tenedit;
            giai.SoLuong = soluongedit;
            giai.GiaiThuong = giaithuongedit;
            context.SaveChanges();
            string thongbao = "Sửa thành công";
            return RedirectToAction("Index", "Giai", new { thongbao = thongbao });
        }

        public IActionResult ThongTinGiai(string ma)
        {
            Giai giai = context.Giai.Where(g => g.MaGiai == ma).SingleOrDefault();
            return PartialView("ThongTinGiaiPartialView", giai);
        }
    }
}