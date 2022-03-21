using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DoctorOfficeContext _db;

    public DoctorsController(DoctorOfficeContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {  
      List<Doctor> thisDoctor = _db.Doctors
        .Include(doctor => doctor.JoinEntities2)
        .ThenInclude(join => join.speciality)
        .ToList();
      return View(thisDoctor);
    }
    public ActionResult Create()
    {
      ViewBag.SpecialityId = new SelectList(_db.Specialities, "SpecialityId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor, int SpecialityId)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      if (SpecialityId != 0)
      {
        _db.SpecialityDoctor.Add(new SpecialityDoctor() { SpecialityId = SpecialityId, DoctorId = doctor.DoctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisDoctor = _db.Doctors
          .Include(doctor => doctor.JoinEntities)
          .ThenInclude(join => join.patient)
          .FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    } 
    public ActionResult Edit(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Doctor doctor)
    {
      _db.Entry(doctor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      _db.Doctors.Remove(thisDoctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddSpeciality(int id)
      {
        ViewBag.SpecialityId = new SelectList(_db.Specialities, "SpecialityId", "Name");
        var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
        return View(thisDoctor);
      }

    [HttpPost]
    public ActionResult AddSpeciality(Doctor doctor, int SpecialityId)
    {
      if (SpecialityId != 0)
      {
        _db.SpecialityDoctor.Add(new SpecialityDoctor() { SpecialityId = SpecialityId, DoctorId = doctor.DoctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    
    [HttpPost]
    public ActionResult DeleteSpeciality(int joinId)
    {
      var joinEntry = _db.SpecialityDoctor.FirstOrDefault(entry => entry.SpecialityDoctorId == joinId);
      _db.SpecialityDoctor.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }  
}    