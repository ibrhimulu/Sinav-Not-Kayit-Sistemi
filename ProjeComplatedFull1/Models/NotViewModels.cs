using ProjeComplatedFull1.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjeComplatedFull1.Models
{
    public class NotModel
    {
        public int NotId { get; set; }
        public Guid UserId { get; set; }
        public int DersId { get; set; }

        public string DersAd { get; set; }

        public string Username { get; set; }

        public int? Sınav1 { get; set; }


        public int? Sınav2 { get; set; }


        public int? Sınav3 { get; set; }


        public decimal Ortalama { get; set; }


        public bool Durum { get; set; }
    }

    public class CreateNotModel
    {
        public int NotId { get; set; }
        public Guid UserId { get; set; }
        public int DersId { get; set; }

        public string DersAd { get; set; }

        public string Username { get; set; }

        public int? Sınav1 { get; set; }


        public int? Sınav2 { get; set; }


        public int? Sınav3 { get; set; }


        public decimal Ortalama { get; set; }


        public bool Durum { get; set; }
    }

    public class EditNotModel
    {
        public int NotId { get; set; }
        public Guid UserId { get; set; }
        public int DersId { get; set; }


        public int? Sınav1 { get; set; }


        public int? Sınav2 { get; set; }


        public int? Sınav3 { get; set; }


        //public decimal Ortalama { get; set; }


        public bool Durum { get; set; }
    }
}
