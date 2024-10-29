using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorios
{
    public interface IArticuloRepositorio
    {
        Task<IEnumerable<Articulo>> GetAllArticulos();
        Task<Articulo> GetArticuloById(int id);
        Task CreateArticulo(Articulo articulo);
        Task UpdateArticulo(Articulo articulo);
        Task DeleteArticulo(int id);
    }
}
