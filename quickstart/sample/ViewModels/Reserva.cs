using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SampleMvcApp.ViewModels
{
    
    public class Reserva
        
       
    {
        [Key]
        public int IdReserva { get; set; }



        //[ForeignKey("Cliente")]
        //public ICollection<Cliente> Cliente { get; set; }


        //public int IdCliente   { get; set; }



        [Display(Name = "Fecha de partida")]
        [Required(ErrorMessage = "Ingresa la fecha de partida del viaje")]
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha valida")]
        public DateTime FechaPartida { get; set; }


        [Display(Name = "Punto de partida (Direccion)")]
        [Required(ErrorMessage = "Debe ingresar el punto de partida")]

        public string? PuntoPartida { get; set; }


        [Required(ErrorMessage = "Ingresa la cantidad de personas que viajan")]
        [Display(Name = "Cantidad personas que viajan")]
        [Range(10, 50, ErrorMessage = "Error. Ingrese un valor dentro los parámetros establecidos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo puede ingresar numeros")]
        public int? CantPersonas { get; set; }
    }
}
