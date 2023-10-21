using System.ComponentModel.DataAnnotations;

namespace ProjeComplatedFull1.Entities
{
    public class Roller
    {
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string? RoleAd { get; set; } = null;

        public List<User> users { get; set; }

    }
}
