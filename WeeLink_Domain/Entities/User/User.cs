using System.ComponentModel.DataAnnotations;

namespace WeeLink_Domain.Entities.User;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
}
