using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YillikIzin.Models;
using YillikIzin.Models.Context;

namespace YillikIzin.Controllers
{
    public class PersonelController : Controller
    {
        IzinContext db = new IzinContext();
        public IActionResult Index()
        {
            var personeller = db.Personeller.Include(x=>x.Departman).ToList();
            
            return View(personeller);
        }
        public IActionResult Form(int id)
        {
            Personel model;
            ViewBag.departmanlistesi = db.Departmanlar.ToList();
            if (id == 0)// yeni kayıt
            {
                model = new Personel();
            }
            else//düzenle
            {
                model = db.Personeller.Find(id);

            }
            model.Giristarih = DateTime.Now;
           
            return View(model);
        }
        [HttpPost]
        public IActionResult Kaydet(Personel personel)
        {
            if (personel.Id == 0)
            {
                db.Add(personel);
            }
            else
            {
               
                db.Entry(personel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            var silinecek = db.Personeller.Find(id);
            db.Personeller.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}