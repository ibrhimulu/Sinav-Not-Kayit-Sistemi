using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjeComplatedFull1.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public int RolId { get; set; } = 1;

        [StringLength(50)]
        public string? NameSurname { get; set; } = null;

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(250)]
        public string ProfileImageFile { get; set; } = "no-image.jpg";

        public bool Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsTeacher { get; set; }

        public List<Notlar> Notlar { get; set; }
        public Roller Rol { get; set; }
    }

}
