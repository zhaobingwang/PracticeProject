using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PracticeProject.WebAPINetCore.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/values")]
    //[Route("api/{v:apiVersion}/values")]
    [ApiController]
    public class ValuesV1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1 from version1", "Value2 from version1" };
        }
    }

    [ApiVersion("2.0")]
    [Route("api/values")]
    //[Route("api/{v:apiVersion}/values")]
    [ApiController]
    public class ValuesV2Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1 from version2", "Value2 from version2" };
        }
    }

    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesNoVersionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 ", "value2" };
        }
    }
}
