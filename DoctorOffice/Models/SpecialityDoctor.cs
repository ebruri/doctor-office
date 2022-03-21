using System.Collections.Generic;


namespace DoctorOffice.Models
{
  public class SpecialityDoctor
  {
    public int SpecialityDoctorId { get; set; }
    public int SpecialityId { get; set; }
    public int DoctorId { get; set; }
    
    // public List<Speciality> model = new List<Speciality>();
    public virtual Speciality speciality { get; set; }
    public virtual Doctor doctor { get; set; }
  }
}