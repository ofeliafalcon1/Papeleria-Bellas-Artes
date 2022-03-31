using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeleriaBellasArtes.BL
{
    public class Cliente
    {
        public Cliente()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese un Nombre")]//Validaciones para Nombre
        [MaxLength(20, ErrorMessage = "Ingrese un máximo de 20 carácteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el Numero")]//Validaciones para el Numero
        [MinLength(8, ErrorMessage = "El Telefono debe ser de 8 digitos")]
        [MaxLength(8, ErrorMessage = "El Telefono debe ser de 8 digitos")]
        public string Telefono { get; set; }
        
        
        [Required(ErrorMessage = "Ingrese la Dirección")]
        [MinLength(3, ErrorMessage = "Ingrese minímo 3 caracteres")]
        public string Direccion { get; set; }

        public bool Activo { get; set; }
    }

}
