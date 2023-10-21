using System.ComponentModel.DataAnnotations;

namespace ProjeComplatedFull1.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Öğrenci numarası gerekli.")]
        [StringLength(30, ErrorMessage = "Öğrenci numarası en fazla 30 karakterden oluşmalı.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Şifre gerekli.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterden oluşmalı.")]
        [MaxLength(15, ErrorMessage = "Şifre en fazla 15 karakterden oluşmalı.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre gerekli.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterden oluşmalı.")]
        [MaxLength(15, ErrorMessage = "Şifre en fazla 15 karakterden oluşmalı.")]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
