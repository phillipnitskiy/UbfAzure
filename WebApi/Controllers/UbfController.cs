using System;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;
using Business.Interfacies.Interfacies;
using WebApi.Filters;
using WebApi.Infrastructure;

namespace WebApi.Controllers
{
    public class UbfController : ApiController
    {
        private readonly IUbfService _ubfServise;

        public UbfController(IUbfService ubfService)
        {
            _ubfServise = ubfService;
        }

        // POST: api/Ubf
        [HttpPost]
        [CustomExceptionFilter]
        public IHttpActionResult ValidateUbf([FromHeader] int producerId, [FromBody] XDocument xml)
        {
            var guid = _ubfServise.ValidateUbf(producerId, xml);
            return Json(new { id = guid, status = Status.InProcess.ToString() });
        }

        // GET: api/Ubf/5
        [HttpGet]
        [CustomExceptionFilter]
        public HttpResponseMessage GetValidatedUbf([FromHeader] int producerId, [FromUri] Guid id)
        {
            var xml = _ubfServise.GetValidatedUbf(producerId, id);
            return new HttpResponseMessage()
            {
                Content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml")
            };
        }
    }
}
