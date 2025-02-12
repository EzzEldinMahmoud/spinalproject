public class ReportDTO
{
    public string diagnosis { get; set; }
    public string notes { get; set; }
    public PatientStatus status { get; set; }
    public int cab_angle { get; set; }
    public Guid patient_id { get; set; }
}