using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace SampleMvcApp.ViewModels
{
    public class Viaje
    {
        [Key]
        public int IdViaje { get; set; }

        [Display(Name = "Nombre del lugar")]
        [Required(ErrorMessage = "Ingrese el nombre del lugar")]
        [RegularExpression("^[a-zA-Z]*${1,100}", ErrorMessage = "Solo puede ingresar letras")]
        public string? Nombre { get; set; }

        [Display(Name = "Imagen")]
        public string ImagenUrl { get; set; }

        [NotMapped]
        public IFormFile ImagenLugar { get; set; }
    }
}
