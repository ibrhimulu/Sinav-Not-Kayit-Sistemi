using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjeComplatedFull1.Entities
{
    public class Notlar
    {
        [Key]
        public int NotId { get; set; }

        [Required]
        [ForeignKey(nameof(Dersler))]
        public int DersId { get; set; }
        public Dersler Dersler { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }


        public int? Sınav1 { get; set; }


        public int? Sınav2 { get; set; }


        public int? Sınav3 { get; set; }


        public decimal Ortalama { get; set; }


        public bool Durum { get; set; }


        //public string DersAd { get; set; }
        //public int? DersProgramiId { get; set; }



    }
}
