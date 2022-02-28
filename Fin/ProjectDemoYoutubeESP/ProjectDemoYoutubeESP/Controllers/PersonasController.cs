using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDemoYoutubeESP.DTOs;
using ProjectDemoYoutubeESP.Entidades;

namespace ProjectDemoYoutubeESP.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PersonasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> Get()
        {
            return await context.Personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Direcciones = p.Direcciones.Select(d => new DireccionDTO { Id = d.Id, Calle = d.Calle, Pais = d.Pais}).ToList()
            }).ToListAsync();
        }

        [HttpGet("projectTo")]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetProjectTo()
        {
            return await context.Personas.ProjectTo<PersonaDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

    }
}
