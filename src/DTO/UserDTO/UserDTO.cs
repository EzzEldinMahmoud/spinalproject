using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class userDTO
{
    public string email_address { get; set; }
    public string password { get; set; }
    public string? name { get; set; }

}