using System.ComponentModel.DataAnnotations;

namespace Gestor_Libros_EF.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(200, ErrorMessage = "El título no puede superar 200 caracteres.")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "La descripción no puede superar 1000 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(150, ErrorMessage = "El autor no puede superar 150 caracteres.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        [StringLength(100, ErrorMessage = "El género no puede superar 100 caracteres.")]
        public string Genre { get; set; }

        [Range(1, 2100, ErrorMessage = "El año debe estar entre 1 y 2100.")]
        public int YearPublished { get; set; }
    }
}
