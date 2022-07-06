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
            if (CelestialObject == null)
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

        [HttpPost]
        public async Create<IActionResult>([FromBody] CelestialObject celestialObject)
        {
            _context.CelestialObjects.Add(celestialObject);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = celestialObject.Id }, celestialObject);
        }

        [HttpPut("{id}")]
        public async Update<IActionResult>(int id, CelestialObject celestialObject)
        {
            var existingObject = _context.CelestialObjects.Find(id);
            if (existingObject == null)
                return NotFound();
            existingObject.Name = celestialObject.Name;
            existingObject.OrbitalPeriod = celestialObject.OrbitalPeriod;
            existingObject.OrbitedObjectId = celestialObject.OrbitedObjectId;
            _context.CelestialObjects.Update(existingObject);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}/{name}")]
        public async RenameObject<IActionResult>([int id, string name], CelestialObject celestialObject)
        {
            var existingObject = _context.CelestialObjects.Find(id);
            if (existingObject == null)
                return NotFound();
        existingObject.name = name;
            _context.CelestialObjecs.Update(existingObject);
            _context.SaveChanges();
            return NoContent();
    }

    [HttpDelete("{id}")]
    public async Delete<IActionResult>(int id)
    {
        var celestialObjects = _context.CelestialObjects.Where(e => e.Id == id || e.OrbitedObjectId == id);
        if (!celestialObjects.Any())
            return NotFound();
        _context.CelestialObjects.RemoveRange(celestialObjects);
        _context.SaveChanges();
        return NoContent();
    }
}
}
