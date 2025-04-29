using System.ComponentModel.DataAnnotations;

namespace RestoManager_YourName.Models.RestosModel
{
    public class Avis
    {
        [Key] // ✅ Add this attribute
        public int CodeAvis { get; set; }

        [Required]
        [MaxLength(30)]
        public string NomPersonne { get; set; }

        [Range(1, 5)]
        [Required]
        public int Note { get; set; }

        [MaxLength(256)]
        public string Commentaire { get; set; }

        public int NumResto { get; set; }

        public Restaurant LeResto { get; set; }
    }
}