using System.ComponentModel.DataAnnotations;

namespace API.DTOs;
public class RegisterDTOs
{
    [Required]
    public required string userName { get; set;}
    [Required]
    public required string password { get; set;}


}
