using System.ComponentModel.DataAnnotations;

namespace WeeLink_Domain.Entities.User;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
}
