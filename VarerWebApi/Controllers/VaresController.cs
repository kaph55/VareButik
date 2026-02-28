using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VarerWebApi.Data;
using VarerWebApi.Models;

namespace VarerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaresController : ControllerBase
    {
        private readonly VarerWebApiContext _context;

        public VaresController(VarerWebApiContext context)
        {
            _context = context;
        }

        // GET: api/Vares
        [HttpGet]
        public IEnumerable<Vare> GetVare()
        {
            return _context.Vare.ToList();
        }


         // POST: api/Vares         
        [HttpPost]        
        public void PostVare(Vare vare)
        {             

            _context.Vare.Add(vare);
            _context.SaveChanges();

            
        }

        // GET: api/Vares/5
        [HttpGet("{id}")]
        public Vare GetVare(int id)
        {

            return _context.Vare.FirstOrDefault(v => v.Id == id);
        }
















        // PUT: api/Vares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public void PutVare(int id, Vare vare)
        //{


        //    _context.Entry(vare).State = EntityState.Modified;

        //     _context.SaveChanges();

        //}



        // DELETE: api/Vares/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteVare(int id)
        //{
        //    var vare = await _context.Vare.FindAsync(id);
        //    if (vare == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Vare.Remove(vare);
        //    await _context.SaveChangesAsync();          
            

        //    return NoContent();
        //}


    }
}
