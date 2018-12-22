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

        public IActionResult CreateGiai(string macreate, string tencreate, int soluongcreate, int socreate, float giaithuongcreate)
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
                giai.So = socreate;
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

        public IActionResult EditGiai(string maedit, string tenedit, int soluongedit, int soedit, float giaithuongedit)
        {
            Giai giai = context.Giai.Where(g => g.MaGiai == maedit).SingleOrDefault();
            giai.TenGiai = tenedit;
            giai.SoLuong = soluongedit;
            giai.So = soedit;
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

        public JsonResult RandomKetQua()
        {
            List<Giai> dsgiai = context.Giai.OrderBy(g => g.MaGiai.Substring(2)).ToList();
            List<int> dsKQVS = new List<int>();
            foreach(var item in dsgiai)
            {
                for (int i = 1; i <= item.SoLuong; i++)
                {
                    double min = Math.Pow(10, item.So.GetValueOrDefault() - 1);
                    double max = Math.Pow(10, item.So.GetValueOrDefault()) - 1;
                    Random rd = new Random();
                    int sotrung = rd.Next(int.Parse(min.ToString()), int.Parse(max.ToString()));
                    dsKQVS.Add(sotrung);
                }
            }
            return Json(dsKQVS);
        }

        public void ThemKetQuaXoSo(string ketqua, string idLVS, string idgiai)
        {
            //Lấy mã mới nhất
            int mamoinhat = 1;
            var list = context.KetQuaXoSo.Select(l => new { Element = int.Parse(l.MaKetQua.Substring(4, l.MaKetQua.Length).ToString()) }).ToList().OrderByDescending(l => l.Element).ToList();
            if (list.Count != 0)
                 mamoinhat = int.Parse(list[0].Element.ToString()) + 1;
            //Thêm
            KetQuaXoSo kqxs = new KetQuaXoSo();
            kqxs.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            kqxs.MaKetQua = "KQXS" + mamoinhat;
            kqxs.IdLoaiVeSo = Guid.Parse(idLVS);
            kqxs.Ngay = DateTime.Now.Date;
            kqxs.IdGiai = Guid.Parse(idgiai);
            kqxs.SoTrung = ketqua;
            context.KetQuaXoSo.Add(kqxs);
            context.SaveChanges();
        }

        public IActionResult ThongTinKetQua(string id)
        {
            KetQuaChung kqc = context.KetQuaChung.Where(kq => kq.Id == Guid.Parse(id)).Include(kq => kq.IdLoaiVeSoNavigation).SingleOrDefault();
            List<KetQuaXoSo> dskqxs = context.KetQuaXoSo.Where(kq => kq.IdLoaiVeSo == kqc.IdLoaiVeSo && kq.Ngay == kqc.Ngay)
                                                        .OrderBy(kq => kq.IdGiaiNavigation.MaGiai)
                                                        .Include(kq => kq.IdGiaiNavigation)
                                                        .Include(kq => kq.IdLoaiVeSoNavigation)
                                                        .ToList();
            List<Giai> dsgiai = context.Giai.OrderBy(g => g.MaGiai).ToList();
            ViewBag.Giai = dsgiai;
            ViewBag.KetQuaChung = kqc;
            return PartialView("ThongTinKetQuaPartialView", dskqxs);
        }
    }
}