using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameController : Controller
    {
        private static readonly string[] Names = new[] {
            "Ruslan", "Olga", "Ivan", "Sofia"
        };
        [HttpGet]
        public IActionResult Get() => Ok(Names);
        [HttpGet]
        public IActionResult Get(int id) => id < Names.Length ? Ok(Names[id]) : NotFound();
    }
}
