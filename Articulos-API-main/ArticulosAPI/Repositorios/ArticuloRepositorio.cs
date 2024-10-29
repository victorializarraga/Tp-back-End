using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorios;

public class ArticuloRepositorio : IArticuloRepositorio
{
    private readonly List<Articulo> _articulos;

    public ArticuloRepositorio()
    {
        _articulos = new List<Articulo>
        {
            new Articulo { Id = 1, Nombre = "Articulo 1", Descripcion = "Descripción del artículo 1", Marca = "Marca 1", Precio = 100 },
            new Articulo { Id = 2, Nombre = "Articulo 2", Descripcion = "Descripción del artículo 2", Marca = "Marca 2", Precio = 200 }
        };
    }

    public async Task<IEnumerable<Articulo>> GetAllArticulos()
    {
        return await Task.FromResult(_articulos);
    }

    public async Task<Articulo> GetArticuloById(int id)
    {
        var articulo = _articulos.Find(a => a.Id == id);
        return await Task.FromResult(articulo);
    }

    public async Task CreateArticulo(Articulo articulo)
    {
        _articulos.Add(articulo);
        await Task.CompletedTask;
    }

    public async Task UpdateArticulo(Articulo articulo)
    {
        var articuloExistente = _articulos.Find(a => a.Id == articulo.Id);
        if (articuloExistente != null)
        {
            articuloExistente.Nombre = articulo.Nombre;
            articuloExistente.Precio = articulo.Precio;
            // Actualizar otras propiedades si es necesario
        }
        await Task.CompletedTask;
    }

    public async Task DeleteArticulo(int id)
    {
        var articulo = _articulos.Find(a => a.Id == id);
        if (articulo != null)
        {
            _articulos.Remove(articulo);
        }
        await Task.CompletedTask;
    }
}
