using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeleriaBellasArtes.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingrese la descripcion")]//Validaciones para descripcion
        [MinLength(3, ErrorMessage = "Ingrese mínimo 3 carácteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un máximo de 20 carácteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]//Validaciones para el precio
        [Range(0, 1000, ErrorMessage = "Ingrese un precio entre 0 y 100")]
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]//Para modificar los nombres en la presentacion y no afecta la base de datos
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }
}
