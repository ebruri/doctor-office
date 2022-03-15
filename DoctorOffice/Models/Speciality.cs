using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Speciality
  {
    public Speciality()
    {
      this.JoinEntities2 = new HashSet<SpecialityDoctor>();
    }
    public int SpecialityId { get; set; }
    public string Name {get; set;}
    public virtual ICollection<SpecialityDoctor> JoinEntities2 { get; set; }

  }  
}  


