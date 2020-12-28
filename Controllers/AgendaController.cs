using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Agenda.Models;
using WebApi.Agenda.Data;

namespace WebApi.Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : Controller
    {
        private readonly ApiDbContext _context;

        public AgendaController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Create(agenda Ag)
        {
            _context.Add(Ag);
            try
            {
               await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao adicionar registro.");
            }
            return Ok(Ag);
        }

        [HttpGet("consult")]
        public ActionResult<List<agenda>> GetAll()
        {   
            return _context.agenda.ToList();
        }

        [HttpPost("edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgendaController/Delete/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult<List<agenda>> Delete([FromBody] int id)
        {
            try
            {
                _context.agenda.Remove(_context.agenda.First(x => x.id == id));
                _context.SaveChanges();

                return _context.agenda.ToList();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao excluir registro.");
            }
            

            
        }
    }
}
