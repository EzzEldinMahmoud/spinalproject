using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Report")]
public class ReportEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id {get;set;}
    [Column("diagnosis")]
    [Required]
    public string diagnosis {get;set;}

    [Column("notes")]
    [MaxLength(500)]
    public string notes {get;set;}
    [Column("status")]
    [Required]
    public PatientStatus status { get; set; } = PatientStatus.normal;
    [Column("cab_angle")]
    [Required]
    [Range(0, 180)]
    public int cab_angle { get; set; }

    [Column("patient_id")]
    [ForeignKey("UserEntity")]
    [Required]
    public Guid patient_id {get;set;}
    [Column("created_at")]
    [Required]

    public DateTime created_at {get;set;} = DateTime.Now;

    
    /* id = db.Column(db.Integer, primary_key=True)
    diagnosis = db.Column(db.String(200), nullable=False)
    treatment_plan = db.Column(db.Text, nullable=False)
    notes = db.Column(db.Text)
    patient_id = db.Column(db.Integer, db.ForeignKey('user.id'))
    doctor_id = db.Column(db.Integer, db.ForeignKey('user.id'))
    created_at = db.Column(db.DateTime, default=datetime.utcnow) */
    
}