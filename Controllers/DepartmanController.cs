using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YillikIzin.Models;
using YillikIzin.Models.Context;

namespace YillikIzin.Controllers
{
    public class DepartmanController : Controller
    {
        IzinContext db = new IzinContext();
        public IActionResult Index()
        {
            var departmanlar = db.Departmanlar.ToList();
            return View(departmanlar);
        }
        public IActionResult Form(int id)
        {
            Departman model;
            if (id == 0)// yeni kayıt
            {
                 model = new Departman();
            }
            else//düzenle
            {
                model = db.Departmanlar.Find(id);

            }
           
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Kaydet(Departman departman)
        {
            if (departman.Id == 0)
            {
                db.Add(departman);
            }
            else
            {
                db.Entry(departman).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            var silinecek = db.Departmanlar.Find(id);
            db.Departmanlar.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}