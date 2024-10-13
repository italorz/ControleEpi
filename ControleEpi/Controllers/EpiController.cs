using ControleEpi.Data;
using ControleEpi.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleEpi.Controllers;
[ApiController]
[Route("[controller]")]
public class EpiController:ControllerBase


{
    private readonly AppdbContext _context;

    public EpiController(AppdbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult CriarEpi(Epi epi)
    {
        if (epi == null)
        {
            return NotFound("epi não informado");
        }
        _context.epis.Add(epi);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getEpi), new { id = epi.EpiId }, epi);
    }

    [HttpGet("{id}")]
    public ActionResult getEpi(int id)
    {
        if (id <= 0)
        {
            return BadRequest("id nao informado");
        }
        var epiEcontrado = _context.epis.FirstOrDefault(x => x.EpiId == id);

        return Ok(epiEcontrado);

    }

    [HttpGet]

    public ActionResult<IEnumerable<Epi>> AllEpi([FromQuery] int take=10,int skip = 0)
    {
        var all = _context.epis.Take(take).Skip(skip).ToList();
        if (all is null)
        {
            return NotFound("Nenhum registro encontrado");
        }
        return Ok(all);
    }

    [HttpPut("{id}")]

    public ActionResult UpdateEpi(int id,Epi epi)
    {
        if (id <= 0)
        {
            return BadRequest("id nao informado");
        }
        var epiEcontrado = _context.epis.FirstOrDefault(x => x.EpiId == id);
        if (epiEcontrado is null)
        {
            return NotFound("Epi não encontrada");
        }
        epiEcontrado.EpiName = epi.EpiName;
        epiEcontrado.EpiValidade = epi.EpiValidade;
        epiEcontrado.EpiDescricao = epi.EpiDescricao;
        _context.SaveChanges();
        return Ok(epiEcontrado);

    }

    [HttpDelete("{id}")]

    public ActionResult DeleteEpi(int id, Epi epi)
    {
        if (id <= 0)
        {
            return BadRequest("id nao informado");
        }
        _context.epis.Remove(epi);
        
       
        return Ok();

    }

    
}
