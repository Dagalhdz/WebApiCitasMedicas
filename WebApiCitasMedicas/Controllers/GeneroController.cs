using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCitasMedicas.DTOS;
using WebApiCitasMedicas.Entities;

namespace WebApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        public readonly ApplicationDbContext _dbContext;
        public readonly IMapper _mapper;

        public GeneroController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<ActionResult> PostGenero([FromBody] GeneroDTO generoDTO)
        {
            var existeGenero = await _dbContext.Generos.AnyAsync(g => g.Name == generoDTO.Name);
            if (existeGenero) return BadRequest($"El genero {generoDTO.Name} ya existe");

            var genero = _mapper.Map<Genero>(generoDTO);

            _dbContext.Generos.Add(genero);
            await _dbContext.SaveChangesAsync();

            var getAlumno = _mapper.Map<GeneroDTO>(genero);

            return CreatedAtRoute("obtenerGenero", new { id = genero.Id }, getAlumno);
        }

        [HttpGet()]
        public async Task<ActionResult<List<GeneroDTO>>> GetGenero()
        {
            var genero = await _dbContext.Generos.ToListAsync();
            return _mapper.Map<List<GeneroDTO>>(genero);
        }


        [HttpGet("{id}", Name = "obtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> GetGeneroById(int id)
        {
            var genero = await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero == null) return NotFound($"No se encontro el dato {id}");

            return _mapper.Map<GeneroDTO>(genero);
        }
    }
}
