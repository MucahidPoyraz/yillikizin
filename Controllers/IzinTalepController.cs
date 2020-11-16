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
    public class IzinTalepController : Controller
    {
        
        IzinContext db = new IzinContext();
        public IActionResult Index(int depid, string hata) {
            ViewBag.personeller = db.Personeller.ToList();
            var izinler = db.Izinler.ToList();
            return View(izinler);

        }
        public IActionResult Form(int perid,int id)
        {
            Izin model;
            ViewBag.personeller = db.Personeller.ToList();
            if (id != 0)//
            {
                model = db.Izinler.Find(id);
                ViewBag.kullanilanizin = kullanilanizin(model.PersonelId);
                ViewBag.kalanizin = kalanizinhesapla(model.PersonelId);

            }
            else
            {
                model =new Izin();
                
                model.BaslamaTarihi = DateTime.Now;
                model.BitisTarihi = DateTime.Now;

                if (perid != 0)
                {
                    model.PersonelId = perid;
                    ViewBag.kullanilanizin = kullanilanizin(perid);
                    ViewBag.kalanizin = kalanizinhesapla(perid);
                }
            }
            return View(model);
        }

        private int kullanilanizin(int personelid)
        {
            return  db.Izinler.Where(i => i.PersonelId == personelid).Sum(i => i.Kullanilanizin);
        }

        public IActionResult Kaydet(Izin izin)
        {
            
            izin.Kullanilanizin = izin.BitisTarihi.Subtract(izin.BaslamaTarihi).Days + 1;
            int kalan = kalanizinhesapla(izin.PersonelId)-izin.Kullanilanizin;
            izin.Taleptarihi = DateTime.Now;
            ViewBag.personeller = db.Personeller.ToList();
            if (izin.BaslamaTarihi > izin.BitisTarihi)
            {

                ViewBag.hatamesaji = "başlangıç tarihi bitis tarihinden büyük olamaz!!!!";
                return View("Form",izin);
            }

            if (kalan < 0)
            {

                ViewBag.hatamesaji = "izin süresi aşıldı!!";
                
                return View("Form",izin);
            }
            else
            {
                if (izin.Id == 0)
                {
                    db.Add(izin);
                }
                else
                {
                    db.Entry(izin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                
            }
            db.SaveChanges();

            return RedirectToAction("Index");
   
        }

        public IActionResult Sil(int id)
        {
            var silinecek = db.Izinler.Find(id);
            db.Izinler.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public int kalanizinhesapla(int personelid)
        {
            var personel = db.Personeller.Find(personelid);
            int hizmetsüresi = DateTime.Now.Subtract(personel.Giristarih).Days/365;
            if (hizmetsüresi < 1)
            {
                return 0;
            }
            else if(hizmetsüresi>=1 && hizmetsüresi < 5){
                return 15-kullanilanizin(personelid);
            }
            else if(hizmetsüresi>=5 && hizmetsüresi < 10)
            {
                return 20-kullanilanizin(personelid);
            }
            else if( hizmetsüresi >=10 && hizmetsüresi < 15)
            {
                return 25 - kullanilanizin(personelid);
            }
            else
            {
                return 30 - kullanilanizin(personelid);
            }
        }
    }
}