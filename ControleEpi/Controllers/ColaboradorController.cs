using ControleEpi.Data;
using ControleEpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleEpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController:ControllerBase
    {
        private readonly AppdbContext _context;

        public ColaboradorController(AppdbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Colaborador>> AllColaborador()
        {
            var registro = _context.colaboradors.ToList();

            if (registro is null) return NotFound("não existe o nenhum colaborador cadastrado");

            return Ok(registro);
        
        }
        [HttpGet(Name = "colaborador_include_epi")]
        public ActionResult<IEnumerable<Colaborador>> ColaboradorIncludeEpi()
        {
            var registro = _context.colaboradors.Include(e=> e.listaEpis)
                                                .ThenInclude(ep => ep.Epi)    
                                                .ToList();

            if (registro is null) return NotFound("não existe o nenhum colaborador cadastrado");

            return Ok(registro);

        }
        [HttpGet("{id}")]
        public ActionResult FindColaborador(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id não foi informado corretamente");
            }
            var registro = _context.colaboradors.FirstOrDefault(x => x.ColaboradorId == id);
            if (registro is null) return NotFound("O registro nao foi encontrado");
            return Ok(registro);
        }

        [HttpPost]

        public ActionResult CreateColaborador(Colaborador colaborador)
        {
            if (colaborador is null)
            {
                return BadRequest();
            }
            _context.colaboradors.Add(colaborador);
            _context.SaveChanges();
            return CreatedAtAction(nameof(FindColaborador), new { id = colaborador.ColaboradorId }, colaborador);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateColaborador(int id, Colaborador colaborador)
        {
            if (id !=colaborador.ColaboradorId)
            {
                return NotFound("O colaborador informado nao foi encontrado");
            }
            _context.Entry(colaborador).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(colaborador);

        }

    }
}
