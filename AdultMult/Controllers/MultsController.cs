using System.Collections.Generic;
using AdultMult.DataProvider;
using AdultMult.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdultMult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultsController : ControllerBase
    {
        private readonly AdultMultContext _context;

        public MultsController(AdultMultContext context)
        {
            _context = context;
        }

        // GET: api/Mults
        [HttpGet]
        public IEnumerable<Mult> Get()
        {
            return _context.Mults;
        }

        // POST: api/Mults
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
