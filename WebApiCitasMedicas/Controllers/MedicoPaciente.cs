using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoPaciente : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
    }

    //[HttpPost]
    //public async Task<ActionResult> PostMedicoPaciente();
}
