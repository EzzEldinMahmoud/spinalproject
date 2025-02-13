public class AppointmentDTO
{
    public string status { get; set; }
    public string? patient_id { get; set; }
    public string? appointment_time { get; set; }
    public Guid? reportDetails { get; set; }
    public string? appointmentDetails { get; set; }

}