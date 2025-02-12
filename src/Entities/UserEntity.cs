using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("User")]
public class UserEntity {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  Guid id {get;set;}
    [Column("Role")]
    [Required]
    public required string Role { get; set; } = "Patient";
    [Column("email_address")]
    [Required]
    public required string email_address { get; set; }
    [Column("password")]
    [Required]
    [MinLength(8)]
    public required string password { get; set; }
    [Column("name")]
    public  string name { get; set; }
    [Column("appointments")]

    public IEnumerable<AppointmentEntity>? Appointments {get;set;}
    [Column("reports")]

    public IEnumerable<ReportEntity>? Reports { get; set; }


    [Column("created_at")]
    [Required]

    public required DateTime created_at {get;set;} = DateTime.Now;

    
    /* id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(80), nullable=False)
    email = db.Column(db.String(120), unique=True, nullable=False)
    password_hash = db.Column(db.String(128), nullable=False)
    role = db.Column(db.String(20), nullable=False)  # 'doctor', 'supervisor', 'patient'
    created_at = db.Column(db.DateTime, default=datetime.utcnow) */
    
}