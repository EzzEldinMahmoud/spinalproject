public class AppointmentDTO
{
    public PatientStatus status { get; set; } = PatientStatus.normal;
    public string? patient_id { get; set; }
    public string? appointment_time { get; set; }
    public Guid? reportDetails { get; set; }
    public string? appointmentDetails { get; set; }

}