using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorOffice.Controllers
{
  public class SpecialitiesController : Controller
  {
    private readonly DoctorOfficeContext _db;

    public SpecialitiesController(DoctorOfficeContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Speciality> model = _db.Specialities.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Speciality speciality)
    {
      _db.Specialities.Add(speciality);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisSpeciality = _db.Specialities
          .Include(speciality => speciality.JoinEntities2)
          .ThenInclude(join => join.doctor)
          .FirstOrDefault(speciality => speciality.SpecialityId == id);
      return View(thisSpeciality);
    } 
    public ActionResult Edit(int id)
    {
      var thisSpeciality = _db.Specialities.FirstOrDefault(speciality => speciality.SpecialityId == id);
      return View(thisSpeciality);
    }

    [HttpPost]
    public ActionResult Edit(Speciality speciality)
    {
      _db.Entry(speciality).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisSpeciality = _db.Specialities.FirstOrDefault(speciality => speciality.SpecialityId == id);
      return View(thisSpeciality);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSpeciality = _db.Specialities.FirstOrDefault(speciality => speciality.SpecialityId == id);
      _db.Specialities.Remove(thisSpeciality);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }  
}    