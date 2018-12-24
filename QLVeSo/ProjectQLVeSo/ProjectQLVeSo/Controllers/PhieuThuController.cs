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
        const int pageSize = 20;
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

            var dsCongNo = context.CongNo.Where(cn => cn.IdDaiLyNavigation.Ten.Contains(key)).Include(cn => cn.IdDaiLyNavigation).Join(context.DaiLy, a => a.IdDaiLy, b => b.Id, (a, b) => new
            {
                MaDaiLy = b.MaDaiLy,
                TongTien = a.TongTien
            })
            .GroupBy(cn => cn.MaDaiLy)
            .Select(cn => new { MaDaiLy = cn.Key, TongTien = cn.Sum(tt => tt.TongTien) }).ToList();
            ViewBag.CongNo = dsCongNo;

            List<DaiLy> dsDaiLy = context.DaiLy.ToList();
            ViewBag.DaiLy = dsDaiLy;

            return View("Index", list);
        }

        // GET: PhieuThu/Create
        public IActionResult Create(string madaily, double tongtienno, double tongtienthu)
        {
            //Thông báo
            string thongbao = "";
            if(tongtienno < tongtienthu)
            {
                thongbao = "Tiền thu không lớn hơn tiền nợ";
                return RedirectToAction("Index", "PhieuThu", new { thongbao = thongbao });
            }
            //Kiểm tra mã có trùng chưa
            PhieuThu pt = context.PhieuThu.OrderByDescending(pthu => pthu.MaPhieuThu).FirstOrDefault();
            DaiLy daily = context.DaiLy.Where(p => p.MaDaiLy == madaily).SingleOrDefault();

            if (pt == null)
            {
                PhieuThu phieuthu = new PhieuThu();
                phieuthu.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
                phieuthu.MaPhieuThu = "PT1";
                phieuthu.IdDaiLy = daily.Id;
                phieuthu.Ngay = DateTime.Now;
                phieuthu.TongTien = tongtienthu;
                context.PhieuThu.Add(phieuthu);
                context.SaveChanges();
                thongbao = "Thêm thành công";
            }
            else
            {
                string maphieuthu = pt.MaPhieuThu;
                maphieuthu = maphieuthu.Substring(2);
                int newmaphieuthu = int.Parse(maphieuthu);
                newmaphieuthu += 1;
                maphieuthu = "PT" + newmaphieuthu.ToString();

                PhieuThu phieuthu = new PhieuThu();
                phieuthu.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
                phieuthu.MaPhieuThu = maphieuthu;
                phieuthu.IdDaiLy = daily.Id;
                phieuthu.Ngay = DateTime.Now;
                phieuthu.TongTien = tongtienthu;
                context.PhieuThu.Add(phieuthu);
                context.SaveChanges();
                thongbao = "Thêm thành công";
            }

            CongNo oldcongno = context.CongNo.OrderByDescending(cn => cn.MaCongNo).FirstOrDefault();
            string macongno = oldcongno.MaCongNo;
            macongno = macongno.Substring(2);
            int newmacongno = int.Parse(macongno);
            newmacongno += 1;
            macongno = "CN" + newmacongno.ToString();

            //Cập nhật lại công nợ
            CongNo congno = new CongNo();
            congno.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            congno.MaCongNo = macongno;
            congno.IdDaiLy = daily.Id;
            congno.Ngay = DateTime.Now;
            congno.TongTien = -(tongtienthu);

            context.CongNo.Add(congno);
            context.SaveChanges();

            return RedirectToAction("Index", "PhieuThu", new { thongbao = thongbao });
        }

        // GET: PhieuThu/Edit/5
        public IActionResult Edit(string maphieuthu, string madaily,/* DateTime ngaythu,*/ double tongtien)
        {
            //Thông báo
            string thongbao = "";
            //Sửa
            PhieuThu pt = context.PhieuThu.Where(p => p.MaPhieuThu == maphieuthu).SingleOrDefault();
            DaiLy daily = context.DaiLy.Where(p => p.MaDaiLy == madaily).SingleOrDefault();
            pt.MaPhieuThu = maphieuthu;
            pt.IdDaiLy = daily.Id;
            //pt.Ngay = ngaythu;
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
            DaiLy daily = context.DaiLy.Where(dl => dl.MaDaiLy == ma).SingleOrDefault();
            ViewBag.DaiLy = daily;
            return PartialView("ChiTietCongNoPartialView", dsCongNo);
        }
    }
}