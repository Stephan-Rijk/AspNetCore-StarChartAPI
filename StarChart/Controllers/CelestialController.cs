using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async GeyById<IActionResult>(int id)
        {
            var celestialObject = _context.CelestialObjects.Find(id);
            if(CelestialObject == null)
                return NotFound();
            celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
            return Ok(celestialObject);
        }

        [HttpGet("{name}")]
        public async GetByName<IActionResult>(string name)
        {
            var celestialObject = _context.CelestialObjects.Where(e => e.Name == name);
            if (!celestialObject.Any()
                return NotFound();
            foreach (var celestialObject in celestialObject)
            {
                celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
            }
            return Ok(celestialObject.ToList());
        }

        [HttpGet]
        public async GetAll<IActionResult>()
        {
            var celestialObjects = _context.CelestialObjects.ToList();
            foreach (CelestialObject)
            {
                celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
            }
            return Ok(celestialObject);

        }
    }
}
