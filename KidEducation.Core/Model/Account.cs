using System.ComponentModel.DataAnnotations;

namespace KidEducation.Core.Model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Fullname { get; set; }

        public string? Password { get; set; }

        public string? PasswordHash { get; set; }

        public int? Role { get; set; }

        public bool? IsAdmin { get; set; }
    }
}
