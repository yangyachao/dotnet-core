using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Versioning.Controllers.All
{
    [ApiVersion("1.0")]
    [ApiVersion("3.0")]
    [Route("api/[controller]")]
    public class ValuesAllController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "v1", "value1", "value2" };
        } 
        
        // GET api/values
        [HttpGet, MapToApiVersion("3.0")]
        public IEnumerable<string> GetV3()
        {
            return new string[] { "v3", "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
