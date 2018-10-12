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
        const int pageSize = 10;
        int pageNumber = 1;

        public PhanPhoiController(QLVeSoContext context)
        {
            this.context = context;
        }
        public int TongSoTrang()
        {
            List<PhanPhoi> list = context.PhanPhoi.ToList();
            return ((list.Count / pageSize) + 1);
        }

        public IActionResult Index(string thongbao, int? pagenumber)
        {
            if (thongbao != null)
                ViewBag.ThongBao = thongbao;
            pageNumber = pagenumber ?? 1;
            List<PhanPhoi> list = context.PhanPhoi.OrderBy(pp => pp.Ngay)
                                                  .ThenBy(pp => pp.IdDaiLy)
                                                  .Include(pp => pp.IdDaiLyNavigation)
                                                  .Include(pp => pp.IdLoaiVeSoNavigation)
                                                  .Skip(pageSize * (pageNumber - 1))
                                                  .Take(pageSize)
                                                  .ToList();
            ViewBag.TongTrang = TongSoTrang();
            ViewBag.TrangHienTai = pageNumber;
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

        public IActionResult CapNhat()
        {
            string thongbao = "";
            PhanPhoi phanphoi = context.PhanPhoi.OrderByDescending(pp => pp.Ngay).FirstOrDefault();
            if (phanphoi != null)
            {
                if (DateTime.Today.Date == phanphoi.Ngay)
                {
                    thongbao = "Hôm nay đã cập nhật";
                }
                else
                {
                    context.Database.ExecuteSqlCommand("EXEC Them_PhanPhoi");
                    thongbao = "Cập nhật thành công";
                }
            }
            else
            {
                context.Database.ExecuteSqlCommand("EXEC Them_PhanPhoi");
                thongbao = "Cập nhật thành công";
            }            
            return RedirectToAction("Index", "PhanPhoi", new { thongbao = thongbao });
        }

        public IActionResult Edit(string idedit, int slgedit, string slbedit)
        {
            string thongbao = "";
            PhanPhoi phanphoi = context.PhanPhoi.Where(pp => pp.Id.ToString() == idedit).SingleOrDefault();
            if(slgedit == phanphoi.SoLuongGiao && slbedit == null)
            {
                thongbao = "Không thay đổi dữ liệu";
            }
            else
            {
                if(slbedit != null)
                {
                    if(int.Parse(slbedit) > slgedit)
                    {
                        thongbao = "Số lượng bán phải ít hơn bằng số lượng giao";
                    }
                    else
                    {
                        phanphoi.SoLuongBan = int.Parse(slbedit);
                        if (slgedit != phanphoi.SoLuongGiao)
                            phanphoi.SoLuongGiao = slgedit;
                        context.SaveChanges();
                        thongbao = "Sửa thành công";
                    }
                }
            }
            return RedirectToAction("Index", "PhanPhoi", new { thongbao = thongbao });
        }
    }
}