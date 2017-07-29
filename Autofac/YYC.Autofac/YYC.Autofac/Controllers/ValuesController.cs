using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YYC.Autofac.Services;

namespace YYC.Autofac.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller     
    {
        private readonly IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            this._valuesService = valuesService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return this._valuesService.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return this._valuesService.Find(id);
        }
    }
}
