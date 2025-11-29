using System.ComponentModel.DataAnnotations;

namespace Reprise_back.Models.Dto
{
    public class MediaDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères")]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
