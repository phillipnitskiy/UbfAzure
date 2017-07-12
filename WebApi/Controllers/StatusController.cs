using System;
using System.Web.Http;
using Business.Interfacies.Interfacies;
using WebApi.Infrastructure;

namespace WebApi.Controllers
{
    public class StatusController : ApiController
    {
        private readonly IUbfService _ubfServise;

        public StatusController(IUbfService ubfService)
        {
            _ubfServise = ubfService;
        }

        // GET: api/Status/5
        [HttpGet]
        public IHttpActionResult GetStatus([FromHeader] int producerId, [FromUri] Guid id)
        {
            var statusCode = _ubfServise.GetStatus(producerId, id);
            return Json(new {status = (Status) statusCode});
        }
    }
}
