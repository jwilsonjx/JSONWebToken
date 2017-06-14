using JSON_WebToken_App.Filters;
using System.Collections.Generic;
using System.Web.Http;

namespace JSON_WebToken_App.Controllers
{

    public class DataController : ApiController
    {

        // GET: api/Value
        [JwtAuthentication]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
