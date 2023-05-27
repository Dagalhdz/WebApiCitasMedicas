using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCitasMedicas.DTOS;
using WebApiCitasMedicas.Entities;

namespace WebApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public PacienteController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<GetUserDTO>>> GetPacientes()
        {
            var pacientes = await _dbContext.Pacientes.ToListAsync();
            if (pacientes == null) return BadRequest("No hay encontro paciente");

            var result = _mapper.Map<List<GetUserDTO>>(pacientes);

            return result;
        }

        [HttpGet("{id}/familiares")]
        public async Task<ActionResult<List<FamiliarDTO>>> GetFamiliar(string id)
        {
            var familiares = await _dbContext.Familiares.ToListAsync();
            return _mapper.Map<List<FamiliarDTO>>(familiares);
        }


    }
}
