namespace DoctorOffice.Models
{
  public class DoctorPatient
  {
    public int DoctorPatientId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public virtual Patient patient { get; set; }
    public virtual Doctor doctor { get; set; }
  }
}