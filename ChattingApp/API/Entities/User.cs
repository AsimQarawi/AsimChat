using System.ComponentModel.DataAnnotations;

namespace API.Entities;
    
public class User
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }

}
