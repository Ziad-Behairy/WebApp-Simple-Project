using System.ComponentModel.DataAnnotations;

namespace Lab11_Project.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(3), MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6), MaxLength(60)]
        public string Password { get; set; }
        public int UserType { get; set; }


    }
}
