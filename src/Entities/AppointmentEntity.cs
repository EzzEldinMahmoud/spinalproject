using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

[Table("Appointment")]
public class AppointmentEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id {get;set;}
    [Column("status")]
    [Required]
    public PatientStatus status {get;set;} = PatientStatus.normal;
    
    [Column("patient_id")]
    [ForeignKey("UserEntity")]
    [Required]
    public string patient_id {get;set;}
    [Column("created_at")]
    [Required]

    public DateTime created_at {get;set;} = DateTime.Now;
    [Column("appointment_time")]
    [Required]
    public  required DateTime appointment_time {get;set;}
    [Column("appointmentDetails")]
    public  string? appointmentDetails { get; set; }
    [Column("report_id")]
    [ForeignKey("ReportEntity")]


    public  Guid? reportDetails {get;set;} 



    
    /*  id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date, nullable=False)
    time = db.Column(db.Time, nullable=False)
    patient_id = db.Column(db.Integer, db.ForeignKey('user.id'))
    doctor_id = db.Column(db.Integer, db.ForeignKey('user.id'))
    status = db.Column(db.String(20), default='confirmed') */
    
}