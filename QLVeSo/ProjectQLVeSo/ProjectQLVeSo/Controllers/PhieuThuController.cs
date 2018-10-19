using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectQLVeSo.Models;

namespace ProjectQLVeSo.Controllers
{
    public class PhieuThuController : Controller
    {
        private readonly QLVeSoContext context;
        const int pageSize = 10;
        int pageNumber = 1;
        public PhieuThuController(QLVeSoContext context)
        {
            this.context = context;
        }

        public int TongSoTrang()
        {
            List<PhieuThu> list = context.PhieuThu.ToList();
            return ((list.Count / pageSize) + 1);
        }

        // GET: PhieuThu
        public IActionResult Index(string thongbao, int? pagenumber)
        {
            if (thongbao != null)
                ViewBag.ThongBao = thongbao;
            pageNumber = pagenumber ?? 1;
            List<PhieuThu> dsPhieuThu = context.PhieuThu.OrderBy(pt => pt.MaPhieuThu).Include(pt => pt.IdDaiLyNavigation).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            ViewBag.TongTrang = TongSoTrang();
            ViewBag.TrangHienTai = pageNumber;
            //Công nợ
            var dsCongNo = context.CongNo.Join(context.DaiLy, a => a.IdDaiLy, b => b.Id, (a,b) => new
            {
                MaDaiLy = b.MaDaiLy,
                TongTien = a.TongTien
            })
            .GroupBy(cn => cn.MaDaiLy)
            .Select(cn => new { MaDaiLy = cn.Key, TongTien = cn.Sum(tt => tt.TongTien) }).ToList();
            ViewBag.CongNo = dsCongNo;
            //Bảng phụ cho công nợ
            List<DaiLy> dsDaiLy = context.DaiLy.ToList();
            ViewBag.DaiLy = dsDaiLy;
            return View(dsPhieuThu);
        }

        // GET: PhieuThu/Details/5
        public ActionResult Search(string key)
        {
            List<PhieuThu> list = context.PhieuThu.Where(pt => pt.IdDaiLyNavigation.Ten.Contains(key)).Include(pt => pt.IdDaiLyNavigation).ToList();
            return View("Index", list);
        }

        // GET: PhieuThu/Create
        public IActionResult Create(string maphieuthu, string madaily, double tongtien)
        {
            //Thông báo
            string thongbao = "";
            //Kiểm tra mã có trùng chưa
            PhieuThu pt = context.PhieuThu.Where(p => p.MaPhieuThu == maphieuthu).FirstOrDefault();
            DaiLy daily = context.DaiLy.Where(p => p.MaDaiLy == madaily).SingleOrDefault();
            if (pt == null)
            {
                PhieuThu ptnew = new PhieuThu();
                ptnew.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
                ptnew.MaPhieuThu = maphieuthu;
                ptnew.IdDaiLy = daily.Id;
                ptnew.Ngay = DateTime.Now;
                ptnew.TongTien = tongtien;
                context.PhieuThu.Add(ptnew);
                context.SaveChanges();
                thongbao = "Thêm thành công";
            }
            else
            {
                thongbao = "Mã bị trùng";
            }
            return RedirectToAction("Index", "PhieuThu", new { thongbao = thongbao });
        }

        // GET: PhieuThu/Edit/5
        public IActionResult Edit(string maphieuthu, string madaily, DateTime ngaythu, double tongtien)
        {
            //Thông báo
            string thongbao = "";
            //Sửa
            PhieuThu pt = context.PhieuThu.Where(p => p.MaPhieuThu == maphieuthu).SingleOrDefault();
            DaiLy daily = context.DaiLy.Where(p => p.MaDaiLy == madaily).SingleOrDefault();
            pt.MaPhieuThu = maphieuthu;
            pt.IdDaiLy = daily.Id;
            pt.Ngay = ngaythu;
            pt.TongTien = tongtien;
            context.SaveChanges();
            thongbao = "Sửa thành công";
            return RedirectToAction("Index", "PhieuThu", new { thongbao = thongbao });
        }

        public IActionResult ThongTinCongNo(string ma)
        {
            List<CongNo> dsCongNo = context.CongNo.Where(cn => cn.IdDaiLyNavigation.MaDaiLy == ma)
                                                  .Include(cn => cn.IdDaiLyNavigation)
                                                  .ToList();
            return PartialView("ChiTietCongNoPartialView", dsCongNo);
        }
    }
}