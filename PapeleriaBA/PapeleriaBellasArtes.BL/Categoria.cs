using System.ComponentModel.DataAnnotations;

namespace PapeleriaBellasArtes.BL
{
    public class Categoria
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la Categoria")]//"Requerido" no acepta campos vacíos
        public string Descripcion { get; set; }
    }
}