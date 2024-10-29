using System.ComponentModel.DataAnnotations;

namespace ArticulosAPI.Modelos
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Marca { get; set; }

        public decimal Precio { get; set; }
    }
}
