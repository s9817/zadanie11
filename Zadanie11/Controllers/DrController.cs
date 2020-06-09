using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie11.Models;

namespace Zadanie11.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DrController : ControllerBase
    {
        private readonly Services.IDrDbService _context;
        public DrController(Services.IDrDbService context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            Models.Doctor dr = _context.GetDoctor(id);
            if (dr == null) return BadRequest("nie ma lekarza z takim ID");
            else return Ok(dr);
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            Doctor dr = _context.AddDoctor(doctor);
            if (dr == null) return BadRequest("błąd podczas dodawania lekarza (takie ID juz istnieje)");
            else return Ok(dr);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            Doctor dr = _context.DeleteDoctor(id);
            if (dr == null) return BadRequest("Doktor z takim ID nie istnieje");
            else return Ok("Usunieto doktora");
        }

        [HttpPut]
        public IActionResult EditDoctor([FromBody] Doctor doctor)
        {
            Doctor dr = _context.EditDoctor(doctor);
            if (dr == null) return BadRequest("Doktor z takim ID nie istnieje");
            else return Ok("Zaktualizowano doktora");
        }
    }
}
