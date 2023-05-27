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
    public class ParentescoController : ControllerBase
    {
        public readonly ApplicationDbContext _dbContext;
        public readonly IMapper _mapper;

        public ParentescoController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] ParentescoDTO parentescoDTO)
        {
            var existeParentesco = await _dbContext.Parentescos.AnyAsync(g => g.Name == parentescoDTO.Name);
            if (existeParentesco) return BadRequest($"El genero {parentescoDTO.Name} ya existe");

            var parentesco = _mapper.Map<Parentesco>(parentescoDTO);

            _dbContext.Parentescos.Add(parentesco);
            await _dbContext.SaveChangesAsync();

            var getParentesco = _mapper.Map<ParentescoDTO>(parentesco);

            return CreatedAtRoute("obtenerParentesco", new { id = parentesco.Id }, getParentesco);
        }

        [HttpGet()]
        public async Task<ActionResult<List<ParentescoDTO>>> GetAll()
        {
            var parentesco = await _dbContext.Parentescos.ToListAsync();
            if (parentesco == null) return BadRequest("No hay datos");
            return _mapper.Map<List<ParentescoDTO>>(parentesco);
        }


        [HttpGet("{id}", Name = "obtenerParentesco")]
        public async Task<ActionResult<ParentescoDTO>> GetById(int id)
        {
            var parentesco = await _dbContext.Parentescos.FirstOrDefaultAsync(g => g.Id == id);

            if (parentesco == null) return NotFound($"No se encontro el dato {id}");

            return _mapper.Map<ParentescoDTO>(parentesco);
        }
    }
}
