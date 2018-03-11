using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("/api/simple")]
    public class SimpleController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }
    }
}