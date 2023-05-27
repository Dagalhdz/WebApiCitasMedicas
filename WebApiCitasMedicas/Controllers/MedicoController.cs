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
    public class MedicoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public MedicoController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        

        [HttpGet]
        public async Task<ActionResult<List<GetUserDTO>>> Get()
        {
            var doctores = await _dbContext.Medicos.ToListAsync();
            if (doctores == null) return BadRequest("No hay medicos");
            var result = _mapper.Map<List<GetUserDTO>>(doctores);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> GetById(string id)
        {
            var medico = await _dbContext.Medicos.FirstOrDefaultAsync(medico => medico.Id == id);
            if (medico == null) return NotFound($"No se encontro {id}");

            var result = _mapper.Map<GetUserDTO>(medico);

            return result;
        }


        //[HttpGet("user")]
        //public async Task<ActionResult<List<ApplicationUser>>> GetUser()
        //{
        //    var user = await _userManager.Users.ToListAsync();
        //    if (user == null) return BadRequest("No se encontro nada");

        //    return user;
        //}

    }
}
