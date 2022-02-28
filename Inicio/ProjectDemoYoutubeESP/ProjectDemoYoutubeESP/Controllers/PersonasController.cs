using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDemoYoutubeESP.Entidades;

namespace ProjectDemoYoutubeESP.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> Get()
        {
            return await context.Personas.Include(p => p.Direcciones).ToListAsync();
        }
    }
}
