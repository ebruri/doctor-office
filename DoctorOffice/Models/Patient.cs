using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Patient
  {
    public Patient()
    {
      this.JoinEntities = new HashSet<DoctorPatient>();
    }

    public int PatientId { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Phone { get; set; }
    public string Address {get; set;}

    public virtual ICollection<DoctorPatient> JoinEntities { get; }
  }
}