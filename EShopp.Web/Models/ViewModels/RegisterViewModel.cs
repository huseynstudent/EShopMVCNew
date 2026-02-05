using System.ComponentModel.DataAnnotations;

namespace AspnetMvcAuth.Models.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
