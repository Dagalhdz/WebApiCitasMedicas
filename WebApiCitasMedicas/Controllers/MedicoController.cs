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

        [HttpPost("RegistrarMedico")]
        public async Task<ActionResult> RegisterDoctor(CreateUserDto createUserDto)
        {
            var user = new Medico
            {
                Nombre = createUserDto.Nombre,
                ApellidoPaterno = createUserDto.ApellidoPaterno,
                FechaNacimiento = createUserDto.FechaNacimiento,
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                MedicoInfo = createUserDto.MedicoInfo
            };
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded) return BadRequest("Error al guardad");

            return Ok("El dato se ha guradad Correctamente");
        }
        [HttpPost("RegistrarPaciente")]
        public async Task<ActionResult> RegisterPaciente(CreateUserDto createUserDto)
        {
            var user = new Paciente
            {
                Nombre = createUserDto.Nombre,
                ApellidoPaterno = createUserDto.ApellidoPaterno,
                FechaNacimiento = createUserDto.FechaNacimiento,
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                PacientesInfo = createUserDto.MedicoInfo
            };
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded) return NotFound("Error al guardad");

            return Ok("El dato se ha guradad Correctamente");
        }


        [HttpPost("AgregarFamiliar")]
        public async Task<ActionResult> AgregarFamiliar([FromBody] FamiliarDTO familiarDto)
        {
            var familiar = _mapper.Map<Familiares>(familiarDto);
            _dbContext.Add(familiar);
            await _dbContext.SaveChangesAsync();
            return Ok("Agregado Correctamente");
        }

        [HttpGet]
        public async Task<ActionResult<List<Medico>>> Get()
        {
            var doctors = await _dbContext.Medicos.ToListAsync();
            if (doctors == null) return BadRequest("No se encontro nada");

            return doctors;
        }

        [HttpGet("user")]
        public async Task<ActionResult<List<ApplicationUser>>> GetUser()
        {
            var user = await _userManager.Users.ToListAsync();
            if (user == null) return BadRequest("No se encontro nada");

            return user;
        }
        [HttpGet("paciente")]
        public async Task<ActionResult<List<Paciente>>> GetPacientes()
        {
            var pacientes = await _dbContext.Pacientes.ToListAsync();
            if (pacientes == null) return BadRequest("No se encontro nada");

            return pacientes;
        }

        [HttpGet("paciente/{id}/familiares")]
        public async Task<ActionResult<List<FamiliarDTO>>> GetFamiliar(string id)
        {
            var familiares = await  _dbContext.Familiares.Where(p => p.PacienteId == id).ToListAsync();
            return _mapper.Map<List<FamiliarDTO>>(familiares);
        }
    }
}
