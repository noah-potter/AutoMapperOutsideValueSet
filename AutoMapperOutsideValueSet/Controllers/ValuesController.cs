using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper.QueryableExtensions;

namespace AutoMapperOutsideValueSet.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IQueryable<TestModelDTO> Get()
        {
            IQueryable<test_model> testModels = new List<test_model> {
                new test_model()
            }.AsQueryable();

            return testModels.ProjectTo<TestModelDTO>(new { insideValue = "inside" });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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