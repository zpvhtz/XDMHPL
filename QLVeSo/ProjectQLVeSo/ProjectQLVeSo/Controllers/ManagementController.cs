using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectQLVeSo.Models;

namespace ProjectQLVeSo.Controllers
{
    public class ManagementController : Controller
    {
        private readonly QlVeSoContext context;
        public ManagementController(QlVeSoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult LoaiVeSo()
        {
            List<LoaiVeSo> dsLoaiVeSo = new List<LoaiVeSo>();
            dsLoaiVeSo = context.LoaiVeSo.OrderBy(vs => vs.Id).ToList();
            return View(dsLoaiVeSo);
        }

        public IActionResult Search(string txtSearch)
        {
            List<LoaiVeSo> dsLoaiVeSo = new List<LoaiVeSo>();
            dsLoaiVeSo = context.LoaiVeSo.Where(vs => vs.Tinh.Contains(txtSearch)).ToList();
            return View("LoaiVeSo", dsLoaiVeSo);
        }

        public IActionResult Add(string ma, string tinh)
        {
            LoaiVeSo vs = new LoaiVeSo();
            vs.Id = Guid.NewGuid();
            vs.Ma = ma;
            vs.Tinh = tinh;
            vs.TinhTrang = "Không khoá";
            context.LoaiVeSo.Add(vs);
            context.SaveChanges();
            return RedirectToAction("LoaiVeSo");
        }
    }
}