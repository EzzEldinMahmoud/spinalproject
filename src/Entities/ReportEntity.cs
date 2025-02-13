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
    public string status { get; set; } 
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

    
}