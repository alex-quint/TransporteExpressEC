using System;
using System.ComponentModel.DataAnnotations;

namespace SampleMvcApp.ViewModels
{
    public class Conductor

    {
        [Key]
        public int IdConductor { get; set; }

        /*[Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese su nombre")]
        [RegularExpression("^[a-zA-Z]*${1,100}", ErrorMessage = "Solo puede ingresar letras")]

        public string? Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Ingrese su apellido")]
        [RegularExpression("^[a-zA-Z]*${1,100}", ErrorMessage = "Solo puede ingresar letras")]
        public string? Apellido { get; set; }*/

        [Display(Name = "Cedula")]
        [Required(ErrorMessage = "Ingrese su cedula")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo puede ingresar numeros")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Su cedula debe tener 10 números")]
        [ValidarCedula]
        public string? Cedula { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Ingrese su celular")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo puede ingresar numeros")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Su celular debe tener 10 números")]
        public string? NumeroTelefono { get; set; }




        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Ingresa la fecha de nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha valida")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Fecha de emisión de la licencia")]
        [Required(ErrorMessage = "Ingresa la fecha de emision de la licencia")]
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha valida")]
        public DateTime FechaEmisionLicencia { get; set; }

        [Display(Name = "Fecha de vencimiento de la licencia")]
        [Required(ErrorMessage = "Ingresa la fecha de vencimiento de la licencia")]
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha valida")]
        public DateTime FechaVencimientoLicencia { get; set; }

        /*[Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "Ingresa el correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo valido.")]
        public string? Correo { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Ingresa la contraseña")]
        [DataType(DataType.Password, ErrorMessage = "Ingrese una contraseña valida")]
        public string? Contraseña { get; set; }*/

    }
        public class ValidarCedula : ValidationAttribute
        {
            public override bool IsValid(object? value)

            {
                string valor1 = (string)value;
                bool estado = false;
                char[] valced = new char[13];
                int provincia;
                if (valor1.Length >= 10)
                {
                    valced = valor1.Trim().ToCharArray();
                    provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
                    if (provincia > 0 && provincia < 25)
                    {
                        estado = Verificar(valced);
                    }

                }
                return estado;

            }

            public static bool Verificar(char[] validarCedula)
            {
            int aux = 0, par = 0, impar = 0, verifi;
            for (int i = 0; i < 9; i += 2)
            {
                aux = 2 * int.Parse(validarCedula[i].ToString());
                if (aux > 9)
                    aux -= 9;
                par += aux;
            }
            for (int i = 1; i < 9; i += 2)
            {
                impar += int.Parse(validarCedula[i].ToString());
            }

            aux = par + impar;
            if (aux % 10 != 0)
            {
                verifi = 10 - (aux % 10);
            }
            else
                verifi = 0;
            if (verifi == int.Parse(validarCedula[9].ToString()))
                return true;
            else
                return false;
        }

        }

        
}
