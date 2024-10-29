using AutoMapper;
using ArticulosAPI.Dtos;
using ArticulosAPI.Modelos;  
using ArticulosAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloRepositorio _articuloRepositorio;
        private readonly IMapper _mapper;

        // Inyectar repositorio y AutoMapper a través del constructor
        public ArticulosController(IArticuloRepositorio articuloRepositorio, IMapper mapper)
        {
            _articuloRepositorio = articuloRepositorio;
            _mapper = mapper;
        }

        // GET: api/articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDto>>> GetArticulos()
        {
            var articulos = await _articuloRepositorio.GetAllArticulos();
            var articulosDto = _mapper.Map<IEnumerable<ArticuloDto>>(articulos);
            return Ok(articulosDto);
        }

        // GET: api/articulos/{id}
        [HttpGet("{id:int}", Name = "GetArticuloById")]
        public async Task<ActionResult<ArticuloDto>> GetArticuloById(int id)
        {
            var articulo = await _articuloRepositorio.GetArticuloById(id);
            if (articulo == null)
            {
                return NotFound();
            }

            var articuloDto = _mapper.Map<ArticuloDto>(articulo);
            return Ok(articuloDto);
        }

        // POST: api/articulos
        [HttpPost]
        public async Task<ActionResult<ArticuloDto>> CreateArticulo([FromBody] ArticuloDto articuloDto)
        {
            if (articuloDto == null)
            {
                return BadRequest();
            }

            var articulo = _mapper.Map<Articulo>(articuloDto);
            await _articuloRepositorio.CreateArticulo(articulo);

            var articuloCreadoDto = _mapper.Map<ArticuloDto>(articulo);

            return CreatedAtRoute("GetArticuloById", new { id = articulo.Id }, articuloCreadoDto);
        }

        // PUT: api/articulos/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateArticulo(int id, [FromBody] ArticuloDto articuloDto)
        {
            if (articuloDto == null || id != articuloDto.Id)
            {
                return BadRequest();
            }

            var articulo = _mapper.Map<Articulo>(articuloDto);
            await _articuloRepositorio.UpdateArticulo(articulo);

            return NoContent();
        }

        // DELETE: api/articulos/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _articuloRepositorio.GetArticuloById(id);
            if (articulo == null)
            {
                return NotFound();
            }

            await _articuloRepositorio.DeleteArticulo(id);
            return NoContent();
        }
    }
}
