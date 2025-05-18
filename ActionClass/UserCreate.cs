using System.ComponentModel.DataAnnotations;

namespace FileExchangerAPI.ActionClass
{
    public class UserCreate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
