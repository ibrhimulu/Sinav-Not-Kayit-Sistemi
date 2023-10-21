using ProjeComplatedFull1.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjeComplatedFull1.Models
{
    public class UserModel
    {

        public Guid Id { get; set; }
        public int RolId { get; set; } = 1;

        public string? NameSurname { get; set; } = null;

        public string Username { get; set; }

        public string ProfileImageFile { get; set; } = "no-image.jpg";


        public bool Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Roller Rol { get; set; }
    }

    public class CreateUserModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gerekli.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı en fazla 30 karakterden oluşmalı.")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string NameSurname { get; set; }

        public bool Locked { get; set; }


        [Required(ErrorMessage = "Şifre gerekli.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterden oluşmalı.")]
        [MaxLength(15, ErrorMessage = "Şifre en fazla 15 karakterden oluşmalı.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre gerekli.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterden oluşmalı.")]
        [MaxLength(15, ErrorMessage = "Şifre en fazla 15 karakterden oluşmalı.")]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }

        public int RolId { get; set; } = 1;
    }

    public class EditUserModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gerekli.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı en fazla 30 karakterden oluşmalı.")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string NameSurname { get; set; }

        public bool Locked { get; set; }

        public int RolId { get; set; } = 1;
    }
}
