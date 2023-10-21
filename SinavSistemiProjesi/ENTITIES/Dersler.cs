using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Entities
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
