using System.ComponentModel.DataAnnotations;

namespace SampleMvcApp.ViewModels
{
    public class Transporte
    {
        [Key]
        public int IdTransporte { get; set; }

        //[ForeignKey("Conductor")]

        //public ICollection<Conductor> Conductor { get; set; }

        [Required(ErrorMessage = "Ingresa el tipo")]
        [Display(Name = "Tipo de transporte ")]
        [RegularExpression("^[a-zA-Z]*${1,100}", ErrorMessage = "Solo puede ingresar letras")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "Ingresa el modelo")]
        [Display(Name = "Modelo del transporte")]
        [RegularExpression("^[a-zA-Z]*${1,100}", ErrorMessage = "Solo puede ingresar letras")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "Ingresa la mátricula")]
        [Display(Name = "Mátricula del transporte ")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "Ingresa la capacidad")]
        [Display(Name = "Capacidad de personas del transporte")]
        [Range(10, 50, ErrorMessage = "Error. Ingrese un valor dentro los parámetros establecidos")]
        [RegularExpression("^[0.-9.]*$", ErrorMessage = "Solo puede ingresar numeros")]
        public int? Capacidad { get; set; }

    }
        
}
