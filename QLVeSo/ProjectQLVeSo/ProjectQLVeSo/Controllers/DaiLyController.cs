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

        public IActionResult Index(string thongbao)
        {
            if (thongbao != null)
                ViewBag.ThongBao = thongbao;
            List<DaiLy> list = context.DaiLy.ToList();
            return View(list);
        }

        public IActionResult Search(string txtSearch)
        {
            List<DaiLy> list = context.DaiLy.Where(dl => dl.Ten.Contains(txtSearch)).ToList();
            return View("Index", list);
        }

        public IActionResult CreateDaiLy(string macreate, string tencreate, string diachicreate, string dienthoaicreate)
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

        public IActionResult EditDaiLy(string maedit, string tenedit, string diachiedit, string dienthoaiedit, string tinhtrangedit)
        {
            DaiLy daily = context.DaiLy.Where(dl => dl.MaDaiLy == maedit).SingleOrDefault();
            daily.Ten = tenedit;
            daily.DiaChi = diachiedit;
            daily.DienThoai = dienthoaiedit;
            daily.TinhTrang = tinhtrangedit;
            context.SaveChanges();
            string thongbao = "Sửa thành công";
            return RedirectToAction("Index", "DaiLy", new { thongbao = thongbao });
        }

        public IActionResult ThongTinDangKy(string ma)
        {
            List<LoaiVeSo> list = context.LoaiVeSo.ToList();
            DaiLy daily = context.DaiLy.Where(dl => dl.MaDaiLy == ma).SingleOrDefault();
            ViewBag.ThongTinDaiLy = daily;
            return PartialView("DangKyPartialView", list);
        }

        public IActionResult CreateDangKy(string madailycreate, string idvesocreate, int soluongdangkycreate)
        {
            DaiLy daily = context.DaiLy.Where(dl => dl.MaDaiLy == madailycreate).SingleOrDefault();
            DangKy dangky = new DangKy();
            dangky.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            dangky.IdDaiLy = daily.Id;
            dangky.IdLoaiVeSo = Guid.Parse(idvesocreate.ToUpper());
            dangky.NgayDangKy = DateTime.Now;
            dangky.SoLuong = soluongdangkycreate;
            context.DangKy.Add(dangky);
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