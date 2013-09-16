using System;
using System.Collections.Generic;
using System.Web.Http;

using ServiceLayer;

namespace MvcApplication1.Controllers
{
    [LogActionWebApiFilter]
    public class ValuesController : ApiController
    {
        private readonly IManagerData1Layer _managerData1Layer;

        public ValuesController(IManagerData1Layer managerData1Layer)
        {
            _managerData1Layer = managerData1Layer;
        }
        // GET api/values

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _managerData1Layer.GetData2();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}