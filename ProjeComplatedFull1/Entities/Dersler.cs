using System.ComponentModel.DataAnnotations;

namespace ProjeComplatedFull1.Entities
{
    public class Dersler
    {
        [Key]
        public int DersId { get; set; }

        [StringLength(50)]
        public string? DersAd { get; set; }

        public List<Notlar> Notlar { get; set; }


    }
}
