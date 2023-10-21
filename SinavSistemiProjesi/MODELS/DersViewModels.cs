using $safeprojectname$.Entities;
using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Models
{
    public class DersModel
    {

        public int DersId { get; set; }


        public string? DersAd { get; set; }


    }

    public class CreateDersModel
    {
        [Required(ErrorMessage = "Ders adı gerekli.")]
        [StringLength(30, ErrorMessage = "Ders adı en fazla 30 karakterden oluşmalı.")]
        public string DersAd { get; set; }

        public int DersId { get; set; }


    }

    public class EditDersModel
    {
        [Required(ErrorMessage = "Ders adı gerekli.")]
        [StringLength(30, ErrorMessage = "Ders adı en fazla 30 karakterden oluşmalı.")]
        public string DersAd { get; set; }

        public int DersId { get; set; }


    }
}
