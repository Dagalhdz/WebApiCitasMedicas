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
    public class AuthController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IMapper mapper)
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
                MedicoInfo = createUserDto.Info
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
                PacientesInfo = createUserDto.Info
            };
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded) return BadRequest("Error al guardad");

            return Ok("El dato se ha guradad Correctamente");
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var doctor = await _userManager.FindByIdAsync(id);
            if (doctor == null) return NotFound("No existe el doctor");
            var result = _userManager.DeleteAsync(doctor);

            return Ok("Se ha eliminado el usario correctamente");
        }
    }
}
